using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface; 
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    /// <summary>
    /// 申请状态
    /// </summary>
    public enum ApplyState
    {
        /// <summary>
        /// 已拒绝
        /// </summary>
        asReject = -1,

        /// <summary>
        /// 已注册
        /// </summary>
        asRegister = 0,

        /// <summary>
        /// 已接收
        /// </summary>
        asReceive = 1,

        /// <summary>
        /// 检查中
        /// </summary>
        asExaming = 2,

        /// <summary>
        /// 报告中
        /// </summary>
        asReporting = 3,

        /// <summary>
        /// 已完成
        /// </summary>
        asComplete = 4

    }

    /// <summary>
    /// 申请来源
    /// </summary>
    public enum ApplySourceFrom
    {
        /// <summary>
        /// 门诊
        /// </summary>
        asfOutPatient = 1,

        /// <summary>
        /// 住院
        /// </summary>
        asfInPatient =2,
        
        /// <summary>
        /// 外来
        /// </summary>
        asfOutside = 3,

        /// <summary>
        /// 体检
        /// </summary>
        asfPhyExam = 4
    }


    /// <summary>
    /// 申请数据
    /// </summary>
    public class ApplyData:ApplyBase, IBizBindRow
    {        
        //private DataRow _bindRow = null;
        //private BizRow _applyRow = null;
        public JApply 申请信息 { get; set; }
        public JApplyLockInfo 锁定信息 { get; set; }

        protected override void InitJsonInstance()
        {
            申请信息 = new JApply();
            锁定信息 = new JApplyLockInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JApply).FullName)
                {
                    return JsonHelper.DeserializeObject<JApply>(jsonData);
                }
                else if (jsonTypeName == typeof(JApplyLockInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JApplyLockInfo>(jsonData);
                }

                return null;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, null);
                return null;
            }
        }
        
    }

    public class ApplyModel: DBModel
    {
        public ApplyModel(IDBQuery dbHelper) : base(dbHelper) { } 

        private SqlParamInfo[] GetApplyPars(ApplyData apply)
        {
            return new SqlParamInfo[] {
                        new SqlParamInfo("申请ID", DbType.String, apply.申请ID),
                        new SqlParamInfo("DcmUID", DbType.String, apply.DcmUID),
                        new SqlParamInfo("申请识别码", DbType.String, apply.申请识别码),
                        new SqlParamInfo("患者ID", DbType.String, apply.患者ID),
                        new SqlParamInfo("执行院区", DbType.String, apply.执行院区),
                        new SqlParamInfo("执行科室ID", DbType.String, apply.执行科室ID),
                        new SqlParamInfo("检查号", DbType.String, apply.检查号),
                        new SqlParamInfo("就诊卡号", DbType.String, apply.就诊卡号),
                        new SqlParamInfo("门诊号", DbType.String, apply.门诊号),
                        new SqlParamInfo("住院号", DbType.String, apply.住院号),
                        new SqlParamInfo("影像类别", DbType.String, apply.影像类别),
                        new SqlParamInfo("申请项目ID", DbType.String, apply.申请项目ID),
                        new SqlParamInfo("申请日期", DbType.DateTime,  apply.申请日期),
                        new SqlParamInfo("报到日期", DbType.DateTime, apply.报到日期),
                        new SqlParamInfo("申请状态", DbType.Int16, apply.申请状态),
                        new SqlParamInfo("申请信息", DbType.String, apply.申请信息.ToString()),
                        new SqlParamInfo("申请关联ID", DbType.String, apply.申请关联ID)
            };
        }

        public bool NewApply(ApplyData apply)
        { 
            SQL sql = CreateSQL("新增申请信息", "insert into " +
                  " 影像检查申请(申请ID, DcmUID, 患者ID, 申请识别码, 执行院区, 执行科室ID, 检查号, 就诊卡号, 门诊号, 住院号, 影像类别, 申请项目ID, 申请日期, :报到日期, 申请状态, 申请信息) " +
                  " values " +
                  " (:申请ID,:DcmUID,:患者ID,:申请识别码,:执行院区,:执行科室ID,:检查号,:就诊卡号,:门诊号,:住院号,:影像类别,:申请项目ID,:申请日期, 报到日期, :申请状态,:申请信息)");            
             
            SqlParamInfo[] sqlPars = GetApplyPars(apply);

            sql.AddParameterRange(sqlPars);

            DataTable dtResult = sql.ExecuteSql();            

            return true;
        }


        /// <summary>
        /// 使用从HIS数据库查询到的医嘱ID（主关键字），查询PACS数据库，判断此检查是否存在PACS库中
        /// </summary>
        /// <param name="strOrderIDs">医嘱ID串，使用逗号连接</param>
        /// <returns></returns>
        public  string GetPacsApplyByOrderID(string strOrderIDs)
        {
            string strOutOrderIDs = "";

            SQL sql =SqlHelper.CreateSQL("申请检索比对PACS数据", "Select Distinct a.申请识别码 From 影像检查申请 A Where a.申请识别码 in :申请识别码");

            sql.AddParameter("申请识别码", DbType.String, strOrderIDs);           

            DataTable dtResult = _dbHelper.ExecuteSQL(sql);

            foreach (DataRow dtItem in dtResult.Rows)
            {
                strOutOrderIDs = strOutOrderIDs + "," + dtItem["申请识别码"];                               
            }
            if (strOutOrderIDs.Length >0)
            {
                strOutOrderIDs = strOutOrderIDs.Substring(2);
            }
            return strOutOrderIDs;
        }



        /// <summary>
        /// 获取申请信息
        /// </summary>
        /// <param name="searchKeys"></param>
        /// <returns></returns>
        public DataTable GetPacsApply(Dictionary<string, object> searchKeys)
        {
            string strSQL;
            DataTable dt;
            string strFilter = null;

            foreach (var oneKey in searchKeys)
            {
                switch (oneKey.Key)
                {
                    case "门诊号":
                    case "住院号":
                    case "就诊卡号":
                    case "检查号":
                        strFilter = strFilter + " And a." + oneKey.Key + " = :" + oneKey.Key;
                        break;                                            
                    //case "医保号":
                    case "身份证号":
                        strFilter = strFilter + " And b." + oneKey.Key + " = :" + oneKey.Key;
                        break;
                    case "姓名":
                        if(oneKey.Value.ToString().Contains("*"))
                        {
                            strFilter = strFilter + " And instr( b." + oneKey.Key + " , :" + oneKey.Key +")>0";
                        }
                        else
                        {
                            strFilter = strFilter + " And b." + oneKey.Key + " = :" + oneKey.Key;
                        }                        
                        break;
                    //case "体检号":
                    //    strFilter = strFilter + " And E.健康号 = :" + oneKey.Key;
                    //    break;
                    case "申请日期":
                        strFilter = strFilter + " And a.申请日期 > :" + oneKey.Key;
                        break;
                    case "报道日期":
                        strFilter = strFilter + " And a.报到日期 > :" + oneKey.Key;
                        break;

                    case "检查室":
                        strFilter = strFilter + " And d.房间名称 = :" + oneKey.Key;
                        break;
                    case "检查设备":
                        strFilter = strFilter + " And e.设备名称 = :" + oneKey.Key;
                        break;
                    case "检查项目":
                        strFilter = strFilter + " And f.项目名称 = :" + oneKey.Key;
                        break;
                    case "扫描申请单":
                        if (oneKey.Value.ToString() == "1")
                        {
                            strFilter = strFilter + " And g.扫描id is not null";
                        }
                        break;
                    default:
                        break;
                }
            }

            if (searchKeys.ContainsKey("姓名"))
            {
                searchKeys["姓名"] = searchKeys["姓名"].ToString().Replace("*", "");
            }

            //strSQL = @"select b.姓名, a.申请id,a.患者id,a.执行科室id,a.检查号,a.就诊卡号,
            //            a.门诊号,a.住院号,a.申请日期,a.申请状态,a.申请信息,a.申请关联id,a.影像类别,
            //            a.申请识别码,b.身份证号,b.患者信息,b.患者关联id,b.患者识别码 ,a.执行院区
            //            from 影像检查申请 a,影像患者信息 b where a.患者id = b.患者id and 
            //            a.删除标记 is null  ";



            strSQL = @"select b.姓名, a.申请id,a.患者id,a.执行科室id,a.检查号,a.就诊卡号,
                        a.门诊号,a.住院号,a.申请日期,a.报到日期, a.申请状态,a.申请信息,a.申请关联id,a.影像类别,
                        a.申请识别码,b.身份证号,b.患者信息,b.患者关联id,b.患者识别码 ,a.执行院区,
                        c.执行id,c.部位序号,c.部位名称,c.房间id,c.设备id,c.执行信息,
                        d.房间名称,e.设备名称,f.项目名称 as 检查项目,g.扫描id
                        from 影像检查申请 a,影像患者信息 b, 影像检查执行 c,影像房间信息 d,
                        影像设备信息 e ,影像项目信息 f ,影像申请扫描 g 
                        where a.患者id = b.患者id and c.申请id(+) = a.申请id 
                        and d.房间id(+)=c.房间id and c.设备id=e.设备id(+) and f.项目id = a.申请项目id 
                        and a.申请id = g.申请id(+) and a.删除标记 is null ";
            strSQL = strSQL + strFilter;
            SQL sql = SqlHelper.CreateSQL("影像检查检索", strSQL);
            
            dt = _dbHelper.ExecuteSQL(strSQL, searchKeys);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                //MsgBox.ShowInf("查询不到数据");                
                return null;
            }
        }

        public void DelApply(ApplyData apply)
        {

        }

        public void UpdateApply(ApplyData apply)
        {
            SQL sql = SqlHelper.CreateSQL("修改申请信息", @"update 影像检查申请 a set a.患者id = :患者id ,
                a.执行院区=:执行院区,a.执行科室id=:执行科室id,a.检查号=:检查号,a.就诊卡号=:就诊卡号,
                a.门诊号=:门诊号,a.住院号=:住院号,a.影像类别=:影像类别,a.申请日期=:申请日期,a.报到日期=:报到日期,
                a.申请状态=:申请状态,a.申请信息=:申请信息,a.申请关联id=:申请关联id,
                a.申请识别码=:申请识别码 where a.申请id=:申请id");

            SqlParamInfo[] sqlPars = GetApplyPars(apply);

            sql.AddParameterRange(sqlPars);

            _dbHelper.ExecuteSQL(sql);
        }

        public string GetDepartmentName(string strDepartmentID)
        {
            SQL sql = SqlHelper.CreateSQL("通过ID查找科室名称", "Select 科室名称 From 影像科室信息 where 科室ID = :科室ID ");
            sql.AddParameter("科室ID", DbType.String, strDepartmentID);

            object result = _dbHelper.ExecuteSQLOneOutput(sql);

            return (result == null ? "" : result.ToString());           
        }

        /// <summary>
        /// 获取申请关键数据
        /// </summary>
        /// <param name="applyId"></param>
        /// <returns></returns>
        public DataTable GetApplyKeyData(string applyId)
        {
            SQL sql = CreateSQL("查询申请关键数据", "Select a.申请ID,a.申请识别码,b.患者ID,b.患者识别码 From 影像检查申请 a, 影像患者信息 b" +
                                        " Where a.患者ID=b.患者ID and a.申请ID=:申请ID");
            sql.AddParameter("申请ID", applyId);

            return sql.ExecuteSql();
        }

        public DataTable GetApplyKeyData1(string applyId)
        {
            SQL sql = CreateSQL("查询申请关键数据", "Select a.申请ID,a.申请识别码,b.患者ID,b.患者识别码 From 影像检查申请 a, 影像患者信息 b" +
                                        " Where a.患者ID=b.患者ID and a.申请ID=:申请ID");
            sql.AddParameter("申请ID", applyId);

            return sql.ExecuteSql();
        }

        /// <summary>
        /// 获取科室房间
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public DataTable GetRoomInfo(string departmentId)
        {
            SQL sql = CreateSQL("查询影像房间信息","select 房间ID,房间名称 from 影像房间信息 where 科室ID=:科室ID");
            sql.AddParameter("科室ID", DbType.String, departmentId);

            return sql.ExecuteSql();
        }

        /// <summary>
        /// 获取房间设备
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public DataTable GetDeviceInfo(string roomId)
        {
            SQL sql = CreateSQL("查询影像设备信息", "select 设备ID,设备名称 from 影像设备信息 where 房间ID=:房间ID");
            sql.AddParameter("房间ID", DbType.String, roomId);

            return sql.ExecuteSql();
        }

        /// <summary>
        /// 获取影像检查项目
        /// </summary>
        /// <returns></returns>
        public DataTable GetStudyItems()
        {
            SQL sql =  CreateSQL("查询影像检查项目", "select a.项目id,a.项目名称 from 影像项目信息 a ");
            return sql.ExecuteSql();
        }
    }
}

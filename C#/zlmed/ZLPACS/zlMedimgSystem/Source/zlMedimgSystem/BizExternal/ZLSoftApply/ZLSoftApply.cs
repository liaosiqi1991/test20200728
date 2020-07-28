using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Collections;
using System.Text.RegularExpressions;
using zlMedimgSystem.ExtInterface;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.APPLY.ZLSoftApply
{
    public class InterfaceCfg
    {
        /// <summary>
        /// 服务器类型
        /// </summary>
        public string ServerType { get; set; }

        /// <summary>
        /// 接口文件
        /// </summary>
        public string InterfaceFile { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 服务器实例
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// 授权账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 授权密码
        /// </summary>
        public string Pwd { get; set; }
    }

    public class ZLSoftApply : IApply
    {
        #region 私有属性
        private const string _name = "中联申请交互接口";
        private IDBQuery _dbQuery;
        private InterfaceCfg _cfgData=null;
        private IDBProvider _dbProvider = null;
        private string _userName = null;

        private string _cfgContext = "";
        #endregion

        #region 公共属性
        public string InterfaceName { get { return _name; } }

        public IExpense Expense { get; }

        /// <summary>
        /// 数据库连接串
        /// </summary>
        public string ConfigString
        {
            get
            {
                return _cfgContext;
            }
            set
            {
                _cfgContext = value;
            }
        }

        /// <summary>
        /// 当前操作的用户名称，HIS和PACS中使用相同的名称
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }
        #endregion

        #region 公共方法
        public void Init(IDBQuery dbQuery)
        {
            _dbQuery = dbQuery;

            _cfgData = null;

            try
            { 
            if (string.IsNullOrEmpty(_cfgContext) == false)
            {
                _cfgData = JsonHelper.DeserializeObject<InterfaceCfg>(_cfgContext);                
            }
            else
            {
                _cfgData = new InterfaceCfg();
            }

            ConnectDB();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex);
            }
        }

        /// <summary>
        /// 申请接口配置
        /// </summary>
        public bool ShowCfg(IWin32Window owner)
        {
            using (frmHisDBConfig cfg = new frmHisDBConfig())
            {
                InterfaceCfg cfgData = null;

                if (string.IsNullOrEmpty(_cfgContext) == false)
                {
                    cfgData = JsonHelper.DeserializeObject<InterfaceCfg>(_cfgContext);
                }
                else
                {
                    cfgData = new InterfaceCfg();
                }

                if (cfg.ShowCfg(cfgData, owner))
                {
                    _cfgContext = JsonHelper.SerializeObject(cfgData);
                    return true;
                }

                return false;
            }



        }


        /// <summary>
        /// 获取申请信息
        /// </summary>
        /// <param name="searchKeys"></param>
        /// <returns></returns>
        public DataTable GetApply(Dictionary<string, object> searchKeys)            
        {
            string strSQL;
            DataTable dt;
            string strFilter=null ;
            string strReceived = " and b.执行过程 = 0 ";

            try
            {
                foreach (var oneKey in searchKeys)
                {
                    switch (oneKey.Key)
                    {
                        case "门诊号":
                        case "住院号":
                        case "就诊卡号":
                        case "医保号":
                        case "身份证号":
                            strFilter = strFilter + " And E." + oneKey.Key + " = :" + oneKey.Key;
                            break;
                        case "姓名":
                            //支持模糊查找
                            if (oneKey.Value.ToString().Contains("*"))
                            {
                                strFilter = strFilter + " And instr(A.姓名,:姓名 ) > 0";                                
                            }
                            else
                            {
                                strFilter = strFilter + " And E." + oneKey.Key + " = :" + oneKey.Key;
                            }
                            
                            break;
                        case "体检号":
                            strFilter = strFilter + " And E.健康号 = :" + oneKey.Key;
                            break;
                        case "申请日期":
                            strFilter = strFilter + " And A.开嘱时间 > :" + oneKey.Key;
                            break;
                        case "性别":
                            strFilter = strFilter + " And A." + oneKey.Key + " = :" + oneKey.Key;
                            break;
                        case "联系电话":
                            strFilter = strFilter + " And (e.家庭电话 = :" + oneKey.Key + " Or e.联系人电话 = :" + oneKey.Key + " Or e.单位电话 = :" + oneKey.Key + ")";
                            break;
                        case "患者来源":
                            strFilter = strFilter + " And a.病人来源 = :" + oneKey.Key;
                            break;
                        case "危急值":
                            if (oneKey.Value.ToString() == "1")
                            {
                                strFilter = strFilter + " And (a.紧急标志 = 1 Or d.急诊 = 1)";
                            }                            
                            break;
                        case "已接收":
                            if (oneKey.Value.ToString() == "1")
                            {
                                strReceived = "";
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
                if(searchKeys.ContainsKey("患者来源"))
                {
                    searchKeys["患者来源"] = (searchKeys["患者来源"].ToString() == "住院" ? 2 : (searchKeys["患者来源"].ToString() == "门诊" ? 1 : (searchKeys["患者来源"].ToString() == "体检" ? 4 : 3)));
                }
                
                strSQL = @"select a.id as 医嘱ID ,decode(a.紧急标志,1,1,(decode(d.急诊,1,1,0))) as 紧急,a.姓名,a.性别,a.年龄, 
                        a.医嘱内容 as 项目名称,f.名称 as 申请科室,e.婚姻状况,e.病人ID,e.身份证号,e.国籍,e.籍贯,e.民族,
                        decode(a.病人来源, 2, '住院', 1, '门诊', 4, '体检', '外诊') as 来源,a.病人来源,e.职业,
                        To_Char(a.开嘱时间, 'YYYY-MM-DD HH24:MI:SS') as 申请日期,e.门诊号,e.住院号,e.医保号,
                        nvl(a.婴儿, 0) as 婴儿,decode(e.家庭地址,null,e.联系人地址,e.家庭地址) as 常用联系地址,
                        e.家庭地址邮编 as 常用邮编,decode(e.家庭电话,null,e.联系人电话,e.家庭电话) as 常用联系电话,
                        decode(e.工作单位,null,e.联系人地址,e.工作单位) as 备用联系地址,e.单位邮编 as 备用邮编,
                        decode(e.单位电话,null,e.联系人电话,e.单位电话) as 备用联系电话,a.开嘱医生 as 申请医生,
                        e.就诊卡号,e.健康号 as 体检号,e.当前床号 as 床号,a.医生嘱托 as 申请嘱托,a.执行科室id,
                        g.影像类别,a.主页ID
                        from 病人医嘱记录 a, 病人医嘱发送 b,病人挂号记录 d, 病人信息 e,部门表 f ,影像检查项目 g
                        where a.id = b.医嘱id  and a.挂号单 = d.no(+)  and a.病人id = e.病人id 
                        and a.开嘱科室id = f.id and g.诊疗项目id = a.诊疗项目id and a.医嘱状态 = 8  
                        and a.相关id is null ";

                strSQL = strSQL + strReceived + strFilter;


                dt = _dbProvider.ExecuteSQL(strSQL, searchKeys);            
                if (dt.Rows.Count > 0)
                {
                    //处理婴儿医嘱
                    DataRow[] drs = dt.Select("婴儿 >0");
                    foreach (DataRow dr in drs)
                    {
                        strSQL = @"SELECT A.婴儿姓名 ,A.婴儿性别,round(to_number(SYSDATE-A.出生时间))||'天' as 婴儿年龄 
                                FROM 病人新生儿记录 A,病人医嘱记录 B where a.病人id=b.病人id and a.主页id = b.主页id 
                                and a.序号 = b.婴儿 and b.id = :医嘱ID";
                        DataTable dtBaby = _dbProvider.ExecuteSQL(strSQL, "医嘱ID", dr["医嘱ID"]);
                        if (dtBaby.Rows.Count >= 1)
                        {
                            dr["姓名"] = dtBaby.Rows[0]["婴儿姓名"];
                            dr["性别"] = dtBaby.Rows[0]["婴儿性别"];
                            dr["年龄"] = dtBaby.Rows[0]["婴儿年龄"];
                        }
                    }
                    //处理婴儿医嘱 结束
                    return FormatDatatTable(dt);
                }
                else
                {
                   // MessageBox.Show("查询不到数据".ToString(), "提示");
                    return null;
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex);
                return null;
            }
        }
        

        /// <summary>
        /// 接收申请
        /// </summary>
        /// <param name="applyKey"></param>
        public void ReceiveApply(string applyKey)
        {
            Dictionary<string, object> pars = null;

            //对应HIS的“已报到”状态
            pars = new Dictionary<string, object>();
            pars.Add("医嘱id_In",  Int32.Parse(applyKey));
            pars.Add("Risid_In", 0);
            pars.Add("状态_In", 1);
            pars.Add("操作人员_In", "定一");

            _dbProvider.ExecuteProcedure("b_Zlxwinterface.Receiverisstate", pars);
            
        }

        /// <summary>
        /// 撤销申请接收
        /// </summary>
        /// <param name="applyKey"></param>
        public void CancelReceive(string applyKey) { }

        /// <summary>
        /// 发布报告
        /// </summary>
        public void PublishReport(string applyKey, string reportContext, string reportUrl) { }

        /// <summary>
        /// 收回报告
        /// </summary>
        public void BackReport(string applyKey) { }

        /// <summary>
        /// 完成申请
        /// </summary>
        public void CompleteApply(string applyKey) { }

        /// <summary>
        /// 撤销申请完成
        /// </summary>
        public void CancelComplete(string applyKey) { }


        /// <summary>
        /// 新开申请
        /// </summary>
        /// <param name="apply"></param>
        public void NewApply(Dictionary<string,string> applyInfo,Dictionary<string,string> patientInfo)
        {
            string strReturn;
            SaveOrderData(applyInfo, patientInfo,out strReturn);
            MsgBox.ShowInf("保存信息，返回：" + strReturn);
        }

        /// <summary>
        /// 提取医嘱的其他信息，临床诊断，医嘱附件
        /// <param name="OrderKey">医嘱关键字</param>
        /// </summary>
        public DataTable GetOrderInfo(string OrderKey)
        {           
            string strSQL;
            string strAttatch="";
            DataTable dtReturn = new DataTable();

            try
            {
                //医嘱附件               
                strSQL = "Select a.项目,a.内容 From 病人医嘱附件 a Where a.医嘱ID = :医嘱ID Order By 排列";
                DataTable dt = _dbProvider.ExecuteSQL(strSQL, "医嘱ID", Int32.Parse(OrderKey));
                foreach(DataRow dr in dt.Rows)
                {
                    if(dr["内容"].ToString() != "")
                    {
                        if (strAttatch == "")
                        {
                            strAttatch = "【" + dr["项目"] + "】\r\n" + dr["内容"];
                        }
                        else
                        {
                            strAttatch = strAttatch + "\r\n【" + dr["项目"] + "】\r\n" + dr["内容"];
                        }
                    }
                }

                //临床诊断，区分门诊和住院的临床诊断，提取方法不同，先按照门诊提，提不到再提住院诊断
                strSQL = @"select a.id, e.诊断描述 from 病人医嘱记录 a, 病人诊断医嘱 d,病人诊断记录 e  
                        where d.医嘱id = a.id and d.诊断id = e.id and a.id=:医嘱ID";
                dt = _dbProvider.ExecuteSQL(strSQL, "医嘱ID", Int32.Parse(OrderKey));
                if (dt ==null || dt.Rows.Count ==0)
                {
                    strSQL = @"Select a.id, e.诊断描述 From 病人医嘱记录 A, 病人诊断记录 E 
                        Where a.病人ID = e.病人id And a.主页id = e.主页id And e.记录来源 = 3 
                        And e.诊断类型 In ( 2, 12) And  e.诊断次序=1 And e.编码序号 = 1 And  a.id = :医嘱ID";
                    dt = _dbProvider.ExecuteSQL(strSQL, "医嘱ID", Int32.Parse(OrderKey));
                }
                string strDiag = "";
                if (dt !=null && dt.Rows.Count >1)
                {
                    int j = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (j == 1)
                        {
                            strDiag = j.ToString() + "、" + dr["诊断描述"].ToString() + "。";
                        }
                        else
                        {
                            strDiag = strDiag + "/r/n" + j.ToString() + "、" + dr["诊断描述"].ToString() + "。";
                        }
                    }
                }
                else if (dt!=null && dt.Rows.Count ==1)
                {
                    strDiag = dt.Rows[0]["诊断描述"].ToString() + "。";
                }    

                dtReturn.Columns.Add("医嘱ID", typeof(string));
                dtReturn.Columns.Add("附加内容", typeof(string));
                dtReturn.Columns.Add("临床诊断", typeof(string));
                
                dtReturn.Rows.Add( OrderKey, strAttatch,strDiag);
                return dtReturn;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex);
                return null;
            }
        }


        /// <summary>
        /// 拒绝执行
        /// </summary>
        /// <param name="applyKey"></param>
        public void RejectApply(string applyKey)
        {
            string sql = "b_Zlxwinterface.取消检查申请单";
            Dictionary<string, object> pars = new Dictionary<string, object>();
            try
            {                                
                pars.Add("医嘱id_In", applyKey);
                _dbProvider.ExecuteProcedure(sql, pars);               
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex);              
            }            
        }

        #endregion

        #region 私有方法


        /// <summary>
        /// 新建并保存医嘱
        /// </summary>
        /// <param name="applyInfo"></param>
        /// <param name="patientInfo"></param>
        /// <param name="strReturn"></param>
        /// <returns>0-成功
        /// -1:打开检查申请XML出错 ,
        ///       -2:诊疗项目没有设置执行科室
        ///       -3:医保对码检查失败，用户退出
        ///       -4:医保对码检查失败，禁止开申请
        ///       -5:打开病人信息XML出错
        ///       -6:创建新病人，但病人信息为空
        ///       -7:诊疗项目ID不正确
        ///       -8:保存新申请存储过程出错
        ///
        ///       -10:其他错误
        ///       -11:新建患者，身份证号重复</returns>
        private long SaveOrderData(Dictionary<string, string> applyInfo, Dictionary<string, string> patientInfo,out string strReturn)
        {           
            long lng执行科室ID;                        
            string str诊疗项目名称;
            string str诊疗项目类别;                       
            string sql;
            string strNO;
            long lngOrderID;
            long lngSeq = 0;
            strReturn = "";            
            DataTable dt;
            Dictionary<string, object> arrSql = new Dictionary<string, object>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            
            try
            {
                long lngMasSeq = 1;
                long lngSonSeq = 1;
                DateTime  dt申请时间 =Convert.ToDateTime( applyInfo["App_Date"].ToString());
                string str部位方法组合 = applyInfo["Body_Part_Method"].ToString();
                long lng紧急标志 = Int32.Parse(applyInfo["Emergency"].ToString());
                long lng申请科室ID = Int32.Parse(applyInfo["App_Dept_ID"].ToString());
                string str申请医生 = applyInfo["App_Doctor"].ToString();
                string str挂号NO = applyInfo["Reg_NO"].ToString();
                long lng主页ID = Int32.Parse(applyInfo["Page_ID"].ToString());
                string str医嘱内容 = applyInfo["Order_Content"].ToString();
                string strUserName = UserName;
                string strUserNo = "";
                string str病人姓名 = patientInfo["Patient_Name"].ToString();
                string str性别 = patientInfo["Patient_Sex"].ToString();
                string str年龄 = patientInfo["Patient_Age"].ToString();
                string str费别 = patientInfo["Fee_Type"].ToString();
                string str医疗付款方式 = patientInfo["Payment_Type"].ToString();
                string str民族 = patientInfo["Patient_Race"].ToString();
                string str婚姻状况 = patientInfo["Marital_Status"].ToString();
                string str职业 = patientInfo["Patient_Career"].ToString();
                string str家庭地址 = patientInfo["Address"].ToString();
                string str家庭电话 = patientInfo["Phone_Num"].ToString();
                string str家庭地址邮编 = patientInfo["Zip_Code"].ToString();
                DateTime  dt出生日期 =Convert.ToDateTime( patientInfo["Birthday"].ToString());
                long lng诊疗项目ID = Int32.Parse(applyInfo["Clinic_Item_ID"].ToString());
                long lng病人来源 = Int32.Parse(applyInfo["Patient_Source"].ToString());
                string str身份证号 = patientInfo["ID_Card"].ToString();
                string str国籍 = patientInfo["Patient_Nation"].ToString();
                DateTime curDate = DateTime.Now;
                string patientID = patientInfo["Patient_ID"];

                //根据诊疗项目ID，提取执行科室ID，体检和外诊都算门诊
                lng执行科室ID = Get诊疗执行科室(lng诊疗项目ID, (lng病人来源 == 2) ? 2 : 1);
                if (lng执行科室ID == 0)
                {
                    return -2;
                }

                //提取诊疗项目名称和类别
                sql = "select 类别,名称 from 诊疗项目目录 where id=:id";
                dt = _dbProvider.ExecuteSQL(sql, "id", lng诊疗项目ID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    str诊疗项目名称 = dt.Rows[0]["名称"].ToString();
                    str诊疗项目类别 = dt.Rows[0]["类别"].ToString();
                }
                else
                {
                    return -7;
                }

                //只有从门诊或住院开过来的医保病人才进行医保对码检查
                if (lng病人来源 == 1 || lng病人来源 == 2)
                {
                    //TODO，医保对码查询，还需要一个HIS的参数
                }

                if (patientID == "0")
                {
                    //新病人
                    //判断身份证号是否重复，如果重复，提示用户，禁止新建病人
                    sql = "select 病人id from 病人信息 where 身份证号=:身份证号";
                    dt = _dbProvider.ExecuteSQL(sql, "身份证号", str身份证号);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        MsgBox.ShowInf("身份证号出现重复，如果是新患者，请重新输入身份证号。");
                        return -11;
                    }
                    //提取新的病人ID
                    patientID = GetNextNo(1).ToString();

                    //sql ="zl_挂号病人病案_INSERT(1," + patientID + ",'','',''," +
                    //"'" + str病人姓名 + "','" + str性别 + "','" + str年龄 + "'," + "'" +
                    //str费别 + "','" + str医疗付款方式 + "'," + "'','" + str民族 + "','" +
                    //str婚姻状况 + "'," + "'" + str职业 + "','" + str身份证号 + "','','','','','" +
                    //str家庭地址 + "','" + str家庭电话 + "','" + str家庭地址邮编 + "'," +
                    //To_Date(curDate) + ",''," + To_Date(dt出生日期) +" ,null)";

                    sql = (arrSql.Count).ToString().PadLeft(3,'0') + "zl_挂号病人病案_INSERT";
                    pars = new Dictionary<string, object>();
                    pars.Add("处理类型_In", 1);
                    pars.Add("病人id_In", patientID);
                    pars.Add("门诊号_In", "");
                    pars.Add("就诊卡号_In", "");
                    pars.Add("卡验证码_In", "");
                    pars.Add("姓名_In", str病人姓名);
                    pars.Add("性别_In", str性别);
                    pars.Add("年龄_In", str年龄);
                    pars.Add("费别_In", str费别);
                    pars.Add("医疗付款方式_In", str医疗付款方式);
                    pars.Add("国籍_In", str国籍);
                    pars.Add("民族_In", str民族);
                    pars.Add("婚姻_In", str婚姻状况);
                    pars.Add("职业_In", str职业);
                    pars.Add("身份证号_In", str身份证号);
                    pars.Add("工作单位_In", "");
                    pars.Add("合同单位id_In", "");
                    pars.Add("单位电话_In", "");
                    pars.Add("单位邮编_In", "");
                    pars.Add("家庭地址_In", str家庭地址);
                    pars.Add("家庭电话_In", str家庭电话);
                    pars.Add("家庭地址邮编_In", str家庭地址邮编);
                    pars.Add("登记时间_In", curDate);
                    pars.Add("挂号单_In", "");
                    pars.Add("出生日期_In", dt出生日期);
                    arrSql.Add(sql, pars);                                                    
                }
                //保存医嘱并发送
                lngOrderID = GetNextID("病人医嘱记录");
                long lngSendNo =Int32.Parse( GetNextNo(10)); //医嘱发送号                   

                strNO = (lng病人来源 != 2) ? GetNextNo(13).ToString() : GetNextNo(14).ToString();
                
                //插入主医嘱
                lngSeq = lngSeq + 1;    //病人医嘱记录.序号，递增
                //sql =("ZL_病人医嘱记录_Insert(" + lngOrderID + ",NULL," + lngSeq + "," + lng病人来源 +
                //    "," + patientID + "," + ((lng病人来源 == 2) ? lng主页ID.ToString() : "NULL") + "," +
                //    "0,1,1,'" + str诊疗项目类别 + "'," + lng诊疗项目ID + ",NULL,NULL,NULL,1," +
                //    "'" + str诊疗项目名称 + ",常规执行:" + str医嘱内容 +
                //    "',NULL,NULL,'一次性',NULL,NULL,NULL,NULL,2," + lng执行科室ID + ",3," +
                //    lng紧急标志 + "," +To_Date( dt申请时间) + "," +To_Date( dt申请时间 )+ "," + lng申请科室ID +
                //    "," + lng申请科室ID + ",'" + str申请医生 + "'," + To_Date( curDate) + ",'" + str挂号NO +
                //    "',NULL,NULL,0,NULL,NULL,'" + strUserName + "')");

                sql = (arrSql.Count).ToString().PadLeft(3, '0') + "ZL_病人医嘱记录_Insert";
                pars = new Dictionary<string, object>();
                pars.Add("Id_In", lngOrderID);
                pars.Add("相关id_In", null);
                pars.Add("序号_In", lngSeq);
                pars.Add("病人来源_In", lng病人来源);
                pars.Add("病人id_In", patientID);
                pars.Add("主页id_In", (lng病人来源 == 2) ? lng主页ID.ToString() : null);
                pars.Add("婴儿_In", 0);
                pars.Add("医嘱状态_In", 1);
                pars.Add("医嘱期效_In", 1);
                pars.Add("诊疗类别_In", str诊疗项目类别);
                pars.Add("诊疗项目id_In", lng诊疗项目ID);
                pars.Add("收费细目id_In", null);
                pars.Add("天数_In", null);
                pars.Add("单次用量_In", null);
                pars.Add("总给予量_In", 1);
                pars.Add("医嘱内容_In", str诊疗项目名称 + ",常规执行:" + str医嘱内容);
                pars.Add("医生嘱托_In", null);
                pars.Add("标本部位_In", null);
                pars.Add("执行频次_In", "一次性");
                pars.Add("频率次数_In", null);
                pars.Add("频率间隔_In", null);
                pars.Add("间隔单位_In", null);
                pars.Add("执行时间方案_In", null);
                pars.Add("计价特性_In", 2);
                pars.Add("执行科室id_In", lng执行科室ID);
                pars.Add("执行性质_In", 3);
                pars.Add("紧急标志_In", lng紧急标志);
                pars.Add("开始执行时间_In", dt申请时间);
                pars.Add("执行终止时间_In", dt申请时间);
                pars.Add("病人科室id_In", lng申请科室ID);
                pars.Add("开嘱科室id_In", lng申请科室ID);
                pars.Add("开嘱医生_In", str申请医生);
                pars.Add("开嘱时间_In", curDate);
                pars.Add("挂号单_In", str挂号NO);
                pars.Add("前提id_In", null);
                pars.Add("检查方法_In", null);
                pars.Add("执行标记_In", 0);
                pars.Add("可否分零_In", null);
                pars.Add("摘要_In", null);
                pars.Add("操作员姓名_In", strUserName);
                arrSql.Add(sql, pars);

                //循环部位方法，插入附加医嘱
                //医嘱内容格式：颅脑(增强扫描,血管重建),蝶鞍(增强扫描,CT重建),颅底(增强扫描,CT重建)
                //部位方法格式：颅脑; 增强扫描,颅脑; 平扫
                long lngTempID;
                string str部位;
                string str方法;

                foreach (string oneBodypart in str部位方法组合.Split(','))
                {
                    str部位 = oneBodypart.Substring(0, oneBodypart.IndexOf(';'));
                    str方法 = oneBodypart.Substring(oneBodypart.IndexOf(';')+1);

                    lngSeq = lngSeq + 1;    //病人医嘱记录.序号，递增 
                    lngTempID = GetNextID("病人医嘱记录");

                    //sql =("ZL_病人医嘱记录_Insert(" + lngTempID + "," + lngOrderID + "," +
                    //    lngSeq + "," + lng病人来源 + "," + patientID + "," +
                    //    ((lng病人来源 == 2) ? lng主页ID.ToString() : "NULL") + "," +
                    //    "0,1,1,'" + str诊疗项目类别 + "'," + lng诊疗项目ID +
                    //    ",NULL,NULL,NULL,1," + "'" + str诊疗项目名称 + "',NULL," +
                    //    "'" + str部位 + "','一次性',NULL,NULL,NULL,NULL,2," +
                    //    lng执行科室ID + ",3," + lng紧急标志 + "," +To_Date( dt申请时间) +
                    //    "," +To_Date( dt申请时间) + "," + lng申请科室ID + "," + lng申请科室ID +
                    //    ",'" + str申请医生 + "'," +To_Date( curDate) + ",'" + str挂号NO +
                    //    "',NULL,'" + str方法 + "',0,NULL,NULL,'" + strUserName + "')");

                    sql = (arrSql.Count).ToString().PadLeft(3, '0') + "ZL_病人医嘱记录_Insert";
                    pars = new Dictionary<string, object>();
                    pars.Add("Id_In", lngTempID);
                    pars.Add("相关id_In", lngOrderID);
                    pars.Add("序号_In", lngSeq);
                    pars.Add("病人来源_In", lng病人来源);
                    pars.Add("病人id_In", patientID);
                    pars.Add("主页id_In", (lng病人来源 == 2) ? lng主页ID.ToString() : null);
                    pars.Add("婴儿_In", 0);
                    pars.Add("医嘱状态_In", 1);
                    pars.Add("医嘱期效_In", 1);
                    pars.Add("诊疗类别_In", str诊疗项目类别);
                    pars.Add("诊疗项目id_In", lng诊疗项目ID);
                    pars.Add("收费细目id_In", null);
                    pars.Add("天数_In", null);
                    pars.Add("单次用量_In", null);
                    pars.Add("总给予量_In", 1);
                    pars.Add("医嘱内容_In", str诊疗项目名称 );
                    pars.Add("医生嘱托_In", null);
                    pars.Add("标本部位_In", str部位);
                    pars.Add("执行频次_In", "一次性");
                    pars.Add("频率次数_In", null);
                    pars.Add("频率间隔_In", null);
                    pars.Add("间隔单位_In", null);
                    pars.Add("执行时间方案_In", null);
                    pars.Add("计价特性_In", 2);
                    pars.Add("执行科室id_In", lng执行科室ID);
                    pars.Add("执行性质_In", 3);
                    pars.Add("紧急标志_In", lng紧急标志);
                    pars.Add("开始执行时间_In", dt申请时间);
                    pars.Add("执行终止时间_In", dt申请时间);
                    pars.Add("病人科室id_In", lng申请科室ID);
                    pars.Add("开嘱科室id_In", lng申请科室ID);
                    pars.Add("开嘱医生_In", str申请医生);
                    pars.Add("开嘱时间_In", curDate);
                    pars.Add("挂号单_In", str挂号NO);
                    pars.Add("前提id_In", null);
                    pars.Add("检查方法_In", str方法);
                    pars.Add("执行标记_In", 0);
                    pars.Add("可否分零_In", null);
                    pars.Add("摘要_In", null);
                    pars.Add("操作员姓名_In", strUserName);
                    arrSql.Add(sql, pars);
                    //发送附加医嘱
                    //有收费单据号的为已计费,无的为未计费
                    lngSonSeq = lngSonSeq + 1;      //病人医嘱发送.记录序号，附加医嘱中的，要递增
                    //sql =("ZL_病人医嘱发送_Insert(" + lngTempID + "," + lngSendNo + "," +
                    //        ((lng病人来源 == 2) ? 2 : 1) + ",'" + strNO + "'," + lngSonSeq +
                    //        ",1," +To_Date( curDate) + "," +To_Date( curDate) + "," +To_Date( dt申请时间) + ",0," +
                    //        lng执行科室ID + "," + "0,0,NULL,'" + strUserNo + "','" + strUserName + "')");
                    sql = (arrSql.Count).ToString().PadLeft(3, '0') + "ZL_病人医嘱发送_Insert";
                    pars = new Dictionary<string, object>();
                    pars.Add("医嘱id_In", lngTempID);
                    pars.Add("发送号_In", lngSendNo);
                    pars.Add("记录性质_In", (lng病人来源 == 2) ? 2 : 1);
                    pars.Add("No_In", strNO);
                    pars.Add("记录序号_In", lngSonSeq);
                    pars.Add("发送数次_In", 1);
                    pars.Add("首次时间_In", curDate);
                    pars.Add("末次时间_In", curDate);
                    pars.Add("发送时间_In", dt申请时间);
                    pars.Add("执行状态_In", 0);
                    pars.Add("执行部门id_In", lng执行科室ID);
                    pars.Add("计费状态_In", 0);
                    pars.Add("First_In", 0);
                    pars.Add("样本条码_In", null);
                    pars.Add("操作员编号_In", strUserNo);
                    pars.Add("操作员姓名_In", strUserName);
                    arrSql.Add(sql, pars);  
                }
                //发送主医嘱
                //sql =("ZL_病人医嘱发送_Insert(" + lngOrderID + "," + lngSendNo + "," +
                //    ((lng病人来源 == 2) ? 2 : 1) + ",'" + strNO + "'," + lngMasSeq + ",1," +
                //   To_Date( curDate) + "," +To_Date( curDate) + "," +To_Date( dt申请时间) + ",0," + lng执行科室ID + "," +
                //    "0,1,NULL,'" + strUserNo + "','" + strUserName + "')");

                sql = (arrSql.Count).ToString().PadLeft(3, '0') + "ZL_病人医嘱发送_Insert";
                pars = new Dictionary<string, object>();
                pars.Add("医嘱id_In", lngOrderID);
                pars.Add("发送号_In", lngSendNo);
                pars.Add("记录性质_In", (lng病人来源 == 2) ? 2 : 1);
                pars.Add("No_In", strNO);
                pars.Add("记录序号_In", lngMasSeq);
                pars.Add("发送数次_In", 1);
                pars.Add("首次时间_In", curDate);
                pars.Add("末次时间_In", curDate);
                pars.Add("发送时间_In", dt申请时间);
                pars.Add("执行状态_In", 0);
                pars.Add("执行部门id_In", lng执行科室ID);
                pars.Add("计费状态_In", 0);
                pars.Add("First_In", 1);
                pars.Add("样本条码_In", null);
                pars.Add("操作员编号_In", strUserNo);
                pars.Add("操作员姓名_In", strUserName);
                arrSql.Add(sql, pars);

                bool inTrans = false;
                try
                {   //事务处理，执行SQL       
                    _dbProvider.TransactionBegin();
                    inTrans = true;
                    foreach (var oneSql in arrSql)
                    {
                        pars = oneSql.Value as Dictionary <string, object>;
                        _dbProvider.ExecuteProcedure(oneSql.Key.Substring(3), pars);
                    }
                    _dbProvider.TransactionCommit();
                    inTrans = false;
                }
                finally
                {
                    if (inTrans == true) _dbProvider.TransactionRollback();
                }

                long lng挂号ID = 0;
                //组织返回值
                sql = "Select ID As 挂号ID From 病人挂号记录 Where 记录性质 = 1 And 记录状态 = 1 And NO = :NO";
                dt = _dbProvider.ExecuteSQL(sql, "NO", str挂号NO);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lng挂号ID = Int32.Parse(dt.Rows[0]["挂号ID"].ToString());
                }

                strReturn = lngOrderID + "|" + lng执行科室ID + "|" + lngSendNo + "|" + lng挂号ID;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex);
            }
            //这个模式，无法直接生成主费用,生成主费用，需要使用HIS部件提供的功能，如果需要计费，需要手工生成主费用，或者补费。           
            return 0;
        }      

        /// <summary>
        /// 读取指定表名对应的序列(按规范，其序列名称为“表名称_id”)的下一数值
        /// </summary>
        /// <param name="strTable"></param>
        /// <param name="strField"></param>
        /// <returns></returns>
        private long GetNextID(string strTable )
        {
            string sql = "Select " + strTable + "_ID.Nextval as ID From Dual";
            DataTable dt = _dbProvider.ExecuteSQL(sql);
            if (dt !=null && dt.Rows.Count >0)
            {
                return int.Parse( dt.Rows[0]["ID"].ToString());
            }
            else
            {
                return 0;
            }

        }
               
        /// <summary>
        /// 根据诊疗项目执行科室信息返回可用的执行科室
        /// </summary>
        /// <param name="lng诊疗项目ID"></param>
        /// <param name="lng服务对象"></param>
        /// <param name="lng开单科室id"></param>
        /// <returns></returns>
        private long Get诊疗执行科室(long lng诊疗项目ID,long lng服务对象, long lng开单科室id = 0)
        {
            string sql = "Select Distinct A.ID,A.编码,A.简码,A.名称" +
                    " From 部门表 A,诊疗执行科室 B,部门性质说明 C" +
                    " Where A.ID=B.执行科室ID And B.诊疗项目ID=:诊疗项目ID And A.ID=C.部门ID" +
                    " And C.服务对象 IN(:服务对象,3) And (B.病人来源 is NULL Or B.病人来源=:服务对象)" +
                    " And (B.开单科室ID is NULL Or B.开单科室ID=:开单科室ID)" +
                    " And (A.撤档时间=TO_DATE('3000-01-01','YYYY-MM-DD') Or A.撤档时间 is NULL)" +
                    " Order by 编码";
            
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("服务对象", lng服务对象);
            pars.Add("开单科室ID", lng开单科室id);
            pars.Add("诊疗项目ID", lng诊疗项目ID);
            DataTable dt = _dbProvider.ExecuteSQL(sql,pars);
            if (dt !=null && dt.Rows.Count >0)
            {
                return  Int32.Parse( dt.Rows[0]["ID"].ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 提取HIS中的NextNO，最大号码
        /// </summary>
        /// <param name="lng序号"></param>
        /// <param name="lng科室ID"></param>
        /// <param name="strTag"></param>
        /// <param name="lngStep"></param>
        /// <returns></returns>
        private string GetNextNo(long lng序号,long lng科室ID=0,string strTag="",long lngStep=0)
        {
            string sql = "Select NextNO(:序号,:科室ID,:Tag,:Step) as NO From Dual";
            try
            {
                DataTable dt = _dbProvider.ExecuteSQL(sql, "序号", lng序号, "科室ID", lng科室ID, "Tag", strTag, "Step", lngStep);
                if (dt != null && dt.Rows.Count > 0)
                {

                    return dt.Rows[0]["NO"].ToString();
                }
                else
                {
                    return "0";
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex);
                return "0";
            }
        }
      
        private DataTable FormatDatatTable(DataTable dt)
        {
            //增加需要单独查询的列
            dt.Columns.Add("附加内容", typeof(string));
            dt.Columns.Add("临床诊断", typeof(string));

            //隐藏列 ：医嘱ID 等
            dt.Columns["医嘱ID"].ColumnMapping = MappingType.Hidden;
            dt.Columns["紧急"].ColumnMapping = MappingType.Hidden;
            dt.Columns["婴儿"].ColumnMapping = MappingType.Hidden;
            dt.Columns["婚姻状况"].ColumnMapping = MappingType.Hidden;
            dt.Columns["病人ID"].ColumnMapping = MappingType.Hidden;
            dt.Columns["身份证号"].ColumnMapping = MappingType.Hidden;
            dt.Columns["国籍"].ColumnMapping = MappingType.Hidden;
            dt.Columns["籍贯"].ColumnMapping = MappingType.Hidden;
            dt.Columns["民族"].ColumnMapping = MappingType.Hidden;
            dt.Columns["常用联系地址"].ColumnMapping = MappingType.Hidden;
            dt.Columns["常用联系电话"].ColumnMapping = MappingType.Hidden;
            dt.Columns["常用邮编"].ColumnMapping = MappingType.Hidden;
            dt.Columns["备用联系地址"].ColumnMapping = MappingType.Hidden;
            dt.Columns["备用联系电话"].ColumnMapping = MappingType.Hidden;
            dt.Columns["备用邮编"].ColumnMapping = MappingType.Hidden;
            dt.Columns["床号"].ColumnMapping = MappingType.Hidden;
            dt.Columns["申请医生"].ColumnMapping = MappingType.Hidden;
            dt.Columns["申请嘱托"].ColumnMapping = MappingType.Hidden;
            dt.Columns["附加内容"].ColumnMapping = MappingType.Hidden;
            dt.Columns["临床诊断"].ColumnMapping = MappingType.Hidden;

            //紧急标记改成图形               
            DataColumn c = new DataColumn("急", typeof(byte[]));
            dt.Columns.Add(c);           
            foreach (DataRow dr in dt.Select())
            {
                if (dr["紧急"].ToString() =="0")
                {
                    dr["急"] = imageToByte(Properties.Resources.Nothing);
                }
                else
                {
                    dr["急"] = imageToByte(Properties.Resources.Emergency);
                }                        
            }
            //dt.Columns.Remove("紧急");
            dt.Columns["急"].SetOrdinal(1);
            
            return dt;
        }

        //将image转换成byte[]数据
        private byte[] imageToByte(System.Drawing.Image _image)
        {
            MemoryStream ms = new MemoryStream();
            _image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        //将byte[]数据转换成image
        private Image byteToImage(byte[] myByte)
        {
            MemoryStream ms = new MemoryStream(myByte);
            Image _Image = Image.FromStream(ms);
            return _Image;
        }

        private bool ConnectDB()
        {
            try
            {                
                if (string.IsNullOrEmpty(_cfgData.InterfaceFile))
                {
                    MessageBox.Show("未指定对应的服务驱动文件，不能连接数据库。", "提示");
                    return false;
                }
                string modulePath = System.Windows.Forms.Application.StartupPath + @"\" + _cfgData.InterfaceFile;
                
                if (File.Exists(modulePath) == true)
                {
                    FileInfo fi = new FileInfo(modulePath);

                    string assemblyName = fi.Name.Replace(fi.Extension, "");
                    string[] tmp = ("..." + assemblyName).Split('.');
                    string objName = tmp[tmp.Length - 1];

                    _dbProvider = (IDBProvider)Assembly.LoadFile(modulePath).CreateInstance(assemblyName + "." + objName);
                }

                if (_dbProvider != null)
                {
                    _dbProvider.Init(_cfgData.Ip, _cfgData.Port,_cfgData.Instance ,_cfgData.Account ,_cfgData.Pwd);

                    string strError = "";
                    IDbConnection dc = _dbProvider.Open(ref strError);

                    if (dc == null)
                    {
                        MessageBox.Show("打开数据库失败：" + strError, "提示");
                        return false;
                    }
                    
                    return true;
                }
                else
                {
                    MessageBox.Show("数据访问实例创建失败。", "提示");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
                return false;
            }
        }

        #endregion
    }

}

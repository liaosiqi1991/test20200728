using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text; 
using zlMedimgSystem.Services;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.DataModel
{
    /// <summary>
    /// 患者数据
    /// </summary>
    public class PatientData : PatientBase,IBizBindRow 
    {       
        public JPatient 患者信息 { get; set; }

        protected override void InitJsonInstance()
        {
            患者信息 = new JPatient();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JPatient).FullName)
                {
                    return JsonHelper.DeserializeObject<JPatient>(jsonData);
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

    public class PatientModel : DBModel
    {
        public PatientModel(IDBQuery dbHelper) : base(dbHelper) { }        

        private SqlParamInfo[] GetPatientPars(PatientData patData)
        {
            return new SqlParamInfo[] {
                        new SqlParamInfo("患者id", DbType.String, patData.患者ID),
                        new SqlParamInfo("姓名", DbType.String, patData.姓名),
                        new SqlParamInfo("身份证号", DbType.String, patData.身份证号),
                        new SqlParamInfo("患者信息", DbType.String, patData.患者信息.ToString()),
                        new SqlParamInfo("患者关联id", DbType.String, patData.患者关联ID),
                        new SqlParamInfo("删除标记", DbType.String, patData.删除标记),
                        new SqlParamInfo("患者识别码", DbType.String, patData.患者识别码)                                            
            };
        }

        /// <summary>
        /// 新建一个患者
        /// </summary>
        /// <param name="patData"></param>
        /// <returns></returns>
        public bool NewPatient(PatientData patData)
        {
            ////新建患者之前，先查询是新建还是修改
            //sql = CreateSQL("查询患者是否存在", "select count(患者ID)  from 影像患者信息 where 患者ID = :患者ID");
            //sql.AddParameter("患者ID", DbType.String, patData.患者ID);
            //string strHere =  _dbHelper.ExecuteSQLOneOutput(sql).ToString();

            //if (strHere == "1")
            //{
            //    return UpdatePatient(patData);                
            //}

            SQL sql = CreateSQL("插入患者信息", "insert into " +
                  " 影像患者信息(患者id, 患者识别码, 姓名, 身份证号, 患者信息, 患者关联id, 删除标记) " +
                  " values " +
                  " (:患者id,:患者识别码,:姓名,:身份证号,:患者信息,:患者关联id,:删除标记)");          

            SqlParamInfo[] sqlPars = GetPatientPars(patData);
            sql.AddParameterRange(sqlPars);

            DataTable dtResult = sql.ExecuteSql();

            return true;
        }

        public bool UpdatePatient(PatientData patData)
        {
            SQL sql = CreateSQL("更新患者信息", "update 影像患者信息 a " +
                    " set a.姓名 = :姓名,a.身份证号= :身份证号,a.患者信息= :患者信息, " +
                    " a.患者关联id = :患者关联id,a.删除标记= :删除标记,a.患者识别码=:患者识别码 " +
                    " where 患者ID = :患者ID");
            SqlParamInfo[] sqlPars = GetPatientPars(patData);
            sql.AddParameterRange(sqlPars);

            DataTable dtResult = sql.ExecuteSql();

            return true;
        }

        /// <summary>
        /// 通过患者识别码查找患者
        /// </summary>
        /// <param name="patientCode"></param>
        /// <returns></returns>
        public PatientData GetPatientByPatientCode(string patientCode)
        {
            SQL sql = CreateSQL("根据患者识别码查询患者信息", "select 患者ID, 患者识别码,姓名,身份证号,患者信息,患者关联ID,删除标记 " +
                                                            " from 影像患者信息 where 患者识别码=:患者识别码");

            sql.AddParameter("患者识别码", patientCode);

            DataTable dtPatient = sql.ExecuteSql();

            if (dtPatient == null || dtPatient.Rows.Count <= 0) return null;

            PatientData patiData = new PatientData();
            patiData.BindRowData(dtPatient.Rows[0]);

            return patiData;
        }
    }
}

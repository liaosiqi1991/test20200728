using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using zlMedimgSystem.Services;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.DataModel
{

    public class StudyExecuteData:StudyExecuteBase, IBizBindRow
    {
        public JStudyExecute 执行信息 { get; set; }


        protected override void InitJsonInstance()
        {
            执行信息 = new JStudyExecute();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JStudyExecute).FullName)
                {
                    return JsonHelper.DeserializeObject<JStudyExecute>(jsonData);
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

    public class StudyExecuteModel:DBModel
    {
        public StudyExecuteModel(IDBQuery dbHelper) : base(dbHelper) { }

        private SqlParamInfo[] GetStudyExecPars(StudyExecuteData oneStudyExecuteData)
        {
            return new SqlParamInfo[] {
                        new SqlParamInfo("执行ID", DbType.String, oneStudyExecuteData.执行ID),
                        new SqlParamInfo("申请ID", DbType.String, oneStudyExecuteData.申请ID),
                        new SqlParamInfo("部位序号", DbType.String, oneStudyExecuteData.部位序号),
                        new SqlParamInfo("部位名称", DbType.String, oneStudyExecuteData.部位名称),
                        new SqlParamInfo("房间ID", DbType.String, oneStudyExecuteData.房间ID),
                        new SqlParamInfo("设备ID", DbType.String, oneStudyExecuteData.设备ID),
                        new SqlParamInfo("执行信息", DbType.String, oneStudyExecuteData.执行信息.ToString()),
                        new SqlParamInfo("执行状态", DbType.Int32, (int)oneStudyExecuteData.执行状态),
                        new SqlParamInfo("删除标记", DbType.String, oneStudyExecuteData.删除标记)
            };
        }

        /// <summary>
        /// 新增检查执行信息
        /// </summary>
        /// <param name="studyExecuteDatas"></param>
        /// <returns></returns>
        public bool NewStudyExecute(List<StudyExecuteData> studyExecuteDatas)
        {
            if (studyExecuteDatas == null) return true;

            SqlParamInfo[] sqlPars;

            SQL sql = SqlHelper.CreateSQL("新增检查执行信息", "insert into " +
                    " 影像检查执行(执行ID,申请ID,部位序号,部位名称,房间ID,设备ID,执行信息,执行状态,删除标记) " +
                    " values(:执行ID,:申请ID,:部位序号,:部位名称,:房间ID,:设备ID,:执行信息,:执行状态,:删除标记)");
            foreach(var oneStudyExecData in studyExecuteDatas)
            {
                sqlPars = GetStudyExecPars(oneStudyExecData);

                //先清除参数
                sql.ClearParameters();
                sql.AddParameterRange(sqlPars);
                DataTable dtResult = _dbHelper.ExecuteSQL(sql);
            }            
            return true;
        }

        /// <summary>
        /// 更新检查执行信息
        /// </summary>
        /// <param name="studyExecuteDatas"></param>
        /// <returns></returns>
        public bool UpdateStudyExecute(List<StudyExecuteData> studyExecuteDatas)
        {
            DelStudyExecute(studyExecuteDatas);
            return NewStudyExecute(studyExecuteDatas);
        }

        /// <summary>
        /// 删除检查执行信息
        /// </summary>
        /// <param name="studyExecuteDatas"></param>
        /// <returns></returns>
        public bool DelStudyExecute(List<StudyExecuteData> studyExecuteDatas)
        {
            if (studyExecuteDatas.Count == 0) return true;

            SQL sql = SqlHelper.CreateSQL("删除检查执行信息", "delete from 影像检查执行 where 申请ID = :申请ID");

            sql.AddParameter("申请ID", DbType.String, studyExecuteDatas[0].申请ID);
            _dbHelper.ExecuteSQL(sql);
            return true;
        }
        
        public DataTable GetStudyExecuteInfo(string str申请ID)
        {
            SQL sql = SqlHelper.CreateSQL("提取检查执行信息", "select 执行ID,申请ID,部位序号,部位名称,房间ID,设备ID,执行信息,执行状态,删除标记 from 影像检查执行 where 申请ID =:申请ID");
            sql.AddParameter("申请ID", DbType.String, str申请ID);
            return _dbHelper.ExecuteSQL(sql);
        }

        public List<StudyExecuteData> GetStudyExecuteData(string str申请ID)
        {
            List<StudyExecuteData> studyExecuteDatas = new List<StudyExecuteData>();
            StudyExecuteData oneStudyExecuteData;

            DataTable dt = GetStudyExecuteInfo(str申请ID);
            
            if (dt == null) return null;

            foreach(DataRow dw in dt.Rows)
            {
                oneStudyExecuteData = new StudyExecuteData();
                oneStudyExecuteData.BindRowData(dw);
                studyExecuteDatas.Add(oneStudyExecuteData);
            }
            return studyExecuteDatas;
        }
    }
}

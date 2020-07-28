using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public class StudyImplData: StudyImplBase, IBizBindRow
    {
        public JStudyImplInfo 执行信息 { get; set; }

        protected override void InitJsonInstance()
        {
            执行信息 = new JStudyImplInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JStudyImplInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JStudyImplInfo>(jsonData);
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
    public class StudyImplModel:DBModel
    {
        public StudyImplModel(IDBQuery dbHelper) : base(dbHelper) { }
    }
}

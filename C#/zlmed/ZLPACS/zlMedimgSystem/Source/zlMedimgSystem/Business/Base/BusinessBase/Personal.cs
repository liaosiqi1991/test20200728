using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BusinessBase
{
    public class Personal
    {
        /// <summary>
        /// 保存窗口位置
        /// </summary>
        /// <param name="window"></param>
        static public void SaveWindowPostion(Form window)
        {
            string setTag = window.Name + "." + Screen.AllScreens.Count().ToString().ToString() + ".";
             
            AppSetting.WriteSetting(setTag + "left", window.Left.ToString());
            AppSetting.WriteSetting(setTag + "top", window.Top.ToString());
            AppSetting.WriteSetting(setTag + "width", window.Width.ToString());
            AppSetting.WriteSetting(setTag + "height", window.Height.ToString());
        }

        /// <summary>
        /// 读取窗口位置
        /// </summary>
        /// <param name="window"></param>
        static public void RestoreWindowPostion(Form window)
        {
            string setTag = window.Name + "." + Screen.AllScreens.Count().ToString() + ".";

            window.Left = AppSetting.ReadInt(setTag + "left", window.Left);
            window.Top = AppSetting.ReadInt(setTag + "top", window.Top);
            window.Width = AppSetting.ReadInt(setTag + "width", window.Width);
            window.Height = AppSetting.ReadInt(setTag + "height", window.Height);
        }

        /// <summary>
        /// 设置应用程序窗口图标
        /// </summary>
        /// <param name="window"></param>
        static public void ResetAppIcon(Form window)
        {

        }

        static public void SaveGridView(GridView gv, string fileName)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                gv.SaveLayoutToStream(ms);
                ms.Position = 0;

                Dictionary<string, string> dic = new Dictionary<string, string>();

                using (StreamReader sr = new StreamReader(ms))
                {
                    dic.Add("layout", sr.ReadToEnd());
                }

                string fix = "";
                foreach(GridColumn gc in gv.Columns)
                {
                    if (gc.Fixed != FixedStyle.None)
                    {
                        if (string.IsNullOrEmpty(fix) == false) fix = fix + ",";
                        fix = fix + gc.FieldName + "-" + ((gc.Fixed == FixedStyle.Left) ? "0" : "1");
                    }
                }

                dic.Add("fix", fix);

                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    string json = DictionaryJsonHelper.SerializeDictionaryToJsonString<string, string>(dic);
                    sw.Write(json);

                    sw.Flush();
                }
            }

        }

        static public void RestoreGridView(GridView gv, string fileName)
        {
            Dictionary<string, string> dic = null;
            using (StreamReader sr = new StreamReader(fileName))
            {
                dic = DictionaryJsonHelper.DeserializeStringToDictionary<string, string>(sr.ReadToEnd());
            }

            if (dic != null)
            {
                using (MemoryStream ms = new MemoryStream())
                using (StreamWriter sw = new StreamWriter(ms))
                {
                    sw.Write(dic["layout"]);
                    sw.Flush();

                    ms.Position = 0;

                    gv.RestoreLayoutFromStream(ms);
                }
            }

            string fixs = dic["fix"];

            foreach(string fix in (fixs+",").Split(','))
            {
                if (string.IsNullOrEmpty(fix)) continue;

                string[] fixPro = (fix + "-0").Split('-');

                if (fixPro[1] == "1")
                {
                    gv.Columns[fixPro[0]].Fixed = FixedStyle.Right;
                }
                else
                {
                    gv.Columns[fixPro[0]].Fixed = FixedStyle.Left;
                }
            }
        }
    }
}

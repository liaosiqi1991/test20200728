using DevExpress.XtraBars.Docking;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.Design
{
    public static class DesignHelper
    {

        static public object OpenEventEditor(Control designParent, ISysDesign designInstance, object value)
        {
            return frmProEventEditor.EditValue(designParent, designInstance, value);
        }
        /// <summary>
        /// 获取组件的设计容器对象
        /// </summary>
        /// <param name="designControl"></param>
        /// <returns></returns>
        public static T GetDesignContainer<T>(Control designControl)
        {
            if (designControl == null) return default(T);

            Control parentDesign = designControl.Parent;


            while (parentDesign != null)
            {
                if (parentDesign.GetType() == typeof(T))
                {
                    return (T)((Object)parentDesign);
                }

                parentDesign = parentDesign.Parent;
            }

            return default(T);
        }
        
        public static List<Control> GetDesignControls(Control container)
        {
            List<Control> ctls = new List<Control>();

            ISysDesign root = container as ISysDesign;
            if (root != null)
            {
                ctls.Add(container);
            }

            foreach (Control ctl in container.Controls)
            {
                if ((ctl as ISysDesign) != null)
                {
                    ctls.Add(ctl);
                }
                else if (ctl.HasChildren == true)
                {
                    List<Control> subCtls = GetDesignControls(ctl);
                    foreach (Control subCtl in subCtls)
                    {
                        ctls.Add(subCtl);
                    }
                }
            }

            return ctls;
        }

        static public Image LoadFile(string imgFile)
        {
            using (Image img = Image.FromFile(imgFile))
            {
                return new Bitmap(img);
            }

        }

        static public void SaveDockManager(Form window, DockManager dckManager)
        {
            string setTag = window.Name + "." + Screen.AllScreens.Count().ToString().ToString() + ".";

            using (MemoryStream ms = new MemoryStream())
            using (StreamReader sr = new StreamReader(ms))
            {
                dckManager.SaveLayoutToStream(ms);
                ms.Position = 0;

                AppSetting.WriteSetting(setTag + "dock", sr.ReadToEnd()); 
            } 
        }

        static public void RestoreDockManager(Form window, DockManager dckManager)
        {
            string setTag = window.Name + "." + Screen.AllScreens.Count().ToString().ToString() + ".";

            string dckLayoutFmt = AppSetting.ReadSetting(setTag + "dock", "");

            if (string.IsNullOrEmpty(dckLayoutFmt)) return;

            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(ms))
            {
                sw.Write(dckLayoutFmt);
                sw.Flush();

                ms.Position = 0;

                dckManager.RestoreLayoutFromStream(ms);
            }
        }


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
    }



}

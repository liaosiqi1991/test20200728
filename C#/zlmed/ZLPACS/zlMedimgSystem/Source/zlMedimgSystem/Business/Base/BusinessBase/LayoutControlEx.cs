using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.BusinessBase
{
    static public class LayoutControlEx
    {
        //获取单个layout的布局配置
        static public void SetLayoutString(LayoutControl layout, string config)
        {
            layout.Items.Clear();
            layout.Controls.Clear();

            if (string.IsNullOrEmpty(config)) return;

            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(ms))
            {
                sw.Write(config);
                sw.Flush();

                ms.Position = 0;

                layout.RestoreLayoutFromStream(ms);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.CTL.RollText
{
    public class RollTextModuleDesign
    {
        public string BackgroundImage { get; set; }
        public ImageLayout BackgroundImageLayout { get; set; }
        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }

        public int RollSpeed { get; set; }
        public int RollDistance { get; set; }
        public string RollText { get; set; }
        public string FontName { get; set; }
        public float FontSize { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }



    }
}

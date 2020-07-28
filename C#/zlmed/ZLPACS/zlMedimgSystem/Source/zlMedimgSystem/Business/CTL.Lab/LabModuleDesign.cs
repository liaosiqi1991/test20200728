using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.CTL.Lab
{

    public enum PostionType
    {
        /// <summary>
        /// 顶部
        /// </summary>
        ipTop = 0,

        /// <summary>
        /// 左侧
        /// </summary>
        ipLeft = 1,

        /// <summary>
        /// 右侧
        /// </summary>
        ipRight = 2,

        /// <summary>
        /// 底部
        /// </summary>
        ipBottom = 3,

        /// <summary>
        /// 居中
        /// </summary>
        ipCenter = 4

    }

    public class LabModuleDesign
    {
        public string BackgroundImage { get; set; }
        public ImageLayout BackgroundImageLayout { get; set; }

        public string TextIcon { get; set; }
        public PostionType IconPostion { get; set; }
        public PostionType TextPostion { get; set; }
        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }
         public string LabText { get; set; }
        public string FontName { get; set; }
        public float FontSize { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }

        public bool UseDrag { get; set; }
        

    }
}

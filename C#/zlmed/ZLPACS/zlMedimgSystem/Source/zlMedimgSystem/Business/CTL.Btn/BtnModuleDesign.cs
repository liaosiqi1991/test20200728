using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.Btn
{


    public enum ButtonStyle
    {
        /// <summary>
        /// 默认样式
        /// </summary>
        bsDefault = 0,
        /// <summary>
        /// 简单样式
        /// </summary>
        bsSimple = 1,
        /// <summary>
        /// 平面样式
        /// </summary>
        bsFlat = 2
  
    }
    public enum ButtonImagePostion
    {
        /// <summary>
        /// 图像在文本上方
        /// </summary>
        bipImageAboveText = 0,
        /// <summary>
        /// 图像在文本下方
        /// </summary>
        bipTextAboveImage = 1,
        /// <summary>
        /// 图像在文字左侧
        /// </summary>
        bipImageBeforeText = 2,
        /// <summary>
        /// 图像在文字右侧
        /// </summary>
        bipTextBeforeImage = 3
    }

    public class BtnModulleDesign
    {
        public string Text { get; set; }
        public string Tag { get; set; }

        public ButtonStyle Style { get; set; }
        public ButtonImagePostion ImagePostion { get; set; }

        public string ImageName { get; set; }

        public Color BackColor { get; set; }

        public Color ForceColor { get; set; }

        public bool ClickReponse { get; set; }


        public string FontName { get; set; }

        public float FontSize { get; set; }
        public bool FontBold { get; set; }
        public bool FontItalic { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.QueueHint
{
    public class QueueItem
    {
        public string QueueId { get; set; }
        public string QueueName { get; set; }
    }

    public enum HeadDockWay
    {
        hdwTop = 0,
        hdwLeft = 1,
        hdwRight = 2,
        hdwBottom = 3

    }
    public class QueueHintModuleDesign
    {
        public string BackgroundImage { get; set; }
        public List<QueueItem> QueueItems { get; set; }

        public bool ShowHeader { get; set; }

        public string HeadText { get; set; }

        public HeadDockWay HeadDockWay { get; set; }

        public Color HeadBColor { get; set; }
        public Color HeadBColor2 { get; set; }
        public Color HeadFColor { get; set; }
        public string HeadFontName { get; set; }
        public float HeadFontSize { get; set; }
        public bool HeadFontBold { get; set; }
        public bool HeadFontItalic { get; set; }


        public Color TxtBColor { get; set; }
        public Color TxtBColor2 { get; set; }
        public Color TxtFColor { get; set; }
        public string TxtFontName { get; set; }
        public float TxtFontSize { get; set; }
        public bool TxtFontBold { get; set; }
        public bool TxtFontItalic { get; set; }

        /// <summary>
        /// 启用房间关联队列
        /// </summary>
        public bool UserRoomReleationQueue { get; set; }


        public QueueHintModuleDesign()
        {
            QueueItems = new List<QueueItem>();
        }
    }
}

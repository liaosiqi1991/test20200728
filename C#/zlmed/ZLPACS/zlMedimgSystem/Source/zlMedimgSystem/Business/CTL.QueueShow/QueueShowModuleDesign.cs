using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.QueueShow
{
    public class QueueShowModuleDesign
    {
        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }
        public int Column1Width { get; set; }
        public int Column2Width { get; set; }
        public int Column3Width { get; set; }

        public string FontName { get; set; }
        public float FontSize { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }

        public string HeadFontName { get; set; }
        public float HeadFontSize { get; set; }
        public bool HeadBold { get; set; }
        public bool HeadItalic { get; set; }

        public List<QueueItem> ReleationQueueItems { get; set; }

        public bool IsShowMiss { get; set; }
        public int WaitCount { get; set; }
        public string BackgroundImage { get; set; }

        public bool IsShowMemo { get; set; }
        public bool IsShowLastCall { get; set; }
        public bool IsShowCallIcon { get; set; }
        public bool IsShowQueueIcon { get; set; }

        public bool UseRoomQueueReleation { get; set; }

        public QueueShowModuleDesign()
        {
            ReleationQueueItems = new List<QueueItem>();
        }
    }
}

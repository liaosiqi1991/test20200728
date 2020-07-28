using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.QueueState
{

    public class QueueItem
    {
        public string QueueId { get; set; }
        public string QueueName { get; set; }

        public int BusyCount { get; set; }
    }

    public class QueueStateModuleDesign
    {
        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }

        public Color BusyColor { get; set; }
        public Color WorkColor { get; set; }
        public Color FreeColor { get; set; }

        public int DefaultBusyCount { get; set; }

        public string FontName { get; set; }
        public float FontSize { get; set; }
        public bool FontBold { get; set; }
        public bool FontItalic { get; set; }

        /// <summary>
        /// 使用房间队列关联
        /// </summary>
        public bool UseRoomQueueReleation { get; set; }
        public List<QueueItem> QueueItems { get; set; }

        public int FixRow { get; set; }
        public int FixColumn { get; set; }

        public QueueStateModuleDesign()
        {
            QueueItems = new List<QueueItem>();
        }
    }




}

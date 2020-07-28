using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.QueueQuick
{

    public class QueueItem
    {
        public string QueueId { get; set; }
        public string QueueName { get; set; } 
    }

    public class QueueQuickModuleDesign
    {
        public Color BackColor { get; set; }
        public Color ForeColor { get; set; }
        public Color CallColor { get; set; }

        public string ModuleFontName { get; set; }
        public float ModuleFontSize { get; set; }
        public bool ModuleFontBold { get; set; }
        public bool ModuleFontItalic { get; set; }

        public string WaitFontName { get; set; }
        public float WaitFontSize { get; set; }
        public bool WaitFontBold { get; set; }
        public bool WaitFontItalic { get; set; }
         
        public QueueQuickModuleDesign()
        {
        }
    }
}

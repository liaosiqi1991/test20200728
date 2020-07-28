using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.QueueManager
{
    public class QueueModuleDesign
    {
        public bool ButOrderCallVisible { get; set; }
        public bool ButDirectCallVisible { get; set; }
        public bool ButInsertQueueVisible { get; set; }
        public bool ButResetQueueVisible { get; set; }
        public bool ButPauseQueueVisible { get; set; }
        public bool ButAbandonQueueVisible { get; set; }
        public bool ButReceptQueueVisible { get; set; }
        public bool ButRestoreQueueVisible { get; set; }
        public bool ButRefreshQueueVisible { get; set; }
        public bool ButPrintQueueVisible { get; set; }
        public bool ButModifyQueueVisible { get; set; }
        public bool ButFindQueueVisible { get; set; }

        public ToolsDesign ToolsDesign { get; set; }

        public QueueModuleDesign()
        {
            ToolsDesign = new ToolsDesign();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.Capture
{
    public class CaptureModuleDesign
    {
        public ToolDockWay Dock { get; set; }
        
        public bool ButCaptureVisible { get; set; }
        public bool ButRecordVisible { get; set; }
        public bool ButRestartVisible { get; set; }
        public bool ButQuitVisible { get; set; }
        public bool ButSettingVisible { get; set; }

        public ToolsDesign ToolsDesign { get; set; }

        public CaptureModuleDesign()
        {
            ToolsDesign = new ToolsDesign();
        }
    }
}

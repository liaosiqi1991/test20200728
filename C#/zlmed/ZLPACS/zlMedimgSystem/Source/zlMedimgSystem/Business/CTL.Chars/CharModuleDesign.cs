using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.Chars
{
    public class CharModuleDesign
    {
        public bool ButSettingVisible { get; set; } 
        public ToolsDesign ToolsDesign { get; set; }

        public CharModuleDesign()
        {
            ToolsDesign = new ToolsDesign();
        }
    }
}

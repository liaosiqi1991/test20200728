using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.Image
{
    public class ImageModuleDesign
    {

        public bool ButImgRefreshVisible { get; set; }       
        public bool ButImgSettingVisible { get; set; }
        public ToolsDesign ToolsDesign { get; set; }

        public ImageModuleDesign()
        {
            ToolsDesign = new ToolsDesign();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.Design;

namespace zlMedimgSystem.CTL.Words
{

    public class WordsModuleDesign 
    {

        public bool ButWordLocateVisible { get; set; }
        public bool ButWordWriteVisible { get; set; }
        public ToolsDesign ToolsDesign { get; set; }

        public WordsModuleDesign()
        {
            ToolsDesign = new ToolsDesign();
        }



    }
}

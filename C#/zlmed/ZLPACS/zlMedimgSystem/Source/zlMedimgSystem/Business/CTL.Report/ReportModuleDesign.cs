using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.Report
{
    public class ReportModuleDesign
    {
        public bool ButSaveVisible { get; set; }
        public bool ButPreviewVisible { get; set; }
        public bool ButPrintVisible { get; set; }
        public bool ButReviseVisible { get; set; }
        public bool ButSureReviseVisible { get; set; }
        public bool ButQuitReviseVisible { get; set; }
        public bool ButSignVisible { get; set; }
        public bool ButSignManagerVisible { get; set; }
        public bool ButAddReportImgVisible { get; set; }
        public bool ButAllowViewVisible { get; set; }
        public bool ButGiveOutVisible { get; set; }
        public bool ButFinishedVisible { get; set; }
        public bool ButRefreshVisible { get; set; }
        public bool ButMoreVisible { get; set; }
        public bool ButNewVisible { get; set; }
        public bool ButRejectVisible { get; set; }
        public bool ButRejectManagerVisible { get; set; }
        public bool ButUnlockVisible { get; set; }
        public bool ButDelVisible { get; set; }
        public bool ButPDFConvertVisible { get; set; }
        public bool ButGiveInVisible { get; set; }
        public bool ButAbortViewVisible { get; set; }
        public bool ButEscFinishedVisible { get; set; }

        public ToolDockWay Dock { get; set; }

        public ToolsDesign ToolsDesign { get; set; }

        public ReportModuleDesign()
        {
            ToolsDesign = new ToolsDesign();
        }

    }
}

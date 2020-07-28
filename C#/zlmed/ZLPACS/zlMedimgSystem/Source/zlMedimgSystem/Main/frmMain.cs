using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Layout;

namespace zlMedimgSystem.Main
{
    public partial class frmMain : BizMainLayout
    {
         
        public frmMain()
            : this(true, null, "")
        {

        }

        public frmMain(bool isDesignMode, SplashScreenManager splash)
            :this(isDesignMode, splash, "")
        {

        }
        public frmMain(bool isDesignMode, SplashScreenManager splash, string layoutFmt)
            : base(isDesignMode, layoutFmt)
        {
            if (splash != null) splash.SetWaitFormDescription("加载窗口基础布局...");

            InitializeComponent();
        }

    }
}

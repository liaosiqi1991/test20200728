using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using DevExpress.XtraEditors;

namespace zlMedimgSystem.Design
{
    [ToolboxItem(false)]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class DockContainer : XtraUserControl
    {
        public DockContainer()
        {
            InitializeComponent();
        }
    }
}

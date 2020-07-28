using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmFuncDesign : Form
    {
        private IDBQuery _dbHelper = null;
        public frmFuncDesign(IDBQuery dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper;
        }

        private void tsbAdjustLayout_Click(object sender, EventArgs e)
        {
            funcDesigner1.DesignState = !funcDesigner1.DesignState;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            funcDesigner1.ShowTest();
        }
    }
}

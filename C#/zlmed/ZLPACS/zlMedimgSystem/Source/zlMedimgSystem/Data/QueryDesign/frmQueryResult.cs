using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.QueryDesign
{
    public partial class frmQueryResult : Form
    {
        private DataTable _bindTable = null;
        public frmQueryResult()
        {
            InitializeComponent();
        }

        public void ShowResult(IWin32Window owner, DataTable dt)
        {
            _bindTable = dt;

            this.ShowDialog(owner);
        }

        private void frmQueryResult_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _bindTable;
        }
    }
}

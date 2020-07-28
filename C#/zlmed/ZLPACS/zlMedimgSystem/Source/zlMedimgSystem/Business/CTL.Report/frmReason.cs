using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Report
{
    public partial class frmReason : Form
    {
        private string _reason = "";
        public frmReason()
        {
            InitializeComponent();
        }

        public string ShowReason(IWin32Window owner)
        {
            _reason = "";

            this.ShowDialog(owner);

            return _reason;
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                _reason = rtbReason.Text;
                this.Close();

            }catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            _reason = "";
            this.Close();
        }
    }
}

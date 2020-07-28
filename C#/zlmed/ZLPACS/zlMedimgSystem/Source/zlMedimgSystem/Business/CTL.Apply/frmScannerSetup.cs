using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.CTL.Apply
{
    public partial class frmScannerSetup : Form
    {
        public string OutValue;
        public List<string> scanList;        

        private string _scannerName = "";
        public frmScannerSetup()
        {
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            this.OutValue = _scannerName;            
        }

        private void frmScannerSetup_Load(object sender, EventArgs e)
        {                        

            cboScanner.Properties.Items.Clear();

            foreach(string scan in scanList)
            {
                cboScanner.Properties.Items.Add(scan);
            }
            
            if (cboScanner.Properties.Items.Count >0)
            {
                cboScanner.SelectedIndex = 0;
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (cboScanner.Text != "")
            {
                _scannerName = cboScanner.Text;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

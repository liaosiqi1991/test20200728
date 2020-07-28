using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Image
{
    public partial class frmImageConfig : Form
    {

        private string _sectionName = "";
        private ImageConfig _ic = null;


        public bool IsOk { get; set; }

        public frmImageConfig()
        {
            InitializeComponent();
        }

        public bool ShowImageConfig(ImageConfig ic, string sectionName, IWin32Window owner)
        {
            IsOk = false;

            _ic = ic;
            _sectionName = sectionName;

            this.ShowDialog(owner);

            return IsOk;

        }

        private void frmImageConfig_Load(object sender, EventArgs e)
        {
            if (Owner != null) this.Icon = Owner.Icon;

            try
            {
                IsOk = false;


                txtPageRecord.Text = Convert.ToString(_ic.RecordCount);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

     

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                _ic.RecordCount = Convert.ToInt32(txtPageRecord.Text); 

                ImageConfig.SetConfig(_ic, _sectionName);

                IsOk = true;

                this.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
 
    }
}

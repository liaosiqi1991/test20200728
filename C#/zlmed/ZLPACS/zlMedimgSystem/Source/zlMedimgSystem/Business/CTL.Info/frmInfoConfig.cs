using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Info
{
    public partial class frmInfoConfig : Form
    {
        private string _sectionName = "";
        private InfoConfig _ic = null;


        public bool IsOk { get; set; }

        public frmInfoConfig()
        {
            InitializeComponent();
        }

        public bool ShowImageConfig(InfoConfig ic, string sectionName, IWin32Window owner)
        {
            IsOk = false;

            _ic = ic;
            _sectionName = sectionName;

            this.ShowDialog(owner);

            return IsOk;

        }

        private void frmInfoConfig_Load(object sender, EventArgs e)
        {
            if (Owner != null) this.Icon = Owner.Icon;

            try
            {
                IsOk = false;


                txtZoomFactor.Text = Convert.ToString(_ic.ZoomFactor);

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
                _ic.ZoomFactor = (float)Convert.ToDouble(txtZoomFactor.Text);

                InfoConfig.SetConfig(_ic, _sectionName);

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

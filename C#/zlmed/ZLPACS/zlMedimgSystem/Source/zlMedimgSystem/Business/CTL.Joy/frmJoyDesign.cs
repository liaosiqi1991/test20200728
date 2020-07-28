using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.HardWare;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Joy
{
    public partial class frmJoyDesign : Form
    {
        private bool _isOk = false;

        private JoyPar _joyPar = null;
        public frmJoyDesign()
        {
            InitializeComponent();
        }

        public bool ShowJoyConfig(JoyPar joyPar, IWin32Window owner)
        {
            _isOk = false;

            _joyPar = joyPar;

            this.ShowDialog(owner);

            return _isOk;

        }

        private void InitJoyDevice()
        {
            List<string> joyNames = JoyDevice.GetJoyDevs();

            foreach (string name in joyNames)
            {
                cbxJoy.Items.Add(name);
            }
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                _joyPar.JoyName = cbxJoy.Text; 

                JoyPar.SetConfig(_joyPar);

                _isOk = true;

                this.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void frmJoyDesign_Load(object sender, EventArgs e)
        {
            try
            {
                InitJoyDevice(); 

                cbxJoy.Text = _joyPar.JoyName; 
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
    }
}

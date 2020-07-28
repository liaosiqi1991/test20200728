using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.ExtFuncs
{
    public partial class frmFuncTest : Form
    {
        private string _funcScheme = "";
        private string _result = "";
        public frmFuncTest()
        {
            InitializeComponent();
        }

        public string ShowTest(IWin32Window owner, string funcScheme)
        {
            _funcScheme = funcScheme;

            this.ShowDialog(owner);

            return _result;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                _result = "";
                this.Close();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmFuncTest_Load(object sender, EventArgs e)
        {
            try
            {
                fcDemo.LoadSchemeFromString(_funcScheme);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                _result = fcDemo.GetStorageData();
                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmFuncTest_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;

                fcDemo.AutoHeight = false;

                this.ClientSize = new Size(this.ClientSize.Width, fcDemo.GetLayoutHeight() + panel1.Height);

                fcDemo.AutoHeight = true;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);

            }
        }
    }
}

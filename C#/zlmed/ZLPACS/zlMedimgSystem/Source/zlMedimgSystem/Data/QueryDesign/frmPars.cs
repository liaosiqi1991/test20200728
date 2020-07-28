using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.QueryDesign
{
    public partial class frmPars : Form
    {
        private List<string> _sysPars = null;
        private string _selPar = "";
        public frmPars()
        {
            InitializeComponent();
        }

        public string ShowPars(List<string> sysPars, IWin32Window owner)
        {
            _selPar = "";
            _sysPars = sysPars;

            this.ShowDialog(owner);

            return _selPar;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                _selPar = listBox1.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmPars_Load(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();

                foreach(string par in _sysPars)
                {                    
                    listBox1.Items.Add("[系统_" + par.Replace("[", "").Replace("]", "") + "]");
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

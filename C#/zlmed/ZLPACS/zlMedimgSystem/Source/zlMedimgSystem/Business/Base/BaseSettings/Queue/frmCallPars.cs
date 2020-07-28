﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmCallPars : Form
    {
        private string _par = "";
        public frmCallPars()
        {
            InitializeComponent();
        }

        public string ShowCallPar(IWin32Window owner)
        {
            this.ShowDialog(owner);

            return _par;
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
                _par = listBox1.Text;

                this.Close();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }
    }
}

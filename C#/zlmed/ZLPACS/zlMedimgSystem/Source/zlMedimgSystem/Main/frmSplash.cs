using DevExpress.XtraWaitForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.Main
{
    public partial class frmSplash : WaitForm
    {
        public frmSplash()
        {
            InitializeComponent();
            InitTitle();
            this.progressPanel1.AutoHeight = false;
        }

        private void InitTitle()
        { 

            //if (string.IsNullOrEmpty(Program._appTitle) == false)
            //{
            //    labTitle.Text = Program._appTitle;
            //    this.Text = labTitle.Text;
            //}
        }

        #region Overrides

        public void SetTitle(string title)
        {
            //this.labTitle.Text = title;
        }

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            //ShowOnTopMode = ShowFormOnTopMode.AboveAll;
        }
    }
}

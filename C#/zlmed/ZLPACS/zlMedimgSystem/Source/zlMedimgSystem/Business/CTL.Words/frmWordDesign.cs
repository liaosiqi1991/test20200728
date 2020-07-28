using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Words
{
    public partial class frmWordDesign : Form
    {
        private bool _isOk = false;
        private WordsModuleDesign _wordModuleDesign = null;
        public frmWordDesign()
        {
            InitializeComponent();
        }

        public bool ShowDesign(WordsModuleDesign wordModuleDesign, IWin32Window owner)
        {
            _wordModuleDesign = wordModuleDesign;

            toolsConfig1.InitToolDesign(_wordModuleDesign.ToolsDesign);

            this.ShowDialog(owner);

            return _isOk;
        }

        private void frmWordDesign_Load(object sender, EventArgs e)
        {
            try
            {

                chkWordLocate.Checked = _wordModuleDesign.ButWordLocateVisible;
                chkWordWrite.Checked = _wordModuleDesign.ButWordWriteVisible;
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
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                toolsConfig1.ApplyUpdate();

                _wordModuleDesign.ButWordLocateVisible = chkWordLocate.Checked;
                _wordModuleDesign.ButWordWriteVisible = chkWordWrite.Checked;

                _wordModuleDesign.ToolsDesign = toolsConfig1.ToolsDesign;

                _isOk = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

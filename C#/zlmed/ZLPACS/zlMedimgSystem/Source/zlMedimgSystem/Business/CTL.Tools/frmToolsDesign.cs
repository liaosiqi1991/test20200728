using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;
using zlMedimgSystem.Design;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.Tools
{
    public partial class frmToolsDesign : Form
    {
        private bool _isOk = false; 
        private ToolsDesign _toolsDesign = null;
        public frmToolsDesign()
        {
            InitializeComponent();
        }

        public bool ShowDesign(ToolsDesign toolsDesign, IWin32Window owner)
        {
            _toolsDesign = toolsDesign;

            toolsConfig1.InitToolDesign(_toolsDesign);

            this.ShowDialog(owner);

            return _isOk;
        }
         
        private void frmToolsDesign_Load(object sender, EventArgs e)
        {
            try
            {

               

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

                _toolsDesign = toolsConfig1.ToolsDesign; 

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

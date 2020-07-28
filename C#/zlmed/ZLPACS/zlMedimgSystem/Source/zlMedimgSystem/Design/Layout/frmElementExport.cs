using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.Layout
{
    public partial class frmElementExport : Form
    {

        private DesignControl _exportEle = null;
        public frmElementExport()
        {
            InitializeComponent();
        }

        public void ShowTemplateExport(DesignControl element, IWin32Window owner)
        {
            _exportEle = element;

            this.ShowDialog(owner);
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
                string templateDir = Dir.GetAppTemplateDir() + @"\" + _exportEle.OriginalModule;

                if (Directory.Exists(templateDir) == false)
                {
                    System.IO.Directory.CreateDirectory(templateDir);
                }

                using (StreamWriter sw = new StreamWriter(templateDir + @"\" + txtName.Text))
                {
                    sw.Write(_exportEle.CustomDesignFmt);
                    sw.Flush();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

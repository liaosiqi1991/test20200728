using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;
using System.IO;

namespace zlMedimgSystem.Design
{
    public partial class frmImageResourceSelector : Form
    {
        private string _selImgResourceName = "";
        public frmImageResourceSelector()
        {
            InitializeComponent();
        }

        public string ShowImageResourceSelector(IWin32Window owner)
        {
            this.ShowDialog(owner);

            return _selImgResourceName;
        }
        private void frmImageResourceSelector_Load(object sender, EventArgs e)
        { 
            string[] files = Directory.GetFiles(Dir.GetAppResourceDir());
            foreach(string fileName in files)
            {
                fileListBox1.Items.Add(fileName);
            }
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
                _selImgResourceName = fileListBox1.Text;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void fileListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = DesignHelper.LoadFile(Dir.GetAppResourceDir() + @"\" + fileListBox1.Text);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

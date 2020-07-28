using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.ImgProcess
{
    public partial class ImagePreview : Form
    {
        private string _imgFile = "";
        private int _delayTime = 0;
        private int _alreadyTime = 0;
        public ImagePreview()
        {
            InitializeComponent();
        }

        static private ImagePreview _imagePreview = null;
        static public void ShowImagePreview(string imgFile, int delayTime, IWin32Window owner)
        {
            if (_imagePreview == null) _imagePreview = new ImagePreview();

            _imagePreview.ShowImage(imgFile, delayTime, owner);
        }

        static public void CloseImagePreview()
        {
            if (_imagePreview == null) return;

            _imagePreview.Close();
        }

 

        public void ShowImage(string imgFile, int delayTime, IWin32Window owner)
        {
            _imgFile = imgFile;
            _delayTime = delayTime;

            _alreadyTime = 0;
            _allowExit = false;
            this.Opacity = 100;
            timer1.Enabled = true;

            if (this.Visible == false)
            {
                this.Show(owner);
            }

            pictureBox1.Image = ImageEx.LoadFile(_imgFile);
        }

        private void frmImagePreview_Load(object sender, EventArgs e)
        {
            try
            {
                Personal.RestoreWindowPostion(this);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmImagePreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            _imagePreview = null;
        }

        private bool _allowExit = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            _alreadyTime = _alreadyTime + 50;

            if (_alreadyTime >= _delayTime)
            {
                _allowExit = true;
            }

            if (_allowExit)
            {
                this.Opacity = this.Opacity - 0.1;

                if (this.Opacity <= 0) this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ImagePreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Personal.SaveWindowPostion(this);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

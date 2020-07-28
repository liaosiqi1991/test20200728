using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using System.Drawing.Drawing2D;

namespace zlMedimgSystem.Services
{
    internal partial class frmMsgBox : Form
    {
        private const string ERR_MESSAGE = "应用程序发生了非预期的处理。\r\n单击“确定”按钮，应用程序将尝试继续执行。\r\n";
                  

        public Icon IconPic
        {
            set { this.Icon = value; }
        }

        public string ErrMsg
        {
            set { this.lblErrInfo.Text = value; }
        }

        public string ExtraMsg
        {
            set { this.mmeErrInfo.Text = value; }
        }

 

        private bool _isIniting = false;
        public frmMsgBox()
        {
            _isIniting = true;
            InitializeComponent();


            this.ResizeControl();
            this.Disposed += new EventHandler(frmMsgBox_Disposed);

            _isIniting = false;
        }

        void frmMsgBox_Disposed(object sender, EventArgs e)
        {
            //msgBox.Close();
            //msgBox = null;
        }

        private void frmMsgBox_Load(object sender, EventArgs e)
        {
            this.btnExtraNote.Text = "▽详细信息";

            this.mmeErrInfo.Visible = false;

            this.plErrInfo.Dock = DockStyle.Fill;
            this.plControl.Dock = DockStyle.Bottom;

            this.Height = this.Height - this.mmeErrInfo.Height;
        }

        private void btnExtraNote_Click(object sender, EventArgs e)
        {
            this.ResizeControl();
        }

        private void ResizeControl()
        {
            if (_isIniting == true) return;

            if (this.btnExtraNote.Text == "▽详细信息")
            {
                this.btnExtraNote.Text = "△详细信息";

                this.mmeErrInfo.Dock = DockStyle.Bottom;
                this.plControl.Dock = DockStyle.Bottom;
                this.mmeErrInfo.Visible = true;

                this.Height = this.Height + this.mmeErrInfo.Height;
            }
            else
            {
                this.btnExtraNote.Text = "▽详细信息";
                this.mmeErrInfo.Visible = false;

                this.plErrInfo.Dock = DockStyle.Fill;
                this.plControl.Dock = DockStyle.Bottom;

                this.Height = this.Height - this.mmeErrInfo.Height;
            }
        }

        private void ZlMsgBox_Resize(object sender, EventArgs e)
        {
            this.lblErrInfo.Left = this.picFormIcon.Left * 2 + this.picFormIcon.Width;
            this.lblErrInfo.Top = 10;
            this.lblErrInfo.Width = plErrInfo.Width - this.lblErrInfo.Left - 10;
            this.lblErrInfo.Height = plErrInfo.Height - 15;

            this.btnExtraNote.Left = 20;
            this.btnContinue.Left = this.ClientSize.Width - this.btnContinue.Width - 20;
        }

        public void ShowError(Exception ex, IWin32Window owner = null)
        {
            this.ShowError(ex, "", "", owner);
        }

        public void ShowError(Exception ex,  string hint, IWin32Window owner = null)
        {
            this.ShowError(ex, hint, "", owner);            
        }

        public void ShowError(Exception ex, string hint, string  caption, IWin32Window owner = null)
        {
            if (string.IsNullOrEmpty(hint) == true)
            {
                this.lblErrInfo.Text = "[" + DateTime.Now + "]" + ERR_MESSAGE + 
                        System.Environment.NewLine + System.Environment.NewLine + "描述信息：" + System.Environment.NewLine + GetAllException(ex);
            }
            else
            {
                string allExceptions = GetAllException(ex);

                if (string.IsNullOrEmpty(allExceptions) == true)
                {
                    this.lblErrInfo.Text = "[" + DateTime.Now + "]" + ERR_MESSAGE + ((string.IsNullOrEmpty(hint) == true) ? "" : System.Environment.NewLine + System.Environment.NewLine) + hint;
                }
                else
                {
                    this.lblErrInfo.Text = "[" + DateTime.Now + "]" + ERR_MESSAGE + ((string.IsNullOrEmpty(hint) == true) ? "" : System.Environment.NewLine + System.Environment.NewLine) + hint +
                        System.Environment.NewLine + System.Environment.NewLine +"描述信息：" + System.Environment.NewLine + allExceptions;
                }
            }

            this.mmeErrInfo.Text = ex.StackTrace;
            if (caption != "") this.Text = caption;

            this.Icon = SystemIcons.Warning;
            this.picFormIcon.BackgroundImage = this.Icon.ToBitmap();

            this.ShowDialog(owner);
        }

        private string GetAllException(Exception ex)
        {
            string erInfo = "";

            if (ex != null)
            {
                erInfo = erInfo + "■" + ex.Message;
                erInfo = erInfo + "\r\n\r\n" + this.GetAllException(ex.InnerException);

                return erInfo;
            }
            else
            {
                return "";
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMsgBox_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void tmerTopMost_Tick(object sender, EventArgs e)
        {
            try
            {
                this.TopMost = true;
            }
            catch{}
        }

        private void frmMsgBox_Shown(object sender, EventArgs e)
        {
            tmerTopMost.Enabled = true;
        }
    }
}

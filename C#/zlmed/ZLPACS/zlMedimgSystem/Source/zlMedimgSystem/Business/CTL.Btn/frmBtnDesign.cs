using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Btn
{
    public partial class frmBtnDesign : Form
    {
        private bool _isOk = false;
        private BtnModulleDesign _btnDesign = null;
        public frmBtnDesign()
        {
            InitializeComponent();
        }

        public bool ShowDesign(BtnModulleDesign btnDesign, IWin32Window owner)
        {
            _btnDesign = btnDesign;
             
            this.ShowDialog(owner);

            return _isOk;
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

                _btnDesign.Text = txtDesplay.Text;
                _btnDesign.Tag = txtButTag.Text;
                _btnDesign.ImageName = txtImgName.Text;
                _btnDesign.Style = (ButtonStyle)cbxStyle.SelectedIndex;
                _btnDesign.ImagePostion = (ButtonImagePostion)cbxIconPostion.SelectedIndex;
                _btnDesign.BackColor = labBkColor.Color;
                _btnDesign.ForceColor = labForeColor.Color;
                _btnDesign.ClickReponse = chkReponse.Checked;

                _btnDesign.FontName = feFontStyle.Value.Name;
                _btnDesign.FontSize = feFontStyle.Value.Size;
                _btnDesign.FontBold = feFontStyle.Value.Bold;
                _btnDesign.FontItalic = feFontStyle.Value.Italic;

                _isOk = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmBtnDesign_Load(object sender, EventArgs e)
        {
            try
            {

                txtDesplay.Text = _btnDesign.Text;
                txtButTag.Text = _btnDesign.Tag;
                txtImgName.Text = _btnDesign.ImageName;
                cbxStyle.SelectedIndex = (int)_btnDesign.Style;
                cbxIconPostion.SelectedIndex = (int)_btnDesign.ImagePostion;
                labBkColor.Color = _btnDesign.BackColor;
                labForeColor.Color = _btnDesign.ForceColor;
                chkReponse.Checked = _btnDesign.ClickReponse;


                float fontSize = 0;
                FontStyle fs = FontStyle.Regular;

                try
                {
                    fontSize = _btnDesign.FontSize;
                }
                catch { }
                if (fontSize <= 0) fontSize = this.Font.Size;

                if (_btnDesign.FontBold) fs = fs | FontStyle.Bold;
                if (_btnDesign.FontItalic) fs = fs | FontStyle.Italic;

                Font font = new Font(_btnDesign.FontName, fontSize, fs);
                feFontStyle.Value = font;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butLoadImg_Click(object sender, EventArgs e)
        {
            try
            {
                txtImgName.Text = Img24Resource.ShowImgResourcesSelector(this);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
 
    }
}

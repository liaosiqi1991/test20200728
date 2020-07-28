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

namespace zlMedimgSystem.CTL.Lab
{
    public partial class frmLabDesign : Form
    {
        private bool _isOk = false;
        private LabModuleDesign _labDesign = null;
        public frmLabDesign()
        {
            InitializeComponent();
        }

        public bool ShowLabDesign(LabModuleDesign labDesign, IWin32Window owner)
        {
            _isOk = false;

            _labDesign = labDesign;

            this.ShowDialog(owner);

            return _isOk;
        }

        private void frmLabDesign_Load(object sender, EventArgs e)
        {
            try
            {
                if (_labDesign == null) return;

                txtBackgroundImage.Text = _labDesign.BackgroundImage;
                cbxBkgroundLayout.SelectedIndex = (int)_labDesign.BackgroundImageLayout;

                txtIconName.Text = _labDesign.TextIcon;
                ceBackColor.Color = _labDesign.BackColor;
                ceForeColor.Color = _labDesign.ForeColor;
 
                 
                float fontSize = 0;

                try
                {
                    fontSize = _labDesign.FontSize;
                }
                catch { }
                if (fontSize <= 0) fontSize = this.Font.Size;

                FontStyle fs = FontStyle.Regular;

                if (_labDesign.IsBold) fs = fs | FontStyle.Bold;
                if (_labDesign.IsItalic) fs = fs | FontStyle.Italic;



                Font ft = new Font(_labDesign.FontName, fontSize, fs);
                feSetting.Value = ft;
                 

                rtbDisplayText.Text = _labDesign.LabText;

                cbxImagePostion.SelectedIndex = (int)_labDesign.IconPostion;
                cbxTextPostion.SelectedIndex = (int)_labDesign.TextPostion;

                chkDrag.Checked = _labDesign.UseDrag;

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
                _labDesign.BackgroundImage = txtBackgroundImage.Text;
                _labDesign.BackgroundImageLayout = (ImageLayout)cbxBkgroundLayout.SelectedIndex;

                _labDesign.TextIcon = txtIconName.Text;
                _labDesign.BackColor = ceBackColor.Color;
                _labDesign.ForeColor = ceForeColor.Color;
                _labDesign.FontName = feSetting.Value.Name;
                _labDesign.FontSize = feSetting.Value.Size;
                _labDesign.IsBold = feSetting.Value.Bold;
                _labDesign.IsItalic = feSetting.Value.Italic;
                _labDesign.LabText = rtbDisplayText.Text;
                _labDesign.IconPostion = (PostionType)cbxImagePostion.SelectedIndex;
                _labDesign.TextPostion = (PostionType)cbxTextPostion.SelectedIndex;
                 

                _labDesign.UseDrag = chkDrag.Checked;

                _isOk = true;

                this.Close();
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
                txtIconName.Text = Img24Resource.ShowImgResourcesSelector(this);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txtBackgroundImage.Text = Img24Resource.ShowImgResourcesSelector(this);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

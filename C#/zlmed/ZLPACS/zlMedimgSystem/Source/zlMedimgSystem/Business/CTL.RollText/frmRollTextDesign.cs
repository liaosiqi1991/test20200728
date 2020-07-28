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

namespace zlMedimgSystem.CTL.RollText
{
    public partial class frmRollTextDesign : Form
    {
        private bool _isOk = false;
        private RollTextModuleDesign _rollTextDesign = null;
        public frmRollTextDesign()
        {
            InitializeComponent();
        }

        public bool ShowRollTextDesign(RollTextModuleDesign rollTextDesign, IWin32Window owner)
        {
            _isOk = false;

            _rollTextDesign = rollTextDesign;

            this.ShowDialog(owner);

            return _isOk;
        }

        private void frmRollTextDesign_Load(object sender, EventArgs e)
        {
            try
            {
                if (_rollTextDesign == null) return;

                txtImgName.Text = _rollTextDesign.BackgroundImage;
                labBkColor.Color = _rollTextDesign.BackColor;
                labForeColor.Color = _rollTextDesign.ForeColor; 
                 
                float fontSize = 0;

                try
                {
                    fontSize =  _rollTextDesign.FontSize;
                }
                catch { }
                if (fontSize <= 0) fontSize = this.Font.Size;

                FontStyle fs = FontStyle.Regular;

                if (_rollTextDesign.IsBold) fs = fs | FontStyle.Bold;
                if (_rollTextDesign.IsItalic) fs = fs | FontStyle.Italic;

                

                Font ft = new Font(_rollTextDesign.FontName, fontSize,  fs);
                feFontDetail.Value = ft;

                txtSpeed.Text = Convert.ToString(_rollTextDesign.RollSpeed);
                txtDistance.Text = Convert.ToString(_rollTextDesign.RollDistance);

                rtbDisplayText.Text = _rollTextDesign.RollText;

                cbxLayout.SelectedIndex = (int)_rollTextDesign.BackgroundImageLayout;

            }
            catch(Exception ex)
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
                _rollTextDesign.BackgroundImage = txtImgName.Text;
                _rollTextDesign.BackColor = labBkColor.Color;
                _rollTextDesign.ForeColor = labForeColor.Color;
                _rollTextDesign.FontName = feFontDetail.Value.Name;
                _rollTextDesign.FontSize = feFontDetail.Value.Size;
                _rollTextDesign.IsBold = feFontDetail.Value.Bold;
                _rollTextDesign.IsItalic = feFontDetail.Value.Italic;
                _rollTextDesign.RollSpeed = Convert.ToInt32(txtSpeed.Text);
                _rollTextDesign.RollDistance = Convert.ToInt32(txtDistance.Text);
                _rollTextDesign.RollText = rtbDisplayText.Text;
                _rollTextDesign.BackgroundImageLayout = (ImageLayout)cbxLayout.SelectedIndex;
                
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
                txtImgName.Text = Img24Resource.ShowImgResourcesSelector(this);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmTextPars textpars = new frmTextPars())
                {
                    string par = textpars.ShowTextPar(this);

                    if (string.IsNullOrEmpty(par)) return;

                    rtbDisplayText.SelectedText = par;
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

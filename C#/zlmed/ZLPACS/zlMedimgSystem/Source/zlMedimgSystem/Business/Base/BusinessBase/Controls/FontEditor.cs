using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;
using System.Drawing.Text;

namespace zlMedimgSystem.BusinessBase.Controls
{
    public partial class FontEditor : UserControl
    {
        public FontEditor()
        {
            InitializeComponent();
        }

        public Font Value
        {
            get
            {
                return labView.Font;
            }
            set
            {
                cbxFontName.Text = value.Name;
                nuSize.Value = Convert.ToDecimal(value.Size);
                chkBold.Checked = value.Bold;
                chkItalic.Checked = value.Italic;

                ViewFont();
            }
        }

        private void ViewFont()
        {
            float fontSize = 0;
            try
            {
                fontSize =Convert.ToSingle(nuSize.Value);
            }
            catch { }
            if (fontSize <= 0) fontSize = this.Font.Size;

            FontStyle fs = FontStyle.Regular;

            if (chkBold.Checked) fs = fs | FontStyle.Bold;
            if (chkItalic.Checked) fs = fs | FontStyle.Italic;

            Font vf = new Font(cbxFontName.Text, fontSize, fs);

            labView.Font = vf;
        }

        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ViewFont();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ViewFont();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void nuSize_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ViewFont();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxFontName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ViewFont();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void FontEditor_Load(object sender, EventArgs e)
        {
            try
            {
                cbxFontName.Items.Clear();

                InstalledFontCollection fc = new InstalledFontCollection();

                foreach (FontFamily font in fc.Families)
                {
                    cbxFontName.Items.Add(font.Name);
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

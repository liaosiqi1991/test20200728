using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.History
{
    public partial class frmHistoryDesign : Form
    {
        private HistoryDesign _historyDesign = null;

        public frmHistoryDesign()
        {
            InitializeComponent();
        }

        public void ShowDesign(HistoryDesign historyDesign, IWin32Window owner)
        {
            _historyDesign = historyDesign;

            this.ShowDialog(owner);
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
                _historyDesign.BackColor = labBkColor.Color;
                _historyDesign.ForceColor = labForeColor.Color;
                _historyDesign.Size = Convert.ToInt32(txtToolSize.Text);

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmHistoryDesign_Load(object sender, EventArgs e)
        {
            try
            {
                labBkColor.Color = _historyDesign.BackColor;
                labForeColor.Color = _historyDesign.ForceColor;
                txtToolSize.Text = Convert.ToString(_historyDesign.Size);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

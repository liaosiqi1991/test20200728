using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.HardWare;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Pedal
{
    public partial class frmPedalDesign : Form
    {
        private bool _isOk = false;
        private PedalConfig _cc = null;
        public frmPedalDesign()
        {
            InitializeComponent();
        }

        private void InitPealDevice()
        {
            List<string> pealNames = PedalDevice.GetComlist(false);

            foreach (string name in pealNames)
            {
                cbxPedal.Items.Add(name);
            }
        }

        private void InitPealTouchWay()
        {
            cbxTouchWay.Items.Add("直接触发");
            cbxTouchWay.Items.Add("持续触发");
            cbxTouchWay.Items.Add("信号量触发");
        }

        public bool ShowPedalConfig(PedalConfig cc, IWin32Window owner)
        {
            _isOk = false;

            _cc = cc;

            this.ShowDialog(owner);

            return _isOk;

        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            { 

                _cc.PealDeviceName = cbxPedal.Text;
                _cc.TouchWay = (SerialTouchWay)cbxTouchWay.SelectedIndex;
                _cc.TouchInterval = Convert.ToInt32(cbxInterval.Text);
                _cc.SignCount = Convert.ToInt32(cbxSignCount.Text); 

                PedalConfig.SetConfig(_cc);

                _isOk = true;

                this.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void frmPedalDesign_Load(object sender, EventArgs e)
        {
            try
            {
                InitPealDevice();
                InitPealTouchWay();

                cbxPedal.Text = _cc.PealDeviceName;
                cbxTouchWay.SelectedIndex = Convert.ToInt32(_cc.TouchWay);
                cbxInterval.Text = _cc.TouchInterval.ToString();
                cbxSignCount.Text = _cc.SignCount.ToString();
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
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}

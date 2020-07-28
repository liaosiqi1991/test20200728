using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.TaskTimer
{
    public partial class frmTaskTimerDesign : Form
    {
        private bool _isOk = false;
        private TimerModuleDesign _timerDesign = null;
        public frmTaskTimerDesign()
        {
            InitializeComponent();
        }

        public bool ShowDesign(TimerModuleDesign timerDesign, IWin32Window owner)
        {
            _timerDesign = timerDesign;

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
                _timerDesign.Interval = Convert.ToInt32(txtInerval.Text);

                _timerDesign.Timing1.UseState = chkT1.Checked;
                _timerDesign.Timing1.StartTime = dtpStartTime1.Value;
                _timerDesign.Timing1.RepeatPeriod = Convert.ToInt32(txtRepeat1.Text);
                _timerDesign.Timing1.RepeatType = (TimerRepeatType)cbxUnit1.SelectedIndex;


                _timerDesign.Timing2.UseState = chkT2.Checked;
                _timerDesign.Timing2.StartTime = dtpStartTime2.Value;
                _timerDesign.Timing2.RepeatPeriod = Convert.ToInt32(txtRepeat2.Text);
                _timerDesign.Timing2.RepeatType = (TimerRepeatType)cbxUnit2.SelectedIndex;

                _timerDesign.Timing3.UseState = chkT3.Checked;
                _timerDesign.Timing3.StartTime = dtpStartTime3.Value;
                _timerDesign.Timing3.RepeatPeriod = Convert.ToInt32(txtRepeat3.Text);
                _timerDesign.Timing3.RepeatType = (TimerRepeatType)cbxUnit3.SelectedIndex;

                _timerDesign.Timing4.UseState = chkT4.Checked;
                _timerDesign.Timing4.StartTime = dtpStartTime4.Value;
                _timerDesign.Timing4.RepeatPeriod = Convert.ToInt32(txtRepeat4.Text);
                _timerDesign.Timing4.RepeatType = (TimerRepeatType)cbxUnit4.SelectedIndex;

                _timerDesign.Timing5.UseState = chkT5.Checked;
                _timerDesign.Timing5.StartTime = dtpStartTime5.Value;
                _timerDesign.Timing5.RepeatPeriod = Convert.ToInt32(txtRepeat5.Text);
                _timerDesign.Timing5.RepeatType = (TimerRepeatType)cbxUnit5.SelectedIndex;

                _isOk = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmTaskTimerDesign_Load(object sender, EventArgs e)
        {
            try
            {
                cbxUnit1.SelectedIndex = 0;
                cbxUnit2.SelectedIndex = 0;
                cbxUnit3.SelectedIndex = 0;
                cbxUnit4.SelectedIndex = 0;
                cbxUnit5.SelectedIndex = 0;

                txtInerval.Text = Convert.ToString(_timerDesign.Interval);

                chkT1.Checked = _timerDesign.Timing1.UseState;
                try
                {
                    dtpStartTime1.Value = _timerDesign.Timing1.StartTime;
                }
                catch
                {
                    dtpStartTime1.Value = DateTime.Now;
                }
                txtRepeat1.Text = Convert.ToString(_timerDesign.Timing1.RepeatPeriod);
                cbxUnit1.SelectedIndex = (int)_timerDesign.Timing1.RepeatType;

                chkT2.Checked = _timerDesign.Timing2.UseState;
                try
                {
                    dtpStartTime2.Value = _timerDesign.Timing2.StartTime;
                }
                catch
                {
                    dtpStartTime2.Value = DateTime.Now;
                }
                txtRepeat2.Text = Convert.ToString(_timerDesign.Timing2.RepeatPeriod);
                cbxUnit2.SelectedIndex = (int)_timerDesign.Timing2.RepeatType;

                chkT3.Checked = _timerDesign.Timing3.UseState;
                try
                {
                    dtpStartTime3.Value = _timerDesign.Timing3.StartTime;
                }
                catch
                {
                    dtpStartTime3.Value = DateTime.Now;
                }
                txtRepeat3.Text = Convert.ToString(_timerDesign.Timing3.RepeatPeriod);
                cbxUnit3.SelectedIndex = (int)_timerDesign.Timing3.RepeatType;

                chkT4.Checked = _timerDesign.Timing4.UseState;
                try
                {
                    dtpStartTime4.Value = _timerDesign.Timing4.StartTime;
                }
                catch
                {
                    dtpStartTime4.Value = DateTime.Now;
                }
                txtRepeat4.Text = Convert.ToString(_timerDesign.Timing4.RepeatPeriod);
                cbxUnit4.SelectedIndex = (int)_timerDesign.Timing4.RepeatType;

                chkT5.Checked = _timerDesign.Timing5.UseState;
                try
                {
                    dtpStartTime5.Value = _timerDesign.Timing5.StartTime;
                }
                catch
                {
                    dtpStartTime5.Value = DateTime.Now;
                }
                txtRepeat5.Text = Convert.ToString(_timerDesign.Timing5.RepeatPeriod);
                cbxUnit5.SelectedIndex = (int)_timerDesign.Timing5.RepeatType;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


    }
}

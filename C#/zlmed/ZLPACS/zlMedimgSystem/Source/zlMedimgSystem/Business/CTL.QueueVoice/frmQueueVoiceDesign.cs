using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.QueueVoice
{
    public partial class frmQueueVoiceDesign : Form
    {
        private bool _isOk = false;
        private QueueVoiceModuleDesign _queueVoiceDesign = null;
        public frmQueueVoiceDesign()
        {
            InitializeComponent();
        }

        public bool ShowQueueCallDesign(QueueVoiceModuleDesign queueVoiceDesign, IWin32Window owner)
        {
            _isOk = false;

            _queueVoiceDesign = queueVoiceDesign;

            this.ShowDialog(owner);

            return _isOk;

        }


        private void frmQueueVoiceDesign_Load(object sender, EventArgs e)
        {
            try
            {
                SpeechSynthesizer Talker = new SpeechSynthesizer();

                cbxVoiceName.Items.Add("");
                foreach(InstalledVoice voice in Talker.GetInstalledVoices())
                {
                    cbxVoiceName.Items.Add(voice.VoiceInfo.Name);
                }

                cbxVoiceName.Text = _queueVoiceDesign.VoiceName;
                txtPlayCount.Text = _queueVoiceDesign.PlayCount.ToString();
                txtRate.Text = _queueVoiceDesign.PlayRate.ToString();
                txtInterval.Text = _queueVoiceDesign.Interval.ToString();

                chkPlayHintSound.Checked = _queueVoiceDesign.PlayHintSound;


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
                _queueVoiceDesign.VoiceName = cbxVoiceName.Text;
                _queueVoiceDesign.PlayCount = Convert.ToInt32(txtPlayCount.Text);
                _queueVoiceDesign.PlayRate = Convert.ToInt32(txtRate.Text);
                _queueVoiceDesign.Interval = Convert.ToInt32(txtInterval.Text);

                _queueVoiceDesign.PlayHintSound = chkPlayHintSound.Checked;

                _isOk = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using zlMedimgSystem.Services;
using AForge.Video.FFMPEG; 

namespace zlMedimgSystem.CTL.Capture
{
    public partial class frmVideoConfig : Form
    {
        private CaptureConfig _cc = null;
        private string _sectionName = "";

        public bool IsOk { get; set; }

        public frmVideoConfig()
        {
            InitializeComponent();
        }

        public bool ShowCaptureConfig(CaptureConfig cc, string sectionName, IWin32Window owner)
        {
            IsOk = false;

            _cc = cc;
            _sectionName = sectionName;

            this.ShowDialog(owner);

            return IsOk;

        }

        private void frmVideoConfig_Load(object sender, EventArgs e)
        {
            if (Owner != null) this.Icon = Owner.Icon;

            try
            {
                IsOk = false;
                 

                Init();

                //_cc = CaptureConfig.GetConfig();

                cbxDevName.Text = _cc.VideoDeviceName;
                if (cbxResolution.Items.Count > 0) cbxResolution.SelectedIndex = _cc.ResolutionIndex;
                if (cbxInput.Items.Count > 0) cbxInput.SelectedIndex = _cc.InputPort;
                cbxEncode.Text = _cc.VideoEncode.ToString();

                chkSoundHint.Checked = _cc.SoundHint;
                chkPopupHint.Checked = _cc.PopupHint;
                cbxFrameRate.Text = _cc.FrameRate.ToString();
                chkRecordDatetime.Checked = _cc.RecordDate;

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private FilterInfoCollection _filterInfoCollection = null;
        private void InitVideoDevice()
        {
            if (_filterInfoCollection == null) _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo info in _filterInfoCollection)
            {
                cbxDevName.Items.Add(info.Name);
            }
        }



        private void LoadResolution(string devName)
        {
            cbxResolution.Text = "";
            cbxResolution.Items.Clear();

            cbxInput.Text = "";
            cbxInput.Items.Clear();

            if (_filterInfoCollection == null) _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo info in _filterInfoCollection)
            {
                if (info.Name.ToUpper() == devName.ToUpper())
                {
                    VideoCaptureDevice videoSource = new VideoCaptureDevice(info.MonikerString);
                    if (videoSource.VideoCapabilities.Length > 0)
                    {
                        foreach (VideoCapabilities vc in videoSource.VideoCapabilities)

                            cbxResolution.Items.Add(cbxResolution.Items.Count.ToString() + ":" + vc.FrameSize.Width.ToString() + "X" + vc.FrameSize.Height.ToString());
                    }

                    if (videoSource.AvailableCrossbarVideoInputs.Length > 0)
                    {
                        foreach (VideoInput vi in videoSource.AvailableCrossbarVideoInputs)

                            cbxInput.Items.Add(cbxInput.Items.Count.ToString() + ":" + vi.Index.ToString() + "端口");
                    }

                    if (cbxResolution.Items.Count > 0) cbxResolution.SelectedIndex = 0;
                    if (cbxInput.Items.Count > 0) cbxInput.SelectedIndex = 0;

                    return;
                }
            }

            if (cbxResolution.Items.Count > 0) cbxResolution.SelectedIndex = 0;
            if (cbxInput.Items.Count > 0) cbxInput.SelectedIndex = 0;
        }

        private void InitEncode()
        {
            cbxEncode.Items.Add(VideoCodec.Default.ToString());
            cbxEncode.Items.Add(VideoCodec.MPEG4.ToString());
            cbxEncode.Items.Add(VideoCodec.WMV1.ToString());
            cbxEncode.Items.Add(VideoCodec.WMV2.ToString());
            cbxEncode.Items.Add(VideoCodec.MSMPEG4v2.ToString());
            cbxEncode.Items.Add(VideoCodec.MSMPEG4v3.ToString());
            cbxEncode.Items.Add(VideoCodec.H263P.ToString());
            cbxEncode.Items.Add(VideoCodec.FLV1.ToString());
            cbxEncode.Items.Add(VideoCodec.MPEG2.ToString());
            cbxEncode.Items.Add(VideoCodec.Raw.ToString());
        }

        private void Init()
        {
            InitEncode();
            InitVideoDevice(); 
        }

        private void cbxDevName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadResolution(cbxDevName.Text);

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
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

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                _cc.VideoDeviceName = cbxDevName.Text;
                _cc.ResolutionIndex = cbxResolution.SelectedIndex;
                _cc.InputPort = cbxInput.SelectedIndex;
                _cc.VideoEncode = (VideoCodec)Enum.Parse(typeof(VideoCodec), cbxEncode.Text);

                _cc.SoundHint = chkSoundHint.Checked;
                _cc.PopupHint = chkPopupHint.Checked;
                _cc.FrameRate = Convert.ToInt32(cbxFrameRate.Text);
                _cc.RecordDate = chkRecordDatetime.Checked;

                CaptureConfig.SetConfig(_cc, _sectionName);               

                IsOk = true;

                this.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void butAdvice_Click(object sender, EventArgs e)
        {
            try
            {
                VideoCaptureDevice camAdvice = new VideoCaptureDevice(_filterInfoCollection[cbxDevName.SelectedIndex].MonikerString);
                camAdvice.DisplayPropertyPage(this.Handle); 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

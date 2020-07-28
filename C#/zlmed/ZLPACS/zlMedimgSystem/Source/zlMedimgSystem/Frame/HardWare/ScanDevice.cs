using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TWAINWorkingGroup;
using TWAINWorkingGroupToolkit;

namespace zlMedimgSystem.HardWare
{
    public class ScanDevice: Control
    {
        public delegate void ScanCompleteEvent(Bitmap bmp);

        private TWAINCSToolkit _scanCore = null;
        private string _scanDevName = "";
        private string m_szProductDirectory;

        // Setup information...
        private FormSetup m_formsetup;

        /// <summary>
        /// If true, then show the driver's window messages while
        /// we're scanning.  Set this in the constructor...
        /// </summary>
        private bool m_blIndicators;

        public event ScanCompleteEvent OnScanComplete;

        public ScanDevice()
        {
            InitializeComponent();
            

            base.Visible = false;
        }

        private void InitCore()
        {
            m_blIndicators = false; 

            _scanCore = new TWAINCSToolkit(this.Handle,
                    WriteOutput,
                    ReportImage,
                    null,
                    "TWAIN Working Group",
                    "TWAIN Sharp",
                    "TWAIN Sharp Scan App",
                    2,
                    4,
                    new string[] { "DF_APP2", "DG_CONTROL", "DG_IMAGE" },
                    "USA",
                    "testing...",
                    "ENGLISH_USA",
                    1,
                    0,
                    false,
                    true,
                    RunInUiThread,
                    this);
        }

        /// <summary>
        /// 返回扫描设备
        /// </summary>
        /// <returns></returns>
        public List<string> GetScanDevs()
        {
            string szDefault = "";

            if (_scanCore == null) InitCore(); 
            List<string> result = new List<string>(_scanCore.GetDrivers(ref szDefault));

            return result;
        }

        /// <summary>
        /// 初始化设备
        /// </summary>
        /// <param name="devName"></param>
        public bool InitDevice(string devName)
        {
            _scanDevName = devName;

            string szStatus = "";

            if (_scanCore == null) InitCore();

            _scanCore.Send("DG_CONTROL", "DAT_IDENTITY", "MSG_SET", ref _scanDevName, ref szStatus);

            // Open it...

            TWAIN.STS sts = _scanCore.Send("DG_CONTROL", "DAT_IDENTITY", "MSG_OPENDS", ref _scanDevName, ref szStatus);
            if (sts != TWAIN.STS.SUCCESS)
            {
                //MessageBox.Show("Unable to open scanner (it is turned on and plugged in?)");
                
                return false;
            }

            // Strip off unsafe chars.  Sadly, mono let's us down here...
            m_szProductDirectory = TWAINCSToolkit.CsvParse(_scanDevName)[11];
            foreach (char c in new char[41]
                            { '\x00', '\x01', '\x02', '\x03', '\x04', '\x05', '\x06', '\x07',
                              '\x08', '\x09', '\x0A', '\x0B', '\x0C', '\x0D', '\x0E', '\x0F', '\x10', '\x11', '\x12',
                              '\x13', '\x14', '\x15', '\x16', '\x17', '\x18', '\x19', '\x1A', '\x1B', '\x1C', '\x1D',
                              '\x1E', '\x1F', '\x22', '\x3C', '\x3E', '\x7C', ':', '*', '?', '\\', '/'
                            }
                    )
            {
                m_szProductDirectory = m_szProductDirectory.Replace(c, '_');
            }


            szStatus = "";
            string szCapability = "ICAP_XFERMECH,TWON_ONEVALUE,TWTY_UINT16,2";
            sts = _scanCore.Send("DG_CONTROL", "DAT_CAPABILITY", "MSG_SET", ref szCapability, ref szStatus);
            if (sts != TWAIN.STS.SUCCESS)
            { 
                return false;
            }

            // Decide whether or not to show the driver's window messages...
            szStatus = "";
            szCapability = "CAP_INDICATORS,TWON_ONEVALUE,TWTY_BOOL," + (m_blIndicators ? "1" : "0");
            sts = _scanCore.Send("DG_CONTROL", "DAT_CAPABILITY", "MSG_SET", ref szCapability, ref szStatus);
            if (sts != TWAIN.STS.SUCCESS)
            {
                return false;
            }

            if (m_formsetup == null)
            {
                m_formsetup = new FormSetup(ref _scanCore, m_szProductDirectory);
            }


            return true;
        }

        /// <summary>
        /// 显示设置
        /// </summary>
        public void ShowSetting()
        {
            m_formsetup.StartPosition = FormStartPosition.CenterParent;
            m_formsetup.ShowDialog(this);
        }

        public void Scan()
        {
            string szTwmemref;
            string szStatus = "";
            TWAIN.STS sts;
             
            // Silently start scanning if we detect that customdsdata is supported,
            // otherwise bring up the driver GUI so the user can change settings...
            if ( m_formsetup.IsCustomDsDataSupported())
            {
                szTwmemref = "0,0," + this.Handle;
            }
            else
            {
                szTwmemref = "1,0," + this.Handle;
            }

            sts = _scanCore.Send("DG_CONTROL", "DAT_USERINTERFACE", "MSG_ENABLEDS", ref szTwmemref, ref szStatus);
        }

        private void Stop()
        {
            string szPendingxfers = "0,0";
            string szStatus = "";

            _scanCore.Send("DG_CONTROL", "DAT_PENDINGXFERS", "MSG_STOPFEEDER", ref szPendingxfers, ref szStatus);
        }


        public void Close()
        {
            Stop();

            _scanCore.CloseDriver();

            if (m_formsetup != null)
            {
                m_formsetup.Dispose();
                m_formsetup = null;
            }
        }


        /// <summary>
        /// Debugging output that we can monitor, this is just a place
        /// holder for this particular application...
        /// </summary>
        /// <param name="a_szOutput"></param>
        private void WriteOutput(string a_szOutput)
        {
            return;
        }

        static public void RunInUiThread(Object a_object, Action a_action)
        {
            Control control = (Control)a_object;
            if (control.InvokeRequired)
            {
                control.Invoke(new TWAINCSToolkit.RunInUiThreadDelegate(RunInUiThread), new object[] { a_object, a_action });
                return;
            }
            a_action();
        }


        private TWAINCSToolkit.MSG ReportImage
         (
             string a_szTag,
             string a_szDg,
             string a_szDat,
             string a_szMsg,
             TWAIN.STS a_sts,
             Bitmap a_bitmap,
             string a_szFile,
             string a_szTwimageinfo,
             byte[] a_abImage,
             int a_iImageOffset
         )
        { 

            // Let us be called from any thread...
            if (this.InvokeRequired)
            {
                // We need a copy of the bitmap, because we're not going to wait
                // for the thread to return.  Be careful when using EndInvoke.
                // It's possible to create a deadlock situation with the Stop
                // button press.
                BeginInvoke(new MethodInvoker(delegate () { ReportImage(a_szTag, a_szDg, a_szDat, a_szMsg, a_sts, a_bitmap, a_szFile, a_szTwimageinfo, a_abImage, a_iImageOffset); }));
                return (TWAINCSToolkit.MSG.ENDXFER);
            }

            // We're processing end of scan...
            if (a_bitmap == null)
            {
                // Report errors, but only if the driver's indicators have
                // been turned off, otherwise we'll hit the user with multiple
                // dialogs for the same error...
                if (!m_blIndicators && (a_sts != TWAIN.STS.SUCCESS))
                {
                    MessageBox.Show("End of session status: " + a_sts);
                }

                // Get ready for the next scan... 
                return (TWAINCSToolkit.MSG.ENDXFER);
            }

            // Display the image...
            this.Invoke(new ScanCompleteEvent(DoScanComplete), new object[] { a_bitmap }); 

            // All done...
            return (TWAINCSToolkit.MSG.ENDXFER);
        }

        public void DoScanComplete(Bitmap bmp)
        {
            if (OnScanComplete == null) return;

            OnScanComplete(bmp);
        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanDevice));
            this.SuspendLayout();
            // 
            // ScanDevice
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            base.MaximumSize = new System.Drawing.Size(24, 24);
            base.MinimumSize = new System.Drawing.Size(24, 24);
            this.Size = new System.Drawing.Size(24, 24);
            this.ResumeLayout(false);

        }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Visible
        {
            get { return base.Visible; }
        }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get { return ""; }
        }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size MinimumSize
        {
            get { return base.MinimumSize; }
        }


        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size MaximumSize
        {
            get { return base.MaximumSize; }
        }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DockStyle Dock { get { return base.Dock; } }

    }
}

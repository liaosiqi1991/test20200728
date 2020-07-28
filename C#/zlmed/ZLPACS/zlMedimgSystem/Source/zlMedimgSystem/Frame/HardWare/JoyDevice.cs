using Microsoft.DirectX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace zlMedimgSystem.HardWare
{
    public sealed class JoyDevice:Control
    {
        public delegate void JoyThreadDelegate();
        public delegate void JoyClick(byte[] buttons);

        private Device _joyInput = null;
        private DeviceList _dlist = null;

                  
        private AutoResetEvent eventFire = null;
        private Thread threadData = null;

        private bool _isStart = false;


        public event JoyClick OnJoyClick;



        public JoyDevice()
        {
            InitializeComponent();

            base.Visible = false;

            _isStart = false;
            _dlist = Manager.GetDevices(DeviceType.Gamepad, EnumDevicesFlags.AttachedOnly);

        }

        ~JoyDevice()
        {
            Stop();
        }
         
        public void InitDevice(string devName)
        { 
            if (_dlist.Count <= 0 || string.IsNullOrEmpty(devName)) return;
                    
            _dlist.Reset();
            foreach (DeviceInstance di in _dlist)
            {
                try
                {
                    if (di.InstanceName.ToUpper().Equals(devName.ToUpper()))
                    {
                        _joyInput = new Device(di.ProductGuid);
                        break;
                    }
                }
                catch
                {
                    _joyInput = null;
                    break;
                } 
            }

            if (_joyInput == null) return;


            _joyInput.SetCooperativeLevel(null, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);

            _joyInput.Properties.AxisModeAbsolute = true; 

            foreach (DeviceObjectInstance doi in _joyInput.Objects)
            {
                if ((doi.ObjectId & (int)DeviceObjectTypeFlags.Axis) != 0)
                {
                    _joyInput.Properties.SetRange(ParameterHow.ById, doi.ObjectId, new InputRange(-128, 128));
                }
            } 

            threadData = new Thread(new ThreadStart(InputEvent));
            threadData.Start();

            eventFire = new AutoResetEvent(false);

            _joyInput.SetEventNotification(eventFire); 

        }

        private void InputEvent()
        {
            while (true)
            {
                eventFire.WaitOne(-1, false);

                if (_isStart == false) return;

                try
                {
                    _joyInput.Poll();
                }
                catch
                {
                    continue;
                }

                //ThreadDelegate td = new ThreadDelegate(ThreadEventWrapper); 

                //td.BeginInvoke(null, null);//td.Invoke();

                //Control ctl = new Control();

                this.Invoke(new JoyThreadDelegate(ThreadEventWrapper));


                if (_isStart == false) return; 
            }
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            if (_joyInput == null) return false;

            _joyInput.Acquire();

            _isStart = true;

            return true;
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {

            _isStart = false;

            if (_joyInput == null) return;


            if (eventFire != null) eventFire.Set();

            if (threadData != null)
            {
                threadData.Abort();

                while (threadData.ThreadState != ThreadState.Aborted)
                {
                    Thread.Sleep(20);
                }
            }

        }

         
        private void ThreadEventWrapper()
        {
            if (_isStart == false) return;
            if (_joyInput == null) return;

            byte[] buttons = _joyInput.CurrentJoystickState.GetButtons();
             
            if (OnJoyClick == null) return;

            try
            {
                OnJoyClick(buttons);
            }
            catch
            {

            }
        }
        
        public static List<string> GetJoyDevs()
        {
            DeviceList dlist = Manager.GetDevices(DeviceType.Gamepad, EnumDevicesFlags.AttachedOnly);

            if (dlist.Count <= 0) return new List<string>();

            List<string> result = new List<string>();

            foreach (DeviceInstance di in dlist)
            {
                result.Add(di.ProductName);
            }

            return result;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoyDevice));
            this.SuspendLayout();
            // 
            // JoyDevice
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

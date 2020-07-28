using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.HardWare
{ 
    public enum SerialTouchWay
    {
        /// <summary>
        /// 直接触发
        /// </summary>
        stwDirect, 

        /// <summary>
        /// 持续触发
        /// </summary>
        stwKeep,

        /// <summary>
        /// 信号量触发
        /// </summary>
        stwSemaphore

    }
     

    
    public sealed class PedalDevice: Control
    {
        public delegate void SerialSignalEvent();


        private SerialPort _serialPort = null;
        private bool _isStart = false;

        private SerialTouchWay _parTouchWay = SerialTouchWay.stwDirect;
        private int _parPedalInterval = 300;//脚踏间隔,毫秒
        private int _parSignalCount = 0;

        private DateTime _lastTouchTime = DateTime.Now;
        private DateTime _startTouchTime;
         
        private int _curSignalCount = 0;

        private bool _isTouch = false;
        

        public event SerialSignalEvent OnSerialSignal;

        public PedalDevice()
        {
            InitializeComponent();

            base.Visible = false;
        }

        public PedalDevice(string devName)
        {
            InitializeComponent();
            InitDevice(devName);

            base.Visible = false;
        }

        /// <summary>
        /// 触发方式
        /// </summary>
        public SerialTouchWay TouchWay
        {
            get { return _parTouchWay; }
            set { _parTouchWay = value; }
        }

        /// <summary>
        /// 脚踏间隔
        /// </summary>
        public int PedaInterval
        {
            get { return _parPedalInterval; }
            set { _parPedalInterval = value; }
        }

        /// <summary>
        /// 信号数量
        /// </summary>
        public int SignalCount
        {
            get { return _parSignalCount; }
            set { _parSignalCount = value; }
        }

        public void InitDevice(string devName)
        { 
            _isStart = false;

            SerialPort sp = new SerialPort();

            //设置参数
            sp.PortName = devName;
            sp.BaudRate = 9600;
            sp.DataBits = 8; //每个字节的标准数据位长度
            sp.StopBits = StopBits.One; //设置每个字节的标准停止位数
            sp.Parity = Parity.None; //设置奇偶校验检查协议
            sp.ReadTimeout = 3000; //单位毫秒
            sp.WriteTimeout = 3000; //单位毫秒

            sp.RtsEnable = true;
            sp.DtrEnable = true;

            //串口控件成员变量，字面意思为接收字节阀值，
            //串口对象在收到这样长度的数据之后会触发事件处理函数
            //一般都设为1
            sp.ReceivedBytesThreshold = 1;
            sp.PinChanged += SerialPinChangedProcess;
            sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedProcess); //设置数据接收事件（监听）
 
            _serialPort = sp;
        }

        public bool Start()
        {
            if (_serialPort == null) return false;

            _serialPort.Open(); //打开串口 

            _isStart = true;

            return true;
        }

        public void Stop()
        {
            _isStart = false;

            if (_serialPort != null) _serialPort.Close();

        }

        private void SerialPinChangedProcess(object sender, SerialPinChangedEventArgs e)
        {
            DoHolding();
        }
         


        /// <summary>
        /// 串口数据处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceivedProcess(Object sender, SerialDataReceivedEventArgs e)
        {
            DoHolding();
        }

        private void DoHolding()
        {
            if (_isStart == false) return;

            switch(_parTouchWay)
            {
                case SerialTouchWay.stwDirect:
                    DoDirectTouch();
                    break;

                case SerialTouchWay.stwKeep:
                    DoKeepTouch();
                    break;

                case SerialTouchWay.stwSemaphore:
                    DoSemaphoreTouch();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 直接触发
        /// </summary>
        private void DoDirectTouch()
        {
            //直接判断两次踩下脚踏的时间间隔
            TimeSpan ts = DateTime.Now - _lastTouchTime;

            if (ts.TotalMilliseconds < _parPedalInterval)
            {
                _lastTouchTime = DateTime.Now;
                return;
            }

            ts = DateTime.Now - _startTouchTime;
            if (_curSignalCount == 0 || (_curSignalCount != 0 && ts.TotalMilliseconds > _parPedalInterval))
            {
                _curSignalCount = 0;
                _startTouchTime = DateTime.Now;
            }


            //结合收集到的信号数量进行采集，适当屏蔽干扰
            _curSignalCount = _curSignalCount + 1;
            if (_parSignalCount > 0 && _curSignalCount < _parSignalCount)
            {
                return;
            }

            _curSignalCount = 0;
            _lastTouchTime = DateTime.Now;

            //this.BeginInvoke(new SerialSignalEvent(DoSerialSignal));
            this.Invoke(new SerialSignalEvent(DoSerialSignal));
        }
         

        /// <summary>
        /// 持续触发
        /// </summary>
        private void DoKeepTouch()
        {
            //直接判断两次踩下脚踏的时间间隔
            TimeSpan ts = DateTime.Now - _lastTouchTime;

            if (ts.TotalMilliseconds < _parPedalInterval)
            {
                _lastTouchTime = DateTime.Now;
                return;
            }

            //计算脚踏按下的持续时间
            if (_isTouch == false)
            {
                _isTouch = true;
                _startTouchTime = DateTime.Now;
            }


            _curSignalCount = _curSignalCount + 1;

            ts = DateTime.Now - _startTouchTime;

            if (ts.TotalMilliseconds >= _parPedalInterval)
            {                
                _isTouch = false;
                _lastTouchTime = DateTime.Now;

                if (_parSignalCount > 0 && _curSignalCount < _parSignalCount)
                {
                    _curSignalCount = 0;
                    return;
                }

                _curSignalCount = 0;

                //this.BeginInvoke(new SerialSignalEvent(DoSerialSignal));
                this.Invoke(new SerialSignalEvent(DoSerialSignal));
            }
        }

        /// <summary>
        /// 信号数量触发
        /// </summary>
        private void DoSemaphoreTouch()
        {
            TimeSpan ts = DateTime.Now - _startTouchTime;

            if (ts.TotalMilliseconds < _parPedalInterval)
            {
                _curSignalCount = 1;
                _startTouchTime = DateTime.Now;
            }
            else
            {
                _curSignalCount = _curSignalCount + 1;

                TimeSpan tsEnd = DateTime.Now - _lastTouchTime;
                if (tsEnd.TotalMilliseconds > _parPedalInterval)
                {
                    _curSignalCount = 1;
                    _lastTouchTime = DateTime.Now;
                }

                if (_curSignalCount >= _parSignalCount)
                {
                    _curSignalCount = 0;
                    _startTouchTime = DateTime.Now;
                    _lastTouchTime = _startTouchTime;

                    //this.BeginInvoke(new SerialSignalEvent(DoSerialSignal));
                    this.Invoke(new SerialSignalEvent(DoSerialSignal));
                }

            }
        }

        /// <summary>
        /// 触发串口信号
        /// </summary>
        private void DoSerialSignal()
        {
            if (OnSerialSignal == null) return;

            OnSerialSignal();
        }



        /// <summary>
        /// 获取本机串口列表
        /// </summary>
        /// <param name="isUseReg"></param>
        /// <returns></returns>
        public static List<string> GetComlist(bool isUseReg)
        {
            List<string> list = new List<string>();

            if (isUseReg)
            {
                RegistryKey RootKey = Registry.LocalMachine;
                RegistryKey Comkey = RootKey.OpenSubKey(@"HARDWARE\DEVICEMAP\SERIALCOMM");

                String[] ComNames = Comkey.GetValueNames();

                foreach (String ComNamekey in ComNames)
                {
                    string TemS = Comkey.GetValue(ComNamekey).ToString();
                    list.Add(TemS);
                }
            }
            else
            {
                foreach (string com in SerialPort.GetPortNames())  //自动获取串行口名称  
                {
                    list.Add(com);
                }
            }

            return list; 

        }



        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedalDevice));
            this.SuspendLayout();
            // 
            // SerialDevice
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using zlMedimgSystem.HardWare;

namespace zlMedimgSystem.CTL.Joy
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(JoyControl), "Resources.手柄.bmp")]
    public partial class JoyControl : DesignComponent, ISysBizModule, ISysDesign, IBizDataQuery
    {

        static public class JoyEventDefine
        {
            public const string OneTouch = "键一触发";
            public const string TwoTouch = "键二触发";
            public const string ThreeTouch = "键三触发";
            public const string FourTouch = "键四触发";
            public const string FiveTouch = "键五触发";
            public const string SixTouch = "键六触发";
            public const string SevenTouch = "键七触发";
            public const string EightTouch = "键八触发";
        }

        static public class JoyActionDefine
        {
            public const string JoyConfig = "手柄设置";
        }


        private JoyPar _defJoyPar = null;
        private JoyPar _joyPar = null;

        private JoyDevice _joy = null;

        public JoyControl()
        {
            InitializeComponent();

            _defJoyPar = new JoyPar();
        }


        protected override void InitBaseInfo()
        {
            _multiInstance = false;
            _moduleName = "辅助手柄";


            _provideActionDesc.Add(JoyActionDefine.JoyConfig, "");

            //_provideDatas.Add("", "");


            _designEvents.Add(JoyEventDefine.OneTouch, new EventActionReleation(JoyEventDefine.OneTouch, ActionType.atSysFixedEvent));
            _designEvents.Add(JoyEventDefine.TwoTouch, new EventActionReleation(JoyEventDefine.TwoTouch, ActionType.atSysFixedEvent));
            _designEvents.Add(JoyEventDefine.ThreeTouch, new EventActionReleation(JoyEventDefine.ThreeTouch, ActionType.atSysFixedEvent));
            _designEvents.Add(JoyEventDefine.FourTouch, new EventActionReleation(JoyEventDefine.FourTouch, ActionType.atSysFixedEvent));
            _designEvents.Add(JoyEventDefine.FiveTouch, new EventActionReleation(JoyEventDefine.FiveTouch, ActionType.atSysFixedEvent));
            _designEvents.Add(JoyEventDefine.SixTouch, new EventActionReleation(JoyEventDefine.SixTouch, ActionType.atSysFixedEvent));
            _designEvents.Add(JoyEventDefine.SevenTouch, new EventActionReleation(JoyEventDefine.SevenTouch, ActionType.atSysFixedEvent));
            _designEvents.Add(JoyEventDefine.EightTouch, new EventActionReleation(JoyEventDefine.EightTouch, ActionType.atSysFixedEvent));
        }

        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            switch (actName)
            {
                case JoyActionDefine.JoyConfig://手柄设置
                    bool isOk = ShowJoyConfig(_joyPar);

                    if (isOk)
                    {
                        OpenJoy();
                    }

                    return isOk;

                default:
                    return false;
            }

        }

        private bool ShowJoyConfig(JoyPar joyPar)
        {
            using (frmJoyDesign design = new frmJoyDesign())
            {
                return design.ShowJoyConfig(joyPar, this);
            }
        }



        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _defJoyPar = JsonHelper.DeserializeObject<JoyPar>(customContext);

        }

        public override string ShowCustomDesign()
        {
            ShowJoyConfig(_defJoyPar);

            _customDesignFmt = JsonHelper.SerializeObject(_defJoyPar);

            return _customDesignFmt;
        }

        public override void ModuleLoaded()
        {
            try
            {
                //设计模式则不启动脚踏
                if (this.DesignMode) return;
                
                OpenJoy();

                base.ModuleLoaded();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void JoyControl_Load(object sender, EventArgs e)
        {
            try
            {
                //设计模式则不启动脚踏
                if (this.DesignMode) return;

                OpenJoy();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        public override void Terminated()
        {
            if (_joy != null) _joy.Stop();

            base.Terminated();
        }


        private void OpenJoy()
        {
            if (_joyPar == null) _joyPar = JoyPar.GetConfig();

            if (string.IsNullOrEmpty(_joyPar.JoyName))
            {
                _joyPar.CopyFrom(_defJoyPar);
            }

            if (string.IsNullOrEmpty(_joyPar.JoyName)) return;

            if (_joy == null)
            {
                _joy = new JoyDevice();
                this.Controls.Add(_joy);

                _joy.OnJoyClick += JoyClickProcess;
            }

            _joy.Stop();

            _joy.InitDevice(_joyPar.JoyName);
            _joy.Start();
        }


        private void JoyClickProcess(byte[] buttons)
        {
            try
            {
                if (buttons[0] == 128)
                {
                    //A键处理--1
                    DoActions(_designEvents[JoyEventDefine.OneTouch], this);
                }

                if (buttons[1] == 128)
                {
                    //B键处理--2
                    DoActions(_designEvents[JoyEventDefine.TwoTouch], this);
                }

                if (buttons[2] == 128)
                {
                    //C键处理--3
                    DoActions(_designEvents[JoyEventDefine.ThreeTouch], this);
                }

                if (buttons[3] == 128)
                {
                    //C键处理--4
                    DoActions(_designEvents[JoyEventDefine.FourTouch], this);
                }

                if (buttons[4] == 128)
                {
                    //C键处理--5
                    DoActions(_designEvents[JoyEventDefine.FiveTouch], this);
                }

                if (buttons[5] == 128)
                {
                    //C键处理--6
                    DoActions(_designEvents[JoyEventDefine.SixTouch], this);
                }

                if (buttons[6] == 128)
                {
                    //C键处理--7
                    DoActions(_designEvents[JoyEventDefine.SevenTouch], this);
                }

                if (buttons[7] == 128)
                {
                    //C键处理--8
                    DoActions(_designEvents[JoyEventDefine.EightTouch], this);
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void DoActions(EventActionReleation ea, object sender)
        {
            try
            {
                base.DoBindActions(ea, sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

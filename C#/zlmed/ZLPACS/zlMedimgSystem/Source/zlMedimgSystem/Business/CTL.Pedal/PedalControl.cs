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
using System.Configuration;

namespace zlMedimgSystem.CTL.Pedal
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(PedalControl), "Resources.脚踏.bmp")]
    public partial class PedalControl : DesignComponent, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class PedalEventDefine
        {
            public const string PedalTouch = "脚踏触发";
        }

        static public class PedalActionDefine
        {
            public const string PedalConfig = "脚踏设置";
        }

        private PedalConfig _defPedalPar = null;

        private PedalConfig _pc = null;
        private PedalDevice _pedal = null;
        public PedalControl()
        {
            InitializeComponent();

            _defPedalPar = new PedalConfig();
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = false;
            _moduleName = "脚踏开关";


            _provideActionDesc.Add(PedalActionDefine.PedalConfig, "");

            //_provideDatas.Add("", "");


            _designEvents.Add(PedalEventDefine.PedalTouch, new EventActionReleation(PedalEventDefine.PedalTouch, ActionType.atSysFixedEvent)); 
        }

        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            switch (actName)
            {
                case PedalActionDefine.PedalConfig://检查刷新
                    bool isOk = ShowPedalConfig(_pc);

                    if (isOk)
                    {
                        OpenPedal();
                    }

                    return isOk;

                default:
                    return false;
            }
             
        }

        private bool ShowPedalConfig(PedalConfig pedalPar)
        {
            using (frmPedalDesign design = new frmPedalDesign())
            {
                return design.ShowPedalConfig(pedalPar, this);
            }
        }



        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _defPedalPar = JsonHelper.DeserializeObject<PedalConfig>(customContext);

        }
 
 

        public override string ShowCustomDesign()
        {
            ShowPedalConfig(_defPedalPar);

            _customDesignFmt = JsonHelper.SerializeObject(_defPedalPar);

            return _customDesignFmt;
        } 

        public override void ModuleLoaded()
        {
            try
            {
                //设计模式则不启动脚踏
                if (this.DesignMode) return; 

                OpenPedal();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void PedalControl_Load(object sender, EventArgs e)
        {
            try
            {
                //设计模式则不启动脚踏
                if (this.DesignMode) return; 

                OpenPedal();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }



        private void OpenPedal()
        {
            try
            {
                if (_pc == null) _pc = PedalConfig.GetConfig();

                if (string.IsNullOrEmpty(_pc.PealDeviceName))
                {
                    _pc.CopyFrom(_defPedalPar);
                }

                if (string.IsNullOrEmpty(_pc.PealDeviceName)) return;

                if (_pedal == null)
                {
                    _pedal = new PedalDevice();
                    this.Controls.Add(_pedal);

                    _pedal.OnSerialSignal += SerialSignalProcess;
                }

                _pedal.Stop();
                _pedal.InitDevice(_pc.PealDeviceName);


                _pedal.Start();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }

        public override void Terminated()
        {
            if (_pedal != null) _pedal.Stop();

            base.Terminated();
        }

        private void SerialSignalProcess()
        {
            try
            {
                //脚踏触发图像采集
                DoActions(_designEvents[PedalEventDefine.PedalTouch], this);
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

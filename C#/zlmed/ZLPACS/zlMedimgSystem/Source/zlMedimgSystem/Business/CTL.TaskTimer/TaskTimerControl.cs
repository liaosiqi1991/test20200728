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

namespace zlMedimgSystem.CTL.TaskTimer
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(TaskTimerControl), "Resources.timer.ico")]
    public partial class TaskTimerControl : DesignComponent, ISysBizModule, ISysDesign, IBizDataQuery
    {
 
        static public class TimerEventDefine
        {
            public const string Interval = "间隔触发";
            public const string Time1 = "定时1触发";
            public const string Time2 = "定时2触发";
            public const string Time3 = "定时3触发";
            public const string Time4 = "定时4触发";
            public const string Time5 = "定时5触发";
        }

        static public class TimerActionDefine
        {
            public const string Start = "开启计时器";
            public const string Stop = "停止计时器";
        }



        private TimerModuleDesign _timerDesign = null;


        public TaskTimerControl()
        {
            InitializeComponent();

            _timerDesign = new TimerModuleDesign();

            _timerDesign.Interval = 5;

            _timerConfig = new TimerConfig();

            _timerConfig.LastTime1 = default(DateTime);
            _timerConfig.LastTime1 = default(DateTime);
            _timerConfig.LastTime1 = default(DateTime);
            _timerConfig.LastTime1 = default(DateTime);
            _timerConfig.LastTime1 = default(DateTime);
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "定时器";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            //_provideDataDesc.AddDataDescription(_moduleName, TestDataDefine.CurTestData, "");
            _provideActionDesc.Add(TimerActionDefine.Start, "开启计时器。");
            _provideActionDesc.Add(TimerActionDefine.Stop, "停止计时器。");

            _designEvents.Add(TimerEventDefine.Interval, new EventActionReleation(TimerEventDefine.Interval, ActionType.atSysFixedEvent));

            //_designEvents.Add(TimerEventDefine.Time1, new EventActionReleation(TimerEventDefine.Time1, ActionType.atSysFixedEvent));
            //_designEvents.Add(TimerEventDefine.Time2, new EventActionReleation(TimerEventDefine.Time2, ActionType.atSysFixedEvent));
            //_designEvents.Add(TimerEventDefine.Time3, new EventActionReleation(TimerEventDefine.Time3, ActionType.atSysFixedEvent));
            //_designEvents.Add(TimerEventDefine.Time4, new EventActionReleation(TimerEventDefine.Time4, ActionType.atSysFixedEvent));
            //_designEvents.Add(TimerEventDefine.Time5, new EventActionReleation(TimerEventDefine.Time5, ActionType.atSysFixedEvent));
        }

        public override bool HasData(string dataIdentificationName)
        {
            return false;
        }


        public override IBizDataItems QueryDatas(string dataIdentificationName)
        {
            return null;
        }

        private TimerConfig _timerConfig = null;
        public override void ModuleLoaded()
        {
            _timerConfig = TimerConfig.GetConfig(_moduleName);
                     
            //timer1.Enabled = true; 
        }

        public override void Terminated()
        {
            timer1.Enabled = false;
            base.Terminated();
        }

        private void ClearEvent()
        {
            List<string> keys = new List<string>(_designEvents.Keys);
            for (int i = keys.Count - 1; i >= 0; i--)
            {
                //固定事件不允许删除
                if (_designEvents[keys[i]].ActType == ActionType.atSysFixedEvent) continue;
                              
                    //未找到对应按钮
                    _designEvents.Remove(keys[i]); 
            }
        }

        private void InitTimeEvent()
        { 

            if (_timerDesign.Timing1.UseState)
            {
                _designEvents.Add(TimerEventDefine.Time1, new EventActionReleation(TimerEventDefine.Time1, ActionType.atSysCustomEvent));
            }
            else
            {
                _designEvents.Remove(TimerEventDefine.Time1);
            }

            if (_timerDesign.Timing2.UseState)
            {
                _designEvents.Add(TimerEventDefine.Time2, new EventActionReleation(TimerEventDefine.Time2, ActionType.atSysCustomEvent));
            }
            else
            {
                _designEvents.Remove(TimerEventDefine.Time2);
            }

            if (_timerDesign.Timing3.UseState)
            {
                _designEvents.Add(TimerEventDefine.Time3, new EventActionReleation(TimerEventDefine.Time3, ActionType.atSysCustomEvent));
            }
            else
            {
                _designEvents.Remove(TimerEventDefine.Time3);
            }

            if (_timerDesign.Timing4.UseState)
            {
                _designEvents.Add(TimerEventDefine.Time4, new EventActionReleation(TimerEventDefine.Time4, ActionType.atSysCustomEvent));
            }
            else
            {
                _designEvents.Remove(TimerEventDefine.Time4);
            }

            if (_timerDesign.Timing5.UseState)
            {
                _designEvents.Add(TimerEventDefine.Time5, new EventActionReleation(TimerEventDefine.Time5, ActionType.atSysCustomEvent));
            }
            else
            {
                _designEvents.Remove(TimerEventDefine.Time5);
            }
        }
        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _timerDesign = JsonHelper.DeserializeObject<TimerModuleDesign>(customContext);

            InitTimeEvent();

            timer1.Interval = _timerDesign.Interval * 1000;
        }



        public override string ShowCustomDesign()
        {
            _customDesignFmt = ShowDesign(_timerDesign);

            return _customDesignFmt;
        }

        public string ShowDesign(TimerModuleDesign timerDesign)
        {
            using (frmTaskTimerDesign design = new frmTaskTimerDesign())
            {
                design.ShowDesign(timerDesign, this);
            }

            InitTimeEvent();

            return JsonHelper.SerializeObject(timerDesign);
        }

        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {
                switch (actName)
                {
                    case TimerActionDefine.Start:
                        timer1.Start();
                        return true; 

                    case TimerActionDefine.Stop:
                        timer1.Stop();
                        return true;

                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        private void DoInterval()
        {
            if (_designEvents.ContainsKey(TimerEventDefine.Interval) == false) return;

            EventActionReleation ea = _designEvents[TimerEventDefine.Interval];

            DoActions(ea, timer1);
        }

        private bool DoActions(EventActionReleation ea, object sender)
        {
            try
            {
                return base.DoBindActions(ea, sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        private bool WakeTime(TimerItem timeItem, DateTime lastTime)
        {
            //没有启用则退出
            if (timeItem.UseState == false) return false;

            //已经执行过一次则退出
            if (lastTime != default(DateTime) && timeItem.RepeatPeriod == 0) return false;

            if (lastTime == default(DateTime))
            {
                if (DateTime.Now >= timeItem.StartTime) return true;
            }

            bool isWake = false;
            switch(timeItem.RepeatType)
            {
                case TimerRepeatType.trtMinute:
                    if (DateTime.Now >= lastTime.AddMinutes(timeItem.RepeatPeriod)) isWake = true;
                    break;

                case TimerRepeatType.trtHour:
                    if (DateTime.Now >= lastTime.AddHours(timeItem.RepeatPeriod)) isWake = true;
                    break;

                case TimerRepeatType.trtDay:
                    if (DateTime.Now >= lastTime.AddDays(timeItem.RepeatPeriod)) isWake = true;
                    break;

                case TimerRepeatType.trtWeek:
                    if (DateTime.Now >= lastTime.AddDays(timeItem.RepeatPeriod * 7)) isWake = true;
                    break;

                case TimerRepeatType.trtMonth:
                    if (DateTime.Now >= lastTime.AddMonths(timeItem.RepeatPeriod)) isWake = true;
                    break;

                default:
                    isWake = false;
                    break;
            }

            //不触发
            if (isWake == false) return false;

            
            return true;
        }
         

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DoInterval();

                bool isDo = false;
                if (WakeTime(_timerDesign.Timing1, _timerConfig.LastTime1))
                {
                    if (_designEvents.ContainsKey(TimerEventDefine.Time1))
                    {
                        EventActionReleation ea = _designEvents[TimerEventDefine.Time1];

                        DoActions(ea, timer1);

                        _timerConfig.LastTime1 = DateTime.Now;
                        isDo = true;
                    }
                }

                if (WakeTime(_timerDesign.Timing2, _timerConfig.LastTime2))
                {
                    if (_designEvents.ContainsKey(TimerEventDefine.Time2))
                    {
                        EventActionReleation ea = _designEvents[TimerEventDefine.Time2];

                        DoActions(ea, timer1);

                        _timerConfig.LastTime2 = DateTime.Now;
                        isDo = true;
                    }
                }

                if (WakeTime(_timerDesign.Timing3, _timerConfig.LastTime3))
                {
                    if (_designEvents.ContainsKey(TimerEventDefine.Time3))
                    {
                        EventActionReleation ea = _designEvents[TimerEventDefine.Time3];

                        DoActions(ea, timer1);

                        _timerConfig.LastTime3 = DateTime.Now;
                        isDo = true;
                    }
                }

                if (WakeTime(_timerDesign.Timing4, _timerConfig.LastTime4))
                {
                    if (_designEvents.ContainsKey(TimerEventDefine.Time4))
                    {
                        EventActionReleation ea = _designEvents[TimerEventDefine.Time4];

                        DoActions(ea, timer1);

                        _timerConfig.LastTime4 = DateTime.Now;
                        isDo = true;
                    }
                }

                if (WakeTime(_timerDesign.Timing5, _timerConfig.LastTime5))
                {
                    if (_designEvents.ContainsKey(TimerEventDefine.Time5))
                    {
                        EventActionReleation ea = _designEvents[TimerEventDefine.Time5];

                        DoActions(ea, timer1);

                        _timerConfig.LastTime5 = DateTime.Now;
                        isDo = true;
                    }
                }

                if (isDo) TimerConfig.SetConfig(_timerConfig, _moduleName);
            }
            catch
            {

            }
        }
    }
}

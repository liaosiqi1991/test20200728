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
using zlMedimgSystem.DataModel;
using System.Speech.Synthesis;
using System.Media;

namespace zlMedimgSystem.CTL.QueueVoice
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(QueueVoiceControl), "Resources.queuevoice.ico")]
    public partial class QueueVoiceControl : DesignComponent, ISysBizModule, ISysDesign, IBizDataQuery
    {

        static public class QueueVoiceEventDefine
        {
            public const string Refresh = "轮询刷新事件";
        }

        private QueueModel _qm = null;
        private QueueVoiceModuleDesign _queueVoiceDesign = null;
        private bool _isStop = false;
        public QueueVoiceControl()
        {
            InitializeComponent();

            _queueVoiceDesign = new QueueVoiceModuleDesign();

            _queueVoiceDesign.PlayCount = 2;
            _queueVoiceDesign.PlayRate = 0;
            _queueVoiceDesign.Interval = 5;
            _queueVoiceDesign.PlayHintSound = true;
        }

        private QueueModel QueueModel
        {
            get
            {
                if (_qm == null) _qm = new QueueModel(_dbQuery);

                return _qm;
            }
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = false;
            _moduleName = "排队语音播放";
            _category = "后台业务";

            //_provideActionDesc.Add("", "");

            _designEvents.Add(QueueVoiceEventDefine.Refresh, new EventActionReleation(QueueVoiceEventDefine.Refresh, ActionType.atSysFixedEvent)); 
        }


        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _queueVoiceDesign = JsonHelper.DeserializeObject<QueueVoiceModuleDesign>(customContext);

            LoadDesign();


        }


        private void LoadDesign()
        {
            //if (DesignMode == false) timerPlay.Enabled = true;
        }

        private bool _isUseVoice = false;
        public override void ModuleLoaded()
        {
            //设计模式不启动呼叫
            if (DesignMode) return;

            base.ModuleLoaded();

            if (GlobalProcess.IsStartedVoice)
            {
                //语音播放已经启动
                return;
            }

            GlobalProcess.IsStartedVoice = true;
            GlobalProcess.StartModuleDescription = (this.TopLevelControl as Form).Text + "." + _moduleName;


            _isUseVoice = true;
            _isStop = false;

            timerPlay.Interval = ((_queueVoiceDesign.Interval <= 0) ? 5 : _queueVoiceDesign.Interval) * 1000;
            timerPlay.Enabled = true;
        }

        public override void Terminated()
        {
            _isStop = true;
            timerPlay.Enabled = false;

            base.Terminated();
        }


        public override string ShowCustomDesign()
        {
            frmQueueVoiceDesign design = new frmQueueVoiceDesign();
            design.ShowQueueCallDesign(_queueVoiceDesign, this);

            _customDesignFmt = JsonHelper.SerializeObject(_queueVoiceDesign);

            LoadDesign();

            return _customDesignFmt;
        }

        private DataTable _dtCall = null;

        public class ThreadVoicePar
        {
            public LineCallData LineCallInfo { get; set; }
            public LineUpData LineUpInfo { get; set; }
        }

        private bool DoActions(string actionName, object sender)
        {
            try
            {
                if (_designEvents.ContainsKey(actionName))
                {
                    return base.DoBindActions(_designEvents[actionName], sender);
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }


        private void LoopPlay()
        {

            DataRow drPlay = _dtCall.Rows[0];

            if (_isStop) return;


            LineCallData linecallInfo = new LineCallData();
            linecallInfo.BindRowData(drPlay);

            LineUpData lineupInfo = QueueModel.GetLineupInfo(linecallInfo.排队ID);


            //更新状态未正在呼叫
            lineupInfo.排队状态 = LineUpState.qsCalling;

            lineupInfo.附加信息.末次呼叫时间 = QueueModel.GetServerDate();
            lineupInfo.附加信息.CopyBasePro(lineupInfo);

            QueueModel.UpdateLineupInfo(lineupInfo);

            if (_isStop) return;

            DoActions(QueueVoiceEventDefine.Refresh, null);
            
            if (_isStop) return;

            //播放声音
            StartPlay(linecallInfo, lineupInfo);

            if (_isStop) return;


        }

        private void timerPlay_Tick(object sender, EventArgs e)
        {
            try
            {
                timerPlay.Interval = ((_queueVoiceDesign.Interval <= 0) ? 5 : _queueVoiceDesign.Interval) * 1000;

                if (_isUseVoice)
                {
                    timerPlay.Enabled = false;

                    if (_dtCall == null || _dtCall.Rows.Count <= 0)
                    {
                        _dtCall = QueueModel.GetCallTextInfo(_stationInfo.StationName);
                    }
                                        

                    if (_dtCall.Rows.Count > 0)
                    {
                        LoopPlay();
                    }
                    else
                    {
                        timerPlay.Enabled = true;
                    }
                }

                DoActions(QueueVoiceEventDefine.Refresh, null);

                //timerPlay.Enabled = true;
            }
            catch(Exception ex)
            {
                timerPlay.Enabled = false;
                MsgBox.ShowException(ex, this);
            }
        }

        private void StartPlay(LineCallData lineupCallInfo, LineUpData lineupInfo)
        {
            BackgroundWorker bgWork = new BackgroundWorker();

            bgWork.DoWork += DoWork;
            bgWork.ProgressChanged += ProgessChanged;
            bgWork.RunWorkerCompleted += WorkerCompleted;

            bgWork.WorkerReportsProgress = false;
            bgWork.WorkerSupportsCancellation = true;

            ThreadVoicePar lineVoicePar = new ThreadVoicePar();
            lineVoicePar.LineCallInfo = lineupCallInfo;
            lineVoicePar.LineUpInfo = lineupInfo;

            bgWork.RunWorkerAsync(lineVoicePar);
        }


        private object objLockWork = new object();
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            lock (objLockWork)
            {
                if (e.Argument == null)
                {
                    throw new Exception("播放参数传递无效。");
                }

                ThreadVoicePar lineVoicePar = e.Argument as ThreadVoicePar;
                if (lineVoicePar == null)
                {
                    throw new Exception("播放参数信息无效。");
                }

                LineCallData lineCallInfo = lineVoicePar.LineCallInfo;
                LineUpData lineupInfo = lineVoicePar.LineUpInfo;
                try
                {
                    if (_isStop) return;

                    if (_queueVoiceDesign.PlayHintSound)
                    {
                        SoundPlayer sp = new SoundPlayer(Properties.Resources.DingDong);
                        sp.PlaySync();
                    }

                    if (_isStop) return;

                    //执行语音播放
                    for (int i = 0; i < _queueVoiceDesign.PlayCount; i++)
                    {
                        if (_isStop) break;
                        PlaySound(lineCallInfo.呼叫信息.格式内容);
                    }

                    //更新状态为呼叫完成
                    lineupInfo.排队状态 = LineUpState.qsCalled;

                    QueueModel.TransactionBegin();

                    try
                    {
                        QueueModel.UpdateLineupInfo(lineupInfo);

                        //删除播放内容
                        QueueModel.DelCallInfoByCallId(lineCallInfo.呼叫ID);

                        QueueModel.TransactionCommit();

                        DataRow drBind = lineCallInfo.GetBindRow();
                        if (drBind != null) _dtCall.Rows.Remove(drBind);
                        //e.Result = lineCallInfo.GetBindRow();
                    }
                    catch(Exception ex)
                    {
                        QueueModel.TransactionRollback();
                        throw new Exception("更新语音播放后的排队信息出现错误", ex); ;
                    }


                }
                catch (Exception ex)
                {
                    try
                    {
                        lineupInfo.排队状态 = LineUpState.qsWaitCall;
                        lineupInfo.附加信息.末次呼叫时间 = QueueModel.GetServerDate();

                        QueueModel.UpdateLineupInfo(lineupInfo);
                    }
                    catch (Exception exd)
                    {
                        throw new Exception("恢复语音播放前的排队状态错误", exd);
                    }

                    throw new Exception("排队语音播放错误", ex);
                }
            }
        }

        private void PlaySound(string context)
        {
            SpeechSynthesizer Talker = new SpeechSynthesizer();

            Talker.Rate = _queueVoiceDesign.PlayRate;
            Talker.Volume = 100;



            if (string.IsNullOrEmpty(_queueVoiceDesign.VoiceName) == false)
            {
                Talker.SelectVoice(_queueVoiceDesign.VoiceName);
            }
            //设置性别,年龄类型等，需要tts支持
            //Talker.SelectVoiceByHints(VoiceGender.NotSet, VoiceAge.Child, 2, System.Globalization.CultureInfo.CurrentCulture);

            Talker.Speak(context);

        }


        private void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        delegate void DelegateDoWorkMsg(Exception msg);
        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //增加失败声音提示
                DoWorkMsg(e.Error);

                return;
            }

            //if (e.Result != null)
            //{
            //    DataRow drBind = e.Result as DataRow;
            //    if (drBind != null) _dtCall.Rows.Remove(drBind);
            //}

            StartWork();
        }
         

        public void DoWorkMsg(Exception ex)
        {
            if (this.InvokeRequired)//如果是在非创建控件的线程访问，即InvokeRequired=true
            {
                DelegateDoWorkMsg workMsg = new DelegateDoWorkMsg(DoWorkMsg);
                this.Invoke(workMsg, new object[] { ex });
            }
            else
            {
                MsgBox.ShowException(ex, this);
            }
        }

        delegate void DelegateDoStartWork();
        public void StartWork()
        {
            if (this.InvokeRequired)//如果是在非创建控件的线程访问，即InvokeRequired=true
            {
                DelegateDoStartWork workFunc = new DelegateDoStartWork(StartWork);
                this.Invoke(workFunc);
            }
            else
            {
                timerPlay.Interval = 10;
                timerPlay.Enabled = true;
            }
        }
    }
}

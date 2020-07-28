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
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Services;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.QueueQuick
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(QueueQuickControl), "Resources.queuequick.ico")]
    public partial class QueueQuickControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class QueueQuickActionDefine
        {
            public const string Refresh = "刷新";
            public const string ChangeQueue = "切换队列";
        }

        static public class QueueQuickDataDefine
        {
            public const string CurCallLineup = "当前操作的排队信息";
        }

 
        static public class QueueQuickEventDefine
        {
            public const string OrderCallBefore = "顺呼前";
            public const string OrderCallAfter = "顺呼后";

            public const string DirectCallBefore = "直呼前";
            public const string DirectCallAfter = "直呼后";

            public const string DiagnoseBefore = "接诊前";
            public const string DiagnoseAfter = "接诊后";

            public const string ChangeQueueBefore = "队列切换前";
            public const string ChangeQueueAfter = "队列切换后";
        }

        struct OperLineupInfo
        {
            public string LineupId;
            public string QueueId;
            public string QueueName;
            public string ApplyId;
            public string PatientId;
            public string PatientName;
        }

        private QueueModel _qm = null;
        private QueueQuickModuleDesign _queueQuickDesign = null;
        private List<QueueItem> _queueItems = null;
        
        private OperLineupInfo _curOperLineupInfo = new OperLineupInfo(); 

        public QueueQuickControl()
        {
            InitializeComponent();

            _queueItems = new List<QueueItem>();

            _queueQuickDesign = new QueueQuickModuleDesign();
            _queueQuickDesign.BackColor = Color.FromArgb(64, 64, 64);
            _queueQuickDesign.ForeColor = Color.Black;
            _queueQuickDesign.CallColor = Color.Green;

            _queueQuickDesign.ModuleFontName = this.Font.Name;
            _queueQuickDesign.ModuleFontSize = this.Font.Size;
            _queueQuickDesign.ModuleFontBold = this.Font.Bold;
            _queueQuickDesign.ModuleFontItalic = this.Font.Italic;

            _queueQuickDesign.WaitFontName = this.Font.Name;
            _queueQuickDesign.WaitFontSize = this.Font.Size;
            _queueQuickDesign.WaitFontBold = this.Font.Bold;
            _queueQuickDesign.WaitFontItalic = this.Font.Italic;
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
            _multiInstance = true;
            _moduleName = "队列快捷操作";

            _provideActionDesc.Add(QueueQuickActionDefine.Refresh, "刷新队列排队状态信息。");

            _provideDataDesc.AddDataDescription(_moduleName, QueueQuickDataDefine.CurCallLineup, "返回当前操作的排队信息，返回数据项如下："
                                                                                            + System.Environment.NewLine
                                                                                            + "queueid,queuename,lineupid,applyid,patientid,patientname");

            _designEvents.Add(QueueQuickEventDefine.OrderCallBefore, new EventActionReleation(QueueQuickEventDefine.OrderCallBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueQuickEventDefine.OrderCallAfter, new EventActionReleation(QueueQuickEventDefine.OrderCallAfter, ActionType.atSysFixedEvent));

            _designEvents.Add(QueueQuickEventDefine.DirectCallBefore, new EventActionReleation(QueueQuickEventDefine.DirectCallBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueQuickEventDefine.DirectCallAfter, new EventActionReleation(QueueQuickEventDefine.DirectCallAfter, ActionType.atSysFixedEvent));

            _designEvents.Add(QueueQuickEventDefine.DiagnoseBefore, new EventActionReleation(QueueQuickEventDefine.DiagnoseBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueQuickEventDefine.DiagnoseAfter, new EventActionReleation(QueueQuickEventDefine.DiagnoseAfter, ActionType.atSysFixedEvent));
        }


        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case QueueQuickDataDefine.CurCallLineup:
                    return true;

                default:
                    return false;
            }
        }

        public override IBizDataItems QueryDatas(string dataIdentificationName)
        {
            BizDataItems resultDatas = null;
            BizDataItem dataItem = null;

            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case QueueQuickDataDefine.CurCallLineup://当前操作的排队信息
                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_LineupId, _curOperLineupInfo.LineupId);

                    dataItem.Add(DataHelper.StdPar_QueueId, _curOperLineupInfo.QueueId);
                    dataItem.Add(DataHelper.StdPar_QueueName, _curOperLineupInfo.QueueName);
                    
                    dataItem.Add(DataHelper.StdPar_ApplyId, _curOperLineupInfo.ApplyId);
                    dataItem.Add(DataHelper.StdPar_PatientId, _curOperLineupInfo.PatientId);
                    dataItem.Add(DataHelper.StdPar_PatiName, _curOperLineupInfo.PatientName);

                    resultDatas.Add(dataItem);

                    return resultDatas;

                default:
                    return null;
            }
        }


        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {

                switch (actName)
                {
                    case QueueQuickActionDefine.Refresh:
                        BindQueueCall();
                        return true;

                    case QueueQuickActionDefine.ChangeQueue:
                        if (bizDatas == null) return false;

                        string queueName = DataHelper.GetItemValueByQueueName(bizDatas[0]);

                        return Action_ChangeQueue(queueName, null); 

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

        private bool Action_ChangeQueue(string queueName, object sender)
        {
            if (DoActions(QueueQuickEventDefine.ChangeQueueBefore, sender) == false) return false;

            int index = cbxQueueNames.FindString(queueName);
            if (index < 0)
            {
                MessageBox.Show("未加载此队列信息。", "提示");
                return false;
            }

            cbxQueueNames.SelectedIndex = index;

            DoActions(QueueQuickEventDefine.ChangeQueueAfter, sender);

            return true;
        }


        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _queueQuickDesign = JsonHelper.DeserializeObject<QueueQuickModuleDesign>(customContext);

            LoadDesign();

            //BindQueueCall();

        }


        private void LoadDesign()
        {
            labWaitCall.BackColor = Color.Transparent;
            labWaitCall.ForeColor = _queueQuickDesign.CallColor;

            labNext.BackColor = Color.Transparent;
            labNext.ForeColor = _queueQuickDesign.ForeColor;


            this.BackColor = _queueQuickDesign.BackColor;
            this.ForeColor = _queueQuickDesign.ForeColor;

            cbxQueueNames.ForeColor = _queueQuickDesign.ForeColor;
            labQueueCount.ForeColor = _queueQuickDesign.ForeColor;

            butMiss.ForeColor = _queueQuickDesign.ForeColor;
            butOrderCall.ForeColor = _queueQuickDesign.ForeColor;
            butRestartCall.ForeColor = _queueQuickDesign.ForeColor;
            butDiagnose.ForeColor = _queueQuickDesign.ForeColor;



            float fontSize = 0;
            FontStyle fs = FontStyle.Regular;

            try
            {
                fontSize = _queueQuickDesign.ModuleFontSize;
            }
            catch { }
            if (fontSize <= 0) fontSize = this.Font.Size;


            if (_queueQuickDesign.ModuleFontBold) fs = fs | FontStyle.Bold;
            if (_queueQuickDesign.ModuleFontItalic) fs = fs | FontStyle.Italic;

            Font moduleFont = new Font(_queueQuickDesign.ModuleFontName, fontSize, fs);

            labNext.Font = moduleFont;
            cbxQueueNames.Font = moduleFont;
            labQueueCount.Font = moduleFont;
            butMiss.Font = moduleFont;

            butOrderCall.Font = moduleFont;
            butRestartCall.Font = moduleFont;
            butDiagnose.Font = moduleFont;


            _queueItems.Clear();

            //查询科室包含的队列
            DataTable dtQueueData = QueueModel.GetQueueInfoByDeptId(_stationInfo.DepartmentId);
            foreach (DataRow drQueue in dtQueueData.Rows)
            {
                QueueData queData = new QueueData();
                queData.BindRowData(drQueue);

                if (string.IsNullOrEmpty(_stationInfo.RoomId) == false)
                {
                    if (queData.包含房间.房间明细.FindIndex(T => T.房间ID == _stationInfo.RoomId) < 0) continue;
                }

                QueueItem qi = new QueueItem();

                qi.QueueName = drQueue["队列名称"].ToString();
                qi.QueueId = drQueue["队列ID"].ToString();

                _queueItems.Add(qi);
            }

            cbxQueueNames.Items.Clear();

            cbxQueueNames.DisplayMember = "Name";
            cbxQueueNames.ValueMember = "Value";

            DataTable queueDatas = QueueModel.GetQueueInfoByDeptId(_stationInfo.DepartmentId);
            foreach (QueueItem qi in _queueItems)
            {
                DataRow[] drQueues = queueDatas.Select("队列ID='" + qi.QueueId + "'");

                if (drQueues.Length > 0)
                {
                    QueueData queData = new QueueData();
                    queData.BindRowData(drQueues[0]);

                    ItemBind ib = new ItemBind();

                    ib.Name = queData.队列名称;
                    ib.Value = queData.队列ID;
                    ib.Tag = queData;

                    cbxQueueNames.Items.Add(ib);
                }
            }

            if (cbxQueueNames.Items.Count > 0) cbxQueueNames.SelectedIndex = 0;
        }

        private QueueQuickConfig _qqc = null;
        public override void ModuleLoaded()
        {
            base.ModuleLoaded();

            if (cbxQueueNames.Items.Count <= 0) return;
            //读取上次选择的队列
            _qqc = QueueQuickConfig.GetConfig(_moduleName);

            if (string.IsNullOrEmpty(_qqc.DefaultQueueName) == false)
            {
                cbxQueueNames.Text = _qqc.DefaultQueueName;
            }
            else
            {
                cbxQueueNames.SelectedIndex = 0;
            }
        }


        public override string ShowCustomDesign()
        {
            using (frmQueueQuickDesign design = new frmQueueQuickDesign())
            {
                design.ShowQueueQuickDesign(QueueModel, _stationInfo.DepartmentId, _queueQuickDesign, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_queueQuickDesign);

            LoadDesign();

            //BindQueueCall();

            return _customDesignFmt;
        }

        private void BindQueueCall()
        {
            try
            {
                labWaitCall.Text = "";
                labWaitCall.Tag = null;

                labNext.Text = "";
                labNext.Tag = null;

                labQueueCount.Text = "余：000人";

                if (cbxQueueNames.SelectedItem == null) return;
                ItemBind ib = cbxQueueNames.SelectedItem as ItemBind;
                 
                string queueId = ib.Value;

                int queueCount = QueueModel.GetLineupCount(queueId, QueueModel.GetServerDate());
                labQueueCount.Text = "余：" + queueCount.ToString().PadLeft(3, '0') + "人";

                //查询已呼叫的排队
                DataTable dtLastCall = QueueModel.GetLastCallInfoByQueueId(queueId, true);
                if (dtLastCall != null && dtLastCall.Rows.Count > 0)
                {
                    LineUpData lineupCall = null;
                    DateTime lastTime = default(DateTime);

                    foreach (DataRow drCall in dtLastCall.Rows)
                    {
                        LineUpData curLineup = new LineUpData();
                        curLineup.BindRowData(drCall);

                        if (curLineup.附加信息.末次呼叫时间 >= lastTime && curLineup.附加信息.检查房间 == _stationInfo.RoomName)
                        {
                            lineupCall = curLineup;
                            lastTime = curLineup.附加信息.末次呼叫时间;
                        }
                    }

                    if (lineupCall != null)
                    {
                        string waitCall = "(" + lineupCall.号码前缀 + lineupCall.排队号码 + ") "
                            + lineupCall.患者姓名 + " " + lineupCall.附加信息.性别 + " " + lineupCall.附加信息.年龄
                            + "\r" + lineupCall.附加信息.检查项目;

                        labWaitCall.Tag = lineupCall;
                        labWaitCall.Text = waitCall;
                    }
                }

                //查询待呼叫的排队
                LineUpData lineupNext = QueueModel.GetOrderCallLineup(queueId);
                if (lineupNext != null )
                {
                    string nextCall = "(" + lineupNext.号码前缀 + lineupNext.排队号码 + ") "
                        + lineupNext.患者姓名 + " " + lineupNext.附加信息.性别 + " " + lineupNext.附加信息.年龄
                        + " " + lineupNext.附加信息.检查项目;

                    labNext.Tag = lineupNext;
                    labNext.Text = nextCall;
                }


            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxQueueNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DoActions(QueueQuickEventDefine.ChangeQueueBefore, sender) == false) return;

                BindQueueCall();

                DoActions(QueueQuickEventDefine.ChangeQueueBefore, sender);

                if (_qqc == null)
                {
                    _qqc = QueueQuickConfig.GetConfig(_moduleName);

                    _qqc.DefaultQueueName = cbxQueueNames.Text;
                }

                QueueQuickConfig.SetConfig(_qqc, _moduleName);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private void DoLineupCall(LineUpData lineupInfo, QueueData queueData)
        {
            DateTime callTime = _qm.GetServerStamp();

            lineupInfo.检查房间 = _stationInfo.RoomName;

            if (lineupInfo.附加信息.首次呼叫时间 == default(DateTime)) lineupInfo.附加信息.首次呼叫时间 = callTime;
            lineupInfo.附加信息.末次呼叫时间 = callTime;
            lineupInfo.附加信息.播放站点 = queueData.队列信息.播放站点;

            if (lineupInfo.排队状态 == LineUpState.qsQueueing) lineupInfo.排队状态 = LineUpState.qsWaitCall;

            lineupInfo.附加信息.CopyBasePro(lineupInfo);


            LineCallData callInfo = new LineCallData();

            callInfo.呼叫ID = SqlHelper.GetNumGuid();
            callInfo.排队ID = lineupInfo.排队ID;
            callInfo.队列ID = lineupInfo.队列ID;
            callInfo.生成日期 = callTime;
            callInfo.呼叫站点 = queueData.队列信息.播放站点;


            callInfo.呼叫信息.原始内容 = queueData.队列信息.呼叫格式.Replace("[排队号码]", lineupInfo.号码前缀 + lineupInfo.排队号码).Replace("[患者姓名]", lineupInfo.患者姓名).Replace("[检查房间]", lineupInfo.检查房间).Replace("[科室名称]", lineupInfo.科室名称);
            callInfo.呼叫信息.格式内容 = queueData.队列信息.呼叫格式.Replace("[排队号码]", lineupInfo.号码前缀 + lineupInfo.排队号码).Replace("[患者姓名]", PYConvert.FormatCallSurname(lineupInfo.患者姓名)).Replace("[检查房间]", lineupInfo.检查房间).Replace("[科室名称]", lineupInfo.科室名称);

            callInfo.呼叫信息.CopyBasePro(callInfo);


            _qm.TransactionBegin();

            try
            {
                _qm.UpdateLineupInfo(lineupInfo);

                _qm.NewCall(callInfo);

                _qm.TransactionCommit();
            }
            catch (Exception ex)
            {
                _qm.TransactionRollback();

                throw ex;
            }
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

        private void butOrderCall_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxQueueNames.SelectedItem == null) return;

                if (DoActions(QueueQuickEventDefine.OrderCallBefore, sender) == false) return;

                ItemBind ib = cbxQueueNames.SelectedItem as ItemBind;

                QueueData queData = ib.Tag as QueueData;

                LineUpData lineupOrder = QueueModel.GetOrderCallLineup(queData.队列ID);
                if (lineupOrder != null)
                {
                    DoLineupCall(lineupOrder, queData);
                }

                BindQueueCall();

                SetCurInfo(lineupOrder);

                DoActions(QueueQuickEventDefine.OrderCallAfter, sender);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butDiagnose_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxQueueNames.SelectedItem == null) return;


                if (labWaitCall.Tag == null)
                {
                    MessageBox.Show("尚无进行呼叫的队列信息。", "提示");
                    return;
                }


                LineUpData lineupWait = labWaitCall.Tag as LineUpData;

                LineUpData lineupNew = QueueModel.GetLineupInfo(lineupWait.排队ID);

                if (lineupNew.附加信息.最后更新日期 != lineupWait.附加信息.最后更新日期)
                {
                    MessageBox.Show("排队信息已发生变更。", "提示");
                    BindQueueCall();

                    return;
                }

                if (DoActions(QueueQuickEventDefine.DiagnoseBefore, sender) == false) return;

                lineupNew.排队状态 = LineUpState.qsRecepting;
                lineupNew.附加信息.CopyBasePro(lineupNew);

                QueueModel.UpdateLineupInfo(lineupNew);

                labWaitCall.Tag = lineupNew;

                SetCurInfo(lineupNew);

                DoActions(QueueQuickEventDefine.DiagnoseAfter, sender);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butRestartCall_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxQueueNames.SelectedItem == null)  return;


                if (labWaitCall.Tag == null)
                {
                    MessageBox.Show("尚无进行呼叫的队列信息。", "提示");
                    return;
                }

                LineUpData lineupWait = labWaitCall.Tag as LineUpData;

                LineUpData lineupNew = QueueModel.GetLineupInfo(lineupWait.排队ID);

                if (lineupNew.附加信息.最后更新日期 != lineupWait.附加信息.最后更新日期)
                {
                    MessageBox.Show("排队信息已发生变更。", "提示");
                    BindQueueCall();

                    return;
                }

                if (DoActions(QueueQuickEventDefine.DirectCallBefore, sender) == false) return;


                ItemBind ib = cbxQueueNames.SelectedItem as ItemBind;

                QueueData queData = ib.Tag as QueueData;

                DoLineupCall(lineupNew, queData);

                SetCurInfo(lineupNew); 

                DoActions(QueueQuickEventDefine.DirectCallAfter, sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void SetCurInfo(LineUpData lineupInfo)
        {
            _curOperLineupInfo.LineupId = lineupInfo.排队ID;
            _curOperLineupInfo.QueueId = lineupInfo.队列ID;
            _curOperLineupInfo.QueueName = lineupInfo.队列名称;
            _curOperLineupInfo.ApplyId = lineupInfo.申请ID;
            _curOperLineupInfo.PatientId = lineupInfo.患者ID;
            _curOperLineupInfo.PatientName = lineupInfo.患者姓名;
        }
    }
}

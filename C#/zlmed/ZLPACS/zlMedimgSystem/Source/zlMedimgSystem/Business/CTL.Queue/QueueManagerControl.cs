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
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.QueueManager
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(QueueManagerControl), "Resources.queue.ico")]
    public partial class QueueManagerControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {


        static public class QueueManagerDataDefine
        {
            public const string SelQueueData = "当前选中的队列信息";
            public const string SelLineupData = "当前选中的排队信息";
            public const string CurLineupData = "当前操作的排队信息"; 
        }

        static public class QueueManagerActionDefine
        {
            public const string IntoQueue = "入队";
            public const string OrderCall = "顺呼";
            public const string DirectCall = "直呼";
            public const string InsertQueue = "插队";
            public const string ReQueue = "重排";
            public const string Pause = "暂停";
            public const string Abandon = "弃号";
            public const string Recept = "接诊";
            public const string Restore = "恢复";
            public const string Print = "打号";
            public const string Refresh = "刷新";
            public const string Modify = "修改";
            public const string Find = "查找";
            public const string ChangeQueue = "切换队列";
        }

        static public class QueueManagerEventDefine
        {
            public const string IntoQueueBefore = "入队前"; 
            public const string OrderCallBefore = "顺呼前";
            public const string DirectCallBefore = "直呼前";     
            public const string InsertQueueBefore = "插队前";
            public const string ResetQueueBefore = "重排前";
            public const string PausetQueueBefore = "暂停前";
            public const string AbandonQueueBefore = "弃呼前";
            public const string ReceptQueueBefore = "接诊前";
            public const string RestoreQueueBefore = "恢复前";
            public const string PrintQueueBefore = "打号前";
            public const string RefreshQueueBefore = "刷新前";
            public const string ModifyQueueBefore = "修改前";
            public const string FindQueueBefore = "查找前";
            public const string ChangeQueueBefore = "改变队列前";


            public const string IntoQueueAfter = "入队后";
            public const string OrderCallAfter = "顺呼后";
            public const string DirectCallAfter = "直呼后";
            public const string InsertQueueAfter = "插队后";
            public const string ResetQueueAfter = "重排后";
            public const string PausetQueueAfter = "暂停后";
            public const string AbandonQueueAfter = "弃呼后";
            public const string ReceptQueueAfter = "接诊后";
            public const string RestoreQueueAfter = "恢复后";
            public const string PrintQueueAfter = "打号后";
            public const string RefreshQueueAfter = "刷新后";
            public const string ModifyQueueAfter = "修改后";
            public const string FindQueueAfter = "查找后";
            public const string ChangeQueueAfter = "改变队列后";
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

        private DateTime _selDate = default(DateTime);
        private QueueModel _qm = null;
        private QueueModuleDesign _queueDesign = null;

        private OperLineupInfo _curOperLineupInfo = new OperLineupInfo();

        /// <summary>
        /// 队列数据访问模型
        /// </summary>
        public QueueModel QueueModel
        {
            get
            {
                if (_qm == null) _qm = new QueueModel(_dbQuery);

                return _qm;
            }
        }

        public QueueManagerControl()
        {
            InitializeComponent();

            _queueDesign = new QueueModuleDesign();

            _queueDesign.ButAbandonQueueVisible = true;
            _queueDesign.ButDirectCallVisible = true;
            _queueDesign.ButFindQueueVisible = true;
            _queueDesign.ButInsertQueueVisible = true;
            _queueDesign.ButModifyQueueVisible = true;
            _queueDesign.ButOrderCallVisible = true;
            _queueDesign.ButPauseQueueVisible = true;
            _queueDesign.ButPrintQueueVisible = true;
            _queueDesign.ButReceptQueueVisible = true;
            _queueDesign.ButRefreshQueueVisible = true;
            _queueDesign.ButResetQueueVisible = true;
            _queueDesign.ButRestoreQueueVisible = true;

            _queueDesign.ToolsDesign.Visible = true;
            _queueDesign.ToolsDesign.BackColor = toolStripEx1.BackColor;
            _queueDesign.ToolsDesign.ForceColor = toolStripEx1.ForeColor;

        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "队列排队管理";

            _provideActionDesc.Add(QueueManagerActionDefine.IntoQueue, "患者检查入队，根据请求的申请数据执行排队操作，请求数据项如下：" 
                                                                + System.Environment.NewLine 
                                                                + "applyid");

            _provideActionDesc.Add(QueueManagerActionDefine.Refresh, "刷新当前队列排队数据。");
            _provideActionDesc.Add(QueueManagerActionDefine.Abandon, "放弃对当前排队患者的呼叫。");
            _provideActionDesc.Add(QueueManagerActionDefine.DirectCall, "选择指定排队患者进行呼叫。");
            _provideActionDesc.Add(QueueManagerActionDefine.Find, "查找指定的排队患者信息。");
            _provideActionDesc.Add(QueueManagerActionDefine.InsertQueue, "插入指定的排队信息到队列中。");
            _provideActionDesc.Add(QueueManagerActionDefine.Modify, "修改指定的排队患者信息。");
            _provideActionDesc.Add(QueueManagerActionDefine.OrderCall, "按顺序呼叫排队的患者。");
            _provideActionDesc.Add(QueueManagerActionDefine.Pause, "暂停当前排队患者的呼叫。");
            _provideActionDesc.Add(QueueManagerActionDefine.Print, "打印队列号。");
            _provideActionDesc.Add(QueueManagerActionDefine.Recept, "接诊当前已呼叫的排队患者。");
            _provideActionDesc.Add(QueueManagerActionDefine.ReQueue, "重新对指定患者进行排队。");
            _provideActionDesc.Add(QueueManagerActionDefine.Restore, "恢复状态。");
            _provideActionDesc.Add(QueueManagerActionDefine.ChangeQueue, "改变当前加载的排队队列,根据请求的队列名称进行队列切换，请求数据项如下："
                                                                    + System.Environment.NewLine 
                                                                    + "queuename");

            _provideDataDesc.AddDataDescription(_moduleName, QueueManagerDataDefine.SelQueueData, "返回当前选择的队列信息，返回数据项如下："
                                                        + System.Environment.NewLine
                                                        + "queueid,queuename");
            _provideDataDesc.AddDataDescription(_moduleName, QueueManagerDataDefine.SelLineupData, "返回当前选择的排队信息，返回数据项如下："
                                                                    + System.Environment.NewLine
                                                                    + "queueid,queuename,lineupid,applyid,patientid,patientname");
            _provideDataDesc.AddDataDescription(_moduleName, QueueManagerDataDefine.CurLineupData, "返回当前操作的排队信息，返回数据项如下："
                                                                                + System.Environment.NewLine
                                                                                + "queueid,queuename,lineupid,applyid,patientid,patientname");

            _designEvents.Add(QueueManagerEventDefine.AbandonQueueAfter, new EventActionReleation(QueueManagerEventDefine.AbandonQueueAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.AbandonQueueBefore, new EventActionReleation(QueueManagerEventDefine.AbandonQueueBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.ChangeQueueAfter, new EventActionReleation(QueueManagerEventDefine.ChangeQueueAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.ChangeQueueBefore, new EventActionReleation(QueueManagerEventDefine.ChangeQueueAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.DirectCallAfter, new EventActionReleation(QueueManagerEventDefine.DirectCallAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.DirectCallBefore, new EventActionReleation(QueueManagerEventDefine.DirectCallBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.FindQueueAfter, new EventActionReleation(QueueManagerEventDefine.FindQueueAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.FindQueueBefore, new EventActionReleation(QueueManagerEventDefine.FindQueueBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.InsertQueueAfter, new EventActionReleation(QueueManagerEventDefine.InsertQueueAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.InsertQueueBefore, new EventActionReleation(QueueManagerEventDefine.InsertQueueBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.IntoQueueAfter, new EventActionReleation(QueueManagerEventDefine.IntoQueueAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.IntoQueueBefore, new EventActionReleation(QueueManagerEventDefine.IntoQueueBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.ModifyQueueAfter, new EventActionReleation(QueueManagerEventDefine.ModifyQueueAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.ModifyQueueBefore, new EventActionReleation(QueueManagerEventDefine.ModifyQueueBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.OrderCallAfter, new EventActionReleation(QueueManagerEventDefine.OrderCallAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.OrderCallBefore, new EventActionReleation(QueueManagerEventDefine.OrderCallBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.PausetQueueAfter, new EventActionReleation(QueueManagerEventDefine.PausetQueueAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.PausetQueueBefore, new EventActionReleation(QueueManagerEventDefine.PausetQueueBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.PrintQueueAfter, new EventActionReleation(QueueManagerEventDefine.PrintQueueAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.PrintQueueBefore, new EventActionReleation(QueueManagerEventDefine.PrintQueueBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.ReceptQueueAfter, new EventActionReleation(QueueManagerEventDefine.ReceptQueueAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.ReceptQueueBefore, new EventActionReleation(QueueManagerEventDefine.ReceptQueueBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.RefreshQueueAfter, new EventActionReleation(QueueManagerEventDefine.RefreshQueueAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.RefreshQueueBefore, new EventActionReleation(QueueManagerEventDefine.RefreshQueueBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.ResetQueueAfter, new EventActionReleation(QueueManagerEventDefine.ResetQueueAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.ResetQueueBefore, new EventActionReleation(QueueManagerEventDefine.ResetQueueBefore, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.RestoreQueueAfter, new EventActionReleation(QueueManagerEventDefine.RestoreQueueAfter, ActionType.atSysFixedEvent));
            _designEvents.Add(QueueManagerEventDefine.RestoreQueueBefore, new EventActionReleation(QueueManagerEventDefine.RestoreQueueBefore, ActionType.atSysFixedEvent));
        }

        /// <summary>
        /// 插队
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool Action_InsertQueue(object sender)
        {
            QueueData queData = GetSelQueue();

            if (queData == null) return false;


            if (listQueue.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择需要插队的排队信息。", "提示");
                return false;
            }
                        
            LineUpData lineupInfo = listQueue.SelectedItems[0].Tag as LineUpData;
            if (lineupInfo == null)
            {
                MessageBox.Show("未获取到有效的排队信息，请刷新后重试。", "提示");
                return false;
            }

            LineUpData lineupNew = _qm.GetLineupInfo(lineupInfo.排队ID);
            if (lineupInfo.附加信息.最后更新日期 != lineupNew.附加信息.最后更新日期)
            {
                MessageBox.Show("当前状态已改变，请刷新后重试。", "提示");
                return false;
            }

            if (DoActions(QueueManagerEventDefine.InsertQueueBefore, sender) == false) return false;

            using (frmInsertQueue insertQueue = new frmInsertQueue())
            {
                if (insertQueue.ShowInsertQueue(QueueModel, lineupNew, this))
                {
                    SetCurInfo(lineupNew);

                    RebindData(queData.队列ID, _selDate);

                    DoActions(QueueManagerEventDefine.InsertQueueAfter, sender);

                    return true;
                }
            }
                        
            return false;

        }

        /// <summary>
        /// 重排
        /// </summary>
        private bool Action_ResetQueue(object sender)
        {
            QueueData queData = GetSelQueue();

            if (queData == null) return false;


            if (listQueue.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择需要重排的排队信息。", "提示");
                return false;
            }

            LineUpData lineupInfo = listQueue.SelectedItems[0].Tag as LineUpData;
            if (lineupInfo == null)
            {
                MessageBox.Show("未获取到有效的排队信息，请刷新后重试。", "提示");
                return false;
            }

            LineUpData lineupNew = _qm.GetLineupInfo(lineupInfo.排队ID);
            if (lineupInfo.附加信息.最后更新日期 != lineupNew.附加信息.最后更新日期)
            {
                MessageBox.Show("当前状态已改变，请刷新后重试。", "提示");
                return false;
            }

            if (DoActions(QueueManagerEventDefine.ResetQueueBefore, sender) == false) return false;

            using (frmResetQueue resetQueue = new frmResetQueue())
            {
                if (resetQueue.ShowResetQueue(_qm, lineupInfo, this))
                {
                    SetCurInfo(lineupInfo);

                    RebindData(queData.队列ID, _selDate);

                    DoActions(QueueManagerEventDefine.ResetQueueAfter, sender);

                    return true;
                }
            }
                        
            return false;

        }

        /// <summary>
        /// 暂停
        /// </summary>
        /// <returns></returns>
        private bool Action_PauseQueue(object sender)
        {
            QueueData queData = GetSelQueue();

            if (queData == null) return false;


            if (listQueue.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择需要暂停的排队信息。", "提示");
                return false;
            }

            LineUpData lineupInfo = listQueue.SelectedItems[0].Tag as LineUpData;
            if (lineupInfo == null)
            {
                MessageBox.Show("未获取到有效的排队信息，请刷新后重试。", "提示");
                return false;
            }

            LineUpData lineupNew = _qm.GetLineupInfo(lineupInfo.排队ID);
            if (lineupInfo.附加信息.最后更新日期 != lineupNew.附加信息.最后更新日期)
            {
                MessageBox.Show("当前状态已改变，请刷新后重试。", "提示");
                return false;
            }

            if (DoActions(QueueManagerEventDefine.PausetQueueBefore, sender) == false) return false;

            lineupInfo.排队状态 = LineUpState.qsPaused;
            lineupInfo.附加信息.CopyBasePro(lineupInfo);

            QueueModel.UpdateLineupInfo(lineupInfo);

            SetCurInfo(lineupInfo);

            if (chkAllState.Checked == false)
            {
                listQueue.SelectedItems[0].Remove();
            }
            else
            {
                listQueue.SelectedItems[0].SubItems[4].Text = QueueHelper.GetLineupStateCaption(LineUpState.qsPaused);
            }

            SyncListCount();

            DoActions(QueueManagerEventDefine.PausetQueueAfter, sender);

            return true;
        }

        /// <summary>
        /// 放弃呼叫
        /// </summary>
        /// <returns></returns>
        private bool Action_AbandonQueue(object sender)
        {
            QueueData queData = GetSelQueue();

            if (queData == null) return false;


            if (listQueue.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择需要弃呼的排队信息。", "提示");
                return false;
            }

            LineUpData lineupInfo = listQueue.SelectedItems[0].Tag as LineUpData;
            if (lineupInfo == null)
            {
                MessageBox.Show("未获取到有效的排队信息，请刷新后重试。", "提示");
                return false;
            }

            LineUpData lineupNew = _qm.GetLineupInfo(lineupInfo.排队ID);
            if (lineupInfo.附加信息.最后更新日期 != lineupNew.附加信息.最后更新日期)
            {
                MessageBox.Show("当前状态已改变，请刷新后重试。", "提示");
                return false;
            }

            if (DoActions(QueueManagerEventDefine.AbandonQueueBefore, sender) == false) return false;

            lineupInfo.排队状态 = LineUpState.qsAbandoned;
            lineupInfo.附加信息.CopyBasePro(lineupInfo);

            QueueModel.UpdateLineupInfo(lineupInfo);

            SetCurInfo(lineupInfo);

            if (chkAllState.Checked == false)
            {
                listQueue.SelectedItems[0].Remove();
            }
            else
            {
                listQueue.SelectedItems[0].SubItems[4].Text = QueueHelper.GetLineupStateCaption(LineUpState.qsAbandoned);
            }

            SyncListCount();

            DoActions(QueueManagerEventDefine.AbandonQueueAfter, sender);

            return true;
        }

        /// <summary>
        /// 接诊
        /// </summary>
        /// <returns></returns>
        private bool Action_ReceptQueue(object sender)
        {
            QueueData queData = GetSelQueue();

            if (queData == null) return false;


            if (_activeList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择需要接诊的排队信息。", "提示");
                return false;
            }

            LineUpData lineupInfo = _activeList.SelectedItems[0].Tag as LineUpData;
            if (lineupInfo == null)
            {
                MessageBox.Show("未获取到有效的排队信息，请刷新后重试。", "提示");
                return false;
            }

            LineUpData lineupNew = _qm.GetLineupInfo(lineupInfo.排队ID);
            if (lineupInfo.附加信息.最后更新日期 != lineupNew.附加信息.最后更新日期)
            {
                MessageBox.Show("当前状态已改变，请刷新后重试。", "提示");
                return false;
            }

            if (lineupInfo.排队状态 <= LineUpState.qsQueueing || lineupInfo.排队状态 >= LineUpState.qsRecepting)
            {
                DialogResult dr = MessageBox.Show("当前排队尚未处于呼叫状态，是否继续接诊？", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return false;
            }


            if (DoActions(QueueManagerEventDefine.ReceptQueueBefore, sender) == false) return false;

            lineupInfo.排队状态 = LineUpState.qsRecepting;
            lineupInfo.附加信息.CopyBasePro(lineupInfo);

            QueueModel.UpdateLineupInfo(lineupInfo);

            SetCurInfo(lineupInfo);

            if (_activeList == listQueue)
            {
                RebindData(queData.队列ID, _selDate);
            }
            else
            {
                listCall.SelectedItems[0].SubItems[4].Text = QueueHelper.GetLineupStateCaption(lineupInfo.排队状态);
            }

            SyncListCount();

            DoActions(QueueManagerEventDefine.ReceptQueueAfter, sender);

            return true;
        }
        
        /// <summary>
        /// 完成接诊
        /// </summary>
        /// <returns></returns>
        private bool Action_FinishQueue()
        {
            QueueData queData = GetSelQueue();

            if (queData == null) return false;


            if (_activeList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择需要完成的排队信息。", "提示");
                return false;
            }

            LineUpData lineupInfo = _activeList.SelectedItems[0].Tag as LineUpData;
            if (lineupInfo == null)
            {
                MessageBox.Show("未获取到有效的排队信息，请刷新后重试。", "提示");
                return false;
            }

            LineUpData lineupNew = _qm.GetLineupInfo(lineupInfo.排队ID);
            if (lineupInfo.附加信息.最后更新日期 != lineupNew.附加信息.最后更新日期)
            {
                MessageBox.Show("当前状态已改变，请刷新后重试。", "提示");
                return false;
            }

            if (lineupInfo.排队状态 == LineUpState.qsRecepting)
            {
                DialogResult dr = MessageBox.Show("当前排队尚未处于接诊状态，是否继续完成？", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return false;
            }

            lineupInfo.排队状态 = LineUpState.qsRecepted;
            lineupInfo.附加信息.CopyBasePro(lineupInfo);

            QueueModel.UpdateLineupInfo(lineupInfo);

            listQueue.SelectedItems[0].Remove();

            return true;
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="applyId"></param>
        private void Action_IntoQueue(string applyId, object sender)
        {
            if (DoActions(QueueManagerEventDefine.IntoQueueBefore, sender) == false ) return;

            frmIntoQueue intoQueue = new frmIntoQueue();
            LineUpData lineupInfo = intoQueue.ShowIntoQueue(QueueModel, _stationInfo, applyId, this);

            if (lineupInfo == null) return;
            if (tsCbxQueue.Items.Count <= 0) return;
            if (lineupInfo.队列名称 != tsCbxQueue.Text) return;

            ListViewItem lviQueue = new ListViewItem(new string[] { lineupInfo.号码前缀 + lineupInfo.排队号码,
                                                                    lineupInfo.患者姓名,
                                                                    lineupInfo.附加信息.性别,
                                                                    lineupInfo.附加信息.年龄,
                                                                    QueueHelper.GetLineupStateCaption(lineupInfo.排队状态),
                                                                    lineupInfo.附加信息.备注}, 0);

            lviQueue.Tag = lineupInfo;

            listQueue.Items.Add(lviQueue);


            DoActions(QueueManagerEventDefine.IntoQueueAfter, sender);
        }

        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {

                switch (actName)
                {
                    case QueueManagerActionDefine.IntoQueue:
                        //入队
                        string applyId = DataHelper.GetItemValueByApplyId(bizDatas[0]);

                        if (string.IsNullOrEmpty(applyId)) return false;

                        Action_IntoQueue(applyId, null);

                        
                        return true;

                    case QueueManagerActionDefine.Refresh://刷新

                        QueueData queData = GetSelQueue();

                        if (queData == null) return false;

                        Action_RefreshQueue(sender, queData.队列ID, _selDate);

                        return true;

                    case QueueManagerActionDefine.Abandon://弃呼
                        
                        return Action_AbandonQueue(null);

                    case QueueManagerActionDefine.DirectCall://直呼

                        return Action_DirectCall(null);

                    case QueueManagerActionDefine.OrderCall: //顺呼

                        return Action_OrderCall(null);

                    case QueueManagerActionDefine.Find: //查找

                        return Action_FindQueue(null);

                    case QueueManagerActionDefine.Pause: //暂停

                        return Action_PauseQueue(null);

                    case QueueManagerActionDefine.Recept: //接诊

                        return Action_ReceptQueue(null);

                    case QueueManagerActionDefine.InsertQueue://插队

                        return Action_InsertQueue(null);

                    case QueueManagerActionDefine.ReQueue: //重排

                        return Action_ResetQueue(null);

                    case QueueManagerActionDefine.Restore: //恢复

                        return Action_RestoreToQueueing(null);

                    case QueueManagerActionDefine.Modify: //修改

                        return Action_ModifyQueue(null);

                    case QueueManagerActionDefine.ChangeQueue://切换队列
                        if (bizDatas == null) return false;

                        string queueName = DataHelper.GetItemValueByQueueName(bizDatas[0]);

                        return Action_ChangeQueue(queueName, null);

                    case QueueManagerActionDefine.Print://打号
                        //TODO:打号
                        return false;

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

        /// <summary>
        /// 切换队列
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        private bool Action_ChangeQueue(string queueName, object sender)
        {
            //if (DoActions(QueueEventDefine.ChangeQueueBefore, sender) == false) return false;

            int index = tsCbxQueue.FindString(queueName);
            if (index < 0)
            {
                MessageBox.Show("未加载此队列信息。", "提示");
                return false;
            }

            tsCbxQueue.SelectedIndex = index;

            //DoActions(QueueEventDefine.ChangeQueueAfter, sender);

            return true;
        }

        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case QueueManagerDataDefine.SelQueueData:
                    return true;

                case QueueManagerDataDefine.SelLineupData:
                    return true;

                case QueueManagerDataDefine.CurLineupData:
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
                case QueueManagerDataDefine.SelQueueData://获取选中的队列信息

                    if (tsCbxQueue.SelectedItem == null) return null;

                    QueueData queData = (tsCbxQueue.SelectedItem as ItemBind).Tag as QueueData;

                    if (queData == null) return null;

                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();
                     
                    dataItem.Add(DataHelper.StdPar_QueueId, queData.队列ID);
                    dataItem.Add(DataHelper.StdPar_QueueName, queData.队列名称);

                    resultDatas.Add(dataItem);

                    return resultDatas;


                case QueueManagerDataDefine.SelLineupData://获取选中的排队信息
                    if (_activeList == null) return null;

                    if (_activeList.SelectedItems.Count <= 0) return null;      

                    LineUpData selLineup = _activeList.SelectedItems[0].Tag as LineUpData;

                    if (selLineup == null) return null;
                    
                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_LineupId, selLineup.排队ID);

                    dataItem.Add(DataHelper.StdPar_QueueId, selLineup.队列ID);
                    dataItem.Add(DataHelper.StdPar_QueueName, selLineup.队列名称);

                    dataItem.Add(DataHelper.StdPar_ApplyId, selLineup.申请ID);
                    dataItem.Add(DataHelper.StdPar_PatientId, selLineup.患者ID);
                    dataItem.Add(DataHelper.StdPar_PatiName, selLineup.患者姓名);

                    resultDatas.Add(dataItem);

                    return resultDatas;


                case QueueManagerDataDefine.CurLineupData://当前操作的排队信息
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

        private QueueConfig _qc = null;
        public override void ModuleLoaded()
        {
            try
            {
                InitLocalQueue();

                if (tsCbxQueue.Items.Count <= 0) return;
                //读取上次选择的队列
                _qc = QueueConfig.GetConfig(_moduleName);

                if (string.IsNullOrEmpty(_qc.DefaultQueueName) == false)
                {
                    tsCbxQueue.Text = _qc.DefaultQueueName;
                }
                else
                {
                    tsCbxQueue.SelectedIndex = 0;
                }

                ////加载排队数据
                //QueueData queData = (tsCbxQueue.SelectedItem as ItemBind).Tag as QueueData;

                //RebindData(queData.队列ID, _selDate);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }


        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _queueDesign = JsonHelper.DeserializeObject<QueueModuleDesign>(customContext);

            LoadDesign();
        }

        private void LoadDesign()
        {
            if (_queueDesign.ToolsDesign.Visible == false)
            {
                toolStripEx1.Visible = false;
                return;
            }

            toolStripEx1.Visible = true;

 
            toolStripEx1.BackColor = _queueDesign.ToolsDesign.BackColor;
            toolStripEx1.ForeColor = _queueDesign.ToolsDesign.ForceColor;

            tsbOrderCall.Visible = _queueDesign.ButOrderCallVisible;
            tsmDirectCall.Visible = _queueDesign.ButDirectCallVisible;
            tsmInsert.Visible = _queueDesign.ButInsertQueueVisible;
            tsmReQueue.Visible = _queueDesign.ButResetQueueVisible;
            tsmPause.Visible = _queueDesign.ButPauseQueueVisible;
            tsmAbandon.Visible = _queueDesign.ButAbandonQueueVisible;
            tsbRecept.Visible = _queueDesign.ButReceptQueueVisible;
            tsbRestore.Visible = _queueDesign.ButRestoreQueueVisible;
            tsbPrint.Visible = _queueDesign.ButPrintQueueVisible;
            tsbRefresh.Visible = _queueDesign.ButRefreshQueueVisible;
            tsmModify.Visible = _queueDesign.ButModifyQueueVisible;
            tsmFind.Visible = _queueDesign.ButFindQueueVisible; 

            if (_queueDesign.ButModifyQueueVisible == false 
                && _queueDesign.ButFindQueueVisible == false)
            {
                tsbMore.Visible = false;
            }
            else
            {
                tsbMore.Visible = true;

            }

            if (_queueDesign.ToolsDesign.ToolsCfg != null)
            {
                InitUserTool(_queueDesign.ToolsDesign);
            }


            ToolsHelper.SyncDesignEventsByButtons(_queueDesign.ToolsDesign, _designEvents);
        }

        private void InitUserTool(ToolsDesign toolDesign)
        {
            try
            {
                for (int i = toolStripEx1.Items.Count - 1; i >= 0; i--)
                {
                    //先移除用户控件
                    if (toolStripEx1.Items[i].Tag == null) continue;
                    toolStripEx1.Items.RemoveAt(i);
                }

                if (toolDesign.ToolsCfg.Count <= 0)
                {
                    if (toolStripEx1.Items.Count <= 0) toolStripEx1.Visible = false;

                    return;
                }

                ToolsHelper.ConfigButtons(toolStripEx1, toolDesign, DoUserToolEvent_StripItem);

                if (this.DesignMode == false)
                {
                    toolStripEx1.Visible = (toolStripEx1.Items.Count <= 0) ? false : true;
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        public override string ShowCustomDesign()
        {
            using (frmQueueDesign design = new frmQueueDesign())
            {
                design.ShowQueueDesign(_queueDesign, _stationInfo, _dbQuery, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_queueDesign);

            LoadDesign();

            return _customDesignFmt;
        }

        private void DoUserToolEvent_StripItem(object sender, EventArgs e)
        {
            ToolStripItem tsi = (sender as ToolStripItem);
            if (tsi == null) return;

            DoActions(tsi.Text, sender);
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

        private void BindLinuupInfo(string queueId, bool isQueueing, DateTime dtQueue = default(DateTime))
        {
            listQueue.Items.Clear();

            DataTable dtLineupInfos = QueueModel.GetLineupInfos(queueId, isQueueing, dtQueue);

            foreach(DataRow dr in dtLineupInfos.Rows)
            {
                LineUpData lineupData = new LineUpData();
                lineupData.BindRowData(dr);

                ListViewItem lvi = new ListViewItem(new string[] { lineupData.号码前缀 + lineupData.排队号码,
                                                                    lineupData.患者姓名,
                                                                    lineupData.附加信息.性别,
                                                                    lineupData.附加信息.年龄,
                                                                    QueueHelper.GetLineupStateCaption(lineupData.排队状态),
                                                                    lineupData.附加信息.备注}, 0);

                lvi.Name = lineupData.排队ID;
                lvi.Tag = lineupData;

                listQueue.Items.Add(lvi);
            }

            listQueue.View = View.Details;
        }

        private void BindCalledInfo(string queueId)
        {
            listCall.Items.Clear();

            DataTable dtLineupInfos = QueueModel.GeCalledInfos(queueId);

            foreach (DataRow dr in dtLineupInfos.Rows)
            {
                LineUpData lineupData = new LineUpData();
                lineupData.BindRowData(dr);

                //如果设置了对应检查房间，则只显示本房间呼叫的信息
                if (string.IsNullOrEmpty(_stationInfo.RoomName) == false && lineupData.附加信息.检查房间 != _stationInfo.RoomName) continue;
                                                
                ListViewItem lvi = new ListViewItem(new string[] { lineupData.号码前缀 + lineupData.排队号码,
                                                                    lineupData.患者姓名,
                                                                    lineupData.附加信息.性别,
                                                                    lineupData.附加信息.年龄,
                                                                    QueueHelper.GetLineupStateCaption(lineupData.排队状态),
                                                                    lineupData.附加信息.备注}, 1);

                lvi.Name = lineupData.排队ID;
                lvi.Tag = lineupData;

                listCall.Items.Add(lvi);

            }

            listCall.View = View.Details;
        }


        private void InitQueueList()
        {
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "排队号码";
            columnHeader.Name = "排队号码";
            columnHeader.Width = 80;
            listQueue.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "患者姓名";
            columnHeader.Name = "患者姓名";
            columnHeader.Width = 100;
            listQueue.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "性别";
            columnHeader.Name = "性别";
            columnHeader.Width = 40;
            listQueue.Columns.Add(columnHeader);
            
            columnHeader = new ColumnHeader();
            columnHeader.Text = "年龄";
            columnHeader.Name = "年龄";
            columnHeader.Width = 40;
            listQueue.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "状态";
            columnHeader.Name = "状态";
            columnHeader.Width = 60;
            listQueue.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "备注";
            columnHeader.Name = "备注";
            columnHeader.Width = 200;
            listQueue.Columns.Add(columnHeader);

            listQueue.View = View.Details;
        }


        private void InitCallList()
        {
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "排队号码";
            columnHeader.Name = "排队号码";
            columnHeader.Width = 80;
            listCall.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "患者姓名";
            columnHeader.Name = "患者姓名";
            columnHeader.Width = 100;
            listCall.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "性别";
            columnHeader.Name = "性别";
            columnHeader.Width = 40;
            listCall.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "年龄";
            columnHeader.Name = "年龄";
            columnHeader.Width = 40;
            listCall.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "状态";
            columnHeader.Name = "状态";
            columnHeader.Width = 60;
            listCall.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "备注";
            columnHeader.Name = "备注";
            columnHeader.Width = 200;
            listCall.Columns.Add(columnHeader);

            listCall.View = View.Details;
        }

        private void InitLocalQueue()
        {
            //如果设置了房间，则显示房间对应的排队队列
            //如果没有设置房间，则显示该科室下的所有队列

            DataTable dtQueues = QueueModel.GetQueueInfoByDeptId(_stationInfo.DepartmentId);

            tsCbxQueue.ComboBox.DisplayMember = "Name";
            tsCbxQueue.ComboBox.ValueMember = "Value";

            foreach (DataRow dr in dtQueues.Rows)
            {
                QueueData queData = new QueueData();
                queData.BindRowData(dr);

                if (string.IsNullOrEmpty(_stationInfo.RoomId) == false)
                {
                    //如果设置了房间，则只显示房间对应的队列
                    if (queData.包含房间.房间明细.FindIndex(T => T.房间ID == _stationInfo.RoomId) < 0) continue;
                }

                ItemBind ib = new ItemBind();

                ib.Name = queData.队列名称;
                ib.Value = queData.队列ID;

                ib.Tag = queData;

                tsCbxQueue.Items.Add(ib);
            }
        }

 
        /// <summary>
        /// 刷新
        /// </summary>
        public override void RefreshModule()
        {

        }

        //private bool _isLoad = false;
        private void QueueControl_Load(object sender, EventArgs e)
        {
            try
            {
                //_isLoad = true;

                _activeList = listQueue;

                dateTimePicker1.Value = DateTime.Now.Date;

                ToolStripControlHost tch = new ToolStripControlHost(dateTimePicker1);
                toolStripEx2.Items.Insert(2, tch);

                InitQueueList();
                InitCallList();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isLoaded = false;
            }
        }

        private QueueData GetSelQueue()
        {
            if (tsCbxQueue.Items.Count <= 0)
            {
                MessageBox.Show("尚无队列信息，不能执行此操作。", "提示");
                return null;
            }

            QueueData queData = (tsCbxQueue.SelectedItem as ItemBind).Tag as QueueData;

            if (queData == null)
            {
                MessageBox.Show("队列信息无效，不能执行此操作。", "提示");
                return null;
            }

            return queData;
        }

        /// <summary>
        /// 直呼
        /// </summary>
        private bool Action_DirectCall(object sender)
        {
            QueueData queData = GetSelQueue();
            if (queData == null) return false;


            if (_activeList == null)
            {
                MessageBox.Show("请选择需要直呼的排队信息。", "提示");
                return false;
            }

            if (_activeList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择需要直呼的排队信息。", "提示");
                return false;
            }
            
            if (string.IsNullOrEmpty(_stationInfo.RoomId))
            {
                MessageBox.Show("尚未配置检查房间，不能执行此操作。", "提示");
                return false;
            }

            if (string.IsNullOrEmpty(queData.队列信息.呼叫格式))
            {
                MessageBox.Show("队列呼叫内容格式尚未配置，不能执行此操作。", "提示");
                return false;
            }

            LineUpData lineupCall = _activeList.SelectedItems[0].Tag as LineUpData;

            if (lineupCall == null)
            {
                MessageBox.Show("未获取到需要呼叫的排队信息。", "提示");
                return false;
            }

            //验证当前状态
            LineUpData lineupNew = _qm.GetLineupInfo(lineupCall.排队ID);
            if (lineupNew.附加信息.最后更新日期 != lineupCall.附加信息.最后更新日期)
            {
                MessageBox.Show("当前状态已改变，请刷新后重试。", "提示");
                return false;
            }

            if (DoActions(QueueManagerEventDefine.DirectCallBefore, sender) == false) return false;

            DoLineupCall(lineupNew, queData);

            SetCurInfo(lineupNew);

            if (_activeList == listQueue)
            {
                SyncCallList(lineupNew);

                if (chkAllState.Checked == false)
                {
                    _activeList.SelectedItems[0].Remove();
                }
                else
                {
                    _activeList.SelectedItems[0].SubItems[4].Text = QueueHelper.GetLineupStateCaption(LineUpState.qsWaitCall);
                }
            }

            SyncListCount();

            DoActions(QueueManagerEventDefine.DirectCallAfter, sender);

            return true;
        }

        /// <summary>
        /// 顺呼
        /// </summary>
        private bool Action_OrderCall(object sender)
        {            
            QueueData queData = GetSelQueue();

            if (queData == null) return false;


            if (listQueue.Items.Count <= 0)
            {
                MessageBox.Show("当前队列尚无排队信息，请刷新后重试。", "提示");
                return false;
            }

            if (string.IsNullOrEmpty(_stationInfo.RoomId))
            {
                MessageBox.Show("尚未配置检查房间，不能执行此操作。", "提示");
                return false;
            }

            if (string.IsNullOrEmpty(queData.队列信息.呼叫格式))
            {
                MessageBox.Show("队列呼叫内容格式尚未配置，不能执行此操作。", "提示");
                return false;
            }

            LineUpData lineupCall = _qm.GetOrderCallLineup(queData.队列ID);

            if (lineupCall == null)
            {
                MessageBox.Show("未获取到需要呼叫的排队信息。", "提示");
                RebindData(queData.队列ID, _selDate);
                return false; 
            }

            ListViewItem[] lvis = listQueue.Items.Find(lineupCall.排队ID, false); 

            if (lvis.Length <= 0)
            {
                RebindData(queData.队列ID, _selDate);
                DialogResult dRes = MessageBox.Show("排队信息已更新，是否继续对 [" + lineupCall.号码前缀 + lineupCall.排队号码 + "号 " + lineupCall.患者姓名 + "] 呼叫。", "提示", MessageBoxButtons.YesNo);

                if (dRes == DialogResult.No) return false;

                lvis = listQueue.Items.Find(lineupCall.排队ID, false);
            } 

            if (lvis.Length <= 0)
            {
                MessageBox.Show("未提取到待呼叫 [" + lineupCall.号码前缀 + lineupCall.排队号码 + "号 " + lineupCall.患者姓名 + "] 的排队信息", "提示");
                return false;
            }

            if (DoActions(QueueManagerEventDefine.OrderCallBefore, sender) == false) return false ;

            DoLineupCall(lineupCall, queData);

            SetCurInfo(lineupCall);

            SyncCallList(lineupCall);

            if (chkAllState.Checked == false)
            {
                listQueue.Items.RemoveAt(0);
            }
            else
            {
                lvis[0].Selected = true;
                lvis[0].SubItems[4].Text = QueueHelper.GetLineupStateCaption(LineUpState.qsWaitCall);
            }

            SyncListCount();

            DoActions(QueueManagerEventDefine.OrderCallAfter, sender);

            return true;
        }

        /// <summary>
        /// 同步呼叫列表显示
        /// </summary>
        /// <param name="lineupInfo"></param>
        private void SyncCallList(LineUpData lineupInfo)
        {
            ListViewItem lviCall = new ListViewItem(new string[] { lineupInfo.号码前缀 + lineupInfo.排队号码,
                                                                    lineupInfo.患者姓名,
                                                                    lineupInfo.附加信息.性别,
                                                                    lineupInfo.附加信息.年龄,
                                                                    QueueHelper.GetLineupStateCaption(lineupInfo.排队状态),
                                                                    lineupInfo.附加信息.备注}, 1);

            lviCall.Tag = lineupInfo;

            listCall.Items.Add(lviCall);
        }

        private void SyncQueueList(LineUpData lineupInfo)
        {
            ListViewItem lviQueue = new ListViewItem(new string[] { lineupInfo.号码前缀 + lineupInfo.排队号码,
                                                                    lineupInfo.患者姓名,
                                                                    lineupInfo.附加信息.性别,
                                                                    lineupInfo.附加信息.年龄,
                                                                    QueueHelper.GetLineupStateCaption(lineupInfo.排队状态),
                                                                    lineupInfo.附加信息.备注}, 0);

            lviQueue.Tag = lineupInfo;

            listQueue.Items.Add(lviQueue);
        }




        /// <summary>
        /// 执行呼叫
        /// </summary>
        /// <param name="lineupInfo"></param>
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
            catch(Exception ex)
            {
                _qm.TransactionRollback();

                throw ex;
            }
        }

        private void RebindData(string queueId, DateTime dtQueue = default(DateTime))
        {
            BindLinuupInfo(queueId, !chkAllState.Checked, dtQueue);

            BindCalledInfo(queueId);

            SyncListCount();
        }

        private void SyncListCount()
        {
            labQueueTitle.Text = "排队列表：" + listQueue.Items.Count;
            labCallTitle.Text = "呼叫列表：" + listCall.Items.Count;
        }


        private bool Action_RefreshQueue(object sender, string queueId,  DateTime dtQueue = default(DateTime))
        {
            if (DoActions(QueueManagerEventDefine.RefreshQueueBefore, sender) == false) return false;
            
            RebindData(queueId, dtQueue);

            DoActions(QueueManagerEventDefine.RefreshQueueAfter, sender);

            return true;
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                QueueData queData = GetSelQueue();

                if (queData == null) return;

                Action_RefreshQueue(sender, queData.队列ID, _selDate);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbOrderCall_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                Action_OrderCall(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private ListView _activeList = null;
        private bool Action_RestoreToQueueing(object sender)
        {
            if (_activeList == null)
            {
                MessageBox.Show("请选择需要恢复的排队信息。", "提示");
                return false;
            }

            if (_activeList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择需要恢复的排队信息。", "提示");
                return false;
            }
            

            LineUpData lineupQueue = _activeList.SelectedItems[0].Tag as LineUpData;

            if (lineupQueue == null)
            {
                MessageBox.Show("未获取到需要附加的排队信息。", "提示");
                return false;
            }

            if (lineupQueue.排队状态 == LineUpState.qsQueueing)
            {
                MessageBox.Show("当前项目正处于排队状态，无需恢复排队。", "提示");
                return false;
            }

            if (lineupQueue.排队日期 != _qm.GetServerDate().Date)
            {
                DialogResult dr = MessageBox.Show("排队日期为 [" + lineupQueue.排队日期.ToString("yyyy-MM-dd") + "] 与当前日期不同，是否继续？", "提示");
                if (dr == DialogResult.No) return false;
            }

            if (DoActions(QueueManagerEventDefine.RestoreQueueBefore, sender) == false) return false;

            lineupQueue.排队状态 = LineUpState.qsQueueing;
            lineupQueue.附加信息.排队状态 = LineUpState.qsQueueing;
            

            _qm.DelCallInfoByLineupId(lineupQueue.排队ID);
            _qm.UpdateLineupInfo(lineupQueue);

            SetCurInfo(lineupQueue);
            //UpdateListItemInfo(_activeList.SelectedItems[0], lineupQueue);

            //if (_activeList == listCall)
            //{
            //    SyncQueueList(lineupQueue);

            //    listCall.Items.Remove(_activeList.SelectedItems[0]);
            //}

            DoActions(QueueManagerEventDefine.ResetQueueAfter, sender);

            return true;

        }

        private void tsbRestore_Click(object sender, EventArgs e)
        {
            try
            {
                QueueData queData = GetSelQueue();
                if (queData == null) return;

                Action_RestoreToQueueing(sender);

                RebindData(queData.队列ID, _selDate);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listCall_Enter(object sender, EventArgs e)
        {
            try
            {
                _activeList = listCall;

                panel1.BackColor = SystemColors.Control;
                labQueueTitle.BackColor = SystemColors.Control;
                labCallTitle.BackColor = Color.FromArgb(192, 192, 255);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listQueue_Enter(object sender, EventArgs e)
        {
            try
            {
                _activeList = listQueue;

                panel1.BackColor = Color.FromArgb(192, 192, 255);
                labQueueTitle.BackColor = Color.FromArgb(192, 192, 255);
                labCallTitle.BackColor = SystemColors.Control; 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsCbxQueue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                QueueData queData = GetSelQueue();
                if (queData == null) return;

                if (DoActions(QueueManagerEventDefine.ChangeQueueBefore, sender) == false) return;

                RebindData(queData.队列ID, _selDate);

                DoActions(QueueManagerEventDefine.ChangeQueueAfter, sender);

                if (_qc == null)
                {
                    _qc = QueueConfig.GetConfig(_moduleName);

                    _qc.DefaultQueueName = tsCbxQueue.Text;                    
                }

                QueueConfig.SetConfig(_qc, _moduleName);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsmDirectCall_Click(object sender, EventArgs e)
        {
            try
            {
                Action_DirectCall(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsmInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Action_InsertQueue(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsmReQueue_Click(object sender, EventArgs e)
        {
            try
            {
                Action_ResetQueue(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsmPause_Click(object sender, EventArgs e)
        {
            try
            {
                Action_PauseQueue(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsmAbandon_Click(object sender, EventArgs e)
        {
            try
            {
                Action_AbandonQueue(sender);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbRecept_Click(object sender, EventArgs e)
        {
            try
            {
                Action_ReceptQueue(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _selDate = dateTimePicker1.Value.Date;

                if (_isLoaded) return;

                QueueData queData = GetSelQueue();
                if (queData == null) return;

                RebindData(queData.队列ID, _selDate);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 查找排队
        /// </summary>
        /// <returns></returns>
        private bool Action_FindQueue(object sender)
        {

            if (DoActions(QueueManagerEventDefine.FindQueueBefore, sender) == false) return false;

            using (frmFindQueue findQueue = new frmFindQueue())
            {
                DataTable dtFinds = null;
                if (findQueue.ShowFindQueue(QueueModel, _stationInfo.DepartmentId, this, out dtFinds))
                {
                    listQueue.Items.Clear();

                    foreach (DataRow dr in dtFinds.Rows)
                    {
                        LineUpData lineupData = new LineUpData();
                        lineupData.BindRowData(dr);

                        ListViewItem lvi = new ListViewItem(new string[] { lineupData.号码前缀 + lineupData.排队号码,
                                                                    lineupData.患者姓名,
                                                                    lineupData.附加信息.性别,
                                                                    lineupData.附加信息.年龄,
                                                                    QueueHelper.GetLineupStateCaption(lineupData.排队状态),
                                                                    "(" + lineupData.队列名称 + ")" + lineupData.附加信息.备注}, 0);

                        lvi.Tag = lineupData;

                        listQueue.Items.Add(lvi);
                    }

                    listQueue.View = View.Details;

                    DoActions(QueueManagerEventDefine.FindQueueAfter, sender);

                    SyncListCount();

                    return true;
                }

                return false;
            }
        }

        private void tsmFind_Click(object sender, EventArgs e)
        {
            try
            {
                Action_FindQueue(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }

        /// <summary>
        /// 修改排队
        /// </summary>
        /// <returns></returns>
        private bool Action_ModifyQueue(object sender)
        {
            QueueData queData = GetSelQueue();
            if (queData == null) return false;

            if (_activeList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择需要修改的排队信息。", "提示");
                return false;
            }

            LineUpData lineupInfo = _activeList.SelectedItems[0].Tag as LineUpData;
            if (lineupInfo == null)
            {
                MessageBox.Show("未获取到有效的排队信息，请刷新后重试。", "提示");
                return false;
            }

            LineUpData lineupNew = _qm.GetLineupInfo(lineupInfo.排队ID);
            if (lineupInfo.附加信息.最后更新日期 != lineupNew.附加信息.最后更新日期)
            {
                MessageBox.Show("当前状态已改变，请刷新后重试。", "提示");
                return false;
            }

            if (DoActions(QueueManagerEventDefine.ModifyQueueBefore, sender) == false) return false;

            using (frmModifyQueue modifyQueue = new frmModifyQueue())
            {
                if (modifyQueue.ShowModifyQueue(QueueModel, lineupInfo, this))
                {
                    SetCurInfo(lineupInfo);

                    UpdateListItemInfo(_activeList.SelectedItems[0], lineupInfo);

                    DoActions(QueueManagerEventDefine.ModifyQueueAfter, sender);

                    return true;
                }
            }
             
            return false;
        }

        private void UpdateListItemInfo(ListViewItem lvi, LineUpData lineupInfo)
        {
            lvi.SubItems[1].Text = lineupInfo.患者姓名;
            lvi.SubItems[2].Text = lineupInfo.附加信息.性别;
            lvi.SubItems[3].Text = lineupInfo.附加信息.年龄;
            lvi.SubItems[4].Text = QueueHelper.GetLineupStateCaption(lineupInfo.排队状态);
            lvi.SubItems[5].Text = lineupInfo.附加信息.备注;
        }

        private void tsmModify_Click(object sender, EventArgs e)
        {
            try
            {
                Action_ModifyQueue(sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void chkAllState_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                QueueData queData = GetSelQueue();
                if (queData == null) return;

                RebindData(queData.队列ID, _selDate);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO:打号
            }
            catch(Exception ex)
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

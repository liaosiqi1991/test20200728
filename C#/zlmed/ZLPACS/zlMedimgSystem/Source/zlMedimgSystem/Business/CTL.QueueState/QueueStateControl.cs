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

namespace zlMedimgSystem.CTL.QueueState
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(QueueStateControl), "Resources.queuestate.ico")]
    public partial class QueueStateControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class QueueStateActionDefine
        {
            public const string Refresh = "刷新";
        }

        static public class QueueStateDataDefine
        {
            public const string ClickQueue = "点击队列";
        }

        static public class QueuestateEventDefine
        {
            public const string QueueClick = "队列单击事件";
            public const string QueueDblClick = "队列双击事件";
        }



        private QueueModel _qm = null;
        private QueueStateModuleDesign _queueStateDesign = null;
        private List<QueueItem> _queueItems = null;

        private string _clickQueueId = "";
        private string _clickQueueName = "";
        
        public QueueStateControl()
        {
            InitializeComponent();

            _queueItems = new List<QueueItem>();

            _queueStateDesign = new QueueStateModuleDesign();
            _queueStateDesign.BackColor =Color.FromArgb(64,64,64);
            _queueStateDesign.ForeColor = Color.Black;
            _queueStateDesign.BusyColor = Color.FromArgb(255, 192, 192);
            _queueStateDesign.WorkColor = Color.FromArgb(255, 192, 128);
            _queueStateDesign.FreeColor = Color.FromArgb(192, 255, 192);
            _queueStateDesign.DefaultBusyCount = 0;
            _queueStateDesign.FontName = this.Font.Name;
            _queueStateDesign.FontSize = this.Font.Size;
            _queueStateDesign.FontBold = this.Font.Bold;
            _queueStateDesign.FontItalic = this.Font.Italic;
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
            _moduleName = "队列状态显示";

            _provideActionDesc.Add(QueueStateActionDefine.Refresh, "刷新队列排队状态信息。");

            _provideDataDesc.AddDataDescription(_moduleName, QueueStateDataDefine.ClickQueue, "返回当前点击(单击或双击)的队列信息，返回数据项如下：" 
                                                                                            + System.Environment.NewLine 
                                                                                            + "queueid,queuename");

            _designEvents.Add(QueuestateEventDefine.QueueClick, new EventActionReleation(QueuestateEventDefine.QueueClick, ActionType.atSysFixedEvent));
            _designEvents.Add(QueuestateEventDefine.QueueDblClick, new EventActionReleation(QueuestateEventDefine.QueueDblClick, ActionType.atSysFixedEvent));
        }


        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {

                switch (actName)
                {
                    case QueueStateActionDefine.Refresh:
                        BindQueueState();
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


        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case QueueStateDataDefine.ClickQueue:
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
                case QueueStateDataDefine.ClickQueue://当前采集的图像数据
                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_QueueId, _clickQueueId);
                    dataItem.Add(DataHelper.StdPar_QueueName, _clickQueueName); 

                    resultDatas.Add(dataItem);

                    return resultDatas; 

                default:
                    return null;
            }
        }

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _queueStateDesign = JsonHelper.DeserializeObject<QueueStateModuleDesign>(customContext);

            LoadDesign();

            BindQueueState();
        }


        private void LoadDesign()
        {
            this.BackColor = _queueStateDesign.BackColor;
            flowLayoutPanel1.BackColor = Color.Transparent;

            float fontSize = 0;
            FontStyle fs = FontStyle.Regular;

            try
            {
                fontSize = _queueStateDesign.FontSize;
            }
            catch { }
            if (fontSize <= 0) fontSize = this.Font.Size;

            if (_queueStateDesign.FontBold) fs = fs | FontStyle.Bold;
            if (_queueStateDesign.FontItalic) fs = fs | FontStyle.Italic;

            Font font = new Font(_queueStateDesign.FontName, fontSize, fs);

            this.Font = font;




            _queueItems.Clear();
            if (_queueStateDesign.QueueItems.Count > 0)
            {
                _queueItems = new List<QueueItem>(_queueStateDesign.QueueItems);
            }
            else
            {
                //查询科室包含的队列
                DataTable dtQueueData = QueueModel.GetQueueInfoByDeptId(_stationInfo.DepartmentId);

                if (_queueStateDesign.UseRoomQueueReleation && string.IsNullOrEmpty(_stationInfo.RoomId) == false)
                {
                    foreach (DataRow drQueue in dtQueueData.Rows)
                    {
                        QueueData queData = new QueueData();
                        queData.BindRowData(drQueue);

                        if (queData.包含房间.房间明细.FindIndex(T => T.房间ID == _stationInfo.RoomId) >= 0)
                        {
                            QueueItem qi = new QueueItem();

                            qi.QueueName = drQueue["队列名称"].ToString();
                            qi.QueueId = drQueue["队列ID"].ToString();
                            qi.BusyCount = _queueStateDesign.DefaultBusyCount;

                            _queueItems.Add(qi);
                        }
                    }
                }
                else
                {
                    foreach (DataRow drQueue in dtQueueData.Rows)
                    {
                        QueueItem qi = new QueueItem();

                        qi.QueueName = drQueue["队列名称"].ToString();
                        qi.QueueId = drQueue["队列ID"].ToString();
                        qi.BusyCount = _queueStateDesign.DefaultBusyCount;

                        _queueItems.Add(qi);
                    }
                }
            }

        }


        public override string ShowCustomDesign()
        {
            frmQueueStateModuleDesign design = new frmQueueStateModuleDesign();
            design.ShowQueueStateDesign(QueueModel, _stationInfo.DepartmentId, _queueStateDesign, this);

            _customDesignFmt = JsonHelper.SerializeObject(_queueStateDesign);

            LoadDesign();

            flowLayoutPanel1.Controls.Clear();

            BindQueueState();

            return _customDesignFmt;
        }

        private void BindQueueState()
        {            
            if (_queueItems.Count <= 0) return;

            DataTable dtQueueState = QueueModel.GetLineupCountByDepartmentId(_stationInfo.DepartmentId);
            if (dtQueueState == null || dtQueueState.Rows.Count <= 0)
            {
                flowLayoutPanel1.Controls.Clear();
                return;
            }


            if (flowLayoutPanel1.Controls.Count > 0)
            {
                foreach (Control lab in flowLayoutPanel1.Controls)
                {
                    Label labQueue = lab as Label;
                    if (labQueue == null) continue;

                    QueueItem qi = labQueue.Tag as QueueItem; 
                    
                    DataRow[] drQueue = dtQueueState.Select("队列ID='" + qi.QueueId + "'");

                    if (drQueue.Length <= 0)
                    {
                        labQueue.Text = "";
                        labQueue.BackColor = GetQueueStateColor(qi.QueueId, 0);

                        continue;
                    }

                    int count = Convert.ToInt32(drQueue[0]["数量"].ToString());

                    string context = drQueue[0]["队列名称"].ToString() + "\r----\r(" + count + ")人";
                    labQueue.Text = context;

                    labQueue.BackColor = GetQueueStateColor(qi.QueueId, count);
                }
            }
            else
            {
                foreach (DataRow drQueue in dtQueueState.Rows)
                {
                    Label labQueue = new Label();
                     
                    int count = Convert.ToInt32(drQueue["数量"].ToString());
                    string queueId = drQueue["队列ID"].ToString();

                    if (_queueItems.FindIndex(T => T.QueueId == queueId) < 0) continue;

                    QueueItem qi = new QueueItem();
                    qi.QueueId = queueId;
                    qi.QueueName = drQueue["队列名称"].ToString();

                    labQueue.Tag = qi;

                    string context = qi.QueueName + "\r----\r(" + count + ")人";
                    labQueue.Text = context;
                                        

                    labQueue.AutoSize = false;
                    labQueue.Size = new Size(65, 65);
                    labQueue.Font = this.Font;
                    labQueue.TextAlign = ContentAlignment.MiddleCenter;
                    labQueue.ForeColor = _queueStateDesign.ForeColor;
                    labQueue.Margin = new Padding(2);

                    labQueue.Click += LabClick;
                    labQueue.DoubleClick += LabDblClick;


                    labQueue.BackColor = GetQueueStateColor(qi.QueueId, count);

                    flowLayoutPanel1.Controls.Add(labQueue);
                }
            }
        }

        private void LabClick(object sender, EventArgs e)
        {
            //设置数据
            Label labQueue = sender as Label;

            QueueItem qi = labQueue.Tag as QueueItem;

            if (qi == null) return;

            _clickQueueId = qi.QueueId;
            _clickQueueName = qi.QueueName;

            DoActions(QueuestateEventDefine.QueueClick, sender);

        }

        private void LabDblClick(object sender, EventArgs e)
        {
            //设置数据
            Label labQueue = sender as Label;

            QueueItem qi = labQueue.Tag as QueueItem;

            if (qi == null) return;

            _clickQueueId = qi.QueueId;
            _clickQueueName = qi.QueueName;


            DoActions(QueuestateEventDefine.QueueDblClick, sender);
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

        private Color GetQueueStateColor(string queueId, int count)
        {
            int busyCount = _queueStateDesign.DefaultBusyCount;
            int index = _queueItems.FindIndex(T => T.QueueId == queueId);

            if (index >= 0)
            {
                busyCount = _queueItems[index].BusyCount;
                if (busyCount <= 0) busyCount = _queueStateDesign.DefaultBusyCount;
            }

            if (count >= busyCount && busyCount != 0) return _queueStateDesign.BusyColor;
            if (count <= 0) return _queueStateDesign.FreeColor;

            return _queueStateDesign.WorkColor;

        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            try
            {
                if (_queueStateDesign == null) return;

                if (_queueStateDesign.FixColumn <= 0 && _queueStateDesign.FixRow <= 0) return;

                int curRow = _queueStateDesign.FixRow;
                int curColumn = _queueStateDesign.FixColumn;

                if (curRow <= 0)
                {
                    curRow = _queueItems.Count / curColumn;
                }

                if (curColumn <= 0)
                {
                    curColumn = _queueItems.Count / curRow;
                }

                int width = (flowLayoutPanel1.ClientSize.Width) / curColumn - 4;
                int height = (flowLayoutPanel1.ClientSize.Height) / curRow - 4;

                foreach(Control ctlLab in flowLayoutPanel1.Controls)
                {
                    if (ctlLab is Label)
                    {
                        (ctlLab as Label).Width = width;
                        (ctlLab as Label).Height = height;
                    }
                }

            }
            catch { }
        }
    }
}

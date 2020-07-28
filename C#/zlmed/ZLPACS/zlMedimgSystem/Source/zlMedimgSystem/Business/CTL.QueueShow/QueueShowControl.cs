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
using System.IO;
using DevExpress.XtraEditors;

namespace zlMedimgSystem.CTL.QueueShow
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(QueueShowControl), "Resources.queueshow.ico")]
    public partial class QueueShowControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class QueueShowActionDefine
        {
            public const string Refresh = "刷新";
        }

        //private QueueShowConfig _queueShowConfig = null;
        private QueueShowModuleDesign _queueShowDesign = null;
        private List<QueueItem> _queueItems = null;

        private QueueModel _qm = null;
        public QueueShowControl()
        {
            InitializeComponent();

            _queueItems = new List<QueueItem>();

            _queueShowDesign = new QueueShowModuleDesign();

            _queueShowDesign.BackColor = this.BackColor;
            _queueShowDesign.ForeColor = this.ForeColor;

            _queueShowDesign.FontName = this.Font.Name;
            _queueShowDesign.FontSize = this.Font.Size;
            _queueShowDesign.IsBold = false;
            _queueShowDesign.IsItalic = false;

            _queueShowDesign.HeadFontName = this.Font.Name;
            _queueShowDesign.HeadFontSize = this.Font.Size;
            _queueShowDesign.HeadBold = false;
            _queueShowDesign.HeadItalic = false;

            _queueShowDesign.WaitCount = 5;

            _queueShowDesign.Column1Width = 200;
            _queueShowDesign.Column2Width = 200;
            _queueShowDesign.Column3Width = 200;

            _queueShowDesign.IsShowMemo = true;
            _queueShowDesign.IsShowLastCall = false;
            _queueShowDesign.IsShowCallIcon = true;
            _queueShowDesign.IsShowQueueIcon = false;

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
            _moduleName = "队列列表显示"; 

            _provideActionDesc.Add(QueueShowActionDefine.Refresh, "刷新排队状态信息。"); 

            //_designEvents.Add(QueueEventDefine.AbandonQueueAfter, new EventActionReleation(QueueEventDefine.AbandonQueueAfter, ActionType.atSysFixedEvent)); 
        }

        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {

                switch (actName)
                {
                    case QueueShowActionDefine.Refresh:
                        BindQueueListData(_queueItems);
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

        //public override void ModuleLoaded()
        //{
        //    base.ModuleLoaded();

        //    //_queueShowConfig = QueueShowConfig.GetConfig(_userData.Account, _moduleName);


        //}

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _queueShowDesign = JsonHelper.DeserializeObject<QueueShowModuleDesign>(customContext);

            LoadDesign();


        }

        protected override CreateParams CreateParams 
        {
            get
            {
                CreateParams paras = base.CreateParams;

                //使背景加载时不闪烁
                paras.ExStyle |= 0x02000000;
                return paras;
            }
        }

        private void LoadDesign()
        {
            this.ForeColor = _queueShowDesign.ForeColor;
            tableLayoutPanel1.ForeColor = _queueShowDesign.ForeColor;


            float fontSize = 0;

            try
            {
                fontSize = _queueShowDesign.FontSize;
            }
            catch { }
            if (fontSize <= 0) fontSize = this.Font.Size;

            FontStyle fs = FontStyle.Regular;

            if (_queueShowDesign.IsBold) fs = fs | FontStyle.Bold;
            if (_queueShowDesign.IsItalic) fs = fs | FontStyle.Italic;



            Font ft = new Font(_queueShowDesign.FontName, fontSize, fs);
            this.Font = ft;

            tableLayoutPanel1.Font = ft;


            _queueItems.Clear();
            if (_queueShowDesign.ReleationQueueItems.Count > 0)
            {
                _queueItems = new List<QueueItem>(_queueShowDesign.ReleationQueueItems);
            }
            else
            {
                //查询科室包含的队列
                DataTable dtQueueData = QueueModel.GetQueueInfoByDeptId(_stationInfo.DepartmentId);

                if (_queueShowDesign.UseRoomQueueReleation && string.IsNullOrEmpty(_stationInfo.RoomId) == false)
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

                        _queueItems.Add(qi);
                    }
                }
            }


            InitQueueLayout(_queueItems);
            
            BindQueueListData(_queueItems); 

        }


        public override string ShowCustomDesign()
        {
            using (frmQueueShowDesign design = new frmQueueShowDesign())
            {
                design.ShowQueueShowDesign(QueueModel, _stationInfo.DepartmentId, _queueShowDesign, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_queueShowDesign);

            LoadDesign();

            return _customDesignFmt;
        }

        private Dictionary<string, Label> _callList = null;
        private Dictionary<string, LabelControl> _waitList = null;
        //private Dictionary<string, Label> _missList = null;
        private void InitQueueLayout(List<QueueItem> queueItems)
        {
            tableLayoutPanel1.Controls.Clear();

            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.ColumnCount = (_queueShowDesign.IsShowLastCall) ? 3 : 2;

            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            if (string.IsNullOrEmpty(_queueShowDesign.BackgroundImage) == false)
            {
                tableLayoutPanel1.BackgroundImageLayout = ImageLayout.Stretch;

                //根据队列数量载入对应的背景图像
                FileInfo fi = new FileInfo(Dir.GetAppResourceDir() + @"\" + _queueShowDesign.BackgroundImage);

                string styleName = fi.Name.Replace(fi.Extension, "") + queueItems.Count + fi.Extension;
                string styleFile = fi.DirectoryName + @"\" + styleName;

                if (File.Exists(styleFile))
                {
                    tableLayoutPanel1.BackgroundImage = BigImgResource.LoadImg(styleName);
                }
                else
                {
                    tableLayoutPanel1.BackgroundImage = BigImgResource.LoadImg(_queueShowDesign.BackgroundImage);
                }
            }
            
            if (_callList == null) _callList = new Dictionary<string, Label>();
            if (_waitList == null) _waitList = new Dictionary<string, LabelControl>();
            //if (_missList == null) _missList = new Dictionary<string, Label>();

            _callList.Clear();
            _waitList.Clear();
            //_missList.Clear();

            if (queueItems == null || queueItems.Count <= 0) return;

            tableLayoutPanel1.RowCount = queueItems.Count;

            if (tableLayoutPanel1.ColumnCount >= 1 && _queueShowDesign.Column1Width > 0)
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _queueShowDesign.Column1Width));

            if (tableLayoutPanel1.ColumnCount >= 2 && _queueShowDesign.Column2Width > 0)
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _queueShowDesign.Column2Width)); 

            if (tableLayoutPanel1.ColumnCount >= 3 && _queueShowDesign.Column3Width > 0) 
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _queueShowDesign.Column3Width)); 


            float fontSize = 0;

            try
            {
                fontSize = _queueShowDesign.HeadFontSize;
            }
            catch { }
            if (fontSize <= 0) fontSize = this.Font.Size;

            FontStyle fs = FontStyle.Regular;

            if (_queueShowDesign.HeadBold) fs = fs | FontStyle.Bold;
            if (_queueShowDesign.HeadItalic) fs = fs | FontStyle.Italic;
                       
            Font headFont = new Font(_queueShowDesign.HeadFontName, fontSize, fs);

            int colIndex = 0;
            for (int i = 0; i < queueItems.Count; i ++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, this.Height / queueItems.Count));

                string queueName = queueItems[i].QueueName;


                colIndex = 0;
                //添加行头文本
                Label lab = new Label();

                lab.BackColor = Color.Transparent;
                lab.TextAlign = ContentAlignment.MiddleLeft;
                lab.Text = "(" + (i + 1) + ")" + queueName;
                lab.Tag = queueName;
                lab.AutoSize = false;
                lab.Dock = DockStyle.Fill;

                lab.ForeColor = _queueShowDesign.ForeColor;
                lab.Font = headFont;

                
                tableLayoutPanel1.Controls.Add(lab, colIndex, i);

                ////添加呼叫状态文本
                if (_queueShowDesign.IsShowLastCall)
                {
                    colIndex = colIndex + 1;
                    Label labCall = new Label();

                    labCall.BackColor = Color.Transparent;
                    labCall.TextAlign = ContentAlignment.MiddleLeft;
                    labCall.Tag = queueName;
                    labCall.AutoSize = false;
                    labCall.Dock = DockStyle.Fill;

                    if (_queueShowDesign.IsShowCallIcon)
                    {
                        labCall.Image = Properties.Resources.calling;
                        labCall.ImageAlign = ContentAlignment.MiddleLeft;
                    }

                    labCall.ForeColor = _queueShowDesign.ForeColor;
                    labCall.Font = this.Font;

                    tableLayoutPanel1.Controls.Add(labCall, colIndex, i);

                    _callList.Add(queueName, labCall);
                }

                colIndex = colIndex + 1;
                //添加排队状态文本
                LabelControl labWait = new LabelControl();

                labWait.BackColor = Color.Transparent;
                labWait.AutoSizeMode = LabelAutoSizeMode.None;
                labWait.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                labWait.Tag = queueName;
                labWait.AutoSize = false;
                labWait.Dock = DockStyle.Fill;
         
                if (_queueShowDesign.IsShowQueueIcon)
                {
                    labWait.Appearance.Image = Properties.Resources.wait;
                    labWait.ImageAlignToText = ImageAlignToText.LeftCenter;
                }

                labWait.ForeColor = _queueShowDesign.ForeColor;
                labWait.Font = this.Font;

                tableLayoutPanel1.Controls.Add(labWait, colIndex, i);

                _waitList.Add(queueName, labWait);

                //if (_queueShowDesign.IsShowMiss)
                //{
                //    //添加过号状态文本
                //    Label labMiss = new Label();

                //    labMiss.BackColor = Color.Transparent;
                //    labMiss.TextAlign = ContentAlignment.MiddleLeft;
                //    labMiss.Tag = queueName;
                //    labMiss.AutoSize = false;
                //    labMiss.Dock = DockStyle.Fill;

                //    labMiss.ForeColor = _queueShowDesign.ForeColor;
                //    labMiss.Font = this.Font;

                //    tableLayoutPanel1.Controls.Add(labMiss, 2, i);

                //    _missList.Add(queueName, labMiss);
                //}
            }

        }

        private void BindQueueListData(List<QueueItem> queueItems)
        {
            if (queueItems == null || queueItems.Count <= 0) return;

            foreach(QueueItem queueItem in queueItems)
            {
                DataTable dtLineupInfo = QueueModel.GetLineupInfos(queueItem.QueueId, false);
                 
                //处理正在呼叫的排队信息显示
                if (_queueShowDesign.IsShowLastCall)
                {
                    DataRow[] drCalls = dtLineupInfo.Select("排队状态>1 and 排队状态<=3");
                    if (drCalls.Length > 0)
                    {
                        DateTime lastTime = default(DateTime);
                        LineUpData lineupCall = null;

                        foreach (DataRow dr in drCalls)
                        {
                            LineUpData lineUpInfo = new LineUpData();
                            lineUpInfo.BindRowData(dr);

                            if (lineUpInfo.附加信息.末次呼叫时间 >= lastTime)
                            {
                                lineupCall = lineUpInfo;
                                lastTime = lineUpInfo.附加信息.末次呼叫时间;
                            }
                        }

                        if (lineupCall != null)
                        {
                            string newName = lineupCall.患者姓名.Replace(lineupCall.患者姓名.Substring(1, 1), "*");
                            _callList[queueItem.QueueName].Text =((_queueShowDesign.IsShowCallIcon)?"    ":"") + "" + lineupCall.号码前缀 + lineupCall.排队号码 + "" + newName;
                        }
                        else
                        {
                            _callList[queueItem.QueueName].Text = "";
                        }
                    }
                    else
                    {
                        _callList[queueItem.QueueName].Text = "";
                    }
                } 

                //处理正在排队的数据显示
                DataRow[] drQueues = dtLineupInfo.Select("排队状态=0");
                if (drQueues.Length > 0)
                {
                    string waitQueueInfo = "";
                    for(int i = 0; i < _queueShowDesign.WaitCount; i ++)
                    {
                        if (i >= drQueues.Length) break;

                        LineUpData lineupInfo = new LineUpData();
                        lineupInfo.BindRowData(drQueues[i]);

                        if (waitQueueInfo != "") waitQueueInfo = waitQueueInfo + "  ";

                        string newName = lineupInfo.患者姓名.Replace(lineupInfo.患者姓名.Substring(1, 1), "*");

                        waitQueueInfo = waitQueueInfo + "" + lineupInfo.号码前缀 + lineupInfo.排队号码 + ""
                                                        + newName
                                                        + ((string.IsNullOrEmpty(lineupInfo.附加信息.备注))?"": "(" + lineupInfo.附加信息.备注 + ")");
                    }

                    _waitList[queueItem.QueueName].Text = waitQueueInfo;
                }
                else
                {
                    _waitList[queueItem.QueueName].Text = "";
                }

                //处理已经过号的排队数据显示
            }
        }

        private void QueueShowControl_Resize(object sender, EventArgs e)
        {
            try
            {
                 
                for (int i = 0; i < tableLayoutPanel1.RowStyles.Count; i ++)
                {
                    tableLayoutPanel1.RowStyles[i].Height = this.Height / tableLayoutPanel1.RowCount;
                } 
            }
            catch { }
        }
    }
}

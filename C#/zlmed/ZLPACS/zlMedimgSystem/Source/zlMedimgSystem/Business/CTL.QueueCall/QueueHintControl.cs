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
using System.Speech;
using System.Speech.Synthesis;
using System.Drawing.Drawing2D;

namespace zlMedimgSystem.CTL.QueueHint
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(QueueHintControl), "Resources.queuehint.ico")]
    public partial class QueueHintControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {

        static public class QueueCallActionDefine
        {
            public const string Refresh = "刷新";
        }

        private QueueModel _qm = null;
        private QueueHintModuleDesign _queueCallDesign = null;
        private List<QueueItem> _queueItems = null;

        public QueueHintControl()
        {
            InitializeComponent();
             
            _queueItems = new List<QueueItem>();

            _queueCallDesign = new QueueHintModuleDesign();

            _queueCallDesign.ShowHeader = true;
            _queueCallDesign.HeadDockWay = HeadDockWay.hdwLeft;
            _queueCallDesign.HeadBColor = labHead.BackColor;
            _queueCallDesign.HeadFColor = labHead.ForeColor;

            _queueCallDesign.HeadFontName = labHead.Font.Name;
            _queueCallDesign.HeadFontSize = labHead.Font.Size;
            _queueCallDesign.HeadFontBold = labHead.Font.Bold;
            _queueCallDesign.HeadFontItalic = labHead.Font.Italic;

            _queueCallDesign.HeadText = labHead.Text;

            _queueCallDesign.TxtBColor = this.BackColor;
            _queueCallDesign.TxtFColor = labCallContext.ForeColor;

            _queueCallDesign.TxtFontName = labCallContext.Font.Name;
            _queueCallDesign.TxtFontSize = labCallContext.Font.Size;
            _queueCallDesign.TxtFontBold = labCallContext.Font.Bold;
            _queueCallDesign.TxtFontItalic = labCallContext.Font.Italic;

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
            _moduleName = "排队呼叫提示";

            _provideActionDesc.Add(QueueCallActionDefine.Refresh, "刷新最后呼叫的排队信息显示");

            //_designEvents.Add(QueueEventDefine.AbandonQueueAfter, new EventActionReleation(QueueEventDefine.AbandonQueueAfter, ActionType.atSysFixedEvent)); 
        }


        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {

                switch (actName)
                {
                    case QueueCallActionDefine.Refresh:
                        BindLastCall();
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


        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _queueCallDesign = JsonHelper.DeserializeObject<QueueHintModuleDesign>(customContext);

            LoadDesign();

            BindLastCall();

        }

        
        private void LoadDesign()
        {
            labCallContext.BackColor = Color.Transparent;
            labHead.BackColor = Color.Transparent;

            this.BackColor = _queueCallDesign.TxtBColor;

            if (string.IsNullOrEmpty(_queueCallDesign.BackgroundImage) == false)
            {
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.BackgroundImage = BigImgResource.LoadImg(_queueCallDesign.BackgroundImage);
            }

            if (_queueCallDesign.ShowHeader)
            {
                switch(_queueCallDesign.HeadDockWay)
                {
                    case HeadDockWay.hdwTop:
                        labHead.Dock = DockStyle.Top;
                        break;

                    case HeadDockWay.hdwLeft:
                        labHead.Dock = DockStyle.Left;
                        break;

                    case HeadDockWay.hdwRight:
                        labHead.Dock = DockStyle.Right;
                        break;

                    default:
                        labHead.Dock = DockStyle.Bottom;
                        break;
                }

                labHead.ForeColor = _queueCallDesign.HeadFColor;
                labHead.BackColor = _queueCallDesign.HeadBColor;

                float fontSize = 0;
                FontStyle fs = FontStyle.Regular;

                try
                {
                    fontSize = _queueCallDesign.HeadFontSize;
                }
                catch { }
                if (fontSize <= 0) fontSize = this.Font.Size;


                if (_queueCallDesign.HeadFontBold) fs = fs | FontStyle.Bold;
                if (_queueCallDesign.HeadFontItalic) fs = fs | FontStyle.Italic;

                Font headFont = new Font(_queueCallDesign.HeadFontName, fontSize, fs);

                labHead.Font = headFont;

                if (string.IsNullOrEmpty(_queueCallDesign.HeadText))
                {
                    labHead.ImageAlign = ContentAlignment.MiddleCenter;
                    labHead.Text = "";
                }
                else
                {
                    labHead.ImageAlign = ContentAlignment.TopCenter;

                    char[] txtChars = _queueCallDesign.HeadText.ToCharArray();

                    string headText = "";
                    foreach(char chr in txtChars)
                    {
                        if (headText != "") headText = headText + '\r';

                        headText = headText + chr;
                    }
                    labHead.Text = headText;
                }

                labHead.Visible = true;



                labCallContext.ForeColor = _queueCallDesign.TxtFColor;
                labCallContext.Text = "";


                float txtfontSize = 0;
                FontStyle txtfs = FontStyle.Regular;

                try
                {
                    txtfontSize = _queueCallDesign.TxtFontSize;
                }
                catch { }
                if (txtfontSize <= 0) txtfontSize = this.Font.Size;


                if (_queueCallDesign.TxtFontBold) txtfs = txtfs | FontStyle.Bold;
                if (_queueCallDesign.TxtFontItalic) txtfs = txtfs | FontStyle.Italic;

                Font txtFont = new Font(_queueCallDesign.TxtFontName, txtfontSize, txtfs);

                labCallContext.Font = txtFont;

                 
                _queueItems.Clear();
                if (_queueCallDesign.QueueItems.Count > 0)
                {
                    _queueItems = new List<QueueItem>(_queueCallDesign.QueueItems);
                }
                else
                {
                    //查询科室包含的队列
                    DataTable dtQueueData = QueueModel.GetQueueInfoByDeptId(_stationInfo.DepartmentId);

                    if (_queueCallDesign.UserRoomReleationQueue && string.IsNullOrEmpty(_stationInfo.RoomId) == false)
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

            }
            else
            {
                labHead.Visible = false;
            }


        }


        public override string ShowCustomDesign()
        {
            using (frmQueueHintDesign design = new frmQueueHintDesign())
            {
                design.ShowQueueCallDesign(QueueModel, _stationInfo.DepartmentId, _queueCallDesign, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_queueCallDesign);

            LoadDesign();

            BindLastCall();

            return _customDesignFmt;
        }
          
        private void BindLastCall()
        {
            try
            {
                string stationName = _stationInfo.StationName;


                DataTable dtLastCall = QueueModel.GetLastCallInfoByDepartmentId(_stationInfo.DepartmentId);

                if (dtLastCall == null || dtLastCall.Rows.Count <= 0) return ;

                LineUpData lastCall = null;
                DateTime lastTime = default(DateTime);

                foreach (DataRow dr in dtLastCall.Rows)
                {
                    LineUpData curLineup = new LineUpData();
                    curLineup.BindRowData(dr);

                    if (curLineup.附加信息.末次呼叫时间 > lastTime && _queueItems.FindIndex(T=>T.QueueId == curLineup.队列ID) >= 0)
                    {
                        lastTime = curLineup.附加信息.末次呼叫时间;
                        lastCall = curLineup;
                    }
                }

                if (lastCall != null)
                { 
                    //显示语音呼叫状态
                    ShowCallingInfo(lastCall);
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }




        private void ShowCallingInfo(LineUpData lineupInfo)
        {

            if (lineupInfo == null) return;
                    

            string newName = lineupInfo.患者姓名.Replace(lineupInfo.患者姓名.Substring(1, 1), "*");
            labCallContext.Text = lineupInfo.号码前缀 + lineupInfo.排队号码 + " " + newName
                                    + System.Environment.NewLine
                                    + lineupInfo.检查房间;

        }

        private void QueueCallControl_Load(object sender, EventArgs e)
        {
            
        }

        //protected override void PaintGradient()
        //{
        //}
 

        //private void labCallContext_Paint(object sender, PaintEventArgs e)
        //{
        //    if (_queueCallDesign.TxtBColor2 != default(Color))
        //    {
        //        labCallContext.BackColor = _queueCallDesign.TxtBColor;
        //        LinearGradientBrush brush = new LinearGradientBrush(labCallContext.ClientRectangle,
        //                            _queueCallDesign.TxtBColor,
        //                            _queueCallDesign.TxtBColor2,
        //                            this.GradientMode);

        //        Graphics g = labCallContext.CreateGraphics();
        //        g.FillRectangle(brush, labCallContext.ClientRectangle);
        //    }
        //}

        //private void labHead_Paint(object sender, PaintEventArgs e)
        //{
        //    if (_queueCallDesign.HeadBColor2 != default(Color))
        //    {
        //        LinearGradientBrush brush = new LinearGradientBrush(labHead.ClientRectangle,
        //                            _queueCallDesign.HeadBColor,
        //                            _queueCallDesign.HeadBColor2,
        //                            this.GradientMode);

        //        Graphics g = labHead.CreateGraphics();
        //        g.FillRectangle(brush, labHead.ClientRectangle);
        //    }
        //}
    }
}

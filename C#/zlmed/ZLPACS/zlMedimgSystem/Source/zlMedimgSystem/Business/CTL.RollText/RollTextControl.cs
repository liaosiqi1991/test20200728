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

namespace zlMedimgSystem.CTL.RollText
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(RollTextControl), "Resources.rolltext.ico")]
    public partial class RollTextControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {

        private RollTextModuleDesign _rollTextDesign = null;
        public RollTextControl()
        {
            InitializeComponent();

            _rollTextDesign = new RollTextModuleDesign();

            _rollTextDesign.BackColor = this.BackColor;
            _rollTextDesign.ForeColor = this.ForeColor;
            _rollTextDesign.FontName = this.Font.Name;
            _rollTextDesign.IsBold = this.Font.Bold;
            _rollTextDesign.IsItalic = this.Font.Italic;
            _rollTextDesign.FontSize = this.Font.Size;
            _rollTextDesign.RollDistance = 1;
            _rollTextDesign.RollSpeed = 50;
            _rollTextDesign.RollText = "";

        }

        private void RollTextControl_Resize(object sender, EventArgs e)
        {
            bool timerEnable = timerRoll.Enabled;

            try
            {
                timerRoll.Enabled = false;


                if (labRoll.Width <= this.Width)
                {
                    labRoll.Left = (this.Width - labRoll.Width) / 2;
                    labRoll.Top = (this.Height - labRoll.Height) / 2;

                }
                else
                {
                    labRoll.Left = 0;
                    labRoll.Top = (this.Height - labRoll.Height) / 2;
                }
            }
            catch { }
            finally
            {
                timerRoll.Enabled = timerEnable;
            }
        }


        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "滚动字幕";
            _category = "基础控件";

            //_provideActionDesc.Add(QueueActionDefine.Refresh, "刷新当前队列排队数据。"); 

            //_designEvents.Add(QueueEventDefine.AbandonQueueAfter, new EventActionReleation(QueueEventDefine.AbandonQueueAfter, ActionType.atSysFixedEvent)); 
        }


        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _rollTextDesign = JsonHelper.DeserializeObject<RollTextModuleDesign>(customContext);

            LoadDesign();
        }

        private void LoadDesign()
        {
            timerRoll.Interval = _rollTextDesign.RollSpeed;

            labRoll.BackColor = Color.Transparent;

            this.BackColor = _rollTextDesign.BackColor;
            labRoll.ForeColor = _rollTextDesign.ForeColor;
            labRoll.Text = _rollTextDesign.RollText;

            if (string.IsNullOrEmpty(_rollTextDesign.BackgroundImage) == false)
            {
                this.BackgroundImageLayout = _rollTextDesign.BackgroundImageLayout;
                this.BackgroundImage = Img24Resource.LoadImg(_rollTextDesign.BackgroundImage);                
            }
            else
            {
                this.BackgroundImage = null;
            }

            float fontSize = 0;

            try
            {
                fontSize = _rollTextDesign.FontSize;
            }
            catch { }
            if (fontSize <= 0) fontSize = this.Font.Size;

            FontStyle fs = FontStyle.Regular;

            if (_rollTextDesign.IsBold) fs = fs | FontStyle.Bold;
            if (_rollTextDesign.IsItalic) fs = fs | FontStyle.Italic;



            Font ft = new Font(_rollTextDesign.FontName, fontSize, fs);
            labRoll.Font = ft;

            //如果没有文本，则不启动timer
            if (string.IsNullOrEmpty(_rollTextDesign.RollText)) return;

            timerRoll.Enabled = true;

        }

        public override string ShowCustomDesign()
        {
            using (frmRollTextDesign design = new frmRollTextDesign())
            {
                design.ShowRollTextDesign(_rollTextDesign, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_rollTextDesign);

            LoadDesign();

            return _customDesignFmt;
        }

        public override void Terminated()
        {
            timerRoll.Enabled = false;

            base.Terminated();
        }

        private Label _loopLab = null;
        private bool _isLast = false;
        private void timerRoll_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime curDateTime = DateTime.Now;

                if (_rollTextDesign.RollText.IndexOf("[当前") >= 0)
                {
                    labRoll.Text = _rollTextDesign.RollText.Replace("[当前日期]", curDateTime.ToString("yyyy-MM-dd")).Replace("[当前时间]", curDateTime.ToString("hh:mm")).Replace("[当前日期时间]", curDateTime.ToString("yyyy-MM-dd hh:mm"));
                }

                if (labRoll.Width <= this.Width)
                {
                    labRoll.Left = (this.Width - labRoll.Width) / 2;
                    labRoll.Top = (this.Height - labRoll.Height) / 2;

                    return;
                }

                if (string.IsNullOrEmpty(labRoll.Text)) return;

                if (_loopLab == null )
                {
                    _loopLab = new Label();
                    _loopLab.AutoSize = true;

                    this.Controls.Add(_loopLab);

                    _loopLab.Left = labRoll.Left + labRoll.Width;
                }

                _loopLab.Font = labRoll.Font;
                _loopLab.ForeColor = labRoll.ForeColor;

                _loopLab.Text = labRoll.Text;
                               
                _loopLab.Top = labRoll.Top;

                if (_isLast == false && labRoll.Left + labRoll.Width <= 0)
                {
                    _isLast = true;
                }

                if (_isLast && _loopLab.Left + _loopLab.Width <= 0)
                {
                    _isLast = false;
                }

                if (_isLast)
                {
                    _loopLab.Left = _loopLab.Left - _rollTextDesign.RollDistance;
                    labRoll.Left = _loopLab.Left + _loopLab.Width + 10;
                }
                else
                {
                    labRoll.Left = labRoll.Left - _rollTextDesign.RollDistance;
                    _loopLab.Left = labRoll.Left + labRoll.Width + 10;
                }
            }
            catch { }
        }
    }
}

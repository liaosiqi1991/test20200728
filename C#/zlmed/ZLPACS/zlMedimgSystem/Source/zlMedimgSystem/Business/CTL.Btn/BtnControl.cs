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
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.Btn
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(BtnControl), "Resources.Button.ico")]
    public partial class BtnControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class ButEventDefine
        {
            public const string Click = "按钮单击事件";
        }

        static public class ButActionDefine
        {
            public const string DoClick = "模拟单击";
        }

        private BtnModulleDesign _btnDesign = null;
        public BtnControl()
        {
            InitializeComponent();

            _btnDesign = new BtnModulleDesign();

            _btnDesign.Text = simpleButton1.Text;
            _btnDesign.Style = ButtonStyle.bsDefault;
            _btnDesign.ImagePostion = ButtonImagePostion.bipImageBeforeText;
            _btnDesign.BackColor = simpleButton1.Appearance.BackColor;
            _btnDesign.ForceColor = simpleButton1.ForeColor;
            _btnDesign.ClickReponse = true;
        }

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _btnDesign = JsonHelper.DeserializeObject<BtnModulleDesign>(customContext);

            ConfigBtnStyle();
        }

        private void ConfigBtnStyle()
        {
            Tag = _btnDesign.Tag;

            simpleButton1.Appearance.BackColor = _btnDesign.BackColor;
            simpleButton1.Appearance.Options.UseBackColor = true;

            simpleButton1.ForeColor = _btnDesign.ForceColor;

            simpleButton1.Text = _btnDesign.Text;
            simpleButton1.Tag = _btnDesign.Tag;
            simpleButton1.Image = Img24Resource.LoadImg(_btnDesign.ImageName);

            switch (_btnDesign.Style)
            {
                case ButtonStyle.bsDefault:
                    simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                    break;
                case ButtonStyle.bsSimple:
                    simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    break;
                case ButtonStyle.bsFlat:
                    simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
                    break;
                default:
                    break;
            }

            switch (_btnDesign.ImagePostion)
            {
                case ButtonImagePostion.bipImageAboveText:
                    simpleButton1.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
                    break;
                case ButtonImagePostion.bipTextAboveImage:
                    simpleButton1.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
                    break;
                case ButtonImagePostion.bipImageBeforeText:
                    simpleButton1.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
                    break;
                case ButtonImagePostion.bipTextBeforeImage:
                    simpleButton1.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
                    break;
                default:
                    break;
            }

            float fontSize = 0;
            FontStyle fs = FontStyle.Regular;

            try
            {
                fontSize = _btnDesign.FontSize;
            }
            catch { }
            if (fontSize <= 0) fontSize = this.Font.Size;

            if (_btnDesign.FontBold) fs = fs | FontStyle.Bold;
            if (_btnDesign.FontItalic) fs = fs | FontStyle.Italic;

            Font font = new Font(_btnDesign.FontName, fontSize, fs);

            this.Font = font;

            simpleButton1.Font = this.Font;

        }
        

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "按钮模块";
            _category = "基础控件";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add(ButActionDefine.DoClick, "模拟按钮按下。"); 

            //_provideDataDesc.AddDataDescription("", "", "");

            _designEvents.Add(ButEventDefine.Click, new EventActionReleation(ButEventDefine.Click, ActionType.atSysFixedEvent)); 
        }


        private bool DoClick(object sender)
        {
            if (_designEvents.ContainsKey(ButEventDefine.Click) == false) return false;

            EventActionReleation ea = _designEvents[ButEventDefine.Click];

            return DoActions(ea, sender);
        }


        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {
                switch (actName)
                {
                    case ButActionDefine.DoClick:
                        return DoClick(sender);  

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

        public override string ShowCustomDesign()
        {
            using (frmBtnDesign design = new frmBtnDesign())
            {
                design.ShowDesign(_btnDesign, this);
            }

            ConfigBtnStyle();

            _customDesignFmt = JsonHelper.SerializeObject(_btnDesign);
                        
            return _customDesignFmt;
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_btnDesign.ClickReponse)
                { 
                    ButtonHint.Start(sender as Control, "···");
                }

                DoClick(sender);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

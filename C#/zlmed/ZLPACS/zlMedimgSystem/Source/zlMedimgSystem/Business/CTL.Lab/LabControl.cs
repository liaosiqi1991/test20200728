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

namespace zlMedimgSystem.CTL.Lab
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(LabControl), "Resources.lab.ico")]
    public partial class LabControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {

        static public class LabActionDefine
        {
            public const string LoadText = "载入文本";
            public const string ClearText = "清理文本";
        }

        static public class LabDataDefine
        {
            public const string GetTextContext = "获取文本内容";
        }

        private LabModuleDesign _labDesign = null;

        public LabControl()
        {
            InitializeComponent();

            _labDesign = new LabModuleDesign();

            _labDesign.BackColor = this.BackColor;
            _labDesign.ForeColor = this.ForeColor;
            _labDesign.FontName = this.Font.Name;
            _labDesign.IsBold = this.Font.Bold;
            _labDesign.IsItalic = this.Font.Italic;
            _labDesign.FontSize = this.Font.Size;
            _labDesign.LabText = "";
            _labDesign.UseDrag = false;
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "文本图像";
            _category = "基础控件";

            _provideActionDesc.Add(LabActionDefine.LoadText, "载入指定的文本内容，该方法将根据执行标记获取需要载入的数据内容。");
            _provideActionDesc.Add(LabActionDefine.ClearText, "清除显示的文本内容。");
            //_designEvents.Add(QueueEventDefine.AbandonQueueAfter, new EventActionReleation(QueueEventDefine.AbandonQueueAfter, ActionType.atSysFixedEvent)); 
        }

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _labDesign = JsonHelper.DeserializeObject<LabModuleDesign>(customContext);

            LoadDesign();
        }

        private void LoadDesign()
        { 
            labContext.BackColor = Color.Transparent;

            this.BackColor = _labDesign.BackColor;

            labContext.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            labContext.ForeColor = _labDesign.ForeColor;
            labContext.Text = _labDesign.LabText;
            

            if (string.IsNullOrEmpty(_labDesign.BackgroundImage) == false)
            {
                this.BackgroundImageLayout = _labDesign.BackgroundImageLayout;
                this.BackgroundImage = BigImgResource.LoadImg(_labDesign.BackgroundImage);
            }
            else
            {
                this.BackgroundImage = null;
            }

            if (string.IsNullOrEmpty(_labDesign.TextIcon) == false)
            { 
                labContext.Appearance.Image = Img24Resource.LoadImg(_labDesign.TextIcon);
            }
            else
            {
                labContext.Appearance.Image = null;
            }

            
            float fontSize = 0;

            try
            {
                fontSize = _labDesign.FontSize;
            }
            catch { }
            if (fontSize <= 0) fontSize = this.Font.Size;

            FontStyle fs = FontStyle.Regular;

            if (_labDesign.IsBold) fs = fs | FontStyle.Bold;
            if (_labDesign.IsItalic) fs = fs | FontStyle.Italic;



            Font ft = new Font(_labDesign.FontName, fontSize, fs);
            labContext.Font = ft;


            switch (_labDesign.TextPostion)
            {
                case PostionType.ipTop:
                    labContext.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    labContext.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
                    break;

                case PostionType.ipLeft:
                    labContext.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    labContext.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    break;

                case PostionType.ipRight:
                    labContext.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    labContext.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    break;

                case PostionType.ipBottom:
                    labContext.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    labContext.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
                    break;

                case PostionType.ipCenter:
                    labContext.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    labContext.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    break;


                default:
                    break;
            }


            switch (_labDesign.IconPostion)
            {
                case PostionType.ipTop:
                    labContext.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
                    break;

                case PostionType.ipLeft:
                    labContext.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
                    break;

                case PostionType.ipRight:
                    labContext.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
                    break;

                case PostionType.ipBottom:
                    labContext.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
                    break;

                case PostionType.ipCenter:
                    labContext.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
                    break;


                default:
                    break;
            }

 

        }

        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case LabDataDefine.GetTextContext:
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
                case LabDataDefine.GetTextContext://方法当前查询到的数据结果
                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_TextContext, labContext.Text); 

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
                    case LabActionDefine.LoadText:
                        labContext.Text = "";

                        if (bizDatas == null || bizDatas.Count <= 0) return true;

                        if (bizDatas[0].Count <= 0) return true;

                        if (string.IsNullOrEmpty(tag))
                        {
                            foreach (KeyValuePair<string, object> kv in bizDatas[0])
                            {
                                labContext.Text = Convert.ToString(kv.Value);
                                return true;
                            }
                        }
                        else
                        {
                            labContext.Text = Convert.ToString(bizDatas[0][tag]);
                        }

                        return true;

                    case LabActionDefine.ClearText:
                        labContext.Text = "";

                        return true;
       

                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        public override string ShowCustomDesign()
        {
            frmLabDesign design = new frmLabDesign();
            design.ShowLabDesign(_labDesign, this);

            _customDesignFmt = JsonHelper.SerializeObject(_labDesign);

            LoadDesign();

            return _customDesignFmt;
        }

        private Control _parentForm = null;

        private bool moving = false;
        private Point oldMousePosition;
        private void labContext_MouseDown(object sender, MouseEventArgs e)
        {
            if ((_parentForm as Form).WindowState == FormWindowState.Maximized)
            {
                return;
            }

            oldMousePosition = e.Location;
            moving = true;
        }

        private void LabControl_Load(object sender, EventArgs e)
        {
            _parentForm = Parent;
            while (_parentForm.Parent != null)
            {
                _parentForm = _parentForm.Parent;
            }
        }

        private void labContext_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && moving)
            {
                Point newPosition = new Point(e.Location.X - oldMousePosition.X, e.Location.Y - oldMousePosition.Y);

                if (_labDesign.UseDrag) _parentForm.Location += new Size(newPosition);

            }
        }

        private void labContext_MouseUp(object sender, MouseEventArgs e)
        {
            if ((_parentForm as Form).WindowState == FormWindowState.Maximized)
            {
                return;
            }

            oldMousePosition = e.Location;
            moving = false;
        }
    }
}

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


namespace zlMedimgSystem.CTL.Chars
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(CharsControl), "Resources.char12.ico")]
    public partial class CharsControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {

        static private class CharActionDefine
        {
            public const string LoadChars = "载入字符";
            public const string CharsSetting = "字符配置";
        }

        static private class CharEventDefine
        {
            public const string WriteChar = "写入字符";
        }

        static private class CharDataDefine
        {
            public const string SelCharContext = "当前选择字符";
        }

        private CharModuleDesign _chrModuleDesign = null;

        public CharsControl()
        {
            InitializeComponent();

            _chrModuleDesign = new CharModuleDesign();

            _chrModuleDesign.ButSettingVisible = true;
            _chrModuleDesign.ToolsDesign.Visible = true;
            _chrModuleDesign.ToolsDesign.BackColor = toolStrip1.BackColor;
            _chrModuleDesign.ToolsDesign.ForceColor = toolStrip1.ForeColor;
            _chrModuleDesign.ToolsDesign.Size = toolStrip1.Height;
        }

        protected override void InitBaseInfo()
        {
            _moduleName = "字符模块";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add(CharActionDefine.LoadChars, "载入配置的特殊字符。");
            _provideActionDesc.Add(CharActionDefine.CharsSetting, "配置当前用户常用的特殊字符。");

            _provideDataDesc.AddDataDescription(_moduleName, CharDataDefine.SelCharContext, "返回选择的字符，返回数据项如下："  
                                                                + System.Environment.NewLine 
                                                                + "text");

            
            _designEvents.Add(CharEventDefine.WriteChar, new EventActionReleation(CharEventDefine.WriteChar, ActionType.atSysFixedEvent));
        }


        /// <summary>
        /// 刷新
        /// </summary>
        public override void RefreshModule()
        {

        }

        private ParameterModel _pm = null;

        private ParameterModel ParameterModel
        {
            get
            {
                if (_pm == null) _pm = new ParameterModel(_dbQuery);

                return _pm;
            }
        }

        private JReportChars _reportChars = null;
        private void LoadChars()
        {
            listView1.Clear();

            if (_reportChars == null)
            {
                ParameterData charsData = ParameterModel.ReadParameter("特殊字符", _userData.UserId);

                if (charsData == null) return;
                if (string.IsNullOrEmpty(charsData.参数取值)) return;


                _reportChars = JsonHelper.DeserializeObject<JReportChars>(charsData.参数取值);
            }

            foreach(JReportCharItem charItem in _reportChars.字符明细)
            {
                listView1.Items.Add(charItem.字符内容);
            }

            listView1.View = View.LargeIcon;
        }

        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {

                switch (actName)
                {
                    case CharActionDefine.LoadChars:
                        LoadChars();
                        break;

                    case CharActionDefine.CharsSetting:
                        CharsConfig();
                        break;

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

        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case CharDataDefine.SelCharContext:
                    return true;

                //case CaptureProviderDataDefine.Data_StudyData:
                //    return true;

                default:
                    return false;
            }
        }


        public override IBizDataItems QueryDatas(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            BizDataItems resultDatas = null;
            BizDataItem dataItem = null;

            switch (dataName)
            {
                case CharDataDefine.SelCharContext:

                    if (listView1.SelectedItems.Count <= 0) return null;

                    resultDatas = new BizDataItems();

                    dataItem = new BizDataItem();
                    dataItem.Add(DataHelper.StdPar_Text, listView1.SelectedItems[0].Text);

                    resultDatas.Add(dataItem);

                    return resultDatas;

                default:
                    return null;
            }
        }


        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _chrModuleDesign = JsonHelper.DeserializeObject<CharModuleDesign>(customContext);

            LoadDesign();
        }

        public override string ShowCustomDesign()
        {
            using (frmCharDesign design = new frmCharDesign())
            {
                design.ShowDesign(_chrModuleDesign, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_chrModuleDesign);

            LoadDesign();

            return _customDesignFmt;
        }


        private void LoadDesign()
        {
            if (_chrModuleDesign.ToolsDesign.Visible == false)
            {
                toolStrip1.Visible = false; 
                return;
            }

            if (_chrModuleDesign.ToolsDesign.Size > 0)
            {
                toolStrip1.Height = _chrModuleDesign.ToolsDesign.Size;
            }

            toolStrip1.Visible = true;


            toolStrip1.BackColor = _chrModuleDesign.ToolsDesign.BackColor;
            toolStrip1.ForeColor = _chrModuleDesign.ToolsDesign.ForceColor;

             

            tsbConfig.Visible = _chrModuleDesign.ButSettingVisible; 

            if (_chrModuleDesign.ToolsDesign.ToolsCfg != null)
            {
                InitUserTool(_chrModuleDesign.ToolsDesign);
            }
 
            ToolsHelper.SyncDesignEventsByButtons(_chrModuleDesign.ToolsDesign, _designEvents);

        }


        private void InitUserTool(ToolsDesign toolDesign)
        {
            try
            {
                for (int i = toolStrip1.Items.Count - 1; i >= 0; i--)
                {
                    //先移除用户控件
                    if (toolStrip1.Items[i].Tag == null) continue;
                    toolStrip1.Items.RemoveAt(i);
                }

                if (toolDesign.ToolsCfg.Count <= 0)
                {
                    if (toolStrip1.Items.Count <= 0) toolStrip1.Visible = false;

                    return;
                }

                ToolsHelper.ConfigButtons(toolStrip1, toolDesign, DoUserToolEvent_StripItem);

                if (this.DesignMode == false)
                {
                    toolStrip1.Visible = (toolStrip1.Items.Count <= 0) ? false : true;
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void DoUserToolEvent_StripItem(object sender, EventArgs e)
        {
            ToolStripItem tsi = (sender as ToolStripItem);
            if (tsi == null) return;

            //没有对应的事件配置
            if (_designEvents.ContainsKey(tsi.Text) == false) return;

            EventActionReleation ea = _designEvents[tsi.Text];

            DoActions(ea, sender);
        }

        private void CharsConfig()
        {
            using (frmCharConfig cc = new frmCharConfig())
            {
                JReportChars curChars = cc.ShowCharConfig(_reportChars, _dbQuery, _userData.UserId, this);

                if (curChars != null)
                {
                    listView1.Clear();
                    foreach (JReportCharItem charItem in _reportChars.字符明细)
                    {
                        listView1.Items.Add(charItem.字符内容);
                    }

                    listView1.View = View.LargeIcon;
                }
            }
        }

        private void tsbConfig_Click(object sender, EventArgs e)
        {
            try
            {
                CharsConfig();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0) return;

                DoActions(_designEvents[CharEventDefine.WriteChar], sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void DoActions(EventActionReleation ea, object sender)
        {
            try
            {
                base.DoBindActions(ea, sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void CharsControl_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.DesignMode) return;

                LoadChars();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

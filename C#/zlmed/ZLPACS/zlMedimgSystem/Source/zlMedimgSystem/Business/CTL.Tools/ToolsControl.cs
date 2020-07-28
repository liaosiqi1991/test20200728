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

namespace zlMedimgSystem.CTL.Tools
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(ToolsControl), "Resources.toolbox.ico")]
    public partial class ToolsControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        private ToolsDesign _toolsDesign = null;
        public ToolsControl()
        {
            InitializeComponent();

            _toolsDesign = new ToolsDesign();

            _toolsDesign.Visible = true;
            _toolsDesign.BackColor = toolStrip1.BackColor;
            _toolsDesign.ForceColor = toolStrip1.ForeColor;            
        }

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _toolsDesign = JsonHelper.DeserializeObject<ToolsDesign>(customContext);

            toolStrip1.BackColor = _toolsDesign.BackColor;
            toolStrip1.ForeColor = _toolsDesign.ForceColor;

            if (_toolsDesign.ToolsCfg != null)
            { 
                InitUserTool(_toolsDesign);
            }
                         
            ToolsHelper.SyncDesignEventsByButtons(_toolsDesign, _designEvents);
        }


        private void InitUserTool(ToolsDesign toolDesign)
        {
            try
            {
                //先移除用户控件
                toolStrip1.Items.Clear(); 
                

                if (toolDesign.ToolsCfg.Count <= 0)
                {
                    if (toolStrip1.Items.Count <= 0 && this.DesignMode == false) toolStrip1.Visible = false; 

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

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "工具栏模块";
            _category = "基础控件";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            //_provideActionDesc.Add("", ""); 

            //_provideDataDesc.AddDataDescription("", "", "");

            //_designEvents.Add("", new EventAction("", ActionType.atFixed)); 
        }

        public override string ShowCustomDesign()
        {
            using (frmToolsDesign design = new frmToolsDesign())
            {
                design.ShowDesign(_toolsDesign, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_toolsDesign);


            toolStrip1.BackColor = _toolsDesign.BackColor;
            toolStrip1.ForeColor = _toolsDesign.ForceColor;

            if (_toolsDesign.ToolsCfg != null)
            { 
                InitUserTool(_toolsDesign);
            }

            ToolsHelper.SyncDesignEventsByButtons(_toolsDesign, _designEvents);

            return _customDesignFmt;
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
    }
}

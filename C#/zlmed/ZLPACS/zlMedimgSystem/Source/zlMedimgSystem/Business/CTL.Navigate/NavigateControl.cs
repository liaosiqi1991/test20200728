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
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using zlMedimgSystem.Services;
using System.Security.Permissions;
using System.Runtime.Serialization;

namespace zlMedimgSystem.CTL.Navigate
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(NavigateControl), "Resources.menu.ico")]
    public partial class NavigateControl : DesignControl, ISysBizModule, ISysDesign
    {


        private NavModuleDesign _navDesign = null; 


        private Control _parentForm = null;

        private bool moving = false;
        private Point oldMousePosition;

        public NavigateControl()
        {
            InitializeComponent();

            _navDesign = new NavModuleDesign();

            _navDesign.ButVisible.图标 = true;
            _navDesign.ButVisible.附加菜单 = true;
            _navDesign.ButVisible.退出按钮 = true;

            _navDesign.BackColor = Color.Gray;
            _navDesign.ForceColor = Color.White;

        }

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _navDesign = JsonHelper.DeserializeObject<NavModuleDesign>(customContext);

            if (_navDesign.ButVisible != null)
            {
                InitToolVisible(_navDesign.ButVisible);
            }

            if (_navDesign.NavItems != null)
            {
                InitUserTool(_navDesign.NavItems);
            }


            SyncDesignEventsByButtons();
        }

        private void SyncDesignEventsByButtons()
        {
            foreach (NavItemConfig ctc in _navDesign.NavItems)
            {
                if (_designEvents.ContainsKey(ctc.Name) == false)
                {
                    _designEvents.Add(ctc.Name, new EventActionReleation(ctc.Name, ActionType.atSysFixedEvent));
                }
            }
        }

        public override string ShowCustomDesign()
        {
            using (frmDesign design = new frmDesign())
            {
                design.ShowDesign(_navDesign, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_navDesign);


            if (_navDesign.ButVisible != null)
            {
                InitToolVisible(_navDesign.ButVisible);
            }

            if (_navDesign.NavItems != null)
            {
                InitUserTool(_navDesign.NavItems);
            }

            SyncDesignEventsByButtons();

            return _customDesignFmt;
        }

        protected override void InitBaseInfo()
        {
            _moduleName = "导航模块";
            _category = "基础控件";

            //_moduleStyles = new string[] { "样式一", "样式二" };


            //_provideActionDesc.Add("", ""); 

            //_provideDataDesc.AddDataDescription("", "", "");

            //_designEvents.Add("", new EventAction("", ActionType.atFixed)); 
        }


        /// <summary>
        /// 刷新
        /// </summary>
        public override void RefreshModule()
        {

        }

        //protected override void BindEvents()
        //{
        //    //if (_designEvents.Count <= 0) return;

        //    //foreach(EventAction ea in _designEvents.Values)
        //    //{
        //    //    if (ea.Actions.Count <= 0) continue;

        //    //    //绑定执行事件
        //    //    switch(ea.ActType)
        //    //    {
        //    //        case ActionType.atSysFixedEvent:
        //    //            break;
        //    //        case ActionType.atUserToolEvent:
                        
        //    //            break;
        //    //        //case ActionType.atSysToolEvent://该类型不需要绑定
        //    //        //    break;
        //    //        default:
        //    //            break;
        //    //    }
        //    //}
        //}


        private void DoUserToolEvent_NavElement(object sender, NavElementEventArgs e)
        {
            NavElement ne = (sender as NavElement);
            if (ne == null) return;

            //没有对应的事件配置
            if (_designEvents.ContainsKey(ne.Caption) == false) return;

            EventActionReleation ea = _designEvents[ne.Caption];

            DoActions(ea, sender);
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


        private void DoToolBeforeEvent(string toolName)
        {
            throw new Exception("调用了暂不需实现的方法。");
        }

        private void DoToolAfterEvent(string toolName)
        {
            throw new Exception("调用了暂不需实现的方法。");
        }

        public override void ChangeModuleStyle(string styleName)
        {
            throw new Exception("暂不支持样式切换。");
        }

        protected void InitUserTool(List<NavItemConfig> toolsCfg)
        {
            try
            {
                //先移除用户控件 
                menuPopup.Items.Clear();

                tileNavPane.Appearance.BackColor = _navDesign.BackColor;
                tileNavPane.Appearance.ForeColor = _navDesign.ForceColor;

                tileNavPane.Appearance.Options.UseBackColor = true;
                tileNavPane.Appearance.Options.UseForeColor = true;

                NavButton navButton = null;
                for (int i = tileNavPane.Buttons.Count - 1; i >= 0; i--)
                {
                    navButton = (NavButton)tileNavPane.Buttons[i];

                    if (navButton.Tag != null && navButton.Tag.ToString().Equals("Navigate")) continue;

                    tileNavPane.Buttons.Remove(navButton);
                }

                Font bMainFont = new Font(this.Font.FontFamily, (float)11.5, FontStyle.Bold);
                Font bSmallFont = new Font(this.Font.FontFamily, (float)10.5);
                int insertIndex = 1;

                //添加用户工具按钮
                foreach (NavItemConfig mt in toolsCfg)
                {
                    switch (mt.Style)
                    {
                        case NavigateType.ntMain:
                            //创建主导航
                            NavButton funcMenu = new NavButton();
                            funcMenu.Caption = mt.Name;
                            funcMenu.Tag = mt.Tag;
                            funcMenu.Alignment = NavButtonAlignment.Left;

                            funcMenu.Glyph = Img24Resource.LoadImg(mt.IconName);

                            funcMenu.Appearance.Font = bMainFont;
                            funcMenu.Appearance.Options.UseFont = true;

                            funcMenu.AppearanceHovered.Font = bMainFont;
                            funcMenu.AppearanceHovered.ForeColor = Color.FromArgb(255, 255, 128);
                            funcMenu.AppearanceHovered.Options.UseFont = true;
                            funcMenu.AppearanceHovered.Options.UseForeColor = true;

                            funcMenu.AppearanceSelected.Font = bMainFont;
                            funcMenu.AppearanceSelected.Options.UseFont = true;

                            funcMenu.ElementClick += DoUserToolEvent_NavElement;

                            tileNavPane.Buttons.Insert(insertIndex , funcMenu);

                            mt.LinkObj = funcMenu;

                            insertIndex = insertIndex + 1;

                            break;

                        case NavigateType.ntDropdown:
                            //创建下拉项
                            ToolStripItem tsMenu = menuPopup.Items.Add(mt.Name);

                            tsMenu.Image = Img24Resource.LoadImg(mt.IconName);

                            tsMenu.Tag = mt.Tag;
                            tsMenu.Click += DoUserToolEvent_StripItem;

                            mt.LinkObj = tsMenu;
                            break;

                        default:

                            break;
                    }
                }

                int attachButCount = 0;
                //添加用户工具按钮
                foreach (NavItemConfig mt in toolsCfg)
                {
                    if (mt.Style == NavigateType.ntAttach)
                    {
                        if (attachButCount == 0)
                        {
                            NavButton funcSplit = new NavButton();
                            funcSplit.Caption = "|";

                            funcSplit.Appearance.ForeColor = Color.DarkGray;
                            funcSplit.Appearance.Options.UseForeColor = true;

                            funcSplit.AppearanceHovered.ForeColor = Color.DarkGray;
                            funcSplit.AppearanceHovered.Options.UseForeColor = true;

                            funcSplit.AppearanceSelected.ForeColor = Color.DarkGray;
                            funcSplit.AppearanceSelected.Options.UseForeColor = true;

                            funcSplit.Enabled = false;

                            tileNavPane.Buttons.Insert(insertIndex, funcSplit);

                            insertIndex = insertIndex + 1;
                        }


                        NavButton funcMenu = new NavButton();
                        funcMenu.Caption = mt.Name;
                        funcMenu.Tag = mt.Tag;
                        funcMenu.Alignment = NavButtonAlignment.Left;

                        funcMenu.Appearance.Font = bSmallFont;
                        funcMenu.Appearance.Options.UseFont = true;
                        funcMenu.AppearanceHovered.Font = bSmallFont;
                        funcMenu.AppearanceHovered.Options.UseFont = true;
                        funcMenu.AppearanceSelected.Font = bSmallFont;
                        funcMenu.AppearanceSelected.Options.UseFont = true;

                        funcMenu.Glyph = Img24Resource.LoadImg(mt.IconName);

                        tileNavPane.Buttons.Insert(insertIndex, funcMenu);

                        mt.LinkObj = funcMenu;

                        insertIndex = insertIndex + 1;

                        attachButCount = attachButCount + 1;
                    }
                }               
                                 
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        protected void InitToolVisible(NavButVisible itemVisible)
        {
            if (itemVisible == null) return;

            navButLog.Visible = itemVisible.图标;
            navCbx.Visible = itemVisible.附加菜单;
            nButClose.Visible = itemVisible.退出按钮;
        } 

     
        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            throw new Exception("暂无可执行的方法。"); 
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

        private void nButClose_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            try
            {
                Control fp = Parent;

                while(fp.Parent != null)
                {
                    fp = fp.Parent;
                }

                if ((fp as Form) != null) (fp as Form).Close();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tileNavPane1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((_parentForm as Form).WindowState == FormWindowState.Maximized)
            {
                return;
            }

            oldMousePosition = e.Location;
            moving = true;
        }

        private void NavigateControl_Load(object sender, EventArgs e)
        {

            _parentForm = Parent;
            while (_parentForm.Parent != null)
            {
                _parentForm = _parentForm.Parent;
            }            
        }

        private void tileNavPane1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && moving)
            {
                Point newPosition = new Point(e.Location.X - oldMousePosition.X, e.Location.Y - oldMousePosition.Y);
                _parentForm.Location += new Size(newPosition);
                
            }
        }

        private void tileNavPane1_MouseUp(object sender, MouseEventArgs e)
        {
            if ((_parentForm as Form).WindowState == FormWindowState.Maximized)
            {
                return;
            }

            oldMousePosition = e.Location;
            moving = true;
        }

 
        private void navCbx_ElementClick(object sender, NavElementEventArgs e)
        {
            try
            {
                if (menuPopup.Items.Count <= 0) return;
                menuPopup.Show(MousePosition);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tileNavPane_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if ((_parentForm as Form).WindowState != FormWindowState.Maximized)
                {
                    (_parentForm as Form).WindowState = FormWindowState.Maximized;
                }
                else
                {
                    (_parentForm as Form).WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

    }
}

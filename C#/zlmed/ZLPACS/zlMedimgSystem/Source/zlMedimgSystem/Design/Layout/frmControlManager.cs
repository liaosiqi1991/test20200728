using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.Layout
{
    public partial class frmControlManager : Form
    {

        private BizMainLayout _bizMain = null;
        private DesignControlInstances _dynamicControls = null;
        public frmControlManager()
        {
            InitializeComponent();

            listView1.LargeImageList = imageList1;
            listView1.SmallImageList = imageList1; 
        }

        protected void ShowManager(BizMainLayout bizMain, DesignControlInstances dynamicControls, IWin32Window owner)
        {
            _bizMain = bizMain;
            _dynamicControls = dynamicControls;



            this.Show(owner);

            BindControlData();
        }


        private static System.Type toolboxBitmapAttributeType = typeof(ToolboxBitmapAttribute);
        private Image GetControlIcon(object control)
        {
            ToolboxBitmapAttribute attribute = TypeDescriptor.GetAttributes(control)[toolboxBitmapAttributeType] as ToolboxBitmapAttribute;
            if (attribute != null)
            {
                //img里取到的即是控件textBox1在工具箱中的图标 
                return attribute.GetImage(control, true);
            }

            return null;

        }

        private void BindControlData()
        {
            listView1.Items.Clear();

            foreach(DesignControlInstanceInfo dci in _dynamicControls.Values)
            {
                string category = "";

                string imgKey = dci.OriginalModule;

                ListViewItem lvi = null;
                if (dci.Instance != null)
                {
                    DesignControl dc = dci.Instance as DesignControl;

                    if (imageList1.Images.ContainsKey(imgKey) == false)
                    {
                        if (dci.ToolImg != null)
                        {
                            imageList1.Images.Add(imgKey, dci.ToolImg);
                        }
                        else
                        {
                            imageList1.Images.Add(imgKey, GetControlIcon(dc));
                        }
                    }

                    category = dc.Category;
                    if (string.IsNullOrEmpty(category))
                    {
                        if (dc as DesignComponent != null)
                        {
                            category = "后台组件";
                        }
                        else
                        {
                            category = "业务组件";
                        }
                    }

                    string visible = (dc.Visible) ? "可见" : "不可见";

                    if (dc.Parent == _bizMain)
                    {
                        if (dc as DesignComponent != null)
                        {
                            visible = "后台";
                        }
                        else
                        {
                            visible = "被遮挡";
                        }
                    }

                    lvi = new ListViewItem(new string[] { dc.Name, dc.ModuleName, dc.OriginalModule, category, "有效", visible, dci.ModuleFile });
                                                  
                    lvi.Name = dc.Name;                     
                }
                else
                {
                    if (imageList1.Images.ContainsKey(imgKey) == false)
                    {
                        if (dci.ToolImg != null)
                        {
                            imageList1.Images.Add(imgKey, dci.ToolImg);
                        }
                        else
                        {
                            imageList1.Images.Add(dci.OriginalModule, Properties.Resources.gear);
                        }
                    }
                     
                    category = dci.Category;
                    if (string.IsNullOrEmpty(category)) category = "业务组件";

                    lvi = new ListViewItem(new string[] {dci.InstanceName, dci.ModuleName, dci.OriginalModule, category, "无效", "不可见",  dci.ModuleFile });
                     
                    lvi.Name = dci.InstanceName;                    
                }


                lvi.ImageKey = dci.OriginalModule;
                lvi.Tag = dci;

                listView1.Items.Add(lvi);
                

            }


            listView1.View = View.Details;
            labCount.Text = "组件数量:" + listView1.Items.Count;

            if (listView1.Items.Count > 0) listView1.Items[0].Selected = true;
        }

        private void InitControlList()
        {
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "实例名";
            columnHeader.Name = "实例名";
            columnHeader.Width = 240;
            listView1.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "模块名";
            columnHeader.Name = "模块名";
            columnHeader.Width = 120;
            listView1.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "模块类型";
            columnHeader.Name = "模块类型";
            columnHeader.Width = 100;
            listView1.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "模块分类";
            columnHeader.Name = "模块分类";
            columnHeader.Width = 80;
            listView1.Columns.Add(columnHeader);


            columnHeader = new ColumnHeader();
            columnHeader.Text = "实例状态";
            columnHeader.Name = "实例状态";
            columnHeader.Width = 80;
            listView1.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "可见性";
            columnHeader.Name = "可见性";
            columnHeader.Width = 60;
            listView1.Columns.Add(columnHeader);


            columnHeader = new ColumnHeader();
            columnHeader.Text = "类库文件";
            columnHeader.Name = "类库文件";
            columnHeader.Width = 200;
            listView1.Columns.Add(columnHeader);

            //columnHeader = new ColumnHeader();
            //columnHeader.Text = "状态";
            //columnHeader.Name = "状态";
            //columnHeader.Width = 60;
            //listQueue.Columns.Add(columnHeader);

            //columnHeader = new ColumnHeader();
            //columnHeader.Text = "备注";
            //columnHeader.Name = "备注";
            //columnHeader.Width = 200;
            //listQueue.Columns.Add(columnHeader);

            listView1.View = View.Details;
        }

        static private frmControlManager _controlManager = null;
        static public void ShowControlManager(BizMainLayout bizMain, DesignControlInstances dynamicControls)
        {
            try
            {
                if (_controlManager == null)
                {
                    _controlManager = new frmControlManager();

                }

                if (_controlManager.IsHandleCreated == false)
                {
                    _controlManager = new frmControlManager();
                }

                _controlManager.ShowManager(bizMain, dynamicControls, bizMain);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, bizMain);
            }
        }

        static public bool InFormCursor(Point cursorPoint)
        {
            if (_controlManager == null) return false;
            if (_controlManager.IsHandleCreated == false) return false;

            Rectangle rectWindow = _controlManager.DesktopBounds;
           
            if (cursorPoint.X >= rectWindow.Left 
                && cursorPoint.X <= rectWindow.Right
                && cursorPoint.Y >= rectWindow.Top 
                && rectWindow.Y <= rectWindow.Bottom)
            {
                return true;
            }

            return false;
        }

        private void frmControlManager_Load(object sender, EventArgs e)
        {
            try
            {
                InitControlList();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 清除选择的元素
        /// </summary>
        private void ClearSelectionElements()
        {
            if (_bizMain.layoutWork.CustomizationForm != null)
            {
                _bizMain.layoutWork.Root.ClearSelection();
                _bizMain.layoutWork.Refresh();
            }

            if (_bizMain.layoutNavigate.CustomizationForm != null)
            {
                _bizMain.layoutNavigate.Root.ClearSelection();
                _bizMain.layoutNavigate.Refresh();
            }

            if (_bizMain.layoutLeft.CustomizationForm != null)
            {
                _bizMain.layoutLeft.Root.ClearSelection();
                _bizMain.layoutLeft.Refresh();
            }

            if (_bizMain.layoutRight.CustomizationForm != null)
            {
                _bizMain.layoutRight.Root.ClearSelection();
                _bizMain.layoutRight.Refresh();
            }

            if (_bizMain.layoutBottom.CustomizationForm != null)
            {
                _bizMain.layoutBottom.Root.ClearSelection();
                _bizMain.layoutBottom.Refresh();
            }


            foreach (ListViewItem lvi in _bizMain.listView1.SelectedItems) lvi.Selected = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0 )
                {
                    propertyGrid1.SelectedObject = null;
                    return;
                }

                ClearSelectionElements();

                DesignControlInstanceInfo dci = listView1.SelectedItems[0].Tag as DesignControlInstanceInfo;

                TypeDescriptor.AddAttributes(dci, new Attribute[] { new ReadOnlyAttribute(true) });
                propertyGrid1.SelectedObject = dci;

                if (dci.Instance != null)
                {
                    DesignComponent dcmpt = dci.Instance as DesignComponent;

                    if (dcmpt != null)
                    {
                        //后台组件
                        ListViewItem[] lviComponents = _bizMain.listView1.Items.Find(dci.ModuleName, false);
                        if (lviComponents.Length > 0)
                        {                            
                            lviComponents[0].Selected = true;
                        }

                    }
                    else
                    {
                        DesignControl dc = dci.Instance as DesignControl;
                        if (dc != null)
                        { 
                            LayoutControl lc = dc.Parent as LayoutControl;
                            if (lc != null)
                            {
                                LayoutControlItem lci = lc.GetItemByControl(dc);

                                if (lci != null)
                                {
                                    lc.ShowCustomizationForm();

                                    lci.Selected = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                BindControlData();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("请选择需要删除的项目。", "提示");
                    return;
                }

                if (MessageBox.Show("确认删除当前所选组件吗？删除后将不能恢复。", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;

                DesignControlInstanceInfo dci = listView1.SelectedItems[0].Tag as DesignControlInstanceInfo;

                if (_bizMain.DelSelComponent(dci))
                {
                    listView1.SelectedItems[0].Remove();
                    propertyGrid1.SelectedObject = null;
                }

                labCount.Text = "组件数量:" + listView1.Items.Count;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

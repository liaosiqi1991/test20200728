using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;
using zlMedimgSystem.Design;

namespace zlMedimgSystem.CTL.Navigate
{
    public partial class frmDesign : Form
    {
        private bool _isOk = false;
        private NavModuleDesign _navDesign = null;
        public frmDesign()
        {
            InitializeComponent();
        }

        public bool ShowDesign(NavModuleDesign navDesign, IWin32Window owner)
        {
            _isOk = false;
            _navDesign = navDesign;

            this.ShowDialog(owner);

            return _isOk;
        }


        private void InitToolsList()
        {
            listView1.Clear();
            listView1.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();
            columnDefault = new ColumnHeader();
            columnDefault.Text = "名称";
            columnDefault.Name = "名称";
            columnDefault.Width = 120;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "类型";
            columnDefault.Name = "类型";
            columnDefault.Width = 80;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "图标";
            columnDefault.Name = "图标";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "标记";
            columnDefault.Name = "标记";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault); 

            listView1.View = View.Details;
        }

        private void frmDesign_Load(object sender, EventArgs e)
        {
            try
            {
                cbxButType.SelectedIndex = 0;

                chkLog.Checked = _navDesign.ButVisible.图标;
                chkCbxMenu.Checked = _navDesign.ButVisible.附加菜单;
                chkShowExit.Checked = _navDesign.ButVisible.退出按钮;

                labBkColor.Color = _navDesign.BackColor;
                labForeColor.Color = _navDesign.ForceColor;

                InitToolsList();

                LoadDesign(_navDesign);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void LoadDesign(NavModuleDesign toolsDesign)
        {
            if (toolsDesign == null) return;

            foreach (NavItemConfig tic in toolsDesign.NavItems)
            {
                AddItemToList(tic);
            }

            listView1.View = View.Details;
        }

        public string GetToolTypeAlias(NavigateType toolType)
        {
            switch ((int)toolType)
            {
                case (int)NavigateType.ntMain:
                    return "主按钮样式";

                case (int)NavigateType.ntAttach:
                    return "辅按钮样式";

                case (int)NavigateType.ntDropdown:
                    return "附加按钮样式";
                     
                default:
                    return "";
            }
        }

        private void AddItemToList(NavItemConfig tic, int insertIndex = -1)
        {
        

            ListViewItem itemNew = new ListViewItem(new string[] {tic.Name,
                                                                GetToolTypeAlias(tic.Style),
                                                                tic.IconName,
                                                                tic.Tag}, 0);

            itemNew.Tag = tic;
            itemNew.Name = tic.Name;


            if (insertIndex <= 0)
            {
                listView1.Items.Add(itemNew);
            }
            else
            {
                listView1.Items.Insert(insertIndex, itemNew);
            }
             
        }

        private string GetNavigateStyle(NavigateType style)
        {
            switch (style)
            {
                case NavigateType.ntMain:
                    return "导航类型";
                case NavigateType.ntAttach:
                    return "附加类型";
                case NavigateType.ntDropdown:
                    return "下拉类型";
                default:
                    return "快捷类型";
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("按钮名称不允许为空。");
                    return;
                }

                NavItemConfig newItem = new NavItemConfig();

                UpdateToolItem(newItem);

                AddItemToList(newItem);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void UpdateToolItem(NavItemConfig toolItem)
        {
            toolItem.Name = txtName.Text;
            toolItem.Style = (NavigateType)cbxButType.SelectedIndex;
            toolItem.IconName = txtImgName.Text; 
            toolItem.Tag = txtButTag.Text;
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("请选择需要删除的项目。", "提示");
                    return;
                }


                DialogResult dr = MessageBox.Show("确认删除改项目吗", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;

                ListViewItem delItem = listView1.SelectedItems[0];
                
                delItem.Remove();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void chkLog_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _navDesign.ButVisible.图标 = chkLog.Checked;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void chkCbxMenu_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _navDesign.ButVisible.附加菜单 = chkCbxMenu.Checked;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void chkShowExit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _navDesign.ButVisible.退出按钮 = chkShowExit.Checked;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butLoadImg_Click(object sender, EventArgs e)
        {
            try
            {
                txtImgName.Text = Img24Resource.ShowImgResourcesSelector(this);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0) return;

                ListViewItem lvi = listView1.SelectedItems[0];

                NavItemConfig tic = lvi.Tag as NavItemConfig;

                txtName.Text = tic.Name;
                txtImgName.Text = tic.IconName;
                cbxButType.SelectedIndex = (int)tic.Style; 
                txtButTag.Text = tic.Tag; 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0) return;

                ListViewItem lvi = listView1.SelectedItems[0];

                NavItemConfig tic = lvi.Tag as NavItemConfig;

                UpdateToolItem(tic);

                int index = lvi.Index;
                listView1.Items.Remove(lvi);

                AddItemToList(tic, index);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                _navDesign.BackColor = labBkColor.Color;
                _navDesign.ForceColor = labForeColor.Color;

                _navDesign.ButVisible.图标 = chkLog.Checked;
                _navDesign.ButVisible.附加菜单 = chkCbxMenu.Checked;
                _navDesign.ButVisible.退出按钮 = chkShowExit.Checked;

                _navDesign.NavItems.Clear();
                foreach (ListViewItem lvi in listView1.Items)
                {
                    _navDesign.NavItems.Add(lvi.Tag as NavItemConfig);
                }

                _isOk = true;

                this.Close();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
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
 
    }
}

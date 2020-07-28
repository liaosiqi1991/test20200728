using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.Design
{
    public partial class frmRClickMenuEditor : Form
    {
 
        private bool _isOk = false;
        private ModuleMenus _rMenus = null;
        public frmRClickMenuEditor()
        {
            InitializeComponent();
        }

        public bool ShowDesign(ModuleMenus rclickMenus, IWin32Window owner)
        {
            _rMenus = rclickMenus;

            this.ShowDialog(owner);

            return _isOk;
        }

        private void InitMenuList()
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
            columnDefault.Text = "图标";
            columnDefault.Name = "图标";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "菜单热键";
            columnDefault.Name = "菜单热键";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);


            listView1.View = View.Details;
        }


        private void AddItemToList(ModuleMenuInfo menuInfo)
        {

            int pIndex = -1;
            string caption = "";

            if (string.IsNullOrEmpty(menuInfo.ParentName) == false)
            {
                pIndex = listView1.Items.IndexOfKey(menuInfo.ParentName);

                if (pIndex >= 0)
                {
                    ModuleMenuInfo tiParent = listView1.Items[pIndex].Tag as ModuleMenuInfo;
                    caption = "    " + listView1.Items[pIndex].Text.Replace(tiParent.Name, "") + menuInfo.Name;
                }
            }
            else
            {
                caption = menuInfo.Name;
            }

            ListViewItem itemNew = new ListViewItem(new string[] {caption,
                                                                menuInfo.Icon,
                                                                menuInfo.Shortcutkey
                                                                }, 0);

            itemNew.Tag = menuInfo;
            itemNew.Name = menuInfo.Name;

            if (pIndex >= 0 && pIndex + 1 <= listView1.Items.Count - 1)
            {
                listView1.Items.Insert(pIndex + 1, itemNew);
            }
            else
            {
                listView1.Items.Add(itemNew);
            }

            if (menuInfo.Name != "-")
            {
                if (cbxParentName.Items.IndexOf(menuInfo.Name) < 0)
                {
                    cbxParentName.Items.Add(menuInfo.Name);
                }
            }
        }

        private void frmRClickMenuEditor_Load(object sender, EventArgs e)
        {
            try
            {
                cbxShortcutKey.Items.Add("");
                cbxParentName.Items.Add("");

                InitMenuList();


                foreach (ModuleMenuInfo tic in _rMenus.Menus)
                {
                    AddItemToList(tic);
                }

                listView1.View = View.Details;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
 
        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ModuleMenuInfo newItem = new ModuleMenuInfo();
                
                UpdateMenuItem(newItem);

                AddItemToList(newItem);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
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

                ListViewItem delItem = listView1.SelectedItems[0];

                ModuleMenuInfo ticDel = delItem.Tag as ModuleMenuInfo;
                int nextIndex = delItem.Index + 1;

                if (nextIndex <= listView1.Items.Count - 1)
                {
                    ModuleMenuInfo ticNext = listView1.Items[nextIndex].Tag as ModuleMenuInfo;

                    if (string.IsNullOrEmpty(ticNext.ParentName) == false && ticNext.ParentName == ticDel.Name)
                    {
                        MessageBox.Show("存在子项，不允许删除。", "提示");
                        return;
                    }
                }

                DialogResult dr = MessageBox.Show("确认删除改项目吗", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;



                delItem.Remove();

            }
            catch (Exception ex)
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

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                _rMenus.Menus.Clear();
                 

                foreach (ListViewItem lvi in listView1.Items)
                {
                    _rMenus.Menus.Add(lvi.Tag as ModuleMenuInfo);
                }

                _isOk = true;

                this.Close();
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
            catch(Exception ex)
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

                ModuleMenuInfo mmInfo = lvi.Tag as ModuleMenuInfo;

                txtName.Text = mmInfo.Name;
                txtImgName.Text = mmInfo.Icon;
                cbxShortcutKey.Text = mmInfo.Shortcutkey; 
                
                cbxParentName.Text = mmInfo.ParentName;
                txtButTag.Text = mmInfo.Tag;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void UpdateMenuItem(ModuleMenuInfo mmInfo)
        {
            mmInfo.Name = txtName.Text; 
            mmInfo.Icon = txtImgName.Text;
            mmInfo.Shortcutkey = cbxShortcutKey.Text; 
            mmInfo.ParentName = cbxParentName.Text;
            mmInfo.Tag = txtButTag.Text;
        }

        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0) return;

                ListViewItem lvi = listView1.SelectedItems[0];

                ModuleMenuInfo tic = lvi.Tag as ModuleMenuInfo;

                UpdateMenuItem(tic);

                listView1.Items.Remove(lvi);

                AddItemToList(tic);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

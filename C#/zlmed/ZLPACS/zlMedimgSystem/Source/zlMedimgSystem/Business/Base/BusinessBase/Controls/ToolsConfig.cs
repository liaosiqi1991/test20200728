using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;
using zlMedimgSystem.Design;

namespace zlMedimgSystem.BusinessBase.Controls
{
    public partial class ToolsConfig : UserControl
    { 
        private ToolsDesign _toolsDesign = null;
        public ToolsConfig()
        {
            InitializeComponent();
        }

        public void InitToolDesign(ToolsDesign toolDesign)
        {
            _toolsDesign = toolDesign;              
        }

        public ToolsDesign ToolsDesign
        {
            get { return _toolsDesign; }
            set
            {
                _toolsDesign = value;

                LoadDesign(_toolsDesign);
            }
        }

        public void ApplyUpdate()
        {
            _toolsDesign.ToolsCfg.Clear();

            _toolsDesign.Visible = chkShowTools.Checked;
            _toolsDesign.Size = Convert.ToInt32(txtToolSize.Text);
            _toolsDesign.BackColor = labBkColor.Color;
            _toolsDesign.ForceColor = labForeColor.Color;

            _toolsDesign.LayoutStyle = (ToolLayout)cbxToolsStyle.SelectedIndex;

            foreach (ListViewItem lvi in listView1.Items)
            {
                _toolsDesign.ToolsCfg.Add(lvi.Tag as ToolItemConfig);
            }
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
            columnDefault.Text = "图标位置";
            columnDefault.Name = "图标位置";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "显示样式";
            columnDefault.Name = "显示样式";
            columnDefault.Width = 80;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "靠右对齐";
            columnDefault.Name = "靠右对齐";
            columnDefault.Width = 80;
            listView1.Columns.Add(columnDefault);

            listView1.View = View.Details;
        }


        private void AddItemToList(ToolItemConfig tic)
        {

            int pIndex = -1;
            string caption = "";

            if (string.IsNullOrEmpty(tic.父级名称) == false)
            {
                pIndex = listView1.Items.IndexOfKey(tic.父级名称);

                if (pIndex >= 0)
                {
                    ToolItemConfig tiParent = listView1.Items[pIndex].Tag as ToolItemConfig;
                    caption = "    " + listView1.Items[pIndex].Text.Replace(tiParent.名称, "") + tic.名称;
                }
            }
            else
            {
                caption = tic.名称;
            }

            ListViewItem itemNew = new ListViewItem(new string[] {caption,
                                                                GetToolTypeAlias(tic.按钮类型),
                                                                tic.图标,
                                                                GetToolIconStyleAlias(tic.图标位置),
                                                                GetDisplayStyleAlias(tic.显示样式),
                                                                (tic.右对齐)?"√":"" }, 0);

            itemNew.Tag = tic;
            itemNew.Name = tic.名称;

            if (pIndex >= 0 && pIndex + 1 <= listView1.Items.Count - 1)
            {
                listView1.Items.Insert(pIndex + 1, itemNew);
            }
            else
            {
                listView1.Items.Add(itemNew);
            }

            if (tic.按钮类型 == ToolType.ttDrowDownButton)
            {
                if (cbxParentName.Items.IndexOf(tic.名称) < 0)
                {
                    cbxParentName.Items.Add(tic.名称);
                }
            }
        }

        private void ToolsConfig_Load(object sender, EventArgs e)
        {
            try
            {

                cbxParentName.Items.Add("");
                cbxButType.SelectedIndex = 1;
                cbxDisplyStyle.SelectedIndex = 0;
                cbxIconPostion.SelectedIndex = 1;

                InitToolsList();

                LoadDesign(_toolsDesign);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void LoadDesign(ToolsDesign toolsDesign)
        {
            if (toolsDesign == null) return;

            txtToolSize.Text = Convert.ToString(toolsDesign.Size);

            cbxToolsStyle.SelectedIndex = (int)toolsDesign.LayoutStyle;
            labBkColor.Color = toolsDesign.BackColor;
            labForeColor.Color = toolsDesign.ForceColor;

            chkShowTools.Checked = toolsDesign.Visible;
                        

            foreach (ToolItemConfig tic in toolsDesign.ToolsCfg)
            {
                AddItemToList(tic);
            }

            listView1.View = View.Details;
        }

        public string GetDisplayStyleAlias(ToolDisplayStyle displayStyle)
        {
            switch (displayStyle)
            {
                case ToolDisplayStyle.tdsText:
                    return "仅文本";

                case ToolDisplayStyle.tdsImage:
                    return "仅图像";

                case ToolDisplayStyle.tdsTextAndImage:
                    return "文本和图像";

                default:
                    return "";
            }
        }

        public string GetToolTypeAlias(ToolType toolType)
        {
            switch ((int)toolType)
            {
                case (int)ToolType.ttLabel:
                    return "文本";

                case (int)ToolType.ttButton:
                    return "按钮";

                case (int)ToolType.ttDrowDownButton:
                    return "下拉";

                case (int)ToolType.ttSeparator:
                    return "分割";

                default:
                    return "";
            }
        }


        public string GetToolIconStyleAlias(ToolIconStyle toolIconStyle)
        {
            switch ((int)toolIconStyle)
            {
                case (int)ToolIconStyle.tisImageAboveText:
                    return "文本上部";

                case (int)ToolIconStyle.tisTextAboveImage:
                    return "文本下部";

                case (int)ToolIconStyle.tisImageBeforeText:
                    return "文本左侧";

                case (int)ToolIconStyle.tisTextBeforeImage:
                    return "文本右侧";

                default:
                    return "";
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ToolItemConfig newItem = new ToolItemConfig();

                UpdateToolItem(newItem); 

                AddItemToList(newItem);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void UpdateToolItem(ToolItemConfig toolItem)
        {
            toolItem.名称 = txtName.Text;
            toolItem.按钮类型 = (ToolType)cbxButType.SelectedIndex;
            toolItem.图标 = txtImgName.Text;
            toolItem.图标位置 = (ToolIconStyle)cbxIconPostion.SelectedIndex;
            toolItem.显示样式 = (ToolDisplayStyle)cbxDisplyStyle.SelectedIndex;
            toolItem.右对齐 = chkRight.Checked;
            toolItem.父级名称 = cbxParentName.Text;
            toolItem.标记 = txtButTag.Text;
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

                ToolItemConfig ticDel = delItem.Tag as ToolItemConfig;
                int nextIndex = delItem.Index + 1;

                if (nextIndex <= listView1.Items.Count - 1)
                {
                    ToolItemConfig ticNext = listView1.Items[nextIndex].Tag as ToolItemConfig;

                    if (string.IsNullOrEmpty(ticNext.父级名称) == false && ticNext.父级名称 == ticDel.名称)
                    {
                        MessageBox.Show("存在子项，不允许删除。", "提示");
                        return;
                    }
                }

                DialogResult dr = MessageBox.Show("确认删除改项目吗", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;


                if (ticDel != null && ticDel.按钮类型 == ToolType.ttDrowDownButton)
                {
                    cbxParentName.Items.Remove(ticDel.名称);
                }

                delItem.Remove();

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

                ToolItemConfig tic = lvi.Tag as ToolItemConfig;

                txtName.Text = tic.名称;
                txtImgName.Text = tic.图标;
                cbxButType.SelectedIndex = (int)tic.按钮类型;
                cbxDisplyStyle.SelectedIndex = (int)tic.显示样式;
                txtButTag.Text = tic.标记;
                cbxParentName.Text = tic.父级名称;
                cbxIconPostion.SelectedIndex = (int)tic.图标位置;
                chkRight.Checked = tic.右对齐; 
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

                ToolItemConfig tic = lvi.Tag as ToolItemConfig;
                
                UpdateToolItem(tic);
                
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

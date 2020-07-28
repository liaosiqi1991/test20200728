using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Design;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Summary
{
    public partial class frmSelectField : Form
    {
        private string _formatContext = "";
        private DesignLabelFormats _formats = null;
        public frmSelectField()
        {
            InitializeComponent();

            _formats = new DesignLabelFormats();
        }

        public string ShowDataNameEditor(string format, IWin32Window owner)
        {
            _formatContext = format;
            _formats = JsonHelper.DeserializeObject<DesignLabelFormats>(format);

            this.ShowDialog(owner);

            return _formatContext;
        }

        private void InitFormatItemList()
        {
            listView1.Clear();
            listView1.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();
            columnDefault = new ColumnHeader();
            columnDefault.Text = "数据值";
            columnDefault.Name = "数据值";
            columnDefault.Width = 120;
            listView1.Columns.Add(columnDefault);


            columnDefault = new ColumnHeader();
            columnDefault.Text = "显示值";
            columnDefault.Name = "显示值";
            columnDefault.Width = 120;
            listView1.Columns.Add(columnDefault);


            columnDefault = new ColumnHeader();
            columnDefault.Text = "图标";
            columnDefault.Name = "图标";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "背景色";
            columnDefault.Name = "背景色";
            columnDefault.Width = 60;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "前景色";
            columnDefault.Name = "前景色";
            columnDefault.Width = 60;
            listView1.Columns.Add(columnDefault);

            //columnDefault = new ColumnHeader();
            //columnDefault.Text = "靠右对齐";
            //columnDefault.Name = "靠右对齐";
            //columnDefault.Width = 80;
            //listView1.Columns.Add(columnDefault);

            listView1.View = View.Details;
        }

 
        private void frmSelectField_Load(object sender, EventArgs e)
        {
            //colorDialog1.CustomColors = new int[] {Color.Transparent.ToArgb(), SystemColors.Control.ToArgb()  };

            if (GlobalDB.DBSource != null)
            {
                if (string.IsNullOrEmpty(GlobalDB.DBSource.查询语句) == false)
                {
                    string pars = SqlHelper.GetSqlPars(GlobalDB.DBSource.查询语句);
                    DataTable dtTest = SqlHelper.TestSql(GlobalDB.DBHelper, GlobalDB.DBSource.查询语句, pars, GlobalDB.DBSource.数据源别名, this);

                    foreach (DataColumn dc in dtTest.Columns)
                    {
                        cbxDbName.Items.Add(dc.ColumnName);
                    }
                }
            }

            labBkColor.Color = _formats.默认背景色;

            if (_formats.默认前景色.Name == "0")
            {
                labForeColor.BackColor = Color.Black;
            }
            else
            {
                labForeColor.Color = _formats.默认前景色;
            }

            InitFormatItemList();

            LoadDesign(_formats);
            
        }

        private void LoadDesign(DesignLabelFormats formats)
        {
            if (formats == null) return;

            cbxDbName.Text = formats.数据项名称;
             
            foreach (DesignLabelFormatItem fi in formats.文本格式)
            {
                AddItemToList(fi);
            }

            listView1.View = View.Details;
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                if (_formats == null) _formats = new DesignLabelFormats();

                _formats.数据项名称 = cbxDbName.Text;

                _formats.文本格式.Clear(); 

                foreach (ListViewItem lvi in listView1.Items)
                {
                    _formats.文本格式.Add(lvi.Tag as DesignLabelFormatItem);
                }

                _formatContext = JsonHelper.SerializeObject(_formats);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DesignLabelFormatItem newItem = new DesignLabelFormatItem();

                UpdateFormatItem(newItem);

                AddItemToList(newItem);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void AddItemToList(DesignLabelFormatItem fi)
        {

            ListViewItem itemNew = new ListViewItem(new string[] {fi.数据值,
                                                                fi.显示内容,
                                                                fi.图标名称,
                                                                "",
                                                                ""}, 0);

            itemNew.UseItemStyleForSubItems = false;

            itemNew.Tag = fi;
            itemNew.Name = fi.数据值;

            itemNew.SubItems[3].BackColor = fi.背景色;
            itemNew.SubItems[4].BackColor = fi.前景色;

            listView1.Items.Add(itemNew); 
        }

        private void UpdateFormatItem(DesignLabelFormatItem formatItem)
        {
            formatItem.数据值 = txtValue.Text;
            formatItem.显示内容 = txtDisplayValue.Text;
            formatItem.图标名称 = txtImgName.Text;
            formatItem.背景色 = labBkColor.Color;
            formatItem.前景色 = labForeColor.Color; 
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
 
                DialogResult dr = MessageBox.Show("确认删除改项目吗", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;

 
                delItem.Remove();

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

                DesignLabelFormatItem fi = lvi.Tag as DesignLabelFormatItem;

                UpdateFormatItem(fi);

                lvi.Text = fi.数据值;
                lvi.SubItems[1].Text = fi.显示内容;
                lvi.SubItems[2].Text = fi.图标名称;
                lvi.SubItems[3].BackColor = fi.背景色;
                lvi.SubItems[4].BackColor = fi.前景色;
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

                DesignLabelFormatItem fi = lvi.Tag as DesignLabelFormatItem;

                txtValue.Text = fi.数据值;
                txtDisplayValue.Text = fi.显示内容;
                txtImgName.Text = fi.图标名称;
                labBkColor.Color = fi.背景色;
                labForeColor.Color = fi.前景色;
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
         
    }
}

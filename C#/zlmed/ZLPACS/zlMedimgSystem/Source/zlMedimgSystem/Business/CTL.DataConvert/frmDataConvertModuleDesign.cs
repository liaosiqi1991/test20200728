using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.DataConvert
{
    public partial class frmDataConvertModuleDesign : Form
    {
        private bool _isOk = false;
        private DataConvertModuleDesign _dataConvertDesign = null;
        public frmDataConvertModuleDesign()
        {
            InitializeComponent();
        }

        public bool ShowDataConvertModuleDesign(DataConvertModuleDesign dataConvertDesign , IWin32Window owner)
        {
            _isOk = false;
            _dataConvertDesign = dataConvertDesign;

            this.ShowDialog(owner);

            return _isOk;
        }

        private bool Vertify(bool isNew)
        {
            int sourceIndex = listView1.Items.IndexOfKey(txtSourceName.Text);

            int convertIndex = -1;
            foreach (ListViewItem lvi in listView1.Items)
            {
                if (lvi.SubItems[1].Text == txtConvertName.Text)
                {
                    convertIndex = lvi.Index;
                    break;
                } 
            }

            if (isNew)
            {
                
                if (sourceIndex >= 0)
                {
                    MessageBox.Show("该数据项已配置转换，不能重复添加。", "提示");
                    return false;
                }


                
                if (convertIndex >= 0)
                {
                    MessageBox.Show("转换后名称已经存在，不能重复添加。", "提示");
                    return false;
                }
            }
            else
            {
                if (listView1.SelectedItems.Count <=0)
                {
                    MessageBox.Show("尚未选择需要更新的项目。", "提示");
                    return false;
                }

                if (sourceIndex >= 0 && listView1.SelectedItems[0].Index != sourceIndex)
                {
                    MessageBox.Show("该数据项已配置转换，不能重复添加。", "提示");
                    return false;
                }

                if (convertIndex >= 0 &&  listView1.SelectedItems[0].Index != convertIndex)
                {
                    MessageBox.Show("转换后名称已经存在，不能重复添加。", "提示");
                    return false;
                }
            }

            return true;

        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (Vertify(true) == false) return;

                DataConvertItem dci = new DataConvertItem();

                dci.SourceName = txtSourceName.Text;
                dci.ConvertName = txtConvertName.Text;
                dci.ConvertType = cbxConvertType.Text;

                NewListViewItem(dci);
               
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void NewListViewItem(DataConvertItem dci)
        {
            ListViewItem lvi = new ListViewItem(new string[] { dci.SourceName, dci.ConvertName, dci.ConvertType });
            lvi.Name = dci.SourceName;

            listView1.Items.Add(lvi);

            lvi.Tag = dci;

        }


        private void UpdateListViewItem(DataConvertItem dci)
        {
            ListViewItem lvi = listView1.SelectedItems[0];
            lvi.Name = dci.SourceName;
        

            lvi.Text = dci.SourceName;
            lvi.SubItems[1].Text = dci.ConvertName;
            lvi.SubItems[2].Text = dci.ConvertType;

            listView1.Items.Add(lvi);

            lvi.Tag = dci;

        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (Vertify(false) == false) return;

                DataConvertItem dci = listView1.SelectedItems[0].Tag as DataConvertItem;

                dci.SourceName = txtSourceName.Text;
                dci.ConvertName = txtConvertName.Text;
                dci.ConvertType = cbxConvertType.Text;

                UpdateListViewItem(dci);
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
                if (listView1.SelectedItems.Count <= 0) return;

                listView1.Items.Remove(listView1.SelectedItems[0]);
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

        private void InitList()
        {
            ColumnHeader columnHeaderDate = new ColumnHeader();
            columnHeaderDate.Text = "源数据名称";
            columnHeaderDate.Name = "源数据名称";
            columnHeaderDate.Width = 120;
            listView1.Columns.Add(columnHeaderDate);

            columnHeaderDate = new ColumnHeader();
            columnHeaderDate.Text = "转换后名称";
            columnHeaderDate.Name = "转换后名称";
            columnHeaderDate.Width = 120;
            listView1.Columns.Add(columnHeaderDate);

            columnHeaderDate = new ColumnHeader();
            columnHeaderDate.Text = "转换后类型";
            columnHeaderDate.Name = "转换后类型";
            columnHeaderDate.Width = 120;
            listView1.Columns.Add(columnHeaderDate);
        }


        private void frmDataConvertModuleDesign_Load(object sender, EventArgs e)
        {
            try
            {
                string[] types = new string[] {typeof(Int16).Name,
                                                typeof(Int32).Name,
                                                typeof(Int64).Name,
                                                typeof(Double).Name,
                                                typeof(Single).Name,
                                                typeof(Decimal).Name,
                                                typeof(String).Name,
                                                typeof(DateTime).Name, 
                                                typeof(Boolean).Name,
                                                typeof(Byte).Name,
                                                typeof(Char).Name
                         };


                //初始化转换类型
                cbxConvertType.Items.Clear();
                foreach(string typeName in types)
                {
                    cbxConvertType.Items.Add(typeName);
                }


                listView1.Clear();

                //初始化列表
                InitList();                               

                foreach(DataConvertItem dci in _dataConvertDesign.ConvertItems)
                {
                    NewListViewItem(dci);
                }

                listView1.View = View.Details;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                _dataConvertDesign.ConvertItems.Clear();

                foreach(ListViewItem lvi in listView1.Items)
                {
                    _dataConvertDesign.ConvertItems.Add((lvi.Tag as DataConvertItem).Clone());
                }

                _isOk = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.TestData
{
    public partial class frmDataConstructor : Form
    {
        private bool _isOk = false;
        private List<TestDataItem> _testDatas = null;
        public frmDataConstructor()
        {
            InitializeComponent();
        }

        public bool ShowDesign(List<TestDataItem> testDatas, IWin32Window owner)
        {
            _testDatas = testDatas;

            this.ShowDialog(owner);

            return _isOk;
        }

        private void InitMenuList()
        {
            listView1.Clear();
            listView1.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();
            columnDefault = new ColumnHeader();
            columnDefault.Text = "数据项名称";
            columnDefault.Name = "数据项名称";
            columnDefault.Width = 120;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "类型";
            columnDefault.Name = "类型";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "模拟数据值";
            columnDefault.Name = "模拟数据值";
            columnDefault.Width = 300;
            listView1.Columns.Add(columnDefault); 
            
            listView1.View = View.Details;
        }


        private void AddItemToList(TestDataItem itemInfo)
        {

            ListViewItem itemNew = new ListViewItem(new string[] {itemInfo.数据名称,
                                                                itemInfo.数据类型,
                                                                itemInfo.数据内容
                                                                }, 0);
            itemNew.Tag = itemInfo;
            itemNew.Name = itemInfo.数据名称;

            listView1.Items.Add(itemNew);
        }
                
        private void frmDataConstructor_Load(object sender, EventArgs e)
        {
            try
            {
                cbxType.SelectedIndex = 0;
 
                InitMenuList();


                foreach (TestDataItem di in _testDatas)
                {
                    AddItemToList(di);
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
                TestDataItem dataItem = new TestDataItem();

                dataItem.数据名称 = txtName.Text;
                dataItem.数据类型 = cbxType.Text;
                dataItem.数据内容 = txtValue.Text;
                
                AddItemToList(dataItem);
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
                 
                DialogResult dr = MessageBox.Show("确认删除该项目吗", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;


                ListViewItem delItem = listView1.SelectedItems[0];
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
                _testDatas.Clear();


                foreach (ListViewItem lvi in listView1.Items)
                {
                    _testDatas.Add(lvi.Tag as TestDataItem); 
                }

                _isOk = true;

                this.Close();
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

                TestDataItem tdi = lvi.Tag as TestDataItem;

                txtName.Text = tdi.数据名称;
                cbxType.Text = tdi.数据类型;
                txtValue.Text = tdi.数据内容;
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

                TestDataItem di = lvi.Tag as TestDataItem;

                di.数据名称 = txtName.Text;
                di.数据类型 = cbxType.Text;
                di.数据内容 = txtValue.Text;

                lvi.Name = di.数据名称;
                lvi.Text = di.数据名称;
                lvi.SubItems[1].Text = di.数据类型;
                lvi.SubItems[2].Text = di.数据内容;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxType.SelectedIndex == 0)
                {
                    butDicts.Visible = false;
                    txtValue.ReadOnly = false;
                }
                else
                {
                    butDicts.Visible = true;
                    txtValue.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butDicts_Click(object sender, EventArgs e)
        {
            try
            {
                frmDictData dictDatas = new frmDictData();

                Dictionary<string, string> dicts = null;

                if (string.IsNullOrEmpty(txtValue.Text) == false)
                {
                    try
                    {
                        dicts = DictionaryJsonHelper.DeserializeStringToDictionary<string, string>(txtValue.Text);
                    }
                    catch
                    {
                        dicts = null;
                    }
                }

                dicts = dictDatas.ShowDictConstructor(dicts, this);
                if (dicts == null) return;

                txtValue.Text = DictionaryJsonHelper.SerializeDictionaryToJsonString<string, string>(dicts);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

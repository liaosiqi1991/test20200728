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
    public partial class frmDictData : Form
    {
        private Dictionary<string, string> _datas = null;
        public frmDictData()
        {
            InitializeComponent();
        }

        public Dictionary<string, string> ShowDictConstructor(Dictionary<string, string> datas, IWin32Window owner)
        {
            _datas = datas;
            this.ShowDialog(owner);

            return _datas;
        }
        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void InitMenuList()
        {
            listView1.Clear();
            listView1.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();
            columnDefault = new ColumnHeader();
            columnDefault.Text = "字典项名称";
            columnDefault.Name = "字典项名称";
            columnDefault.Width = 120;
            listView1.Columns.Add(columnDefault);
             

            columnDefault = new ColumnHeader();
            columnDefault.Text = "字典项内容";
            columnDefault.Name = "字典项内容";
            columnDefault.Width = 300;
            listView1.Columns.Add(columnDefault);

            listView1.View = View.Details;
        }


        private void frmDictData_Load(object sender, EventArgs e)
        {
            try
            {
                listView1.Clear();

                InitMenuList();

                if (_datas == null) return;

                foreach(KeyValuePair<string,string> kv in _datas)
                {
                    AddItemToList(kv.Key, kv.Value);
                }

                listView1.View = View.Details;
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

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddItemToList(txtName.Text, txtValue.Text);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void AddItemToList(string itemName, string itemValue)
        {

            ListViewItem itemNew = new ListViewItem(new string[] {itemName,
                                                                itemValue
                                                                }, 0);

            itemNew.Tag = itemName;
            itemNew.Name = itemName;

            listView1.Items.Add(itemNew);
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                if (_datas == null) _datas = new Dictionary<string, string>();

                _datas.Clear();


                foreach (ListViewItem lvi in listView1.Items)
                {
                    _datas.Add(lvi.Name, lvi.SubItems[1].Text);
                }
                 
                this.Close();
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
                lvi.Name = txtName.Text;
                lvi.Text = txtName.Text;
                lvi.SubItems[1].Text = txtValue.Text;
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
                
                txtName.Text = lvi.Text; 
                txtValue.Text = lvi.SubItems[1].Text;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

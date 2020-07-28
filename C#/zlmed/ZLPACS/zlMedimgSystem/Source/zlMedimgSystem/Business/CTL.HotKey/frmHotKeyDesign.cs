using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.HotKey
{
    public partial class frmHotKeyDesign : Form
    {
        private bool _isOk = false;
        private HotKeys _hotKeys = null;
        public frmHotKeyDesign()
        {
            InitializeComponent();
        }

        public bool ShowDesign(HotKeys hotKeys, IWin32Window owner)
        {
            _hotKeys = hotKeys;

            this.ShowDialog(owner);

            return _isOk;
        }

        private void InitMenuList()
        {
            listView1.Clear();
            listView1.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();
            columnDefault = new ColumnHeader();
            columnDefault.Text = "别名";
            columnDefault.Name = "别名";
            columnDefault.Width = 120;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "功能键";
            columnDefault.Name = "功能键";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "字符键";
            columnDefault.Name = "字符键";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);


            listView1.View = View.Details;
        }

        private string GetFuncKeyAlias(KeyFlags keyFlag)
        {
            switch(keyFlag)
            {
                case KeyFlags.MOD_ALT:
                    return "ALT";

                case KeyFlags.MOD_CONTROL:
                    return "CTRL";

                case KeyFlags.MOD_SHIFT:
                    return "SHIFT";

                default:
                    return "";
            }
        }

        private string GetCharKeyAlias(Keys charKey)
        {
            int key = (int)charKey;
            if (key >= 48 && key <= 57 )
            {
                return (key - 48).ToString();
            }

            if (key >= 65 && key <= 90)
            {
                return Convert.ToChar(key).ToString();
            }

            if (key >= 112 && key <= 123)
            {
                return Enum.GetName(charKey.GetType(), charKey);
            }


            return "";

        }

        private void AddItemToList(KeyItemInfo keyInfo)
        {


            ListViewItem itemNew = new ListViewItem(new string[] {keyInfo.Alias,
                                                                GetFuncKeyAlias(keyInfo.FuncKey),
                                                                GetCharKeyAlias(keyInfo.CharKey),
                                                                }, 0);

            itemNew.Tag = keyInfo;
            itemNew.Name = keyInfo.Alias;


            listView1.Items.Add(itemNew);
        }

        private void frmHotKeyDesign_Load(object sender, EventArgs e)
        {
            try
            {
                cbxFuncKey.Items.Insert(0, ""); 

                InitMenuList();


                foreach (KeyItemInfo keyItem in _hotKeys.keys)
                {
                    AddItemToList(keyItem);
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
                KeyItemInfo newItem = new KeyItemInfo();

                newItem.FuncKey = (KeyFlags)cbxFuncKey.SelectedIndex;
                if (string.IsNullOrEmpty(cbxCharKey.Text) == false)
                {
                    if (cbxCharKey.Text.Length >= 2)
                    {
                        newItem.CharKey = (Keys)Enum.Parse(typeof(Keys), cbxCharKey.Text);
                    }
                    else
                    {
                        newItem.CharKey = (Keys)((int)cbxCharKey.Text.ToCharArray()[0]);
                    }
                }

                if (newItem.FuncKey != KeyFlags.MOD_NONE)
                {
                    newItem.Alias = GetFuncKeyAlias(newItem.FuncKey) + "+" + GetCharKeyAlias(newItem.CharKey);
                }
                else
                {
                    newItem.Alias = GetCharKeyAlias(newItem.CharKey);
                }

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
                _hotKeys.keys.Clear();


                foreach (ListViewItem lvi in listView1.Items)
                {
                    _hotKeys.keys.Add(lvi.Tag as KeyItemInfo);
                }

                _isOk = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

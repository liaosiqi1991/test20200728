using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmWordConstruct : Form
    {
        private bool _isOk = false;
        private bool _isModify = false;
        private ReportWordsInfoData _wordData = null;
        private bool _isBinding = false;
        private bool _isReadContext = false;

        private IDBQuery _dbHelper = null;
        private ReportWordsModel _rwm = null;


 
        public bool IsModify
        {
            get { return _isModify; }
            set
            {
                _isModify = value;
                tsbSave.Enabled = _isModify;
            }
        }

        public frmWordConstruct()
        {
            InitializeComponent();
        }

        public bool ShowWordConstruct(ReportWordsInfoData wordData, IDBQuery dbHelper, IWin32Window owner)
        {
            _isOk = false;
            _wordData = wordData;
            _dbHelper = dbHelper;

            _rwm = new ReportWordsModel(dbHelper);

            this.ShowDialog(owner);

            return _isOk;
        }

        private void InitList()
        { 

            lvFreeList.Clear();
            lvFreeList.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();
            columnDefault = new ColumnHeader();
            columnDefault.Text = "段落名称";
            columnDefault.Name = "段落名称";
            columnDefault.Width = 120;
        
            lvFreeList.Columns.Add(columnDefault);


            lvFreeList.View = View.Details;
        }

        /// <summary>
        /// 绑定段落
        /// </summary>
        private void BindSections()
        {
            _isBinding = true;
            try
            {
                InitList(); 

                DataTable dtField = _rwm.GetSectionNames();

                ListViewItem itemFree = new ListViewItem(new string[] { "共用词句" }, 1);
                itemFree.SubItems[0].Name = "段落名称";
                lvFreeList.Items.Add(itemFree);

                foreach (DataRow dr in dtField.Rows)
                {
                    string fName = dr["COLUMN_NAME"].ToString(); 

                    ListViewItem itemNew = new ListViewItem(new string[] { fName }, 0);

                    itemNew.SubItems[0].Name = "段落名称"; 

                    lvFreeList.Items.Add(itemNew);
                }

                lvFreeList.View = View.Details;
            }
            finally
            {
                _isBinding = false;
            }

        }

        /// <summary>
        /// 读取词句内容
        /// </summary>
        private void ReadWordContext()
        {
            if (_wordData.词句信息 == null || _wordData.词句信息.词句明细.Count <= 0) return;

            tsCbxType.SelectedIndex = _wordData.词句信息.词句类型;

            foreach (JReportWordSection wordSection in _wordData.词句信息.词句明细)
            {
                ListViewItem lvi  = lvFreeList.FindItemWithText(wordSection.段落名称);

                if (lvi!= null)
                {
                    lvi.Checked = true;
                    lvi.Tag = wordSection;
                } 
            }
        }


        private void frmWordConstruct_Load(object sender, EventArgs e)
        {
            try
            {
                tsCbxType.SelectedIndex = 0;

                BindSections();

                ReadWordContext();

                lvFreeList.Items[0].Selected = true;
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
                _isReadContext = true;

                rtbFreeContext.Text = "";

                if (lvFreeList.SelectedItems.Count <= 0) return;

                ListViewItem lvi = lvFreeList.SelectedItems[0];

                if (lvi.Tag == null) return;

                JReportWordSection wordSection = lvi.Tag as JReportWordSection;

                rtbFreeContext.Text = wordSection.段落内容;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isReadContext = false;
            }
        }

        private void rtbFreeContext_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isBinding) return;
                if (_isReadContext) return;

                if (lvFreeList.SelectedItems.Count <= 0) return;

                ListViewItem lvi = lvFreeList.SelectedItems[0];

                if (lvi.Tag == null)
                {
                    JReportWordSection wordSection = new JReportWordSection(lvi.Text, rtbFreeContext.Text);
                    lvi.Tag = wordSection;
                }
                else
                {
                    JReportWordSection wordSection = lvi.Tag as JReportWordSection;
                    wordSection.段落内容 = rtbFreeContext.Text;
                }

                if (string.IsNullOrEmpty(rtbFreeContext.Text))
                {
                    lvi.Checked = false;
                }
                else
                {
                    lvi.Checked = true;
                }

                IsModify = true;
            }
            catch(Exception ex)
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

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_wordData == null) return;

                _wordData.词句信息.词句明细.Clear();

                _wordData.词句信息.词句类型 = tsCbxType.SelectedIndex;

                foreach(ListViewItem lvi in lvFreeList.Items)
                {
                    if (lvi.Checked)
                    {
                        JReportWordSection wordSection = lvi.Tag as JReportWordSection;

                        _wordData.词句信息.词句明细.Add(wordSection);
                    }
                }

                _rwm.UpdateWordItem(_wordData);

                IsModify = false;

                _isOk = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void lvFreeList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                if (_isBinding) return;
                if (lvFreeList.SelectedItems.Count <= 0) return;

                ListViewItem lvi = lvFreeList.SelectedItems[0];

                if (lvi.Tag == null)
                {
                    JReportWordSection wordSection = new JReportWordSection(lvi.Text, rtbFreeContext.Text);
                    lvi.Tag = wordSection;
                }

                IsModify = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsCbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isBinding) return;

                IsModify = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

using FormPart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BaseSettings
{

    public delegate void SaveReportSectionEvent(JReportTemplateSection section);
    public partial class frmReportSectionConfig : Form
    {
        public event SaveReportSectionEvent OnSaveReportSection;

        private IDBQuery _dbHelper = null;
        private JReportTemplateSection _section = null;
        private List<FormItem> _elementNames = null;

        private bool _isModify = false;

        private bool _isBinding = false;

        public bool IsModify
        {
            get { return _isModify; }
            set
            {
                _isModify = value;
                tsbSave.Enabled = value;
            }
        }

        public frmReportSectionConfig(IDBQuery dbHelper)
        {
            InitializeComponent();

            _dbHelper = dbHelper;
        }

        public void ShowSectionConfig(JReportTemplateSection section,  List<FormItem> elementNames, IWin32Window owner)
        {
            _section = section;
            _elementNames = elementNames;

            this.ShowDialog(owner);
        }

        public void LoadSections()
        {
            _isBinding = true;
            try
            {
                InitList();

                ReportTemplateModel rtm = new ReportTemplateModel(_dbHelper);

                DataTable dtField = rtm.GetSectionNames();
 
                foreach (DataRow dr in dtField.Rows)
                {
                    string fName = dr["COLUMN_NAME"].ToString();

                    bool isCheck = false;
                    string eName = "";
                    string etitle = "";

                    if (_section.段落关联信息 != null && _section.段落关联信息.Count > 0)
                    {
                        int index = _section.段落关联信息.FindIndex(T => T.报告段落名 == fName);

                        if (index >= 0)
                        {
                            etitle = _section.段落关联信息[index].段落显示名;
                            eName = _section.段落关联信息[index].模板元素名;
                            isCheck = _section.段落关联信息[index].关联存储;
                        }
                    }


                    ListViewItem itemNew = new ListViewItem(new string[] { fName, etitle, eName, ((isCheck)? "√" : "") }, 0);

                    itemNew.SubItems[0].Name = "段落名称";
                    itemNew.SubItems[1].Name = "显示名称";
                    itemNew.SubItems[2].Name = "关联元素";
                    itemNew.SubItems[3].Name = "同步保存";


                    listView1.Items.Add(itemNew); 
                }

                listView1.View = View.Details;
            }
            finally
            {
                _isBinding = false;
            }

        }


        private void InitList()
        {
            cbxElementName.SelectedIndex = -1;
            txtTitle.Text = "";

            listView1.Clear();
            listView1.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();
            columnDefault = new ColumnHeader();
            columnDefault.Text = "段落名称";
            columnDefault.Name = "段落名称";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "显示名称";
            columnDefault.Name = "显示名称";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);


            columnDefault = new ColumnHeader();
            columnDefault.Text = "关联元素";
            columnDefault.Name = "关联元素";
            columnDefault.Width = 120;
            listView1.Columns.Add(columnDefault);


            columnDefault = new ColumnHeader();
            columnDefault.Text = "同步保存";
            columnDefault.Name = "同步保存";
            columnDefault.Width = 80;
            listView1.Columns.Add(columnDefault);

            listView1.View = View.Details;
        }


        private void LoadModuleElement()
        {
            cbxElementName.Items.Add("");
            foreach (FormItem eName in _elementNames)
            {
                cbxElementName.Items.Add(eName.Name);
            }
        }

        private void frmReportSectionConfig_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSections();

                LoadModuleElement();

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private void cbxElementName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateSectionConfig();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void UpdateSectionConfig()
        {
            if (_isBinding) return;
            if (_isRead) return;
            if (listView1.SelectedItems.Count <= 0) return;

            ListViewItem lvi = listView1.SelectedItems[0];
         
            lvi.SubItems["显示名称"].Text = txtTitle.Text;
            lvi.SubItems["关联元素"].Text = cbxElementName.Text;
            lvi.SubItems["同步保存"].Text = (chkSyncSave.Checked) ? "√" : "";

            IsModify = true;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                _section.段落关联信息.Clear();

                for (int i = 0; i < listView1.Items.Count; i++)
                {

                    ListViewItem lvi = listView1.Items[i];

                    string elementName = lvi.SubItems["关联元素"].Text;
                    string sectionName = lvi.Text;

                    if (string.IsNullOrEmpty(elementName)) continue;


                    JReportSectionItem jsi = new JReportSectionItem(sectionName, elementName);


                    jsi.段落显示名 = lvi.SubItems["显示名称"].Text;

                    jsi.关联存储 = (lvi.SubItems["同步保存"].Text == "√") ? true : false;

                    _section.段落关联信息.Add(jsi);

                }
                 

                OnSaveReportSection?.Invoke(_section);

                IsModify = false;

                this.Close();
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

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateSectionConfig();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ClearSelData()
        {
            chkSyncSave.Checked = false;
            txtTitle.Text = "";
            cbxElementName.SelectedIndex = -1;
        }

        private bool _isRead = false;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearSelData();

                if (listView1.SelectedItems.Count <= 0) return; 
                ListViewItem lvi = listView1.SelectedItems[0];

          

                _isRead = true;

                txtTitle.Text = lvi.SubItems["显示名称"].Text;
                cbxElementName.Text = lvi.SubItems["关联元素"].Text;
                chkSyncSave.Checked = (lvi.SubItems["同步保存"].Text == "√") ? true : false; 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);

            }

            _isRead = false;
        }

        private void chkSyncSave_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateSectionConfig();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

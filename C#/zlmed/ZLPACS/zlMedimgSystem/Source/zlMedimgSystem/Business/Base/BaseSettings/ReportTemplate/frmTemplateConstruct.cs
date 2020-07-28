using FormPart;
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

    public delegate void SaveReportDesign(DataBase reportFmt, DataTable dtWordReleations);

 
    public partial class frmTemplateConstruct : Form
    {
        public event SaveReportDesign OnSaveReportDesign;

        private ReportTemplateItemData _reportItem = null;
        private ReportTemplateFormatData _reportFmt = null; 

        private ReportWordsModel _rwm = null;
        private ReportTemplateModel _rtm = null;
        private DesignerControl designerControl1 = null;

        private IDBQuery _dbHelper = null;
        private string _imgKind = "";
        private bool _isModify = false;
        public frmTemplateConstruct(IDBQuery dbHelper, string imgKind)
        {
            InitializeComponent();

            designerControl1 = new DesignerControl();
            panel2.Controls.Add(designerControl1);
            designerControl1.Dock = DockStyle.Fill;

            _dbHelper = dbHelper;
            _imgKind = imgKind;

            _rwm = new ReportWordsModel(dbHelper);
            _rtm = new ReportTemplateModel(dbHelper);
        }

        public bool IsModify
        {
            get { return _isModify; }
            set
            {
                _isModify = value;
                tsbSave.Enabled = value;
            }
        }

        /// <summary>
        /// 显示模板构造
        /// </summary>
        /// <param name="reportTemplate"></param>
        /// <param name="owner"></param>
        public void ShowTemplateConstruct(ReportTemplateItemData reportTemplate,  IWin32Window owner) 
        {
            _reportItem = reportTemplate;

            this.ShowDialog(owner); 
        }

        /// <summary>
        /// 显示格式构造
        /// </summary>
        /// <param name="reportTemplate"></param>
        /// <param name="owner"></param>
        public void ShowFormatConstruct(ReportTemplateFormatData reportFormat, ReportTemplateItemData reportTemplate, IWin32Window owner)
        {
            _reportFmt = reportFormat;
            _reportItem = reportTemplate;

            this.ShowDialog(owner);
        }

        private void tsbNewDataSource_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportDataConfig dataCfg = new frmReportDataConfig(_dbHelper);
                dataCfg.OnSaveReportTemplateDataSource += SaveReportTemplateDataSource;

                dataCfg.ShowDataConfig(null, this);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 保存查询配置处理事件
        /// </summary>
        /// <param name="templateQuery"></param>
        private void SaveReportTemplateDataSource(JReportTemplateQuery templateQuery)
        {


            if (string.IsNullOrEmpty(templateQuery.查询名称))
            {
                MessageBox.Show("查询名称不允许为空。", "提示");
                return;
            }

            if (string.IsNullOrEmpty(templateQuery.查询内容))
            {
                MessageBox.Show("查询内容不允许为空。", "提示");
                return;
            }


            int index = _reportItem.数据来源.查询信息.FindIndex(T => T.查询ID == templateQuery.查询ID);

            if (index < 0)
            {
                int nameIndex = _reportItem.数据来源.查询信息.FindIndex(T => T.查询名称 == templateQuery.查询名称);
                if (nameIndex >= 0)
                {
                    MessageBox.Show("查询名称不允许重复。", "提示");
                    return;
                }

                _reportItem.数据来源.查询信息.Add(templateQuery);


            }
            else
            {
                int nameIndex = _reportItem.数据来源.查询信息.FindIndex(T => T.查询名称 == templateQuery.查询名称);
                if (nameIndex != index)
                {
                    MessageBox.Show("查询名称不允许重复。", "提示");
                    return;
                }

                _reportItem.数据来源.查询信息[index].查询名称 = templateQuery.查询名称;
                //_reportItem.数据来源.查询信息[index].数据源名称 = templateQuery.数据源名称;
                _reportItem.数据来源.查询信息[index].查询内容 = templateQuery.查询内容;
            }

            listDataSource.DataSource = null;

            listDataSource.DisplayMember = "查询名称";
            listDataSource.ValueMember = "查询ID";

            listDataSource.DataSource = _reportItem.数据来源.查询信息;

            //绑定数据源
            designerControl1.DataSet = SqlHelper.GetReportDataSource(_reportItem.数据来源.查询信息, _dbHelper);

            IsModify = true;
        }

        private void frmTemplateConstruct_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTemplate();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private DataTable _reportWords = null;
        private void LoadTemplate()
        {
            if (_reportItem == null)
            {
                MessageBox.Show("模板对象无效，不能载入对应数据。", "提示");
                return;
            }
             

            if (_reportFmt != null)
            {
                tsbNewDataSource.Enabled = false;
                tsbEditDataSource.Enabled = false;
                tsbDelDataSource.Enabled = false;
                tsbSectionConfig.Enabled = false;
                tsbExamItemReleation.Enabled = false;

                if (Convert.ToString(_reportFmt.格式信息.格式内容) == null)
                {
                    _reportFmt.格式信息.格式内容 = _reportItem.模板信息.模板内容;
                }

                designerControl1.ImportByXml(_reportFmt.格式信息.格式内容);

                _reportWords = _rtm.GetFormatWords(_reportFmt.格式ID);
                if (_reportWords == null || _reportWords.Rows.Count <= 0)
                {
                    _reportWords = _rtm.GetTemplateWords(_reportItem.模板ID);
                }
            }
            else
            {
                designerControl1.ImportByXml(_reportItem.模板信息.模板内容);

                //配置词句显示
                _reportWords = _rtm.GetTemplateWords(_reportItem.模板ID);
            }

            BindWordClassData();
            BindReleationWords(_reportWords);


            //载入数据源
            listDataSource.DataSource = null;

            listDataSource.DisplayMember = "查询名称";
            listDataSource.ValueMember = "查询ID";

            listDataSource.DataSource = _reportItem.数据来源.查询信息;

            designerControl1.DataSet = SqlHelper.GetReportDataSource(_reportItem.数据来源.查询信息, _dbHelper);


            //读取段落配置
            BindSection(_reportItem.关联段落);

            //读取关联项目
            BindExamItem();

        }






        /// <summary>
        /// 绑定词句分类数据
        /// </summary>
        private void BindWordClassData()
        {
            DataTable dtClass = _rwm.GetWordsClass(_imgKind);
            if (dtClass.Rows.Count <= 0) return;

            DataRow[] drRoots = dtClass.Select("上级分类ID is null or 上级分类ID=''");


            foreach (DataRow drRoot in drRoots)
            {
                TreeNode rootNode = null;

                ReportWordsClassData classData = new ReportWordsClassData();
                classData.BindRowData(drRoot);

                rootNode = treeView1.Nodes.Add(classData.词句分类ID, classData.分类名称, 0);

                rootNode.SelectedImageIndex = 0;
                rootNode.Tag = classData;

                if (rootNode == null) continue;

                BindSubNode(rootNode, dtClass);
            }

            treeView1.ExpandAll();
        }

        private void BindSubNode(TreeNode pNode, DataTable dtClass)
        {
            if (pNode == null || dtClass == null) return;

            ReportWordsClassData pClassData = pNode.Tag as ReportWordsClassData;
            DataRow[] drSubs = dtClass.Select("上级分类ID='" + pClassData.词句分类ID + "'");

            if (drSubs.Length <= 0) return;

            foreach (DataRow drCur in drSubs)
            {
                ReportWordsClassData subClassData = new ReportWordsClassData();
                subClassData.BindRowData(drCur);

                TreeNode tnSub = pNode.Nodes.Add(subClassData.词句分类ID, subClassData.分类名称, 0);
                tnSub.SelectedImageIndex = 0;
                tnSub.Tag = subClassData;

                BindSubNode(tnSub, dtClass);
            }
        }
         

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (_reportFmt != null)
                {
                    _reportFmt.格式信息.格式内容 = designerControl1.ExportXmlf();

                    //如果不为空，说明是对模板格式进行构造
                    OnSaveReportDesign?.Invoke(_reportFmt, _reportWords);

                    return;
                }
                else
                {
                    _reportItem.模板信息.模板内容 = designerControl1.ExportXmlf();

                    OnSaveReportDesign?.Invoke(_reportItem, _reportWords);
                }

                IsModify = false;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbEditDataSource_Click(object sender, EventArgs e)
        {
            try
            {
                if (listDataSource.Items.Count <= 0)
                {
                    MessageBox.Show("没有可供编辑的数据源。", "提示");
                    return;
                }

                if (listDataSource.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择需要编辑的数据源。", "提示");
                    return;
                }

                int index = _reportItem.数据来源.查询信息.FindIndex(T => T.查询ID == listDataSource.SelectedValue.ToString());
                if (index < 0)
                {
                    MessageBox.Show("为找到对应的数据源信息。", "提示");
                    return;
                }

                frmReportDataConfig dataCfg = new frmReportDataConfig(_dbHelper);
                dataCfg.OnSaveReportTemplateDataSource += SaveReportTemplateDataSource;

                dataCfg.ShowDataConfig(_reportItem.数据来源.查询信息[index], this);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbDelDataSource_Click(object sender, EventArgs e)
        {
            try
            {
                if (listDataSource.Items.Count <= 0)
                {
                    MessageBox.Show("没有可供删除的数据源。", "提示");
                    return;
                }

                if (listDataSource.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择需要上次的数据源。", "提示");
                    return;
                }

                int index = _reportItem.数据来源.查询信息.FindIndex(T => T.查询ID == listDataSource.SelectedValue.ToString());
                if (index < 0)
                {
                    MessageBox.Show("为找到对应的数据源信息。", "提示");
                    return;
                }


                _reportItem.数据来源.查询信息.RemoveAt(index);

                listDataSource.DataSource = null;

                listDataSource.DisplayMember = "查询名称";
                listDataSource.ValueMember = "查询ID";

                listDataSource.DataSource = _reportItem.数据来源.查询信息;


            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbWords_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportWordsConfig wordConfig = new frmReportWordsConfig(_dbHelper, _imgKind);
                wordConfig.OnSaveReportWords += SaveReportWords;

                string templateId = _reportItem.模板ID;
                string formatId = "";

                if (_reportFmt != null) formatId = _reportFmt.格式ID;

                wordConfig.ShowWordConfig(templateId, formatId, _reportWords, this);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void SaveReportWords(DataTable wordReleations)
        {
            //词句保存
            IsModify = true;

            BindReleationWords(wordReleations);
        }

        private List<TreeNode> GetCheckedNodes(TreeNode tnParent)
        {
            List<TreeNode> result = new List<TreeNode>();

            if (tnParent.Checked) result.Add(tnParent);

            foreach (TreeNode tn in tnParent.Nodes)
            {
                if (tn.Nodes.Count > 0)
                {
                    List<TreeNode> checkNodes = GetCheckedNodes(tn);
                    result.AddRange(checkNodes);
                }
                else
                {
                    if (tn.Checked) result.Add(tn);
                }
            }

            return result;
        }


        private void BindReleationWords(DataTable wordReleations)
        {
            if (treeView1.Nodes.Count <= 0) return;

            List<TreeNode> checkNodes = GetCheckedNodes(treeView1.Nodes[0]);

            foreach(TreeNode tn in checkNodes)
            {
                tn.ImageIndex = 0;
                tn.SelectedImageIndex = 0;
            }

    
            ConfigCheckState(treeView1.Nodes[0], wordReleations);
        }

        private void ConfigCheckState(TreeNode tnParent, DataTable wordReleations)
        {
            if (tnParent == null) return;

            ReportWordsClassData wordClass = tnParent.Tag as ReportWordsClassData;
            if (wordClass == null) return;

            if (wordReleations.Select("词句分类ID='" + wordClass.词句分类ID + "'").Length > 0)
            {
                tnParent.ImageIndex = 1;
                tnParent.SelectedImageIndex = 1;

                tnParent.Checked = true;
            }

            foreach(TreeNode tn in tnParent.Nodes)
            {
                if (tn.Nodes.Count > 0)
                {
                    ConfigCheckState(tn, wordReleations);
                }
                else
                {
                    wordClass = tn.Tag as ReportWordsClassData;
                    if (wordReleations.Select("词句分类ID='" + wordClass.词句分类ID + "'").Length > 0)
                    {
                        tn.ImageIndex = 1;
                        tn.SelectedImageIndex = 1;

                        tn.Checked = true;
                    }
                }
            }
        }

        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                if (e.Action != TreeViewAction.Unknown)
                {
                    e.Cancel = true;
                } 
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

        private void frmTemplateConstruct_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_isModify)
                {
                    if (MessageBox.Show("配置已被修改，是否进行保存？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        tsbSave_Click(tsbSave, null);
                    }

                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbSectionConfig_Click(object sender, EventArgs e)
        {
            try
            {
                if (designerControl1 == null) return;

                JReportTemplateSection section = _reportItem.关联段落; 

                frmReportSectionConfig sectionConfig = new frmReportSectionConfig(_dbHelper);
                sectionConfig.OnSaveReportSection += SaveReportSection;

                Header hd = null;
                Footer fd = null;
                List<FormItem> elements =  designerControl1.getAllFormItems(out hd, out fd);

                sectionConfig.ShowSectionConfig(section, elements, this);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        public void SaveReportSection(JReportTemplateSection section)
        {
            BindSection(section);

            IsModify = true;
        }

        private void InitList()
        {
            lbxSection.Clear();
            lbxSection.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();
            columnDefault = new ColumnHeader();
            columnDefault.Text = "段落显示名";
            columnDefault.Name = "段落显示名";
            columnDefault.Width = 100;
            lbxSection.Columns.Add(columnDefault);

            //columnDefault = new ColumnHeader();
            //columnDefault.Text = "显示名称";
            //columnDefault.Name = "显示名称";
            //columnDefault.Width = 100;
            //lbxSection.Columns.Add(columnDefault);


            columnDefault = new ColumnHeader();
            columnDefault.Text = "关联元素";
            columnDefault.Name = "关联元素";
            columnDefault.Width = 100;
            lbxSection.Columns.Add(columnDefault);


            columnDefault = new ColumnHeader();
            columnDefault.Text = "同步保存";
            columnDefault.Name = "同步保存";
            columnDefault.Width = 60;
            lbxSection.Columns.Add(columnDefault);

            lbxSection.View = View.Details;
        }

        private void BindSection(JReportTemplateSection section)
        {
            InitList();

            foreach (JReportSectionItem jsi in section.段落关联信息)
            {
                if (string.IsNullOrEmpty(jsi.模板元素名)) continue;


                ListViewItem itemNew = new ListViewItem(new string[] { (string.IsNullOrEmpty(jsi.段落显示名)) ? jsi.报告段落名 : jsi.段落显示名, jsi.模板元素名, ((jsi.关联存储) ? "√" : "") }, 0);
                               
                itemNew.ToolTipText = jsi.报告段落名;

                lbxSection.Items.Add(itemNew);
            }

            lbxSection.View = View.Details;
        }

        private void tsbExamItemReleation_Click(object sender, EventArgs e)
        {
            try
            {
                if (designerControl1 == null) return;
                 

                frmReportExamConfig examItemConfig = new frmReportExamConfig(_imgKind, _reportItem.模板ID, _dbHelper);


                examItemConfig.ShowDialog(this);

                if (examItemConfig.Updated)
                {
                    BindExamItem();
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void BindExamItem()
        {
            DataTable dtExamItem = _rtm.GetTemplateExamItem(_reportItem.模板ID);

            lbxExamItem.DisplayMember = "项目名称";

            lbxExamItem.DataSource = dtExamItem;
        }
    }
}

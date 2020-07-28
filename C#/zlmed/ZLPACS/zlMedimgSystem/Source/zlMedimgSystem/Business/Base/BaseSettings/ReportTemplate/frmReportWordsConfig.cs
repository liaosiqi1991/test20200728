using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BaseSettings
{
    public delegate void SaveReportWordsEvent(DataTable wordReleations);
    public partial class frmReportWordsConfig : Form
    {
        public event SaveReportWordsEvent OnSaveReportWords;

        private IDBQuery _dbHelper = null;
        private DataTable _wordReleations = null;

        private ReportWordsModel _rwm = null;
        private string _imgKind = "";
        private bool _isModify = false;
        private bool _isLoading = false;

        private string _templateId = "";//模板ID
        private string _formatId = "";//格式ID

        public frmReportWordsConfig(IDBQuery dbHelper, string imgKind)
        {
            InitializeComponent();

            _dbHelper = dbHelper;
            _imgKind = imgKind;

            _rwm = new ReportWordsModel(dbHelper);
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

        public void ShowWordConfig(string templateId, string formatId, DataTable wordReleations, IWin32Window owner)
        {
            _templateId = templateId;
            _formatId = formatId;
            _wordReleations = wordReleations;

            this.ShowDialog(owner);
        }

        private void frmReportWordsConfig_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            try
            {
                treeView1.Nodes.Clear();

                if (string.IsNullOrEmpty(_imgKind))
                {
                    return;
                }


                BindWordClassData();

                if (treeView1.Nodes.Count > 0)
                {
                    ConfigCheckState(treeView1.Nodes[0], _wordReleations);
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isLoading = false;
            }
        }


        private void ConfigCheckState(TreeNode tnParent, DataTable words)
        {
            if (tnParent == null) return;

            ReportWordsClassData wordClass = tnParent.Tag as ReportWordsClassData;
            if (wordClass == null) return;

            if (words.Select("词句分类ID='" + wordClass.词句分类ID + "'").Length > 0)
            {
                tnParent.Checked = true;
            }

            foreach (TreeNode tn in tnParent.Nodes)
            {
                if (tn.Nodes.Count > 0)
                {
                    ConfigCheckState(tn, words);
                }
                else
                {
                    wordClass = tn.Tag as ReportWordsClassData;
                    if (words.Select("词句分类ID='" + wordClass.词句分类ID + "'").Length > 0)
                    {
                        tn.Checked = true;
                    }
                }
            }
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


        /// <summary>
        /// 绑定词句项目
        /// </summary>
        private void BindWordItem(TreeNode tnClass)
        {
            listView1.Clear();

            if (tnClass == null) return;

            ReportWordsClassData classData = tnClass.Tag as ReportWordsClassData;

            if (classData == null) return;
             

            DataTable dtItem = _rwm.GetWordItemByClass(classData.词句分类ID);

            foreach (DataRow dr in dtItem.Rows)
            {
                ReportWordsInfoData wordInfo = new ReportWordsInfoData();
                wordInfo.BindRowData(dr);

                ListViewItem lvi = listView1.Items.Add(wordInfo.词句名称, 0);
                lvi.Tag = wordInfo;
            }
             

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                BindWordItem(treeView1.SelectedNode);
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
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (_isLoading) return;
                //if (e.Node.Checked)
                //{
                    foreach(TreeNode tn in e.Node.Nodes)
                    {
                        tn.Checked = e.Node.Checked;
                    }
                //}

                IsModify = true;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
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

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.Nodes.Count <= 0)
                {
                    return;
                }

                List<TreeNode> checkNodes = GetCheckedNodes(treeView1.Nodes[0]);

                _wordReleations.Rows.Clear();

                foreach(TreeNode tn in checkNodes)
                {
                    ReportWordsClassData wordClass = tn.Tag as ReportWordsClassData;

                    DataRow newWordReleation = _wordReleations.NewRow();

                    newWordReleation["关联ID"] = SqlHelper.GetNumGuid();
                    newWordReleation["词句分类ID"] = wordClass.词句分类ID;
                    newWordReleation["格式ID"] = _formatId;
                    newWordReleation["模板ID"] = _templateId;

                    _wordReleations.Rows.Add(newWordReleation); 
                }

                OnSaveReportWords?.Invoke(_wordReleations);

                IsModify = false;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmReportWordsConfig_FormClosing(object sender, FormClosingEventArgs e)
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


        private void ReadWordContext(ReportWordsInfoData wordData)
        {
            rtbFree.Text = "";
            if (wordData == null) return;
            if (wordData.词句信息 == null || wordData.词句信息.词句明细.Count <= 0) return;

            string sections = "";

            if (wordData.词句信息.词句类型 == (int)ReportWordType.rwtFree)
            {
                foreach (JReportWordSection wordSection in wordData.词句信息.词句明细)
                {
                    string sectionContext = "■■" + wordSection.段落名称 + ":" + System.Environment.NewLine + wordSection.段落内容 + System.Environment.NewLine;

                    sections = sections + sectionContext + System.Environment.NewLine; ;
                }
            }

            rtbFree.Text = sections;
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                rtbFree.Text = "";

                if (listView1.SelectedItems.Count <= 0) return;

                ListViewItem lvi = listView1.SelectedItems[0];

                if (lvi.Tag == null) return;

                ReportWordsInfoData wordData = lvi.Tag as ReportWordsInfoData;

                ReadWordContext(wordData);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

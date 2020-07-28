using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmReportExamConfig : Form
    {
        private IDBQuery _dbHelper = null;

        private string _imgKind = "";
        private string _templateId = "";

        private ExamItemModel _eim = null;
        private ReportTemplateModel _rtm = null;

        private bool _isModify = false;
        private bool _isLoading = false;

        private bool _updated = false;
        
        private bool IsModify
        {
            get { return _isModify;}
            set
            {
                _isModify = value;
                tsbSave.Enabled = value;

                if (_updated == false) _updated = value;
            }
        }

        public bool Updated
        {
            get { return _updated; }
        }

        public frmReportExamConfig(string imgKind, string templateId, IDBQuery dbHelper)
        {
            InitializeComponent();

            _dbHelper = dbHelper;
            _imgKind = imgKind;
            _templateId = templateId;

            _eim = new ExamItemModel(dbHelper);
            _rtm = new ReportTemplateModel(dbHelper);
        }

        private void frmReportExamConfig_Load(object sender, EventArgs e)
        {
            try
            {
                _isLoading = true;

                BindExamClassData();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void BindExamClassData()
        {
            DataTable dtClass = _eim.GetExamClass(_imgKind);
            if (dtClass.Rows.Count <= 0) return;

            DataRow[] drRoots = dtClass.Select("上级分类ID is null or 上级分类ID=''");


            foreach (DataRow drRoot in drRoots)
            {
                TreeNode rootNode = null;

                ExamClassData classData = new ExamClassData();
                classData.BindRowData(drRoot);

                rootNode = treeView1.Nodes.Add(classData.项目分类ID, classData.分类名称, 0);

                rootNode.SelectedImageIndex = 0;
                rootNode.Tag = classData;

                //rootNode.Nodes.Add("TMP" + classData.项目分类ID, "TMP");


                if (rootNode == null) continue; 

                BindSubNode(rootNode, dtClass);

                BindClassItem(rootNode);

                if (rootNode.Nodes.Count <= 0)
                {
                    rootNode.Remove();                    
                }
                else
                {
                    rootNode.Expand();
                }

                ////绑定当前分类及下一级分类的检查项目
                //BindClassItem(rootNode);

                //foreach (TreeNode tnSub in rootNode.Nodes)
                //{
                //    BindClassItem(tnSub);
                //}
            }

            if (treeView1.Nodes.Count <=0)
            {
                MessageBox.Show("未发现可供模板关联的检查项目，请确认检查项目是否已关联其他模板。", "提示");
            }
        }

        private void BindSubNode(TreeNode pNode, DataTable dtClass)
        {
            if (pNode == null || dtClass == null) return;

            ExamClassData pClassData = pNode.Tag as ExamClassData;
            DataRow[] drSubs = dtClass.Select("上级分类ID='" + pClassData.项目分类ID + "'");

            if (drSubs.Length <= 0) return;

            foreach (DataRow drCur in drSubs)
            {
                ExamClassData subClassData = new ExamClassData();
                subClassData.BindRowData(drCur);

                TreeNode tnSub = pNode.Nodes.Add(subClassData.项目分类ID, subClassData.分类名称, 0);
                tnSub.SelectedImageIndex = 0;
                tnSub.Tag = subClassData;

                BindSubNode(tnSub, dtClass);

                BindClassItem(tnSub);

                if (tnSub.Nodes.Count <= 0) tnSub.Remove();
            }
        }

        /// <summary>
        /// 绑定分类项目
        /// </summary>
        private void BindClassItem(TreeNode tnClass)
        {
            if (tnClass == null) return;


            ExamClassData classData = tnClass.Tag as ExamClassData;

            if (classData == null) return;

            DataTable dtItem = _eim.GetExamItemByClass(classData.项目分类ID);

            foreach (DataRow dr in dtItem.Rows)
            {
                ExamItemData itemData = new ExamItemData();
                itemData.BindRowData(dr);

                if (AllowReleation(itemData.项目ID))
                {
                    TreeNode tnItem = tnClass.Nodes.Add(itemData.项目ID, itemData.项目名称, 1);
                    tnItem.SelectedImageIndex = 1;
                    tnItem.Tag = itemData;

                    tnItem.Checked = IsChecked(itemData.项目ID);
                }
       
            }
        }

        private DataTable _dtOther = null;
        private DataTable _dtSel = null;
        private bool AllowReleation(string itemId)
        {
            if (_dtOther == null)
            {
                _dtOther = _rtm.GetNoReleationExamItem(_templateId, _imgKind);
            }
           
            if (_dtOther.Select("项目ID='" + itemId + "'").Length > 0)
            {
                return false;
            }

            return true;
        }

        private bool IsChecked(string itemId)
        {
            if (_dtSel == null)
            {
                _dtSel = _rtm.GetTemplateExamItem(_templateId);
            }

            if (_dtSel.Select("项目ID='" + itemId + "'").Length > 0)
            {
                return true;
            }

            return false;

        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //try
            //{
            //    if (e.Node == null) return;

            //    TreeNode expNode = e.Node;

            //    if (expNode.Tag is ExamClassData)
            //    {
            //        //读取下级分类中的项目
            //        foreach (TreeNode tnSub in expNode.Nodes)
            //        {
            //            BindClassItem(tnSub);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.ShowException(ex, this);
            //}
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (_isLoading) return;

                foreach (TreeNode tn in e.Node.Nodes)
                {
                    tn.Checked = e.Node.Checked;
                }

                IsModify = true;

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.Nodes.Count <= 0) return;

                //清除模板关联检查项目
                _rtm.ClearTemplateReleationExamItem(_templateId);

                List<TreeNode> checkNodes = ControlEx.GetCheckedTreeNode(treeView1.Nodes[0]);

                foreach(TreeNode tn in checkNodes)
                {
                    if (tn.Tag is ExamClassData) continue;

                    ExamItemData itemData = tn.Tag as ExamItemData;

                    _rtm.NewTemplateExamItemReleation(_templateId, itemData.项目ID);
                }

                IsModify = false;
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
    }
}

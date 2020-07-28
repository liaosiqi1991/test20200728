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
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmReportWords : Form, ISetting
    {
        private IDBQuery _dbHelper = null;
        private ReportWordsModel _rwm = null;
        private ILoginUser _loginUser = null;
        private ComboxEx _comboxEx = null;//字典，类别下拉框加载方法
        public frmReportWords()
            : this(null, null)
        {
        }


        public frmReportWords(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }


        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {

            _dbHelper = dbHelper;
            _loginUser = loginUser;
            _rwm = new ReportWordsModel(_dbHelper);
            _comboxEx = new ComboxEx(dbHelper);
    }

        public void RefreshSetting()
        {
            _comboxEx.BindImageKing(cbxImageKind);
            _comboxEx.BindDictionary(cbxSex, "性别", true);

            cbxType.SelectedIndex = 0; 
        }

        private void frmReportWords_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshSetting();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxImageKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                treeView1.Nodes.Clear();
                //选择类别前先清空编辑区域和词句内容
                rtbFree.Text = "";
                txtName.Text = "";
                cbxSex.Text = "";
                rtbDescription.Text = "";

                if (string.IsNullOrEmpty(cbxImageKind.Text))
                {
                    return;
                }


                BindWordClassData();

                
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        /// <summary>
        /// 绑定词句分类数据
        /// </summary>
        private void BindWordClassData()
        {
            DataTable dtClass = _rwm.GetWordsClass(cbxImageKind.Text);
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

                rootNode.Nodes.Add("TMP" + classData.词句分类ID, "TMP");


                if (rootNode == null) continue;

                BindSubNode(rootNode, dtClass);

                //绑定当前分类及下一级分类的检查项目
                BindWordItem(rootNode);

                foreach (TreeNode tnSub in rootNode.Nodes)
                {
                    BindWordItem(tnSub);
                }
            }
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

                tnSub.Nodes.Add("TMP" + subClassData.词句分类ID, "TMP");

                BindSubNode(tnSub, dtClass);
            }
        }


        /// <summary>
        /// 绑定词句项目
        /// </summary>
        private void BindWordItem(TreeNode tnClass)
        {
            if (tnClass == null) return;


            ReportWordsClassData classData = tnClass.Tag as ReportWordsClassData;

            if (classData == null) return;

            TreeNode[] tmpNodes = tnClass.Nodes.Find("TMP" + classData.词句分类ID, false);
            if (tmpNodes.Length <= 0) return;

            DataTable dtItem = _rwm.GetWordItemByClass(classData.词句分类ID);

            foreach (DataRow dr in dtItem.Rows)
            {
                ReportWordsInfoData itemData = new ReportWordsInfoData();
                itemData.BindRowData(dr);

                TreeNode tnItem = tnClass.Nodes.Add(itemData.词句ID, itemData.词句名称, 1);
                tnItem.SelectedImageIndex = 1;
                tnItem.Tag = itemData;
            }

            tnClass.Nodes.Remove(tmpNodes[0]);

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                SyncSelNodeData();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private void ClearData()
        {
            txtName.Text = "";
            txtName.Tag = null;
             

            cbxType.SelectedIndex = 0; 

            cbxSex.SelectedIndex = -1;
            cbxSex.Text = "";
             
            rtbDescription.Text = "";
            rtbFree.Text = "";
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


        private void SyncSelNodeData()
        {
            try
            {

                ClearData();
                 
                if (treeView1.SelectedNode == null) return;

                TreeNode selNode = treeView1.SelectedNode;

                if (selNode.Tag is ReportWordsInfoData)
                {
                    ReportWordsInfoData itemData = selNode.Tag as ReportWordsInfoData;

                    txtName.Text = itemData.词句名称;
                    txtName.Tag = itemData.词句ID;

                    cbxType.SelectedIndex = 0;
                     
                    //cbxSex.Text = itemData.词句信息.适用性别;

                    rtbDescription.Text = itemData.词句信息.备注说明;

                    ReadWordContext(itemData);
                }
                else
                {
                    ReportWordsClassData classData = selNode.Tag as ReportWordsClassData;

                    txtName.Text = classData.分类名称;
                    txtName.Tag = classData.词句分类ID;

                    cbxType.SelectedIndex = 1;

                    cbxSex.Text = classData.分类信息.适用性别;
                    rtbDescription.Text = classData.分类信息.备注说明;

                    //读取下级分类中的项目
                    foreach (TreeNode tnSub in selNode.Nodes)
                    {
                        BindWordItem(tnSub);
                    }
                     
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                if (e.Node == null) return;

                TreeNode expNode = e.Node;

                if (expNode.Tag is ReportWordsClassData)
                {
                    //读取下级分类中的词句
                    foreach (TreeNode tnSub in expNode.Nodes)
                    {
                        BindWordItem(tnSub);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private bool ClassVerify(bool isModify)
        {
            if (cbxType.Text == "词句")
            {
                MessageBox.Show("分类项目类型不能是词句。", "提示");
                cbxType.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbxImageKind.Text))
            {
                MessageBox.Show("影像类别不允许未空。", "提示");
                cbxImageKind.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("项目名称不允许为空。", "提示");
                txtName.Focus();
                return false;
            }

            string classId = _rwm.GetWordClassIdByName(txtName.Text, cbxImageKind.Text);

            if (string.IsNullOrEmpty(classId) == false)
            {
                if (isModify)
                {
                    if (classId.Equals(txtName.Tag) == false)
                    {
                        MessageBox.Show("项目名称不允许重复。", "提示");
                        txtName.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("项目名称不允许重复。", "提示");
                    txtName.Focus();
                    return false;
                }
            }

            return true;

        }

        public bool ItemVerify(bool isModify)
        {

            if (cbxType.Text == "分类")
            {
                MessageBox.Show("项目类型不能是分类。", "提示");
                cbxType.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbxImageKind.Text))
            {
                MessageBox.Show("影像类别不允许未空。", "提示");
                cbxImageKind.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("项目名称不允许为空。", "提示");
                txtName.Focus();
                return false;
            }

            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("请选择对应的项目分类。", "提示");
                treeView1.Focus();
                return false;
            }

            string itemId = _rwm.GetWordItemIdByName(txtName.Text);

            if (string.IsNullOrEmpty(itemId) == false)
            {
                if (isModify)
                {
                    if (itemId.Equals(txtName.Tag) == false)
                    {
                        MessageBox.Show("项目名称不允许重复。", "提示");
                        txtName.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("项目名称不允许重复。", "提示");
                    txtName.Focus();
                    return false;
                }
            }

            return true;
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {

                TreeNode newNode = null;

                if (cbxType.SelectedIndex == 1)
                {
                    if (ClassVerify(false) == false) return;

                    //新增分类
                    ReportWordsClassData classData = new ReportWordsClassData();

                    classData.词句分类ID = SqlHelper.GetCmpUID();
                    classData.影像类别 = cbxImageKind.Text;
                    classData.分类名称  = txtName.Text;

                    classData.分类信息.适用性别 = cbxSex.Text;
                    classData.分类信息.创建日期 = DateTime.Now;
                    classData.分类信息.备注说明 = rtbDescription.Text;

                    TreeNode tn = null;
                    if (treeView1.SelectedNode != null)
                    {
                        tn = treeView1.SelectedNode;

                        if (tn.Tag is ReportWordsInfoData)
                        {
                            tn = tn.Parent;
                        }

                        ReportWordsClassData pData = tn.Tag as ReportWordsClassData;

                        classData.上级分类ID = pData.词句分类ID;
                    }

                    classData.分类信息.CopyBasePro(classData);

                    _rwm.NewWordClass(classData);

                    if (tn == null)
                    {
                        newNode = treeView1.Nodes.Add(classData.词句分类ID, classData.分类名称, 0);
                    }
                    else
                    {
                        newNode = tn.Nodes.Add(classData.词句分类ID, classData.分类名称, 0);

                        tn.Expand();
                    }
                    newNode.SelectedImageIndex = 0;
                    newNode.Tag = classData;

                }
                else
                {
                    //新增项目
                    if (ItemVerify(false) == false) return;

                    ReportWordsInfoData itemData = new ReportWordsInfoData();

                    itemData.词句ID = SqlHelper.GetCmpUID();
                    itemData.词句名称 = txtName.Text;  
                    //itemData.词句信息.适用性别 = cbxSex.Text;
                    itemData.词句信息.创建人 = _loginUser.Name;
                    itemData.词句信息.备注说明 = rtbDescription.Text;
                    itemData.词句信息.创建日期 = DateTime.Now;

                    TreeNode tn = null;
                    if (treeView1.SelectedNode != null)
                    {
                        tn = treeView1.SelectedNode;

                        if (tn.Tag is ReportWordsInfoData)
                        {
                            tn = tn.Parent;
                        }

                        ReportWordsClassData pData = tn.Tag as ReportWordsClassData;

                        itemData.词句分类ID = pData.词句分类ID;
                    }

                    itemData.词句信息.CopyBasePro(itemData);

                    _rwm.NewWordItem(itemData);



                    if (tn == null)
                    {
                        newNode = treeView1.Nodes.Add(itemData.词句ID, itemData.词句名称, 1);
                    }
                    else
                    {
                        newNode = tn.Nodes.Add(itemData.词句ID, itemData.词句名称, 1);

                        tn.Expand();
                    }

                    newNode.SelectedImageIndex = 1;
                    newNode.Tag = itemData;

                }

                treeView1.SelectedNode = newNode;

                ButtonHint.Start(butNew, "OK");
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
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("请选择需要删除的项目。", "提示");
                    return;
                }

                TreeNode delNode = treeView1.SelectedNode;

                if (delNode.Tag is ReportWordsInfoData)
                {
                    //删除报告词句
                    ReportWordsInfoData itemData = delNode.Tag as ReportWordsInfoData;
                    //删除项目前提示确认
                    if (MessageBox.Show("是否删除项目" + itemData.词句名称.ToString() + "？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    _rwm.DelWordItem(itemData.词句ID);

                    delNode.Parent.Nodes.Remove(delNode);
                }
                else
                {
                    if (delNode.Nodes.Count > 0)
                    {
                        MessageBox.Show("项目存在子项，不允许删除。", "提示");
                        return;
                    }
                    //删除词句分类
                    ReportWordsClassData classData = delNode.Tag as ReportWordsClassData;
                    //删除项目前提示确认
                    if (MessageBox.Show("是否删除分类项目" + classData.分类名称.ToString() + "？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;

                    _rwm.DelWordClass(classData.词句分类ID);

                    //delNode.Parent.Nodes.Remove(delNode);
                    //如果是根目录，解决：未将对象引用设置到对象的实例，错误。
                    delNode.Remove();
                }

                ButtonHint.Start(butDel, "OK");

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
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("请选择需要修改的项目。", "提示");
                    return;
                }

                TreeNode selNode = treeView1.SelectedNode;

                if (selNode.Tag is ReportWordsInfoData)
                {
                   
                    //修改项目
                    if (ItemVerify(true) == false) return;

                    ReportWordsInfoData itemData = selNode.Tag as ReportWordsInfoData;

                    itemData.词句名称 = txtName.Text; 
                    //itemData.词句信息.适用性别 = cbxSex.Text; 
                    itemData.词句信息.备注说明 = rtbDescription.Text;

                    itemData.词句信息.CopyBasePro(itemData);

                    _rwm.UpdateWordItem(itemData);

                    selNode.Text = itemData.词句名称;
                }
                else
                {
                    //修改分类
                    if (ClassVerify(true) == false) return;

                    ReportWordsClassData classData = selNode.Tag as ReportWordsClassData;

                    classData.分类名称 = txtName.Text;

                    classData.分类信息.适用性别 = cbxSex.Text;
                    classData.分类信息.备注说明 = rtbDescription.Text;

                    classData.分类信息.CopyBasePro(classData);

                    _rwm.UpdateWordClass(classData);

                    selNode.Text = classData.分类名称;
                }

                ButtonHint.Start(butModify, "OK");

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
                bool isItem = (cbxType.SelectedIndex == 0) ? true : false;
                cbxSex.Enabled = !isItem; 
       
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butConstract_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("请选择需要构造的词句。", "提示");
                    return;
                }

                TreeNode delNode = treeView1.SelectedNode;

                ReportWordsInfoData wordData = delNode.Tag as ReportWordsInfoData;

                if (wordData == null)
                {
                    MessageBox.Show("请选择需要构造的词句。", "提示");
                    return;
                }


                //构造词句内容
                frmWordConstruct wordConstruct = new frmWordConstruct();
                if (wordConstruct.ShowWordConstruct(wordData, _dbHelper, this))
                {
                    ReadWordContext(wordData);
                }
             
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

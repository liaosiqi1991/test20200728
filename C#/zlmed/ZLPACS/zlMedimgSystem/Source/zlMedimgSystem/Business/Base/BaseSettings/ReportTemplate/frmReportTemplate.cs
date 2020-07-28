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
using FormPart;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmReportTemplate : Form, ISetting
    {
        private IDBQuery _dbHelper = null;
        private ReportTemplateModel _rtm = null;
        private ILoginUser _loginUser = null;

        private PreviewControl previewControl1 = null;
        private ComboxEx _comboxEx = null;//字典，类别下拉框加载方法


        public frmReportTemplate()
            : this(null, null)
        {
        }


        public frmReportTemplate(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            previewControl1 = new PreviewControl();
            panel4.Controls.Add(previewControl1);

            previewControl1.Dock = DockStyle.Fill;

            Init(dbHelper, loginUser);
        }


        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {

            _dbHelper = dbHelper;
            _loginUser = loginUser;
            _rtm = new ReportTemplateModel(_dbHelper);
            _comboxEx = new ComboxEx(dbHelper);
        }

        public void RefreshSetting()
        {
            _comboxEx.BindImageKing(cbxImageKind);
            _comboxEx.BindDictionary(cbxSex, "性别", true);

            cbxType.SelectedIndex = 0;
        }

        private void frmReportTemplate_Load(object sender, EventArgs e)
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

                if (string.IsNullOrEmpty(cbxImageKind.Text))
                {
                    return;
                }


                BindTemplateClassData();


            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        /// <summary>
        /// 绑定模板分类数据
        /// </summary>
        private void BindTemplateClassData()
        {
            DataTable dtClass = _rtm.GetTemplateClass(cbxImageKind.Text);
            if (dtClass.Rows.Count <= 0) return;

            DataRow[] drRoots = dtClass.Select("上级分类ID is null or 上级分类ID=''");


            foreach (DataRow drRoot in drRoots)
            {
                TreeNode rootNode = null;

                ReportTemplateClassData classData = new ReportTemplateClassData();
                classData.BindRowData(drRoot);

                rootNode = treeView1.Nodes.Add(classData.模板分类ID, classData.分类名称, 0);

                rootNode.SelectedImageIndex = 0;
                rootNode.Tag = classData;

                rootNode.Nodes.Add("TMP" + classData.模板分类ID, "TMP");


                if (rootNode == null) continue;

                BindSubNode(rootNode, dtClass);

                //绑定当前分类及下一级分类的检查项目
                BindTemplateItem(rootNode);

                foreach (TreeNode tnSub in rootNode.Nodes)
                {
                    BindTemplateItem(tnSub);
                }
            }

            treeView1.ExpandAll();
        }


        private void BindSubNode(TreeNode pNode, DataTable dtClass)
        {
            if (pNode == null || dtClass == null) return;

            ReportTemplateClassData pClassData = pNode.Tag as ReportTemplateClassData;
            DataRow[] drSubs = dtClass.Select("上级分类ID='" + pClassData.模板分类ID + "'");

            if (drSubs.Length <= 0) return;

            foreach (DataRow drCur in drSubs)
            {
                ReportTemplateClassData subClassData = new ReportTemplateClassData();
                subClassData.BindRowData(drCur);

                TreeNode tnSub = pNode.Nodes.Add(subClassData.模板分类ID, subClassData.分类名称, 0);
                tnSub.SelectedImageIndex = 0;
                tnSub.Tag = subClassData;

                tnSub.Nodes.Add("TMP" + subClassData.模板分类ID, "TMP");

                BindSubNode(tnSub, dtClass);
            }
        }


        /// <summary>
        /// 绑定模板项目
        /// </summary>
        private void BindTemplateItem(TreeNode tnClass)
        {
            if (tnClass == null) return;


            ReportTemplateClassData classData = tnClass.Tag as ReportTemplateClassData;

            if (classData == null) return;

            TreeNode[] tmpNodes = tnClass.Nodes.Find("TMP" + classData.模板分类ID, false);
            if (tmpNodes.Length <= 0) return;

            DataTable dtItem = _rtm.GetTemplateItemsByClass(classData.模板分类ID);

            foreach (DataRow dr in dtItem.Rows)
            {
                ReportTemplateItemData itemData = new ReportTemplateItemData();
                itemData.BindRowData(dr);

                TreeNode tnItem = tnClass.Nodes.Add(itemData.模板ID, itemData.模板名称, 1);
                tnItem.SelectedImageIndex = 1;
                tnItem.Tag = itemData;

                BindTemplateFormat(tnItem);
            }

            tnClass.Nodes.Remove(tmpNodes[0]);

        }

        /// <summary>
        /// 绑定模板格式
        /// </summary>
        /// <param name="tnItem"></param>
        private void BindTemplateFormat(TreeNode tnItem)
        {
            if (tnItem == null) return;


            ReportTemplateItemData itemData = tnItem.Tag as ReportTemplateItemData;

            if (itemData == null) return;

            //TreeNode[] tmpNodes = tnItem.Nodes.Find("TMP" + itemData.模板ID, false);
            //if (tmpNodes.Length <= 0) return;

            DataTable dtItem = _rtm.GetTemplateFormatsByTemplate(itemData.模板ID);

            foreach (DataRow dr in dtItem.Rows)
            {
                ReportTemplateFormatData formtData = new ReportTemplateFormatData();
                formtData.BindRowData(dr);

                TreeNode tnFormat = tnItem.Nodes.Add(formtData.格式ID, formtData.格式名称, 2);
                tnFormat.SelectedImageIndex = 2;
                tnFormat.Tag = formtData;


            }

            //tnItem.Nodes.Remove(tmpNodes[0]);
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

            cbxBodypart.SelectedIndex = -1;
            cbxBodypart.Text = "";

            cbxPatientFrom.SelectedIndex = -1;
            cbxPatientFrom.Text = "";

            rtbDescription.Text = "";

            previewControl1.ImportByXml("");
        }



        private void SyncSelNodeData()
        {
            try
            {

                ClearData();

                if (treeView1.SelectedNode == null) return;

                TreeNode selNode = treeView1.SelectedNode;

                butConstract.Enabled = true;

                if (selNode.Tag is ReportTemplateItemData)
                {
                    ReportTemplateItemData itemData = selNode.Tag as ReportTemplateItemData;

                    txtName.Text = itemData.模板名称;
                    txtName.Tag = itemData.模板ID;

                    cbxType.SelectedIndex = 0;

                    rtbDescription.Text = itemData.模板信息.备注说明;

                    
                    previewControl1.ImportByXml(itemData.模板信息.模板内容);
                   

                }
                else if (selNode.Tag is ReportTemplateFormatData)
                {
                    ReportTemplateFormatData formatData = selNode.Tag as ReportTemplateFormatData;

                    txtName.Text = formatData.格式名称;
                    txtName.Tag = formatData.格式ID;

                    cbxType.SelectedIndex = 1;

                    cbxSex.Text = formatData.格式信息.适用性别;
                    cbxBodypart.Text = formatData.格式信息.患者来源;

                    rtbDescription.Text = formatData.格式信息.备注说明;

                    previewControl1.ImportByXml(formatData.格式信息.格式内容);
                }
                else
                {
                    ReportTemplateClassData classData = selNode.Tag as ReportTemplateClassData;

                    txtName.Text = classData.分类名称;
                    txtName.Tag = classData.模板分类ID;

                    cbxType.SelectedIndex = 2;

                    rtbDescription.Text = classData.分类信息.备注说明;

                    //读取下级分类中的项目
                    foreach (TreeNode tnSub in selNode.Nodes)
                    {
                        BindTemplateItem(tnSub);
                    }

                    butConstract.Enabled = false;
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

                if (expNode.Tag is ReportTemplateClassData)
                {
                    //读取下级分类中的词句
                    foreach (TreeNode tnSub in expNode.Nodes)
                    {
                        BindTemplateItem(tnSub);
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

            string classId = _rtm.GetTemplateClassIdByName(txtName.Text, cbxImageKind.Text);

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
                MessageBox.Show("请选择对应的模板分类。", "提示");
                treeView1.Focus();
                return false;
            }

            string itemId = _rtm.GetTemplateItemIdByName(txtName.Text);

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

        private ReportTemplateItemData GetSelTemplateItem(ref TreeNode tnNode)
        {
            if (treeView1.SelectedNode == null) return null;

            ReportTemplateClassData templateItemData = treeView1.SelectedNode.Tag as ReportTemplateClassData;
            if (templateItemData != null)
            {
                return null;
            }


            ReportTemplateFormatData templateFormatData = treeView1.SelectedNode.Tag as ReportTemplateFormatData;
            if (templateFormatData != null)
            {
                tnNode = treeView1.SelectedNode.Parent;
                return tnNode.Tag as ReportTemplateItemData;
            }

            tnNode = treeView1.SelectedNode;

            return tnNode.Tag as ReportTemplateItemData;
        }


        public bool FormatVerify(bool isModify)
        {
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

            TreeNode tn = null;
            ReportTemplateItemData templateItemData = GetSelTemplateItem(ref tn);
            if (templateItemData == null)
            {
                MessageBox.Show("请选择对应的模板项目。", "提示");
                treeView1.Focus();
                return false;
            }

            string formatId = _rtm.GetTemplateFormatIdByName(txtName.Text, templateItemData.模板ID);

            if (string.IsNullOrEmpty(formatId) == false)
            {
                if (isModify)
                {
                    if (formatId.Equals(txtName.Tag) == false)
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

                if (cbxType.SelectedIndex == 2)
                {
                    if (ClassVerify(false) == false) return;

                    //新增分类
                    ReportTemplateClassData classData = new ReportTemplateClassData();

                    classData.模板分类ID = SqlHelper.GetCmpUID();
                    classData.影像类别 = cbxImageKind.Text;
                    classData.分类名称 = txtName.Text;

                    classData.分类信息.创建日期 = DateTime.Now;
                    classData.分类信息.备注说明 = rtbDescription.Text;

                    TreeNode tn = null;
                    if (treeView1.SelectedNode != null)
                    {
                        tn = treeView1.SelectedNode;

                        while (!(tn.Tag is ReportTemplateClassData))
                        {
                            tn = tn.Parent;
                        }

                        ReportTemplateClassData pData = tn.Tag as ReportTemplateClassData;

                        classData.上级分类ID = pData.模板分类ID;
                    }

                    classData.分类信息.CopyBasePro(classData);

                    _rtm.NewTemplateClass(classData);

                    if (tn == null)
                    {
                        newNode = treeView1.Nodes.Add(classData.模板分类ID, classData.分类名称, 0);
                    }
                    else
                    {
                        newNode = tn.Nodes.Add(classData.模板分类ID, classData.分类名称, 0);

                        tn.Expand();
                    }
                    newNode.SelectedImageIndex = 0;
                    newNode.Tag = classData;

                }
                else if (cbxType.SelectedIndex == 0)
                {
                    //新增项目
                    if (ItemVerify(false) == false) return;

                    ReportTemplateItemData itemData = new ReportTemplateItemData();

                    itemData.模板ID = SqlHelper.GetCmpUID();
                    itemData.模板名称 = txtName.Text;
                    //itemData.词句信息.适用性别 = cbxSex.Text;
                    itemData.模板信息.创建人 = _loginUser.Name;
                    itemData.模板信息.备注说明 = rtbDescription.Text;
                    itemData.模板信息.创建日期 = DateTime.Now;

                    TreeNode tn = null;
                    if (treeView1.SelectedNode != null)
                    {
                        tn = treeView1.SelectedNode;

                        while (!(tn.Tag is ReportTemplateClassData))
                        {
                            tn = tn.Parent;
                        }

                        ReportTemplateClassData pData = tn.Tag as ReportTemplateClassData;

                        itemData.模板分类ID = pData.模板分类ID;
                    }

                    itemData.模板信息.CopyBasePro(itemData);

                    _rtm.NewTemplateItem(itemData);



                    if (tn == null)
                    {
                        newNode = treeView1.Nodes.Add(itemData.模板ID, itemData.模板名称, 1);
                    }
                    else
                    {
                        newNode = tn.Nodes.Add(itemData.模板ID, itemData.模板名称, 1);

                        tn.Expand();
                    }

                    newNode.SelectedImageIndex = 1;
                    newNode.Tag = itemData;

                }
                else
                {
                    //添加模板格式
                    if (FormatVerify(false) == false) return;

                    ReportTemplateFormatData formtData = new ReportTemplateFormatData();

                    formtData.格式ID = SqlHelper.GetCmpUID();
                    formtData.格式名称 = txtName.Text;

                    formtData.格式信息.创建人 = _loginUser.Name;
                    formtData.格式信息.备注说明 = rtbDescription.Text;
                    formtData.格式信息.创建日期 = DateTime.Now;

                    formtData.格式信息.适用性别 = cbxSex.Text;
                    formtData.格式信息.适用部位 = cbxBodypart.Text;
                    formtData.格式信息.患者来源 = cbxPatientFrom.Text;


                    TreeNode tn = null;
                    ReportTemplateItemData pData = GetSelTemplateItem(ref tn);
                    formtData.模板ID = pData.模板ID;

                    formtData.格式信息.CopyBasePro(formtData);

                    _rtm.NewTemplateFormat(formtData);


                    if (tn == null)
                    {
                        newNode = treeView1.Nodes.Add(formtData.格式ID, formtData.格式名称, 2);
                    }
                    else
                    {
                        newNode = tn.Nodes.Add(formtData.格式ID, formtData.格式名称, 2);

                        tn.Expand();
                    }

                    newNode.SelectedImageIndex = 2;
                    newNode.Tag = formtData;
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

                if (delNode.Tag is ReportTemplateFormatData)
                {
                    //删除模板格式
                    ReportTemplateFormatData formatData = delNode.Tag as ReportTemplateFormatData;

                    _rtm.DelTemplateFormat(formatData.格式ID);

                    delNode.Parent.Nodes.Remove(delNode);
                }
                else if (delNode.Tag is ReportTemplateItemData)
                {
                    if (delNode.Nodes.Count > 0)
                    {
                        MessageBox.Show("项目存在子项，不允许删除。", "提示");
                        return;
                    }

                    //删除模板信息
                    ReportTemplateItemData itemData = delNode.Tag as ReportTemplateItemData;

                    _rtm.DelTemplateItem(itemData.模板ID);

                    delNode.Parent.Nodes.Remove(delNode);
                }
                else
                {
                    if (delNode.Nodes.Count > 0)
                    {
                        MessageBox.Show("项目存在子项，不允许删除。", "提示");
                        return;
                    }

                    //删除模板分类
                    ReportTemplateClassData classData = delNode.Tag as ReportTemplateClassData;

                    _rtm.DelTemplateClass(classData.模板分类ID);

                    delNode.Parent.Nodes.Remove(delNode);
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

                if (selNode.Tag is ReportTemplateFormatData)
                {
                    //修改格式
                    if (FormatVerify(true) == false) return;

                    ReportTemplateFormatData fmtData = selNode.Tag as ReportTemplateFormatData;

                    fmtData.格式名称 = txtName.Text;

                    fmtData.格式信息.备注说明 = rtbDescription.Text;
                    fmtData.格式信息.适用性别 = cbxSex.Text;
                    fmtData.格式信息.适用部位 = cbxBodypart.Text;
                    fmtData.格式信息.患者来源 = cbxPatientFrom.Text;

                    fmtData.格式信息.CopyBasePro(fmtData);

                    _rtm.UpdateTemplateFormat(fmtData);

                    selNode.Text = fmtData.格式名称;
                }
                if (selNode.Tag is ReportTemplateItemData)
                {
                    //修改项目
                    if (ItemVerify(true) == false) return;

                    ReportTemplateItemData itemData = selNode.Tag as ReportTemplateItemData;

                    itemData.模板名称 = txtName.Text;

                    itemData.模板信息.备注说明 = rtbDescription.Text;

                    itemData.模板信息.CopyBasePro(itemData);

                    _rtm.UpdateTemplateItem(itemData);

                    selNode.Text = itemData.模板名称;
                }
                else
                {
                    //修改分类
                    if (ClassVerify(true) == false) return;

                    ReportTemplateClassData classData = selNode.Tag as ReportTemplateClassData;

                    classData.分类名称 = txtName.Text;

                    classData.分类信息.备注说明 = rtbDescription.Text;

                    classData.分类信息.CopyBasePro(classData);

                    _rtm.UpdateTemplateClass(classData);

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
                bool isItem = (cbxType.SelectedIndex == 1) ? true : false;

                groupBox1.Enabled = isItem;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void SaveReportDesign(DataBase reportFmt, DataTable dtWordReleations)
        {
            //保存设计
            if (reportFmt == null)
            {
                throw new Exception("报告模板对象无效。"); 
            }

            ReportTemplateFormatData fmtData = reportFmt as ReportTemplateFormatData;
            if (fmtData != null)
            {
                //保存格式
                fmtData.版本 = fmtData.版本 + 1;

                _rtm.TransactionBegin();
                try
                {
                    _rtm.UpdateTemplateFormat(fmtData);
                    _rtm.ClearFormateWords(fmtData.格式ID);

                    _rtm.UpdateWordReleations(dtWordReleations);


                    _rtm.TransactionCommit();
                }
                catch(Exception ex)
                {
                    _rtm.TransactionRollback();
                    throw new Exception("格式保存失败", ex);
                }

                previewControl1.ImportByXml(fmtData.格式信息.格式内容);
            }
            else
            {
                ReportTemplateItemData itemData = reportFmt as ReportTemplateItemData;

                itemData.版本 = itemData.版本 + 1;

                _rtm.TransactionBegin();
                try
                {
                    _rtm.UpdateTemplateItem(itemData);

                    _rtm.ClearTemplateWords(itemData.模板ID);

                    _rtm.UpdateWordReleations(dtWordReleations);


                    _rtm.TransactionCommit();
                }
                catch (Exception ex)
                {
                    _rtm.TransactionRollback();
                    throw new Exception("模板保存失败", ex);
                }

                previewControl1.ImportByXml(itemData.模板信息.模板内容);
            } 
        }

        private void butConstract_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("请选择需要构造的项目。", "提示");
                    return;
                }

                if (treeView1.SelectedNode.Tag as ReportTemplateClassData != null)
                {
                    MessageBox.Show("请选择需要构造的项目。", "提示");
                    return;
                }

                frmTemplateConstruct templateConstruct = new frmTemplateConstruct(_dbHelper, cbxImageKind.Text);

                templateConstruct.OnSaveReportDesign += SaveReportDesign;



                if (treeView1.SelectedNode.Tag as ReportTemplateFormatData != null)
                {
                    //格式构造
                    ReportTemplateFormatData formatData = treeView1.SelectedNode.Tag as ReportTemplateFormatData;
                    ReportTemplateItemData itemData = treeView1.SelectedNode.Parent.Tag as ReportTemplateItemData;

                    if (string.IsNullOrEmpty(itemData.模板信息.模板内容))
                    {
                        if (MessageBox.Show("模板内容尚未构造，是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    }

                    templateConstruct.ShowFormatConstruct(formatData, itemData, this);
                }
                else
                {
                    //模板构造 
                    ReportTemplateItemData itemData = treeView1.SelectedNode.Tag as ReportTemplateItemData;

                    templateConstruct.ShowTemplateConstruct(itemData, this);
                }


            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


    }
}

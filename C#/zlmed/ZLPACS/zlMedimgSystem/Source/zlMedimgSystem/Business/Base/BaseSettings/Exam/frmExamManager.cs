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
using static System.Windows.Forms.ListViewItem;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmExamManager : Form, ISetting
    {
        private IDBQuery _dbHelper = null;
        private ExamItemModel _eim = null;
        private ILoginUser _loginUser = null;
        private ComboxEx _comboxEx = null;//字典，类别下拉框加载方法
        public frmExamManager()
            : this(null, null)
        {
        }


        public frmExamManager(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }


        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {

            _dbHelper = dbHelper;
            _loginUser = loginUser;
            _eim = new ExamItemModel(_dbHelper);
            _comboxEx = new ComboxEx(dbHelper);
        }

        public void RefreshSetting()
        {
            tabPage2.Parent = null;
            _comboxEx.BindImageKing(cbxImageKind);
            _comboxEx.BindDictionary(cbxApplySex, "性别", true);
            cbxType.SelectedIndex = 0;
            cbxDiagnoseType.SelectedIndex = 0;
            
        }
       
        private void frmExamManager_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshSetting();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }

        private void cbxImageKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                treeView1.Nodes.Clear();

                InitBodypartList();
                InitWayList();

                if (string.IsNullOrEmpty(cbxImageKind.Text))
                {
                    return;
                }


                BindExamClassData();

                BindBodypart();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 绑定检查分类数据
        /// </summary>
        private void BindExamClassData()
        {
            DataTable dtClass = _eim.GetExamClass(cbxImageKind.Text);
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

                rootNode.Nodes.Add("TMP" + classData.项目分类ID, "TMP");


                if (rootNode == null) continue;

                BindSubNode(rootNode, dtClass);

                //绑定当前分类及下一级分类的检查项目
                BindClassItem(rootNode);

                foreach (TreeNode tnSub in rootNode.Nodes)
                {
                    BindClassItem(tnSub);
                }
            }
        }

        private void BindSubNode(TreeNode pNode, DataTable dtClass)
        {
            if (pNode == null || dtClass == null) return;

            ExamClassData pClassData = pNode.Tag as ExamClassData;
            DataRow[] drSubs = dtClass.Select("上级分类ID='" + pClassData.项目分类ID + "'");

            if (drSubs.Length <= 0) return;

            foreach(DataRow drCur in drSubs)
            {
                ExamClassData subClassData = new ExamClassData();
                subClassData.BindRowData(drCur);

                TreeNode tnSub = pNode.Nodes.Add(subClassData.项目分类ID, subClassData.分类名称, 0);
                tnSub.SelectedImageIndex = 0;
                tnSub.Tag = subClassData;

                tnSub.Nodes.Add("TMP" + subClassData.项目分类ID, "TMP");

                BindSubNode(tnSub, dtClass);
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

            TreeNode[] tmpNodes = tnClass.Nodes.Find("TMP" + classData.项目分类ID, false);
            if (tmpNodes.Length <= 0) return;

            DataTable dtItem = _eim.GetExamItemByClass(classData.项目分类ID);

            foreach(DataRow dr in dtItem.Rows)
            {
                ExamItemData itemData = new ExamItemData();
                itemData.BindRowData(dr);

                TreeNode tnItem = tnClass.Nodes.Add(itemData.项目ID, itemData.项目名称, 1);
                tnItem.SelectedImageIndex = 1;
                tnItem.Tag = itemData;
            }

            tnClass.Nodes.Remove(tmpNodes[0]);

        }

        private void InitBodypartList()
        {
            listView1.Clear();
            listView1.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();
            columnDefault.Text = "可选部位";
            columnDefault.Name = "可选部位";
            columnDefault.Width = 100;


            listView1.Columns.Add(columnDefault);


            columnDefault = new ColumnHeader();
            columnDefault.Text = "分组标记";
            columnDefault.Name = "分组标记";
            columnDefault.Width = 100;


            listView1.Columns.Add(columnDefault);


            columnDefault = new ColumnHeader();
            columnDefault.Text = "默认选择";
            columnDefault.Name = "默认选择";
            columnDefault.Width = 80;


            listView1.Columns.Add(columnDefault);

            listView1.View = View.Details;
        }

        private void BindBodypart()
        {
            _isLoadBodypart = true;
            try
            {
                DataTable dtBodypart = _eim.GetAllBodypartInfo(cbxImageKind.Text);

                //listView1.Columns.Clear();

                //foreach (DataColumn dc in dtBodypart.Columns)
                //{
                //    if (("部位名称,分组标记").IndexOf(dc.Caption) >= 0)
                //    {
                //        ColumnHeader columnHeader = new ColumnHeader();
                //        columnHeader.Text = (dc.Caption.Equals("部位名称")) ? dc.Caption : "可选部位";
                //        columnHeader.Name = dc.Caption;

                //        columnHeader.Width = 100;


                //        listView1.Columns.Add(columnHeader);
                //    }
                //}

                //ColumnHeader columnDefault = new ColumnHeader();
                //columnDefault.Text = "默认选择";
                //columnDefault.Name = "默认选择";
                //columnDefault.Width = 80;


                //listView1.Columns.Add(columnDefault);


                DataTable dtGroup = _eim.GetBodypartGroups(cbxImageKind.Text);

                foreach (DataRow dr in dtGroup.Rows)
                {
                    string groupName = dr["分组标记"].ToString();

                    ListViewGroup lvg = new ListViewGroup(groupName);
                    listView1.Groups.Add(lvg);
                }


                foreach (DataRow drItem in dtBodypart.Rows)
                {
                    BodypartInfoData bodypartData = new BodypartInfoData();
                    bodypartData.BindRowData(drItem);

                    ListViewGroup lvgCur = GetCurGroup(bodypartData.分组标记);

                    ListViewItem itemNew = new ListViewItem(new string[] { bodypartData.部位名称, bodypartData.分组标记 }, 0, lvgCur);

                    itemNew.Name = bodypartData.部位ID;
                    itemNew.SubItems.Add("□").Name = "默认选择";//✔☑

                    itemNew.Tag = bodypartData;

                    listView1.Items.Add(itemNew);
                }

                listView1.View = View.Details;
            }
            finally
            {
                _isLoadBodypart = false;
            }
        }

        private ListViewGroup GetCurGroup(string groupName)
        {
            if (string.IsNullOrEmpty(groupName)) return null;

            foreach (ListViewGroup lvg in listView1.Groups)
            {
                if (lvg.Header.Equals(groupName))
                {
                    return lvg;
                }
            }

            return null;
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
                    ExamClassData classData = new ExamClassData();

                    classData.项目分类ID = SqlHelper.GetCmpUID();
                    classData.影像类别 = cbxImageKind.Text;
                    classData.分类名称 = txtName.Text;
                    classData.分类信息.创建日期 = DateTime.Now;
                    classData.分类信息.分类描述 = rtbDescription.Text;
                    classData.分类信息.适用性别 = cbxApplySex.Text;
                    

                    TreeNode tn = null;
                    if (treeView1.SelectedNode != null)
                    {
                        tn = treeView1.SelectedNode;

                        if (tn.Tag is ExamItemData)
                        {
                            tn = tn.Parent;
                        }

                        ExamClassData pData = tn.Tag as ExamClassData;

                        classData.上级分类ID = pData.项目分类ID;
                    }

                    classData.分类信息.CopyBasePro(classData);

                    _eim.NewExamClass(classData);
                     
                    if (tn == null)
                    {
                        newNode = treeView1.Nodes.Add(classData.项目分类ID, classData.分类名称, 0);
                    }
                    else
                    {
                        newNode = tn.Nodes.Add(classData.项目分类ID, classData.分类名称, 0);

                        tn.Expand();
                    }
                    newNode.SelectedImageIndex = 0;
                    newNode.Tag = classData;
                     
                }
                else
                {
                    //新增项目
                    if (ItemVerify(false) == false) return;
                     
                    ExamItemData itemData = new ExamItemData();

                    itemData.项目ID = SqlHelper.GetCmpUID();
                    itemData.项目名称 = txtName.Text; 
                    itemData.项目信息.创建日期 = DateTime.Now;
                    itemData.项目信息.对照编码 = txtMatchCode.Text;
                    itemData.项目信息.诊疗分类 = cbxDiagnoseType.Text;
                    //itemData.项目信息.适用性别 = cbxApplySex.Text;
                    itemData.项目信息.注意事项 = rtbCareDescription.Text;
                    itemData.项目信息.参考说明 = rtbReferDescription.Text;
                    itemData.项目信息.项目备注 = rtbDescription.Text; 

                    TreeNode tn = null;
                    if (treeView1.SelectedNode != null)
                    {
                        tn = treeView1.SelectedNode;

                        if (tn.Tag is ExamItemData)
                        {
                            tn = tn.Parent;
                        }

                        ExamClassData pData = tn.Tag as ExamClassData;

                        itemData.项目分类ID = pData.项目分类ID;
                    }

                    itemData.项目信息.CopyBasePro(itemData);
                   
                    _eim.NewExamItem(itemData);

                    

                    if (tn == null)
                    {
                        newNode = treeView1.Nodes.Add(itemData.项目ID, itemData.项目名称, 1);
                    }
                    else
                    {
                        newNode = tn.Nodes.Add(itemData.项目ID, itemData.项目名称, 1);

                        tn.Expand();
                    }

                    newNode.SelectedImageIndex = 1;
                    newNode.Tag = itemData;

                }

                treeView1.SelectedNode = newNode;

                ButtonHint.Start(butNew, "OK");
            }
            catch(Exception ex)
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

            string classId = _eim.GetExamClassIdByName(txtName.Text, cbxImageKind.Text);

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
                MessageBox.Show("请选择对应的项目分类。", "提示");
                treeView1.Focus();
                return false;
            }

            string itemId = _eim.GetExamItemIdByName(txtName.Text);

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

                if (delNode.Tag is ExamItemData)
                {
                    //删除检查项目
                    ExamItemData itemData = delNode.Tag as ExamItemData;
                    //提示是否删除项目
                    if (MessageBox.Show("是否删除项目："+itemData.项目名称.ToString()+"？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
                    _eim.DelExamItem(itemData.项目ID);

                    delNode.Parent.Nodes.Remove(delNode);
                }
                else
                {
                    if (delNode.Nodes.Count > 0)
                    {
                        MessageBox.Show("项目存在子项，不允许删除。", "提示");
                        return;
                    }
                    //删除检查分类
                    ExamClassData classData = delNode.Tag as ExamClassData;
                    //提示是否删除分类
                    if (MessageBox.Show("是否删除分类：" + classData.分类名称.ToString() + "？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;

                    _eim.DelExamClass(classData.项目分类ID);

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

                if (selNode.Tag is ExamItemData)
                {
                    //修改项目
                    if (ItemVerify(true) == false) return;

                    ExamItemData itemData = selNode.Tag as ExamItemData;

                    itemData.项目名称 = txtName.Text;
                    itemData.项目信息.诊疗分类 = cbxDiagnoseType.Text;
                    itemData.项目信息.对照编码 = txtMatchCode.Text;
                    //itemData.项目信息.适用性别 = cbxApplySex.Text;
                    itemData.项目信息.注意事项 = rtbCareDescription.Text;
                    itemData.项目信息.参考说明 = rtbReferDescription.Text;
                    itemData.项目信息.项目备注 = rtbDescription.Text;

                    itemData.项目信息.CopyBasePro(itemData);

                    _eim.UpdateExamItem(itemData);

                    selNode.Text = itemData.项目名称;
                }
                else
                {
                    //修改分类
                    if (ClassVerify(true) == false) return;

                    ExamClassData classData = selNode.Tag as ExamClassData;

                    classData.分类名称 = txtName.Text;
                    classData.分类信息.分类描述 = rtbDescription.Text;
                    classData.分类信息.适用性别 = cbxApplySex.Text;

                    classData.分类信息.CopyBasePro(classData);

                    _eim.UpdateExamClass(classData);

                    selNode.Text = classData.分类名称;
                }

                ButtonHint.Start(butModify, "OK");

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                SyncSelNodeData();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void InitWayList()
        {
            listView2.Clear();
            listView2.Columns.Clear();

            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "默认方法";
            columnHeader.Name = "默认方法";

            columnHeader.Width = 100;

            listView2.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "关系";
            columnHeader.Name = "关系";

            columnHeader.Width = 80;

            listView2.Columns.Add(columnHeader);

            listView2.View = View.Details;
        }

        private void ClearData()
        {
            txtName.Text = "";
            txtName.Tag = null;

            txtMatchCode.Text = "";

            cbxType.SelectedIndex = 0;
            cbxDiagnoseType.SelectedIndex = 0;

            cbxApplySex.SelectedIndex = -1;
            cbxApplySex.Text = "";

            rtbCareDescription.Text = "";
            rtbReferDescription.Text = "适应症:" + System.Environment.NewLine + "禁忌症:" + System.Environment.NewLine + "高危因素:" + System.Environment.NewLine;

            rtbDescription.Text = "";

            if (listView1.SelectedItems.Count > 0) listView1.SelectedItems[0].Selected = false;

            InitWayList(); 

            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null; 
            
        }



        private void SyncSelNodeData()
        {
            try
            {

                ClearData();

                listView1.Enabled = false;
                listView2.Enabled = false;

                if (treeView1.SelectedNode == null) return;

                TreeNode selNode = treeView1.SelectedNode;

                if (selNode.Tag is ExamItemData)
                {
                    ExamItemData itemData = selNode.Tag as ExamItemData;

                    txtName.Text = itemData.项目名称;
                    txtName.Tag = itemData.项目ID;

                    cbxType.SelectedIndex = 0;

                    txtMatchCode.Text = itemData.项目信息.对照编码;
                    cbxDiagnoseType.Text = itemData.项目信息.诊疗分类;
                    //cbxApplySex.Text = itemData.项目信息.适用性别;

                    rtbCareDescription.Text = itemData.项目信息.注意事项;
                    rtbReferDescription.Text = itemData.项目信息.参考说明;
                    rtbDescription.Text = itemData.项目信息.项目备注;

                    //读取部位配置
                    ResetBodypartSetting(itemData);

                    listView1.Enabled = true;
                }
                else
                {
                    ExamClassData classData = selNode.Tag as ExamClassData;

                    txtName.Text = classData.分类名称;
                    txtName.Tag = classData.项目分类ID;

                    cbxType.SelectedIndex = 1;
                    cbxDiagnoseType.SelectedIndex = -1;
                    rtbReferDescription.Text = "";

                    cbxApplySex.Text = classData.分类信息.适用性别;
                    rtbDescription.Text = classData.分类信息.分类描述;

                    //读取下级分类中的项目
                    foreach (TreeNode tnSub in selNode.Nodes)
                    {
                        BindClassItem(tnSub);
                    }

                    ClearBodypartSetting();
                }

 

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

                txtMatchCode.Enabled = isItem;
                cbxDiagnoseType.Enabled = isItem;
                cbxApplySex.Enabled = !isItem;
                rtbCareDescription.Enabled = isItem;
                rtbReferDescription.Enabled = isItem;
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

                if (expNode.Tag is ExamClassData)
                {
                    //读取下级分类中的项目
                    foreach (TreeNode tnSub in expNode.Nodes)
                    {
                        BindClassItem(tnSub);
                    }
                }
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
                InitWayList();
                listView2.Enabled = false;

                ExamItemData itemData = GetSelectItemData(); 

                if (itemData == null) return; 
                if (listView1.SelectedItems.Count <= 0) return;

                BodypartInfoData bodypartData = listView1.SelectedItems[0].Tag as BodypartInfoData;
                if (bodypartData == null) return;

                BindBodypartWay(bodypartData);

                listView2.Enabled = listView1.SelectedItems[0].Checked;
                 

                JExamBodypartSetting bodypartSetting = null;

                if (itemData.项目信息.可选部位.Count > 0)
                {
                    int index = (itemData.项目信息.可选部位 as List<JExamBodypartSetting>).FindIndex(T=>T.部位ID == bodypartData.部位ID);

                    if (index >= 0) bodypartSetting = itemData.项目信息.可选部位[index];
                }

                ResetBodypartWaySetting(bodypartSetting);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private bool _isLoadBodypartWay = false;
        private void BindBodypartWay(BodypartInfoData bodypartData)
        {
            int maxColumn = 0;

            _isLoadBodypartWay = true;
            try
            {
                foreach (JBodypartWay bw in bodypartData.部位信息.互斥方法)
                {
                    if (bw.附加方法.Count > maxColumn) maxColumn = bw.附加方法.Count;
                }

                foreach (JBodypartWay bw in bodypartData.部位信息.共用方法)
                {
                    if (bw.附加方法.Count > maxColumn) maxColumn = bw.附加方法.Count;
                }


                DataTable dtBodypart = _eim.GetAllBodypartInfo(cbxImageKind.Text);

                listView2.Columns.Clear();

                ColumnHeader columnHeader = new ColumnHeader();
                columnHeader.Text = "默认方法";
                columnHeader.Name = "默认方法";

                columnHeader.Width = 100;

                listView2.Columns.Add(columnHeader);

                columnHeader = new ColumnHeader();
                columnHeader.Text = "关系";
                columnHeader.Name = "关系";

                columnHeader.Width = 80;

                listView2.Columns.Add(columnHeader);

                for (int i = 1; i <= maxColumn; i++)
                {
                    columnHeader = new ColumnHeader();
                    columnHeader.Text = "附加方法" + i.ToString();
                    columnHeader.Name = "附加方法" + i.ToString();

                    columnHeader.Width = 100;

                    listView2.Columns.Add(columnHeader);
                }

                foreach (JBodypartWay bw in bodypartData.部位信息.互斥方法)
                {
                    ListViewItem itemNew = new ListViewItem(bw.方法名称);
                    itemNew.Name = bw.方法名称;

                    itemNew.SubItems.Add("互斥");
                    foreach (string attach in bw.附加方法)
                    {
                        itemNew.SubItems.Add("□" + attach).Name = "附加方法";
                    }
                    //如果方法列比listview的列少，多余的列插入空，否则后续循环索引会提示：.ArgumentOutOfRangeException 异常
                    if(maxColumn- bw.附加方法.Count>0)
                    {
                        for(int i = bw.附加方法.Count+1;i<= maxColumn; i++)
                        {
                            itemNew.SubItems.Add(string.Empty).Name = "附加方法";
                        }
                    }
                    itemNew.Tag = bw;

                    listView2.Items.Add(itemNew);
                }

                foreach (JBodypartWay bw in bodypartData.部位信息.共用方法)
                {
                    ListViewItem itemNew = new ListViewItem(bw.方法名称);
                    itemNew.Name = bw.方法名称;

                    itemNew.SubItems.Add("共用");
                    foreach (string attach in bw.附加方法)
                    {
                        itemNew.SubItems.Add("□" + attach).Name = "附加方法"; //■
                    }

                    //如果方法列比listview的列少，多余的列插入空，否则后续循环索引会提示：.ArgumentOutOfRangeException 异常
                    if (maxColumn - bw.附加方法.Count > 0)
                    {
                        for (int i = bw.附加方法.Count + 1; i <= maxColumn; i++)
                        {
                            itemNew.SubItems.Add(string.Empty).Name = "附加方法";
                        }
                    }
                    itemNew.Tag = bw;

                    listView2.Items.Add(itemNew);
                }

                listView2.View = View.Details;
            }
            finally
            {
                _isLoadBodypartWay = false;
            }

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //□表示未选择，■表示已选择

                ExamItemData itemData = GetSelectItemData();
                if (itemData == null) return;

                Point cp = listView1.PointToClient(MousePosition);
                ListViewItem lvi = listView1.GetItemAt(cp.X, cp.Y);

                if (lvi == null) return;

                ListViewSubItem subItem = lvi.GetSubItemAt(cp.X, cp.Y);
                if (subItem == null) return;

                if (subItem.Name == "默认选择")
                {
                    if (subItem.Text.Equals("□"))
                    {                        
                        if (lvi.Checked == false) lvi.Checked = true;

                        subItem.Text = "■";
                    }
                    else
                    {
                        subItem.Text = "□";
                    }
                }
                                 
                UpdteBodypartSetting(itemData, lvi);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void UpdteBodypartSetting(ExamItemData itemData, ListViewItem mouseItem)
        {
            if (itemData == null || mouseItem == null) return;

            JExamBodypartSetting bodypartSetting = null;

            if (itemData.项目信息.可选部位.Count > 0)
            {
                int index = (itemData.项目信息.可选部位 as List<JExamBodypartSetting>).FindIndex(T => T.部位ID == mouseItem.Name);

                if (index >= 0) bodypartSetting = itemData.项目信息.可选部位[index];
            }

            if (mouseItem.Checked)
            {
                //添加可选部位
                if (bodypartSetting == null)
                {
                    bodypartSetting = new JExamBodypartSetting();

                    itemData.项目信息.可选部位.Add(bodypartSetting);
                }
                
                bodypartSetting.部位ID = mouseItem.Name;
                bodypartSetting.部位名称 = mouseItem.SubItems[0].Text;
                bodypartSetting.默认选择 = (mouseItem.SubItems[2].Text.Equals("□")) ? false : true; 
            }
            else
            {
                //删除可选部位
                if (bodypartSetting != null) itemData.项目信息.可选部位.Remove(bodypartSetting);
            }
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //□表示未选择，■表示已选择
                JExamBodypartSetting bodypartSetting = GetSelectBodypartSettingData();
                if (bodypartSetting == null) return;


                Point cp = listView2.PointToClient(MousePosition);
                ListViewItem lvi = listView2.GetItemAt(cp.X, cp.Y);

                if (lvi == null) return;

                ListViewSubItem subItem = lvi.GetSubItemAt(cp.X, cp.Y);
                //如果鼠标点击选择的没有任何附加方法，
                if (subItem == null || string.IsNullOrEmpty(subItem.Text) == true) return;
              
                if (subItem.Name == "附加方法")
                {
                    if (subItem.Text.Substring(0,1).Equals("□"))
                    {
                        if (lvi.Checked == false) lvi.Checked = true;
                        subItem.Text = subItem.Text.Replace("□", "■");                     
                    }
                    else
                    {
                        subItem.Text = subItem.Text.Replace("■", "□");
                    }
                }
                                  
                UpdateBodypartWaySetting(bodypartSetting, lvi);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 获取选择的项目数据
        /// </summary>
        /// <returns></returns>
        private ExamItemData GetSelectItemData()
        {
            TreeNode tn = treeView1.SelectedNode;

            if (tn == null) return null;
            if ((tn.Tag is ExamItemData) == false) return null;

            return tn.Tag as ExamItemData;
        }

        /// <summary>
        /// 获取当前部位设置
        /// </summary>
        /// <returns></returns>
        private JExamBodypartSetting GetSelectBodypartSettingData()
        {
            TreeNode tn = treeView1.SelectedNode;

            if (tn == null) return null;
            if ((tn.Tag is ExamItemData) == false) return null;

            if (listView1.SelectedItems.Count <= 0) return null;


            ExamItemData itemData = (tn.Tag as ExamItemData);
            if (itemData.项目信息.可选部位.Count <= 0) return null;

            int index = (itemData.项目信息.可选部位 as List<JExamBodypartSetting>).FindIndex(T => T.部位ID == listView1.SelectedItems[0].Name);
            if (index < 0) return null;

            return itemData.项目信息.可选部位[index];

        }

        /// <summary>
        /// 更新默认方法设置
        /// </summary>
        /// <param name="bodypartSetting"></param>
        /// <param name="mouseItem"></param>
        private void UpdateBodypartWaySetting(JExamBodypartSetting bodypartSetting, ListViewItem mouseItem)
        {
            if (bodypartSetting == null || mouseItem == null) return;

            JExamBodypartWaySetting waySetting = null;

            if (bodypartSetting.默认方法.Count > 0)
            {
                int index = (bodypartSetting.默认方法 as List<JExamBodypartWaySetting>).FindIndex(T => T.方法名称 == mouseItem.Name);

                if (index >= 0) waySetting = bodypartSetting.默认方法[index];
            }


            if (mouseItem.Checked)
            {
                //添加可选部位
                if (waySetting == null)
                {
                    waySetting = new JExamBodypartWaySetting();

                    bodypartSetting.默认方法.Add(waySetting);
                }

                waySetting.方法名称 = mouseItem.Name;

                for(int i = 2; i < mouseItem.SubItems.Count; i ++)
                {
                    string attach = mouseItem.SubItems[i].Text;
                    //如果方法对应的附加方法为空，后面的附加方法也为空，退出循环
                    if (string.IsNullOrEmpty(attach)) break;
                    if (attach.Substring(0,1).Equals("■"))
                    {
                        attach = attach.Substring(1);
                        if (waySetting.附加方法.IndexOf(attach) < 0) waySetting.附加方法.Add(attach);
                    }

                } 
            }
            else
            {
                //删除可选部位
                if (waySetting != null) bodypartSetting.默认方法.Remove(waySetting);
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                listView2.Enabled = false;

                if (_isLoadBodypart) return;

                
                if (e.Item == null) return;

                ExamItemData itemData = GetSelectItemData();
                if (itemData == null) return;

                UpdteBodypartSetting(itemData, e.Item);

                listView2.Enabled = e.Item.Checked;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
        
        /// <summary>
        /// 清除部位选择设置
        /// </summary>
        private void ClearBodypartSetting()
        {
            foreach(ListViewItem lvi in listView1.Items)
            {
                lvi.Checked = false;

                lvi.SubItems[2].Text = "□";
            }

            ClearBodypartWaySetting();
        }

        private bool _isLoadBodypart = false;
        /// <summary>
        /// 重设项目的部位方法设置-部位
        /// </summary>
        /// <param name="itemData"></param>
        private void ResetBodypartSetting(ExamItemData itemData)
        {
            _isLoadBodypart = true;

            try
            {
                ClearBodypartSetting();

                if (itemData == null) return;

                foreach (JExamBodypartSetting bw in itemData.项目信息.可选部位)
                {
                    ListViewItem[] lvis = listView1.Items.Find(bw.部位ID, true);

                    foreach (ListViewItem lvi in lvis)
                    {
                        lvi.Checked = true;

                        if (bw.默认选择) lvi.SubItems[2].Text = "■";
                    }
                }
            }
            finally
            {
                _isLoadBodypart = false;
            }
        }

        /// <summary>
        /// 清除部位方法设置
        /// </summary>
        private void ClearBodypartWaySetting()
        {
            foreach (ListViewItem lvi in listView2.Items)
            {
                lvi.Checked = false;

                for (int i = 2; i < listView2.Columns.Count; i++)
                {
                    if (lvi.SubItems.Count < i) break;
                    if (lvi.SubItems[i] != null) lvi.SubItems[i].Text = lvi.SubItems[i].Text.Replace("■", "□");
                }
            }
        }

        /// <summary>
        /// 重设项目的部位方法设置-方法
        /// </summary>
        /// <param name="bw"></param>
        private void ResetBodypartWaySetting(JExamBodypartSetting bw)
        {
            _isLoadBodypartWay = true;

            try
            {
                ClearBodypartWaySetting();

                if (bw == null) return;

                foreach (JExamBodypartWaySetting way in bw.默认方法)
                {
                    ListViewItem[] lvis = listView2.Items.Find(way.方法名称, true);
                    foreach (ListViewItem lvi in lvis)
                    {
                        lvi.Checked = true;


                        foreach (string attach in way.附加方法)
                        {
                            int index = FindSubItemByText(lvi.SubItems, "□" + attach);
                            if (index >= 0) lvi.SubItems[index].Text = "■" + attach;
                        }
                    }

                }
            }
            finally
            {
                _isLoadBodypartWay = false;
            }
        }

        /// <summary>
        /// 根据文本内容查找索引
        /// </summary>
        /// <param name="subItems"></param>
        /// <param name="findText"></param>
        /// <returns></returns>
        private int FindSubItemByText(ListViewSubItemCollection subItems, string findText)
        {
            for(int i = 0; i < subItems.Count; i ++)
            {
                if (subItems[i].Text.Equals(findText)) return i;
            }

            return -1;
        }

        private void butApplyCurSetting_Click(object sender, EventArgs e)
        {
            try
            {
                ExamItemData itemData = GetSelectItemData();

                if (itemData == null)
                {
                    MessageBox.Show("未能获取有效的项目数据，不能执行此操作。", "提示");
                    return;
                }

                if (tabControl1.SelectedTab.Text.Equals("部位关联"))
                {
                    _eim.UpdateExamItem(itemData);
                }
                else
                {

                }

                ButtonHint.Start(butApplyCurSetting, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                if (_isLoadBodypartWay) return;
                //如果鼠标选择的是空的附加方法，退出。
                if (e.Item == null || e.Item.Index==0) return;

                JExamBodypartSetting bodypartSetting = GetSelectBodypartSettingData();
                if (bodypartSetting == null) return;

                UpdateBodypartWaySetting(bodypartSetting, e.Item);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

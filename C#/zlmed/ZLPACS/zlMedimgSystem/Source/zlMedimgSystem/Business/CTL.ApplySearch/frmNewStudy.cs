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

namespace zlMedimgSystem.CTL.ApplySearch
{
    public partial class frmNewStudy : Form
    {
        #region  公共属性

        public string ItemID;
        public string OrderContent;
        public string Bodyparts;
        public string Modality;
        public JApplyExamItem oneExamItem;

        #endregion

        #region 私有属性

        private ExamItemModel _eiModel = null;
        private BodypartModel _bpModel = null;
        private IDBQuery _dbHelper = null;
        private bool _isLoadWays = false;
        private bool _isLoadBodypart = false;
        private IList<JExamBodypartSetting> _bodypartSetting = null;

        #endregion

        #region 构造函数

        public frmNewStudy():this(null)
        {
            
        }

        public frmNewStudy(IDBQuery dbHelper)
        {
            InitializeComponent();
            Init(dbHelper);
        }

        #endregion

        #region 私有方法
    

        /// <summary>
        /// 显示部位信息
        /// </summary>
        /// <param name="bodypartData"></param>
        private void BindBodypartWay(BodypartInfoData bodypartData)
        {
            int maxColumn = 0;

            _isLoadWays = true;
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


                DataTable dtBodypart = _eiModel.GetAllBodypartInfo(cbxModality.Text);

                lstWays.Columns.Clear();

                ColumnHeader columnHeader = new ColumnHeader();
                columnHeader.Text = "默认方法";
                columnHeader.Name = "默认方法";

                columnHeader.Width = 100;

                lstWays.Columns.Add(columnHeader);

                columnHeader = new ColumnHeader();
                columnHeader.Text = "关系";
                columnHeader.Name = "关系";

                columnHeader.Width = 80;

                lstWays.Columns.Add(columnHeader);

                for (int i = 1; i <= maxColumn; i++)
                {
                    columnHeader = new ColumnHeader();
                    columnHeader.Text = "附加方法" + i.ToString();
                    columnHeader.Name = "附加方法" + i.ToString();

                    columnHeader.Width = 100;

                    lstWays.Columns.Add(columnHeader);
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

                    itemNew.Tag = bw;

                    lstWays.Items.Add(itemNew);
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

                    itemNew.Tag = bw;

                    lstWays.Items.Add(itemNew);
                }

                lstWays.View = View.Details;
            }
            finally
            {
                _isLoadWays = false;
            }

        }

        /// <summary>
        /// 设置“方法”是否被勾选
        /// </summary>
        /// <param name="bw"></param>
        private void ResetWaySetting(JExamBodypartSetting bw)
        {
            _isLoadWays = true;

            try
            {
                if (bw == null) return;

                foreach (JExamBodypartWaySetting way in bw.默认方法)
                {
                    ListViewItem[] lvis = lstWays.Items.Find(way.方法名称, true);
                    foreach (ListViewItem lvi in lvis)
                    {
                        lvi.Checked = true;

                        foreach (string attach in way.附加方法)
                        {
                            int index = FindSubItemByText(lvi.SubItems, "□" + attach);
                            if (index >= 0) lvi.SubItems[index].Text = "√" + attach;
                        }
                    }
                }
            }
            finally
            {
                _isLoadWays = false;
            }
        }

        /// <summary>
        /// 根据文本内容查找索引
        /// </summary>
        /// <param name="subItems"></param>
        /// <param name="findText"></param>
        /// <returns></returns>
        private int FindSubItemByText(ListViewItem.ListViewSubItemCollection subItems, string findText)
        {
            for (int i = 0; i < subItems.Count; i++)
            {
                if (subItems[i].Text.Equals(findText)) return i;
            }

            return -1;
        }


        /// <summary>
        /// 同步显示检查项目对应的部位信息
        /// </summary>
        private void SyncSelNodeData()
        {            
            try
            {
                lblItem.Text = "";
                lblBodypart.Text = "";

                lstBodyPart.Enabled = false;               
                lstWays.Clear();                
                lstWays.Enabled = false;

                if (trvItems.SelectedNode == null) return;

                TreeNode selNode = trvItems.SelectedNode;

                if (selNode.Tag is ExamItemData)
                {
                    ExamItemData itemData = selNode.Tag as ExamItemData;
                    _bodypartSetting = itemData.项目信息.可选部位;

                    loadBodyPart(itemData);                    
                    lstBodyPart.Enabled = true;                    

                    lblItem.Text = itemData.项目名称;
                    lblItem.Tag = itemData.项目信息.对照编码;
                    lblBodypart.Text = GetOrderContent();                    
                    lblBodypart.Tag =  GetBodypartContent();    
                    oneExamItem = getJApplyExamItem();
                }                
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 根据当前部位方法的选择，组织“医嘱内容”数据
        /// 格式为：颅脑CT扫描,常规执行:颅脑(增强扫描,血管重建),蝶鞍(增强扫描,CT重建),颅底(增强扫描,CT重建)，只需要冒号后面的部分
        /// </summary>
        /// <returns></returns>
        private string GetOrderContent()
        {
            string strBodypart = "";
            string strWays = "";

            try
            {
                //(部位+方法用;分割，组成一个检查项目，多个检查项目用,分割)
                //颅脑; 增强扫描,颅脑; 平扫
                //医嘱内容：颅脑CT扫描,常规执行:颅脑(增强扫描,血管重建),蝶鞍(增强扫描,CT重建),颅底(增强扫描,CT重建)，只需要冒号后面的部分
                foreach (JExamBodypartSetting bodypartSetting in _bodypartSetting)
                {
                    if (bodypartSetting.默认选择 == true)
                    {
                        strBodypart = strBodypart + "," + bodypartSetting.部位名称;
                        strWays = "";
                        foreach (JExamBodypartWaySetting waySetting in bodypartSetting.默认方法)
                        {                            
                            strWays = strWays + "," + waySetting.方法名称;
                            foreach (string attach in waySetting.附加方法)
                            {                               
                                strWays = strWays + "," + attach;
                            }
                        }
                        if (bodypartSetting.默认方法.Count > 0)
                        {
                            if (strWays !="")
                            {
                                strWays = strWays.Substring(1);
                            }
                            strBodypart = strBodypart + "(" + strWays + ")";
                        }
                    }
                }
                if (strBodypart != "")
                {
                    strBodypart = strBodypart.Substring(1);
                }                
                return strBodypart;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return strBodypart;
            }
        }

        /// <summary>
        /// 根据当前部位方法的选择，组织部位方法串
        /// 格式为：(部位+方法用;分割，组成一个检查项目，多个检查项目用,分割)
        /// 例如：颅脑; 增强扫描,颅脑; 平扫
        /// </summary>
        /// <returns></returns>
        private string GetBodypartContent()
        {
            string strBodypart = "";            

            try
            {
                //(部位+方法用;分割，组成一个检查项目，多个检查项目用,分割)
                //颅脑; 增强扫描,颅脑; 平扫                
                foreach (JExamBodypartSetting bodypartSetting in _bodypartSetting)
                {
                    if (bodypartSetting.默认选择 == true)
                    {                        
                        foreach (JExamBodypartWaySetting waySetting in bodypartSetting.默认方法)
                        {
                            strBodypart = strBodypart + "," + bodypartSetting.部位名称 + ";" + waySetting.方法名称;                            
                            foreach (string attach in waySetting.附加方法)
                            {
                                strBodypart = strBodypart + "," + bodypartSetting.部位名称 + ";" + attach;                                
                            }
                        }
                        if (bodypartSetting.默认方法.Count == 0)
                        {
                            strBodypart = strBodypart + "," + bodypartSetting.部位名称 + ";";
                        }
                    }
                }
                if (strBodypart != "")
                {
                    strBodypart = strBodypart.Substring(1);
                }
                return strBodypart;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return strBodypart;
            }
        }

        private JApplyExamItem getJApplyExamItem()
        {
            JApplyExamItem oneExamItem = new JApplyExamItem();
            JApplyExamBodypart oneBodypart = new JApplyExamBodypart();
            try
            {
                oneExamItem.项目名称 = lblItem.Text;
                //(部位+方法用;分割，组成一个检查项目，多个检查项目用,分割)
                //颅脑; 增强扫描,颅脑; 平扫                
                foreach (JExamBodypartSetting bodypartSetting in _bodypartSetting)
                {
                    if (bodypartSetting.默认选择 == true)
                    {
                        foreach (JExamBodypartWaySetting waySetting in bodypartSetting.默认方法)
                        {
                            oneBodypart = new JApplyExamBodypart();
                            oneBodypart.部位名称 = bodypartSetting.部位名称;
                            oneBodypart.方法 = waySetting.方法名称;                            
                            oneExamItem.部位方法.Add(oneBodypart);
                            //strBodypart = strBodypart + "," + bodypartSetting.部位名称 + ";" + waySetting.方法名称;
                            foreach (string attach in waySetting.附加方法)
                            {
                                oneBodypart = new JApplyExamBodypart();
                                oneBodypart.部位名称 = bodypartSetting.部位名称;
                                oneBodypart.方法 = attach;
                                oneExamItem.部位方法.Add(oneBodypart);
                                //strBodypart = strBodypart + "," + bodypartSetting.部位名称 + ";" + attach;
                            }
                        }
                        if (bodypartSetting.默认方法.Count == 0)
                        {
                            oneBodypart = new JApplyExamBodypart();
                            oneBodypart.部位名称 = bodypartSetting.部位名称;
                            oneBodypart.方法 = "";
                            oneExamItem.部位方法.Add(oneBodypart);
                            //strBodypart = strBodypart + "," + bodypartSetting.部位名称 + ";";
                        }
                    }
                }
                
                return oneExamItem;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return null;
            }
        }

        /// <summary>
        /// 初始化部位列表
        /// </summary>
        private void InitBodypartList()
        {
            lstBodyPart.Clear();
            lstBodyPart.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();
            columnDefault.Text = "可选部位";
            columnDefault.Name = "可选部位";
            columnDefault.Width = 400;
            lstBodyPart.Columns.Add(columnDefault);

            lstBodyPart.View = View.Details;
        }

        /// <summary>
        /// 加载部位列表
        /// </summary>
        /// <param name="itemData"></param>
        private void loadBodyPart(ExamItemData itemData)
        {            
            try
            {
                _isLoadBodypart = true;
                lstBodyPart.Items.Clear();

                if (itemData == null) return;

                foreach (JExamBodypartSetting bps in itemData.项目信息.可选部位)
                {
                    //根据部位ID，提取部位信息
                    DataTable dtBodypart = _bpModel.GetBodypartInfoByID(bps.部位ID);

                    //显示部位分组和信息
                    if (dtBodypart != null)
                    {
                        BodypartInfoData bodypartData = new BodypartInfoData();
                        bodypartData.BindRowData(dtBodypart.Select()[0]);
                        ListViewGroup lvg = new ListViewGroup(bodypartData.分组标记);
                        if (lstBodyPart.Groups.Contains(lvg) == false)
                        {
                            lstBodyPart.Groups.Add(lvg);
                        }

                        ListViewGroup lvgCur = GetCurGroup(bodypartData.分组标记);

                        ListViewItem itemNew = new ListViewItem(new string[] { bodypartData.部位名称 }, 0, lvgCur);

                        itemNew.Name = bodypartData.部位ID;
                        //itemNew.SubItems.Add("□").Name = "默认选择";//✔☑
                        itemNew.Tag = bodypartData;
                        itemNew.Checked = (bps.默认选择 == true);
                        lstBodyPart.Items.Add(itemNew);                        
                    }
                }
                if (itemData.项目信息.可选部位.Count >0)
                {
                    lstBodyPart.Items[0].Selected = true;
                    lstBodyPart.Select();
                }                
                _isLoadBodypart = false;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isLoadBodypart = false;
            }         
        }

        /// <summary>
        /// 获取当前分组
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        private ListViewGroup GetCurGroup(string groupName)
        {
            if (string.IsNullOrEmpty(groupName)) return null;

            foreach (ListViewGroup lvg in lstBodyPart.Groups)
            {
                if (lvg.Header.Equals(groupName))
                {
                    return lvg;
                }
            }

            return null;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        private void Init(IDBQuery dbHelper)
        {
            _dbHelper = dbHelper;           
            _eiModel = new ExamItemModel(_dbHelper);
            _bpModel = new BodypartModel(_dbHelper);
            InitBodypartList(); 
            InitModality();
            BindExamClassData();            
        }

        /// <summary>
        /// 初始化影像类别下拉框
        /// </summary>
        private void InitModality()
        {
            try
            {
                DataTable dtModality = _eiModel.GetImageKind();

                cbxModality.DisplayMember = "影像类别";
                cbxModality.DataSource = dtModality;

                if (cbxModality.Items.Count > 0) cbxModality.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 绑定检查分类数据
        /// </summary>
        private void BindExamClassData()
        {
            trvItems.Nodes.Clear();
            
            DataTable dtClass = _eiModel.GetExamClass(cbxModality.Text);
            if (dtClass.Rows.Count <= 0) return;

            DataRow[] drRoots = dtClass.Select("上级分类ID is null or 上级分类ID=''");

            foreach (DataRow drRoot in drRoots)
            {
                TreeNode rootNode = null;

                ExamClassData classData = new ExamClassData();
                classData.BindRowData(drRoot);

                rootNode = trvItems.Nodes.Add(classData.项目分类ID, classData.分类名称, 0);

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

        /// <summary>
        /// 绑定子节点
        /// </summary>
        /// <param name="pNode"></param>
        /// <param name="dtClass"></param>
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

                tnSub.Nodes.Add("TMP" + subClassData.项目分类ID, "TMP");

                BindSubNode(tnSub, dtClass);
            }
        }

        /// <summary>
        /// 绑定当前分类及下一级分类的检查项目
        /// </summary>
        /// <param name="tnClass"></param>
        private void BindClassItem(TreeNode tnClass)
        {
            if (tnClass == null) return;

            ExamClassData classData = tnClass.Tag as ExamClassData;

            if (classData == null) return;

            TreeNode[] tmpNodes = tnClass.Nodes.Find("TMP" + classData.项目分类ID, false);
            if (tmpNodes.Length <= 0) return;

            DataTable dtItem = _eiModel.GetExamItemByClass(classData.项目分类ID);

            foreach (DataRow dr in dtItem.Rows)
            {
                ExamItemData itemData = new ExamItemData();
                itemData.BindRowData(dr);

                TreeNode tnItem = tnClass.Nodes.Add(itemData.项目ID, itemData.项目名称, 1);
                tnItem.SelectedImageIndex = 1;
                tnItem.Tag = itemData;
            }
            tnClass.Nodes.Remove(tmpNodes[0]);
        }


        /// <summary>
        /// 显示部位方法数据
        /// </summary>
        private void showBodyPartWays()
        {
            try
            {
                setBodypartWays();
                lblBodypart.Text = GetOrderContent();
                lblBodypart.Tag =GetBodypartContent();
                oneExamItem = getJApplyExamItem();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }       

        /// <summary>
        /// 提取部位方法串
        /// </summary>
        private void setBodypartWays()
        {
            try
            {
                if (lstBodyPart.SelectedItems.Count > 0)
                {
                    //for (int i=0;i<_bodypartSetting.Count;i++)     
                    foreach (JExamBodypartSetting oneBodypartSetting in _bodypartSetting)
                    {
                        if (oneBodypartSetting.部位名称 == lstBodyPart.SelectedItems[0].Text)
                        {
                            if (lstBodyPart.SelectedItems[0].Checked == false)
                            {
                                oneBodypartSetting.默认选择 = false;
                            }
                            else
                            {
                                oneBodypartSetting.默认选择 = true;
                                oneBodypartSetting.默认方法.Clear();
                                foreach (ListViewItem lvi in lstWays.Items)
                                {
                                    if (lvi.Checked == true)
                                    {
                                        JExamBodypartWaySetting oneWay = new JExamBodypartWaySetting();
                                        oneWay.方法名称 = lvi.Text;
                                        foreach (ListViewItem.ListViewSubItem lvsi in lvi.SubItems)
                                        {
                                            string attach;
                                            if (lvsi.Text.Substring(0, 1).Equals("√"))
                                            {
                                                attach = lvsi.Text.Substring(1);
                                                oneWay.附加方法.Add(attach);
                                            }
                                        }
                                        oneBodypartSetting.默认方法.Add(oneWay);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
        #endregion

        #region 窗体事件

        private void lstWays_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                if (_isLoadWays) return;

                if (e.Item == null) return;

                //处理互斥项目的选择
                if (e.Item.Checked == true)
                {
                    if (e.Item.SubItems[1].Text == "互斥")
                    {
                        foreach (ListViewItem lvi in lstWays.Items)
                        {
                            if (lvi != e.Item)
                            {
                                if (lvi.SubItems[1].Text == "互斥")
                                {
                                    lvi.Checked = false;
                                }
                            }
                        }
                    }
                }
                showBodyPartWays();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void lstWays_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //□表示未选择，√表示已选择               

                Point cp = lstWays.PointToClient(MousePosition);
                ListViewItem lvi = lstWays.GetItemAt(cp.X, cp.Y);

                if (lvi == null) return;

                System.Windows.Forms.ListViewItem.ListViewSubItem subItem = lvi.GetSubItemAt(cp.X, cp.Y);
                if (subItem == null) return;

                if (subItem.Name == "附加方法")
                {
                    if (subItem.Text.Substring(0, 1).Equals("□"))
                    {
                        if (lvi.Checked == false) lvi.Checked = true;
                        subItem.Text = subItem.Text.Replace("□", "√"); //☑■✔√
                    }
                    else
                    {
                        subItem.Text = subItem.Text.Replace("√", "□");
                    }
                }
                showBodyPartWays();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void lstBodyPart_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (_isLoadBodypart) return;
            lstWays.Enabled = e.Item.Checked;
            e.Item.Selected = true;
            showBodyPartWays();
        }

        private void lstBodyPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //初始化方法列表
                lstWays.Clear();
                lstWays.Enabled = false;

                if (lstBodyPart.SelectedItems.Count <= 0) return;

                ExamItemData itemData = trvItems.SelectedNode.Tag as ExamItemData;

                BodypartInfoData bodypartData = lstBodyPart.SelectedItems[0].Tag as BodypartInfoData;
                if (bodypartData == null) return;

                //绑定方法数据
                BindBodypartWay(bodypartData);

                lstWays.Enabled = lstBodyPart.SelectedItems[0].Checked;

                //勾选默认方法
                JExamBodypartSetting bodypartSetting = null;

                if (itemData.项目信息.可选部位.Count > 0)
                {
                    int index = (itemData.项目信息.可选部位 as List<JExamBodypartSetting>).FindIndex(T => T.部位ID == bodypartData.部位ID);

                    if (index >= 0) bodypartSetting = itemData.项目信息.可选部位[index];
                }

                ResetWaySetting(bodypartSetting);
                showBodyPartWays();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxModality_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                trvItems.Nodes.Clear();               

                if (string.IsNullOrEmpty(cbxModality.Text))
                {
                    return;
                }

                BindExamClassData();
                //BindBodypart();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ItemID = lblItem.Tag.ToString();
            OrderContent = lblBodypart.Text;           
            Modality = cbxModality.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void trvItems_BeforeExpand(object sender, TreeViewCancelEventArgs e)
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
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void trvItems_AfterSelect(object sender, TreeViewEventArgs e)
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


        #endregion
    }
}

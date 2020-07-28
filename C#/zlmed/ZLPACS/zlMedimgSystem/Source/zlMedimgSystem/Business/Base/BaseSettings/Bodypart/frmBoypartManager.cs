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
    public partial class frmBoypartManager : Form, ISetting
    {
        private IDBQuery _dbHelper = null;
        private BodypartModel _bpm = null;
        private ILoginUser _loginUser = null;
        private ComboxEx _comboxEx = null;//字典，类别下拉框加载方法

        public frmBoypartManager()
            : this(null, null)
        {
        }


        public frmBoypartManager(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }


        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {

            _dbHelper = dbHelper;
            _loginUser = loginUser;
            _bpm = new BodypartModel(_dbHelper);
            _comboxEx = new ComboxEx(dbHelper);
        }

        public void RefreshSetting()
        {
            _comboxEx.BindImageKing(cbxImageKind);
            _comboxEx.BindDictionary(cbxApplySex, "性别", true);

        }
        
        #region 附加方法添加删除相关
        /// <summary>
        /// 选择下拉框添加附件方法
        /// </summary>
        /// <param name="sAttachWay"></param>
        public void AddAttachWay(string sAttachWay)
        {
            if (string.IsNullOrEmpty(sAttachWay)) return;
            if (cboAttachWay.Properties.Items.IndexOf(sAttachWay) < 0)
            {
                cboAttachWay.Properties.Items.Add(sAttachWay);
            }
        }
        /// <summary>
        /// 设置表格内下拉框显示的样式
        /// </summary>
        private void setCbo()
        {
            try
            {
                //设置附加方法样式
                if (this.dataGridView1.CurrentCell.ColumnIndex == 2)
                {
                    Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, false);
                    string Value = dataGridView1.CurrentCell.Value.ToString();
                    this.cboAttachWay.Text = Value;
                    this.cboAttachWay.Left = rect.Left;
                    this.cboAttachWay.Top = rect.Top;
                    this.cboAttachWay.Width = rect.Width;
                    this.cboAttachWay.Height = rect.Height;
                    this.cboAttachWay.Visible = true;
                }
                else
                {
                    this.cboAttachWay.Visible = false;
                }
                //设置共用，可选方法样式
                if (this.dataGridView1.CurrentCell.ColumnIndex == 1)
                {
                    Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, false);
                    string Value = dataGridView1.CurrentCell.Value.ToString();
                    this.cboMutex.Text = Value;
                    this.cboMutex.Left = rect.Left;
                    this.cboMutex.Top = rect.Top;
                    this.cboMutex.Width = rect.Width;
                    this.cboMutex.Height = rect.Height;
                    this.cboMutex.Visible = true;
                }
                else
                {
                    this.cboMutex.Visible = false;
                }
                //设置检查方法下拉框样式
                if (this.dataGridView1.CurrentCell.ColumnIndex == 0)
                {
                    Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, false);
                    string Value = dataGridView1.CurrentCell.Value.ToString();
                    this.cbxBodypartWayName.Text = Value;
                    this.cbxBodypartWayName.Left = rect.Left;
                    this.cbxBodypartWayName.Top = rect.Top;
                    this.cbxBodypartWayName.Width = rect.Width;
                    this.cbxBodypartWayName.Height = rect.Height;
                    this.cbxBodypartWayName.Visible = true;
                }
                else
                {
                    this.cbxBodypartWayName.Visible = false;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        /// <summary>
        /// 保存方法表格的数据
        /// 方法存储在一个字段，直接保存表格所以数据
        /// </summary>
        /// <param name=""></param>
        private void saveWays()
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0) return;

                BodypartInfoData bodypartData = listView1.SelectedItems[0].Tag as BodypartInfoData;

                bodypartData.部位信息.互斥方法.Clear();
                bodypartData.部位信息.共用方法.Clear();

                DataTable dT = dataGridView1.DataSource as DataTable;
                string sCheckWay = "", sRelation = "", sAttach = "";
                for (int i = 0; i < dT.Rows.Count; i++)
                {
                    sCheckWay = dT.Rows[i]["检查方法"].ToString();
                    sRelation = dT.Rows[i]["关系"].ToString();
                    sAttach = dT.Rows[i]["附加方法"].ToString();

                    if (string.IsNullOrEmpty(sCheckWay) || string.IsNullOrEmpty(sRelation))
                    {
                        MessageBox.Show("第" + (i + 1) + "行检查方法或关系为空，请修改或删除后重新保存", "提示");
                        return;
                    }

                    if (dT.Select("检查方法='" + sCheckWay + "'").Count() > 1)
                    {
                        MessageBox.Show("存在相同的检查方法：" + sCheckWay + "请修改或删除后重新保存", "提示");
                        return;
                    }

                    JBodypartWay bw = new JBodypartWay();
                    bw.方法名称 = sCheckWay;
                    foreach (string item in sAttach.Split(';'))
                    {
                        //判断是否存在相同的附加方法，存在退出保存
                        if (bw.附加方法.IndexOf(item) > -1)
                        {
                            MessageBox.Show("检查方法：" + sCheckWay + "存在相同的附加方法，请修改或删除后重新保存", "提示");
                            return;
                        }
                        if (string.IsNullOrEmpty(item) == false)
                        {
                            bw.附加方法.Add(item);
                        }
                    }
                    if (sRelation == "互斥方法")
                    {
                        bodypartData.部位信息.互斥方法.Add(bw);
                    }
                    else
                    {
                        bodypartData.部位信息.共用方法.Add(bw);
                    }
                }

                _bpm.UpdateBodypartWay(bodypartData);

                int selIndex = dataGridView1.SelectedRows[0].Index;

                BindBodypartWay(bodypartData);
                
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex,this);
                return;
            }
        }
        //加载显示部件
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setCbo();
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            setCbo();
        }
        /// <summary>
        /// 选择下拉框选中的值赋给表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboAttachWay_EditValueChanged(object sender, EventArgs e)
        {           
            if (dataGridView1.CurrentCell==null) return;
            dataGridView1.CurrentCell.Value = cboAttachWay.Text;
        }

        private void cboMutex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            dataGridView1.CurrentCell.Value = cboMutex.Text;
        }

        private void cbxBodypartWayName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            dataGridView1.CurrentCell.Value = cbxBodypartWayName.Text;
        }
        private void cbxBodypartWayName_TextUpdate(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            dataGridView1.CurrentCell.Value = cbxBodypartWayName.Text;
        }
        #endregion


        private void frmBoypartManager_Load(object sender, EventArgs e)
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
                listView1.Clear();
                //切换科室后，先清空编辑区域，和方法
                ClearData();
                //切换科室后，先清空分组标记下拉列表框
                cbxBodypartGroup.Items.Clear();
                //切换科室，清空附加下拉框选项，隐藏表格内显示的下拉框控件

                this.cboAttachWay.Visible = false;
                this.cboAttachWay.Properties.Items.Clear();
                this.cboMutex.Visible = false;
                cbxBodypartWayName.Visible = false;
                cbxBodypartWayName.Items.Clear();
                if (string.IsNullOrEmpty( cbxImageKind.Text ))
                {
                    return;
                }

                BindBodyPartData();


            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void BindBodyPartData()
        {
            DataTable dtBodypart = _bpm.GetAllBodypartInfo(cbxImageKind.Text);

            foreach(DataColumn dc in dtBodypart.Columns)
            {
                if (("部位名称,分组标记").IndexOf(dc.Caption) >= 0)
                {
                    ColumnHeader columnHeader = new ColumnHeader();
                    columnHeader.Text = dc.Caption;
                    columnHeader.Name = dc.Caption;             
                    columnHeader.Width = 200;


                    listView1.Columns.Add(columnHeader);
                }
            }


            DataTable dtGroup = _bpm.GetBodypartGroups(cbxImageKind.Text);

            foreach(DataRow dr in dtGroup.Rows)
            {
                string groupTag = dr["分组标记"].ToString();
                string groupName = (string.IsNullOrEmpty(groupTag)) ? "未分组" : groupTag;

                ListViewGroup lvg = new ListViewGroup(groupName);
                listView1.Groups.Add(lvg);

                
                if (cbxBodypartGroup.Items.IndexOf(groupTag) < 0)
                {
                    cbxBodypartGroup.Items.Add(groupTag);
                }
            }


            foreach(DataRow drItem in dtBodypart.Rows)
            {
                BodypartInfoData bodypartData = new BodypartInfoData();
                bodypartData.BindRowData(drItem);

                string gn = (string.IsNullOrEmpty(bodypartData.分组标记)) ? "未分组" : bodypartData.分组标记;

                ListViewGroup lvgCur =  GetCurGroup(gn);

                ListViewItem itemNew = new ListViewItem(new string[] { bodypartData.部位名称, gn }, 0, lvgCur);
                //添加部位后需要定位。新增查找项
                itemNew.Name = bodypartData.部位ID;
                itemNew.Tag = bodypartData;
                //初始化科室内的方法名称，附加方法

                foreach(JBodypartWay jb in bodypartData.部位信息.互斥方法)
                {
                    if (cbxBodypartWayName.Items.IndexOf(jb.方法名称) < 0)
                    {
                        cbxBodypartWayName.Items.Add(jb.方法名称);
                    }
                    foreach (string  item in jb.附加方法)
                    {
                        AddAttachWay(item);
                    }
                }
                foreach (JBodypartWay jb in bodypartData.部位信息.共用方法)
                {
                    if (cbxBodypartWayName.Items.IndexOf(jb.方法名称) < 0)
                    {
                        cbxBodypartWayName.Items.Add(jb.方法名称);
                    }
                    foreach (string item in jb.附加方法)
                    {
                        AddAttachWay(item);
                    }
                }

                listView1.Items.Add(itemNew);
            }

            listView1.View = View.Details;
        }

        private void NewView(BodypartInfoData bodypartData)
        {
            string gn = (string.IsNullOrEmpty(bodypartData.分组标记)) ? "未分组" : bodypartData.分组标记;

            ListViewGroup lvgCur = GetCurGroup(gn);

            if (lvgCur == null)
            {
                lvgCur = new ListViewGroup(gn);
                listView1.Groups.Add(lvgCur);
            }

            ListViewItem itemNew = new ListViewItem(new string[] { bodypartData.部位名称, gn }, 0, lvgCur);
            //添加部位后需要定位。新增查找项
            itemNew.Name = bodypartData.部位ID;
            itemNew.Tag = bodypartData;

            listView1.Items.Add(itemNew);

            listView1.View = View.Details;
        }

        private ListViewGroup GetCurGroup(string groupName)
        {
            if (string.IsNullOrEmpty(groupName)) return null;

            foreach(ListViewGroup lvg in listView1.Groups)
            {
                if (lvg.Header.Equals(groupName) )
                {
                    return lvg;
                }
            }

            return null;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //切换部位时先隐藏表格内的部件
                this.cboMutex.Visible = false;
                this.cboAttachWay.Visible = false;
                this.cbxBodypartWayName.Visible = false;
                SyncSelRowData();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ClearData()
        {
            txtBodypartName.Text = "";
            txtBodypartName.Tag = null;

            cbxBodypartGroup.Text = ""; 

            cbxApplySex.SelectedIndex = -1;
            cbxApplySex.Text = "";

            rtbDescription.Text = "";

            dataGridView1.DataSource = null;
        }



        private void SyncSelRowData()
        {
            try
            {

                ClearData();
                 
                if (listView1.SelectedItems.Count <= 0) return;

                BodypartInfoData bodypartData = listView1.SelectedItems[0].Tag as BodypartInfoData;
                if (bodypartData == null)
                {
                    MessageBox.Show("未获取到对应的部位信息。", "提示");
                    return;
                }

                txtBodypartName.Text = bodypartData.部位名称;
                txtBodypartName.Tag = bodypartData.部位ID;

                cbxBodypartGroup.Text = bodypartData.分组标记;

                if (bodypartData.部位信息 != null)
                {
                    cbxApplySex.Text = bodypartData.部位信息.适用性别;
                    rtbDescription.Text = bodypartData.部位信息.备注描述;
                }


                BindBodypartWay(bodypartData);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void BindBodypartWay(BodypartInfoData bodypartData)
        {

            //显示部位方法信息
            DataTable dtWay = new DataTable("部位方法");

            dtWay.Columns.Add("检查方法", typeof(string));
            dtWay.Columns.Add("关系", typeof(string));
            dtWay.Columns.Add("附加方法", typeof(string));

            foreach(JBodypartWay bw in bodypartData.部位信息.互斥方法)
            {
                DataRow drNew = dtWay.NewRow();

                drNew["检查方法"] = bw.方法名称;
                drNew["关系"] = "互斥方法";
                //添加方法到下拉框
                if (cbxBodypartWayName.Items.IndexOf(bw.方法名称) < 0)
                {
                    cbxBodypartWayName.Items.Add(bw.方法名称);
                }

                string attachWay = "";
                foreach (string way in bw.附加方法)
                {
                    if (string.IsNullOrEmpty(attachWay) == false) attachWay = attachWay + ";";
                    attachWay = attachWay + way;
                    //添加附加方法到下拉框
                    AddAttachWay(way);
                }

                drNew["附加方法"] = attachWay;

                dtWay.Rows.Add(drNew);
            }

            foreach (JBodypartWay bw in bodypartData.部位信息.共用方法)
            {
                DataRow drNew = dtWay.NewRow();

                drNew["检查方法"] = bw.方法名称;
                drNew["关系"] = "可选方法";
                //添加方法到下拉框
                if (cbxBodypartWayName.Items.IndexOf(bw.方法名称) < 0)
                {
                    cbxBodypartWayName.Items.Add(bw.方法名称);
                }

                string attachWay = "";
                foreach (string way in bw.附加方法)
                {
                    if (string.IsNullOrEmpty(attachWay) == false) attachWay = attachWay + ";";
                    attachWay = attachWay + way;
                    //添加附加方法到下拉框
                    AddAttachWay(way);
                }

                drNew["附加方法"] = attachWay;

                dtWay.Rows.Add(drNew);
            }

            dataGridView1.DataSource = dtWay;
            
            dataGridView1.Columns["附加方法"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        private void UpdateBodypartGroup()
        {
            if (string.IsNullOrEmpty(cbxBodypartGroup.Text)) return;
            if (cbxBodypartGroup.Items.IndexOf(cbxBodypartGroup.Text) < 0)
            {
                cbxBodypartGroup.Items.Add(cbxBodypartGroup.Text);
            }
        }

        
        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (Verify() == false) return;


                BodypartInfoData bodypartData = new BodypartInfoData();

                bodypartData.部位ID = SqlHelper.GetCmpUID();
                bodypartData.部位名称 = txtBodypartName.Text;
                bodypartData.分组标记 = cbxBodypartGroup.Text;
                bodypartData.影像类别 = cbxImageKind.Text;
                bodypartData.部位信息.备注描述 = rtbDescription.Text;
                bodypartData.部位信息.适用性别 = cbxApplySex.Text;
                bodypartData.部位信息.创建日期 = DateTime.Now;

                bodypartData.部位信息.CopyBasePro(bodypartData);

                _bpm.NewBodypartInfo(bodypartData);

                NewView(bodypartData);

                UpdateBodypartGroup();

                ButtonHint.Start(sender as Button, "OK");
                //添加部位后，焦点定位
                listView1.Items.Find(bodypartData.部位ID, false)[0].Selected = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private bool Verify(bool isModify = false)
        {
            if (string.IsNullOrEmpty(txtBodypartName.Text))
            {
                MessageBox.Show("部位名称不允许为空。", "提示");
                txtBodypartName.Focus();
                return false;
            }
             
            string bodypartId = _bpm.GetBodypartInfoId(cbxImageKind.Text, txtBodypartName.Text);
            if (string.IsNullOrEmpty(bodypartId) == false)
            {
                if (isModify)
                {
                    if (bodypartId.Equals(txtBodypartName.Tag) == false)
                    {
                        MessageBox.Show("部位名称不允许重复。", "提示");
                        txtBodypartName.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("部位名称不允许重复。", "提示");
                    txtBodypartName.Focus();
                    return false;
                }
            }              

            return true;
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBodypartName.Tag == null)
                {
                    MessageBox.Show("请选择需要删除的部位信息。", "提示");
                    return;
                }
                //删除弹出提示确认删除
                if (MessageBox.Show("是否删除部位："+ txtBodypartName.Text + "?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                _bpm.DelBodypartInfo(txtBodypartName.Tag.ToString());

                int rowIndex = 0;
                if (listView1.SelectedItems.Count > 0)
                {
                    rowIndex = listView1.SelectedItems[0].Index;
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                }

                ButtonHint.Start(sender as Button, "OK");

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 获取选择的部位信息
        /// </summary>
        /// <returns></returns>
        public BodypartInfoData GetSelectBodypartInfo()
        {

            if (listView1.SelectedItems.Count <= 0) return null;

             
            return listView1.SelectedItems[0].Tag as BodypartInfoData;
        }


        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBodypartName.Tag == null)
                {
                    MessageBox.Show("请选择需要修改的部位信息。", "提示");
                    return;
                }


                BodypartInfoData bodypartData = GetSelectBodypartInfo();
                if (bodypartData == null)
                {
                    MessageBox.Show("未获取到有效的部位信息。", "提示");
                    return;
                }

                if (Verify(true) == false) return;


                bool isNewGroup = false;
                if (cbxBodypartGroup.Text.Equals(bodypartData.分组标记) == false)
                {
                    isNewGroup = true;
                    
                }

                bodypartData.部位名称 = txtBodypartName.Text;
                bodypartData.分组标记 = cbxBodypartGroup.Text;
                bodypartData.部位信息.适用性别 = cbxApplySex.Text;
                bodypartData.部位信息.备注描述 = rtbDescription.Text;

                bodypartData.部位信息.CopyBasePro(bodypartData);

                _bpm.UpdateBodypartInfo(bodypartData);

                if (isNewGroup)
                {
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                    NewView(bodypartData);
                }
                else
                {
                    listView1.SelectedItems[0].SubItems[0].Text = txtBodypartName.Text;
                    listView1.SelectedItems[0].SubItems[1].Text = (string.IsNullOrEmpty(cbxBodypartGroup.Text)) ? "未分组" : cbxBodypartGroup.Text;
                }

                 

                UpdateBodypartGroup();

                ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butNewWay_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("未选择对应检查部位，不能执行此操作。", "提示");
                return;
            }
            try
            {
                DataTable dBind = dataGridView1.DataSource as DataTable;
                DataRow drNew = dBind.NewRow();
                dBind.Rows.Add(drNew);
                //定位到新增行检查方法单元格
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["检查方法"];
            }catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butNewSubWay_Click(object sender, EventArgs e)
        {
            saveWays();
            ButtonHint.Start(sender as Button, "OK");
        }

        private void butDelWay_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("未选择需要删除的检查方法，不能执行此操作。", "提示");
                    return;
                }


                BodypartInfoData bodypartData = listView1.SelectedItems[0].Tag as BodypartInfoData;

                string wayName = dataGridView1.SelectedRows[0].Cells["检查方法"].Value.ToString();
                //删除弹出提示：
                if (MessageBox.Show("是否删除检查方法：" + wayName + "的数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
                int delIndex = (bodypartData.部位信息.互斥方法 as List<JBodypartWay>).FindIndex(T => T.方法名称 == wayName);

                if (delIndex >= 0)
                {
                    bodypartData.部位信息.互斥方法.RemoveAt(delIndex);
                }
                else
                {
                    delIndex = (bodypartData.部位信息.共用方法 as List<JBodypartWay>).FindIndex(T => T.方法名称 == wayName);
                    if (delIndex >= 0) bodypartData.部位信息.共用方法.RemoveAt(delIndex);
                }

                _bpm.UpdateBodypartWay(bodypartData);

                BindBodypartWay(bodypartData);

                ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butApplyGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("没有对应的方法，不能执行此操作。", "提示");
                    return;
                }


                ApplyBodypartWay(true);

                ButtonHint.Start(sender as Button, "OK");

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 应用部位方法
        /// </summary>
        /// <param name="isOnlyToGroup"></param>
        private void ApplyBodypartWay(bool isOnlyToGroup)
        {
            BodypartInfoData bodypartData = listView1.SelectedItems[0].Tag as BodypartInfoData;

            foreach (ListViewItem lvi in listView1.Items)
            {
                if (listView1.SelectedItems[0].Equals(lvi)) continue;

                BodypartInfoData curBodypartData = lvi.Tag as BodypartInfoData;

                if (isOnlyToGroup)
                {
                    //未分组对象为null，添加判断
                    if (curBodypartData.分组标记 !=bodypartData.分组标记) continue;
                }

                curBodypartData.部位信息.互斥方法.Clear();
                foreach (JBodypartWay bw in bodypartData.部位信息.互斥方法)
                {
                    curBodypartData.部位信息.互斥方法.Add(bw.Clone());
                }

                curBodypartData.部位信息.共用方法.Clear();
                foreach (JBodypartWay bw in bodypartData.部位信息.共用方法)
                {
                    curBodypartData.部位信息.共用方法.Add(bw.Clone());
                }

                _bpm.UpdateBodypartWay(curBodypartData);

            }
        }

        private void butApplyAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("没有对应的方法，不能执行此操作。", "提示");
                    return;
                }


                ApplyBodypartWay(false);

                ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        
    }
}

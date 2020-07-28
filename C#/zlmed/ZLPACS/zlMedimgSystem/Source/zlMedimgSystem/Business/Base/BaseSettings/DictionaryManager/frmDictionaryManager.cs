using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;
using zlMedimgSystem.Interface;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmDictionaryManager : Form, ISetting
    {
        private IDBQuery _dbHelper = null;
        private DictManageModel _dbDicModel = null;
        private int iRow = -1; //记录当前选择的字典信息行
        private int iOperationRow = -1;//记录操作前选择行
        private List<JDictionaryItem> gridlist = null;
        private ILoginUser _loginUser = null;

        public frmDictionaryManager()
            :this(null, null)
        { 

        }
        public frmDictionaryManager(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }

        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {
            _dbHelper = dbHelper;
            _loginUser = loginUser;

            _dbDicModel = new DictManageModel(_dbHelper);
        }
       
        /// <summary>
        /// 加载字典名称
        /// </summary>
        private void LoadDictItemName()
        {
            try
            {
                DataTable dDictionary = _dbDicModel.GetDictInfo();
                //需要将数据源设置为null，否则刷新时会提示：设置 DataSource 属性后无法修改项集合 错误。
                cbxDictionary.DataSource = null;
                cbxDictionary.Items.Clear();

                cbxDictionary.DisplayMember = "字典名称";
                cbxDictionary.ValueMember = "字典名称";

                cbxDictionary.DataSource = dDictionary;

                if (cbxDictionary.Items.Count > 0) cbxDictionary.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
        /// <summary>
        /// 重新绑定表格数据
        /// </summary>
        private void ReBindDictonary()
        {
            BindingList<JDictionaryItem> list = new BindingList<JDictionaryItem>(gridlist);

            dgvDictionary.DataSource = list;
            //dgvDictionary.ClearSelection();
        }
        /// <summary>
        /// 绑定字典信息
        /// </summary>
        /// <param name="dictName">字典名称</param>
        private void BindDictionaryData(string dictName)
        {
            try
            {
                JDictionary dict = _dbDicModel.GetDictionary(dictName);
                if (dict == null)
                {
                    //重新绑定字典信息时，如果没有内容，需要将gridlist的内容清除，避免界面显示内容错误
                    gridlist = new List<JDictionaryItem>();
                    dgvDictionary.DataSource = new List<JDictionaryItem>();
                    return;
                }
                //使用list绑定数据源时，不能设置为null，否则会影响列结构
                gridlist = dict.项目内容 as List<JDictionaryItem>;

                BindingList<JDictionaryItem> list = new BindingList<JDictionaryItem>(gridlist);

                dgvDictionary.DataSource = list;
                dgvDictionary.Columns["项目说明"].Visible = false;
                dgvDictionary.Columns["创建日期"].Visible = false;

                //this.dgvDictionary.ClearSelection();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                gridlist = new List<JDictionaryItem>();
            }
        }

        /// <summary>
        /// 更新字典信息
        /// </summary>
        /// <returns></returns>
        private Boolean UpdateDictionary()
        {
            try
            {
                DictManageData dictData = new DictManageData();

                dictData.字典名称 = cbxDictionary.Text;
                dictData.字典信息.项目内容 = gridlist;

                dictData.字典信息.CopyBasePro(dictData);

                _dbDicModel.UpdateDictContent(dictData);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 将选择的字典信息行加载到编辑区域控件内
        /// </summary>
        private void LoadDicItem()
        {
            iRow = this.dgvDictionary.SelectedRows[0].Index;// dgvDictionary.CurrentCell.RowIndex;
            DataGridViewRow dr = this.dgvDictionary.SelectedRows[0];
            this.txtDicName.Text = dr.Cells["项目名称"].Value.ToString();
            this.txtDicCode.Text = dr.Cells["项目编码"].Value.ToString();
            this.txtDicDescription.Text = dr.Cells["项目说明"].Value.ToString();

            if ((bool)dr.Cells["缺省"].Value)
            { this.chkDefaule.Checked = true; }
            else
            { this.chkDefaule.Checked = false; }

        }
        /// <summary>
        /// 清空编辑区域控件信息
        /// </summary>
        private void ClearDicItem()
        {
            this.txtDicName.Text = "";
            this.txtDicCode.Text = "";
            this.txtDicDescription.Text = "";

            this.chkDefaule.Checked = false;
        }
       
        /// <summary>
        /// 验证编辑区域的数据
        /// </summary>
        /// <param name="operation">0：新增字典信息；1：更新字典信息</param>
        /// <returns>返回验证不通过的信息，返回空字符串表示严重通过</returns>
        private string ValidateDicItem(int operation)
        {
            string strMsg = "";
            try
            {
                switch (operation)
                {
                    case 0:
                        if (!string.IsNullOrEmpty(txtDicName.Text.Trim()))
                        {
                            strMsg = ItemIsRepeat(txtDicName.Text, -1);
                        }
                        else
                        {
                            return "字典项目名称不能为空";
                        }
                        break;
                    case 1:
                        if (!string.IsNullOrEmpty(txtDicName.Text.Trim()))
                        {
                            strMsg = ItemIsRepeat(txtDicName.Text, iRow);
                        }
                        else
                        {
                            return "字典项目名称不能为空";
                        }
                        break;

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return strMsg;
        }
        /// <summary>
        /// 判断字典名称是否在列表中存在
        /// </summary>
        /// <param name="itemName">字典项目</param>
        /// <param name="rowindex">例外的行号</param>
        /// <returns>返回空字符串，不存在，不为空，存在</returns>
        private string ItemIsRepeat(string itemName, int rowindex)
        {
            for (int i = 0; i < dgvDictionary.Rows.Count; i++)
            {
                if (dgvDictionary.Rows[i].Cells["项目名称"].Value.ToString() == itemName && i != rowindex)
                {
                    return "已存在相同的字典项目名称：" + itemName;
                }
            }
            return "";
        }

        public void RefreshSetting()
        {
            LoadDictItemName();
        }

        private void frmDictionaryManagernew_Load(object sender, EventArgs e)
        {
            RefreshSetting();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            string strMsg = ValidateDicItem(0);
            if (strMsg != "")
            {
                MessageBox.Show(strMsg, "提示");
                txtDicName.Focus();
                txtDicName.SelectAll();
                return;
            }
            //将新增的行添加到最后一行
            try
            {
                JDictionaryItem arrnew = new JDictionaryItem();
                arrnew.项目名称 = this.txtDicName.Text;
                arrnew.项目编码 = this.txtDicCode.Text;
                arrnew.项目说明 = this.txtDicDescription.Text;
                arrnew.创建日期 = DateTime.Now;
                if (chkDefaule.Checked)
                {
                    for (int i = 0; i < gridlist.Count; i++)
                    {
                        gridlist[i].缺省 = false;
                    }
                    arrnew.缺省 = true;
                }
                else
                {
                    arrnew.缺省 = false;
                }
                gridlist.Add(arrnew);
                UpdateDictionary();
                ClearDicItem();
                //重新绑定字典信息
                ReBindDictonary();

                ButtonHint.Start(sender as Button, "OK");
                dgvDictionary.Rows[dgvDictionary.Rows.Count - 1].Selected = true;
                iRow = dgvDictionary.Rows.Count - 1;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDictionary_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            DataGridView dgv = sender as DataGridView;
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                                                e.RowBounds.Location.Y,
                                                dgv.RowHeadersWidth - 4,
                                                e.RowBounds.Height);


            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                                    dgv.RowHeadersDefaultCellStyle.Font,
                                    rectangle,
                                    dgv.RowHeadersDefaultCellStyle.ForeColor,
                                    TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

        }

        private void cbxDictionary_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取字典信息
            try
            {
                //将下面代码放到BindDictionaryData里面，如果查询返回为null时使用
                //dgvDictionary.DataSource = new List<JDictionaryItem>();
                ClearDicItem();
                BindDictionaryData(cbxDictionary.Text);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            iOperationRow = iRow;
            if (iRow < 0 || iRow > dgvDictionary.Rows.Count - 1) { return; }
            if (string.IsNullOrEmpty(txtDicName.Text.Trim())) { return; }
            if (MessageBox.Show("是否删除选择行字典项目:"+ txtDicName.Text.Trim() + "？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridlist.RemoveAt(iRow);
                if (UpdateDictionary())
                {
                    //BindDictionaryData(cbxDictionary.Text);
                    ClearDicItem();
                    ReBindDictonary();
                    ButtonHint.Start(sender as Button, "OK");
                    //如果字典项目列表行数大于删除前选择的行数，定位到下一行
                    if (dgvDictionary.Rows.Count> iOperationRow)
                    {
                        dgvDictionary.Rows[iOperationRow].Selected = true;
                    }
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            iOperationRow = iRow;
            string strMsg = ValidateDicItem(1);
            if (strMsg != "")
            {
                MessageBox.Show(strMsg, "提示");
                txtDicName.Focus();
                txtDicName.SelectAll();
                return;
            }

            gridlist[iRow].项目名称 = this.txtDicName.Text;
            gridlist[iRow].项目编码 = this.txtDicCode.Text;
            gridlist[iRow].项目说明 = this.txtDicDescription.Text;

            if (chkDefaule.Checked)
            {
                for (int i = 0; i < gridlist.Count; i++)
                {
                    gridlist[i].缺省 = false;
                }
                gridlist[iRow].缺省 = true;
            }
            else
            {
                gridlist[iRow].缺省 = false;
            }
            //执行保存数据库操作
            UpdateDictionary();
            //ClearDicItem();
            ReBindDictonary();
            ButtonHint.Start(sender as Button, "OK");
            dgvDictionary.Rows[iOperationRow].Selected = true;
        }

        private void dgvDictionary_SelectionChanged(object sender, EventArgs e)
        {
            //加载选中行数据
          
            try
            {
                if (dgvDictionary.SelectedRows.Count > 0)
                {
                    LoadDicItem();
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

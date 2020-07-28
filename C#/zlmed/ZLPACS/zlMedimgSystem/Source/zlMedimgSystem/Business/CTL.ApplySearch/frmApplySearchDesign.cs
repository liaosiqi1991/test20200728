using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors;
using zlMedimgSystem.Services;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.CTL.ApplySearch
{

   
    public partial class frmApplySearchDesign : Form
    {
        #region 私有属性
        private bool _isOk = false;
        private ApplySearchDesign _applySearchDesign = null;
        private IDBQuery _dbQuery;
        #endregion

        #region 构造函数
        public frmApplySearchDesign()
        {
            InitializeComponent();
        }
        #endregion


        #region 公共方法
        public bool ShowDesign(ApplySearchDesign  applySearchDesign, IWin32Window owner,IDBQuery dbQuery)
        {
            _applySearchDesign = applySearchDesign;
            _dbQuery = dbQuery;
            this.ShowDialog(owner);

            return _isOk;
        }

        #endregion

        #region 私有方法

        private void BindHISSource()
        {            
            try
            {
                HisServerModel hisServerM = new HisServerModel(_dbQuery);

                DataTable dt = hisServerM.GetAllHisServer();

                cbxHISDB.DisplayMember = "服务名称";
                cbxHISDB.DataSource = dt;

                if (cbxHISDB.Items.Count > 0)
                {
                    if (_applySearchDesign.HIS库名称 != "")
                    {
                        cbxHISDB.Text = _applySearchDesign.HIS库名称;
                    }
                    else
                    {
                        cbxHISDB.SelectedIndex = 0;
                    }                    
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                _applySearchDesign.查PACS库 = rbtnPACS.Checked;
                if(_applySearchDesign.查PACS库)
                {
                    _applySearchDesign.HIS库名称 = "";
                }
                else
                {
                    _applySearchDesign.HIS库名称 = cbxHISDB.Text;
                }
                _applySearchDesign.ApplySearchCfg.Clear();                

                foreach (ListViewItem lvi in listView.Items)
                {
                    _applySearchDesign.ApplySearchCfg.Add(lvi.Tag as ApplySearchItemConfig);
                }

                _isOk = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
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

        private void cbxControlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                BindControlNames();                
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
        
        private void AddPACSCondition()
        {
            try
            {
                switch (cbxControlType.Text)
                {
                    case "单项条件":
                        cbxControlName.Items.Add("姓名");
                        cbxControlName.Items.Add("姓名拼音");
                        cbxControlName.Items.Add("性别");
                        cbxControlName.Items.Add("联系电话");
                        cbxControlName.Items.Add("身份证号");
                        cbxControlName.Items.Add("检查室");
                        cbxControlName.Items.Add("检查设备");
                        cbxControlName.Items.Add("检查项目");
                        cbxControlName.Items.Add("检查状态");
                        cbxControlName.Items.Add("报告状态");
                        cbxControlName.Items.Add("诊断");
                        cbxControlName.Items.Add("学组");
                        cbxControlName.Items.Add("报告等级");
                        cbxControlName.Items.Add("类型");
                        cbxControlName.Items.Add("患者类型");
                        cbxControlName.Items.Add("费用类型");
                        cbxControlName.Items.Add("患者来源");
                        cbxControlName.Items.Add("收费状态");
                        cbxControlName.Items.Add("登记日期");
                        cbxControlName.Items.Add("检查日期");
                        cbxControlName.Items.Add("申请日期");
                        cbxControlName.Items.Add("录入员");                        
                        cbxControlName.Items.Add("申请医生");
                        cbxControlName.Items.Add("报告医生");
                        cbxControlName.Items.Add("审核医生");
                        break;
                    case "复合条件":
                        cbxControlName.Items.Add("号别");
                        cbxControlName.Items.Add("单个日期");
                        cbxControlName.Items.Add("两个日期");
                        cbxControlName.Items.Add("医生");
                        break;
                    case "勾选项":
                        cbxControlName.Items.Add("扫描申请单");
                        cbxControlName.Items.Add("打印条码");
                        cbxControlName.Items.Add("危急值");
                        cbxControlName.Items.Add("随访");
                        cbxControlName.Items.Add("阳性");                        
                        break;
                    case "条件按钮":
                        cbxControlName.Items.Add("我的患者");
                        cbxControlName.Items.Add("前一天");
                        cbxControlName.Items.Add("后一天");
                        cbxControlName.Items.Add("今天");
                        cbxControlName.Items.Add("近一天");
                        cbxControlName.Items.Add("近三天");
                        break;
                    case "功能按钮":
                        cbxControlName.Items.Add("查询");
                        cbxControlName.Items.Add("全清");
                        cbxControlName.Items.Add("其他条件设置");
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void AddHISCondition()
        {
            try
            {
                switch (cbxControlType.Text)
                {
                    case "单项条件":
                        cbxControlName.Items.Add("姓名");                        
                        cbxControlName.Items.Add("性别");
                        cbxControlName.Items.Add("联系电话");
                        cbxControlName.Items.Add("身份证号");                                                                                           
                        cbxControlName.Items.Add("患者来源");                                              
                        cbxControlName.Items.Add("申请日期");                     
                        break;
                    case "复合条件":
                        cbxControlName.Items.Add("号别");                                            
                        break;
                    case "勾选项":                      
                        cbxControlName.Items.Add("危急值");                       
                        cbxControlName.Items.Add("已接收");
                        break;
                    case "条件按钮":                     
                        cbxControlName.Items.Add("前一天");
                        cbxControlName.Items.Add("后一天");
                        cbxControlName.Items.Add("今天");
                        cbxControlName.Items.Add("近一天");
                        cbxControlName.Items.Add("近三天");
                        break;
                    case "功能按钮":
                        cbxControlName.Items.Add("查询");
                        cbxControlName.Items.Add("全清");                     
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
        private void BindControlNames()
        {
            try
            {
                cbxControlName.Items.Clear();

                if (string.IsNullOrEmpty(cbxControlType.Text))
                {
                    return;
                }
                if (rbtnPACS.Checked == true)
                {
                    AddPACSCondition();
                }
                else
                {
                    AddHISCondition();
                }

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidConfig() == false) return;

                ApplySearchItemConfig newItem = new ApplySearchItemConfig();

                newItem.控件名称 = cbxControlName.Text;
                newItem.控件类型 = (ASControlType)cbxControlType.SelectedIndex;
                newItem.起始行 = Int32.Parse(txtRowStart.Text);
                newItem.占用行数 = Int32.Parse(txtRowCount.Text);
                newItem.起始列 = Int32.Parse(txtColStart.Text);
                newItem.占用列数 = Int32.Parse(txtColCount.Text);               

                AddItemToList(newItem);

                txtColCount.Text = "1";
                txtRowCount.Text = "1";
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private bool ValidConfig()
        {
            int rowCount;
            int colCount;
            ApplySearchDesign asDesign = new ApplySearchDesign();

            try
            {
                //判断控件类型，控件名称是否为空
                if (cbxControlType.Text =="")
                {
                    MsgBox.ShowInf("请选择控件类型后，重新添加。");
                    cbxControlType.Focus();
                    return false;
                }
                if(cbxControlName.Text == "")
                {
                    MsgBox.ShowInf("请选择控件名称后，重新添加。");
                    cbxControlName.Focus();
                    return false;
                }

                if(txtRowStart.Text.Trim()=="" || Int32.Parse( txtRowStart.Text)==0)
                {
                    MsgBox.ShowInf("请输入行位置后，重新添加。");
                    txtRowStart.Focus();
                    return false;
                }

                if (txtColStart.Text.Trim()==""|| Int32.Parse( txtColStart.Text) ==0)
                {
                    MsgBox.ShowInf("请输入列位置后，重新添加。");
                    txtColStart.Focus();
                    return false;
                }

                //判断是否有同名的控件，复合时间条件，只需要添加一个                                              
                foreach (ListViewItem lvi in listView.Items)
                {
                    asDesign.ApplySearchCfg.Add(lvi.Tag as ApplySearchItemConfig);
                    if (asDesign.ApplySearchCfg[asDesign.ApplySearchCfg.Count - 1].控件名称 == cbxControlName.Text)
                    {
                        MsgBox.ShowInf("控件“" + cbxControlName.Text + "”已存在，请不要重复添加。");
                        return false;
                    }
                    if((cbxControlName.Text == "两个日期" && asDesign.ApplySearchCfg[asDesign.ApplySearchCfg.Count - 1].控件名称=="单个日期")
                        || (cbxControlName.Text == "单个日期" && asDesign.ApplySearchCfg[asDesign.ApplySearchCfg.Count - 1].控件名称=="两个日期"))
                    {
                        MsgBox.ShowInf("复合日期条件，只需要添加一个就足够了，请不要重复添加。");
                        return false;
                    }
                }

                //复合条件，需要控制列数，两个时间和三个时间，只需要添加一个
                if (cbxControlType.Text == "复合条件")
                {
                    if(cbxControlName.Text =="两个日期")
                    {                      
                        if (Int32.Parse( txtColCount.Text)%3 !=0)
                        {
                            txtColCount.Text = "3";
                            MsgBox.ShowInf("两个日期的复合条件，最少需要占用3列，或者3的倍数，请重新添加。");
                            txtColCount.Focus();
                            return false;
                        }                        
                    }
                    else
                    {
                        if(Int32.Parse(txtColCount.Text)%2 != 0)
                        {
                            txtColCount.Text = "2";
                            MsgBox.ShowInf("复合条件最少需要占用2列，或者2的倍数，请重新添加。");
                            txtColCount.Focus();
                            return false;
                        }
                    }
                }

                if (txtColCount.Text.Trim() == "" ||Int32.Parse( txtColCount.Text) == 0) txtColCount.Text = "1";
                if (txtRowCount.Text.Trim() == "" ||Int32.Parse( txtRowCount.Text) == 0) txtRowCount.Text = "1";

                //判断是否存在位置互相覆盖的控件
                ApplySearchItemConfig oneConfig = new ApplySearchItemConfig();
                oneConfig.起始行 =Int32.Parse( txtRowStart.Text);
                oneConfig.起始列 = Int32.Parse(txtColStart.Text);
                oneConfig.占用行数 = Int32.Parse(txtRowCount.Text);
                oneConfig.占用列数 = Int32.Parse(txtColCount.Text);
                oneConfig.控件名称 = cbxControlName.Text;
                oneConfig.控件类型 = (ASControlType)cbxControlType.SelectedIndex;                

                asDesign.ApplySearchCfg.Add(oneConfig);
                asDesign.GetControlRC(out rowCount, out colCount);
                int[, ] intTable = new int[rowCount+1, colCount+1];

                foreach(ApplySearchItemConfig asic in asDesign.ApplySearchCfg)
                {
                    intTable[asic.起始行, asic.起始列] = intTable[asic.起始行, asic.起始列] + 1;
                    if(intTable[asic.起始行, asic.起始列]>1)
                    {
                        MsgBox.ShowInf("控件位置有重叠，请重新调整后再添加。");
                        return false;
                    }
                    if (asic.占用列数>1)
                    {
                        for(int i =1;i<asic.占用列数 ;i++)
                        {
                            intTable[asic.起始行, asic.起始列 + i] = intTable[asic.起始行, asic.起始列 + i] + 1;
                            if (intTable[asic.起始行, asic.起始列 + i] > 1)
                            {
                                MsgBox.ShowInf("控件位置有重叠，请重新调整后再添加。");
                                return false;
                            }
                        }                        
                    }
                    if(asic.占用行数>1)
                    {
                        for(int i =1;i<asic.占用行数;i++)
                        {
                            intTable[asic.起始行 + i, asic.起始列] = intTable[asic.起始行 + i, asic.起始列] + 1;
                            if (intTable[asic.起始行 + i, asic.起始列] > 1)
                            {
                                MsgBox.ShowInf("控件位置有重叠，请重新调整后再添加。");
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
            
        }

        private void AddItemToList(ApplySearchItemConfig asic)
        {                  
            ListViewItem itemNew = new ListViewItem(new string[] {asic.控件名称,
                                                                GetASControlTypeAlias(asic.控件类型),
                                                                asic.起始行.ToString(),                                                                
                                                                asic.起始列.ToString(),
                                                                asic.占用行数.ToString(),
                                                                asic.占用列数.ToString()}, 0);

            itemNew.Tag = asic;
            itemNew.Name = asic.控件名称;
            
            listView.Items.Add(itemNew);                        
        }


        private string GetASControlTypeAlias(ASControlType asControlType)
        {
            switch ((int)asControlType)
            {
                case (int)ASControlType.asct单项条件:
                    return "单项条件";

                case (int)ASControlType.asct复合条件:
                    return "复合条件";

                case (int)ASControlType.asct勾选项:
                    return "勾选项";

                case (int)ASControlType.asct条件按钮:
                    return "条件按钮";

                case (int)ASControlType.asct功能按钮:
                    return "功能按钮";

                default:
                    return "";
            }
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("请选择需要删除的项目。", "提示");
                    return;
                }

                ListViewItem delItem = listView.SelectedItems[0];

                ApplySearchItemConfig asicDel = delItem.Tag as ApplySearchItemConfig;
                int nextIndex = delItem.Index + 1;                

                DialogResult dr = MessageBox.Show("确认删除改项目吗", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;                

                delItem.Remove();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private void InitControlList()
        {
            listView.Clear();
            listView.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();
            columnDefault = new ColumnHeader();
            columnDefault.Text = "控件名称";
            columnDefault.Name = "控件名称";
            columnDefault.Width = 120;
            listView.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "控件类型";
            columnDefault.Name = "控件类型";
            columnDefault.Width = 120;
            listView.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "行";
            columnDefault.Name = "行";
            columnDefault.Width = 80;
            listView.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "列";
            columnDefault.Name = "列";
            columnDefault.Width = 80;
            listView.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "占用行数";
            columnDefault.Name = "占用行数";
            columnDefault.Width = 80;
            listView.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "占用列数";
            columnDefault.Name = "占用列数";
            columnDefault.Width = 80;
            listView.Columns.Add(columnDefault);

            listView.View = View.Details;
        }

        private void frmApplySearchDesign_Load(object sender, EventArgs e)
        {
            try
            {
                rbtnPACS.Checked = _applySearchDesign.查PACS库;
                rbtnHis.Checked = !_applySearchDesign.查PACS库;

                BindHISSource();

                cbxControlType.SelectedIndex = 0;

                InitControlList();

                foreach (ApplySearchItemConfig asic in _applySearchDesign.ApplySearchCfg)
                {
                    AddItemToList(asic);
                }

                listView.View = View.Details;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void txtRowStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        private void cbxControlName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbtnHis_CheckedChanged(object sender, EventArgs e)
        {
            cbxHISDB.Enabled = rbtnHis.Checked;
            BindControlNames();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }



}

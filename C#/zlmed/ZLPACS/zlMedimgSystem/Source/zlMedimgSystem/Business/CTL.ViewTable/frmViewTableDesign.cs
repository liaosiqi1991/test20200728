using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.ViewTable
{
    public partial class frmViewTableDesign : Form
    {
        #region 私有属性
        private bool _isOk = false;
        private ViewTableDesign _viewTableDesign = null;

        #endregion

        #region 构造函数
        public frmViewTableDesign()
        {
            InitializeComponent();
        }

        #endregion

        #region 公共方法
        public bool ShowDesign(ViewTableDesign  viewTableDesign, IWin32Window owner)
        {
            _viewTableDesign = viewTableDesign;

            this.ShowDialog(owner);

            return _isOk;
        }

        #endregion

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidOK() == false) return;

                _viewTableDesign.查PACS库 = rbtnPACS.Checked;                
                _viewTableDesign.ViewTableCfg.Clear();

                foreach (ListViewItem lvi in lstColList.Items)
                {
                    _viewTableDesign.ViewTableCfg.Add(lvi.Tag as ViewTableItemConfig);
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

        private void frmViewTableDesign_Load(object sender, EventArgs e)
        {
            try
            {
                if(_viewTableDesign.查PACS库)
                {
                    rbtnPACS.Checked = true;
                }
                else
                {
                    rbtnHis.Checked = true;
                }
                
                InitColName();

                InitColList();
                
                cbxIsShow.SelectedIndex = 0;

                foreach (ViewTableItemConfig asic in _viewTableDesign.ViewTableCfg)
                {
                    AddItemToList(asic);
                }

                lstColList.View = View.Details;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void InitColName()
        {
            string strCols;
            try
            {
                if(_viewTableDesign.查PACS库)
                {
                    strCols = "姓名,检查号,就诊卡号,门诊号,住院号,申请日期,申请状态,申请信息,"+
                                "申请关联id,影像类别,申请识别码,身份证号,患者信息,患者关联id,"+
                                "患者识别码,执行院区";
                }
                else
                {
                    strCols = "医嘱ID ,急,姓名,性别,年龄,项目名称,申请科室,婚姻状况,身份证号,"+
                                "国籍,籍贯,民族,来源,病人来源,职业,申请日期,门诊号,住院号,医保号,婴儿,"+
                                "常用联系地址,常用邮编,常用联系电话,备用联系地址,备用邮编,备用联系电话,"+
                                "申请医生,就诊卡号,体检号,床号,申请嘱托,影像类别,主页ID";
                }
                
                string[] arrCol = strCols.Split(new char[] { ',' });
                cbxColName.Items.Clear();
                foreach (string _temp in arrCol)
                {
                    if(_temp.Trim()!="")  cbxColName.Items.Add(_temp);
                }
                cbxColName.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void InitColList()
        {
            lstColList.Clear();
            lstColList.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();           
            columnDefault = new ColumnHeader();
            columnDefault.Text = "列名称";
            columnDefault.Name = "列名称";
            columnDefault.Width = 120;
            lstColList.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "列标题";
            columnDefault.Name = "列标题";
            columnDefault.Width = 120;
            lstColList.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "是否显示";
            columnDefault.Name = "是否显示";
            columnDefault.Width = 80;
            lstColList.Columns.Add(columnDefault);            

            lstColList.View = View.Details;
        }

        private void AddItemToList(ViewTableItemConfig asic)
        {
            ListViewItem itemNew = new ListViewItem(new string[] {asic.列名称,                                                                
                                                                asic.列标题.ToString(),
                                                                asic.是否显示?"显示":"隐藏"}, 0);

            itemNew.Tag = asic;
            itemNew.Name = asic.列名称;

            lstColList.Items.Add(itemNew);
        }        

        private void cbxColName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtColTitle.Text = cbxColName.Text;
        }        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidConfig() == false) return;

                ViewTableItemConfig newItem = new ViewTableItemConfig();
               
                newItem.列名称 = cbxColName.Text;
                newItem.列标题 = txtColTitle.Text;                 
                newItem.是否显示 = cbxIsShow.Text.ToString() == "显示" ? true:false ;               
                
                AddItemToList(newItem);                
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private bool ValidConfig()
        {          
            ViewTableDesign asDesign = new ViewTableDesign();

            try
            {                                
                if (txtColTitle.Text == "")
                {
                    MsgBox.ShowInf("请输入列标题后，重新添加。");
                    txtColTitle.Focus();
                    return false;
                }
                
                //判断是否有同名的控件                                          
                foreach (ListViewItem lvi in lstColList.Items)
                {
                    asDesign.ViewTableCfg.Add(lvi.Tag as ViewTableItemConfig);
                    if (asDesign.ViewTableCfg[asDesign.ViewTableCfg.Count - 1].列名称 == cbxColName.Text)
                    {
                        MsgBox.ShowInf("控件“" + cbxColName.Text + "”已存在，请不要重复添加。");
                        return false;
                    }
                }                
                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }

        }

        private bool ValidOK()
        {
            bool isAutoDel = false;
            try            
            {
                ViewTableItemConfig vtic = null;
                foreach ( ListViewItem lvi in lstColList.Items)
                {
                    vtic = lvi.Tag as ViewTableItemConfig;
                    if(cbxColName.Items.Contains(vtic.列名称)==false)
                    {
                        if (isAutoDel == false)
                        {
                            if(MsgBox.ShowQuestion("数据列配置中，包含不属于" + (rbtnPACS.Checked ? "PACS" : "HIS") + "的列，是否自动删除这些列后保存？", MessageBoxButtons.YesNo, this) == DialogResult.Yes)
                            {
                                isAutoDel = true;
                            }
                            else
                            {
                                return false;
                            }
                        }                        
                        lstColList.Items.Remove(lvi);                        
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstColList.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("请选择需要删除的项目。", "提示");
                    return;
                }

                ListViewItem delItem = lstColList.SelectedItems[0];
                
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

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstColList.SelectedItems.Count > 0 && lstColList.SelectedItems[0].Index != 0)
                {
                    lstColList.BeginUpdate();
                    foreach (ListViewItem lvi in lstColList.SelectedItems)
                    {
                        ListViewItem item = lvi;
                        int index = lvi.Index;
                        lstColList.Items.RemoveAt(index);
                        lstColList.Items.Insert(index - 1, item);
                    }
                    lstColList.EndUpdate();
                }
                lstColList.Focus();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstColList.SelectedItems.Count > 0 && lstColList.SelectedItems[lstColList.SelectedItems.Count - 1].Index < (lstColList.Items.Count - 1))
                {
                    lstColList.BeginUpdate();
                    int count = lstColList.SelectedItems.Count;
                    foreach (ListViewItem lvi in lstColList.SelectedItems)
                    {
                        ListViewItem item = lvi;
                        int index = lvi.Index;
                        lstColList.Items.RemoveAt(index);
                        lstColList.Items.Insert(index + count, item);
                    }
                    lstColList.EndUpdate();
                }
                lstColList.Focus();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void rbtnPACS_CheckedChanged(object sender, EventArgs e)
        {          
            _viewTableDesign.查PACS库 = rbtnPACS.Checked;
            InitColName();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowQuestion("是否删除所有的数据列？",MessageBoxButtons.YesNo, this)== DialogResult.Yes)
            {
                lstColList.Items.Clear();
            }
        }
    }
}

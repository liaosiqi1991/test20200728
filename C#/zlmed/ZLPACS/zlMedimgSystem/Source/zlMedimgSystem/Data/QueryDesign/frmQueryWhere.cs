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

namespace zlMedimgSystem.QueryDesign
{
    public partial class frmQueryWhere : Form
    {

        private string _whereItem = "";
        private WhereItem _wi = null;
        private bool _isTabChanging = false;
        private bool _isCondationChange = false;
        private bool _isOk = false;

        private IDBQuery _dbHelper = null;

        private List<string> _sysPars = null;
        public frmQueryWhere()
        {
            InitializeComponent();

            _wi = new WhereItem();
        }


        public WhereItem ShowWhereItem(IDBQuery dbHelper, List<string> sysPars, string whereItem, IWin32Window owner)
        {
            _isOk = false;

            _dbHelper = dbHelper;
            _sysPars = sysPars;
            _whereItem = whereItem;

            this.ShowDialog(owner);

            return _wi;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            _isOk = false;
            _wi = null;
            this.Close();
        }


        private bool ValidateData()
        {
            if (string.IsNullOrEmpty(txtWhereItemName.Text))
            {
                MessageBox.Show("条件项名称不允许为空。", "提示");
                txtWhereItemName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(rtbWhereContext.Text))
            {
                MessageBox.Show("判断条件不允许为空。", "提示");
                rtbWhereContext.Focus();
                return false;
            }

            return true;
        }
        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData() == false) return;

                WhereItem result = new WhereItem();

                result.Name = txtWhereItemName.Text;
                result.LinkType = cbxLinkType.Text;
                result.Condition = rtbWhereContext.Text;
                

                foreach(TabPage tc in tabItems.TabPages)
                {
                    InputItem ii = new InputItem();
                    ii.CopyFrom(_wi.InputItems[tc.Name]);

                    if (string.IsNullOrEmpty(ii.ControlType))
                    {
                        ii.ControlType = QueryConstDefine.Txt;
                    }


                    result.AddInputItem(ii, ii.StartIndex);
                }

                result.SourceFmt = result.SaveWhereToString();

                _wi = result;

                _isOk = true;

                this.Close();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //tabItems.TabPages.Clear();
                if (_isTabChanging) return;

                _isCondationChange = true;


                string source = rtbWhereContext.Text;
                MatchInfos inputs = QueryHelper.GetMinMatchData(source, "[", "]");
  
                for(int i = _wi.InputItems.Values.Count - 1; i >=0; i--)
                {
                    InputItem iiDel = _wi.InputItems.Values.ElementAt(i);
                    if (source.IndexOf("[" + iiDel.Name + "]") < 0)
                    {
                        _wi.InputItems.Remove(iiDel.Name);
                    }
                  
                }

                //删除不存在的tab
                for(int i = tabItems.TabPages.Count - 1; i >= 0; i --)
                {
                    if (inputs.Contains(tabItems.TabPages[i].Name) == false)
                    {
                        tabItems.TabPages.RemoveAt(i);
                    }
                }



                InputControlEnable( true);


                foreach (MatchInfo input in inputs)
                {
                    if (string.IsNullOrEmpty(input.MatchContext)) continue;

                    if (tabItems.TabPages.IndexOfKey(input.MatchContext) >=0) continue;

                    if (input.MatchContext.IndexOf("系统_") >= 0) continue;

                    tabItems.TabPages.Add(input.MatchContext, input.MatchContext); 

                    if (_wi.InputItems.ContainsKey(input.MatchContext) == false)
                    {
                        InputItem curInput = new InputItem();
                        curInput.Name = input.MatchContext; 

                        _wi.AddInputItem(curInput, input.StartIndex);
                    }
                }



                if (tabItems.TabPages.Count > 0)
                {
                    tabItems.SelectedIndex = 0;
                }
                else
                {
                    //清除数据
                    cbxControlType.SelectedIndex = 0;
                    rtbDataFrom.Text = "";
                    txtExtPros.Text = "";
                    txtDefaultValue.Text = "";
                    chkReplace.Checked = false;

                }

                InputControlEnable((tabItems.TabPages.Count <= 0) ? false : true);

                rtbWhereContext.Focus();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isCondationChange = false;
            }
        }

        private void InputControlEnable(bool enableState)
        {
            cbxControlType.Enabled = enableState;
            rtbDataFrom.Enabled = enableState;
            txtExtPros.Enabled = enableState;
            txtDefaultValue.Enabled = enableState;
            chkReplace.Enabled = enableState;
        }

        private void ClearQueryTag()
        {
            cbxControlType.Text = "";
            rtbDataFrom.Text = "";
            txtExtPros.Text = "";
            txtDefaultValue.Text = "";

            chkReplace.Checked = false;
        }

        private void tabItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isCondationChange) return;

                _isTabChanging = true; 

                ClearQueryTag();

                if (_wi.InputItems.ContainsKey(tabItems.SelectedTab.Name) == false) return;

                InputItem qt = _wi.InputItems[tabItems.SelectedTab.Name];

                cbxControlType.Text = qt.ControlType;
                rtbDataFrom.Text = qt.DataFrom;
                txtExtPros.Text = qt.ExtPro;
                txtDefaultValue.Text = qt.DefaultValue;

                chkReplace.Checked = qt.IsWhereReplace;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isTabChanging = false;
            }
        }


        private void cbxControlType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isTabChanging) return;

                if (tabItems.SelectedTab == null) return;
                if (_wi.InputItems.ContainsKey(tabItems.SelectedTab.Name) == false) return;

                switch((sender as Control).Name)
                {
                    case "cbxControlType":
                        _wi.InputItems[tabItems.SelectedTab.Name].ControlType = cbxControlType.Text.Split('-')[0];
                        break;

                    case "rtbDataFrom":
                        _wi.InputItems[tabItems.SelectedTab.Name].DataFrom = rtbDataFrom.Text;
                        break;

                    case "txtExtPros":
                        _wi.InputItems[tabItems.SelectedTab.Name].ExtPro = txtExtPros.Text;
                        break;

                    case "txtDefaultValue":
                        _wi.InputItems[tabItems.SelectedTab.Name].DefaultValue = txtDefaultValue.Text;
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void chkReplace_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabItems.SelectedTab == null) return;

                if (tabItems.SelectedTab == null) return;
                if (_wi.InputItems.ContainsKey(tabItems.SelectedTab.Name) == false) return;

                _wi.InputItems[tabItems.SelectedTab.Name].IsWhereReplace = chkReplace.Checked;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void LoadDataSource()
        {
            cbxDBAlias.DisplayMember = "Name";

            ItemBind ib = new ItemBind("", "");
            cbxDBAlias.Items.Add(ib);


            ThridDBSourceModel dbSourceModel = new ThridDBSourceModel(_dbHelper);

            DataTable dtDBSource = dbSourceModel.GetAllThridDBSource();


            foreach (DataRow dr in dtDBSource.Rows)
            {
                ThridDBSourceData dbSource = new ThridDBSourceData();
                dbSource.BindRowData(dr);

                ItemBind ibSource = new ItemBind(dbSource.数据源别名, "");
                ibSource.Tag = dbSource;

                cbxDBAlias.Items.Add(ibSource);
            }
        }

        private void frmWhereItem_Load(object sender, EventArgs e)
        {
            try
            {
                _isTabChanging = true; 
                
                try
                {
                    LoadDataSource();

                    cbxControlType.SelectedIndex = 0;

                    _wi.LoadWhereFromString(_whereItem);

                    txtWhereItemName.Text = _wi.Name;
                    cbxLinkType.Text = _wi.LinkType;
                    rtbWhereContext.Text = _wi.Condition;


                    foreach (InputItem ii in _wi.InputItems.Values)
                    {
                        if (ii.Name.IndexOf("系统_") >= 0) continue;
                        tabItems.TabPages.Add(ii.Name, ii.Name);
                    }

                    if (_wi.InputItems.Count > 0) cbxControlType.Enabled = false;
                }
                finally
                {
                    _isTabChanging = false;
                }

                if (tabItems.TabPages.Count > 0) tabItems_SelectedIndexChanged(tabItems,e);
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
                if (_isTabChanging) return;

                if (tabItems.SelectedTab == null) return;
                if (_wi.InputItems.ContainsKey(tabItems.SelectedTab.Name) == false) return;

                _wi.InputItems[tabItems.SelectedTab.Name].ControlType = cbxControlType.Text.Split('-')[0];
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmQueryWhere_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (_isOk == false) _wi = null;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butInsertPars_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmPars parSelector = new frmPars())
                {
                    string par = parSelector.ShowPars(_sysPars, this);

                    if (string.IsNullOrEmpty(par)) return;

                    rtbWhereContext.SelectedText = par;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }

        private void butInsertParToDataFrom_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmPars parSelector = new frmPars())
                {
                    string par = parSelector.ShowPars(_sysPars, this);

                    if (string.IsNullOrEmpty(par)) return;

                    rtbDataFrom.SelectedText = par;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

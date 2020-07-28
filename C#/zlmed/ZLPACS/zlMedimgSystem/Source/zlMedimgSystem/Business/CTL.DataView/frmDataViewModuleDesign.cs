using DevExpress.XtraLayout;
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
using zlMedimgSystem.Layout;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.DataView
{
    public partial class frmDataViewModuleDesign : Form
    {
        public event QueryParValueEvent OnRequestPar;

        private bool _isOk = false;
        private IDBQuery _dbHelper = null;
        private IDBQuery _thridDBHelper = null;
        private DataViewModuleDesign _dataViewDesign = null;
        public frmDataViewModuleDesign()
        {
            InitializeComponent();
        }

        public IDBQuery CurDBHelper
        {
            get
            {
                if (_thridDBHelper != null) return _thridDBHelper;

                return _dbHelper;
            }
        }

        public IDBQuery DBHelper
        {
            get
            {
                return _dbHelper;
            }
        }


        public string CurSql
        {
            get
            {
                return richTextBox1.Text;
            }
        }

        public bool ShowDataViewModuleDesign(IDBQuery dbHelper, DataViewModuleDesign dataViewDesign, IWin32Window owner)
        {
            _isOk = false;

            _dbHelper = dbHelper;
            _dataViewDesign = dataViewDesign;

            this.ShowDialog(owner);

            return _isOk;
        }

        private void dataViewLayout1_OnSelDesign(object selControl)
        {
            try
            {
                SelDesignControlProcess(selControl);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void SelDesignControlProcess(object selControl)
        {

            if (selControl is LayoutControlItem)
            {
                propertyGrid1.SelectedObject = new ViewItemWrapper(selControl as LayoutControlItem);
            }
            else if (selControl is LayoutControlGroup)
            {
                if (selControl == dataViewLayout1.LayoutCore.Root)
                {
                    propertyGrid1.SelectedObject = new LayoutControlRootGroupWrapper(selControl as LayoutControlGroup);
                }
                else
                {
                    propertyGrid1.SelectedObject = new LayoutControlGroupProWrapper(selControl as LayoutControlGroup);
                }
            }
            else if (selControl is TabbedControlGroup)
            {
                propertyGrid1.SelectedObject = new TabbedControlGroupProWrapper(selControl as TabbedControlGroup);
            }
            else
            {
                propertyGrid1.SelectedObject = selControl;
            }

            //pgDesign.ExpandAllGridItems();
        }



        private void tsbTxt_Click(object sender, EventArgs e)
        {
            try
            {
                ViewItem vi = new ViewItem();

                vi.InstanceName = "TXT_" + SqlHelper.GetNumGuid();
                vi.ControlType = ViewControlType.Txt;
        
                dataViewLayout1.AddInputControl(vi);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private ThridDBSourceModel _dbSourceModel = null;
        private void LoadDataSource()
        {
            cbxDBAlias.DisplayMember = "Name";

            ItemBind ib = new ItemBind("", "");
            cbxDBAlias.Items.Add(ib);

            if (_dbSourceModel == null)
            {
                _dbSourceModel = new ThridDBSourceModel(_dbHelper);
            }

            DataTable dtDBSource = _dbSourceModel.GetAllThridDBSource();


            foreach (DataRow dr in dtDBSource.Rows)
            {
                ThridDBSourceData dbSource = new ThridDBSourceData();
                dbSource.BindRowData(dr);

                ItemBind ibSource = new ItemBind(dbSource.数据源别名, "");
                ibSource.Tag = dbSource;

                cbxDBAlias.Items.Add(ibSource);
            }
        }

        private void LoadSystemPar()
        {
            listBox1.Items.Clear();

            foreach (string par in SqlHelper.SysFixPars.Split(','))
            {
                if (string.IsNullOrEmpty(par)) continue;
                listBox1.Items.Add("[系统." + par + "]");
            }
        }


        private void frmDataViewModuleDesign_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataSource();

                LoadSystemPar();

                dataViewLayout1.DBHelper = _dbHelper;

                if (_dataViewDesign != null)
                {
                    cbxDBAlias.Text = _dataViewDesign.DBSourceAlias;
                    richTextBox1.Text = _dataViewDesign.DataFrom;

                    dataViewLayout1.LoadLayout(_dataViewDesign.Items, _dataViewDesign.LayoutFmt);
                }
                timer1.Enabled = true;
                //dataViewLayout1.IsDesignModel = true;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbCbx_Click(object sender, EventArgs e)
        {
            try
            {
                ViewItem vi = new ViewItem();

                vi.InstanceName = "CBX_" + SqlHelper.GetNumGuid();
                vi.ControlType = ViewControlType.Cbx;

                dataViewLayout1.AddInputControl(vi);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbDtp_Click(object sender, EventArgs e)
        {
            try
            {
                ViewItem vi = new ViewItem();

                vi.InstanceName = "DTP_" + SqlHelper.GetNumGuid();
                vi.ControlType = ViewControlType.Dtp;

                dataViewLayout1.AddInputControl(vi);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbChkBox_Click(object sender, EventArgs e)
        {
            try
            {
                ViewItem vi = new ViewItem();

                vi.InstanceName = "CHK_" + SqlHelper.GetNumGuid();
                vi.ControlType = ViewControlType.Checkbox;

                dataViewLayout1.AddInputControl(vi);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            try
            {
                dataViewLayout1.RemoveSelControl();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        public object QueryPar(string parName)
        {
            return OnRequestPar?.Invoke(parName);
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            try
            {
                DataViewModuleDesign dataViewDesign = new DataViewModuleDesign();
                dataViewDesign.DataFrom = richTextBox1.Text;
                dataViewDesign.DBSourceAlias = cbxDBAlias.Text;

                List<ViewItem> vis = null;
                string layoutFormat = "";

                dataViewLayout1.GetLayout(out vis, out layoutFormat);

                dataViewDesign.Items = new List<ViewItem>(vis);
                dataViewDesign.LayoutFmt = layoutFormat;

                using (frmTest test = new frmTest())
                {
                    test.OnRequestPar += QueryPar;
                    test.ShowTest(_dbHelper, dataViewDesign, this);
                }
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

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dataViewDesign == null) _dataViewDesign = new DataViewModuleDesign();

                _dataViewDesign.DataFrom = richTextBox1.Text;
                _dataViewDesign.DBSourceAlias = cbxDBAlias.Text;

                List<ViewItem> vis = null;
                string layoutFormat = "";

                dataViewLayout1.GetLayout(out vis, out layoutFormat);

                _dataViewDesign.Items = new List<ViewItem>(vis);
                _dataViewDesign.LayoutFmt = layoutFormat;

                _isOk = true;

                //this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;

                dataViewLayout1.IsDesignModel = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.SelectedText = listBox1.Text;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxDBAlias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbxDBAlias.Text) )
                {
                    _thridDBHelper = null;
                    return;
                }

                string strErr = "";
                _thridDBHelper = SqlHelper.GetThridDBHelper(cbxDBAlias.Text, _dbHelper, ref strErr);

                if (_thridDBHelper == null)
                {
                    MessageBox.Show("数据源链接错误：" + strErr, "提示");
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbVerify_Click(object sender, EventArgs e)
        {
            try
            {
                string pars = SqlHelper.GetSqlPars(richTextBox1.Text);

                if (richTextBox1.Text.ToUpper().IndexOf("SELECT") >= 0)
                {
                    DataTable dtResult = SqlHelper.TestSql(CurDBHelper, richTextBox1.Text, pars, "", this);

                    if (dtResult == null)
                    {
                        MessageBox.Show("验证失败，没有结果返回。", "提示");
                    }
                    else
                    {
                        MessageBox.Show("验证成功。", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("非SQL查询。", "提示");
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbLab_Click(object sender, EventArgs e)
        {
            try
            {
                ViewItem vi = new ViewItem();

                vi.InstanceName = "LAB_" + SqlHelper.GetNumGuid();
                vi.ControlType = ViewControlType.Lab;

                dataViewLayout1.AddInputControl(vi);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbNull_Click(object sender, EventArgs e)
        {
            try
            {
                dataViewLayout1.AddEmptyItemElement();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbGroup_Click(object sender, EventArgs e)
        {
            try
            {
                dataViewLayout1.AddTagGroupElement();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

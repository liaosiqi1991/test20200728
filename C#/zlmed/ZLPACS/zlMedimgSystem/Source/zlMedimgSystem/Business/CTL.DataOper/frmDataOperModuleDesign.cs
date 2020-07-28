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

namespace zlMedimgSystem.CTL.DataOper
{
    public partial class frmDataOperModuleDesign : Form
    {
        private bool _isOk = false;
        private DataOperModuleDesign _dataOperDesign = null;
        private IDBQuery _dbHelper = null;

        public frmDataOperModuleDesign()
        {
            InitializeComponent();
        }

        public bool ShowDataOperModuleDesign(IDBQuery dbHelper, DataOperModuleDesign dataOperDesign, IWin32Window owner)
        {
            _isOk = false;
            _dataOperDesign = dataOperDesign;
            _dbHelper = dbHelper;

            this.ShowDialog(owner);

            return _isOk;
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

        private void LoadPars()
        {
            string[] pars = SqlHelper.SysFixPars.Split(',');

            foreach(string par in pars)
            {
                if (string.IsNullOrEmpty(par)) continue;

                if (("申请ID,患者ID,申请识别码,患者识别码,患者姓名").IndexOf(par) >= 0) continue;

                lbPars.Items.Add("[系统_" + par + "]");
            }
        }


        private void frmDataOperModuleDesign_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataSource();

                LoadPars();

                lbMethodName.DisplayMember = "Name";
                lbMethodName.ValueMember = "Name";

                foreach (DataOperItem doi in _dataOperDesign.DataOperItems)
                {
                    ItemBind ib = new ItemBind();

                    ib.Name = doi.ItemName;
                    ib.Tag = doi;

                    lbMethodName.Items.Add(ib);
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbMethodName.SelectedItem == null) return;

                DialogResult dr = MessageBox.Show("是否确认删除改项？", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;

                tbName.Text = "";
                rtbContext.Text = "";

                lbMethodName.Items.Remove(lbMethodName.SelectedItem);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbMethodName.SelectedItem == null) return;

                int fIndex = lbMethodName.FindString(tbName.Text);

                if (fIndex < 0 || fIndex == lbMethodName.Items.IndexOf(lbMethodName.SelectedItem))
                {
                    ItemBind ib = lbMethodName.SelectedItem as ItemBind;

                    ib.Name = tbName.Text;
                    ib.Value = tbName.Text;

                    DataOperItem doi = ib.Tag as DataOperItem;

                    doi.ItemName = tbName.Text;
                    doi.DBAlias = cbxDBAlias.Text;
                    doi.ProcessContext = rtbContext.Text;
                    doi.ReturnName = txtReturnName.Text;
                }
                else
                {
                    MessageBox.Show("名称存在重复，不能进行更新。", "提示");
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        private void tsbDebug_Click(object sender, EventArgs e)
        {
            try
            {
                string pars = SqlHelper.GetSqlPars(rtbContext.Text);


                DataTable dtResult = SqlHelper.TestSql(_dbHelper, rtbContext.Text, pars, cbxDBAlias.Text, this);

                MessageBox.Show("验证成功。", "提示");


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
                _dataOperDesign.DataOperItems.Clear();

                foreach(ItemBind ib in lbMethodName.Items)
                {
                    _dataOperDesign.DataOperItems.Add(ib.Tag as DataOperItem);
                }

                _isOk = true;

                this.Close();


            }
            catch (Exception ex)
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

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbMethodName.FindString(tbName.Text) >= 0)
                {
                    MessageBox.Show("名称重复，不允许新增。", "提示");
                    return;
                }

                DataOperItem doi = new DataOperItem();
                doi.ItemName = tbName.Text;
                doi.DBAlias = cbxDBAlias.Text;
                doi.ProcessContext = rtbContext.Text;
                doi.ReturnName = txtReturnName.Text;

                ItemBind ib = new ItemBind(doi.ItemName, doi.ItemName);
                ib.Tag = doi;

                lbMethodName.Items.Add(ib);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void lbMethodName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tbName.Text = "";
                cbxDBAlias.Text = "";
                rtbContext.Text = "";
                txtReturnName.Text = "";

                if (lbMethodName.SelectedItem == null) return;

                ItemBind ib = lbMethodName.SelectedItem as ItemBind;

                DataOperItem doi = ib.Tag as DataOperItem;

                tbName.Text = doi.ItemName;
                cbxDBAlias.Text = doi.DBAlias;
                rtbContext.Text = doi.ProcessContext;
                txtReturnName.Text = doi.ReturnName;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void lbPars_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lbPars.SelectedItem == null) return;

                rtbContext.SelectedText = lbPars.Text;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

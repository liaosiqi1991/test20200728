using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BaseSettings
{
    public delegate void SaveReportTemplateQuery(JReportTemplateQuery templateQuery);
    public partial class frmReportDataConfig : Form
    {
        public event SaveReportTemplateQuery OnSaveReportTemplateDataSource;



        private JReportTemplateQuery _reportTemplateQuery = null;
        private ThridDBSourceModel _dbSourceModel = null;
        private IDBQuery _dbHelper = null;
        private bool _isLoading = false;

        private bool _isModify = false;
        public frmReportDataConfig(IDBQuery dbHelper)
        {
            InitializeComponent();

            _dbHelper = dbHelper;
        }

        public bool IsModify
        {
            get { return _isModify; }
            set
            {
                _isModify = value;
                tsbSave.Enabled = value;
            }
        }

        public void ShowDataConfig(JReportTemplateQuery templateQuery, IWin32Window owner)
        {
            _reportTemplateQuery = templateQuery;
            this.ShowDialog(owner);
        }

        private void frmReportDataConfig_Load(object sender, EventArgs e)
        {
            _isLoading = true;

            try
            {

                listBox1.Items.Clear();

                foreach(string par in SqlHelper.SysFixPars.Split(','))
                {
                    listBox1.Items.Add("[" + par + "]");
                }


                LoadDataSource();

                if (_reportTemplateQuery != null)
                {
                    txtName.Text = _reportTemplateQuery.查询名称;
                    cbxDBSource.Text = _reportTemplateQuery.数据源别名;
                    rtbContext.Text = _reportTemplateQuery.查询内容;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void LoadDataSource()
        {
            cbxDBSource.DisplayMember = "Name";

            ItemBind ib = new ItemBind("", "");
            cbxDBSource.Items.Add(ib);

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

                cbxDBSource.Items.Add(ibSource);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_reportTemplateQuery == null)
                {
                    _reportTemplateQuery = new JReportTemplateQuery();
                    _reportTemplateQuery.查询ID = SqlHelper.GetCmpUID();
                }

                _reportTemplateQuery.查询名称 = txtName.Text;
                _reportTemplateQuery.数据源别名 = cbxDBSource.Text;
                _reportTemplateQuery.查询内容 = rtbContext.Text;

                OnSaveReportTemplateDataSource?.Invoke(_reportTemplateQuery);

                IsModify = false;

                this.Close();

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

        private void rtbContext_TextChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;

            IsModify = true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;

            IsModify = true;
        }

        private void cbxDBSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;

            IsModify = true;
        }


        /// <summary>
        /// 测试查询
        /// </summary>
        private bool TestSql(string strTestSql, bool isHint)
        {
            try
            {
                DataTable dt = SqlHelper.TestSql(_dbHelper, strTestSql, SqlHelper.SysFixPars, cbxDBSource.Text, this);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;

                    if (isHint) MessageBox.Show("验证成功。");

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void tsbTest_Click(object sender, EventArgs e)
        {
            //测试查询
            try
            {
                TestSql(rtbContext.Text, true);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //插入参数
            try
            {
                if (listBox1.SelectedIndex < 0) listBox1.SelectedIndex = 0;

                rtbContext.SelectedText = listBox1.Text;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmReportDataConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_isModify)
                {
                    if (MessageBox.Show("配置已被修改，是否进行保存？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        tsbSave_Click(tsbSave, null);
                    }

                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

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

namespace zlMedimgSystem.CTL.Query
{
    public partial class frmQueryDesign : Form
    {
        private bool _isOk = false;
        private QueryModuleDesign _queryDesign = null;
        private IDBQuery _dbHelper = null;
        private ThridDBSourceModel _dbSourceModel = null;

        public frmQueryDesign()
        {
            InitializeComponent();
        }

        public bool ShowDesign(QueryModuleDesign queryDesign, IDBQuery dbHelper, IWin32Window owner)
        {
            _isOk = false;
            _queryDesign = queryDesign;
            _dbHelper = dbHelper;

            this.ShowDialog(owner);

            return _isOk;
        }

        private void tsbInsertWhere_Click(object sender, EventArgs e)
        {
            try
            {
                queryDesigner1.InsertWhereItem();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbLayout_Click(object sender, EventArgs e)
        {
            try
            {
                queryDesigner1.DesignState = !queryDesigner1.DesignState;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                queryDesigner1.DesignState = false;
                //queryDesigner1.LoadFromString(_queryDesign.QueryConfig);
                queryDesigner1.RefreshLayout();
                 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbTest_Click(object sender, EventArgs e)
        {
            try
            {
                IDBQuery curDBHelper = _dbHelper;

                if (string.IsNullOrEmpty(tsCbxDataSource.Text) == false)
                {
                    string strErr = "";
                    curDBHelper = SqlHelper.GetThridDBHelper(tsCbxDataSource.Text, _dbHelper, ref strErr);

                    if (curDBHelper == null)
                    {
                        MessageBox.Show("获取数据访问接口产生错误：" + strErr, "提示");
                        return;
                    }
                }

                queryDesigner1.ShowQuery(curDBHelper);
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
                _queryDesign.DBSourceAlias = tsCbxDataSource.Text;
                _queryDesign.QueryConfig = queryDesigner1.SaveToString();

                _isOk = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmQueryDesign_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataSource();
                 
                tsCbxDataSource.Text = _queryDesign.DBSourceAlias;

                queryDesigner1.DBHelper = _dbHelper;
                queryDesigner1.SysParList = new List<string>(SqlHelper.SysFixPars.Split(','));
                queryDesigner1.LoadFromString(_queryDesign.QueryConfig);

                queryDesigner1.DesignState = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void LoadDataSource()
        {
            tsCbxDataSource.ComboBox.DisplayMember = "Name";

            ItemBind ib = new ItemBind("", "");
            tsCbxDataSource.Items.Add(ib);

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

                tsCbxDataSource.Items.Add(ibSource);
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

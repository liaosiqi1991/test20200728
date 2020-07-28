using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.QueryDesign
{
    public partial class frmQueryFilter : Form
    {
        private string _queryScheme = "";
        //private string _sqlFormatContext = "";
        //private string _layoutContext = "";

        private string _sql = "";
        private IDBQuery _dbHelper = null;
        private Dictionary<string, object>  _pars = null;
        public frmQueryFilter()
        {
            InitializeComponent(); 
        }

        public void ShowQueryFilter(IWin32Window owner, IDBQuery dbHelper, 
            string queryScheme, out string sql, out Dictionary<string, object> pars)
        {
            sql = "";
            pars = null;

            _dbHelper = dbHelper;
            _queryScheme = queryScheme;


            this.ShowDialog(owner);

            pars = _pars;
            sql = _sql;

        }

        private void frmQueryFilter_Load(object sender, EventArgs e)
        {
            queryLayout1.DBHelper = _dbHelper;
            queryLayout1.LoadSchemeFromString(_queryScheme);

            this.Height = queryLayout1.Height + panel1.Height;

            DesignHelper.RestoreWindowPostion(this);
        }

        private void butCancel_Click(object sender, EventArgs e)
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

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                queryLayout1.Query.CreateQuerySql(out _sql, out _pars);


                this.Close();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void queryLayout1_Resize(object sender, EventArgs e)
        {
        }

        private void frmQueryFilter_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                DesignHelper.SaveWindowPostion(this);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }
    }
}

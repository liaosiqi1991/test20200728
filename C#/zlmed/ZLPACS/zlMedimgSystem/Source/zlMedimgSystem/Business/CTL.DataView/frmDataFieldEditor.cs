using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.DataView
{
    public partial class frmDataFieldEditor : Form
    {
        private string _dataField = "";
        private string _sql = "";
        private IDBQuery _dbHelper = null;
        public frmDataFieldEditor()
            : this(null, "", null)
        {

        }

        public frmDataFieldEditor(IDBQuery dbHelper, string sql, object dataField)
        {
            InitializeComponent();

            _dbHelper = dbHelper;
            _sql = sql;
            if (dataField != null) _dataField = dataField.ToString();

        }

        public string DataField
        {
            get { return _dataField; }
        }

        /// <summary>
        /// 编辑属性值
        /// </summary>
        /// <param name="designParent"></param>
        /// <param name="instance"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object EditValue(Control designParent, IDBQuery dbHelper, string sql, object value)
        {
            using (frmDataFieldEditor form = new frmDataFieldEditor(dbHelper, sql, value))
            {
                form.ShowDialog(designParent);

                return form.DataField;
            }
        }

        private void frmDataFieldSelect_Load(object sender, EventArgs e)
        {
            string pars = SqlHelper.GetSqlPars(_sql);
            DataTable dtField = SqlHelper.TestSql(_dbHelper, _sql, pars, "", this);

            if (dtField == null) return;

            foreach(DataColumn dc in dtField.Columns)
            {
                listBox1.Items.Add(dc.ColumnName);
            }
            
            string[] sysPars = SqlHelper.SysFixPars.Split(',');
            foreach(string par in sysPars)
            {
                if (string.IsNullOrEmpty(par)) continue;

                if (("申请ID,申请识别码,患者ID,患者识别码,患者姓名").IndexOf(par) >= 0) continue;

                listBox1.Items.Add("系统_" + par);
            }

            listBox1.Text = _dataField;
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

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                _dataField = listBox1.Text;
                this.Close();
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
                _dataField = listBox1.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.DataView
{
    public partial class frmDataFromEditor : Form
    {
        private string _dataFrom = "";
        private IDBQuery _dbHelper = null;
        public frmDataFromEditor()
            : this(null, null)
        {
            
        }

        public frmDataFromEditor(IDBQuery dbHelper, object dataFrom)
        {
            InitializeComponent();

            _dbHelper = dbHelper;
            if (dataFrom != null) _dataFrom = dataFrom.ToString();

        }

        public string DataFrom
        {
            get { return _dataFrom; }
        }

        /// <summary>
        /// 编辑属性值
        /// </summary>
        /// <param name="designParent"></param>
        /// <param name="instance"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object EditValue(Control designParent, IDBQuery dbHelper, object value)
        {
            using (frmDataFromEditor form = new frmDataFromEditor(dbHelper, value))
            {
                form.ShowDialog(designParent);

                return form.DataFrom;
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

        private void frmDataFromEditor_Load(object sender, EventArgs e)
        {
            try
            {

                LoadDataSource();

                cbxDBAlias.Text = "";
                richTextBox1.Text = "";

                if (string.IsNullOrEmpty(_dataFrom) == false)
                {
                    string[] tmp = _dataFrom.Split('|');

                    if (tmp.Length > 1)
                    {
                        cbxDBAlias.Text = tmp[0];
                        richTextBox1.Text = tmp[1];
                    }
                    else
                    {
                        cbxDBAlias.Text = "";
                        richTextBox1.Text = tmp[0];
                    }
                } 

                string[] aryPars = SqlHelper.SysFixPars.Split(',');

                foreach(string par in aryPars)
                {
                    if (string.IsNullOrEmpty(par)) continue;

                    if (("申请ID,患者ID,申请识别码,患者识别码,患者姓名").IndexOf(par) >= 0) continue;

                    listBoxPars.Items.Add("[系统_" + par + "]");
                }
              
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
                if (string.IsNullOrEmpty(richTextBox1.Text))
                {
                    MessageBox.Show("配置内容不允许为空。", "提示");
                    return;
                }

                if (richTextBox1.Text.ToUpper().IndexOf("SELECT") >= 0)
                {
                    _dataFrom = cbxDBAlias.Text + "|" + richTextBox1.Text;
                }
                else
                {
                    _dataFrom = richTextBox1.Text;
                }
                this.Close();
            }
            catch(Exception ex)
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

        private void butTest_Click(object sender, EventArgs e)
        {
            try
            {
                string pars = SqlHelper.GetSqlPars(richTextBox1.Text);

                if (richTextBox1.Text.ToUpper().IndexOf("SELECT") >= 0)
                {
                    SqlHelper.TestSql(_dbHelper, richTextBox1.Text, pars, cbxDBAlias.Text, this);

                    MessageBox.Show("验证成功。", "提示");
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

        private void listBoxPars_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listBoxPars.SelectedItem == null) return;

                richTextBox1.SelectedText = listBoxPars.Text;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}


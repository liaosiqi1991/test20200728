using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.CTL.Study
{
    public partial class frmFilter : Form
    {
        public string _strSQL="";

        public frmFilter()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _strSQL = "";
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            clear();
        }

        private void clear()
        {
            txtItem.Text = "";
            txtName.Text = "";
            cboItem.SelectedIndex = 0;
            dtpStart.Text= System.DateTime.Now.ToString("yyyy-MM-d 0:00:00");
            dtpEnd.Text = System.DateTime.Now.ToString("yyyy-MM-d 23:59:59");

        }

        private void frmFilter_Load(object sender, EventArgs e)
        {
            clear();
        }

        public string ZlShow()
        {
            this.ShowDialog();
            return _strSQL;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string strTmp;

            _strSQL = "Select 患者信息 from 影像检查信息 where 1=1 ";

            strTmp = txtName.Text.Trim();
            if (strTmp != "")
            {
                _strSQL += " And 姓名 like '%" + strTmp + "%'";
            }

            strTmp = txtItem.Text.Trim();
            if (strTmp != "")
            {
                _strSQL += " AND " +cboItem.SelectedItem.ToString() + " ='" + strTmp + "'";
            }

            _strSQL += " AND 报到日期 BETWEEN to_date('" + dtpStart.Text + "', 'yyyy-MM-dd HH24:MI:ss') AND to_date('" + dtpEnd.Text + "', 'yyyy-MM-dd HH24:MI:ss')" ;
            this.Hide();

        }
    }
}

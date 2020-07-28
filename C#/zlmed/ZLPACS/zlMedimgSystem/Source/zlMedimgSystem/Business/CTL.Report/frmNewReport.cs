using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Report
{

    public delegate void ReportNameExistsEvent(string reportName, ref bool hasReport);
    public partial class frmNewReport : Form
    {

        public event ReportNameExistsEvent OnReportNameExists;

        private bool _isOk = false;
        private string _reportId = "";
        private string _reportName = "";
        private string _bodyPart = "";

        public bool IsOk
        {
            get { return _isOk; }
        }

        public string ReportId
        {
            get { return _reportId; }
        }

        public string ReportName
        {
            get { return _reportName; }
        }

        public string Bodypart
        {
            get { return _bodyPart; }
        }

        public frmNewReport()
        {
            InitializeComponent();
        }

        public void ShowReportNew(IWin32Window owner)
        {
            this.ShowDialog(owner);
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty( txtName.Text ))
                {
                    MessageBox.Show("报告名称不能为空。", "提示");
                    txtName.Focus();
                    return;
                }

                bool hasReport = false;
                OnReportNameExists?.Invoke(txtName.Text, ref hasReport);

                if (hasReport)
                {
                    MessageBox.Show("报告名称已经存在。", "提示");
                    txtName.Focus();
                    return;
                }

                _reportId = SqlHelper.GetNumGuid();
                _reportName = txtName.Text;
                _bodyPart = cbxBodypart.Text;

                _isOk = true;

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
                _isOk = false;
                this.Close();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

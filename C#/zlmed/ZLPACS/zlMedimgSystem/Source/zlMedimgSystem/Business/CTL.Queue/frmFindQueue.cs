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

namespace zlMedimgSystem.CTL.QueueManager
{
    public partial class frmFindQueue : Form
    {
        private bool _isOk = false;
        private string _departmentId = "";
        private QueueModel _qm = null;

        private DataTable _dtLineupInfos = null;
        public frmFindQueue()
        {
            InitializeComponent();
        }


        public bool ShowFindQueue(QueueModel qm, string departmentId, IWin32Window owner, out DataTable dtLineupInfos)
        {
            dtLineupInfos = null;

            _isOk = false;

            _qm = qm;
            _departmentId = departmentId;

            this.ShowDialog(owner);

            dtLineupInfos = _dtLineupInfos;

            return _isOk;

        }

        private void frmFindQueue_Load(object sender, EventArgs e)
        {
            try
            {
                cbxFindType.SelectedIndex = 0;
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

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                switch(cbxFindType.Text)
                {
                    case "患者姓名":
                    case "排队号码":
                        _dtLineupInfos = _qm.FindLineupInfos(_departmentId, cbxFindType.Text, txtValue.Text);

                        break;
                         
                    default:
                        return;
                }

                _isOk = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

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
    public partial class frmModifyQueue : Form
    {

        private bool _isOk = false;
        private QueueModel _qm = null;
        private LineUpData _lineupInfo = null;
        public frmModifyQueue()
        {
            InitializeComponent();
        }

        public bool ShowModifyQueue(QueueModel qm, LineUpData lineupInfo, IWin32Window owner)
        {
            _isOk = false;

            _qm = qm;
            _lineupInfo = lineupInfo;

            this.ShowDialog(owner);

            return _isOk;

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
                if (_lineupInfo == null) return;

                _lineupInfo.患者姓名 = txtName.Text;
                _lineupInfo.附加信息.性别 = cbxSex.Text;
                _lineupInfo.附加信息.年龄 = txtAge.Text;

                _lineupInfo.附加信息.备注 = txtMemo.Text;

                _lineupInfo.附加信息.CopyBasePro(_lineupInfo);

                _qm.UpdateLineupInfo(_lineupInfo);

                _isOk = true;

                this.Close();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmModifyQueue_Load(object sender, EventArgs e)
        {
            try
            {
                if (_lineupInfo == null) return;

                txtName.Text = _lineupInfo.患者姓名;
                cbxSex.Text = _lineupInfo.附加信息.性别;
                txtAge.Text = _lineupInfo.附加信息.年龄;
                txtMemo.Text = _lineupInfo.附加信息.备注;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

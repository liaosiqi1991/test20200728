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

namespace zlMedimgSystem.CTL.QueueManager
{
    public partial class frmQueueDesign : Form
    {
        private bool _isOk = false;
         
        private QueueModuleDesign _queueDesign = null;
        private IDBQuery _dbHelper = null;
        public frmQueueDesign()
        {
            InitializeComponent();
        }

        public bool ShowQueueDesign(QueueModuleDesign queueDesign,
            IStationInfo stationInfo, IDBQuery dbHelper, IWin32Window owner)
        {
            _isOk = false;
             
            _queueDesign = queueDesign; 
            _dbHelper = dbHelper;

            toolsConfig1.InitToolDesign(queueDesign.ToolsDesign);

            this.ShowDialog(owner);

            return _isOk;
        }

        private void frmQueueDesign_Load(object sender, EventArgs e)
        {
            try
            {
                if (_queueDesign != null)
                {
                    chkOrderCall.Checked = _queueDesign.ButOrderCallVisible;
                    chkDirectCall.Checked = _queueDesign.ButDirectCallVisible;
                    chkInsertQueue.Checked = _queueDesign.ButInsertQueueVisible;
                    chkResetQueue.Checked = _queueDesign.ButResetQueueVisible;
                    chkPauseQueue.Checked = _queueDesign.ButPauseQueueVisible;
                    chkAbandon.Checked = _queueDesign.ButAbandonQueueVisible;
                    chkRecept.Checked = _queueDesign.ButReceptQueueVisible;
                    chkRestore.Checked = _queueDesign.ButRestoreQueueVisible;
                    chkPrint.Checked = _queueDesign.ButPrintQueueVisible;
                    chkRefresh.Checked = _queueDesign.ButRefreshQueueVisible;
                    chkModify.Checked = _queueDesign.ButModifyQueueVisible;
                    chkFind.Checked = _queueDesign.ButFindQueueVisible;

                }
            }
            catch (Exception ex)
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
                toolsConfig1.ApplyUpdate();
                     
                if (_queueDesign != null)
                {
                    
                    _queueDesign.ButOrderCallVisible = chkOrderCall.Checked;
                    _queueDesign.ButDirectCallVisible = chkDirectCall.Checked;
                    _queueDesign.ButInsertQueueVisible = chkInsertQueue.Checked;
                    _queueDesign.ButResetQueueVisible = chkResetQueue.Checked;
                    _queueDesign.ButPauseQueueVisible = chkPauseQueue.Checked;
                    _queueDesign.ButAbandonQueueVisible = chkAbandon.Checked;
                    _queueDesign.ButReceptQueueVisible = chkRecept.Checked;
                    _queueDesign.ButRestoreQueueVisible = chkRestore.Checked;
                    _queueDesign.ButPrintQueueVisible = chkPrint.Checked;
                    _queueDesign.ButRefreshQueueVisible = chkRefresh.Checked;
                    _queueDesign.ButModifyQueueVisible = chkModify.Checked;
                    _queueDesign.ButFindQueueVisible = chkFind.Checked;

                    _queueDesign.ToolsDesign = toolsConfig1.ToolsDesign;
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

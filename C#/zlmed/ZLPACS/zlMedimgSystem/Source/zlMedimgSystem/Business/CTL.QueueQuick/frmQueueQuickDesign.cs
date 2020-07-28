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
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.QueueQuick
{
    public partial class frmQueueQuickDesign : Form
    {
        private bool _isOk = false;
        private string _departmentId = "";
        private QueueQuickModuleDesign _queueQuickDesign = null;
        private QueueModel _qm = null;

        public frmQueueQuickDesign()
        {
            InitializeComponent();
        }

        public bool ShowQueueQuickDesign(QueueModel qm, string departmentId, QueueQuickModuleDesign queueQuickDesign, IWin32Window owner)
        {
            _isOk = false;
            _departmentId = departmentId;
            _queueQuickDesign = queueQuickDesign;
            _qm = qm;

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
                _queueQuickDesign.BackColor = ceBackColor.Color;
                _queueQuickDesign.ForeColor = ceForeColor.Color;
                _queueQuickDesign.CallColor = ceCallColor.Color;

                _queueQuickDesign.ModuleFontName = feModuleFont.Value.Name;
                _queueQuickDesign.ModuleFontSize = feModuleFont.Value.Size;
                _queueQuickDesign.ModuleFontBold = feModuleFont.Value.Bold;
                _queueQuickDesign.ModuleFontItalic = feModuleFont.Value.Italic;

                _queueQuickDesign.WaitFontName = feWaitFont.Value.Name;
                _queueQuickDesign.WaitFontSize = feWaitFont.Value.Size;
                _queueQuickDesign.WaitFontBold = feWaitFont.Value.Bold;
                _queueQuickDesign.WaitFontItalic = feWaitFont.Value.Italic;

                //_queueQuickDesign.UseRoomQueueReleation = chkUseRoomReleation.Checked;


                //_queueQuickDesign.QueueItems.Clear();
                //for (int i = 0; i < cbxReleationQueue.Items.Count - 1; i++)
                //{
                //    if (cbxReleationQueue.GetItemChecked(i))
                //    {
                //        ItemBind ib = cbxReleationQueue.Items[i] as ItemBind;

                //        QueueItem qi = new QueueItem();

                //        qi.QueueId = ib.Value;
                //        qi.QueueName = ib.Name;

                //        _queueQuickDesign.QueueItems.Add(qi);
                //    }
                //}
                

                _isOk = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmQueueQuickDesign_Load(object sender, EventArgs e)
        {
            try
            {
                ceBackColor.Color = _queueQuickDesign.BackColor;
                ceForeColor.Color = _queueQuickDesign.ForeColor;
                ceCallColor.Color = _queueQuickDesign.CallColor;

                float fontSize = 0;
                FontStyle fs = FontStyle.Regular;

                try
                {
                    fontSize = _queueQuickDesign.ModuleFontSize;
                }
                catch { }
                if (fontSize <= 0) fontSize = this.Font.Size;

                if (_queueQuickDesign.ModuleFontBold) fs = fs | FontStyle.Bold;
                if (_queueQuickDesign.ModuleFontItalic) fs = fs | FontStyle.Italic;

                Font font = new Font(_queueQuickDesign.ModuleFontName, fontSize, fs); 
                feModuleFont.Value = font;


                fontSize = 0;
                fs = FontStyle.Regular;

                try
                {
                    fontSize = _queueQuickDesign.WaitFontSize;
                }
                catch { }
                if (fontSize <= 0) fontSize = this.Font.Size;

                
                if (_queueQuickDesign.WaitFontBold) fs = fs | FontStyle.Bold;
                if (_queueQuickDesign.WaitFontItalic) fs = fs | FontStyle.Italic;

                Font wFont = new Font(_queueQuickDesign.WaitFontName, fontSize, fs); 
                feWaitFont.Value = wFont;


                //chkUseRoomReleation.Checked = _queueQuickDesign.UseRoomQueueReleation;

                //cbxReleationQueue.DisplayMember = "Name";
                //cbxReleationQueue.ValueMember = "Value";

                //cbxReleationQueue.Items.Clear();

                //DataTable dtQueueData = _qm.GetQueueInfoByDeptId(_departmentId);

                //foreach (DataRow drQueue in dtQueueData.Rows)
                //{
                //    QueueData queInfo = new QueueData();
                //    queInfo.BindRowData(drQueue);

                //    ItemBind ib = new ItemBind();

                //    ib.Name = queInfo.队列名称;
                //    ib.Value = queInfo.队列ID;
                //    ib.Tag = queInfo;

                //    int itemIndex = cbxReleationQueue.Items.Add(ib);
                     

                //    if (_queueQuickDesign.QueueItems.Count > 0)
                //    {
                //        int index = _queueQuickDesign.QueueItems.FindIndex(T => T.QueueId == queInfo.队列ID);

                //        if (index >= 0)
                //        {
                //            cbxReleationQueue.SetItemChecked(itemIndex, true);
                //        }
                //    }
                     
                //} 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

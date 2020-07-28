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

namespace zlMedimgSystem.CTL.QueueState
{
    public partial class frmQueueStateModuleDesign : Form
    {
        private bool _isOk = false;
        private string _departmentId = "";
        private QueueStateModuleDesign _queueStateDesign = null;
        private QueueModel _qm = null;
        public frmQueueStateModuleDesign()
        {
            InitializeComponent();
        }

        public bool ShowQueueStateDesign(QueueModel qm, string departmentId, QueueStateModuleDesign queueStateDesign, IWin32Window owner)
        {
            _isOk = false;
            _departmentId = departmentId;
            _queueStateDesign = queueStateDesign;
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
                _queueStateDesign.BackColor = ceBackColor.Color;
                _queueStateDesign.ForeColor = ceForeColor.Color;
                _queueStateDesign.BusyColor = ceBusyColor.Color;
                _queueStateDesign.WorkColor = ceWorkColor.Color;
                _queueStateDesign.FreeColor = ceFreeColor.Color;
                _queueStateDesign.DefaultBusyCount = Convert.ToInt32(txtDefaultBusyCount.Text);

                _queueStateDesign.FontName = feFontStyle.Value.Name;
                _queueStateDesign.FontSize = feFontStyle.Value.Size;
                _queueStateDesign.FontBold = feFontStyle.Value.Bold;
                _queueStateDesign.FontItalic = feFontStyle.Value.Italic;

                _queueStateDesign.FixRow = Convert.ToInt32(txtFixRow.Text);
                _queueStateDesign.FixColumn = Convert.ToInt32(txtFixColumn.Text);

                _queueStateDesign.UseRoomQueueReleation = chkUseRoomReleation.Checked;

                _queueStateDesign.QueueItems.Clear();
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Checked)
                    {
                        ListViewItem lvi = listView1.Items[i];

                        QueueData queInfo = lvi.Tag as QueueData;

                        QueueItem qi = new QueueItem();

                        qi.QueueId = queInfo.队列ID;
                        qi.QueueName = queInfo.队列名称;
                        qi.BusyCount = Convert.ToInt32(lvi.SubItems[1].Text);

                        _queueStateDesign.QueueItems.Add(qi);
                    }

                }

                _isOk = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void InitQueueList()
        {
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "队列名称";
            columnHeader.Name = "队列名称";
            columnHeader.Width = 120;
            listView1.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "繁忙人数";
            columnHeader.Name = "繁忙人数";
            columnHeader.Width = 100;
            listView1.Columns.Add(columnHeader);

            listView1.View = View.Details;
        }
        private void frmQueueStateModuleDesign_Load(object sender, EventArgs e)
        {
            try
            {
                InitQueueList();

                ceBackColor.Color = _queueStateDesign.BackColor;
                ceForeColor.Color = _queueStateDesign.ForeColor;
                ceBusyColor.Color = _queueStateDesign.BusyColor;
                ceWorkColor.Color = _queueStateDesign.WorkColor;
                ceFreeColor.Color = _queueStateDesign.FreeColor;

                txtFixRow.Text = Convert.ToString(_queueStateDesign.FixRow);
                txtFixColumn.Text = Convert.ToString(_queueStateDesign.FixColumn);

                txtDefaultBusyCount.Text = Convert.ToString(_queueStateDesign.DefaultBusyCount);

                float fontSize = 0;
                FontStyle fs = FontStyle.Regular;

                try
                {
                    fontSize = _queueStateDesign.FontSize;
                }
                catch { }
                if (fontSize <= 0) fontSize = this.Font.Size;

                if (_queueStateDesign.FontBold) fs = fs | FontStyle.Bold;
                if (_queueStateDesign.FontItalic) fs = fs | FontStyle.Italic;

                Font font = new Font(_queueStateDesign.FontName, fontSize, fs); 
                feFontStyle.Value = font;

                chkUseRoomReleation.Checked = _queueStateDesign.UseRoomQueueReleation;

                listView1.Items.Clear();

                DataTable dtQueueData = _qm.GetQueueInfoByDeptId(_departmentId);

                foreach (DataRow drQueue in dtQueueData.Rows)
                {
                    QueueData queInfo = new QueueData();
                    queInfo.BindRowData(drQueue);

                    ListViewItem lvi = new ListViewItem(new string[] { queInfo.队列名称, "0" });

                    if (_queueStateDesign.QueueItems.Count > 0)
                    {
                        int index = _queueStateDesign.QueueItems.FindIndex(T => T.QueueId == queInfo.队列ID);

                        if (index >= 0)
                        {
                            QueueItem qi = _queueStateDesign.QueueItems[index];

                            lvi.SubItems[1].Text =Convert.ToString(qi.BusyCount);
                            lvi.Checked = true;
                        }
                    }

                    lvi.Name = queInfo.队列名称;

                    lvi.Tag = queInfo;

                    listView1.Items.Add(lvi);
                }

                listView1.View = View.Details;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0) return;

                txtQueueBusyCount.Text = listView1.SelectedItems[0].SubItems[1].Text;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void txtQueueBusyCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0) return;

                listView1.SelectedItems[0].SubItems[1].Text = txtQueueBusyCount.Text;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
 
    }
}

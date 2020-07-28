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

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmReleationRooms : Form
    {
        private bool _isOk = false;
        private QueueData _queueData = null;
        private QueueModel _qm = null;
        public frmReleationRooms()
        {
            InitializeComponent();
        }


        public bool ShowReleationRoom(QueueModel qm, QueueData queueData, IWin32Window owner)
        {
            _isOk = false;
            _qm = qm;
            _queueData = queueData;

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
                _queueData.包含房间.房间明细.Clear();

                for(int i = 0; i <= checkedListBox1.Items.Count -1; i ++)
                {
                    if (checkedListBox1.GetItemChecked(i) == false) continue;

                    JQueueRoomItem roomItem = new JQueueRoomItem();

                    ItemBind ib = checkedListBox1.Items[i] as ItemBind;
                    roomItem.房间ID = ib.Value;
                    roomItem.房间名称 = ib.Name;

                    _queueData.包含房间.房间明细.Add(roomItem);
                }

                _qm.UpdateQueueRooms(_queueData);

                _isOk = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmReleationRooms_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtRooms = _qm.GetDeptRooms(_queueData.科室ID);

                checkedListBox1.DisplayMember = "Name";
                checkedListBox1.ValueMember = "Value";

                foreach (DataRow dr in dtRooms.Rows)
                {
                    ItemBind ib = new ItemBind();

                    ib.Name = dr["房间名称"].ToString();
                    ib.Value = dr["房间ID"].ToString();

                    if (_queueData.包含房间.房间明细.FindIndex(T=>T.房间ID == dr["房间ID"].ToString()) >= 0)
                    {
                        checkedListBox1.Items.Add(ib, true);
                    }
                    else
                    {
                        checkedListBox1.Items.Add(ib);
                    }                    
                }


            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butSelAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i <= checkedListBox1.Items.Count - 1; i++)
                {
                    checkedListBox1.SetItemChecked(i, true); 
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butClearSel_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i <= checkedListBox1.Items.Count - 1; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

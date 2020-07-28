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

namespace zlMedimgSystem.CTL.QueueManager
{
    public partial class frmResetQueue : Form
    {

        private bool _isOk = false;
        private QueueModel _qm = null;
        private LineUpData _lineupInfo = null;
        public frmResetQueue()
        {
            InitializeComponent();
        }

        public bool ShowResetQueue(QueueModel qm, LineUpData lineupInfo, IWin32Window owner)
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


        /// <summary>
        /// 初始化队列名称
        /// </summary>
        /// <param name="departmentId"></param>
        private void InitQueueName(string departmentId, string applyId)
        {
            cbxQueueName.Items.Clear();

            if (string.IsNullOrEmpty(departmentId)) return;

            DataTable dtQueues = _qm.GetQueueInfoByDeptId(departmentId);

            cbxQueueName.DisplayMember = "Name";
            cbxQueueName.ValueMember = "Value";

            DataTable dtRooms = _qm.GetApplyRoomId(applyId);


            foreach (DataRow dr in dtQueues.Rows)
            {
                QueueData queueData = new QueueData();
                queueData.BindRowData(dr);


                //如果队列不包含房间信息，则不进行加载
                if (queueData.包含房间.房间明细.Count <= 0) continue;

                if (dtRooms.Rows.Count > 0)
                {
                    //需要判断队列是否包含了对应的房间
                    bool hasRoom = false;

                    foreach (DataRow drRoom in dtRooms.Rows)
                    {
                        if (queueData.包含房间.房间明细.FindIndex(T => T.房间ID == drRoom["房间ID"].ToString()) >= 0)
                        {
                            hasRoom = true;
                            break;
                        }
                    }

                    if (hasRoom == false) continue;
                }


                ItemBind ib = new ItemBind();

                ib.Name = queueData.队列名称;
                ib.Value = queueData.队列ID;

                ib.Tag = queueData;

                cbxQueueName.Items.Add(ib);
            }

            if (cbxQueueName.Items.Count <= 0) return;

            //默认定位到队列人数最少且只有一个房间的队列
            if (cbxQueueName.Items.Count <= 1)
            {
                cbxQueueName.SelectedIndex = 0;
            }
            else
            {
                int roomCount = 999999;
                string minQueue = "";
                foreach (ItemBind ib in cbxQueueName.Items)
                {
                    QueueData queData = ib.Tag as QueueData;

                    if (queData.包含房间.房间明细.Count == 1)
                    {
                        int curCount = _qm.GetLineupCount(queData.队列ID, dtpIntoQueue.Value);
                        if (curCount < roomCount)
                        {
                            roomCount = curCount;
                            minQueue = queData.队列名称;
                        }
                    }
                }

                if (string.IsNullOrEmpty(minQueue) == false)
                {
                    cbxQueueName.Text = minQueue;
                }
            }
        }


        private void frmResetQueue_Load(object sender, EventArgs e)
        {
            try
            {
                if (_lineupInfo == null) return;

                dtpIntoQueue.Value = DateTime.Now.Date;

                txtName.Text = _lineupInfo.患者姓名;
                txtSex.Text = _lineupInfo.附加信息.性别;
                txtAge.Text = _lineupInfo.附加信息.年龄;
                txtItem.Text = _lineupInfo.附加信息.检查项目;

                InitQueueName(_lineupInfo.科室ID, _lineupInfo.申请ID);


            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private int GetQueueNo(string queueID, DateTime queueDate)
        {
            string queueMaxNo = _qm.GetMaxQueueNo(queueID, queueDate);

            int queueNo = 0;
            if (string.IsNullOrEmpty(queueMaxNo) == false) queueNo = Convert.ToInt32(queueMaxNo);

            return queueNo + 1;
        }

        private void cbxQueueName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateQueueNo();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void UpdateQueueNo()
        {
            //更新排队号码
            QueueData queueData = (cbxQueueName.SelectedItem as ItemBind).Tag as QueueData;

            int queueNo = GetQueueNo(queueData.队列ID, dtpIntoQueue.Value);
            txtQueueNo.Text = queueData.队列信息.号码前缀 + queueNo;
            txtQueueNo.Tag = queueNo;
        }
        private void dtpIntoQueue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxQueueName.SelectedItem == null) return;

                UpdateQueueNo();
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
                if (cbxQueueName.Items.Count <= 0)
                {
                    MessageBox.Show("尚无队列信息，不能入队。", "提示");
                    return;
                }

                if (txtQueueNo.Tag == null)
                {
                    MessageBox.Show("尚未产生排队号码，不能入队。", "提示");
                    return;
                }

                QueueData queueData = (cbxQueueName.SelectedItem as ItemBind).Tag as QueueData;

 
                DateTime serverDate = _qm.GetServerDate();

                string orderNum = serverDate.DayOfYear + "" + serverDate.TimeOfDay.Ticks;
                

                if (_qm.HasNo(Convert.ToInt32(txtQueueNo.Tag), queueData.队列ID, dtpIntoQueue.Value))
                {
                    MessageBox.Show("排队号码 [" + txtQueueNo.Text + "] 存在重复,需重新产生。", "提示");
                                       
                    int queueNo = GetQueueNo(cbxQueueName.Text, dtpIntoQueue.Value);
                    txtQueueNo.Text = queueData.队列信息.号码前缀 + queueNo;
                    txtQueueNo.Tag = queueNo;

                    return;
                }
                 
                _lineupInfo.队列ID = queueData.队列ID;
                _lineupInfo.队列名称 = queueData.队列名称;

                _lineupInfo.排队日期 = dtpIntoQueue.Value;
                _lineupInfo.排队号码 = Convert.ToString(txtQueueNo.Tag).PadLeft(queueData.队列信息.号码长度, '0');
                _lineupInfo.号码前缀 = queueData.队列信息.号码前缀;

                _lineupInfo.排队状态 = LineUpState.qsQueueing;

                _lineupInfo.附加信息.备注 = cbxMemo.Text;
                
                _lineupInfo.排队序号 = orderNum.ToString();


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
    }
}

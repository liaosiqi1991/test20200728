using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.QueueManager
{
    public partial class frmIntoQueue : Form
    {
        private QueueModel _qm = null;

        private string _applyId = ""; 
        private ApplyData _applyInfo = null;

        private LineUpData _linuupData = null;

        private IStationInfo _stationInfo = null;

        public frmIntoQueue()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示入队
        /// </summary>
        /// <param name="applyId"></param>
        /// <param name="patientId"></param>
        /// <param name="owner"></param>
        /// <returns>排队号码</returns>
        public LineUpData ShowIntoQueue(QueueModel qm, IStationInfo stationInfo, string applyId, IWin32Window owner)
        {
            _qm = qm;
            _applyId = applyId; 

            _stationInfo = stationInfo;

            this.ShowDialog(owner);
            
            return _linuupData;
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

                    foreach(DataRow drRoom in dtRooms.Rows)
                    {
                        if (queueData.包含房间.房间明细.FindIndex(T=>T.房间ID == drRoom["房间ID"].ToString())>=0)
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
                foreach(ItemBind ib in cbxQueueName.Items)
                {
                    QueueData queData = ib.Tag as QueueData;

                    if (queData.包含房间.房间明细.Count == 1)
                    {
                        int curCount = _qm.GetLineupCount(queData.队列ID, dtpIntoQueue.Value);
                        if (curCount < roomCount )
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

        /// <summary>
        /// 根据队列名称获取排队号
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        private int GetQueueNo(string queueID, DateTime queueDate)
        {
            string queueMaxNo = _qm.GetMaxQueueNo(queueID, queueDate);

            int queueNo = 0;
            if (string.IsNullOrEmpty(queueMaxNo) == false) queueNo = Convert.ToInt32(queueMaxNo);
             
            return queueNo + 1;
        }

        private string _departmentName = "";
        private void frmIntoQueue_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_applyId)) return;
                                
                _applyInfo = _qm.GetApplyByID(_applyId);
   
                InitQueueName(_applyInfo.执行科室ID, _applyId);

                _departmentName = _qm.GetDepartmentName(_applyInfo.执行科室ID);

                txtName.Text = _applyInfo.申请信息.姓名;
                txtSex.Text = _applyInfo.申请信息.性别;
                txtAge.Text = _applyInfo.申请信息.年龄;

                dtpIntoQueue.Value = DateTime.Now.Date;

                txtItem.Text =_qm.GetExamItemName(_applyInfo.申请信息.申请项目ID);

                if (cbxQueueName.SelectedItem != null)
                {
                    //产生排队号码
                    QueueData queueData = (cbxQueueName.SelectedItem as ItemBind).Tag as QueueData;

                    int queueNo = GetQueueNo(queueData.队列ID, dtpIntoQueue.Value);
                    txtQueueNo.Text = queueData.队列信息.号码前缀 + queueNo;
                    txtQueueNo.Tag = queueNo;
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

                LineUpData lineupInfo = _qm.HasApply(_applyId, queueData.科室ID);
                //判断本科室下是否已进行排队
                if (lineupInfo != null)
                {
                    MessageBox.Show("当前患者检查已在队列 [" + lineupInfo.队列名称 + "] 中存在，本科室内不能重复排队。", "提示");
                    return;
                }

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


                _linuupData = new LineUpData();

                _linuupData.排队ID = SqlHelper.GetNumGuid();

                _linuupData.队列ID = queueData.队列ID;
                _linuupData.队列名称 = queueData.队列名称;


                _linuupData.申请ID = _applyId;
                _linuupData.患者ID = _applyInfo.患者ID;
                _linuupData.患者姓名 = _applyInfo.申请信息.姓名;

                _linuupData.排队日期 = dtpIntoQueue.Value;
                _linuupData.排队号码 = Convert.ToString(txtQueueNo.Tag).PadLeft(queueData.队列信息.号码长度, '0');
                _linuupData.号码前缀 = queueData.队列信息.号码前缀;

                _linuupData.排队状态 = LineUpState.qsQueueing;

                _linuupData.科室ID = queueData.科室ID;
                _linuupData.科室名称 = _departmentName;
                _linuupData.附加信息.备注 = cbxMemo.Text;
                _linuupData.附加信息.性别 = _applyInfo.申请信息.性别;
                _linuupData.附加信息.年龄 = _applyInfo.申请信息.年龄;
                _linuupData.附加信息.检查项目 = _applyInfo.申请信息.检查项目.项目名称; 


                _linuupData.排队序号 = orderNum.ToString();


                _linuupData.附加信息.CopyBasePro(_linuupData);

                _qm.NewLinuUp(_linuupData);



                this.Close();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
                _linuupData = null;
            }
        }

        private void cbxQueueName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //更新排队号码
                QueueData queueData = (cbxQueueName.SelectedItem as ItemBind).Tag as QueueData;

                int queueNo = GetQueueNo(queueData.队列ID, dtpIntoQueue.Value);
                txtQueueNo.Text = queueData.队列信息.号码前缀 + queueNo;
                txtQueueNo.Tag = queueNo;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

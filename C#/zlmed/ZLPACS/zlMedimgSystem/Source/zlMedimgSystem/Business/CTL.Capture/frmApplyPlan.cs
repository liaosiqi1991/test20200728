using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Capture
{
    public partial class frmApplyPlan : Form
    {
        private bool _isOk = false;

        private IDBQuery _dbHelper = null;
        private IStationInfo _stationInfo = null;
        private DataTable _dtExecuteInfo = null;
        private StudyMediaSerialModel _studyMediaSerialModel = null;

        public frmApplyPlan()
        {
            InitializeComponent();
        }

        public bool ShowPlan(DataTable dtExecuteInfo, IDBQuery dbHelper, IStationInfo stationInfo, IWin32Window owner)
        {
            _isOk = false;

            _dbHelper = dbHelper;
            _stationInfo = stationInfo;
            _dtExecuteInfo = dtExecuteInfo;

            _studyMediaSerialModel = new StudyMediaSerialModel(dbHelper);

            this.ShowDialog(owner);

            return _isOk;
        }

        private void frmApplyPlan_Load(object sender, EventArgs e)
        {
            try
            {
                InitExecuteList();

                BindExecutePlan();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 绑定执行安排数据
        /// </summary>
        private void BindExecutePlan()
        {
            foreach(DataRow drExecute in _dtExecuteInfo.Rows)
            {
                JStudyExecute exeInfo = JsonHelper.DeserializeObject<JStudyExecute>(drExecute["执行信息"].ToString());

                if (exeInfo.执行状态 != StudyExecuteState.sesWaiting) continue;

                ListViewItem lvi = new ListViewItem(new string[] { drExecute["部位名称"].ToString(),
                                                                    drExecute["房间名称"].ToString(),
                                                                    drExecute["设备名称"].ToString(),
                                                                    exeInfo.报到人,
                                                                    Convert.ToString(exeInfo.报到时间)});
                lvi.Name = drExecute["执行ID"].ToString();
                lvi.Tag = exeInfo;

                listView1.Items.Add(lvi);
            }

            listView1.View = View.Details;
        }

        private void InitExecuteList()
        {
            listView1.Clear();
            listView1.Columns.Clear();

            ColumnHeader columnDefault = new ColumnHeader();
            columnDefault = new ColumnHeader();
            columnDefault.Text = "部位名称";
            columnDefault.Name = "部位名称";
            columnDefault.Width = 120;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "房间名称";
            columnDefault.Name = "房间名称";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "设备名称";
            columnDefault.Name = "设备名称";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "报到人";
            columnDefault.Name = "报到人";
            columnDefault.Width = 100;
            listView1.Columns.Add(columnDefault);

            columnDefault = new ColumnHeader();
            columnDefault.Text = "报到时间";
            columnDefault.Name = "报到时间";
            columnDefault.Width = 140;
            listView1.Columns.Add(columnDefault);
             
            listView1.View = View.Details;
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
                if (listView1.CheckedItems.Count <= 0)
                {
                    MessageBox.Show("请勾选需要调整的项目部位。", "提示");
                    return;
                }

                DialogResult dr = MessageBox.Show("确认安排到本房间设备执行吗？", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;

                _studyMediaSerialModel.TransactionBegin();
                try
                {
                    foreach (ListViewItem lvi in listView1.CheckedItems)
                    {
                        JStudyExecute exeInfo = lvi.Tag as JStudyExecute;

                        exeInfo.房间ID = _stationInfo.RoomId;
                        exeInfo.设备ID = _stationInfo.DeviceId;

                        _studyMediaSerialModel.UpdateExecutePlan(exeInfo);
                    }

                    _studyMediaSerialModel.TransactionCommit();
                }
                catch(Exception ex)
                {
                    _studyMediaSerialModel.TransactionRollback();
                    throw ex;
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

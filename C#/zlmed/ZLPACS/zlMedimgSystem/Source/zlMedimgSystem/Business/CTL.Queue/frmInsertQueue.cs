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
    public partial class frmInsertQueue : Form
    {
        private bool _isOk = false;
        private QueueModel _qm = null;
        private LineUpData _lineupInfo = null;
        public frmInsertQueue()
        {
            InitializeComponent();
        }

        public bool ShowInsertQueue(QueueModel qm, LineUpData lineupInfo, IWin32Window owner)
        {
            _isOk = false;

            _qm = qm;
            _lineupInfo = lineupInfo;

            this.ShowDialog(owner);

            return _isOk;
        }

        private void InitQueueList()
        {
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "排队号码";
            columnHeader.Name = "排队号码";
            columnHeader.Width = 80;
            listQueue.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "患者姓名";
            columnHeader.Name = "患者姓名";
            columnHeader.Width = 120;
            listQueue.Columns.Add(columnHeader);


            columnHeader = new ColumnHeader();
            columnHeader.Text = "状态";
            columnHeader.Name = "状态";
            columnHeader.Width = 60;
            listQueue.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Text = "备注";
            columnHeader.Name = "备注";
            columnHeader.Width = 200;
            listQueue.Columns.Add(columnHeader);

            listQueue.View = View.Details;
        }

        private void BindLinuupInfo(string queueId)
        {
            listQueue.Items.Clear();

            DataTable dtLineupInfos = _qm.GetLineupInfos(queueId, false);

            if (dtLineupInfos.Rows.Count <= 0) return;

            ListViewItem lviFirst = new ListViewItem("此处插入");
            lviFirst.ImageIndex = 0;
            lviFirst.Tag = null;
            listQueue.Items.Add(lviFirst);

            foreach (DataRow dr in dtLineupInfos.Rows)
            {
                LineUpData lineupData = new LineUpData();
                lineupData.BindRowData(dr);


                ListViewItem lvi = new ListViewItem(new string[] { lineupData.号码前缀 + lineupData.排队号码,
                                                                    lineupData.患者姓名,
                                                                    QueueHelper.GetLineupStateCaption(lineupData.排队状态),
                                                                    lineupData.附加信息.备注}, -1);
                lvi.BackColor = this.BackColor;
                lvi.Tag = lineupData;

                listQueue.Items.Add(lvi);
                

                ListViewItem lviNext = new ListViewItem("此处插入");
                lviNext.ImageIndex = 0;
                lviNext.Tag = null;
                listQueue.Items.Add(lviNext);

                if (lineupData.排队ID == _lineupInfo.排队ID)
                {
                    if (lvi.Index - 1 >= 0)
                    {
                        listQueue.Items[lvi.Index - 1].ImageIndex = 1;
                        listQueue.Items[lvi.Index - 1].Text = "禁止插入";
                    }

                    lviNext.ImageIndex = 1;
                    lviNext.Text = "禁止插入";
                }
            }
                        

            listQueue.View = View.Details;
        }


        private void frmInsertQueue_Load(object sender, EventArgs e)
        {
            try
            {
                InitQueueList();

                if (_lineupInfo == null) return;

                label2.Text = "待插队信息：" + "  (" + _lineupInfo.号码前缀 + _lineupInfo.排队号码 + ")" + _lineupInfo.患者姓名 + "    " + _lineupInfo.附加信息.备注;

                BindLinuupInfo(_lineupInfo.队列ID); 
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

        private void listQueue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listQueue.SelectedItems.Count <= 0) return;

                if (listQueue.SelectedItems[0].Tag != null)
                {
                    listQueue.SelectedItems[0].Selected = false;
                }
                else
                {
                    if (listQueue.SelectedItems[0].Text == "禁止插入")
                    {
                        listQueue.SelectedItems[0].Selected = false;
                    }
                }
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
                if (_lineupInfo == null) return;

                if (listQueue.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("请选择需要插入的位置。", "提示");
                    return;
                }

                if (listQueue.SelectedItems[0].Text == "禁止插入" || listQueue.SelectedItems[0].Tag != null)
                {
                    MessageBox.Show("插入位置无效，请重新选择。", "提示");
                    return;
                }

                int index = listQueue.SelectedItems[0].Index;

                string firstOrder = "";
                string endOrder = "";

                if (index - 1 >= 0)
                {
                    LineUpData lineFirst = listQueue.Items[index - 1].Tag as LineUpData;
                    firstOrder = lineFirst.排队序号;
                }

                if (index + 1 < listQueue.Items.Count)
                {
                    LineUpData lineEnd = listQueue.Items[index + 1].Tag as LineUpData;
                    endOrder = lineEnd.排队序号;
                }

                if (string.IsNullOrEmpty(firstOrder) && string.IsNullOrEmpty(endOrder))
                {
                    MessageBox.Show("队列排队序号无效，不允许插入。", "提示");
                    return;
                }

                _lineupInfo.附加信息.备注 = comboBox1.Text;
                _lineupInfo.排队序号 = GetNewOrder(firstOrder, endOrder);

                _qm.UpdateLineupInfo(_lineupInfo);

                _isOk = true;

                this.Close();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 获取新的排队序号
        /// </summary>
        /// <param name="firstOrder"></param>
        /// <param name="endOrder"></param>
        /// <returns></returns>
        private string GetNewOrder(string firstOrder, string endOrder)
        {
            string newOrder = "";

            double fOrder = 0;
            string prefix = "";

            if (string.IsNullOrEmpty(firstOrder) == false)
            {
                if (firstOrder.IndexOf('_') >= 0)
                {
                    fOrder = Convert.ToDouble(firstOrder.Split('_')[1]);
                    prefix = firstOrder.Split('_')[0];
                }
                else
                {
                    fOrder = Convert.ToDouble(firstOrder);
                }
            }


            double eOrder = 0;

            if (string.IsNullOrEmpty(endOrder) == false)
            {
                if (endOrder.IndexOf('_') >= 0)
                {
                    eOrder = Convert.ToDouble(endOrder.Split('_')[1]);
                    if (string.IsNullOrEmpty(prefix)) prefix = endOrder.Split('_')[0];
                }
                else
                {
                    eOrder = Convert.ToDouble(endOrder);
                }
            }

            if (fOrder == 0) fOrder = eOrder - 10;
            if (eOrder == 0) eOrder = fOrder + 10;


            double x = eOrder - fOrder;
            Int64 y = 0;

            string tmp = x.ToString();
            if (tmp.IndexOf('.') >= 0)
            {
                y = Convert.ToInt32(tmp.Split('.')[1]);
            }
            else
            {
                y = Convert.ToInt32(tmp);
            }

            double result = 0;
            
            if (y == 5 || y == 3)
            {
                int div = 10;

                if (y == 3) div = 6;

                result = fOrder + x / 2 + x / div;
            }
            else
            {
                result = fOrder + x / 2;
            }

            newOrder = prefix + result;



            return newOrder;
        }
    }
}

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
using zlMedimgSystem.Design;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.QueueShow
{
    public partial class frmQueueShowDesign : Form
    {
        private bool _isOk = false;
        private string _departmentId;
        private QueueShowModuleDesign _queueShowDesign = null;
        private QueueModel _qm = null;
        public frmQueueShowDesign()
        {
            InitializeComponent();
        }

        public bool ShowQueueShowDesign(QueueModel queueModel, string departmentId, QueueShowModuleDesign queueShowDesign, IWin32Window owner)
        {
            _isOk = false;
            _departmentId = departmentId;
            _qm = queueModel;

            _queueShowDesign = queueShowDesign;

            this.ShowDialog(owner);

            return _isOk;
        }

        private void frmQueueShowDesign_Load(object sender, EventArgs e)
        {
            try
            {
                txtImgName.Text = _queueShowDesign.BackgroundImage;
                ceBackColor.Color = _queueShowDesign.BackColor;
                ceForeColor.Color = _queueShowDesign.ForeColor;

                chkShowMemo.Checked = _queueShowDesign.IsShowMemo;
                chkShowLastCall.Checked = _queueShowDesign.IsShowLastCall;
                chkCallIcon.Checked = _queueShowDesign.IsShowCallIcon;
                chkQueueIcon.Checked = _queueShowDesign.IsShowQueueIcon;
                 
                txtWaitCount.Text = _queueShowDesign.WaitCount.ToString();


                float fontSize = 0;
                FontStyle fs = FontStyle.Regular;

                try
                {
                    fontSize = _queueShowDesign.HeadFontSize;
                }
                catch { }
                if (fontSize <= 0) fontSize = this.Font.Size;
                
                if (_queueShowDesign.HeadBold) fs = fs | FontStyle.Bold;
                if (_queueShowDesign.HeadItalic) fs = fs | FontStyle.Italic;
                                
                Font hfont = new Font(_queueShowDesign.HeadFontName, fontSize, fs); 
                feHeadFont.Value = hfont;



                fontSize = 0;
                fs = FontStyle.Regular;

                try
                {
                    fontSize = _queueShowDesign.FontSize;
                }
                catch { }
                if (fontSize <= 0) fontSize = this.Font.Size;

                if (_queueShowDesign.IsBold) fs = fs | FontStyle.Bold;
                if (_queueShowDesign.IsItalic) fs = fs | FontStyle.Italic;

                Font qfont = new Font(_queueShowDesign.FontName, fontSize, fs); 
                feQueueFont.Value = qfont;

                txtC1Width.Text = _queueShowDesign.Column1Width.ToString();
                txtC2Width.Text = _queueShowDesign.Column2Width.ToString();
                txtC3Width.Text = _queueShowDesign.Column3Width.ToString();


                cbxReleationQueue.Items.Clear();

                cbxReleationQueue.DisplayMember = "Name";
                cbxReleationQueue.ValueMember = "Value";

                DataTable dtQueueData = _qm.GetQueueInfoByDeptId(_departmentId);

                foreach (DataRow drQueue in dtQueueData.Rows)
                {
                    ItemBind ib = new ItemBind();

                    ib.Name = drQueue["队列名称"].ToString();
                    ib.Value = drQueue["队列ID"].ToString();

                    int itemIndex = cbxReleationQueue.Items.Add(ib);

                    if (_queueShowDesign.ReleationQueueItems.Count > 0)
                    {
                        int selIndex = _queueShowDesign.ReleationQueueItems.FindIndex(T => T.QueueId == ib.Value);
                        if (selIndex >= 0) cbxReleationQueue.SetItemChecked(itemIndex, true);
                    }
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
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                _queueShowDesign.BackgroundImage = txtImgName.Text;

                _queueShowDesign.BackColor = ceBackColor.Color;
                _queueShowDesign.ForeColor = ceForeColor.Color;

                _queueShowDesign.HeadFontName = feHeadFont.Value.Name;
                _queueShowDesign.HeadFontSize = feHeadFont.Value.Size;
                _queueShowDesign.HeadBold = feHeadFont.Value.Bold;
                _queueShowDesign.HeadItalic = feHeadFont.Value.Italic;


                _queueShowDesign.FontName = feQueueFont.Value.Name;
                _queueShowDesign.FontSize = feQueueFont.Value.Size;
                _queueShowDesign.IsBold = feQueueFont.Value.Bold;
                _queueShowDesign.IsItalic = feQueueFont.Value.Italic;

                _queueShowDesign.WaitCount = Convert.ToInt32(txtWaitCount.Text);

                _queueShowDesign.Column1Width = Convert.ToInt32(txtC1Width.Text);
                _queueShowDesign.Column2Width = Convert.ToInt32(txtC2Width.Text);
                _queueShowDesign.Column3Width = Convert.ToInt32(txtC3Width.Text);

                _queueShowDesign.IsShowMemo = chkShowMemo.Checked;
                _queueShowDesign.IsShowLastCall = chkShowLastCall.Checked;
                _queueShowDesign.IsShowCallIcon = chkCallIcon.Checked;
                _queueShowDesign.IsShowQueueIcon = chkQueueIcon.Checked;


                _queueShowDesign.ReleationQueueItems.Clear();
                for (int i = 0; i < cbxReleationQueue.Items.Count - 1; i++)
                {
                    if (cbxReleationQueue.GetItemChecked(i))
                    {
                        ItemBind ib = cbxReleationQueue.Items[i] as ItemBind;

                        QueueItem qi = new QueueItem();

                        qi.QueueId = ib.Value;
                        qi.QueueName = ib.Name;

                        _queueShowDesign.ReleationQueueItems.Add(qi);
                    }

                }

                _queueShowDesign.UseRoomQueueReleation = chkUseRoomReleation.Checked;

                _isOk = true;

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butLoadImg_Click(object sender, EventArgs e)
        {
            try
            {
                txtImgName.Text = BigImgResource.ShowImgResourcesSelector(this);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

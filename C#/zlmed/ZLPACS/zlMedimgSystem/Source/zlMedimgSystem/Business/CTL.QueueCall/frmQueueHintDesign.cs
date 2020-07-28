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

namespace zlMedimgSystem.CTL.QueueHint
{
    public partial class frmQueueHintDesign : Form
    {
        private bool _isOk = false;
        private string _departmentId;
        private QueueHintModuleDesign _queueCallDesign = null;
        private QueueModel _qm = null;
        public frmQueueHintDesign()
        {
            InitializeComponent();
        }

        public bool ShowQueueCallDesign(QueueModel queueModel, string departmentId, QueueHintModuleDesign queueCallDesign, IWin32Window owner)
        {
            _isOk = false;

            _departmentId = departmentId;
            _qm = queueModel;
            _queueCallDesign = queueCallDesign;

            this.ShowDialog(owner);

            return _isOk;

        }

        private void frmQueueCallDesign_Load(object sender, EventArgs e)
        {
            try
            {
                txtImgName.Text = _queueCallDesign.BackgroundImage;
                chkShowTitle.Checked = _queueCallDesign.ShowHeader;
                txtTitle.Text = _queueCallDesign.HeadText;
                cbxHeadDockWay.SelectedIndex = (int)_queueCallDesign.HeadDockWay;
                ceHeadBkColor.Color  = _queueCallDesign.HeadBColor;
                ceHeadBkColor2.Color = _queueCallDesign.HeadBColor2;
                ceHeadForeColor.Color = _queueCallDesign.HeadFColor;

                ceTxtBkColor.Color = _queueCallDesign.TxtBColor;
                ceTxtBkColor2.Color = _queueCallDesign.TxtBColor2;
                ceTxtForeColor.Color = _queueCallDesign.TxtFColor;

                chkUseRoomReleation.Checked = _queueCallDesign.UserRoomReleationQueue;

                float fontSize = 0;
                FontStyle fs = FontStyle.Regular;

                try
                {
                    fontSize = _queueCallDesign.HeadFontSize;
                }
                catch { }
                if (fontSize <= 0) fontSize = this.Font.Size;

                if (_queueCallDesign.HeadFontBold) fs = fs | FontStyle.Bold;
                if (_queueCallDesign.HeadFontItalic) fs = fs | FontStyle.Italic;

                Font hfont = new Font(_queueCallDesign.HeadFontName, fontSize, fs);
                feHeadFont.Value = hfont;




                fontSize = 0;
                fs = FontStyle.Regular;

                try
                {
                    fontSize = _queueCallDesign.TxtFontSize;
                }
                catch { }
                if (fontSize <= 0) fontSize = this.Font.Size;

                if (_queueCallDesign.TxtFontBold) fs = fs | FontStyle.Bold;
                if (_queueCallDesign.TxtFontItalic) fs = fs | FontStyle.Italic;

                Font txtfont = new Font(_queueCallDesign.TxtFontName, fontSize, fs); 
                feTxtFont.Value = txtfont;



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

                    if (_queueCallDesign.QueueItems.Count > 0)
                    {
                        int selIndex = _queueCallDesign.QueueItems.FindIndex(T => T.QueueId == ib.Value);
                        if (selIndex >= 0) cbxReleationQueue.SetItemChecked(itemIndex, true);
                    }
                } 
            }
            catch(Exception ex)
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
                _queueCallDesign.BackgroundImage = txtImgName.Text;
                _queueCallDesign.ShowHeader = chkShowTitle.Checked;
                _queueCallDesign.HeadText = txtTitle.Text;
                _queueCallDesign.HeadDockWay = (HeadDockWay)cbxHeadDockWay.SelectedIndex;

                _queueCallDesign.HeadBColor = ceHeadBkColor.Color;
                _queueCallDesign.HeadBColor2 = ceHeadBkColor2.Color;
                _queueCallDesign.HeadFColor = ceHeadForeColor.Color;

                _queueCallDesign.HeadFontName = feHeadFont.Value.Name;
                _queueCallDesign.HeadFontSize = feHeadFont.Value.Size;
                _queueCallDesign.HeadFontBold = feHeadFont.Value.Bold;
                _queueCallDesign.HeadFontItalic = feHeadFont.Value.Italic;

                _queueCallDesign.TxtBColor = ceTxtBkColor.Color;
                _queueCallDesign.TxtBColor2 = ceTxtBkColor2.Color;
                _queueCallDesign.TxtFColor = ceTxtForeColor.Color;

                _queueCallDesign.TxtFontName = feTxtFont.Value.Name;
                _queueCallDesign.TxtFontSize = feTxtFont.Value.Size;
                _queueCallDesign.TxtFontBold = feTxtFont.Value.Bold;
                _queueCallDesign.TxtFontItalic = feTxtFont.Value.Italic;

                _queueCallDesign.QueueItems.Clear();
                for(int i = 0; i < cbxReleationQueue.Items.Count -1; i ++)
                {
                    if (cbxReleationQueue.GetItemChecked(i))
                    {
                        ItemBind ib = cbxReleationQueue.Items[i] as ItemBind;

                        QueueItem qi = new QueueItem();

                        qi.QueueId = ib.Value;
                        qi.QueueName = ib.Name;

                        _queueCallDesign.QueueItems.Add(qi);
                    }

                }

                _queueCallDesign.UserRoomReleationQueue = chkUseRoomReleation.Checked;

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

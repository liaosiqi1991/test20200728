using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BusinessBase
{
    public partial class frmImageView : Form
    {

        private IDBQuery _dbHelper = null; 

        private string _applyId = ""; 

        private StudyMediaSerialModel _studyMediaModel = null;

        private int _imgViewCount = 8;

        public frmImageView()
        {
            InitializeComponent();
        }

        public void ShowImgPreview(IDBQuery dbHelper, string applyId, IWin32Window owner)
        {
            _dbHelper = dbHelper; 
            _applyId = applyId; 

            _studyMediaModel = new StudyMediaSerialModel(dbHelper);

            this.ShowDialog(owner);
        }

         
        private List<TileImageInfo> _images = null;
        private void BindStudyMedia()
        {
            if (_images == null) _images = new List<TileImageInfo>();
            imageView1.Clear();

            if (string.IsNullOrEmpty(_applyId)) return;

            DataTable dtMedias = _studyMediaModel.GetApplyMedia(_applyId);

            if (dtMedias == null || dtMedias.Rows.Count <= 0) return;

            dtMedias.DefaultView.Sort = "序号 Desc";

            StudySerialData serialData = null;
            foreach (DataRowView dr in dtMedias.DefaultView)
            {
                StudyMediaData smd = new StudyMediaData();
                smd.BindRowData(dr.Row);

                if (serialData == null || serialData.序列ID.Equals(smd.序列ID) == false)
                {
                    serialData = _studyMediaModel.GetApplySerialInfoById(smd.序列ID);
                }

                TileImageInfo imgInfo = new TileImageInfo();
                imgInfo.MediaId = smd.媒体ID;
                imgInfo.SerialId = smd.序列ID;
                imgInfo.ApplyId = smd.申请ID;
                imgInfo.StorageId = serialData.存储ID;
                imgInfo.Order = smd.序号.ToString();
                imgInfo.IsReportImage = smd.媒体信息.是否报告图;
                imgInfo.IsKeyImage = smd.媒体信息.是否关键图;
                imgInfo.MediaName = smd.媒体信息.媒体名称;
                imgInfo.MediaType = smd.媒体信息.媒体类型;
                imgInfo.VPath = Convert.ToDateTime(serialData.序列信息.申请日期).ToString("yyyyMMdd") + @"\" + serialData.申请ID + @"\images";
                imgInfo.File = Dir.GetAppTempDir()
                                + @"\" + Convert.ToDateTime(serialData.序列信息.申请日期).ToString("yyyyMMdd")
                                + @"\" + serialData.申请ID
                                + @"\images"
                                + @"\" + smd.媒体信息.媒体名称;

                _images.Add(imgInfo);
            }

            imageView1.ViewCount = _imgViewCount;
            splitPage1.BindList<TileImageInfo>(_images, _imgViewCount);
        }

        private void frmImageView_Load(object sender, EventArgs e)
        {
            try
            {
                splitPage1.OnPageChanged += splitPage1_OnPageChanged;

                BindStudyMedia();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void splitPage1_OnPageChanged(int curPageIndex, List<object> range)
        {
            try
            {
                ImagePageView(range.ConvertAll(S => (TileImageInfo)S));
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ImagePageView(List<TileImageInfo> imgInfos)
        { 
            imageView1.Clear();
            if (imgInfos == null || imgInfos.Count <= 0)
            {
                throw new Exception("无需要加载的图像信息。");
            }

            try
            {

                FTPFileHelp ftp = null;

                imgInfos.Reverse();
                foreach (TileImageInfo imgInfo in imgInfos)
                {
                    string strErr = "";


                    if (File.Exists(imgInfo.File) == false)
                    {
                        if (ftp == null || Convert.ToString(ftp.Tag) != imgInfo.StorageId)
                        {
                            ftp = Transfer.GetFtp(imgInfo.VPath, imgInfo.StorageId, _dbHelper);
                            ftp.Tag = imgInfo.StorageId;
                        }

                        try
                        {

                            ftp.FileDownLoad(ftp.VPath + imgInfo.MediaName, imgInfo.File, true);
                        }
                        catch (Exception ex)
                        {
                            strErr = ex.Message;
                        }
                    }

                    if (File.Exists(imgInfo.File) == false)
                    {
                        imageView1.AddErrorImage("文件加载失败：" + strErr, imgInfo);
                    }
                    else
                    {
                        imageView1.AddImage(imgInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("图像加载失败", ex);
            }


        }

        private void imageView1_OnItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                if (e.Item == null) return;

                TileImageInfo imageInfo = e.Item.Tag as TileImageInfo;

                if (imageInfo == null)
                {
                    return;
                }

                if (imageInfo.MediaType != "图像")
                {
                    MessageBox.Show("音视频不能进行处理。", "提示");
                    return;
                }
                 
                imageEditor1.Image = ImageEx.LoadFile(imageInfo.File);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbRestore_Click(object sender, EventArgs e)
        {
            try
            {
                imageEditor1.Restore();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }


        }
 
        private void frmImageView_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                splitPage1.OnPageChanged -= splitPage1_OnPageChanged;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
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

        private void tsbCursor_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton tsb = sender as ToolStripButton;
                if (tsb == null) return;

                foreach(ToolStripItem tsi in toolStrip1.Items)
                {
                    ToolStripButton tsbItem = tsi as ToolStripButton;
                    if (tsbItem == null) continue;
                                        
                    tsbItem.Checked = false;
                }

                imageEditor1.OperType = (ImageOperType)(Convert.ToInt32(tsb.Tag));

                tsb.Checked = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.BusinessBase;
using System.IO;
using DevExpress.XtraEditors;

namespace zlMedimgSystem.CTL.ImgProcess
{

    public delegate void DelegateImgProcessEvent(TileImageInfo imgInfo); 
    public partial class frmImageProcess : Form
    {

        public event DelegateImgProcessEvent OnImageSave;
        public event DelegateImgProcessEvent OnAddReportImage;

        private IDBQuery _dbHelper = null;
        private ILoginUser _userData = null;
        private string _applyId = "";
        private string _selectImageID = "";

        private StudyMediaSerialModel _studyMediaModel = null;

        private int _imgViewCount = 8;

        public frmImageProcess()
        {
            InitializeComponent();
        }

        public void ShowImgProcess(IDBQuery dbHelper, ILoginUser userData,
                                    string applyId, string imageID, IWin32Window owner)
        {
            _dbHelper = dbHelper;
            _userData = userData;
            _applyId = applyId;
            _selectImageID = imageID;

            _studyMediaModel = new StudyMediaSerialModel(dbHelper);

            this.ShowDialog(owner);
        }

        private void frmImageProcess_Load(object sender, EventArgs e)
        {
            try
            {
                BindStudyMedia();

                if (_images != null && string.IsNullOrEmpty(_selectImageID) == false)
                {
                    int imgIndex = _images.FindIndex(T=>T.MediaId == _selectImageID);

                    if (imgIndex < 0) return;

                    imgIndex = imgIndex + 1;

                    int curPageNo = imgIndex / _imgViewCount;

                    if (imgIndex % _imgViewCount != 0) curPageNo = curPageNo + 1;

                    splitPage1.ChangePage(curPageNo);

                    TileItem ti = imageView1.FindByImageId(_selectImageID);

                    imageView1.Selected(ti);

                    imageProcessControl1.LoadBackImage(ImageEx.LoadFile(_images[imgIndex-1].File) as Bitmap);


                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
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

        private void ImagePageView(List<TileImageInfo> imgInfos)
        {
            //    BackgroundWorker bgWork = new BackgroundWorker();

            //    bgWork.DoWork += DoWork;
            //    bgWork.ProgressChanged += ProgessChanged;
            //    bgWork.RunWorkerCompleted += WorkerCompleted;

            //    bgWork.WorkerReportsProgress = false;
            //    bgWork.WorkerSupportsCancellation = true;


            //    imageView1.Clear();
            //    bgWork.RunWorkerAsync(imgRanges);
            //}

            //private object objLockWork = new object();
            //private void DoWork(object sender, DoWorkEventArgs e)
            //{
            //    if (e.Argument == null)
            //    {
            //        throw new Exception("图像加载参数传递无效。");
            //    }


            //List<TileImageInfo> imgInfos = e.Argument as List<TileImageInfo>;
            imageView1.Clear();
            if (imgInfos == null || imgInfos.Count <= 0)
            {
                throw new Exception("无需要加载的图像信息。");
            }

            try
            {
                //lock (objLockWork)
                //{

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
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("图像加载失败", ex);
            }


        }


        private void ProgessChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        delegate void DelegateDoWorkMsg(Exception msg);
        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //增加失败声音提示
                //MsgBox.ShowException(e.Error, this);
                DoWorkMsg(e.Error);

                return;
            }

            imageView1.RefreshImageRange();
        }

        public void DoWorkMsg(Exception ex)
        {
            if (this.InvokeRequired)//如果是在非创建控件的线程访问，即InvokeRequired=true
            {
                DelegateDoWorkMsg workMsg = new DelegateDoWorkMsg(DoWorkMsg);
                this.Invoke(workMsg, new object[] { ex });
            }
            else
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
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private StudySerialData _serialData = null;
        private void tsbSaveStudy_Click(object sender, EventArgs e)
        {

            string UploadToFtp(string vPath, string mediaFile)
            {
                //上传到ftp
                FTPFileHelp ftp = Transfer.GetFtp(vPath, _serialData.存储ID, _dbHelper);

                if (ftp == null)
                {
                    throw new Exception("FTP对象创建失败。");
                }

                System.IO.FileInfo fi = new System.IO.FileInfo(mediaFile);

                ftp.MakeDirectory(ftp.VPath);
                ftp.FileUpLoad(ftp.VPath + fi.Name, fi);

                return fi.Name;
            }

            try
            {
                int imgIndex = _images.FindIndex(T => T.MediaId == _selectImageID);
                if (imgIndex < 0)
                {
                    MessageBox.Show("未检索到对应的检查图像，不能进行保存。", "提示");
                    return;
                }

                Image processImg = imageProcessControl1.ExportImage();

                TileImageInfo imageInfo = _images[imgIndex];
                

                //序列信息为空或为不同的申请，则需要重新获取序列信息
                if (_serialData == null || _serialData.申请ID.Equals(_applyId) == false)
                {
                    _serialData = _studyMediaModel.GetApplySerialInfoById(imageInfo.SerialId);
                }

                if (_serialData == null)
                {
                    MessageBox.Show("尚未产生图像序列，不能进行保存。", "提示");
                    return;
                }

                StudyMediaData sourceMedia = _studyMediaModel.GetMediaInfoById(imageInfo.MediaId);

                string vPath = GetImageVpath(_applyId, _serialData.序列信息.申请日期);

                if (string.IsNullOrEmpty(sourceMedia.媒体信息.来源媒体ID))
                {                    
                    string localPath = FormatFilePath(Dir.GetAppTempDir() + @"\" + vPath);
                
                    string mediaFile = FormatFilePath(localPath + @"\" + GetImgFileName("bmp"));

                    if (System.IO.Directory.Exists(localPath) == false) System.IO.Directory.CreateDirectory(localPath);

                    //保存修改图像
                    processImg.Save(mediaFile);

                    //先上传图像到ftp
                    string mediaName = UploadToFtp(vPath, mediaFile);


                    //新增数据
                    StudyMediaData mediaData = new StudyMediaData();

                    mediaData.DcmUID = SqlHelper.GetDcmUID("3");
                    mediaData.媒体ID = SqlHelper.GetNumGuid();
                    mediaData.序列ID = _serialData.序列ID;
                    mediaData.申请ID = _serialData.申请ID;
                    mediaData.序号 = _studyMediaModel.GetMaxMediaNo(_serialData.序列ID) + 1;
                    mediaData.媒体信息.媒体名称 = mediaName;
                    mediaData.媒体信息.创建人 = _userData.Name;
                    mediaData.媒体信息.创建日期 = _studyMediaModel.GetServerDate();
                    mediaData.媒体信息.媒体类型 = "图像";// MediaType.图像;
                    mediaData.媒体信息.媒体描述 = "";
                    mediaData.媒体信息.来源媒体ID = sourceMedia.媒体ID;
                    mediaData.媒体信息.最后处理人 = _userData.Name;
                    mediaData.媒体信息.最后处理时间 = mediaData.媒体信息.创建日期;
                    mediaData.媒体信息.最后版本 = 1;


                    mediaData.媒体信息.CopyBasePro(mediaData);


                    _studyMediaModel.NewMedia(mediaData);

                    //添加图像到缩略图中显示
                    TileImageInfo newImg = new TileImageInfo();

                    newImg.CopyFrom(imageInfo);

                    newImg.MediaId = mediaData.媒体ID;
                    newImg.MediaName = mediaName;
                    newImg.Order = Convert.ToString(mediaData.序号);
                    newImg.File = mediaFile;

                    _images.Add(newImg);

                    imageView1.AddImage(newImg);

                    imageView1.Selected(0);

                    _selectImageID = newImg.MediaId;
                }
                else
                {
                    //if (File.Exists(imageInfo.File))
                    //{
                    //    File.Delete(imageInfo.File);
                    //}

                    //保存修改图像
                    processImg.Save(imageInfo.File);

                    //先上传图像到ftp
                    string mediaName = UploadToFtp(vPath, imageInfo.File);

                    sourceMedia.媒体信息.最后版本 = sourceMedia.媒体信息.最后版本 + 1;
                    sourceMedia.媒体信息.最后处理人 = _userData.Name;
                    sourceMedia.媒体信息.最后处理时间 = _studyMediaModel.GetServerDate();

                    //更新数据库
                    _studyMediaModel.UpdateMedia(sourceMedia);

                    //更新缩略图显示
                    imageView1.UpdateTileImage(null, imageInfo.File);
                }
                
                OnImageSave?.Invoke(imageInfo);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private string GetImgFileName(string fmtName)
        {
            return SqlHelper.GetNumGuid() + "." + fmtName;
        }

        private string GetImageVpath(string applyId, DateTime requestTime)
        {
            string fmtRequestDate = Convert.ToDateTime(requestTime).ToString("yyyyMMdd");

            return fmtRequestDate + @"\" + applyId + @"\images\";
        }

        private string FormatFilePath(string fileFullName)
        {
            return fileFullName.Replace(@"\\", @"\");
        }

        private void imageView1_OnItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
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

                _selectImageID = imageInfo.MediaId;

                imageProcessControl1.LoadBackImage(ImageEx.LoadFile(imageInfo.File) as Bitmap);
            }
            catch (Exception ex)
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
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbSaveReport_Click(object sender, EventArgs e)
        {
            try
            {
                int imgIndex = _images.FindIndex(T => T.MediaId == _selectImageID);
                if (imgIndex < 0)
                {
                    MessageBox.Show("未检索到对应的检查图像，不能进行保存。", "提示");
                    return;
                }
                
                TileImageInfo imageInfo = _images[imgIndex];

                OnAddReportImage?.Invoke(imageInfo);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

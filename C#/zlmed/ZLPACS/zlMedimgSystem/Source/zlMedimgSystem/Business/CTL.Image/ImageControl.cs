using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using DevExpress.XtraEditors;
using zlMedimgSystem.DataModel;
using System.IO;
using zlMedimgSystem.Services;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.Image
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(ImageControl), "Resources.images.ico")]
    public partial class ImageControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class ImageActionDefine
        {
            public const string LoadImages = "载入影像";
            public const string AddImage = "添加影像";
            public const string DelImage = "删除影像";
            public const string ImageSetting = "影像设置";
            public const string RefreshImage = "刷新影像";

        }

        static public class ImageDataDefine
        {
            public const string SelImageData = "当前选择影像";
            public const string MouseItemData = "光标所在影像";
        }

        static public class ImageEventDefine
        {
            public const string MediaDblClick = "影像双击事件";
            public const string MediaClick = "影像单击事件";
            public const string MediaEnter = "鼠标移入事件";
            public const string MediaLeave = "鼠标移出事件";
        }


        //**********************************************************************

        private int _imgViewCount = 8;

        private ImageConfig _ic = null;
        private StudyMediaSerialModel _sm = null;
        private ImageModuleDesign _imgModuleDesign = null;

        private string _applyId = "";

        public ImageControl()
        {
            InitializeComponent();

            _imgModuleDesign = new ImageModuleDesign();

            _imgModuleDesign.ToolsDesign.Visible = true;
            _imgModuleDesign.ButImgRefreshVisible = true;
            _imgModuleDesign.ButImgSettingVisible = true;

            _imgModuleDesign.ToolsDesign.BackColor = toolStrip2.BackColor;
            _imgModuleDesign.ToolsDesign.ForceColor = toolStrip2.ForeColor;

        }


        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "图像模块";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add(ImageActionDefine.LoadImages, "载入当前申请的检查影像,需要指定请求数据，请求数据项如下：" 
                                                                    + System.Environment.NewLine 
                                                                    + "applyid");

            _provideActionDesc.Add(ImageActionDefine.AddImage, "添加指定影像到当前模块，需要指定请求数据，请求数据项如下：" 
                                                                    + System.Environment.NewLine
                                                                    + "mediaid,serialid,mediatype,order,localfile");

            _provideActionDesc.Add(ImageActionDefine.RefreshImage, "刷新当前检查影像");
            
            _provideActionDesc.Add(ImageActionDefine.DelImage, "删除影像");
            _provideActionDesc.Add(ImageActionDefine.ImageSetting, "影像设置");


            _provideDataDesc.AddDataDescription(_moduleName, ImageDataDefine.SelImageData, "取得当前选择的媒体数据,返回数据项如下:" 
                                                                                            + System.Environment.NewLine
                                                                                            + "applyid,imageid,mediaid,serialid,storageid,order,mediatype,medianame,iskeyimage,isreportimage,localfile,vpath");
            _provideDataDesc.AddDataDescription(_moduleName, ImageDataDefine.MouseItemData, "获取光标所在的媒体数据,返回数据项如下:" 
                                                                                            + System.Environment.NewLine 
                                                                                            + "applyid,imageid,mediaid,serialid,storageid,order,mediatype,medianame,iskeyimage,isreportimage,localfile,vpath"); 

            _designEvents.Add(ImageEventDefine.MediaDblClick, new EventActionReleation(ImageEventDefine.MediaDblClick, ActionType.atSysFixedEvent));
            _designEvents.Add(ImageEventDefine.MediaClick, new EventActionReleation(ImageEventDefine.MediaClick, ActionType.atSysFixedEvent));
            _designEvents.Add(ImageEventDefine.MediaEnter, new EventActionReleation(ImageEventDefine.MediaEnter, ActionType.atSysFixedEvent));
            _designEvents.Add(ImageEventDefine.MediaLeave, new EventActionReleation(ImageEventDefine.MediaLeave, ActionType.atSysFixedEvent));
        }


        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _imgModuleDesign = JsonHelper.DeserializeObject<ImageModuleDesign>(customContext);

            LoadDesign();
        }
        
        public override string ShowCustomDesign()
        {
            using (frmImageDesign design = new frmImageDesign())
            {
                design.ShowDesign(_imgModuleDesign, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_imgModuleDesign);

            LoadDesign();

            return _customDesignFmt;
        }


        private void LoadDesign()
        {
            if (_imgModuleDesign.ToolsDesign.Visible == false)
            {
                toolStrip2.Visible = false;
                splitPage1.Dock = DockStyle.Fill;
                return;
            }

            if (_imgModuleDesign.ToolsDesign.Size > 0)
            {
                panel1.Height = _imgModuleDesign.ToolsDesign.Size;
                splitPage1.Height = _imgModuleDesign.ToolsDesign.Size;
                toolStrip2.Height = _imgModuleDesign.ToolsDesign.Size;
            }

            toolStrip2.Visible = true;

            
            toolStrip2.BackColor = _imgModuleDesign.ToolsDesign.BackColor;
            toolStrip2.ForeColor = _imgModuleDesign.ToolsDesign.ForceColor;

            
            splitPage1.BackColor = _imgModuleDesign.ToolsDesign.BackColor;
            splitPage1.ForeColor = _imgModuleDesign.ToolsDesign.ForceColor;

            tsbRefresh.Visible = _imgModuleDesign.ButImgRefreshVisible; 
            tsbSetting.Visible = _imgModuleDesign.ButImgSettingVisible;

            
            if (_imgModuleDesign.ToolsDesign.ToolsCfg != null)
            {
                InitUserTool(_imgModuleDesign.ToolsDesign);
            }

            if (toolStrip2.Visible == false)
            {
                splitPage1.Dock = DockStyle.Fill;
            }
            else
            {
                splitPage1.Dock = DockStyle.Left;
                splitPage1.Width = 120;
            }


            ToolsHelper.SyncDesignEventsByButtons(_imgModuleDesign.ToolsDesign, _designEvents);
        }

      
        private void InitUserTool(ToolsDesign toolDesign)
        {
            try
            {
                for (int i = toolStrip2.Items.Count - 1; i >= 0; i--)
                {
                    //先移除用户控件
                    if (toolStrip2.Items[i].Tag == null) continue;
                    toolStrip2.Items.RemoveAt(i);
                }

                if (toolDesign.ToolsCfg.Count <= 0)
                {
                    if (toolStrip2.Items.Count <= 0) toolStrip2.Visible = false;

                    return;
                }

                ToolsHelper.ConfigButtons(toolStrip2, toolDesign, DoUserToolEvent_StripItem);

                if (this.DesignMode == false)
                {
                    toolStrip2.Visible = (toolStrip2.Items.Count <= 0) ? false : true;
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void DoUserToolEvent_StripItem(object sender, EventArgs e)
        {
            ToolStripItem tsi = (sender as ToolStripItem);
            if (tsi == null) return;

            //没有对应的事件配置
            if (_designEvents.ContainsKey(tsi.Text) == false) return;

            EventActionReleation ea = _designEvents[tsi.Text];

            DoActions(ea, sender);
        }


        private void DoActions(EventActionReleation ea, object sender)
        {
            try
            {
                base.DoBindActions(ea, sender);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public override void RefreshModule()
        {
        }


        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case ImageDataDefine.SelImageData:
                    return true;

                case ImageDataDefine.MouseItemData:
                    return true;

                default:
                    return false;
            }
        }


        public override IBizDataItems QueryDatas(string dataIdentificationName)
        {
            BizDataItems resultDatas = null;
            BizDataItem dataItem = null;

            TileImageInfo imgInfo = null;

            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case ImageDataDefine.SelImageData://当前选择的图像
                    resultDatas = new BizDataItems();

                    List<TileItem> checkItems = imageView1.CheckItems;
                    if (checkItems == null || checkItems.Count <= 0)
                    {
                        checkItems = new List<TileItem>();
                        if (imageView1.SelItem != null) checkItems.Add(imageView1.SelItem);
                    }

                    foreach(TileItem ti in checkItems)
                    {
                        dataItem = new BizDataItem();

                        imgInfo = ti.Tag as TileImageInfo;
                        if (imgInfo == null) continue;

                        dataItem.Add(DataHelper.StdPar_ApplyId, _applyId);
                        dataItem.Add(DataHelper.StdPar_MediaId, imgInfo.MediaId);
                        dataItem.Add(DataHelper.StdPar_SerialId, imgInfo.SerialId);
                        dataItem.Add(DataHelper.StdPar_StorageId, imgInfo.StorageId);
                        dataItem.Add(DataHelper.StdPar_MediaOrder, imgInfo.Order);
                        dataItem.Add(DataHelper.StdPar_MediaType, imgInfo.MediaType);
                        dataItem.Add(DataHelper.StdPar_MediaName, imgInfo.MediaName);
                        dataItem.Add(DataHelper.StdPar_IsKeyImage, imgInfo.IsKeyImage);
                        dataItem.Add(DataHelper.StdPar_IsReportImage, imgInfo.IsReportImage);
                        dataItem.Add(DataHelper.StdPar_LocalFile, imgInfo.File);
                        dataItem.Add(DataHelper.StdPar_VPath, imgInfo.VPath);


                        resultDatas.Add(dataItem);
                    }

                    resultDatas.Key = _applyId;
                    resultDatas.Tag = null;

                    return resultDatas;

                case ImageDataDefine.MouseItemData://光标所在Item
                    if (_mouseItem == null) return null;

                    resultDatas = new BizDataItems();

                    dataItem = new BizDataItem();

                    imgInfo = _mouseItem.Tag as TileImageInfo;
                    if (imgInfo == null) return null;

                    dataItem.Add(DataHelper.StdPar_ApplyId, _applyId);
                    dataItem.Add(DataHelper.StdPar_MediaId, imgInfo.MediaId); 
                    dataItem.Add(DataHelper.StdPar_SerialId, imgInfo.SerialId);
                    dataItem.Add(DataHelper.StdPar_StorageId, imgInfo.StorageId);
                    dataItem.Add(DataHelper.StdPar_MediaOrder, imgInfo.Order);
                    dataItem.Add(DataHelper.StdPar_MediaType, imgInfo.MediaType);
                    dataItem.Add(DataHelper.StdPar_MediaName, imgInfo.MediaName);
                    dataItem.Add(DataHelper.StdPar_IsKeyImage, imgInfo.IsKeyImage);
                    dataItem.Add(DataHelper.StdPar_IsReportImage, imgInfo.IsReportImage);
                    dataItem.Add(DataHelper.StdPar_LocalFile, imgInfo.File);
                    dataItem.Add(DataHelper.StdPar_VPath, imgInfo.VPath);


                    resultDatas.Add(dataItem);

                    return resultDatas;

                default:
                    return null;
            }
        }

        //protected override void BindEvents()
        //{
        //}

        public override void ChangeModuleStyle(string styleName)
        {
        }

  
        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            switch (actName)
            {
                case ImageActionDefine.LoadImages://刷新申请图像 

                    if (bizDatas == null) return false; 

                    _applyId = DataHelper.GetItemValueByApplyId(bizDatas[0]);

                    LoadApplyImages(_applyId);

                    break;

                case ImageActionDefine.RefreshImage:
                    if (string.IsNullOrEmpty(_applyId))
                    {
                        _images.Clear();
                        imageView1.Clear();

                        splitPage1.BindNull(0, _imgViewCount);

                        return true;
                    }

                    LoadApplyImages(_applyId);

                    break;

                case ImageActionDefine.AddImage://添加图像

                    if (bizDatas == null) return false; 

                    TileImageInfo imgInfo = new TileImageInfo();

                    imgInfo.MediaId = DataHelper.GetItemValueByImageId(bizDatas[0]);
                    imgInfo.SerialId = DataHelper.GetItemValueBySerialId(bizDatas[0]);
                    imgInfo.MediaType = DataHelper.GetItemValueByMediaType(bizDatas[0]);
                    imgInfo.Order = DataHelper.GetItemValueByMediaOrder(bizDatas[0]);
                    imgInfo.File = DataHelper.GetItemValueByFile(bizDatas[0]);
                    imgInfo.IsKeyImage = false;
                    imgInfo.IsReportImage = false;

                    if (File.Exists(imgInfo.File) == false)
                    {
                        MessageBox.Show("未找到本地图像文件 [" + imgInfo.File  + "]，不能进行加载。", "提示");
                        return false;
                    }

                    FileInfo fi = new FileInfo(imgInfo.File);
                    imgInfo.MediaName = fi.Name;

                    if (_images == null) _images = new List<TileImageInfo>();

                    _images.Insert(0, imgInfo);

                    splitPage1.UpdatePage(_images.Count);
                    imageView1.AddImage(imgInfo);
                     
                    imageView1.RefreshImageRange();

                    break;

                case ImageActionDefine.ImageSetting://影像相关参数设置
                    ShowImageConfig();
                    
                    break;

                default:
                    break;
            }

            return true;
        }


        private List<TileImageInfo> _images = null;

        /// <summary>
        /// 载入申请图像
        /// </summary>
        private void LoadApplyImages(string applyId)
        {
            if (_images == null) _images = new List<TileImageInfo>();
            if (_sm == null) _sm = new StudyMediaSerialModel(_dbQuery);

            _images.Clear();
            imageView1.Clear();

            DataTable dtMedias = _sm.GetApplyMedia(applyId);
            if (dtMedias == null || dtMedias.Rows.Count <= 0) return;

            dtMedias.DefaultView.Sort = "序号 Desc";

            StudySerialData serialData = null;
            foreach(DataRowView dr in dtMedias.DefaultView)
            {
                StudyMediaData smd = new StudyMediaData();
                smd.BindRowData(dr.Row);

                if (serialData == null || serialData.序列ID.Equals(smd.序列ID) == false)
                {
                    serialData = _sm.GetApplySerialInfoById(smd.序列ID);
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

        private void ImagePageView(List<TileImageInfo> imgRanges)
        {
            BackgroundWorker bgWork = new BackgroundWorker();

            bgWork.DoWork += DoWork;
            bgWork.ProgressChanged += ProgessChanged;
            bgWork.RunWorkerCompleted += WorkerCompleted;

            bgWork.WorkerReportsProgress = false;
            bgWork.WorkerSupportsCancellation = true;


            imageView1.Clear();
            bgWork.RunWorkerAsync(imgRanges);
        }
         
        private object objLockWork = new object();
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                throw new Exception("图像加载参数传递无效。");
            }


            List<TileImageInfo> imgInfos = e.Argument as List<TileImageInfo>;
            if (imgInfos == null || imgInfos.Count <= 0)
            {
                throw new Exception("无需要加载的图像信息。");
            }

            try
            {
                lock (objLockWork)
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
                                ftp =Transfer.GetFtp(imgInfo.VPath, imgInfo.StorageId, _dbQuery);
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
            }
            catch(Exception ex)
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
 
   

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_applyId)) return;

                LoadApplyImages(_applyId);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        //private void tsbProcess_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (imageView1.SelItem == null)
        //        {
        //            MessageBox.Show("请选择需要处理的图像。", "提示");
        //            return;
        //        }

        //        TileImageInfo imgInfo = imageView1.SelItem.Tag as TileImageInfo;


        //        //ProcessImage(imgInfo);
        //    }
        //    catch (Exception ex)
        //    {
        //        MsgBox.ShowException(ex, this);
        //    }
        //}

        //private void ProcessImage(TileImageInfo imgInfo)
        //{
        //    ImagePreview.CloseImagePreview();

        //    ImageProcess.ShowImageProcess(imgInfo.File, _dbQuery, this);
        //}

        //暂时不处理关键图标记
        //private void tsbLock_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (imageView1.SelItem == null)
        //        {
        //            MessageBox.Show("请选择需要标记的图像。", "提示");
        //            return;
        //        }

        //        //绘制key
        //        TileImageInfo imgInfo = imageView1.SelItem.Tag as TileImageInfo;
        //        if (imgInfo == null) return;

        //        if (imgInfo.IsKeyImage)
        //        {
                    
        //            imageView1.ClearLockTag(imageView1.SelItem);

        //            imgInfo.IsKeyImage = false;

        //            _sm.UpdateKeyImageState(imgInfo.MediaId, false);
        //        }
        //        else
        //        {
        //            imageView1.SetLockTag(imageView1.SelItem);

        //            imgInfo.IsKeyImage = true;

        //            _sm.UpdateKeyImageState(imgInfo.MediaId, true);
        //        }
                 
        //    }
        //    catch (Exception ex)
        //    {
        //        MsgBox.ShowException(ex, this);
        //    }
        //}

        //暂不处理报告图发送
        //private void tsbSendReport_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (imageView1.SelItem == null)
        //        {
        //            MessageBox.Show("请选择需要标记的图像。", "提示");
        //            return;
        //        }

        //        TileImageInfo imgInfo = imageView1.SelItem.Tag as TileImageInfo;
        //        if (imgInfo == null) return;

        //        if (imgInfo.IsReportImage)
        //        {
        //            //取消报告图，如果已经保存在报告图中，则不能进行取消...

        //        }
        //        else
        //        {
        //            //添加报告图，如果存在报告编辑界面，则直接加入报规图中...

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        MsgBox.ShowException(ex, this);
        //    }
        //}

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

        private TileItem _mouseItem = null;
        private void imageView1_OnItemMouseEnter(TileItem mouseItem)
        {
            //item mouse enter 事件
            try
            {
                _mouseItem = mouseItem;
                if (_mouseItem == null) return;

                if (_designEvents.Count > 0)
                {
                    if (_designEvents.ContainsKey(ImageEventDefine.MediaEnter))
                    {
                        if (DoBindActions(_designEvents[ImageEventDefine.MediaEnter], mouseItem) == false) return;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void imageView1_OnItemMouseLeave(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void imageView1_OnViewerMouseLeave(object sender, EventArgs e)
        {
            //item mouse leave 事件
            try
            {
                _mouseItem = null;

                if (_designEvents.Count > 0)
                {
                    if (_designEvents.ContainsKey(ImageEventDefine.MediaLeave))
                    {
                        if (DoBindActions(_designEvents[ImageEventDefine.MediaLeave], sender) == false) return;
                    }
                } 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void imageView1_OnItemClick(object sender, TileItemEventArgs e)
        {
            //item单击事件
            try
            {
                if (imageView1.SelItem == null) return;

                if (_designEvents.Count > 0)
                {
                    if (_designEvents.ContainsKey(ImageEventDefine.MediaClick))
                    {
                        if (DoBindActions(_designEvents[ImageEventDefine.MediaClick], sender) == false) return;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void imageView1_OnItemDblClick(object sender, TileItemEventArgs e)
        {
            //item双击事件
            try
            {
                if (imageView1.SelItem == null) return;

                if (_designEvents.Count > 0)
                {
                    if (_designEvents.ContainsKey(ImageEventDefine.MediaDblClick))
                    {
                        if (DoBindActions(_designEvents[ImageEventDefine.MediaDblClick], sender) == false) return;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbSetting_Click(object sender, EventArgs e)
        {
            try
            {
                //参数设置
                ShowImageConfig();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 显示视频参数配置
        /// </summary>
        private void ShowImageConfig()
        {
            using (frmImageConfig videoCfg = new frmImageConfig())
            {
                if (videoCfg.ShowImageConfig(_ic, _moduleName, this))
                {
                    _imgViewCount = _ic.RecordCount;
                    LoadApplyImages(_applyId);
                }
            }
        }
         

        public override void ModuleLoaded()
        {
            try
            {
                if (this.DesignMode == false)
                {
                    imageView1.IsDesignModel = this.DesignMode;

                    splitPage1.OnPageChanged -= splitPage1_OnPageChanged;
                    splitPage1.OnPageChanged += splitPage1_OnPageChanged;

                    _ic = ImageConfig.GetConfig(_moduleName);

                    _imgViewCount = _ic.RecordCount;

                    if (_imgViewCount <= 0) _imgViewCount = 8;
                }

                base.ModuleLoaded();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }            
        }

        public override void Terminated()
        {
            splitPage1.OnPageChanged -= splitPage1_OnPageChanged;
            base.Terminated();
        }

        private void ImageControl_Leave(object sender, EventArgs e)
        {
            imageView1.ReleaseCursor();
        }
    }
}

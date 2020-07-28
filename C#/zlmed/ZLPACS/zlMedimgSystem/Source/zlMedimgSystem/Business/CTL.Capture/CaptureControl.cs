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
using zlMedimgSystem.Services;
using AForge.Video.DirectShow; 
using AForge.Video.FFMPEG;
using System.IO;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.CTL.Capture
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(CaptureControl), "Resources.capture.ico")]
    public partial class CaptureControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class CaptureProviderActionDefine
        {
            public const string Action_EnterCapture = "进入采集";
            public const string Action_CaptureImg = "采集图像";
            public const string Action_RecordVideo = "录制视频";
            public const string Action_QuitCapture = "退出采集";
            public const string Action_Restart = "重启视频";
            public const string Action_Config = "参数配置";
        }

        static public class CaptureProviderDataDefine
        {
            public const string Data_CaptureData = "当前采集的媒体数据";
            public const string Data_StudyData = "当前采集对应的申请数据";
        }

        static public class CaptureProviderEventDefine
        {
            public const string Event_AfterCaptureImage = "图像采集事件";
            public const string Event_AfterRecordVideo = "视频录制事件";
        }



        //**********************************************************************

        private CaptureModuleDesign _captureDesign = null;

        private CaptureConfig _cc = null;

        private string _applyId = "";//申请ID
        private DateTime _applyDate = default(DateTime);//申请日期
        private ApplyData _applyData = null;
        private int _mainHandle = 0; 


        private MediaData _curMidiaInfo = null;

        public CaptureControl()
        {
            InitializeComponent();

            _captureDesign = new CaptureModuleDesign();

            _captureDesign.Dock = ToolDockWay.tdwBottom;

            _captureDesign.ToolsDesign.BackColor = toolStrip1.BackColor;
            _captureDesign.ToolsDesign.ForceColor = toolStrip1.ForeColor;
            _captureDesign.ToolsDesign.Visible = true;
            _captureDesign.ToolsDesign.Size = 34;

            _captureDesign.ButSettingVisible = true;
            _captureDesign.ButRestartVisible = true;
            _captureDesign.ButRecordVisible = true;
            _captureDesign.ButQuitVisible = true;
            _captureDesign.ButCaptureVisible = true;

            _captureDesign.ToolsDesign.Visible = true;
        }

        public override void Terminated()
        {
            if (videoCamera.VideoSource != null)
            {

                videoCamera.VideoSource.Stop();
                videoCamera.VideoSource.SignalToStop();
            }

            try
            {
                videoCamera.Stop();
                videoCamera.VideoSource = null;
            }
            catch { }

            

            base.Terminated();
        }
         

        private void ReStart()
        {
            _cc = CaptureConfig.GetConfig(_moduleName);

            OpenDevice();

            AdaptPostion();
        }
 
        /// <summary>
        /// 打开设备
        /// </summary>
        private void OpenDevice()
        {
            videoCamera.Visible = true;


            if (videoCamera.VideoSource != null)
            {

                videoCamera.VideoSource.Stop();
                videoCamera.VideoSource.SignalToStop();
            }

            videoCamera.VideoSource = null;

            if (string.IsNullOrEmpty(_cc.VideoDeviceName)) return;

            //打开视频设备
            FilterInfoCollection filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo info in filterInfoCollection)
            {
                if ((info.Name == _cc.VideoDeviceName) || (string.IsNullOrEmpty(_cc.VideoDeviceName) == true))
                {
                    VideoCaptureDevice videoSource = new VideoCaptureDevice(info.MonikerString);
                    if (videoSource.VideoCapabilities.Length > 0)
                    {
                        if (_cc.ResolutionIndex <= videoSource.VideoCapabilities.Length)
                        {
                            videoSource.VideoResolution = videoSource.VideoCapabilities[_cc.ResolutionIndex];

                        }
                    }

                    if (videoSource.AvailableCrossbarVideoInputs.Length > 0)
                    {
                        if (Convert.ToInt32(_cc.InputPort) <= videoSource.AvailableCrossbarVideoInputs.Length)
                        {
                            videoSource.CrossbarVideoInput = videoSource.AvailableCrossbarVideoInputs[_cc.InputPort];

                        }
                    }


                    this.videoCamera.VideoSource = videoSource;

                    this.videoCamera.Start();


                    break;
                }
            }

        }

        private void tsbSetting_Click(object sender, EventArgs e)
        {
            try
            {
                //参数设置
                ShowVideoConfig();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 显示视频参数配置
        /// </summary>
        private void ShowVideoConfig()
        {
            using (frmVideoConfig videoCfg = new frmVideoConfig())
            {
                if (videoCfg.ShowCaptureConfig(_cc, _moduleName, this))
                {
                    ReStart();
                }
            }
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = false;
            _moduleName = "采集模块";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add(CaptureProviderActionDefine.Action_EnterCapture, "根据指定请求数据，加载视频采集，请求数据项如下：" 
                                                                                    + System.Environment.NewLine 
                                                                                    + "applyid");
            _provideActionDesc.Add(CaptureProviderActionDefine.Action_CaptureImg, "采集当前患者的检查图像");
            _provideActionDesc.Add(CaptureProviderActionDefine.Action_RecordVideo, "录制当前患者的检查视频");
            _provideActionDesc.Add(CaptureProviderActionDefine.Action_QuitCapture, "退出清理当前患者检查");
            _provideActionDesc.Add(CaptureProviderActionDefine.Action_Config, "配置视频采集参数");



            _provideDataDesc.AddDataDescription(_moduleName, CaptureProviderDataDefine.Data_CaptureData, "取得当前采集的媒体数据,返回数据项如下："
                                                            + System.Environment.NewLine 
                                                            + "applyid,applydate,applydata,localfile,mediatype,serialid,mediaid,order");
            _provideDataDesc.AddDataDescription(_moduleName, CaptureProviderDataDefine.Data_StudyData, "取得当前采集对应的检查申请信息,返回数据项如下："
                                                            + System.Environment.NewLine 
                                                            + "applyid,applydate,applydata");


            _designEvents.Add(CaptureProviderEventDefine.Event_AfterCaptureImage, new EventActionReleation(CaptureProviderEventDefine.Event_AfterCaptureImage, ActionType.atSysFixedEvent));
            _designEvents.Add(CaptureProviderEventDefine.Event_AfterRecordVideo, new EventActionReleation(CaptureProviderEventDefine.Event_AfterRecordVideo, ActionType.atSysFixedEvent));
        }

        public override void ModuleLoaded()
        {
            try
            {
                if (DesignMode) return;

                _mainHandle = this.Handle.ToInt32();


                ReStart();

                base.ModuleLoaded();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _captureDesign = JsonHelper.DeserializeObject<CaptureModuleDesign>(customContext);

            LoadDesign();
        }

        private void LoadDesign()
        {
            if (_captureDesign.ToolsDesign.Visible == false)
            {
                toolStrip1.Visible = false;
                return;
            }

            toolStrip1.Visible = true;

            switch (_captureDesign.Dock)
            {
                case ToolDockWay.tdwTop:
                    toolStrip1.Dock = DockStyle.Top;
                    toolStrip1.Height = _captureDesign.ToolsDesign.Size;
                    break;

                case ToolDockWay.tdwLeft:
                    toolStrip1.Dock = DockStyle.Left;
                    toolStrip1.Width = _captureDesign.ToolsDesign.Size;
                    break;

                case ToolDockWay.tdwRight:
                    toolStrip1.Dock = DockStyle.Right;
                    toolStrip1.Width = _captureDesign.ToolsDesign.Size;
                    break;

                default:
                    toolStrip1.Dock = DockStyle.Bottom;
                    toolStrip1.Height = _captureDesign.ToolsDesign.Size;
                    break;
            }

            toolStrip1.BackColor = _captureDesign.ToolsDesign.BackColor;
            toolStrip1.ForeColor = _captureDesign.ToolsDesign.ForceColor;

            tsbCapture.Visible = _captureDesign.ButCaptureVisible;
            tsbVideo.Visible = _captureDesign.ButRecordVisible;
            tsbRestart.Visible = _captureDesign.ButRestartVisible;
            tsbClear.Visible = _captureDesign.ButQuitVisible;
            tsbSetting.Visible = _captureDesign.ButSettingVisible;


            if (_captureDesign.ToolsDesign.ToolsCfg != null)
            {
                InitUserTool(_captureDesign.ToolsDesign);
            }


            ToolsHelper.SyncDesignEventsByButtons(_captureDesign.ToolsDesign, _designEvents);
        }

   
        private void InitUserTool(ToolsDesign toolDesign)
        {
            try
            {
                for (int i = toolStrip1.Items.Count - 1; i >= 0; i--)
                {
                    //先移除用户控件
                    if (toolStrip1.Items[i].Tag == null) continue;
                    toolStrip1.Items.RemoveAt(i);
                }

                if (toolDesign.ToolsCfg.Count <= 0)
                {
                    if (toolStrip1.Items.Count <= 0) toolStrip1.Visible = false;

                    return;
                }

                ToolsHelper.ConfigButtons(toolStrip1, toolDesign, DoUserToolEvent_StripItem);
                               
                if (this.DesignMode == false)
                {
                    toolStrip1.Visible = (toolStrip1.Items.Count <= 0) ? false : true;
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        public override string ShowCustomDesign()
        {
            using (frmVideoDesign design = new frmVideoDesign())
            {
                design.ShowDesign(_captureDesign, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_captureDesign);
            
            LoadDesign();

            return _customDesignFmt;
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


        /// <summary>
        /// 刷新
        /// </summary>
        public override void RefreshModule()
        {
        }

        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch(dataName)
            {
                case CaptureProviderDataDefine.Data_CaptureData:
                    return true;

                case CaptureProviderDataDefine.Data_StudyData:
                    return true;

                default:
                    return false;
            }
        }


        public override IBizDataItems QueryDatas(string dataIdentificationName)
        { 
            BizDataItems resultDatas = null;
            BizDataItem dataItem = null;

            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName); 

            switch (dataName)
            {
                case CaptureProviderDataDefine.Data_CaptureData://当前采集的图像数据
                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_ApplyId, _applyId);
                    dataItem.Add(DataHelper.StdPar_ApplyDate, _applyDate);
                    dataItem.Add(DataHelper.StdPar_ApplyData, _applyData);

                    if (_curMidiaInfo != null)
                    {
                        dataItem.Add(DataHelper.StdPar_LocalFile, _curMidiaInfo.MediaFile);
                        dataItem.Add(DataHelper.StdPar_MediaType, _curMidiaInfo.MediaType);
                        dataItem.Add(DataHelper.StdPar_SerialId, _curMidiaInfo.SerialId);
                        dataItem.Add(DataHelper.StdPar_MediaId, _curMidiaInfo.MediaId);
                        dataItem.Add(DataHelper.StdPar_MediaOrder, _curMidiaInfo.Order); 
                    }

                    resultDatas.Add(dataItem);

                    return resultDatas;
                case CaptureProviderDataDefine.Data_StudyData://当前采集的检查申请数据
                    resultDatas = new BizDataItems();
                    dataItem = new BizDataItem();

                    dataItem.Add(DataHelper.StdPar_ApplyId, _applyId);
                    dataItem.Add(DataHelper.StdPar_ApplyDate, _applyDate);
                    dataItem.Add(DataHelper.StdPar_ApplyData, _applyData);

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

        private void ReclearApplyData()
        {
            _applyId = "";
            _allowExecute = false;
            _applyDate = default(DateTime);

            _applyData = null;

            label1.Text = "";
        }

        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            switch (actName)
            {
                case CaptureProviderActionDefine.Action_EnterCapture://进入采集
                    ReclearApplyData();

                    if (bizDatas == null) return false;
                     

                    string applyId = DataHelper.GetItemValueByApplyId(bizDatas[0]);
                                        
                    if (string.IsNullOrEmpty(applyId))
                    {
                        MessageBox.Show("未检索到对应的申请ID，请求数据项名称为 [" + bizDatas.DataName + "]。", "提示");
                        return false;
                    }
                    
                    DataTable dtApply = StudyMediaSerialModel.GetApplyBaseInfo(applyId);

                    if (dtApply == null || dtApply.Rows.Count <= 0)
                    {
                        MessageBox.Show("未能根据申请ID [" + _applyId + "] 获取到对应的申请信息，请求数据项名称为 [" + bizDatas.DataName + "]。", "提示");
                        return false;
                    }

                    if (_applyData == null) _applyData = new ApplyData();
                    _applyData.BindRowData(dtApply.Rows[0]);
                               

                    DateTime applyDate = DataHelper.GetItemValueByApplyDate(bizDatas[0]);
                    if (applyDate == default(DateTime))
                    {
                        //从数据库中查询申请日期
                        applyDate = _applyData.申请日期;
                    }

                    _applyId = applyId;
                    _applyDate = applyDate;

                    label1.Text = _applyData.申请信息.姓名 + "(" + _applyData.检查号 + ")  " + _applyData.申请信息.性别 + "  " + _applyData.申请信息.年龄;


                    break;

                case CaptureProviderActionDefine.Action_CaptureImg://图像采集
                    ImageCapture();
                    break;

                case CaptureProviderActionDefine.Action_RecordVideo://视频录制
                    VideoRecord();
                    break;

                case CaptureProviderActionDefine.Action_QuitCapture://数据清理
                    DataClear();
                    break;

                case CaptureProviderActionDefine.Action_Restart://重启视频
                    ReStart();
                    break;

                case CaptureProviderActionDefine.Action_Config://参数配置
                    ShowVideoConfig();
                    break;

                default:
                    break;
            }

            return true;
        }

        private string GetImgFileName(string fmtName)
        {
            return SqlHelper.GetNumGuid() + "." + fmtName;
        }

        private string FormatFilePath(string fileFullName)
        {
            return fileFullName.Replace(@"\\", @"\");
        }

        private bool _allowExecute = false;

        /// <summary>
        /// 图像采集
        /// </summary>
        private void ImageCapture()
        {
            try
            {

                if (videoCamera.IsRunning == false) videoCamera.Start();
                if (videoCamera.IsRunning == false)
                {
                    MessageBox.Show("视频尚未启动，不能进行图像采集。", "提示");
                    return;
                }


                if (string.IsNullOrEmpty(_applyId))
                {
                    MessageBox.Show("申请ID无效，不能进行采集。", "提示");
                    return;
                }

                if( _applyDate == default(DateTime))
                {
                    MessageBox.Show("申请日期无效，不能进行采集。", "提示");
                    return;
                }

                if (_allowExecute == false)
                {
                    //判断是否允许执行此操作
                    _allowExecute = VerifyExecutePlan(_applyId);

                    if (_allowExecute == false) return;
                }

                _curMidiaInfo = null;

                string vPath = GetImageVpath();
                string localPath = FormatFilePath(Dir.GetAppTempDir() + @"\" + vPath);

                if (System.IO.Directory.Exists(localPath) == false) System.IO.Directory.CreateDirectory(localPath);

                string fn = GetImgFileName("bmp");

                Bitmap capBmp = videoCamera.GetCurrentVideoFrame();

                string mediaFile = FormatFilePath(localPath + @"\" + fn);

                if (capBmp == null)
                {
                    MessageBox.Show("图像采集失败，未获取到有效的图像数据。", "提示"); 
                    return;
                }

                capBmp.Save(mediaFile, System.Drawing.Imaging.ImageFormat.Bmp);
                
                //后台数据传输处理...
                TransferFile(vPath, mediaFile, MediaType.图像);


                //if (_designEvents.Count > 0)
                //{
                //    if (_designEvents.ContainsKey(CaptureProviderEventDefine.Event_AfterCaptureImage))
                //    {
                //        DoBindActions(_designEvents[CaptureProviderEventDefine.Event_AfterCaptureImage]);
                //    }
                //}

                //弹出提示
                string strPar = mediaFile + "," + _mainHandle.ToString() + "," + ((_cc.SoundHint) ? "1" : "0");
                System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + @"\zl9PacsImageHint.exe", strPar);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private string GetImageVpath()
        {
            string fmtRequestDate = Convert.ToDateTime(_applyDate).ToString("yyyyMMdd");

            return fmtRequestDate + @"\" + _applyId + @"\images\";
        }

       
        private bool _isStartRec = false;
        private string _videoRecFile = "";
        private bool createNewFile = true;
        private int _recFrameCount = 0;
        
        private string drawDate = string.Empty;
        private VideoFileWriter videoWriter = null;


        private object objLockRecord = new object();
        /// <summary>
        /// 视频录制
        /// </summary>
        private void VideoRecord()
        {
            lock (objLockRecord)
            {
                //开始录像
                if (_isStartRec == false)
                {
                    if (videoCamera.IsRunning == false) videoCamera.Start();
                    if (videoCamera.IsRunning == false)
                    {
                        MessageBox.Show("视频尚未启动，不能进行图像采集。", "提示");
                        return;
                    }


                    if (string.IsNullOrEmpty(_applyId) || _applyDate == default(DateTime))
                    {
                        MessageBox.Show("申请ID或日期无效，不能进行采集。", "提示");
                        return;
                    }


                    if (_allowExecute == false)
                    {
                        //判断是否允许执行此操作
                        _allowExecute = VerifyExecutePlan(_applyId);

                        if (_allowExecute == false) return;
                    }


                    _curMidiaInfo = null;

                    string vPath = GetImageVpath();
                    string fn = GetImgFileName("avi");
                     
                    string localPath = FormatFilePath(Dir.GetAppTempDir() + @"\"  + vPath);


                    if (Directory.Exists(localPath) == false) Directory.CreateDirectory(localPath);
                     
                    _recFrameCount = 0;

                    _videoRecFile = FormatFilePath(localPath + @"\" + fn);

                    createNewFile = true;

                    _isStartRec = true;

                    if (tsbVideo.Visible) tsbVideo.Image = Properties.Resources.videocamera_stop;
                }
                else
                {
                    _isStartRec = false;
                    if (tsbVideo.Visible) tsbVideo.Image = Properties.Resources.videocamera_run;
                }
            }
        }

        private void TransferFile(string ftpVPath, string localFile, MediaType mediaType)
        {
            BackgroundWorker bgWork = new BackgroundWorker();

            bgWork.DoWork += DoWork;
            bgWork.ProgressChanged += ProgessChanged;
            bgWork.RunWorkerCompleted += WorkerCompleted;

            bgWork.WorkerReportsProgress = false;
            bgWork.WorkerSupportsCancellation = true;

            //构造后台线程参数
            Dictionary<string, object> pars = new Dictionary<string, object>();

            pars.Add("mediatype", mediaType);
            pars.Add("localfile", localFile);//本地文件
            pars.Add("vpath", ftpVPath);//相对子目录
            pars.Add("storageid", _stationInfo.StorageId);//存储ID 
            pars.Add("soundhint", _cc.SoundHint);
            pars.Add("popuphint", _cc.PopupHint);
            pars.Add("requestdate", _applyDate);//存储ID 
            pars.Add("requestid", _applyId);//存储ID 
            pars.Add("roomid", _stationInfo.RoomId);//房间ID 
            pars.Add("deviceid", _stationInfo.DeviceId);//设备ID 
            pars.Add("username", _userData.AssistUserInfo2.Name);//用户名称


            //启动异步处理
            bgWork.RunWorkerAsync(pars);

        }
         
        private object objLockWork = new object(); 
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                throw new Exception("文件传输参数传递无效。");
            }

            Dictionary<string, object> pars = e.Argument as Dictionary<string, object>;
            System.IO.FileInfo fi = new System.IO.FileInfo(Convert.ToString(pars["localfile"]));

            try
            {
                lock (objLockWork)
                {
                    FTPFileHelp ftp = Transfer.GetFtp(Convert.ToString(pars["vpath"]), Convert.ToString(pars["storageid"]), _dbQuery);

                    if (ftp == null)
                    {
                        throw new Exception("FTP对象创建失败。");
                    }



                    ftp.MakeDirectory(ftp.VPath);
                    ftp.FileUpLoad(ftp.VPath + fi.Name, fi);

                    //写入数据库...
                    StudyMediaData smd = WriteToDB(pars, fi.Name);

                    pars.Add("serialid", smd.序列ID);
                    pars.Add("mediaid", smd.媒体ID);
                    pars.Add("order", smd.序号);

                    //返回结果...
                    e.Result = pars;
                }

            }
            catch (Exception ex)
            {
                //异常传输处理
                string failedFile = TransferFialdProces(pars, fi);

                throw new Exception("申请ID为[" + pars["requestid"] + "] 的文件处理失败，文件已临时存储到目录 [" + failedFile + "]", ex);
            }

        }


     


        private StudyMediaSerialModel _mediaSerialModel = null;
        private StudySerialData _serialData = null;
        //private object objLockDB = new object();

        public StudyMediaSerialModel StudyMediaSerialModel
        {
            get
            {
                if (_mediaSerialModel == null) _mediaSerialModel = new StudyMediaSerialModel(_dbQuery);
                return _mediaSerialModel;
            }
        }
        private StudyMediaData WriteToDB(Dictionary<string, object> pars, string mediaName)
        {
            //执行数据写入
            //根据当前房间设备查询序列信息
            string requestId = pars["requestid"].ToString();
            string roomId = pars["roomid"].ToString();
            string deviceId = pars["deviceid"].ToString();
            string doDoctor = pars["username"].ToString();

            //序列信息为空或为不同的申请，则需要重新获取序列信息
            if (_serialData == null || _serialData.申请ID.Equals(requestId) == false)
            {
                _serialData = StudyMediaSerialModel.GetApplySerialInfoByRoom(requestId, roomId, deviceId);
            }


            bool isCreateSerial = false;

            if (_serialData == null)
            {
                //新增序列
                _serialData = new StudySerialData();

                _serialData.申请ID = requestId;
                _serialData.存储ID = pars["storageid"].ToString();
                _serialData.序列ID = SqlHelper.GetNumGuid();
                _serialData.DcmUID = SqlHelper.GetDcmUID("2");
                _serialData.房间ID = roomId;
                _serialData.设备ID = deviceId;
                _serialData.序号 = StudyMediaSerialModel.GetMaxSerialNo(requestId) + 1;
                _serialData.序列信息.创建人 = doDoctor;
                _serialData.序列信息.创建日期 = StudyMediaSerialModel.GetServerDate();
                _serialData.序列信息.申请日期 = _applyDate;
                _serialData.序列信息.序列描述 = "";


                _serialData.序列信息.CopyBasePro(_serialData);

                isCreateSerial = true;
            }

            StudyMediaData smd = new StudyMediaData();
            smd.DcmUID = SqlHelper.GetDcmUID("3");
            smd.媒体ID = SqlHelper.GetNumGuid();
            smd.序列ID = _serialData.序列ID;
            smd.申请ID = _serialData.申请ID;
            smd.序号 = StudyMediaSerialModel.GetMaxMediaNo(_serialData.序列ID) + 1;
            smd.媒体信息.媒体名称 = mediaName;
            smd.媒体信息.创建人 = doDoctor;
            smd.媒体信息.创建日期 = StudyMediaSerialModel.GetServerDate();
            smd.媒体信息.媒体类型 = pars["mediatype"].ToString();
            smd.媒体信息.媒体描述 = "";

            smd.媒体信息.CopyBasePro(smd);


            StudyMediaSerialModel.TransactionBegin();
            try
            {
                if (isCreateSerial)
                {

                    StudyMediaSerialModel.NewSerial(_serialData);

                    StudyMediaSerialModel.UpdateExecuteState(requestId, roomId, deviceId, doDoctor, "", StudyExecuteState.sesDoing);
                }

                StudyMediaSerialModel.NewMedia(smd);

                StudyMediaSerialModel.TransactionCommit();

                return smd;
            }
            catch(Exception ex)
            {
                StudyMediaSerialModel.TransactionRollback();
                throw ex;
            }
        }


        private string TransferFialdProces(Dictionary<string, object> pars, System.IO.FileInfo fi)
        {
            string failedPath = FormatFilePath(Dir.GetAppFailedDir() + @"\" + pars["vpath"]);
            if (System.IO.Directory.Exists(failedPath) == false) System.IO.Directory.CreateDirectory(failedPath);

            fi.CopyTo(FormatFilePath(failedPath + @"\" + fi.Name), true);

            return failedPath + fi.Name;
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

            if (_designEvents.Count > 0)
            {
                Dictionary<string, object> pars = e.Result as Dictionary<string, object>;

                if (pars == null)
                {
                    MessageBox.Show("未能获取到有效的采集参数，不能载入采集图像。", "提示");
                    return;
                }

                MediaType mt = (MediaType)pars["mediatype"];

                _curMidiaInfo = new MediaData();
                _curMidiaInfo.MediaType = mt;
                //_curMidiaInfo.Bmp = videoCamera.GetCurrentVideoFrame();
                _curMidiaInfo.MediaFile = Convert.ToString(pars["localfile"]);
                _curMidiaInfo.SerialId = Convert.ToString(pars["serialid"]);
                _curMidiaInfo.MediaId = Convert.ToString(pars["mediaid"]);
                _curMidiaInfo.Order = Convert.ToString(pars["order"]);


                if (mt == MediaType.图像)
                {
                    //图像采集后执行事件
                    if (_designEvents.ContainsKey(CaptureProviderEventDefine.Event_AfterCaptureImage))
                    {
                        DoBindActions(_designEvents[CaptureProviderEventDefine.Event_AfterCaptureImage], sender);
                    }
                }
                else
                {
                    //视频录制后执行事件
                    if (_designEvents.ContainsKey(CaptureProviderEventDefine.Event_AfterRecordVideo))
                    {
                        DoBindActions(_designEvents[CaptureProviderEventDefine.Event_AfterRecordVideo], sender);
                    }
                }
            }
        }


        public void DoWorkMsg(Exception ex )
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



        private void DataClear()
        {
            _curMidiaInfo = null;


            ReclearApplyData();
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
        /// 确认执行安排
        /// </summary>
        /// <returns></returns>
        private bool VerifyExecutePlan(string applyId)
        {
            DataTable dtExecuteInfo = StudyMediaSerialModel.GetApplyExecuteInfo(applyId);

            if (dtExecuteInfo == null || dtExecuteInfo.Rows.Count <= 0)
            {
                MessageBox.Show("未找到申请对应的执行安排信息，操作终止。", "提示");
                return false;
            }

            bool isPlan = false;
            int waitCount = 0;
            foreach (DataRow drExecute in dtExecuteInfo.Rows)
            {
                JStudyExecute exeInfo = JsonHelper.DeserializeObject<JStudyExecute>(drExecute["执行信息"].ToString());

                if (exeInfo.执行状态 == StudyExecuteState.sesWaiting)
                {
                    waitCount = waitCount + 1;
                    //判断房间与科室是否进行安排
                    if (string.IsNullOrEmpty(exeInfo.房间ID) == false)
                    {
                        //房间ID不为空
                        if (exeInfo.房间ID == _stationInfo.RoomId)
                        {
                            if (string.IsNullOrEmpty(exeInfo.设备ID) == false)
                            {
                                if (exeInfo.设备ID == _stationInfo.DeviceId)
                                {
                                    //安排到当前设备
                                    isPlan = true;
                                }
                            }
                            else
                            {
                                //安排到当前房间
                                isPlan = true;
                            }
                        }
                    }
                    else
                    {
                        //安排到当前科室
                        isPlan = true;

                    }
                }
            }

            if (isPlan == false)
            {
                if (waitCount <= 0)
                {
                    MessageBox.Show("当前申请已被对应执行，操作终止。", "提示");
                    return false;
                }

                MessageBox.Show("当前申请已被安排到其他房间或设备执行。", "提示");

                //DialogResult dr = MessageBox.Show("当前申请已被安排到其他房间或设备，是否调整执行？", "提示", MessageBoxButtons.YesNo);
                //if (dr == DialogResult.No)
                //{
                //    return false;
                //}

                ////弹出检查安排调整窗口
                //frmApplyPlan applyPlan = new frmApplyPlan();
                //return applyPlan.ShowPlan(dtExecuteInfo, _dbQuery, _stationInfo, this); 
            }

            return true;
        }

        private void tsbCapture_Click(object sender, EventArgs e)
        {
            try
            {
                //图像采集
                ImageCapture();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbVideo_Click(object sender, EventArgs e)
        {
            try
            {
                //视频录制
                VideoRecord();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            try
            {
                //数据清理
                DataClear();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbRestart_Click(object sender, EventArgs e)
        {
            try
            {
                //设备重启
                ReStart();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void panlVideoBack_Resize(object sender, EventArgs e)
        {
            try
            {
                AdaptPostion();
            }
            catch { }

        }


        private void AdaptPostion()
        {
            //窗口自动适应计算
            if (videoCamera.VideoSource == null) return;

            VideoCaptureDevice videoSource = videoCamera.VideoSource as VideoCaptureDevice;
            if (videoSource == null) return;

            //获取原始分辨率
            int vW = 0;
            int vH = 0;
            if (videoSource.VideoResolution != null)
            {
                vW = videoSource.VideoResolution.FrameSize.Width;
                vH = videoSource.VideoResolution.FrameSize.Height;
            }

            if (vW <= 0) vW = 480;
            if (vH <= 0) vH = 360;
             
            double area1 = 0;
            double area2 = 0;
            double area3 = 0;
            double area4 = 0;

           
            double realRate = 1;
            double maxArea = 0;

            //根据宽度缩放
            double zoomRate1 = (double)panlVideoBack.Width / vW;
            area1 = (vW * zoomRate1) * (vH * zoomRate1);
            if (vW * zoomRate1 > panlVideoBack.Width || vH * zoomRate1 > panlVideoBack.Height) area1 = 0;

            double zoomRate2 = (double)panlVideoBack.Height / vW;
            area2 = (vW * zoomRate2) * (vH * zoomRate2);
            if (vW * zoomRate2 > panlVideoBack.Width || vH * zoomRate2 > panlVideoBack.Height) area2 = 0;

            realRate = (area2 > area1) ? zoomRate2 : zoomRate1;
            maxArea = (area2 > area1) ? area2 : area1;
            

            double zoomRate3 = (double)panlVideoBack.Width / vH;
            area3 = (vW * zoomRate3) * (vH * zoomRate3);
            if (vW * zoomRate3 > panlVideoBack.Width || vH * zoomRate3 > panlVideoBack.Height) area3 = 0;

            realRate = (area3 > maxArea) ? zoomRate3 : realRate;
            maxArea = (area3 > maxArea) ? area3 : maxArea;
            

            double zoomRate4 = (double)panlVideoBack.Height / vH;
            area4 = (vW * zoomRate4) * (vH * zoomRate4);
            if (vW * zoomRate4 > panlVideoBack.Width || vH * zoomRate4 > panlVideoBack.Height) area4 = 0;

            realRate = (area4 > maxArea) ? zoomRate4 : realRate;
            maxArea = (area4 > maxArea) ? area4 : maxArea;
            

            videoCamera.Width = (int)(vW * realRate);
            videoCamera.Height = (int)(vH * realRate);
                                      

            videoCamera.Left = (panlVideoBack.Width - videoCamera.Width) / 2;
            videoCamera.Top = (panlVideoBack.Height - videoCamera.Height) / 2; 
        }

        private void videoCamera_NewFrame(object sender, ref Bitmap image)
        {
            lock (objLockRecord)
            {
                if (_isStartRec == false)
                {
                    if (videoWriter != null) videoWriter.Close();

                    if (string.IsNullOrEmpty(_videoRecFile) == false)
                    {
                        //保存视频文件 
                        //_curMidiaInfo = new MediaData();

                        //_curMidiaInfo.Bmp = null;
                        //_curMidiaInfo.MediaType = MediaType.mtVideo;
                        //_curMidiaInfo.MediaFile = _videoRecFile;
                                                                         


                        //后台数据传输处理...
                        TransferFile(GetImageVpath(), _videoRecFile, MediaType.视频);

                        _videoRecFile = "";

                        //if (_designEvents.Count > 0)
                        //{
                        //    if (_designEvents.ContainsKey(CaptureProviderEventDefine.Event_AfterRecordVideo))
                        //    {
                        //        DoBindActions(_designEvents[CaptureProviderEventDefine.Event_AfterRecordVideo]);
                        //    }
                        //}

                        //弹出提示
                        string strPar = "AVI" + "," + _mainHandle.ToString() + "," + ((_cc.SoundHint) ? "1" : "0");
                        System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + @"\zl9PacsImageHint.exe", strPar);
                    }

                    return;
                }


                //录像
                Graphics g = Graphics.FromImage(image);
                SolidBrush drawBrush = new SolidBrush(Color.Yellow);
                SolidBrush dotBrush = new SolidBrush(Color.Red);

                _recFrameCount = _recFrameCount + 1;

                Font drawFont = new Font("Arial", 4, FontStyle.Regular, GraphicsUnit.Millimeter);
                int xPos = 2;
                int yPos = 2;

                //写到屏幕上的时间
                drawDate = "●"; // DateTime.Now.ToString("●");

                if ((_recFrameCount % 4) == 0)
                {
                    g.DrawString(drawDate, drawFont, dotBrush, xPos, yPos - 1);
                }
                else
                {
                    dotBrush.Color = Color.Transparent;
                    g.DrawString(drawDate, drawFont, dotBrush, xPos, yPos);
                }

                if (_cc.RecordDate)
                {
                    drawDate = DateTime.Now.ToString("  HH:mm:ss");
                    g.DrawString(drawDate, drawFont, drawBrush, xPos + 4, yPos);
                }


                //开始录像
                if (createNewFile)
                {

                    createNewFile = false;
                    if (videoWriter != null)
                    {
                        videoWriter.Close();
                        videoWriter.Dispose();
                    }
                    videoWriter = new VideoFileWriter();
                    //这里必须是全路径，否则会默认保存到程序运行根据录下了
                    int frameRate = (_cc.FrameRate <= 0) ? 20 : _cc.FrameRate;

                    videoWriter.Open(_videoRecFile, image.Width, image.Height, frameRate, _cc.VideoEncode);
                    videoWriter.WriteVideoFrame(image);

                }
                else
                {
                    videoWriter.WriteVideoFrame(image);
                }
            }
        }
    }
}

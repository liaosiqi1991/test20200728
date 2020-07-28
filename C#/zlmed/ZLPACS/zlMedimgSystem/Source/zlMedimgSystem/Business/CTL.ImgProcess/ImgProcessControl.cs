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
using zlMedimgSystem.BusinessBase;
using System.IO;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.ImgProcess
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(ImgProcessControl), "Resources.palette_text.ico")]
    public partial class ImgProcessControl : DesignComponent, ISysBizModule, ISysDesign, IBizDataQuery
    {

        static public class ImgActionDefine
        {
            public const string OpenImageProcess = "图像处理";
            public const string OpenImagePreview = "图像预览";
            public const string CloseImagePreview = "关闭预览";
        }

        static public class ImgDataDefine
        {
            public const string CurrentImage = "当前图像";
        }

        static public class ImgEventDefine
        {
            public const string SaveModifyImage = "图像保存事件";
            public const string AddReportImage = "报告图添加事件";

        }



        private string _applyId = "";
        private string _selectImgId = "";

        public ImgProcessControl()
        {
            InitializeComponent();
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "图像处理";
            _category = "后台业务";


            _provideActionDesc.Add(ImgActionDefine.OpenImageProcess, "打开图像处理窗口，请求数据项如下：" 
                                                                    + System.Environment.NewLine 
                                                                    + "applyid,mediaid");
            _provideActionDesc.Add(ImgActionDefine.OpenImagePreview, "打开图像预览窗口");
            _provideActionDesc.Add(ImgActionDefine.CloseImagePreview, "关闭图像预览窗口");

            _provideDataDesc.AddDataDescription(_moduleName, ImgDataDefine.CurrentImage, "当前处理的图像数据,返回数据项如下："
                                                                + System.Environment.NewLine 
                                                                + "applyid,mediaid,serialid,storageid,order,mediatype,medianame,iskeyimage,isreportimage,localfile,vpath");


            _designEvents.Add(ImgEventDefine.SaveModifyImage, new EventActionReleation(ImgEventDefine.SaveModifyImage, ActionType.atSysFixedEvent));
            _designEvents.Add(ImgEventDefine.AddReportImage, new EventActionReleation(ImgEventDefine.AddReportImage, ActionType.atSysFixedEvent));
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
                case ImgDataDefine.CurrentImage:
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
                case ImgDataDefine.CurrentImage:
                    resultDatas = new BizDataItems();

                    dataItem = new BizDataItem();
                     
                    if (_imageInfo == null) return null;

                    dataItem.Add(DataHelper.StdPar_ApplyId, _applyId);
                    dataItem.Add(DataHelper.StdPar_MediaId, _imageInfo.MediaId); 
                    dataItem.Add(DataHelper.StdPar_SerialId, _imageInfo.SerialId);
                    dataItem.Add(DataHelper.StdPar_StorageId, _imageInfo.StorageId);
                    dataItem.Add(DataHelper.StdPar_MediaOrder, _imageInfo.Order);
                    dataItem.Add(DataHelper.StdPar_MediaType, _imageInfo.MediaType);
                    dataItem.Add(DataHelper.StdPar_MediaName, _imageInfo.MediaName);
                    dataItem.Add(DataHelper.StdPar_IsKeyImage, _imageInfo.IsKeyImage);
                    dataItem.Add(DataHelper.StdPar_IsReportImage, _imageInfo.IsReportImage);
                    dataItem.Add(DataHelper.StdPar_LocalFile, _imageInfo.File);
                    dataItem.Add(DataHelper.StdPar_VPath, _imageInfo.VPath);


                    resultDatas.Add(dataItem);

                    return resultDatas;

                default:
                    return null;
            }
        }
        
        public override void ChangeModuleStyle(string styleName)
        {
        }


        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            switch (actName)
            {
                case ImgActionDefine.OpenImageProcess://打开单张图像  

                    if (bizDatas == null) return false; 

                    _applyId = DataHelper.GetItemValueByApplyId(bizDatas[0]);

                    _selectImgId = DataHelper.GetItemValueByImageId(bizDatas[0]);

                    OpenImageProcess();

                    break;

                case ImgActionDefine.OpenImagePreview://打开单图预览 
                    if (bizDatas == null) return false; 


                    string file = DataHelper.GetItemValueByFile(bizDatas[0]);

                    if (File.Exists(file) == false) return false;

                    ImagePreview.ShowImagePreview(file, 3000, this);
                    break;

                case ImgActionDefine.CloseImagePreview:
                    ImagePreview.CloseImagePreview();

                    break;


                default:
                    break;
            }

            return true;
        }


        private void OpenImageProcess()
        {
            frmImageProcess imageProcess = new frmImageProcess();

            imageProcess.OnImageSave += SaveModifyImage;
            imageProcess.OnAddReportImage += AddReportImage;

            imageProcess.ShowImgProcess(_dbQuery,_userData,  _applyId, _selectImgId, this);
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

        private TileImageInfo _imageInfo = null;
        private void SaveModifyImage(TileImageInfo imageInfo)
        {
            try
            {
                _imageInfo = imageInfo;

                DoActions(_designEvents[ImgEventDefine.SaveModifyImage], this);

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void AddReportImage(TileImageInfo imageInfo)
        {
            try
            {
                _imageInfo = imageInfo;

                DoActions(_designEvents[ImgEventDefine.AddReportImage], this);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

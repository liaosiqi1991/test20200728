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

namespace zlMedimgSystem.CTL.WebBrowserEx
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(WebBrowserExControl), "Resources.web_view.ico")]
    public partial class WebBrowserExControl : DesignControl, ISysBizModule, ISysDesign, IBizDataQuery
    {

        static public class WebProviderActionDefine
        {
            public const string Action_OpenUrl = "打开网页"; 
        }


        public WebBrowserExControl()
        {
            InitializeComponent();
        }


        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "网页模块";
            _category = "基础控件";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideActionDesc.Add(WebProviderActionDefine.Action_OpenUrl, "打开执行标记指定的地址"); 



            //_provideDataDesc.AddDataDescription(_moduleName, ImageProviderDataDefine.Data_SelImageData, "取得当前选择的媒体数据");
            //_provideDataDesc.AddDataDescription(_moduleName, ImageProviderDataDefine.Data_ChkImageData, "取得当前采集到的媒体数据");


            //_designEvents.Add(ImageProviderEventDefine.Event_MediaDblClick, new EventActionReleation(ImageProviderEventDefine.Event_MediaDblClick, ActionType.atSysFixedEvent));
            //_designEvents.Add(ImageProviderEventDefine.Event_MediaClick, new EventActionReleation(ImageProviderEventDefine.Event_MediaClick, ActionType.atSysFixedEvent));
        }


        /// <summary>
        /// 刷新
        /// </summary>
        public override void RefreshModule()
        {
        }


        public override IBizDataItems QueryDatas(string dataIdentificationName)
        {
            //BizDataItems resultDatas = null;
            //BizDataItem dataItem = null;

            //string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            //switch (dataName)
            //{                 
            //    default:
            //        return null;
            //}

            return null;
        }
         
        public override void ChangeModuleStyle(string styleName)
        {
        }

        private IList<string> GetParsName(string source)
        {
            int index = source.IndexOf("[@");
            if (index <= 0) return null;

            string pars = source;
            string parName = "";

            List<string> result = new List<string>();

            while (index > 0)
            {
                pars = source.Substring(index);

                parName = pars.Substring(2, pars.IndexOf("]") - 2);
                result.Add(parName);

                pars = pars.Substring(pars.IndexOf("]") + 1);
                index = pars.IndexOf("[@");
            }

            return result;
        }

        private string ParseExecuteTag(string tag, IBizDataItems bizDatas)
        {
            string context = tag;

            if (bizDatas != null)
            {
                IList<string> pars = GetParsName(context);
                 
                if (bizDatas.Count > 0)
                {
                    foreach (string par in pars)
                    {
                        context = context.Replace("[@" + par + "]", bizDatas[0][par].ToString());
                    }
                }
                else
                {
                    foreach (string par in pars)
                    {
                        context = context.Replace("[@" + par + "]", "null");
                    }
                }
            }

            return context;
        }

        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            switch (actName)
            {
                case WebProviderActionDefine.Action_OpenUrl://打开网页
                    string urlAddres = ParseExecuteTag(tag, bizDatas);

                    webBrowser1.Url = new Uri(urlAddres);

                    break; 

                default:
                    break;
            }

            return true;
        }

    }
}

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

namespace zlMedimgSystem.CTL.Sysplugin
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(SyspluginControl), "Resources.plugin.ico")]
    public partial class SyspluginControl :  DesignComponent, ISysBizModule, ISysDesign, IBizDataQuery
    {
        public SyspluginControl()
        {
            InitializeComponent();
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "附加调用";
            _category = "后台业务";


            _provideActionDesc.Add("远程", "打开远程链接");
            _provideActionDesc.Add("医嘱", "查看医嘱内容");
            _provideActionDesc.Add("费用", "查看费用明细");

            //_provideDatas.Add("", "");
            

            //_designEvents.Add("", new EventActionReleation("", ActionType.atSysFixedEvent)); 
        }

        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            switch(actName)
            {
                case "远程":
                    OpenRemote();

                    break;

                case "医嘱":
                    break;

                case "费用":
                    break;

                default:
                    break;
            }

            return true;
        }


        private void OpenRemote()
        {
            string remotePath = System.Windows.Forms.Application.StartupPath + @"\Remote\ZLScreenChatControl.exe";

            System.Diagnostics.Process.Start(remotePath);
        }
    }
}

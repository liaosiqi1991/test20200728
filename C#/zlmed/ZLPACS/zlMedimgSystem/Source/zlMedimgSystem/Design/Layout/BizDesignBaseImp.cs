using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.Layout
{
    public partial class BizDesignBase: ISysDesign, ISysMainModule, IBizDataQuery
    {

        protected string _moduleName = "";
        protected bool _multiInstance = false; 
        protected string _title = "医学影像系统";

        protected CoordinationBizModules _regBizModules = null;

        protected Dictionary<string, string> _provideActionDesc = null;
        protected Dictionary<string, string> _provideDataDesc = null;
         
        protected Dictionary<string, EventActionReleation> _designEvents = null; 
         
        private string _designEventSerialFmt = ""; 
        private string _customDesignFmt = "";
        private string _rclickMenuDesignFmt = "";


        private string _OriginalName = "";

        [Bindable(false), Browsable(false)]
        public string OriginalModule
        {
            get { return _OriginalName; }
        }

        protected void InitModuleInterfacce()
        {
            _regBizModules = new CoordinationBizModules(); 

            _provideActionDesc = new Dictionary<string, string>();
            _provideDataDesc = new Dictionary<string, string>();
             
            _designEvents = new Dictionary<string, EventActionReleation>(); 


            InitBaseInfo();

            _OriginalName = _moduleName;
        }


        public string GetSerializableFmt()
        {

            Dictionary<string, object> serial = new Dictionary<string, object>();

            serial.Add("BackColor", BackColor); 
            serial.Add("DesignEventSerialFmt", DesignEventSerialFmt);

            serial.Add("CustomDesignFmt", CustomDesignFmt);
            serial.Add("ForeColor", ForeColor);
            serial.Add("ImeMode", ImeMode); 
            serial.Add("TabIndex", TabIndex); 

            return DictionaryJsonHelper.SerializeDictionaryToJsonString<string, object>(serial);
        }

        public void SetSerializableFmt(string fmt)
        {
            if (string.IsNullOrEmpty(fmt)) return;

            Dictionary<string, object> serial = DictionaryJsonHelper.DeserializeStringToDictionary<string, object>(fmt);

            if (serial.Count <= 0) return;

 
            try { if (serial.ContainsKey("BackColor")) BackColor = Color.FromArgb(Convert.ToInt32(serial["BackColor"])); } catch (Exception ex) { MsgBox.ShowException(ex); }

            try { if (serial.ContainsKey("DesignEventSerialFmt")) DesignEventSerialFmt = (string)serial["DesignEventSerialFmt"]; } catch (Exception ex) { MsgBox.ShowException(ex); }
            try { if (serial.ContainsKey("CustomDesignFmt")) CustomDesignFmt = (string)serial["CustomDesignFmt"]; } catch (Exception ex) { MsgBox.ShowException(ex); }
            try { if (serial.ContainsKey("ForeColor")) ForeColor = Color.FromArgb(Convert.ToInt32(serial["ForeColor"])); } catch (Exception ex) { MsgBox.ShowException(ex); }
            try { if (serial.ContainsKey("ImeMode")) ImeMode = (ImeMode)(Convert.ToInt32(serial["ImeMode"])); } catch (Exception ex) { MsgBox.ShowException(ex); }

            try { if (serial.ContainsKey("TabIndex")) TabIndex = Convert.ToInt32(serial["TabIndex"]); } catch (Exception ex) { MsgBox.ShowException(ex); }
        }


        protected virtual void InitBaseInfo()
        {
            //throw new Exception("方法InitBaseInfo尚未实现.");
        }


        public IBizDataItems QueryDatas(string dataIdentificationName)
        {
            return null;
        }

        public virtual bool HasData(string dataIdentificationName)
        {
            return false;
        }

        public virtual void ShowDesignHelper()
        {

        }

        public virtual bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            throw new Exception("方法ExecuteAction尚未实现.");
        }

        public virtual string ShowCustomDesign()
        {
            return "";
        }

        public virtual string ShowRClickMenuDesign()
        {
            return "";
        }

        public virtual void ModuleLoaded()
        {
            throw new Exception("方法ReloadLayout尚未实现.");
        }

        /// <summary>
        /// 初始化标题
        /// </summary>
        private void InitTitle()
        {
            _title = AppSetting.ReadSetting("apptitle");
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title"></param>
        private void SetTitle(string title)
        {
            AppSetting.WriteSetting("apptitle", title);
        }


        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CoordinationBizModules RelateModules
        {
            get { return _regBizModules; }
            set { _regBizModules = value; }
        }


        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IBizDataTransferCenter DataCenter
        {
            get { return _dataTransCenter; } 
        }

        public string ModuleName
        {
            get { return _moduleName; }
            set
            {
                if (MultiInstance == false) return;
                _moduleName = value;
            }
        }

        public string Category
        {
            get { return ""; }
        }

        public string Description
        {
            get { return ""; }
        }

        public bool MultiInstance
        {
            get { return _multiInstance; }
        }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CustomDesignFmt
        {
            get { return _customDesignFmt; }
            set { _customDesignFmt = value; }
        }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RClickMenuDesignFmt
        {
            get { return _rclickMenuDesignFmt; }
            set { _rclickMenuDesignFmt = value; }
        }


        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Localizable(true)]
        [Category("Appearance")]
        [Description("Actions")]
        public Dictionary<string, string> ProvideActions
        {
            get
            {
                return _provideActionDesc;
            }
        }


        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Localizable(true)]
        [Category("Appearance")]
        [Description("Datas")]
        public Dictionary<string, string> ProvideDatas
        {
            get
            {
                return _provideDataDesc;
            }
        }



        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Dictionary<string, EventActionReleation> DesignEvents
        {
            get
            {
                return _designEvents;
            }
            set
            {
                _designEvents = value;


            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Editor(typeof(EventProEditor), typeof(UITypeEditor))]
        [Localizable(true)]
        [Category("Appearance")]
        [Description("Events")]
        public string DesignEventSerialFmt
        {
            get
            {
                return _designEventSerialFmt;
            }
            set
            {
                _designEventSerialFmt = value;

                if (string.IsNullOrEmpty(value)) return;

                _designEvents = DictionaryJsonHelper.DeserializeStringToDictionary<string, EventActionReleation>(_designEventSerialFmt);// JsonConvert.DeserializeObject<Dictionary<string, EventActionReleation>>(_designEventSerialFmt);
            }

        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Localizable(true)]
        [Category("Appearance")]
        [Description("Title")]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;


                if (string.IsNullOrEmpty(value) && _isDesignMode )
                {
                    Text = " ";
                }
                else
                {
                    Text = value;
                }
                
                SetTitle(_title);
            }
        }


        /// <summary>
        /// 执行绑定事件
        /// </summary>
        /// <param name="ea"></param>
        /// <returns></returns>
        protected bool DoBindActions(EventActionReleation ea, object sender, object eventArgs = null)
        {
            if (_regBizModules.Count <= 0) return true;

            string moduleName = "";
            string methodName = "";
            foreach (KeyValuePair<string, ActionItem> act in ea.Actions)
            {
                moduleName = act.Key.Split('.')[0];
                methodName = act.Key.Split('.')[1];

                ISysDesign exeModule = null;
                if (act.Value.IsParentModule)
                {
                    if (_regBizModules.ParentWindowBizModules == null)
                    {
                        exeModule = null;
                    }
                    else
                    {
                        if (_regBizModules.ParentWindowBizModules.ContainsKey(moduleName))
                        {
                            exeModule = _regBizModules.ParentWindowBizModules[moduleName];
                        }
                    }
                }
                else
                {
                    if (_regBizModules.ContainsKey(moduleName))
                    {
                        exeModule = _regBizModules[moduleName];
                    }
                }

                if (exeModule == null)
                {
                    if (MessageBox.Show("[" + moduleName + "] 未能加载，不能执行该模块方法， 是否继续？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return false;
                    }
                }


                ActionItem ai = act.Value;

                IBizDataItems bizDatas = null;
                if (string.IsNullOrEmpty(ai.RequestDataName) == false)
                {
                    bizDatas = GetDataItem(_moduleName, ai, ai.RequestDataName);
                    if (bizDatas == null) return false;

                    bizDatas.DataName = ai.RequestDataName;
                }


                if (bizDatas != null)
                {
                    foreach (string requestDataName in ai.RequestAttachDataNames)
                    {
                        IBizDataItems curRequestData = GetDataItem(_moduleName, ai, requestDataName);

                        bizDatas.AttachDatas.Add(curRequestData);
                    }
                }

                if (exeModule.ExecuteAction(_moduleName, this, sender, act.Value.ActName, act.Value.ActTag, bizDatas) == false) return false;
            }

            return true;
        }

        private IBizDataItems GetDataItem(string moduleName, ActionItem ai, string requestDataName)
        {
            IBizDataItems dataItems = null;
            if (ai.IsParentModuleData)
            {
                if (_dataTransCenter.ParentDataCenter == null) return null;
                //查询父级窗口中的数据
                dataItems = _dataTransCenter.ParentDataCenter.GetBizDataQuery(requestDataName);
            }
            else
            {
                dataItems = _dataTransCenter.GetBizDataQuery(requestDataName);
            }

            if (dataItems == null)
            {
                MessageBox.Show("(" + moduleName + "." + ai.ActName + ")未找到所请求的数据，请求数据为 [" + requestDataName + "]。", "提示");
                return null;
            }

            if (dataItems.Count <= 0)
            {
                MessageBox.Show("(" + moduleName + "." + ai.ActName + ")未找到对应的数据项，请求数据为 [" + requestDataName + "]。", "提示");
                return null;
            }

            return dataItems;
        }
    }
}

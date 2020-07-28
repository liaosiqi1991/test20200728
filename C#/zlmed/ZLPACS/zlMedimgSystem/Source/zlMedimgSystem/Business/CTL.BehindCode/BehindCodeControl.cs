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

namespace zlMedimgSystem.CTL.BehindCode
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(BehindCodeControl), "Resources.cscode.ico")]
    public partial class BehindCodeControl : DesignComponent, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class BehindCodeActionDefine
        {
            public const string BehindRun = "动态执行";
        }

        static public class BehindCodeDataDefine
        {
            public const string SourceData = "原始数据";
            public const string ProcessData = "处理后数据";
        }

        private BehindCodeModuleDesign _codeDesign = null;

        public BehindCodeControl()
        {
            InitializeComponent();

            _codeDesign = new BehindCodeModuleDesign();
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "动态代码";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideDataDesc.AddDataDescription(_moduleName, BehindCodeDataDefine.SourceData, "返回代码执行前的原始数据");
            _provideDataDesc.AddDataDescription(_moduleName, BehindCodeDataDefine.ProcessData, "返回代码执行后的数据");

            _provideActionDesc.Add(BehindCodeActionDefine.BehindRun, "动态执行后台函数调用,如果设置了执行标记，则根据执行标记执匹配方法名称进行对应的执行。"); 

            //_designEvents.Add(TimerEventDefine.Interval, new EventActionReleation(TimerEventDefine.Interval, ActionType.atSysFixedEvent));

        }

        private bool DoActions(string actionName, object sender, object eventArgs)
        {
            try
            {
                if (_designEvents.ContainsKey(actionName))
                {
                    return base.DoBindActions(_designEvents[actionName], sender, eventArgs);
                }

                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case BehindCodeDataDefine.ProcessData:
                    return true;

                case BehindCodeDataDefine.SourceData:
                    return true;

                default:
                    return false;
            }
        }


        public override IBizDataItems QueryDatas(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            switch (dataName)
            {
                case BehindCodeDataDefine.ProcessData:
                    return _curProcessData;

                case BehindCodeDataDefine.SourceData:
                    return _curSourceData;

                default:
                    return null;
            }
        }

        
        private IBizDataItems _curSourceData = null;
        private IBizDataItems _curProcessData = null;

        private Runner _runner = null;
        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {
                _curSourceData = bizDatas;
                switch (actName)
                {
                    case BehindCodeActionDefine.BehindRun:

                        bool runResult = false;

                        if (string.IsNullOrEmpty(tag))
                        {
                            if (_runner == null)
                            {
                                _runner = new Runner();
                                _runner.Init(_winKey, _moduleName, _relateBizModules, _dbQuery, _userData, _stationInfo, _dataTransCenter, this);
                            }
                            
                            foreach (BehindCodeItem bci in _codeDesign.BehindCodes)
                            {
                                if (DoActions(bci.FuncName + "执行前", sender, eventArgs) == false) continue;

                                if (string.IsNullOrEmpty(bci.FuncContext)) continue;
                                                               
                                bool curResult = _runner.Run(bci, callModuleName, callModule, sender, eventArgs, actName, tag, 
                                    bizDatas, out _curProcessData);

                                //执行成功才需要执行后续的调用
                                if (curResult)
                                {
                                    runResult = curResult;

                                    DoActions(bci.FuncName + "执行后", sender, eventArgs);
                                }
                            }
                        }
                        else
                        {
                            int mIndex = _codeDesign.BehindCodes.FindIndex(T => T.FuncName == tag);
                            if (mIndex >= 0)
                            {                                
                                BehindCodeItem bci = _codeDesign.BehindCodes[mIndex];

                                if (DoActions(bci.FuncName + "执行前", sender, eventArgs) == false) return false;

                                if (string.IsNullOrEmpty(bci.FuncContext)) return false;

                                if (_runner == null)
                                {
                                    _runner = new Runner();
                                    _runner.Init(_winKey, _moduleName, _relateBizModules, _dbQuery, _userData, _stationInfo, _dataTransCenter, this);
                                }
                                
                                runResult = _runner.Run(bci, callModuleName, callModule, sender, eventArgs, actName, tag, 
                                    bizDatas, out _curProcessData);

                                //执行成功才需要执行后续的调用
                                if (runResult)
                                {
                                    DoActions(bci.FuncName + "执行后", sender, eventArgs);
                                }
                            }
                        }


                        return runResult;
                         

                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
                return false;
            }
        }

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _codeDesign = JsonHelper.DeserializeObject<BehindCodeModuleDesign>(customContext);

            InitCodeEvent();

        }

        public override void ModuleLoaded()
        {
            base.ModuleLoaded();

            if (DesignMode == false)
            {
                DoBGCodeCompile();
            }
        }


        private void DoBGCodeCompile()
        {
            if (_runner == null)
            {
                _runner = new Runner();
                _runner.Init(_winKey, _moduleName, _relateBizModules, _dbQuery, _userData, _stationInfo, _dataTransCenter, this);
            }

            BackgroundWorker bgWork = new BackgroundWorker();

            bgWork.DoWork += DoWork;
            bgWork.ProgressChanged += ProgessChanged;
            bgWork.RunWorkerCompleted += WorkerCompleted;

            bgWork.WorkerReportsProgress = false;
            bgWork.WorkerSupportsCancellation = true;

            bgWork.RunWorkerAsync(_codeDesign);
        }

        private object objLockWork = new object();
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                throw new Exception("后台代码编译参数传递无效。");
            }


            BehindCodeModuleDesign curCodeDesign = e.Argument as BehindCodeModuleDesign;
            if (curCodeDesign == null)
            {
                throw new Exception("后台代码编译参数传递无效。");
            }

            try
            {
                lock (objLockWork)
                {
                    foreach (BehindCodeItem bci in curCodeDesign.BehindCodes)
                    {
                        if (bci.IsBGCompile)
                        {
                            _runner.BGCompiler(bci);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("后台代码编译失败", ex);
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

        public string ShowDesign(BehindCodeModuleDesign codeDesign)
        {
            using (frmBehindCodeModuleDesign design = new frmBehindCodeModuleDesign())
            {
                design.ShowBehindCodeDesign(_dbQuery, _codeDesign, this);
            }

            InitCodeEvent();

            return JsonHelper.SerializeObject(_codeDesign);
        }

        public override string ShowCustomDesign()
        {
            _customDesignFmt = ShowDesign(_codeDesign);

            return _customDesignFmt;
        }
         
        private void InitCodeEvent()
        {
            //_designEvents.Clear();
            foreach (BehindCodeItem bci in _codeDesign.BehindCodes)
            {
                if (_designEvents.ContainsKey(bci.FuncName + "执行前") == false)
                {
                    _designEvents.Add(bci.FuncName + "执行前", new EventActionReleation(bci.FuncName + "执行前", ActionType.atSysCustomEvent));
                }

                if (_designEvents.ContainsKey(bci.FuncName + "执行后") == false)
                    {
                    _designEvents.Add(bci.FuncName + "执行后", new EventActionReleation(bci.FuncName + "执行后", ActionType.atSysCustomEvent));
                }
            }

            List<string> keys = new List<string>(_designEvents.Keys);

            foreach(string key in keys)
            {
                string curKey = key.Replace("执行前", "").Replace("执行后", "");
                if (_codeDesign.BehindCodes.FindIndex(T=>T.FuncName == curKey) < 0)
                {
                    _designEvents.Remove(key);
                }
            }

        }

    }
}

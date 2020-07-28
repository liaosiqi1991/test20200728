using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.BehindCode
{
    public class Runner
    {
        private string _winKey = "";
        private string _moduleName = "";
        private CoordinationBizModules _winRelateModules = null;
        private IDBQuery _dbHelper = null; 
        private ILoginUser _userData = null;
        private IStationInfo _stationInfo = null;
        private IBizDataTransferCenter _dataTransCenter = null;
        private IWin32Window _owiner = null;

        private bool _isAllowDebug = false;

        public Runner()
        {
            _isAllowDebug = AppSetting.ReadBool("允许动态代码调试", false);
            AppSetting.WriteBool("允许动态代码调试", _isAllowDebug);
        }

        public bool IsAllowDebug
        {
            get { return _isAllowDebug; }
            set { _isAllowDebug = value; }
        }

        public void Init(string winKey, string moduleName, CoordinationBizModules winRelateModules, IDBQuery dbHelper, ILoginUser userData, IStationInfo stationInfo, IBizDataTransferCenter dataTransCenter, IWin32Window owner)
        {
            _winKey = winKey;
            _moduleName = moduleName;
            _winRelateModules = winRelateModules;
            _dbHelper = dbHelper; 
            _userData = userData;
            _stationInfo = stationInfo;
            _dataTransCenter = dataTransCenter;
            _owiner = owner;
        }


        /// <summary>
        /// 编译代码
        /// </summary>
        /// <param name="codeKey"></param>
        /// <param name="thridDbAlias"></param>
        /// <param name="codeSource"></param> 
        private IRunner CompilerCode(BehindCodeItem compileCode)
        {

            

            IRunner StartCompile(string compilePath, string assemblyName)
            {
                var providerOptions = new Dictionary<string, string>();
                providerOptions.Add("CompilerVersion", "v4.0");

                CSharpCodeProvider codeProvider = new CSharpCodeProvider(providerOptions);

                CompilerParameters compilerParameters = new CompilerParameters();


                compilerParameters.IncludeDebugInformation = false;
                compilerParameters.TreatWarningsAsErrors = false;
                compilerParameters.GenerateExecutable = false;
                compilerParameters.GenerateInMemory = !compileCode.IsBGCompile;
                compilerParameters.CompilerOptions = "/optimize";//优化

                if (_isAllowDebug)
                {
                    compilerParameters.CompilerOptions = "";
                    compilerParameters.IncludeDebugInformation = true;
                    compilerParameters.GenerateInMemory = true;
                }

                compilerParameters.ReferencedAssemblies.Add("mscorlib.dll");
                compilerParameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
                compilerParameters.ReferencedAssemblies.Add("System.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Data.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Data.DataSetExtensions.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Xml.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Xml.Linq.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Transactions.dll");

                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\DevExpress.Data.v15.1.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\DevExpress.Utils.v15.1.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\DevExpress.XtraEditors.v15.1.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\DevExpress.XtraGrid.v15.1.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\DevExpress.XtraBars.v15.1.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\DevExpress.XtraLayout.v15.1.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\DevExpress.XtraNavBar.v15.1.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\DevExpress.XtraReports.v15.1.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\DevExpress.XtraScheduler.v15.1.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\DevExpress.XtraScheduler.v15.1.Core.dll");

                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\zlMedimgSystem.Interface.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\zlMedimgSystem.Services.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\zlMedimgSystem.Design.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\zlMedimgSystem.Layout.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\zlMedimgSystem.DataModel.dll");
                compilerParameters.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + @"\zlMedimgSystem.BusinessBase.dll");

                compilerParameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);


                string[] source = new string[1];
                source[0] = compileCode.FuncContext;


                if (_isAllowDebug)
                {
                    compilerParameters.TempFiles = new TempFileCollection(Dir.GetAppDebugDir());
                    //compilerParameters.OutputAssembly = Dir.GetAppDebugDir() + @"\" + assemblyName;
                }
                else
                {
                    if (compileCode.IsBGCompile)
                    {
                        compilerParameters.TempFiles = new TempFileCollection(compilePath);
                        compilerParameters.OutputAssembly = compilePath + @"\" +  assemblyName;
                    }
                }

                CompilerResults compilerResults =
                codeProvider.CompileAssemblyFromSource(compilerParameters, source);

                if (_isAllowDebug)
                {
                    string debugFile = compilerParameters.OutputAssembly.Replace(".dll", ".0.cs");
                    using (StreamWriter swcs = new StreamWriter(debugFile))
                    {
                        swcs.Write(source[0]);
                    }
                }

                StringWriter sw = new StringWriter();
                foreach (CompilerError ce in compilerResults.Errors)
                {
                    if (ce.IsWarning) continue;
                    sw.WriteLine("{0}({1},{2}: error {3}: {4}", ce.FileName, ce.Line, ce.Column, ce.ErrorNumber, ce.ErrorText);
                }

                string errorText = sw.ToString();
                if (errorText.Length > 0)
                    throw new ApplicationException(errorText);

                Assembly ass = compilerResults.CompiledAssembly;
                var obj = ass.GetTypes().FirstOrDefault();

                return Activator.CreateInstance(obj) as IRunner;
            }

            IRunner runner = null;
            string curAssemblyName = _winKey + "_" + _moduleName + "_" + compileCode.FuncName + "_V" + Convert.ToString(compileCode.VerNo) + ".dll";
            string assemblyFullName = Dir.GetAppCompileDir() + @"\" + curAssemblyName;
 

            if (compileCode.IsBGCompile && _isAllowDebug == false)
            {
                if (File.Exists(assemblyFullName))
                {
                    Assembly ass = Assembly.LoadFile(assemblyFullName);
                    var obj = ass.GetTypes().FirstOrDefault();

                    runner = Activator.CreateInstance(obj) as IRunner;
                }
                else
                {
                    runner = StartCompile(Dir.GetAppCompileDir(), curAssemblyName);
                }
            }
            else
            {
                runner = StartCompile(Dir.GetAppCompileDir(), curAssemblyName);
            }

            return runner;
 
        }


        /// <summary>
        /// 后台编译
        /// </summary>
        /// <param name="compileCode"></param>
        public void BGCompiler(BehindCodeItem compileCode)
        {
            //非调试模式下才能进行后台编译
            if (compileCode.IsBGCompile && _isAllowDebug == false)
            {
                IRunner runner = CompilerCode(compileCode);

                if (runner != null)
                {
                    if (_compilerObj == null)
                    {
                        _compilerObj = new Dictionary<string, IRunner>();
                    }

                    _compilerObj.Remove(compileCode.FuncName);

                    _compilerObj.Add(compileCode.FuncName, runner);
                }
            }
        }

        private Dictionary<string, IRunner> _compilerObj = null; 

        public bool Run(BehindCodeItem compileCode, string callModuleName, ISysDesign callModule, object sender, object eventArgs, string actName, string actTag,
            IBizDataItems sourceBizDatas, out IBizDataItems processBizDatas, bool isBuffer = true)
        {
            processBizDatas = null;

            if (_compilerObj == null)
            {
                _compilerObj = new Dictionary<string, IRunner>();
            }

            if (_isAllowDebug)
            {
                _compilerObj.Remove(compileCode.FuncName);
            }

            IRunner runner = null;
            if (_compilerObj.ContainsKey(compileCode.FuncName))
            {
                runner = _compilerObj[compileCode.FuncName];
            }
            else
            {
                runner = CompilerCode(compileCode);

                if (isBuffer && _isAllowDebug == false)
                {
                    //缓存编译对象
                    //调试状态不缓存编译对象
                    _compilerObj.Add(compileCode.FuncName, runner);
                }
            } 

            if (runner != null)
            {
                IDBQuery thridDb = null;

                if (string.IsNullOrEmpty(compileCode.ThridDBAlias) == false)
                {
                    string strErr = "";
                    thridDb = SqlHelper.GetThridDBHelper(compileCode.ThridDBAlias, _dbHelper, ref strErr);
                    if (thridDb == null)
                    {
                        MessageBox.Show("动态方法 [" + compileCode.FuncName + "] 对应的数据源 [" + compileCode.ThridDBAlias + "] 链接对象创建失败," + strErr, "提示");
                        return false;
                    }
                }

                runner.Init(_winRelateModules, _dbHelper, thridDb, _userData, _stationInfo, _dataTransCenter, _owiner);
                return runner.Run( callModuleName, callModule, sender, eventArgs, actName, actTag, sourceBizDatas, out processBizDatas);
            }

            return false;
        }
    }
}

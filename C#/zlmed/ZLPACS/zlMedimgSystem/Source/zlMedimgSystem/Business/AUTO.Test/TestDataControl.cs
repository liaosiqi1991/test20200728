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

namespace zlMedimgSystem.CTL.TestData
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(TestDataControl), "Resources.data.ico")]
    public partial class TestDataControl : DesignComponent, ISysBizModule, ISysDesign, IBizDataQuery
    {
        static public class TestDataDefine
        {
            public const string CurTestData = "当前测试数据";
        }

        static public class TestActionDefine
        {
            public const string CreateTestData = "创建测试数据";
        }
         



        private List<TestDataItem> _designDatas = null;
        private List<TestDataItem> _localDatas = null;


        public TestDataControl()
        {
            InitializeComponent();

            _designDatas = new List<TestDataItem>();

            string localDatas = AppSetting.ReadSetting(this.Name, "");

            if (string.IsNullOrEmpty(localDatas))
            {
                _localDatas = new List<TestDataItem>();
            }
            else
            {
                _localDatas = JsonHelper.DeserializeObject<List<TestDataItem>>(localDatas);
            }
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = true;
            _moduleName = "数据模拟";

            //_moduleStyles = new string[] { "样式一", "样式二" };

            _provideDataDesc.AddDataDescription(_moduleName, TestDataDefine.CurTestData, "");
            _provideActionDesc.Add(TestActionDefine.CreateTestData, "创建测试所需的模拟数据。");
                         

            //_designEvents.Add("", new EventAction("", ActionType.atFixed)); 
        }

        public override bool HasData(string dataIdentificationName)
        {
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            if (dataName == TestDataDefine.CurTestData) return true;

            return false;
        }


        public override IBizDataItems QueryDatas(string dataIdentificationName)
        {
            BizDataItems resultDatas = new BizDataItems();
            BizDataItem dataItem = new BizDataItem();
            string dataName = _provideDataDesc.FormatDataName(_moduleName, dataIdentificationName);

            if (dataName != TestDataDefine.CurTestData) return null;

            List<TestDataItem> curDatas = null;

            if (_designDatas != null && _designDatas.Count > 0) curDatas = _designDatas;
            if (_localDatas != null && _localDatas.Count > 0) curDatas = _localDatas;

            foreach (TestDataItem di in curDatas)
            {
                if (di.数据类型 == "字符串")
                {
                    dataItem.Add(di.数据名称, di.数据内容);
                }
                else if (di.数据类型 == "字典")
                {
                    dataItem.Add(di.数据名称, DictionaryJsonHelper.DeserializeStringToDictionary<string, string>(di.数据内容));
                }
                else
                {
                    dataItem.Add(di.数据名称, "不能识别的数据类型");
                }
                                
            }

            resultDatas.Add(dataItem);

            return resultDatas;
        }


        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _designDatas = JsonHelper.DeserializeObject<List<TestDataItem>>(customContext);

        }

        public override string ShowCustomDesign()
        {
            _customDesignFmt = ConstructorData(_designDatas); 

            return _customDesignFmt;
        }

        public string ConstructorData(List<TestDataItem> datas)
        {
            using (frmDataConstructor design = new frmDataConstructor())
            {
                design.ShowDesign(datas, this);
            }

            return JsonHelper.SerializeObject(datas);
        }

        public override bool ExecuteAction(string callModuleName, ISysDesign callModule, object sender, string actName, string tag, IBizDataItems bizDatas, object eventArgs = null)
        {
            try
            {

                switch (actName)
                {
                    case TestActionDefine.CreateTestData:
                        if (_localDatas == null || _localDatas.Count <= 0)
                        {
                            _localDatas = new List<TestDataItem>(_designDatas); 
                        }

                        string localDatas = ConstructorData(_localDatas);

                        AppSetting.WriteSetting(this.Name, localDatas);

                        return true;

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
    }
}

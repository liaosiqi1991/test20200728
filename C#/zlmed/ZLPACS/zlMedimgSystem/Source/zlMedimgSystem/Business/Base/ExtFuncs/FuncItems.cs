using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.ExtFuncs
{

    public static class FuncConstDefine
    {
        public const string Txt = "文本框";
        public const string RTxt = "富文本框";
        public const string Cbx = "下拉框";
        public const string Dtp = "日期框";
        //public const string List = "列表框";
        //public const string ChkBox = "下拉勾选框";
        //public const string ChkList = "列表勾选框";
        

    }

    [Serializable]
    public class InputItem : ISerializable
    {
        [DisplayName("名称")]
        public string Name { get; set; }

        [DisplayName("控件类型")]
        public string ControlType { get; set; }

        [DisplayName("默认值")]
        [Browsable(false)]
        public string DefaultValue { get; set; }

        [DisplayName("数据来源")]
        [Browsable(false)]
        public string DataFrom { get; set; }

        [DisplayName("是否存储"), DefaultValue(true)]
        [Browsable(false)]
        public bool AllowStorage { get; set; }

        [Browsable(false)]
        public Control LinkControl { get; set; }

        public InputItem()
        {
            AllowStorage = true;
        }

        public InputItem(string name, string controlType)
        {
            Name = name;
            ControlType = controlType;
        }

        public void CopyFrom(InputItem liSource)
        {
            Name = liSource.Name;
            ControlType = liSource.ControlType;
            DefaultValue = liSource.DefaultValue;
            DataFrom = liSource.DataFrom;
            AllowStorage = liSource.AllowStorage;
            LinkControl = liSource.LinkControl;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected InputItem(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            ControlType = info.GetString("ControlType");            
            DefaultValue = info.GetString("DefaultValue");
            DataFrom = info.GetString("DataFrom");
            AllowStorage = info.GetBoolean("AllowStorage");
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("ControlType", ControlType);
            info.AddValue("DefaultValue", DefaultValue);
            info.AddValue("DataFrom", DataFrom);
            info.AddValue("AllowStorage", AllowStorage);
        }
    }


    public class InputItems:Dictionary<string, InputItem>
    {
        public string SaveToString()
        {
            return DictionaryJsonHelper.SerializeDictionaryToJsonString<string, InputItem>(this);
        }

        public void LoadFromString(string inputItemFmts)
        {
            Dictionary<string, InputItem> inputs = DictionaryJsonHelper.DeserializeStringToDictionary<string, InputItem>(inputItemFmts);

            foreach(InputItem ii in inputs.Values)
            {
                Add(ii.Name, ii);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace zlMedimgSystem.Services
{
    public class PipeData
    {
        private const string DATA_ITEM_FROM = "<@数据来源>";
        private const string DATA_ITEM_NAME = "<@数据项名>";
        private const string DATA_ITEM_TAG = "<@数据标记>";
        private const string DATA_ITEM_RUNDOWN = "<@数据摘要>";
        private const string DATA_ITEM_COMMAND = "<@命令标识>";
        private const string DATA_ITEM_LASTERROR = "<@最后错误>";

        private string _dataFrom = "";          //数据来源
        private string _dataName = "";          //数据名称
        private string _dataTag = "";           //数据标记
        private string _dataRundown = "";       //数据摘要
        private string _CommandIdentify = "";   //命令标识
        private string _lastError = "";

        private Dictionary<string, string> _pipeData = null;

        public PipeData(string dataName = "")
        {
            _pipeData = new Dictionary<string, string>();

            _dataName = dataName;
            if (string.IsNullOrEmpty(_dataName) == true)
            {
                _dataName = "PD" + Guid.NewGuid().ToString("N");
            }
            SetValue(DATA_ITEM_NAME, _dataName);
            SetValue(DATA_ITEM_TAG, "");
            SetValue(DATA_ITEM_RUNDOWN, "");
        }

        /// <summary>
        /// 数据来源
        /// </summary>
        public string DataFrom
        {
            get { return _dataFrom; }
            set
            {
                _dataFrom = value;
                SetValue(DATA_ITEM_FROM, value);
            }
        }

        /// <summary>
        /// 数据名称
        /// </summary>
        public string DataName
        {
            get { return _dataName; }
            set
            {
                _dataName = value;
                SetValue(DATA_ITEM_NAME, value);
            }
        }

        /// <summary>
        /// 数据标记
        /// </summary>
        public string DataTag
        {
            get { return _dataTag; }
            set
            {
                _dataTag = value;
                SetValue(DATA_ITEM_TAG, value);
            }
        }

        /// <summary>
        /// 数据摘要
        /// </summary>
        public string DataRundown
        {
            get { return _dataRundown; }
            set {
                _dataRundown = value;
                SetValue(DATA_ITEM_RUNDOWN, value);
            }
        }

        /// <summary>
        /// 命令标识
        /// </summary>
        public string CommandIdentify
        {
            get { return _CommandIdentify; }
            set
            {
                _CommandIdentify = value;
                SetValue(DATA_ITEM_COMMAND, value);
            }
        }

        /// <summary>
        /// 最后错误
        /// </summary>
        public string LastError
        {
            get { return _lastError; }
            set
            {
                _lastError = value;
                SetValue(DATA_ITEM_LASTERROR, value);
            }
        }

        public string this[string item]
        {
            get { return GetValue(item); }
            set { SetValue(item, value); }
        }

        public Dictionary<string, string>.KeyCollection Items
        {
            get { return _pipeData.Keys; }
        }

        /// <summary>
        /// 设置键值
        /// </summary>
        /// <param name="item"></param>
        /// <param name="value"></param>
        public void SetValue(string item, string value)
        {
            if (_pipeData.ContainsKey(item) == true)
            {
                _pipeData[item] = value;
            }
            else
            {
                _pipeData.Add(item, value);
            }
        }

        /// <summary>
        /// 获取键值
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string GetValue(string item)
        {
            string value = "";

            if (_pipeData.ContainsKey(item) == true)
            {
                value = _pipeData[item];
            }

            return value;
        }

        /// <summary>
        /// 获取Hash值
        /// </summary>
        /// <returns></returns>
        public new string GetHashCode()
        {
            string sourceData = "";

            foreach (string key in _pipeData.Keys)
            {
                sourceData = _pipeData[key] + sourceData.ToLower();
            }

            return sourceData.GetHashCode().ToString();
        }

        /// <summary>
        /// 保存为xml字符
        /// </summary>
        /// <returns></returns>
        public virtual string SaveToXml()
        {
            string xml = "";
            using (DataTable dtData = new DataTable("XMLDATA"))
            {
                //添加数据列
                foreach (string key in _pipeData.Keys)
                {
                    dtData.Columns.Add(key, typeof(System.String));
                }

                DataRow dr = dtData.NewRow();
                foreach (string key in _pipeData.Keys)
                {
                    dr[key] = _pipeData[key];
                }
                dtData.Rows.Add(dr);

                using (MemoryStream ms = new MemoryStream())
                {
                    dtData.WriteXml(ms,  XmlWriteMode.WriteSchema);

                    ms.Position = 0;
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        xml = sr.ReadToEnd();
                    }

                    ms.Close();
                }
            }

            return xml;
        }

        /// <summary>
        /// 保存为文件
        /// </summary>
        /// <param name="fileName"></param>
        public virtual void SaveToFile(string fileName)
        {
            using (DataTable dtData = new DataTable("XMLDATA"))
            {
                //添加数据列
                foreach (string key in _pipeData.Keys)
                {
                    dtData.Columns.Add(key.ToUpper(), typeof(System.String));
                }

                DataRow dr = dtData.NewRow();
                foreach (string key in _pipeData.Keys)
                {
                    dr[key] = _pipeData[key];
                }
                dtData.Rows.Add(dr);

                dtData.WriteXml(fileName,  XmlWriteMode.WriteSchema);                
            }
        }

        protected void ParseStructure(string structureName, string value)
        {
            switch (structureName)
            {
                case DATA_ITEM_FROM :   //数据来源
                    _dataFrom = value;
                    break;
                case DATA_ITEM_NAME:    //数据项名
                    _dataName = value;
                    break;
                case DATA_ITEM_TAG:     //数据标记
                    _dataTag = value;
                    break;
                case DATA_ITEM_RUNDOWN: //数据摘要
                    _dataRundown = value;
                    break;
                case DATA_ITEM_COMMAND: //命令标识
                    _CommandIdentify = value;
                    break;
                case DATA_ITEM_LASTERROR: //最后错误
                    _lastError = value;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 从XML结构读取数据 
        /// </summary>
        /// <param name="xmlData"></param>
        public virtual void LoadXml(string xmlData)
        {
            DataTable dtData = new DataTable();

            using (MemoryStream ms = new MemoryStream())
            using(StreamWriter sw = new StreamWriter(ms))
            {
                sw.Write(xmlData);
                sw.Flush();

                ms.Position = 0;

                dtData.ReadXml(ms);
            }

            if (dtData.Rows.Count <= 0) return;
            
            string value = "";
            foreach(DataColumn dc in dtData.Columns)
            {
                value = dtData.Rows[0][dc.ColumnName] as string;
                SetValue(dc.ColumnName.ToUpper(), value);

                ParseStructure(dc.ColumnName.ToUpper(), value);
            }
        }

        /// <summary>
        /// 从文件读取数据
        /// </summary>
        /// <param name="fileName"></param>
        public virtual void LoadFile(string fileName)
        {
            using (DataTable dtData = new DataTable())
            {
                dtData.ReadXml(fileName);

                if (dtData.Rows.Count <= 0) return;

                string value = "";
                foreach (DataColumn dc in dtData.Columns)
                {
                    value = dtData.Rows[0][dc.ColumnName] as string;
                    SetValue(dc.ColumnName.ToUpper(), value);

                    ParseStructure(dc.ColumnName.ToUpper(), value);
                }
            }
        }
    }
}

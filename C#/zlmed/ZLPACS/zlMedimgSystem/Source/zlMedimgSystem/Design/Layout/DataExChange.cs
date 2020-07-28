using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.Layout
{
    public class DataExChange: IDataExChange
    {
        private Dictionary<string, IList<BizData>> _datas = null;
        public DataExChange()
        {
            _datas = new Dictionary<string, IList<BizData>>();
        }

        public void RegModuleData(string dataName, IList<BizData> data)
        {
            _datas[dataName] = data;
        }

        public IList<BizData> GetModuleData(string dataName)
        {
            if (HasData(dataName) == false) return null;

            return _datas[dataName];
        }

        public bool HasData(string dataName)
        {
            return _datas.ContainsKey(dataName);
        }


        public void AddDataItem(string dataName, BizData data)
        {
            if (HasData(dataName) == false)
            {
                _datas[dataName] = new List<BizData>();
            }

            _datas[dataName].Add(data);
        }

        public int GetDataItemCount(string dataName)
        {
            if (HasData(dataName) == false) return 0;

            return _datas[dataName].Count;
        }

        public BizData GetDataItem(string dataName, int index)
        {
            if (HasData(dataName) == false) return null;

            return _datas[dataName][index];
        }
    }
}

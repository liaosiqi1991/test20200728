using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.Layout
{
    public class BizDataTransferCenter: IBizDataTransferCenter
    {
        private Dictionary<string, IBizDataQuery> _dataQuerys = null;
        private IBizDataTransferCenter _parentDataCenter = null;
        //private IBizDataTransferCenter _subDataCenter = null;

        public IBizDataTransferCenter ParentDataCenter
        {
            get { return _parentDataCenter; }
            set { _parentDataCenter = value; }
        }

        //public IBizDataTransferCenter SubDataCenter
        //{
        //    get { return _subDataCenter; }
        //    set { _subDataCenter = value; }
        //}

        public BizDataTransferCenter()
        {
            _dataQuerys = new Dictionary<string, IBizDataQuery>();
        }

        /// <summary>
        /// 注册数据查询对象
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="objBizDataQuery"></param>
        public void RegBizDataQuery(string moduleName, IBizDataQuery objBizDataQuery)
        {
            if (_dataQuerys.ContainsKey(moduleName) == false)
            {
                _dataQuerys.Add(moduleName, objBizDataQuery);
            }

            _dataQuerys[moduleName] = objBizDataQuery;
        }

        /// <summary>
        /// 获取数据查询对象
        /// </summary>
        /// <param name="dataIdentificationName"></param>
        /// <returns></returns>
        public IBizDataItems GetBizDataQuery(string dataIdentificationName)
        {
            //if (_dataQuerys.ContainsKey(dataModuleName) == false) return null;
            foreach(IBizDataQuery curDataQuery in _dataQuerys.Values)
            {
                if (curDataQuery.HasData(dataIdentificationName))
                {
                    return curDataQuery.QueryDatas(dataIdentificationName);
                }
            }

            if (_parentDataCenter != null)
            {
                return _parentDataCenter.GetBizDataQuery(dataIdentificationName);
            }

            return null; // _dataQuerys[dataModuleName];
        }

        public bool HasData(string dataModuleName)
        {
            bool hasData = false;

            hasData = _dataQuerys.ContainsKey(dataModuleName);

            if (hasData) return hasData;

            if (_parentDataCenter != null)
            {
                return _parentDataCenter.HasData(dataModuleName);
            }

            return false;
        }
    }
}

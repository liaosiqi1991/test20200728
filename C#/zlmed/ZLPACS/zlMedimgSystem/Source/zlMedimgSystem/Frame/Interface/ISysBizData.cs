using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.Interface
{
    //public class BizData
    //{
    //    public string ID { get; set; }
    //    public string DataModuleName { get; set; }
    //    public string Tag { get; set; }
    //    public object ObjData { get; set; }

    //    public Dictionary<string, object> AttachDataList { get; set; }

    //    public BizData()
    //    {
    //        AttachDataList = new Dictionary<string, object>();
    //    }

    //    public BizData(string id, string dataName, object objData)
    //    {
    //        ID = id;
    //        DataModuleName = dataName;
    //        ObjData = objData;

    //        AttachDataList = new Dictionary<string, object>();
    //    }
    //}
    public interface IBizDataItem : IDictionary<string, object>
    {
        string Key { get; set; }
        object Tag { get; set; }

        IBizDataItems ParentData { get; set; }
    }

    public interface IBizDataItems : IList<IBizDataItem>
    {
        string DataName { get; set; }
        string Key { get; set; }
        object Tag { get; set; }

        List<IBizDataItems> AttachDatas { get; set; }

        new void Add(IBizDataItem item);
    }

    public class BizDataItem: Dictionary<string, object>, IBizDataItem
    {
        public string Key { get; set; }
        public object Tag { get; set; }

        public IBizDataItems ParentData { get; set; }
    }

    
    public class BizDataItems: List<IBizDataItem>, IBizDataItems
    {
        public string DataName { get; set; }
        public string Key { get; set; }
        public object Tag { get; set; }

        public List<IBizDataItems> AttachDatas { get; set; }

        public BizDataItems()
        {
            AttachDatas = new List<IBizDataItems>();
        }

        public new void Add(IBizDataItem item)
        {
            item.ParentData = this;
            base.Add(item);
        }
    }



    public interface IBizDataQuery
    {
        ////获取单个数据
        //object QueryData(string dataItemName);

        //获取多个数据
        IBizDataItems QueryDatas(string dataItemName);

        /// <summary>
        /// 判断数据是否存在
        /// </summary>
        /// <param name="dataItemName"></param>
        /// <returns></returns>
        bool HasData(string dataItemName);
    }

    public interface IBizDataTransferCenter
    {
        IBizDataTransferCenter ParentDataCenter { get; set; }
        //IBizDataTransferCenter SubDataCenter { get; set; }
        void RegBizDataQuery(string moduleName, IBizDataQuery objBizDataQuery);

        IBizDataItems GetBizDataQuery(string dataIdentificationName);

        bool HasData(string dataIdentificationName);
    }

    //public interface IDataExChange
    //{
    //    /// <summary>
    //    /// 注册模块数据
    //    /// </summary>
    //    /// <param name="dataModuleName"></param>
    //    /// <param name="data"></param>
    //    void RegModuleData(string dataModuleName, IList<BizData> data);

    //    /// <summary>
    //    /// 获取模块数据
    //    /// </summary>
    //    /// <param name="dataModuleName"></param>
    //    /// <returns></returns>
    //    IList<BizData> GetModuleData(string dataModuleName);

    //    /// <summary>
    //    /// 是否有数据
    //    /// </summary>
    //    /// <param name="dataModuleName"></param>
    //    /// <returns></returns>
    //    bool HasData(string dataModuleName);

    //    /// <summary>
    //    /// 添加数据项
    //    /// </summary>
    //    /// <param name="dataModuleName"></param>
    //    /// <param name="data"></param>
    //    void AddDataItem(string dataModuleName, BizData data);

    //    /// <summary>
    //    /// 获取数据项数量
    //    /// </summary>
    //    /// <param name="dataModuleName"></param>
    //    /// <returns></returns>
    //    int GetDataItemCount(string dataModuleName);

    //    /// <summary>
    //    /// 获取数据项
    //    /// </summary>
    //    /// <param name="dataModuleName"></param>
    //    /// <param name="index"></param>
    //    /// <returns></returns>
    //    BizData GetDataItem(string dataModuleName, int index);
    //}
}

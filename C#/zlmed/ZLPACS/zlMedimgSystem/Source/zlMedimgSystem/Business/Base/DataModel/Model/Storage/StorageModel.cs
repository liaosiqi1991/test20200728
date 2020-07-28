using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using System.Data;


namespace zlMedimgSystem.DataModel
{
    public class StorageData : StorageBase, IBizBindRow
    { 
        public JStorageInfo 存储信息 { get; set; }

        protected override void InitJsonInstance()
        {
            存储信息 = new JStorageInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JStorageInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JStorageInfo>(jsonData);
                }

                return null;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, null);
                return null;
            }
        }
    }
    public class StorageModel:DBModel
    {
        public StorageModel(IDBQuery dbHelper) : base(dbHelper) { }
        /// <summary>
        /// 查询所有存储设备信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllStorage()
        {
            SQL sql = SqlHelper.CreateSQL("查询存储设备信息", "select 存储ID,存储名称,存储信息 from 影像存储信息 order by 存储名称");   
            return _dbHelper.ExecuteSQL(sql);
        }

        public string GetStorageId(string strStorageName)
        {
            SQL sql = SqlHelper.CreateSQL("查询存储设备信息", "select 存储ID from 影像存储信息 where 存储名称='"+ strStorageName + "'");
            object objStorageid = _dbHelper.ExecuteSQLOneOutput(sql);
            return (objStorageid == null ? "" : objStorageid.ToString());
        }
        
        /// <summary>
        /// 插入存储设备
        /// </summary>
        /// <param name="storageData"></param>
        public void InsertStorage(StorageData storageData)
        {
            SQL sql = SqlHelper.CreateSQL("新增存储信息", "insert into 影像存储信息(存储ID, 存储名称, 存储信息)values(:存储ID, :存储名称, :存储信息)");
            sql.AddParameter("存储ID", DbType.String, storageData.存储ID);
            sql.AddParameter("存储名称", DbType.String, storageData.存储名称);
            sql.AddParameter("存储信息", DbType.String, storageData.存储信息.ToString());
             _dbHelper.ExecuteSQL(sql);
            
        }
        /// <summary>
        /// 修改存储信息
        /// </summary>
        /// <param name="storageData"></param>
        public void UpdateStorage(StorageData storageData)
        {
            SQL sql = SqlHelper.CreateSQL("修改存储信息", "update 影像存储信息 set 存储名称=:存储名称,存储信息=:存储信息 where 存储ID=:存储ID");
            sql.AddParameter("存储ID", DbType.String, storageData.存储ID);
            sql.AddParameter("存储名称", DbType.String, storageData.存储名称);
            sql.AddParameter("存储信息", DbType.String, storageData.存储信息.ToString());
            _dbHelper.ExecuteSQL(sql);
        }
        /// <summary>
        /// 删除存储信息
        /// </summary>
        /// <param name="storageData"></param>
        public void DelStorage(StorageData storageData)
        {
            SQL sql = SqlHelper.CreateSQL("删除存储信息", "delete from 影像存储信息 where 存储ID=:存储ID");
            sql.AddParameter("存储ID", DbType.String, storageData.存储ID);
            _dbHelper.ExecuteSQL(sql);
        }

        public StorageData GetStorageDataByID(string  storageID)
        {
            StorageData sd = new StorageData();
            
            SQL sql = SqlHelper.CreateSQL("根据ID提取存储信息", "select 存储名称,存储信息 from  影像存储信息  where 存储ID = :存储ID");

            sql.AddParameter("存储ID", DbType.String, storageID);

            DataTable dt = _dbHelper.ExecuteSQL(sql);

            if (dt.Rows.Count >0)
            {
                sd = new StorageData();
                sd.BindRowData(dt.Rows[0]);
            }

            return sd;

        }
    }
}

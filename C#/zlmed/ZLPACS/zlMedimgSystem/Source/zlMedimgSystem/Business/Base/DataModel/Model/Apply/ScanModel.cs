using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    public class ScanData : ScanBase,IBizBindRow
    {
        public JScan 扫描信息 { get; set; }

        protected override void InitJsonInstance()
        {
            扫描信息 = new JScan();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JScan).FullName)
                {
                    return JsonHelper.DeserializeObject<JScan>(jsonData);
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

    /// <summary>
    /// 扫描数据模型
    /// </summary>
    public class ScanModel : DBModel
    {
        public ScanModel(IDBQuery dbHelper) : base(dbHelper) { }


        /// <summary>
        /// 保存扫描的申请单
        /// </summary>
        /// <param name="scanData"></param>
        /// <returns></returns>
        public bool SaveScanImage(ScanData scanData)
        {                        
            SQL sql = SqlHelper.CreateSQL("新增申请扫描","insert into 影像申请扫描(扫描ID,申请ID,扫描信息,删除标记) values (:扫描ID,:申请ID,:扫描信息,:删除标记)");
            sql.AddParameter("扫描ID", DbType.String, scanData.扫描ID);
            sql.AddParameter("申请ID", DbType.String, scanData.申请ID);
            sql.AddParameter("扫描信息", DbType.String, scanData.扫描信息.ToString());
            sql.AddParameter("删除标记", DbType.Int32, scanData.删除标记);
                                                 
            _dbHelper.ExecuteSQL(sql);
            return true;
        }

        /// <summary>
        /// 查询是否存在扫描的申请图像
        /// </summary>
        /// <param name="str申请ID"></param>
        /// <returns></returns>
        public bool HasScanImage(string str申请ID)
        {
            SQL sql = SqlHelper.CreateSQL("查询是否有扫描申请", "select 扫描ID from 影像申请扫描 where 申请ID = :申请ID and 删除标记 is null");
            sql.AddParameter("申请ID", DbType.String, str申请ID);

            DataTable dt = _dbHelper.ExecuteSQL(sql);
            if (dt != null && dt.Rows.Count >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查询数据库，获取检查对应的所有扫描申请图像
        /// </summary>
        /// <param name="str申请ID">申请ID</param>
        /// <returns></returns>
        public DataTable GetScanImages(string str申请ID)
        {
            SQL sql = SqlHelper.CreateSQL("查询检查申请扫描图像", "select 扫描ID,申请ID,扫描信息,删除标记 from 影像申请扫描 where 申请ID = :申请ID");
            sql.AddParameter("申请ID", DbType.String, str申请ID);

            DataTable dt = _dbHelper.ExecuteSQL(sql);
            return dt;
        }

        /// <summary>
        /// 删除一个扫描申请图像
        /// </summary>
        /// <param name="ScanID">扫描ID</param>
        /// <returns></returns>
        public bool DeleteOneScanImage(string ScanID)
        {
            SQL sql = SqlHelper.CreateSQL("删除一个扫描申请图像", "delete from  影像申请扫描 where 扫描ID = :扫描ID");
            sql.AddParameter("扫描ID", DbType.String, ScanID);

            _dbHelper.ExecuteSQL(sql);
            return true;
        }
    }
}

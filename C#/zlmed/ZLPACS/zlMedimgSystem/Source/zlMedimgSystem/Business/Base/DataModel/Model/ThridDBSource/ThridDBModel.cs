using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel 
{

    public class ThridDBSourceData : ThridDBSourceBase, IBizBindRow
    {
        public JThridDbSourceInfo 数据源信息 { get; set; }

        protected override void InitJsonInstance()
        {
            数据源信息 = new JThridDbSourceInfo();
        }

        protected override IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            try
            {
                if (jsonTypeName == typeof(JThridDbSourceInfo).FullName)
                {
                    return JsonHelper.DeserializeObject<JThridDbSourceInfo>(jsonData);
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

    public class ThridDBSourceModel : DBModel
    {
        private const string Encrypt_Key = "20792F9C-14FA-4A14-BCBC-A65599FDF3B7";

        
        public ThridDBSourceModel(IDBQuery dbHelper) : base(dbHelper)
        {
            
        }

        public DataTable GetAllThridDBSource()
        {
            SQL sql = SqlHelper.CreateSQL("获取所有三方数据源", "Select 数据源ID,数据源别名,数据源信息 From 影像数据源信息 order by 数据源别名 ");

            return _dbHelper.ExecuteSQL(sql);
        }

        public string GetThridDbSourceIdByName(string serverAlias)
        {
            SQL sql = SqlHelper.CreateSQL("获取三方数据源ID", "Select 数据源ID From 影像数据源信息 where 数据源别名=:数据源别名");
            sql.AddParameter("数据源别名", DbType.String, serverAlias);

            object result = _dbHelper.ExecuteSQLOneOutput(sql);

            return (result == null ? "" : result.ToString());
        }

        public void NewThridDBSource(ThridDBSourceData thridDbSource)
        {
            SQL sql = SqlHelper.CreateSQL("插入三方数据源", "insert into 影像数据源信息(数据源ID, 数据源别名, 数据源信息)" +
                        " values(:数据源ID, :数据源别名, :数据源信息)");


            sql.AddParameter("数据源ID", DbType.String, thridDbSource.数据源ID);
            sql.AddParameter("数据源别名", DbType.String, thridDbSource.数据源别名); 
            sql.AddParameter("数据源信息", DbType.String, thridDbSource.数据源信息.ToString());

            DataTable dtResult = _dbHelper.ExecuteSQL(sql);
        }


        public void UpdateThridDBSource(ThridDBSourceData thridDbSource)
        {
            SQL sql = SqlHelper.CreateSQL("更新三方数据源", "Update 影像数据源信息 " +
                    " Set 数据源别名=:数据源别名, 数据源信息=:数据源信息 where 数据源ID=:数据源ID");

            sql.AddParameter("数据源ID", DbType.String, thridDbSource.数据源ID);
            sql.AddParameter("数据源别名", DbType.String, thridDbSource.数据源别名);
            sql.AddParameter("数据源信息", DbType.String, thridDbSource.数据源信息.ToString());

            _dbHelper.ExecuteSQL(sql);

        }

        public void DelThridDBSource(string thridDbSourceID)
        {
            SQL sql = SqlHelper.CreateSQL("删除三方数据源", "Delete 影像数据源信息 Where 数据源ID=:数据源ID");

            sql.AddParameter("数据源ID", DbType.String, thridDbSourceID);

            _dbHelper.ExecuteSQL(sql);

        }

        static public string EncryPwd(string pwd)
        {
            Encrypt enc = new Encrypt(Encrypt_Key, false); 
            return enc.EncryptStr(pwd);
        }

        static public string DecryPwd(string pwd)
        {
            try
            {
                Encrypt enc = new Encrypt(Encrypt_Key, false);
                return enc.DecryptStr(pwd);
            }
            catch
            {
                return pwd;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Drawing;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{
    //public class EntityConvert
    //{
    //    /// <summary>
    //    /// 数据行转对象
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="r"></param>
    //    /// <returns></returns>
    //    public static T DataRowToObject<T>(DataRow r)
    //    {
    //        T t = default(T);
    //        t = Activator.CreateInstance<T>();
    //        PropertyInfo[] ps = t.GetType().GetProperties();
    //        foreach (var item in ps)
    //        {
    //            if (r.Table.Columns.Contains(item.Name))
    //            {
    //                object v = r[item.Name];
    //                if (v.GetType() == typeof(System.DBNull))
    //                    v = null;
    //                item.SetValue(t, v, null);
    //            }
    //        }
    //        return t;
    //    }
        

    //}
     
    public interface IBizBindRow
    {
        /// <summary>
        /// 获取绑定行
        /// </summary>
        /// <returns></returns>
        DataRow GetBindRow();

        void BindRowData(DataRow r);
    }

    public class BizRow
    {
        public delegate IJsonField BizJsonConvert(string jsonTypeName, string jsonData);


        private bool _hasJsonField = true;
        protected virtual bool HasJsonField { get { return _hasJsonField; } set { _hasJsonField = value; } }
        public string TableName { get; set; }
        public string KeyName { get; set; }


        public event BizJsonConvert OnJsonConvert;

        public BizRow()
        {

        }

        public BizRow(DataRow r)
        {
            SelfConvert(r, this);
        }

        public void RowConvert(DataRow r, object rowEntry, bool hasJsonField)
        {
            _hasJsonField = hasJsonField;
            SelfConvert(r, rowEntry);
        }

        private void SelfConvert(DataRow r, object rowEntry)
        {

            PropertyInfo[] ps = rowEntry.GetType().GetProperties();

            foreach (var item in ps)
            {
                
                //if (item.PropertyType.GetInterface(typeof(IBasePro).Name) != null)
                //{
                //    object itemValue = item.GetValue(rowEntry, null);

                //    SelfConvert(r, itemValue);
                //    continue;
                //}

                if (r.Table.Columns.Contains(item.Name))
                {
                    object v = r[item.Name];

                    if (v.GetType() == typeof(System.DBNull))
                    {
                        v = null;
                    }
                    else 
                    {
                        if (HasJsonField && item.PropertyType.GetInterface(typeof(IJsonField).Name) != null)
                        {
                            v = ConvertJson(item.PropertyType.ToString(), r[item.Name].ToString());
                            if (v == null && OnJsonConvert != null)
                            {
                                v = OnJsonConvert(item.PropertyType.ToString(), r[item.Name].ToString()); 
                            }
                        }
                        else if ((v is byte[]) && (item.PropertyType.FullName == typeof(string).FullName))
                        {
                            v = BitConverter.ToString(v as byte[]).Replace("-", "");
                        }
                        else if ((v is byte[]) && (item.PropertyType.FullName == typeof(Image).FullName))
                        {
                            v = SqlHelper.BinaryToImage(v as byte[]);
                        }
                    }

                    if (v != null)
                    {
                        item.SetValue(rowEntry, v, null);
                    }
                }
                else
                {
                    switch (item.Name)
                    {
                        case "TableName":
                            item.SetValue(this, r.Table.TableName, null);
                            break;
                        case "KeyName":
                            if (r.Table.PrimaryKey.Length > 0)
                            {
                                item.SetValue(this, r.Table.PrimaryKey[0].ColumnName, null);
                            }
                            break;

                        default:
                            break;

                    }
                }
            }
        }

        protected virtual IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            return null;
        }

    }


    public interface IBasePro { }



    public class DataBase : IBizBindRow , IBasePro
    {
        protected DataRow _bindRow = null;

        protected BizRow _rowConvert = null;
         


        public DataBase()
        : this(null)
        {
        }

        public DataBase(DataRow r)
        {
            BindRowData(r);
        }

        protected void CopyFrom<T>(T source)  where T : DataBase
        {
            //根据泛型获取需要转换的类型
            Type sType = this.GetType();

            while (sType != typeof(T))
            {
                sType = sType.BaseType;

                if (sType == null) return;
            }

            if (sType == null) return;


            PropertyInfo[] ps = sType.GetProperties();

            foreach (var item in ps)
            {
                object itemValue = item.GetValue(source, null);
                item.SetValue(this, itemValue, null);
            }
        }

        public void BindRowData(DataRow r)
        {
            _bindRow = r;

            if (_rowConvert == null)
            {
                _rowConvert = new BizRow();
                _rowConvert.OnJsonConvert += ConvertJson;
            }

            if (r != null)
            {
                _rowConvert.RowConvert(r, this, true);
            }
            else
            {
                InitJsonInstance();
            }
        }

        protected virtual void InitJsonInstance()
        {

        }

        protected virtual IJsonField ConvertJson(string jsonTypeName, string jsonData)
        {
            return null;
        }

        /// <summary>
        /// 获取绑定行
        /// </summary>
        /// <returns></returns>
        public DataRow GetBindRow()
        {
            return _bindRow;
        }

        public new string ToString()
        {
            return JsonHelper.SerializeObject(this);
        }

        static public implicit operator string(DataBase dataBase)
        {
            return dataBase.ToString();
        }

    }
}

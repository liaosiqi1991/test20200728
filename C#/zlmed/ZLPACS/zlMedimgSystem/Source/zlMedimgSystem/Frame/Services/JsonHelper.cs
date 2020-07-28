
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;

namespace zlMedimgSystem.Services
{
    public class JsonHelper
    {

        private static JsonSerializer s_serializer;
        private static DefaultContractResolver s_contractResolver;

        static JsonHelper()
        {
            s_serializer = new JsonSerializer();
            s_contractResolver = s_serializer.ContractResolver as DefaultContractResolver;
        }

        public bool IsJsonFmt(string context)
        {
            try
            {
                throw new Exception("IsJsonFmt 是未实现的方法。");
            }
            catch
            {
                return false;
            }
        }
        public static string SerializeObject(object obj)
        {            
            return JsonConvert.SerializeObject(obj);
        }

        public static T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
        public static string SerializeXmlNode(XmlDocument value)
        {
            return JsonConvert.SerializeXmlNode(value);
        }

        public static XmlDocument DeserializeXmlNode(string value)
        {
            return JsonConvert.DeserializeXmlNode(value);
        }
        public static string GetValue(JToken jToken, string name)
        {
           return GetValue(jToken[name]);
        }

        public static string GetValue(JToken jToken)
        {
            JValue jv = jToken as JValue;
            if (jv == null)
                return null;
            return jv.Value == null ? null : jv.Value.ToString();
        }


        /// <summary>
        /// 转为Json字符串
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string ConvertDataTableToJson(DataTable table)
        {
            return ConvertDataTableToJson(table, false);
        }

        /// <summary>
        /// 转为Json字符串
        /// </summary>
        /// <param name="table"></param>
        /// <param name="isChangeColName2LowerCase">是否将数据表的列名转换成小写</param>
        /// <returns></returns>
        public static string ConvertDataTableToJson(DataTable table, bool isChangeColName2LowerCase)
        {
            string oldTableName = table.TableName;
            table.TableName = "root";//转Json时表名统一处理为root
            s_serializer.DateFormatString = "yyyy'-'MM'-'dd' 'HH':'mm':'ss.FFFFFFFK";
            string jsonText;
            using (StringWriter sw = new StringWriter())
            {
                JsonWriter writer = new JsonTextWriter(sw);
                writer.WriteStartObject();
                writer.WritePropertyName(table.TableName);
                writer.WriteStartArray();

                foreach (DataRow row in table.Rows)
                {
                    writer.WriteStartObject();
                    foreach (DataColumn column in table.Columns)
                    {
                        if (s_serializer.NullValueHandling != NullValueHandling.Ignore || !row.IsNull(column))
                        {
                            string columnName = (isChangeColName2LowerCase ? column.ColumnName.ToLower() : column.ColumnName);
                            writer.WritePropertyName(s_contractResolver != null ? s_contractResolver.GetResolvedPropertyName(columnName) : columnName);
                            s_serializer.Serialize(writer, row[column], column.DataType);
                        }
                    }
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
                writer.WriteEndObject();
                writer.Flush();

                jsonText = sw.GetStringBuilder().ToString();
            }
            table.TableName = oldTableName;
            return jsonText;
        }


        /// <summary>
        /// 转为Json字符串
        /// </summary>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public static DataTable ConvertDataTableFromJson(string jsonText)
        {
            DataTable table = new DataTable();
            using (StringReader sr = new StringReader(jsonText))
            {
                using (JsonTextReader reader = new JsonTextReader(sr))
                {
                    CheckedRead(reader);
                    if (reader.TokenType != JsonToken.StartObject)
                    {
                        throw new Exception(string.Format(
                            "读取DataTable时，在位置[{0},{1}]处遇到非预期的JSON token：期望\"StartObject\"，实际\"{2}\"。",
                            reader.LineNumber, reader.LinePosition, reader.TokenType));
                    }
                    CheckedRead(reader);
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        table.TableName = (string)reader.Value;
                        CheckedRead(reader);
                    }
                    if (reader.TokenType != JsonToken.StartArray)
                    {
                        throw new Exception(string.Format(
                            "读取DataTable时，在位置[{0},{1}]处遇到非预期的JSON token：期望\"StartArray\"，实际\"{2}\"。",
                            reader.LineNumber, reader.LinePosition, reader.TokenType));
                    }
                    CheckedRead(reader);
                    while (reader.TokenType != JsonToken.EndArray)
                    {
                        CreateRow(reader, table);
                        CheckedRead(reader);
                    }
                }
            }
            return table;
        }

        #region >>ConvertFromDataTable
        private static void CheckedRead(JsonTextReader reader)
        {
            if (!reader.Read())
            {
                throw new Exception(string.Format("读取DataTable时，在位置[{0},{1}]处遇到非预期的结束符。",
                    reader.LineNumber, reader.LinePosition));
            }
        }
        private static void CreateRow(JsonTextReader reader, DataTable dt)
        {
            DataRow row = dt.NewRow();
            CheckedRead(reader);
            while (reader.TokenType == JsonToken.PropertyName)
            {
                string columnName = (string)reader.Value;
                CheckedRead(reader);
                DataColumn column = dt.Columns[columnName];
                if (column == null)
                {
                    Type columnDataType = GetColumnDataType(reader);
                    column = new DataColumn(columnName, columnDataType);
                    dt.Columns.Add(column);
                }
                if (column.DataType == typeof(DataTable))
                {
                    if (reader.TokenType == JsonToken.StartArray)
                    {
                        CheckedRead(reader);
                    }
                    DataTable table = new DataTable();
                    while (reader.TokenType != JsonToken.EndArray)
                    {
                        CreateRow(reader, table);
                        CheckedRead(reader);
                    }
                    row[columnName] = table;
                }
                else if (column.DataType.IsArray && (column.DataType != typeof(byte[])))
                {
                    if (reader.TokenType == JsonToken.StartArray)
                    {
                        CheckedRead(reader);
                    }
                    List<object> list = new List<object>();
                    while (reader.TokenType != JsonToken.EndArray)
                    {
                        list.Add(reader.Value);
                        CheckedRead(reader);
                    }
                    Array destinationArray = Array.CreateInstance(column.DataType.GetElementType(), list.Count);
                    Array.Copy(list.ToArray(), destinationArray, list.Count);
                    row[columnName] = destinationArray;
                }
                else
                {
                    row[columnName] = reader.Value ?? DBNull.Value;
                }
                CheckedRead(reader);
            }
            row.EndEdit();
            dt.Rows.Add(row);
        }
        private static Type GetColumnDataType(JsonTextReader reader)
        {
            JsonToken tokenType = reader.TokenType;
            switch (tokenType)
            {
                case JsonToken.StartArray:
                    CheckedRead(reader);
                    if (reader.TokenType != JsonToken.StartObject)
                    {
                        return GetColumnDataType(reader).MakeArrayType();
                    }
                    return typeof(DataTable);

                case JsonToken.Integer:
                case JsonToken.Float:
                case JsonToken.String:
                case JsonToken.Boolean:
                case JsonToken.Date:
                case JsonToken.Bytes:
                    return reader.ValueType;

                case JsonToken.Null:
                case JsonToken.Undefined:
                    return typeof(string);
            }
            throw new Exception(string.Format("读取DataTable时，在位置[{0},{1}]处遇到非预期的JSON token：{2}",
                reader.LineNumber, reader.LinePosition, tokenType));
        }
        #endregion

    }
}

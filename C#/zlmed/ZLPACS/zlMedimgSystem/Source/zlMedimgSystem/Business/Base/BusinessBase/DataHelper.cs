using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.BusinessBase
{
    static public class DataHelper
    {
        static public string StdPar_ApplyId = "applyid";
        static public string StdPar_MediaId = "mediaid";
        static public string StdPar_SerialId = "serialid";
        static public string StdPar_FormatId = "formatid";
        static public string StdPar_StorageId = "storageid";
        static public string StdPar_TemplateId = "templateid";
        static public string StdPar_ReportId = "reportid";
        static public string StdPar_PatientId = "patientid";
        static public string StdPar_ExecuteDeptId = "executedepartmentid";
        static public string StdPar_ExamId = "examid";

        static public string StdPar_ApplyCode = "applycode";
        static public string StdPar_PatientCode = "patientcode";

        static public string StdPar_ImageKind = "imagekind";
        static public string StdPar_LocalFile = "localfile";
        static public string StdPar_ApplyDate = "applydate";
        static public string StdPar_StudyNo = "studyno";
        static public string StdPar_PatiFrom = "patientfrom";
        static public string StdPar_PatiName = "patientname";
        static public string StdPar_MediaOrder = "order";
        static public string StdPar_MediaType = "mediatype";
        static public string StdPar_MediaName = "medianame";
        static public string StdPar_Text = "text";
        static public string StdPar_VPath = "vpath";
        static public string StdPar_IsKeyImage = "iskeyimage";
        static public string StdPar_IsReportImage = "isreportimage";


        static public string StdPar_ApplyData = "applydata";
        static public string StdPar_TemplateData = "templatedata";
        static public string StdPar_FormatData = "formatdata";
        static public string StdPar_ReportData = "reportdata";
        static public string StdPar_ReportXML = "reportxml";

        static public string StdPar_LineupId = "lineupid";
        static public string StdPar_QueueId = "queueid";
        static public string StdPar_QueueName = "queuename";
        static public string StdPar_QueryResult = "queryresult";
        static public string StdPar_QueryCfgFormat = "querycfgformat";
        static public string StdPar_QueryDbAlias = "querydbalias";

        static public string StdPar_SelDataRow = "seldatarow";
        static public string StdPar_TextContext = "textcontext";


        static public IBizDataItems GetDataItem(IBizDataTransferCenter transferCenter, string action, string moduleName, string dataName)
        {
            IBizDataItems dataItems = transferCenter.GetBizDataQuery(dataName); 
            if (dataItems == null)
            {
                MessageBox.Show("(" + moduleName + "." + action + ")未找到所请求的数据，请求数据为 [" + dataName + "]。", "提示");
                return null;
            }

            if (dataItems.Count <= 0)
            {
                MessageBox.Show("(" + moduleName + "." + action + ")未找到对应的数据项，请求数据为 [" + dataName + "]。", "提示");
                return null;
            }

            return dataItems;
        }


        /// <summary>
        /// 提取申请ID
        /// </summary>
        /// <param name="dataItems"></param>
        /// <returns></returns>
        static public string GetItemValueByApplyId(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_ApplyId, new string[] { "申请ID", "requestid" });

            return (value == null) ? "" : Convert.ToString(value);
        }

        /// <summary>
        /// 提取申请识别码
        /// </summary>
        /// <param name="dataItems"></param>
        /// <returns></returns>
        static public string GetItemValueByApplyCode(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_ApplyCode, new string[] { "申请识别码", "requestcode" });

            return (value == null) ? "" : Convert.ToString(value);
        }

        /// <summary>
        /// 提取患者ID
        /// </summary>
        /// <param name="dataItems"></param>
        /// <returns></returns>
        static public string GetItemValueByPatientId(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_PatientId, new string[] { "患者ID", "病人ID" });

            return (value == null) ? "" : Convert.ToString(value);
        }

        /// <summary>
        /// 提取患者识别码
        /// </summary>
        /// <param name="dataItems"></param>
        /// <returns></returns>
        static public string GetItemValueByPatientCode(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_PatientCode, new string[] { "患者识别码", "病人识别码" });

            return (value == null) ? "" : Convert.ToString(value);
        }

        /// <summary>
        /// 提取患者姓名
        /// </summary>
        /// <param name="dataItems"></param>
        /// <returns></returns>
        static public string GetItemValueByPatientName(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_PatiName, new string[] { "患者姓名", "病人姓名" });

            return (value == null) ? "" : Convert.ToString(value);
        }



        static public string GetItemValueByQueueName(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_QueueName, new string[] { "队列名称" });

            return (value == null) ? "" : Convert.ToString(value);
        }

        static public string GetItemValueByQueueId(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_QueueId, new string[] { "队列ID" });

            return (value == null) ? "" : Convert.ToString(value);

        }


        static public string GetItemValueByQueryDBAlias(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_QueryDbAlias, new string[] { "数据源别名" });

            return (value == null) ? "" : Convert.ToString(value);
        }


        static public string GetItemValueByQueryCfgFormat(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_QueryCfgFormat, new string[] { "查询配置" });

            return (value == null) ? "" : Convert.ToString(value);
        }

        static private object GetItemValue(IBizDataItem dataItems, string stdParName, string[] parAlias, bool isCheckAttach = true)
        {
            object value = null;

            if (dataItems.ContainsKey(stdParName) == false)
            {
                foreach(string curAlias in parAlias)
                {
                    if (dataItems.ContainsKey(curAlias)) value = dataItems[curAlias];
                    //获取到对应值则直接终止当前循环
                    if (value != null) break;
                }
                
            }
            else
            {
                value = dataItems[stdParName];
            }

            if (value == null && isCheckAttach)
            {
                if (dataItems.ParentData != null)
                {
                    if (dataItems.ParentData.AttachDatas != null && dataItems.ParentData.AttachDatas.Count > 0)
                    {
                        foreach (IBizDataItems bizDatas in dataItems.ParentData.AttachDatas)
                        {
                            if (bizDatas.Count > 0) value = GetItemValue(bizDatas[0], stdParName, parAlias, false);
                        }
                    }
                }
            }
            
            return value;

        }


        static public DataTable GetItemValueByQueryResult(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_QueryResult, new string[] { "查询结果"});
 
            return (value == null) ? null : value as DataTable;
        }

        /// <summary>
        /// 获取影像类别
        /// </summary>
        /// <param name="dataItems"></param>
        /// <returns></returns>
        static public string GetItemValueByImageKind(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_ImageKind, new string[] { "影像类别" });

            return (value == null) ? "" : value.ToString();
        }

        /// <summary>
        /// 获取报告模板ID
        /// </summary>
        /// <param name="dataItems"></param>
        /// <returns></returns>
        static public string GetItemValueByTemplateId(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_TemplateId, new string[] { "模板ID" });

            return (value == null) ? "" : value.ToString();             
        }

        /// <summary>
        /// 获取报告格式ID
        /// </summary>
        /// <param name="dataItems"></param>
        /// <returns></returns>
        static public string GetItemValueByFormatId(IBizDataItem dataItems)
        {

            object value = GetItemValue(dataItems, StdPar_FormatId, new string[] { "格式ID" });

            return (value == null) ? "" : value.ToString();
        }

        static public string GetItemValueBySerialId(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_SerialId, new string[] { "序列ID" });

            return (value == null) ? "" : value.ToString();
        }

        static public string GetItemValueByImageId(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_MediaId, new string[] { "imageid", "图像ID"});

            return (value == null) ? "" : value.ToString();
        }


        static public string GetItemValueByMediaType(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_MediaType, new string[] { "媒体类型" });

            return (value == null) ? "" : value.ToString();
        }

        static public string GetItemValueByMediaOrder(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_MediaOrder, new string[] { "媒体序号" });

            return (value == null) ? "" : value.ToString();
        }

        static public string GetItemValueByFile(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_LocalFile, new string[] { "file", "文件" });

            return (value == null) ? "" : value.ToString();
        }

        /// <summary>
        /// 提取申请日期
        /// </summary>
        /// <param name="dataItems"></param>
        /// <returns></returns>
        static public DateTime GetItemValueByApplyDate(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_ApplyDate, new string[] { "requestdate", "申请日期" });

            return (value == null) ? default(DateTime) : Convert.ToDateTime(value);
        }

        /// <summary>
        /// 提取文本内容值
        /// </summary>
        /// <param name="dataItems"></param>
        /// <returns></returns>
        static public DateTime GetItemValueByTextContext(IBizDataItem dataItems)
        {
            object value = GetItemValue(dataItems, StdPar_TextContext, new string[] { "文本内容"});

            return (value == null) ? default(DateTime) : Convert.ToDateTime(value);
        }
    }
}

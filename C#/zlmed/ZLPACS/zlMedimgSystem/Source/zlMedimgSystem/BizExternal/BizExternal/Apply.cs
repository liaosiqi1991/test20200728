using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.ExtInterface
{

    ///// <summary>
    ///// 项目子项，如检查部位
    ///// </summary>
    //public class ApplySub
    //{
    //    public string SubName { get; set; }

    //    public IList<string> Method { get; set; }


    //    public ApplySub()
    //    {
    //        Method = new List<string>();
    //    }
    //}

    //public enum PatientFrom
    //{
    //    /// <summary>
    //    /// 门诊
    //    /// </summary>
    //    pfOutPatient,

    //    /// <summary>
    //    /// 住院
    //    /// </summary>
    //    pfInPatient,

    //    /// <summary>
    //    /// 体检
    //    /// </summary>
    //    pfCheckUp,

    //    /// <summary>
    //    /// 外来
    //    /// </summary>
    //    pfOutside
    //}

    //public class ApplyExam
    //{
    //    public string Name { get; set; }
    //    public IList<ApplySub> SubItems { get; set; }

    //    public ApplyExam()
    //    {
    //        SubItems = new List<ApplySub>();
    //    }
    //}

    ///// <summary>
    ///// 检查申请
    ///// </summary>
    //public class ApplyInfo
    //{
    //    /// <summary>
    //    /// 申请关键字，如申请ID
    //    /// </summary>
    //    public string ApplyKey { get; set; }

    //    /// <summary>
    //    /// 患者关键字，如患者ID
    //    /// </summary>
    //    public string PatientKey { get; set; }

    //    /// <summary>
    //    /// 患者姓名
    //    /// </summary>
    //    public string PatientName { get; set; }

    //    /// <summary>
    //    /// 性别
    //    /// </summary>
    //    public string Sex { get; set; }

    //    /// <summary>
    //    /// 年龄
    //    /// </summary>
    //    public string Age { get; set; }

    //    /// <summary>
    //    /// 出生日期
    //    /// </summary>
    //    public DateTime BirthDate { get; set; }

    //    /// <summary>
    //    /// 就诊卡号
    //    /// </summary>
    //    public string CardNo { get; set; }

    //    /// <summary>
    //    /// 住院号
    //    /// </summary>
    //    public string InPatientNo { get; set; }

    //    /// <summary>
    //    /// 门诊号
    //    /// </summary>
    //    public string OutPatientNo { get; set; }

    //    /// <summary>
    //    /// 主页ID
    //    /// </summary>
    //    public string PageID { get; set; }

    //    /// <summary>
    //    /// 挂号ID
    //    /// </summary>
    //    public string RegId { get; set; }

    //    /// <summary>
    //    /// 床号
    //    /// </summary>
    //    public string BedNo { get; set; }

    //    /// <summary>
    //    /// 患者申请来源
    //    /// </summary>
    //    public PatientFrom ApplyFrom { get; set; }

    //    /// <summary>
    //    /// 影像检查类别
    //    /// </summary>
    //    public string ExamKind { get; set; }

    //    /// <summary>
    //    /// 申请科室
    //    /// </summary>
    //    public string ApplyDepartment { get; set; }

    //    /// <summary>
    //    /// 申请医生
    //    /// </summary>
    //    public string ApplyDoctor { get; set; }

    //    /// <summary>
    //    /// 是否急诊
    //    /// </summary>
    //    public bool IsEmergency { get; set; }

    //    /// <summary>
    //    /// 检查科室
    //    /// </summary>
    //    public string ExamDepartment { get; set; }

    //    /// <summary>
    //    /// 检查执行院区
    //    /// </summary>
    //    public string ExamHospatialArea { get; set; }

    //    /// <summary>
    //    /// 临床诊断
    //    /// </summary>
    //    public string ClinicalDiagnose { get; set; }

    //    /// <summary>
    //    /// 申请日期
    //    /// </summary>
    //    public DateTime ApplyDate { get; set; }

    //    /// <summary>
    //    /// 是否婴儿
    //    /// </summary>
    //    public bool IsBaby { get; set; }

    //    /// <summary>
    //    /// 嘱托
    //    /// </summary>
    //    public string Entrust { get; set; }

    //    /// <summary>
    //    /// 联系电话
    //    /// </summary>
    //    public string MobilePhoneNumber { get; set; }


    //    public ApplyExam Exam { get; set; }

         
    //    public ApplyInfo()
    //    {
    //        Exam = new ApplyExam();
    //    }
    //}

    public enum ExpensesType
    {
        /// <summary>
        /// 划价
        /// </summary>
        etCash,

        /// <summary>
        /// 记账
        /// </summary>
        etAccount
    }

    public class ExpensesInfo
    {
        public string Name { get; set; }
        public bool IsCharge { get; set; }
        public double Money { get; set; }
        public ExpensesType Type { get; set; }
    }

    public interface IExpense
    {
        /// <summary>
        /// 获取费用状态
        /// </summary>
        /// <param name="applyKey"></param>
        /// <returns></returns>
        ExpensesInfo GetExpensesState(string applyKey);

        /// <summary>
        /// 发送费用
        /// </summary>
        /// <param name="applyKey"></param>
        void SendExpenses(string applyKey, IList<ExpensesInfo> expenses);

        /// <summary>
        /// 撤销费用
        /// </summary>
        /// <param name="applyKey"></param>
        void CancelExpense(string applyKey);

        /// <summary>
        /// 执行费用
        /// </summary>
        /// <param name="applyKey"></param>
        void ExecuteExpense(string applyKey);
    }

    public interface IApply : IInterfaceName
    {

        IExpense Expense { get; }

        void Init(IDBQuery dbQuery);

        /// <summary>
        /// 申请接口配置
        /// </summary>
        bool ShowCfg(IWin32Window owner);

        string ConfigString { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// 获取申请信息
        /// </summary>
        /// <param name="searchKeys">查询条件<key,value></param>
        /// <returns></returns>
        DataTable GetApply(Dictionary<string,object> searchKeys);

        /// <summary>
        /// 接收申请
        /// </summary>
        /// <param name="applyKey"></param>
        void ReceiveApply(string applyKey);

        /// <summary>
        /// 撤销申请接收
        /// </summary>
        /// <param name="applyKey"></param>
        void CancelReceive(string applyKey);

        /// <summary>
        /// 拒绝执行申请
        /// </summary>
        /// <param name="applyKey"></param>
        void RejectApply(string applyKey);

        /// <summary>
        /// 发布报告
        /// </summary>
        void PublishReport(string applyKey, string reportContext, string reportUrl);

        /// <summary>
        /// 收回报告
        /// </summary>
        void BackReport(string applyKey);

        /// <summary>
        /// 完成申请
        /// </summary>
        void CompleteApply(string applyKey);

        /// <summary>
        /// 撤销申请完成
        /// </summary>
        void CancelComplete(string applyKey);



        /// <summary>
        /// 新开申请
        /// </summary>
        /// <param name="apply"></param>
        void NewApply(Dictionary<string, string> applyInfo, Dictionary<string, string> patientInfo);

        /// <summary>
        /// 提取医嘱信息
        /// <param name="OrderKey">医嘱关键字</param>
        /// </summary>
        DataTable GetOrderInfo(string OrderKey);

    }



    public class ApplyEnum : InterfaceEnum<IApply>
    {
        public ApplyEnum() : base("*.APPLY.*")
        {
        }
    }
}

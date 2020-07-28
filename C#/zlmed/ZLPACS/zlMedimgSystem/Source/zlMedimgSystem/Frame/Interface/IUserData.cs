using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.Interface
{

    /// <summary>
    /// 辅助人员
    /// </summary>
    public interface IAssistUser
    {
        /// <summary>
        /// 本地ID
        /// </summary>
        string UserId { get; set; }        

        /// <summary>
        /// 授权或关联ID
        /// </summary>
        string AuthorId { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 签名图像
        /// </summary>
        Image SignImg { get; set; }

    }

    public interface ILoginUser
    {
        /// <summary>
        /// 用户本地ID
        /// </summary>
        string UserId { get; set; }

        /// <summary>
        /// 授权对应ID
        /// </summary>
        string AuthorId { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        string Account { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        int Level { get; set; }

        Image SignImg { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        string RoleId { get; set; }

        /// <summary>
        /// 单位科室ID
        /// </summary>
        string DepartmentId { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        string Pwd { get; set; }

        /// <summary>
        /// 辅助人员信息
        /// </summary>
        IAssistUser AssistUserInfo1
        {
            get;
            set;
        }

        IAssistUser AssistUserInfo2
        {
            get;
            set;
        }

        IAssistUser AssistUserInfo3
        {
            get;
            set;
        }

    }



    public class AssistUser : IAssistUser
    {
        public string UserId { get; set; }
        public string AuthorId { get; set; }

        public string Account { get; set; }
        public string Name { get; set; }

        public Image SignImg { get; set; }

        public AssistUser()
        {

        }

        public AssistUser(string id, string authorId, string account, string name)
        {
            UserId = id;
            AuthorId = authorId;
            Account = account;
            Name = name;
        }
    }
    public class UserData : ILoginUser
    {
        string _locateId;
        string _authorId;
        string _roleId;
        string _departmentId;
        string _account;
        string _name;
        int _level;
        Image _signImg;
        string _pwd;
        IAssistUser _assistUserInfo1;
        IAssistUser _assistUserInfo2;
        IAssistUser _assistUserInfo3;

        /// <summary>
        /// 本地ID
        /// </summary>
        public string UserId
        {
            get { return _locateId; }
            set { _locateId = value; }
        }

        /// <summary>
        /// 授权对应ID,如果没有使用三方验证，则授权ID为locateid
        /// </summary>
        public string AuthorId
        {
            get { return _authorId; }
            set { _authorId = value; }
        }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account
        {
            get { return _account; }
            set { _account = value; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 级别
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public Image SignImg
        {
            get { return _signImg; }
            set { _signImg = value; }
        }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        /// <summary>
        /// 单位科室ID
        /// </summary>
        public string DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }

        public IAssistUser AssistUserInfo1
        {
            get { return _assistUserInfo1; }
            set { _assistUserInfo1 = value; }
        }

        public IAssistUser AssistUserInfo2
        {
            get { return _assistUserInfo2; }
            set { _assistUserInfo2 = value; }
        }

        public IAssistUser AssistUserInfo3
        {
            get { return _assistUserInfo3; }
            set { _assistUserInfo3 = value; }
        }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }

        public UserData()
        {
            _assistUserInfo1 = new AssistUser();
            _assistUserInfo2 = new AssistUser();
            _assistUserInfo3 = new AssistUser();
        }
    }
}

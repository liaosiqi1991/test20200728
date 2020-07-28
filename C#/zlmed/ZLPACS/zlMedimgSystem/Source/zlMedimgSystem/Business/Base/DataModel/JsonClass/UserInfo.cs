using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.DataModel
{

    public class UserReleationBase:DataBase
    {
        public string 用户关联ID { get; set; }
        public string 用户ID { get; set; }
        public string 科室ID { get; set; }
        public string 角色ID { get; set; }
    }

    public class UserBase:DataBase
    {
        public string 用户ID { get; set; }
        public string 系统账号 { get; set; } 
        public string 用户名称 { get; set; }

        public int 职称级别 { get; set; }

        public Image 签名图片 { get; set; }
        public Image 人员照片 { get; set; }

    }


    public class JAccountInfo: UserBase, IJsonField
    {
        public string 密码 { get; set; }

        public string 备注 { get; set; }
        public DateTime 创建日期 { get; set; }

        public bool 是否停用 { get; set; }

        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}

        public void CopyBasePro(UserBase userBase)
        {
            this.用户ID = userBase.用户ID;
            this.用户名称 = userBase.用户名称;
            this.系统账号 = userBase.系统账号;
        }
    }

    public class JUserInfo: UserBase, IJsonField
    {
        public string 人员姓名 { get; set; }
        public string 人员性别 { get; set; }
        public DateTime 出生日期 { get; set; }
        public string 身份证号 { get; set; }

        public string 联系电话 { get; set; }

        public string 联系地址 { get; set; }
        public string 办公电话 { get; set; }
        public string 电子邮件 { get; set; }
        public string 个人简介 { get; set; }
        public string 备注 { get; set; }

        //public new string ToString()
        //{
        //    return JsonHelper.SerializeObject(this);
        //}
        public void CopyBasePro(UserBase userBase)
        {
            this.用户ID = userBase.用户ID;
            this.用户名称 = userBase.用户名称;
            this.系统账号 = userBase.系统账号;
        }
    }

    public class JAlterLog: IJsonField
    {
        public string 更改日期 { get; set; }
        public string 更改人员 { get; set; }
        public string 更改内容 { get; set; }


        public new string ToString()
        {
            return JsonHelper.SerializeObject(this);
        }
    }
}

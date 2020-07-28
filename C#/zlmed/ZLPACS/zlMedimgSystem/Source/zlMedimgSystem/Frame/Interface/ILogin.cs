using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.Interface
{

    public delegate bool DelegateBusinessVerify(IDBProvider dbProvider, ILoginUser userData);
    public interface ILogin
    {
        IDBProvider DBProvider
        {
            get;
        }

        ILoginUser LoginUser
        {
            get;
        }

        string ServerName
        {
            get;
        }

        void SetLoginTitle(string title);

        bool ShowLogin(string command, IVerify defaultVerify);

        bool ShowLogin(string command, IVerify defaultVerify, DelegateBusinessVerify businessVerify);

        bool ShowLogin(string command, IVerify defaultVerify, bool allowThirdVerify);

        bool ShowLogin(string command, IVerify defaultVerify, bool allowThirdVerify, DelegateBusinessVerify businessVerify);

        
    }
}

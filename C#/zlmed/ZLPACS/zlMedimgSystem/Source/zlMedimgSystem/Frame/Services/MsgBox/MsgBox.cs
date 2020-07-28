using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
 

namespace zlMedimgSystem.Services
{
    static public class MsgBox
    { 

        static MsgBox()
        { 
        }
        

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="owner"></param>
        public static void ShowInf(string strMsg, IWin32Window owner = null)
        {           
            MessageBox.Show(owner, strMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="strWaring"></param>
        /// <param name="owner"></param>
        public static void ShowError(string strError, IWin32Window owner = null)
        {
            MessageBox.Show(owner, strError, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        public static void ShowException(Exception ex, IWin32Window owner = null)
        {
            ShowException(ex, "", "", owner);
        }

        public static void ShowException(Exception ex, string hint, IWin32Window owner = null) 
        {
            ShowException(ex, hint, "", owner);
        }
        public static void ShowException(Exception ex, string hint, string caption, IWin32Window owner = null)
        {
            using (frmMsgBox msgbox = new frmMsgBox())
            {
                msgbox.ShowError(ex, hint, caption, owner);
            }

        }



        public static DialogResult ShowQuestion(string strQuestion,IWin32Window owner = null)
        {
            return ShowQuestion(strQuestion, MessageBoxButtons.YesNo, owner);
        }


        /// <summary>
        /// 显示询问对话框
        /// </summary>
        /// <param name="strQuestion"></param>
        /// <param name="buttons"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static DialogResult ShowQuestion(string strQuestion, MessageBoxButtons buttons, IWin32Window owner = null)
        { 
            return MessageBox.Show(owner, strQuestion, "提示", buttons, MessageBoxIcon.Question);
        }

        public static void InitChs()
        { 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using System.Windows.Forms;

namespace zlMedimgSystem.BusinessBase
{
    static public class FuncHelper
    {

        static public void ShowImgPreview(IDBQuery dbHelper, string applyId, IWin32Window owner)
        {
            using (frmImageView imgView = new frmImageView())
            {
                imgView.ShowImgPreview(dbHelper, applyId, owner);
            }

        }
    }
}

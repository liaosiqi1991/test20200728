using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.CTL.Summary
{

    public class DesignLabelFormatEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            //指定为模式窗体属性编辑器类型 
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            //打开属性编辑器修改右键菜单设置
            try
            { 
                Control instanceParent = null;
 
                frmSelectField selectField = new frmSelectField();
                return selectField.ShowDataNameEditor(Convert.ToString(value), instanceParent); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
                //MsgBox.ShowException(ex);
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using zlMedimgSystem.Services;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.CTL.DataView
{
    public class DataFromEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            //指定为模式窗体属性编辑器类型 
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            try
            {
                ViewItemWrapper instance = (context.Instance as ViewItemWrapper);
                Control instanceParent = instance.Parent;
                        
                while (instanceParent.Parent != null)
                {
                    instanceParent = instanceParent.Parent;

                    if (instanceParent as frmDataViewModuleDesign != null) break;
                }

                IDBQuery dbHelper = null;
                if (instanceParent is frmDataViewModuleDesign)
                {
                    dbHelper = (instanceParent as frmDataViewModuleDesign).DBHelper;
                }


                //打开属性编辑器修改数据 
                return frmDataFromEditor.EditValue(instanceParent, dbHelper, value);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
                return null;
            }
        }
    }




    public class DataFieldEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            //指定为模式窗体属性编辑器类型 
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            try
            {
                ViewItemWrapper instance = (context.Instance as ViewItemWrapper);
                Control instanceParent = instance.Parent;

                while (instanceParent.Parent != null)
                {
                    instanceParent = instanceParent.Parent;

                    if (instanceParent as frmDataViewModuleDesign != null) break;
                }

                IDBQuery dbHelper = null;
                string sql = "";
                if (instanceParent is frmDataViewModuleDesign)
                {
                    dbHelper = (instanceParent as frmDataViewModuleDesign).CurDBHelper;
                    sql = (instanceParent as frmDataViewModuleDesign).CurSql;
                }                


                //打开属性编辑器修改数据 
                return frmDataFieldEditor.EditValue(instanceParent, dbHelper, sql, value);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
                return null;
            }
        }
    }

}

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

namespace zlMedimgSystem.Design
{
    public class EventProEditor : UITypeEditor
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
                Control instance = (context.Instance as System.Windows.Forms.Control);
                Control instanceParent = instance;

                if (instance.Parent != null) instanceParent = instance.Parent;


                while (instanceParent.Parent != null)
                {
                    instanceParent = instanceParent.Parent;

                    if (instanceParent as Form != null) break;
                }


                //打开属性编辑器修改数据 
                return frmProEventEditor.EditValue(instanceParent, (ISysDesign)instance, value);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
                return null;
            }
        }
    }

    //public class ToolVisibleProEditor : UITypeEditor
    //{
    //    public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
    //    {
    //        //指定为模式窗体属性编辑器类型 
    //        return UITypeEditorEditStyle.Modal;
    //    }

    //    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    //    {
    //        //打开属性编辑器修改数据  
    //        try
    //        {
    //            Control instance = (context.Instance as System.Windows.Forms.Control);
    //            Control instanceParent = instance.Parent;

    //            while (instanceParent.Parent != null)
    //            {
    //                instanceParent = instanceParent.Parent;

    //                if (instanceParent as Form != null) break;
    //            }

    //            //打开属性编辑器修改数据 
    //            return frmProToolVisible.EditValue(instanceParent, (ISysDesign)instance, value);
    //        }
    //        catch (Exception ex)
    //        {
    //            MsgBox.ShowException(ex);
    //            return null;
    //        }
    //    }
    //}

    //public class UserToolProEditor : UITypeEditor
    //{
    //    public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
    //    {
    //        //指定为模式窗体属性编辑器类型 
    //        return UITypeEditorEditStyle.Modal;
    //    }

    //    public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    //    {
    //        //打开属性编辑器修改数据  
    //        try
    //        {
    //            Control instance = (context.Instance as System.Windows.Forms.Control);
    //            Control instanceParent = instance.Parent;

    //            while (instanceParent.Parent != null)
    //            {
    //                instanceParent = instanceParent.Parent;

    //                if (instanceParent as Form != null) break;
    //            }

    //            //打开属性编辑器修改数据 
    //            return frmProUserTools.EditValue(instanceParent, (ISysDesign)instance, value);
    //        }
    //        catch (Exception ex)
    //        {
    //            MsgBox.ShowException(ex);
    //            return null;
    //        }
    //    }
    //}

    public class CustomDesignEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            //指定为模式窗体属性编辑器类型 
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            //打开属性编辑器修改数据  
            try
            {
                Control instance = (context.Instance as System.Windows.Forms.Control);
                Control instanceParent = instance.Parent;

                while (instanceParent.Parent != null)
                {
                    instanceParent = instanceParent.Parent;

                    if (instanceParent as Form != null) break;
                }

                //打开属性编辑器修改数据 
                return (instance as ISysDesign).ShowCustomDesign(); //frmProUserTools.EditValue(instanceParent, (ISysDesign)instance, value);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
                return null;
            }
        }
    }




    public class RClickMenuEditor : UITypeEditor
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
                Control instance = (context.Instance as System.Windows.Forms.Control);
                Control instanceParent = instance.Parent;

                while (instanceParent.Parent != null)
                {
                    instanceParent = instanceParent.Parent;

                    if (instanceParent as Form != null) break;
                }

                //打开属性编辑器修改数据 
                return (instance as ISysDesign).ShowRClickMenuDesign(); 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
                return null;
            }
        }
    }
}

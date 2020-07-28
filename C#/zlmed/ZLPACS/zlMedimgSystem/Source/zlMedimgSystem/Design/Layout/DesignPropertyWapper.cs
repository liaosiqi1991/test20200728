

using DevExpress.XtraLayout;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace zlMedimgSystem.Layout
{

    public class DesignItemPropertiesWrapper : BasePropertyGridObjectWrapper
    {

        protected LayoutControlItem _layoutItem { get { return WrappedObject as LayoutControlItem; } }

        public LayoutControlItem DesignItem
        {
            get { return _layoutItem; }
        }
        public Control DesignControl
        {
            get { return _layoutItem.Control; }
        }

        public override BasePropertyGridObjectWrapper Clone()
        {
            return new DesignItemPropertiesWrapper();
        }
    }

    public class SkinListConverter: StringConverter
    {
 

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] skins = new string[DevExpress.Skins.SkinManager.Default.Skins.Count];
            for(int i = 0; i < DevExpress.Skins.SkinManager.Default.Skins.Count; i ++)
            {
                skins[i] = DevExpress.Skins.SkinManager.Default.Skins[i].SkinName;
            }

            StandardValuesCollection svc = new StandardValuesCollection(skins);

            return svc;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }


    public class ParentWindowNameConverter : StringConverter
    {
        
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            BizMainLayout bizMain = context.Instance as BizMainLayout;

            if (bizMain == null) return null ;

            List<string> names = null;

            bizMain.DoQueryParentWindowNamesEvent(out names);

            //绑定父窗体名称
            //string[] binds = new string[names.Count];
            //for (int i = 0; i < names.Count; i++)
            //{
            //    if (names[i] == bizMain.DesignWindowName) continue;
            //    binds[i] = names[i];
            //}
            
            names.Remove(bizMain.DesignWindowName);
            names.Insert(0, "");

            StandardValuesCollection svc = new StandardValuesCollection(names);

            return svc;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}

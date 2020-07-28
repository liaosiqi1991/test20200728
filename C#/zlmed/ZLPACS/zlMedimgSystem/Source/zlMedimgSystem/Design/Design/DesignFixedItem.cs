

namespace zlMedimgSystem.Design
{
    //[Serializable]
    //public class DesignLayout : LayoutControlItem, IFixedLayoutControlItem
    //{
    //    // Must return the name of the item's type 
    //    public override string TypeName { get { return ""; } }//这里必须使用固定的名称并且必须和类名称相同 
    //    protected virtual string _customizationName { get { return ""; } }

    //    protected DesignControl _controlCore = null;

    //    public DesignLayout()
    //    {
    //    }

    //    public virtual Control CreateControl()
    //    {
    //        return null;
    //    }


    //    public override string ControlName
    //    {
    //        get
    //        {
    //            if (base.Control == null) return "";
    //            return Control.Name;
    //        }
    //        set
    //        {

    //            if (string.IsNullOrEmpty(value) || base.Control == null) return;

    //            Control.Name = value;
    //        }
    //    }

    //    public Control DesignControl
    //    {
    //        get { return _controlCore; }
    //        set { _controlCore = (DesignControl)value; }
    //    }



    //    void IFixedLayoutControlItem.OnInitialize()
    //    {
    //        TextVisible = true;
    //    }

    //    // Create and return the item's control. 
    //    Control IFixedLayoutControlItem.OnCreateControl()
    //    {

    //        return CreateControl();
    //    }

    //    // Destroy the item's control. 
    //    void IFixedLayoutControlItem.OnDestroy()
    //    {
    //        if (_controlCore != null)
    //        {
    //            _controlCore.Dispose();
    //            _controlCore = null;
    //        }
    //    }


    //    string IFixedLayoutControlItem.CustomizationName { get { return _customizationName; } }
    //    Image IFixedLayoutControlItem.CustomizationImage { get { return null; } }
    //    bool IFixedLayoutControlItem.AllowChangeTextLocation { get { return false; } }
    //    bool IFixedLayoutControlItem.AllowChangeTextVisibility { get { return false; } }
    //    bool IFixedLayoutControlItem.AllowClipText { get { return false; } }
    //    ILayoutControl IFixedLayoutControlItem.Owner { get { return base.Owner; } set { base.Owner = value; } }

    //    //public Image CustomizationImage => throw new NotImplementedException();
    //}


    //public class DesignControlPropertiesWrapper : BasePropertyGridObjectWrapper
    //{
    //    protected DesignLayout _layoutItem { get { return WrappedObject as DesignLayout; } }

    //    public LayoutControlItem DesignItem
    //    {
    //        get { return _layoutItem; }
    //    }
    //    public Control DesignControl
    //    {
    //        get { return _layoutItem.DesignControl; }
    //    }
    //    public override BasePropertyGridObjectWrapper Clone()
    //    {
    //        return new DesignControlPropertiesWrapper();
    //    }
    //}

 
}

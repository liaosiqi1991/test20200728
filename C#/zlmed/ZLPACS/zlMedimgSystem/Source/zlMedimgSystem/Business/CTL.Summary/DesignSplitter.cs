﻿using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.Summary
{
    

    public class DesignSplitter : SplitterItem, IFixedLayoutControlItem  //EmptySpaceItem, IFixedLayoutControlItem
    {
        public override string TypeName { get { return "DesignSplitter"; } }//这里必须使用固定的名称并且必须和类名称相同 
        protected virtual string _customizationName { get { return "分离控件"; } }

        public DesignSplitter()
        {
            TextVisible = false;
        }

        string IFixedLayoutControlItem.CustomizationName { get { return _customizationName; } }
        Image IFixedLayoutControlItem.CustomizationImage { get { return null; } }
        bool IFixedLayoutControlItem.AllowChangeTextLocation { get { return false; } }
        bool IFixedLayoutControlItem.AllowChangeTextVisibility { get { return false; } }
        bool IFixedLayoutControlItem.AllowClipText { get { return false; } }
        ILayoutControl IFixedLayoutControlItem.Owner { get { return base.Owner; } set { base.Owner = value; } }

    }


    public class DesignSplitterPropertiesWrapper : BasePropertyGridObjectWrapper
    {
        protected DesignSplitter _layoutItem { get { return WrappedObject as DesignSplitter; } }

        public DesignSplitterPropertiesWrapper()
        {

        }

        [DisplayName("名称")]
        public string Name
        {
            get { return _layoutItem.Name; }
        }


        [DisplayName("最小区域")]
        public Size MinSize
        {
            get { return _layoutItem.MinSize; }
            set { _layoutItem.MinSize = value; }
        }

        [DisplayName("最大区域")]
        public Size MaxSize
        {
            get { return _layoutItem.MaxSize; }
            set { _layoutItem.MaxSize = value; }
        }

        [DisplayName("当前区域")]
        public Size Size
        {
            get { return _layoutItem.Size; }
            set { _layoutItem.Size = value; }
        }

        public override BasePropertyGridObjectWrapper Clone()
        {
            return this;
        }
    }
}

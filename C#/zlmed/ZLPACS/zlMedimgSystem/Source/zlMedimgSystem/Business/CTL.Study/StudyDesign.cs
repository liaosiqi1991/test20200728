//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using DevExpress.XtraLayout;
//using zlMedimgSystem.Design;

//namespace zlMedimgSystem.CTL.Study
//{
//    [Serializable]
//    public class StudyDesign : DesignLayout, IFixedLayoutControlItem
//    {
//        // Must return the name of the item's type 
//        public override string TypeName { get { return "StudyDesign"; } }//这里必须使用固定的名称并且必须和类名称相同
//        protected override string _customizationName { get { return "检查模块"; } }
        

//        public StudyDesign()
//        {
             
//        }

//        public override Control CreateControl()
//        {
//            if (_controlCore != null) return _controlCore;

//            _controlCore = new StudyControl();
//            _controlCore.Name = _controlCore.ModuleName + "_" + DateTime.Now.Ticks.ToString();

//            base.Control = _controlCore;

//            return _controlCore;
//        }

//    }
//}

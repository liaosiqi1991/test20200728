using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.Layout
{
    public  partial class BizDesignBase: XtraForm, ISysDesign, ISysMainModule, IBizDataQuery
    //public partial class BizDesignBase : Form, ISysDesign, ISysMainModule, IBizDataQuery
    {
        
        //是否设计模式
        protected bool _isDesignMode = true;


        protected IDBQuery _dbHelper = null;    
        protected ILoginUser _userData = null;
        protected IBizDataTransferCenter _dataTransCenter = null; 
        protected IStationInfo _stationInfo = null;
        protected IParameters _parameters = null;
        protected ISysLog _sysLog = null;

        //protected BizData _curBizData = null;

        public BizDesignBase()
            : this(true)
        { 
        }

        public BizDesignBase(bool isDesignMode)
            :base()
        {
            InitializeComponent();
             
            InitTitle();

            InitModuleInterfacce();

            _isDesignMode = isDesignMode; 
        }



        public virtual void Init(IDBQuery dbHelper, ILoginUser userData, IStationInfo stationInfo, IBizDataTransferCenter parentTransferCenter)
        {
            _dbHelper = dbHelper;
            _userData = userData;
            _stationInfo = stationInfo; 

            //初始化系统框架相关对象
            _dataTransCenter = new BizDataTransferCenter();
            _dataTransCenter.ParentDataCenter = parentTransferCenter;
        }

        public virtual void Terminated()
        {

        }

        public virtual void RefreshModule()
        {
            foreach (ISysDesign sd in _regBizModules.Values)
            {
                ISysBizModule sbm = sd as ISysBizModule;

                if (sbm == null) continue;

                sbm.RefreshModule();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BizDesignBase
            // 
            this.ClientSize = new System.Drawing.Size(542, 428);
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BizDesignBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

    }
}

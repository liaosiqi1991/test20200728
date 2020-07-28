using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.DataView
{
    public partial class frmTest : Form
    {

        public event QueryParValueEvent OnRequestPar;

        private IDBQuery _dbHelper = null;
        private DataViewModuleDesign _dataViewDesign = null;
        public frmTest()
        {
            InitializeComponent();
        }

        public void ShowTest(IDBQuery dbHelper, DataViewModuleDesign dataViewDesign, IWin32Window owner)
        {
            _dbHelper = dbHelper;
            _dataViewDesign = dataViewDesign;

            this.ShowDialog(owner);
        }

        public object QueryPar(string parName)
        {
            return OnRequestPar?.Invoke(parName);
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            try
            {
                dataViewLayout1.OnRequestPar += QueryPar;
                dataViewLayout1.ThridDBHelper = _dbHelper;

                dataViewLayout1.LoadLayout(_dataViewDesign.Items, _dataViewDesign.LayoutFmt);
                 

                dataViewLayout1.BindDataView(_dbHelper, _dataViewDesign.DataFrom, _dataViewDesign.DBSourceAlias);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

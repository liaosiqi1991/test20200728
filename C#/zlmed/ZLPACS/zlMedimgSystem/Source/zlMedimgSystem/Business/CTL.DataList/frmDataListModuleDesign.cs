using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.DataList
{
    public partial class frmDataListModuleDesign : Form
    {
        private bool _isOk = false;
        private DataListModuleDesign _dataListDesign = null;


        public frmDataListModuleDesign()
        {
            InitializeComponent();
        }

        public bool ShowDataListModuleDesign(DataListModuleDesign dataListDesign, IWin32Window owner)
        {
            _isOk = false;
            _dataListDesign = dataListDesign;

            this.ShowDialog(owner);

            return _isOk;
        }

        private void frmDataListModuleDesign_Load(object sender, EventArgs e)
        {
            try
            {
                chkAllowGroup.Checked = _dataListDesign.AllowGroup;
                chkAllowRowNo.Checked = _dataListDesign.AllowRowNo;
                chkAllowFixColCfg.Checked = _dataListDesign.AllowFixColCfg;
                chkShowCol.Checked = _dataListDesign.AllowShowColTitle;
                chkAllowFilter.Checked = _dataListDesign.AllowFilter;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                _isOk = true;

                _dataListDesign.AllowGroup = chkAllowGroup.Checked;
                _dataListDesign.AllowRowNo = chkAllowRowNo.Checked;
                _dataListDesign.AllowFixColCfg = chkAllowFixColCfg.Checked;
                _dataListDesign.AllowShowColTitle = chkShowCol.Checked;
                _dataListDesign.AllowFilter = chkAllowFilter.Checked;

                this.Close();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

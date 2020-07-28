using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Summary
{
    public partial class frmSummaryDesign : Form
    {
        private SummaryModuleDesign _summaryDesign = null;
        private IDBQuery _dbHelper = null;
        public frmSummaryDesign()
        {
            InitializeComponent();
        }

        public void ShowDesign(SummaryModuleDesign summaryDesign, IDBQuery dbHelper, IWin32Window owner)
        {
            _summaryDesign = summaryDesign;
            _dbHelper = dbHelper;

            GlobalDB.DBSource = _summaryDesign.DBSource;
            GlobalDB.DBHelper = _dbHelper;

            this.ShowDialog(owner);
        }

        private void frmSummaryDesign_Load(object sender, EventArgs e)
        {
            layoutControl1.UnRegisterFixedItemType(typeof(SimpleLabelItem));
            layoutControl1.UnRegisterFixedItemType(typeof(SimpleSeparator));
            layoutControl1.UnRegisterFixedItemType(typeof(EmptySpaceItem));
            layoutControl1.UnRegisterFixedItemType(typeof(SplitterItem));



            layoutControl1.RegisterFixedItemType(typeof(DesignEmpty));
            layoutControl1.RegisterCustomPropertyGridWrapper(typeof(DesignEmpty), typeof(DesignEmptyPropertiesWrapper));

            layoutControl1.RegisterFixedItemType(typeof(DesignLabel));
            layoutControl1.RegisterCustomPropertyGridWrapper(typeof(DesignLabel), typeof(DesignLabelPropertiesWrapper));

            layoutControl1.RegisterFixedItemType(typeof(DesignSplitter));
            layoutControl1.RegisterCustomPropertyGridWrapper(typeof(DesignSplitter), typeof(DesignSplitterPropertiesWrapper));

            layoutControl1.ShowCustomizationForm();

            if (_summaryDesign == null) return;

            LayoutControlEx.SetLayoutString(layoutControl1, _summaryDesign.LayoutFormats);

            foreach(ItemFormat itemFmt in _summaryDesign.ItemFormats)
            {
                BaseLayoutItem bli = layoutControl1.Items.FindByName(itemFmt.ItemName);

                DesignLabel dl = bli as DesignLabel;
                if (dl != null)
                {
                    dl.Formats = itemFmt.Formats;
                }
            }
        }

 

        private void tsbData_Click(object sender, EventArgs e)
        {
            try
            { 
                using (frmDBSource dbSource = new frmDBSource())
                {
                    dbSource.ShowDesign(GlobalDB.DBSource, GlobalDB.DBHelper, this);                     
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
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

        private void tsbSave_Click(object sender, EventArgs e)
        {

            string GetLayoutString(LayoutControl layout)
            {
                //删除隐藏的item，避免数据库中存储无效的item
                layout.HiddenItems.Clear();

                using (MemoryStream ms = new MemoryStream())
                using (StreamReader sr = new StreamReader(ms))
                {
                    layout.SaveLayoutToStream(ms);
                    ms.Position = 0;

                    return sr.ReadToEnd();
                }
            }

            List<ItemFormat> GetItemFormats(LayoutControl layout)
            {
                layout.HiddenItems.Clear();

                List<ItemFormat> result = new List<ItemFormat>();

                foreach (BaseLayoutItem bli in layout.Items)
                {
                    DesignLabel dl = bli as DesignLabel;
                    if (dl != null)
                    {
                        ItemFormat itemFmt = new ItemFormat();
                        itemFmt.ItemName = dl.Name;
                        itemFmt.Formats = dl.Formats;

                        result.Add(itemFmt);
                    }
                }

                return result;
            }

            try
            {
                if (_summaryDesign == null) _summaryDesign = new SummaryModuleDesign();

                _summaryDesign.DBSource = GlobalDB.DBSource;
                _summaryDesign.LayoutFormats = GetLayoutString(layoutControl1);
                _summaryDesign.ItemFormats = GetItemFormats(layoutControl1);

                this.Close();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmFixedConfig : Form
    {
        private GridControl _gc = null;

        public frmFixedConfig()
        {
            InitializeComponent();
        }

        public void ShowFixedConfig(GridControl gc, IWin32Window owner)
        {
            _gc = gc;

            this.ShowDialog(owner);

        }

        private void frmFixedConfig_Load(object sender, EventArgs e)
        {
            try
            {
                
                foreach(GridColumn col in (_gc.MainView as GridView).Columns)
                {
                    if (col.Visible == false) continue;

                    checkedListBox1.Items.Add(col.FieldName, (col.Fixed == FixedStyle.None) ? false : true);
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

         private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                string fName = checkedListBox1.Items[e.Index].ToString();
                if (e.NewValue == CheckState.Checked)
                {
                    (_gc.MainView as GridView).Columns[fName].Fixed = FixedStyle.Left;
                }
                else
                {
                    (_gc.MainView as GridView).Columns[fName].Fixed = FixedStyle.None;
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }


}

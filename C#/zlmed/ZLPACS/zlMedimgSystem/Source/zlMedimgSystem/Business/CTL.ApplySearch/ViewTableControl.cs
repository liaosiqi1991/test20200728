using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.CTL.ApplySearch
{
    public partial class ViewTableControl : UserControl
    {
        #region 控件事件
        public delegate void FocusedRowChangedHandle(string strOrderID);

        public event FocusedRowChangedHandle UserControlFocusedRowChanged;

        #endregion

        #region 私有变量
        bool isRefreshing = false;

        #endregion

        #region 构造函数
        public ViewTableControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 公共方法
        public void Refresh(DataTable dt)
        {
            isRefreshing = true;
            try
            {
                //gridView.SelectRow(-1);
                gridTable.DataSource = null;
                gridTable.DataSource = dt;

                gridView.BestFitColumns();
                ShowTableImage();
            }
            finally
            {
                isRefreshing = false;
            }
            //gridView.RestoreLayoutFromXml("D:\\AAA");  //绑定数据的，无法记录表格布局？
        }

        #endregion

        #region 私有方法
        private void ShowTableImage()
        {
                                       
            for(int i =0;i<gridView.Columns.Count;i++)
            {
                if (gridView.Columns[i].ColumnType == typeof(byte[]))
                {
                    gridView.Columns[i].Width = 20;
                }
            }
            return;
        }

        private void ViewTableControl_Resize(object sender, EventArgs e)
        {
            panelTable.Left = 0;
            panelTable.Top = 0;
            panelTable.Width = this.Width ;
            panelTable.Height = this.Height ;
            gridTable.Left = 0;
            gridTable.Top = 0;
            gridTable.Width = panelTable.Width;
            gridTable.Height = panelTable.Height;
        }
        #endregion

        private void ViewTableControl_Load(object sender, EventArgs e)
        {           
            
            gridTable.DataSource = null;
            gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void gridView_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {            
            if (this.gridView.RowCount == 0)
            {
                string str = "无数据，请调整检索条件后重新查询。";
                Font f = new Font("宋体", 10, FontStyle.Bold);
                Rectangle r = new Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 5, e.Bounds.Width - 5, e.Bounds.Height - 5);
                e.Graphics.DrawString(str, f, Brushes.Black, r);
            }
            
        }

        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            return;
        }

        private void ViewTableControl_Layout(object sender, LayoutEventArgs e)
        {
            //gridView.SaveLayoutToXml("D:\\AAA");
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (gridView.GetSelectedRows().Length == 0 || isRefreshing ==true) return;

            if (gridView.GetSelectedRows().Length == 0 ) return;

            int intSelRow = gridView.GetSelectedRows()[0];
            if (intSelRow < 0)
                return;
                       
            try
            {
                string strOrderID = gridView.GetRowCellValue(intSelRow, "医嘱ID").ToString();
                //UserControlFocusedRowChanged?.Invoke(strOrderID); //这句话会导致外部出现两次事件？
                if(UserControlFocusedRowChanged != null)
                {
                    UserControlFocusedRowChanged(strOrderID);
                }
            }
            catch(Exception )
            {
                string strApplyID = gridView.GetRowCellValue(intSelRow, "申请ID").ToString();
                if (UserControlFocusedRowChanged != null)
                {
                    UserControlFocusedRowChanged(strApplyID);
                }
                //UserControlFocusedRowChanged?.Invoke(strApplyID);
            }                        
        }

        private void gridTable_Click(object sender, EventArgs e)
        {

        }
    }
}

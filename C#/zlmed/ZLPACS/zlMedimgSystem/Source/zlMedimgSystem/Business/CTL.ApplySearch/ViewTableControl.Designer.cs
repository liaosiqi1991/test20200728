namespace zlMedimgSystem.CTL.ApplySearch
{
    partial class ViewTableControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTable = new System.Windows.Forms.Panel();
            this.gridTable = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.panelTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTable
            // 
            this.panelTable.Controls.Add(this.gridTable);
            this.panelTable.Location = new System.Drawing.Point(27, 16);
            this.panelTable.Name = "panelTable";
            this.panelTable.Size = new System.Drawing.Size(1077, 641);
            this.panelTable.TabIndex = 0;
            // 
            // gridTable
            // 
            this.gridTable.Location = new System.Drawing.Point(3, 0);
            this.gridTable.MainView = this.gridView;
            this.gridTable.Name = "gridTable";
            this.gridTable.Size = new System.Drawing.Size(1032, 603);
            this.gridTable.TabIndex = 0;
            this.gridTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.layoutView1});
            this.gridTable.Click += new System.EventHandler(this.gridTable_Click);
            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridTable;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.gridView_CustomDrawEmptyForeground);
            this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
            this.gridView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView_CustomColumnDisplayText);
            // 
            // layoutView1
            // 
            this.layoutView1.GridControl = this.gridTable;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.TemplateCard = null;
            // 
            // ViewTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTable);
            this.Name = "ViewTableControl";
            this.Size = new System.Drawing.Size(1130, 691);
            this.Load += new System.EventHandler(this.ViewTableControl_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.ViewTableControl_Layout);
            this.Resize += new System.EventHandler(this.ViewTableControl_Resize);
            this.panelTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTable;
        private DevExpress.XtraGrid.GridControl gridTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
    }
}

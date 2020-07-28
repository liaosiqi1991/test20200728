namespace zlMedimgSystem.Design
{
    partial class frmProEventEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProEventEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listModule = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cbxModuleType = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lvEvent = new System.Windows.Forms.ListView();
            this.listEventActions = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxDataType = new System.Windows.Forms.ComboBox();
            this.txtDataDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butNew = new System.Windows.Forms.Button();
            this.butDel = new System.Windows.Forms.Button();
            this.cbxDataName = new System.Windows.Forms.ComboBox();
            this.cbxModuleAction = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.butModify = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer1.Panel1.Controls.Add(this.listModule);
            this.splitContainer1.Panel1.Controls.Add(this.cbxModuleType);
            this.splitContainer1.Panel1.Controls.Add(this.splitter1);
            this.splitContainer1.Panel1.Controls.Add(this.lvEvent);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listEventActions);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(876, 571);
            this.splitContainer1.SplitterDistance = 243;
            this.splitContainer1.TabIndex = 3;
            // 
            // listModule
            // 
            this.listModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listModule.FullRowSelect = true;
            this.listModule.HideSelection = false;
            this.listModule.LargeImageList = this.imageList1;
            this.listModule.Location = new System.Drawing.Point(2, 307);
            this.listModule.MultiSelect = false;
            this.listModule.Name = "listModule";
            this.listModule.Size = new System.Drawing.Size(239, 262);
            this.listModule.SmallImageList = this.imageList1;
            this.listModule.TabIndex = 3;
            this.listModule.UseCompatibleStateImageBehavior = false;
            this.listModule.SelectedIndexChanged += new System.EventHandler(this.listModule_SelectedIndexChanged);
            this.listModule.Resize += new System.EventHandler(this.listModule_Resize);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "flash.ico");
            this.imageList1.Images.SetKeyName(1, "component.ico");
            // 
            // cbxModuleType
            // 
            this.cbxModuleType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxModuleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxModuleType.FormattingEnabled = true;
            this.cbxModuleType.Location = new System.Drawing.Point(2, 287);
            this.cbxModuleType.Name = "cbxModuleType";
            this.cbxModuleType.Size = new System.Drawing.Size(239, 20);
            this.cbxModuleType.TabIndex = 2;
            this.cbxModuleType.SelectedIndexChanged += new System.EventHandler(this.cbxModuleType_SelectedIndexChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(2, 284);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(239, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // lvEvent
            // 
            this.lvEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvEvent.HideSelection = false;
            this.lvEvent.LargeImageList = this.imageList1;
            this.lvEvent.Location = new System.Drawing.Point(2, 2);
            this.lvEvent.MultiSelect = false;
            this.lvEvent.Name = "lvEvent";
            this.lvEvent.Size = new System.Drawing.Size(239, 282);
            this.lvEvent.SmallImageList = this.imageList1;
            this.lvEvent.TabIndex = 0;
            this.lvEvent.UseCompatibleStateImageBehavior = false;
            this.lvEvent.SelectedIndexChanged += new System.EventHandler(this.lvEvent_SelectedIndexChanged);
            this.lvEvent.Resize += new System.EventHandler(this.lvEvent_Resize);
            // 
            // listEventActions
            // 
            this.listEventActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listEventActions.FullRowSelect = true;
            this.listEventActions.HideSelection = false;
            this.listEventActions.Location = new System.Drawing.Point(0, 231);
            this.listEventActions.MultiSelect = false;
            this.listEventActions.Name = "listEventActions";
            this.listEventActions.Size = new System.Drawing.Size(629, 340);
            this.listEventActions.TabIndex = 4;
            this.listEventActions.UseCompatibleStateImageBehavior = false;
            this.listEventActions.SelectedIndexChanged += new System.EventHandler(this.listEventActions_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxDataType);
            this.panel1.Controls.Add(this.txtDataDescription);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cbxDataName);
            this.panel1.Controls.Add(this.cbxModuleAction);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textDesc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTag);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 231);
            this.panel1.TabIndex = 3;
            // 
            // cbxDataType
            // 
            this.cbxDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDataType.FormattingEnabled = true;
            this.cbxDataType.Location = new System.Drawing.Point(91, 93);
            this.cbxDataType.Name = "cbxDataType";
            this.cbxDataType.Size = new System.Drawing.Size(127, 20);
            this.cbxDataType.TabIndex = 16;
            this.cbxDataType.SelectedIndexChanged += new System.EventHandler(this.cbxDataType_SelectedIndexChanged);
            // 
            // txtDataDescription
            // 
            this.txtDataDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.txtDataDescription.Location = new System.Drawing.Point(91, 114);
            this.txtDataDescription.Multiline = true;
            this.txtDataDescription.Name = "txtDataDescription";
            this.txtDataDescription.ReadOnly = true;
            this.txtDataDescription.Size = new System.Drawing.Size(535, 49);
            this.txtDataDescription.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(18, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 27);
            this.label6.TabIndex = 10;
            this.label6.Text = "执行标记";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.butModify);
            this.panel2.Controls.Add(this.butNew);
            this.panel2.Controls.Add(this.butDel);
            this.panel2.Location = new System.Drawing.Point(91, 198);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 28);
            this.panel2.TabIndex = 8;
            // 
            // butNew
            // 
            this.butNew.Location = new System.Drawing.Point(3, 3);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(45, 23);
            this.butNew.TabIndex = 3;
            this.butNew.Text = "新增";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // butDel
            // 
            this.butDel.Location = new System.Drawing.Point(54, 3);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(45, 23);
            this.butDel.TabIndex = 2;
            this.butDel.Text = "删除";
            this.butDel.UseVisualStyleBackColor = true;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // cbxDataName
            // 
            this.cbxDataName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxDataName.FormattingEnabled = true;
            this.cbxDataName.Location = new System.Drawing.Point(224, 93);
            this.cbxDataName.Name = "cbxDataName";
            this.cbxDataName.Size = new System.Drawing.Size(402, 20);
            this.cbxDataName.TabIndex = 11;
            this.cbxDataName.SelectedIndexChanged += new System.EventHandler(this.cbxDataName_SelectedIndexChanged);
            this.cbxDataName.TextChanged += new System.EventHandler(this.cbxDataName_TextChanged);
            // 
            // cbxModuleAction
            // 
            this.cbxModuleAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxModuleAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxModuleAction.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxModuleAction.FormattingEnabled = true;
            this.cbxModuleAction.Location = new System.Drawing.Point(91, 10);
            this.cbxModuleAction.Name = "cbxModuleAction";
            this.cbxModuleAction.Size = new System.Drawing.Size(535, 22);
            this.cbxModuleAction.TabIndex = 1;
            this.cbxModuleAction.SelectedIndexChanged += new System.EventHandler(this.cbxModuleAction_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "请求数据";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textDesc
            // 
            this.textDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.textDesc.Location = new System.Drawing.Point(91, 33);
            this.textDesc.Multiline = true;
            this.textDesc.Name = "textDesc";
            this.textDesc.ReadOnly = true;
            this.textDesc.Size = new System.Drawing.Size(535, 49);
            this.textDesc.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "执行事务名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTag
            // 
            this.txtTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTag.Location = new System.Drawing.Point(91, 174);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(535, 21);
            this.txtTag.TabIndex = 12;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 571);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(876, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // butModify
            // 
            this.butModify.Location = new System.Drawing.Point(105, 3);
            this.butModify.Name = "butModify";
            this.butModify.Size = new System.Drawing.Size(45, 23);
            this.butModify.TabIndex = 4;
            this.butModify.Text = "修改";
            this.butModify.UseVisualStyleBackColor = true;
            this.butModify.Click += new System.EventHandler(this.butModify_Click);
            // 
            // frmProEventEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 593);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmProEventEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "事件设计器";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxModuleAction;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Button butDel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textDesc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxDataName;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.TextBox txtDataDescription;
        private System.Windows.Forms.ListView lvEvent;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView listModule;
        private System.Windows.Forms.ComboBox cbxModuleType;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ComboBox cbxDataType;
        private System.Windows.Forms.ListView listEventActions;
        private System.Windows.Forms.Button butModify;
    }
}
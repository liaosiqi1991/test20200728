﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.DataView
{
 

    public delegate void SelDesignControl(object selControl);
    public partial class DesignMiddleWare : DevExpress.XtraLayout.Customization.UserCustomizationForm
    {
        public event SelDesignControl OnSelDesign;


        public DesignMiddleWare()
        {
            InitializeComponent();
            Visible = false;
        }

        private void DesignMiddleWare_Load(object sender, EventArgs e)
        {
            Visible = false;
            ownerControlCore.ItemSelectionChanged += ItemSelectionChangedEvent;
        }
        
        private void ItemSelectionChangedEvent(object sender, EventArgs e)
        {
            if (OnSelDesign == null) return;
            OnSelDesign(sender);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DesignMiddleWare
            // 
            this.ClientSize = new System.Drawing.Size(206, 107);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.Name = "DesignMiddleWare";
            this.Opacity = 0.01D;
            this.Load += new System.EventHandler(this.DesignMiddleWare_Load);
            this.ResumeLayout(false);

        }
    }
}

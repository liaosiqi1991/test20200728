using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.Design
{
    [ToolboxItem(false)]
    public partial class DesignComponent : DesignControl, ISysDesign, ISysBizModule, IBizDataQuery
    {
        public DesignComponent()
        {
            InitializeComponent();

            base.Visible = false;
            base.Dock = DockStyle.None;
            base.Enabled = true;
        }

        public override void ModuleLoaded()
        {
            base.ModuleLoaded();
        }

        public override void Terminated()
        {
            base.Terminated();
        }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Visible { get { return base.Visible; }  }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DockStyle Dock { get { return base.Dock; }  }

        [Bindable(false), Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Enabled { get { return base.Enabled; }  }


        [Bindable(false), Browsable(false)]
        public new Size Size
        {
            get { return base.Size; }
            set
            {
                base.Size = value;
            }
        }


        [Bindable(false), Browsable(false)]
        public new Size MaximumSize
        {
            get { return base.MaximumSize; }
            set { base.MaximumSize = value; }
        }



        [Bindable(false), Browsable(false)]
        public new Size MinimumSize
        {
            get { return base.MinimumSize; }
            set { base.MinimumSize = value; }
        }


        [Bindable(false), Browsable(false)]
        public new Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }


        [Bindable(false), Browsable(false)]
        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }


        [Bindable(false), Browsable(false)]
        public new ImeMode ImeMode
        {
            get { return base.ImeMode; }
            set { base.ImeMode = value; }
        }

        [Bindable(false), Browsable(false)]
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set { base.BorderStyle = value; }
        }
    }
}

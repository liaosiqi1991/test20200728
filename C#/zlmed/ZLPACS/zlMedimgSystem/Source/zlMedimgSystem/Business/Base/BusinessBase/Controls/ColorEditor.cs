using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace zlMedimgSystem.BusinessBase.Controls
{
    public partial class ColorEditor : UserControl
    {
        public ColorEditor()
        {
            InitializeComponent();
        }

        public Color Color
        {
            get { return colorPickEdit1.Color; }
            set { colorPickEdit1.Color = value; }
        }
    }
}

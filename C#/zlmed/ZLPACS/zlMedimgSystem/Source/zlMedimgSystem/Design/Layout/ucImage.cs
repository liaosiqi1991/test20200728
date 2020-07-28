using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ucImage : UserControl
    {
        public ucImage()
        {
            InitializeComponent();
        }

 

        private void picImg_Resize(object sender, EventArgs e)
        {
            try
            {
                picCheck.Left = 2;
                picCheck.Top = 2;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void picCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (picCheck.BackColor == Color.White)
                {
                    picCheck.BackColor = Color.Red;
                }
                else
                {
                    picCheck.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ucImage_Leave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        private void ucImage_Enter(object sender, EventArgs e)
        {
            BackColor = Color.Red;
             
        }
    }
}

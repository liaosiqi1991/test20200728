using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.ExtFuncs
{
    public partial class frmFuncInput : Form
    {

        public delegate bool CheckNameExists(string name);

        private InputItem _inputItem = null;
        private bool _isOk = false;


        public event CheckNameExists OnCheckNameExists;
        public frmFuncInput()
        {
            InitializeComponent();
        }
  
        public InputItem ShowInput(IWin32Window owner, InputItem ii)
        {
            _inputItem = ii;

            this.ShowDialog(owner);

            return _inputItem;
        }

        private void frmFuncInput_Load(object sender, EventArgs e)
        {
            try
            {
                txtInputName.Text = _inputItem.Name;
                cbxControlType.Text = _inputItem.ControlType;
                txtDefaultValue.Text = _inputItem.DefaultValue;
                rtbDataFrom.Text = _inputItem.DataFrom;
                chkIsSave.Checked = _inputItem.AllowStorage;

                txtInputName.Enabled = string.IsNullOrEmpty(_inputItem.Name);
                cbxControlType.Enabled = txtInputName.Enabled;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private bool ValidateData()
        {
            if (txtInputName.Text.Length <= 0)
            {
                MessageBox.Show("项目名称尚未录入。", "提示");

                txtInputName.Focus();

                return false;
            }

            if (OnCheckNameExists != null)
            {
                bool isExists = OnCheckNameExists(txtInputName.Text);

                if (isExists)
                {
                    MessageBox.Show("名称不允许重复。", "提示");

                    txtInputName.Focus();

                    return false;
                }
            }

            return true;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                _isOk = false;
                _inputItem = null;
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
                if (ValidateData() == false) return;

                _isOk = true;

                _inputItem.Name = txtInputName.Text;
                _inputItem.ControlType = cbxControlType.Text;
                _inputItem.DefaultValue = txtDefaultValue.Text;
                _inputItem.DataFrom = rtbDataFrom.Text;
                _inputItem.AllowStorage = chkIsSave.Checked;

                this.Close();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmFuncInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (_isOk == false) _inputItem = null;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

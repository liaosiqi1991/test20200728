using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Chars
{
    public partial class frmCharConfig : Form
    { 

        private string _userId = "";

        private IDBQuery _dbHelper = null;
        private ParameterModel _pm = null;
        private JReportChars _charData = null;
 
        public frmCharConfig()
        {
            InitializeComponent();
        }

        public JReportChars ShowCharConfig(JReportChars charData, IDBQuery dbHelper, string userId, IWin32Window owner)
        {
            _userId = userId;

            _dbHelper = dbHelper;
            _pm = new ParameterModel(dbHelper);
            _charData = charData;
             
            this.ShowDialog(owner);

            return _charData;

        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                _charData = null;
                this.Close();

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void frmCharConfig_Load(object sender, EventArgs e)
        {
            try
            {
                if (_charData == null || _charData.字符明细.Count <= 0) return;

                foreach(JReportCharItem charItem in _charData.字符明细)
                {
                    richTextBox1.Text = richTextBox1.Text + charItem.字符内容 + System.Environment.NewLine;
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                if (_charData == null) _charData = new JReportChars();

                string[] chars = richTextBox1.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                _charData.字符明细.Clear();

                foreach (string curChar in chars)
                {
                    _charData.字符明细.Add(new JReportCharItem(curChar));
                }

                ParameterData parData = new ParameterData();

                parData.参数ID = SqlHelper.GetNumGuid();
                parData.参数名称 = "特殊字符";
                parData.参数标记 = _userId;
                parData.参数取值 = JsonHelper.SerializeObject(_charData);

                _pm.WriteParameter(parData);
                 
                this.Close();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

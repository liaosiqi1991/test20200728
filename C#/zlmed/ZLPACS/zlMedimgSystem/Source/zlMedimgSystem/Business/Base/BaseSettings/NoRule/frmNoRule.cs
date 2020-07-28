using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmNoRule : Form, ISetting
    {
        private IDBQuery _dbHelper = null;

        private ParameterModel _pm = null;
        private NoRuleModel _nrm = null;
        private ILoginUser _loginUser = null;

        //private bool _isBinding = false;

        public frmNoRule()
            : this(null, null)
        {
        }

        public frmNoRule(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }

        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {
            _dbHelper = dbHelper;

            _pm = new ParameterModel(_dbHelper);
            _nrm = new NoRuleModel(dbHelper);

            _loginUser = loginUser;
        }

        private void frmNoRule_Resize(object sender, EventArgs e)
        {
            try
            {
                panel1.Left = (this.Width - panel1.Width) / 2;
                panel1.Top = (this.Height - panel1.Height) / 2;

                if (panel1.Left <= 0) panel1.Left = 0;
                if (panel1.Top <= 0) panel1.Top = 0;
            }
            catch
            { }
        }

        private JNoRuleInfo GetCurrentNoRule()
        {
            JNoRuleInfo noRule = new JNoRuleInfo();
            noRule.检查号类型 = (NoType)cbxNoType.SelectedIndex;
            noRule.前缀方式 = (NoPrefixWay)cbxPrefixType.SelectedIndex;
            noRule.前缀文本 = txtPrefixContext.Text;
            noRule.前缀分隔符 = cbxPrefixSplit.Text;
            noRule.年份格式 = cbxYearFmt.Text;
            noRule.使用月份 = chkUseMonth.Checked;
            noRule.使用天数 = chkUseDays.Checked;
            noRule.日期分隔符 = cbxDateSplit.Text;
            noRule.序号长度 = cbxNumLen.SelectedIndex + 4;
            noRule.号码识别方式 = (NoIdentWay)cbxIdentWay.SelectedIndex;
            noRule.号码保持统一 = chkKeep.Checked;

            return noRule;
        }

        private void butApply_Click(object sender, EventArgs e)
        {
            try
            {
                JNoRuleInfo noRule = GetCurrentNoRule();

                _nrm.SetNoRuleInfo(noRule, cbxDepartment.SelectedValue.ToString());

                ButtonHint.Start(butApply, "OK");

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        public void RefreshSetting()
        {
            DataTable dtDepartment = _nrm.GetDepartment();

            cbxDepartment.DataSource = null;

            cbxDepartment.DisplayMember = "科室名称";
            cbxDepartment.ValueMember = "科室ID";

            cbxDepartment.DataSource = dtDepartment;

            if (cbxDepartment.Items.Count > 0) cbxDepartment.SelectedIndex = 0;

            cbxNoType.SelectedText = "自定义号";
            cbxYearFmt.SelectedIndex = 0;

            cbxIdentWay.SelectedIndex = 0;
            chkKeep.Checked = false;
        }
        private void frmNoRule_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshSetting();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ClearData()
        {
            cbxNoType.SelectedIndex = -1;
            cbxPrefixType.SelectedIndex = -1;
            txtPrefixContext.Text = "STU";
            cbxPrefixSplit.SelectedIndex = -1;
            cbxYearFmt.SelectedIndex = -1;
            chkUseMonth.Checked = false;
            chkUseDays.Checked = false;
            cbxDateSplit.SelectedIndex = -1;
            cbxNumLen.SelectedIndex = -1 ;
            cbxIdentWay.SelectedIndex = 0;
            chkKeep.Checked = false;
        }

        private void cbxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearData();

                if (string.IsNullOrEmpty(cbxDepartment.Text)) return;
                 
                JNoRuleInfo noRule = _nrm.GetNoRuleInfo(cbxDepartment.SelectedValue.ToString());
                if (noRule == null) return;
                
                cbxNoType.SelectedIndex = (int)noRule.检查号类型;
                cbxPrefixType.SelectedIndex = (int)noRule.前缀方式;
                txtPrefixContext.Text = noRule.前缀文本;
                cbxPrefixSplit.Text = noRule.前缀分隔符;
                cbxYearFmt.Text = noRule.年份格式;
                chkUseMonth.Checked = noRule.使用月份;
                chkUseDays.Checked = noRule.使用天数;
                cbxDateSplit.Text = noRule.日期分隔符;
                cbxNumLen.Text =  noRule.序号长度.ToString() + "位";
                cbxIdentWay.SelectedIndex = (int)noRule.号码识别方式;
                chkKeep.Checked = noRule.号码保持统一;
                
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }

        private void cbxNoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxNoType.Text.Equals("自定义号"))
                {
                    groupBox1.Enabled = true;
                }
                else
                {
                    groupBox1.Enabled = false;
                }

                CreateNoDemo();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void CreateNoDemo()
        {
            JNoRuleInfo noRule = GetCurrentNoRule();

            if (noRule.检查号类型 != NoType.fiCustom)
            {
                labDemo.Text = "号码示例:";
                return;
            }

            string studyNo = "";

            if (noRule.前缀方式 == NoPrefixWay.noFixText)
            {
                studyNo = studyNo + txtPrefixContext.Text;
            }
            else if (noRule.前缀方式 == NoPrefixWay.noImageKindCode)
            {
                studyNo = studyNo + "US";
            }

            if (string.IsNullOrEmpty(noRule.前缀分隔符.Trim()) == false)
            {
                studyNo = studyNo + noRule.前缀分隔符;
            }

            if (string.IsNullOrEmpty(noRule.年份格式) == false)
            {
                studyNo = studyNo + noRule.年份格式.Replace("YYYY", DateTime.Now.Year.ToString()).Replace("YY", DateTime.Now.Year.ToString().Substring(2, 2));
            }

            if (noRule.使用月份)
            {
                studyNo = studyNo + DateTime.Now.Month.ToString().PadLeft(2, '0');
            }

            if (noRule.使用天数)
            {
                if (noRule.使用月份)
                {
                    studyNo = studyNo + DateTime.Now.Day.ToString().PadLeft(2, '0');
                }
                else
                {
                    studyNo = studyNo + DateTime.Now.DayOfYear.ToString().PadLeft(3, '0');
                }
            }

            if (string.IsNullOrEmpty(noRule.日期分隔符.Trim()) == false)
            {
                studyNo = studyNo + noRule.日期分隔符;
            }

            studyNo = studyNo + "1".PadLeft(cbxNumLen.SelectedIndex + 4, '0');

            labDemo.Text = "号码示例:" + studyNo;
        }
        private void cbxNoType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CreateNoDemo();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxPrefixSplit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CreateNoDemo();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxYearFmt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CreateNoDemo();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxDateSplit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CreateNoDemo();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxNumLen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CreateNoDemo();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();

                NoRuleModel nrm = new NoRuleModel(_dbHelper);

                string code = nrm.GetStudyNo("", "超声", @"6LfuLw/NyEabUbskclSyiQ", false);

                nrm.WriteTest(code);


                labDemo.Text = code;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void cbxPrefixType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxPrefixType.SelectedIndex == 0)
                {
                    labFixContext.Enabled = false;
                    txtPrefixContext.Enabled = false;
                }
                else
                {
                    labFixContext.Enabled = true;
                    txtPrefixContext.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
    }

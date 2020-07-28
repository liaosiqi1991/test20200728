using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Services;
using System.IO;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmUserManager : Form, ISetting
    {

        //private bool _isBinding = false;

        private IDBQuery _dbHelper = null;
        private UserModel _um = null;
        private ILoginUser _loginUser = null;
        private ComboxEx _comboxEx = null;//字典下拉框加载方法
        private DepartmentMatchModel _departmentMatchModel = null;//科室模型

        public frmUserManager()
        : this(null, null)
        {
        }

        public frmUserManager(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();

            Init(dbHelper, loginUser);
        }

        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {
            _dbHelper = dbHelper;
            _loginUser = loginUser;

            _um = new UserModel(_dbHelper);
            _comboxEx = new ComboxEx(dbHelper);
            _departmentMatchModel = new DepartmentMatchModel(dbHelper);
        }
       

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (Verify() == false) return;

                UserInfoData userData = new UserInfoData();

                userData.用户ID = SqlHelper.GetCmpUID();
                userData.系统账号 = txtAccountName.Text;
                userData.用户名称 = txtUserName.Text;
                userData.职称级别 = cbxLevel.SelectedIndex;

                userData.签名图片 = picSignImage.Image;

                userData.账号信息.密码 = UserModel.EncryPwd(txtSurePwd.Text);
                userData.账号信息.备注 = rtbAccountDescription.Text;
                userData.账号信息.创建日期 = DateTime.Now;
                userData.账号信息.是否停用 = chkStopUse.Checked;

                userData.账号信息.CopyBasePro(userData);

                userData.人员照片 = picUserPhoto.Image;

                userData.人员信息.人员姓名 = txtName.Text;
                userData.人员信息.人员性别 = cbxSex.Text;
                userData.人员信息.出生日期 = dtpBirth.Value;
                userData.人员信息.身份证号 = txtCardNo.Text;
                userData.人员信息.办公电话 = txtOfficePhone.Text;
                userData.人员信息.电子邮件 = txtEmail.Text;
                userData.人员信息.联系电话 = txtTelePhone.Text;
                userData.人员信息.联系地址 = txtAddress.Text;
                userData.人员信息.备注 = rtbUserDescription.Text;

                userData.人员信息.CopyBasePro(userData);
                //userData.人员信息.个人简介

                UserReleationData userReleation = new UserReleationData();

                userReleation.用户关联ID = SqlHelper.GetCmpUID();
                userReleation.用户ID = userData.用户ID;
                if (cbxDepartment.SelectedValue != null) userReleation.科室ID = cbxDepartment.SelectedValue.ToString();
                if (cbxRoleGroup.SelectedValue != null) userReleation.角色ID = cbxRoleGroup.SelectedValue.ToString();
  
                _um.NewUser(userData, userReleation);
    
                DataTable dtBind = dataGridView1.DataSource as DataTable;

                DataRow drNew = dtBind.NewRow();

                drNew["用户ID"] = userData.用户ID;
                drNew["系统账号"] = userData.系统账号;
                drNew["用户名称"] = userData.用户名称;
                drNew["职称级别"] = userData.职称级别;
                drNew["账号信息"] = userData.账号信息.ToString();
                drNew["人员信息"] = userData.人员信息.ToString();
                drNew["签名图片"] = SqlHelper.ImageToBinary(userData.签名图片);
                drNew["人员照片"] = SqlHelper.ImageToBinary(userData.人员照片);
                 
                drNew["用户关联ID"] = userReleation.用户关联ID;
                drNew["科室ID"] = userReleation.科室ID;
                drNew["角色ID"] = userReleation.角色ID;
                drNew["角色名称"] = cbxRoleGroup.Text;

                dtBind.Rows.Add(drNew);

                ButtonHint.Start(sender as Button, "OK");
                //添加新增成功后的行焦点定位
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex,"添加账户信息失败。", this);
            }
        }

        public void RefreshSetting()
        {
            BindDepartmentData();
            _comboxEx.BindDictionary(cbxSex, "性别", true);
        }

        private void frmUserManager_Load(object sender, EventArgs e)
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

        private void BindDepartmentData()
        {
            DataTable dtDepartment = _departmentMatchModel.GetAllDepartment() ;

            cbxDepartment.DataSource = null;

            cbxDepartment.DisplayMember = "科室名称";
            cbxDepartment.ValueMember = "科室ID";

            cbxDepartment.DataSource = dtDepartment;

            if (cbxDepartment.Items.Count > 0) cbxDepartment.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定用户数据
        /// </summary>
        private void BindUserData()
        {
            DataTable dtUser = _um.GetDepartmentUsers(cbxDepartment.SelectedValue.ToString());

            dataGridView1.DataSource = dtUser;

            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["用户关联ID"].Visible = false;
                dataGridView1.Columns["用户ID"].Visible = false;
                dataGridView1.Columns["科室ID"].Visible = false;
                dataGridView1.Columns["角色ID"].Visible = false;
                dataGridView1.Columns["职称级别"].Visible = false;
                dataGridView1.Columns["签名图片"].Visible = false;
                dataGridView1.Columns["人员照片"].Visible = false;
                dataGridView1.Columns["账号信息"].Visible = false;
                dataGridView1.Columns["人员信息"].Visible = false;
                dataGridView1.Columns["变更日志"].Visible = false;
                dataGridView1.Columns["角色名称"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            cbxRoleGroup.DataSource = null;
            DataTable dtRole = _um.GetRoleInfo(cbxDepartment.SelectedValue.ToString());

            cbxRoleGroup.DisplayMember = "角色名称";
            cbxRoleGroup.ValueMember = "角色ID";

            cbxRoleGroup.DataSource = dtRole;

            if (cbxRoleGroup.Items.Count > 0) cbxRoleGroup.SelectedIndex = 0;
        }

        private void cbxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bool allowOper = !string.IsNullOrEmpty(cbxDepartment.Text);

                butImport.Enabled = allowOper;
                butNew.Enabled = allowOper;
                butDel.Enabled = allowOper;
                butModify.Enabled = allowOper;

                if (allowOper == false) return;

                BindUserData();

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                SyncSelRowData();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void ClearData()
        {
            txtAccountName.Text = "";
            txtAccountName.Tag = null;

            txtUserName.Text = ""; 
            txtPwd.Text = "";
            txtSurePwd.Text = "";

            cbxLevel.SelectedIndex = -1;

            cbxRoleGroup.SelectedIndex = -1; 
            cbxRoleGroup.Text = "";

            rtbAccountDescription.Text = "";
            chkStopUse.Checked = false;
             
            picSignImage.Image = null;


            //人员信息

            txtName.Text = "";
            cbxSex.SelectedIndex = -1;
            dtpBirth.Value = DateTime.Now;
            txtCardNo.Text = "";
            txtOfficePhone.Text = "";
            txtTelePhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            rtbUserDescription.Text = "";
             
            picUserPhoto.Image = null; 
        }



        private void SyncSelRowData()
        {
            try
            {

                ClearData();

                if (dataGridView1.DataSource == null) return;
                if (dataGridView1.SelectedRows.Count <= 0) return;

                DataGridViewRow dvr = dataGridView1.SelectedRows[0];


                string userID = dvr.Cells["用户ID"].Value.ToString();

                DataRow[] drs = (dataGridView1.DataSource as DataTable).Select("用户ID='" + userID + "'");

                if (drs.Length > 0)
                {
                    UserInfoData userData = new UserInfoData();
                    userData.BindRowData(drs[0]);

                    UserReleationData userReleation = new UserReleationData();
                    userReleation.BindRowData(drs[0]);

                    txtAccountName.Text = userData.系统账号;
                    txtAccountName.Tag = userData.用户ID;

                    txtUserName.Text = userData.用户名称;
                    cbxLevel.SelectedIndex = userData.职称级别;

                    if (userData.账号信息 != null)
                    {
                        txtPwd.Text = UserModel.DecryPwd(userData.账号信息.密码);
                        txtSurePwd.Text = txtPwd.Text;

                        rtbAccountDescription.Text = userData.账号信息.备注;
                        chkStopUse.Checked = userData.账号信息.是否停用;
                    } 

                    if (string.IsNullOrEmpty(userReleation.角色ID) == false)
                    {
                        cbxRoleGroup.Text = drs[0]["角色名称"].ToString();// cbxRoleGroup.Items.IndexOf(userReleation.角色ID);
                    }

                    picSignImage.Image = userData.签名图片;

                    //显示人员信息
                    if (userData.人员信息 != null)
                    {
                        txtName.Text = userData.人员信息.人员姓名;
                        cbxSex.Text = userData.人员信息.人员性别;
                        dtpBirth.Value = userData.人员信息.出生日期;
                        txtCardNo.Text = userData.人员信息.身份证号;
                        txtOfficePhone.Text = userData.人员信息.办公电话;
                        txtTelePhone.Text = userData.人员信息.联系电话;
                        txtAddress.Text = userData.人员信息.联系地址;
                        txtEmail.Text = userData.人员信息.电子邮件;
                        rtbUserDescription.Text = userData.人员信息.备注;
                    }
                     
                    picUserPhoto.Image = userData.人员照片;

                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
         

        private bool Verify(bool isModify = false)
        {
            if (string.IsNullOrEmpty(txtAccountName.Text))
            {
                MessageBox.Show("系统账号不允许为空。", "提示");
                txtAccountName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("用户名称不允许为空。", "提示");
                txtUserName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("密码不允许为空。", "提示");
                //密码输入框获取焦点
                txtPwd.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbxLevel.Text))
            {
                MessageBox.Show("职称级别不允许为空。", "提示");
                cbxLevel.Focus();
                return false;
            }

            string userId = _um.GetUserIDWithAccountName(txtAccountName.Text);
            if (string.IsNullOrEmpty(userId) == false)
            {
                if (isModify)
                {
                    if (userId.Equals(txtAccountName.Tag) == false)
                    {
                        MessageBox.Show("系统账号不允许重复。", "提示");
                        txtAccountName.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("系统账号不允许重复。", "提示");
                    txtAccountName.Focus();
                    return false;
                }
            }


            userId = _um.GetUserIDWithUserName(txtUserName.Text, cbxDepartment.SelectedValue.ToString());
            if (string.IsNullOrEmpty(userId) == false)
            {
                if (isModify)
                {
                    if (userId.Equals(txtAccountName.Tag) == false)
                    {
                        MessageBox.Show("用户名称不允许重复。", "提示");
                        txtUserName.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("用户名称不允许重复。", "提示");
                    txtUserName.Focus();
                    return false;
                }
            }

            if (txtSurePwd.Text.Equals(txtPwd.Text) == false)
            {
                MessageBox.Show("确认密码不一致。", "提示");
                txtSurePwd.Focus();

                return false;
            }
            
            //人员信息格式验证
            //出生日期小于当前日期，不能大于之前200年
            if (dtpBirth.Value > DateTime.Now || DateTime.Now.Year - dtpBirth.Value.Year > 200)
            {
                MessageBox.Show("出生日期不合法：不能大于当前日期，和当前日期相差大于200。", "提示");
                tabControl1.SelectedIndex = 1;
                dtpBirth.Focus();
                return false;
            }
           
            //验证身份证
            if (string.IsNullOrEmpty(txtCardNo.Text.Trim()) == false)
            {
                if (txtCardNo.Text.Trim().Length == 18)
                {
                    if (CheckIDCard18(txtCardNo.Text.Trim()) == false)
                    {
                        MessageBox.Show("输入的身份证是非法的", "提示");
                        tabControl1.SelectedIndex = 1;
                        txtCardNo.Focus();
                        return false;
                    }
                } else if (txtCardNo.Text.Trim().Length == 15)
                {
                    if (CheckIDCard15(txtCardNo.Text.Trim()) == false)
                    {
                        MessageBox.Show("输入的身份证是非法的", "提示");
                        tabControl1.SelectedIndex = 1;
                        txtCardNo.Focus();
                        return false;
                    }
                } else
                {
                    MessageBox.Show("输入的身份证是非法的", "提示");
                    tabControl1.SelectedIndex = 1;
                    txtCardNo.Focus();
                    return false;
                    
                }
            }

            //验证办公室电话
            if (string.IsNullOrEmpty(txtOfficePhone.Text.Trim()) == false)
            {
                if (Regex.IsMatch(txtOfficePhone.Text.Trim(), @"^(\d{3,4}-)?\d{6,8}$") == false)
                {
                    MessageBox.Show("办公室电话格式数错误", "提示");
                    tabControl1.SelectedIndex = 1;
                    txtOfficePhone.Focus();
                    return false;
                }
            }

            //验证手机电话
            if (string.IsNullOrEmpty(txtTelePhone.Text.Trim()) == false)
            {
                
                if (Regex.IsMatch(txtTelePhone.Text.Trim(), "1[34578]\\d{9}$") == false)
                {
                    MessageBox.Show("手机电话格式数错误", "提示");
                    tabControl1.SelectedIndex = 1;
                    txtTelePhone.Focus();
                    return false;
                }
            }

            //验证邮箱
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()) == false)
            {
                if (Regex.IsMatch(txtEmail.Text.Trim(), @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$") == false)
                {
                    MessageBox.Show("邮箱格式数错误", "提示");
                    tabControl1.SelectedIndex = 1;
                    txtEmail.Focus();
                    return false;
                }
            }

            return true;
        }

        private void butLoadSignPic_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog(this);

                if (File.Exists(openFileDialog1.FileName) == false) return;

                picSignImage.Image = ImageEx.LoadFile(openFileDialog1.FileName);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAccountName.Tag == null)
                {
                    MessageBox.Show("请选择需要删除的用户信息。", "提示");
                    return;
                }

                if (cbxDepartment.SelectedValue == null)
                {
                    MessageBox.Show("未选择对应科室，不能执行此操作。", "提示");
                    return;
                }
                //弹出确认窗口，确认是否删除当前用户
                if (MessageBox.Show("是否删除账户："+txtAccountName.Text+"?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                _um.DelUserInfo(cbxDepartment.SelectedValue.ToString(), txtAccountName.Tag.ToString());

                int rowIndex = 0;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    rowIndex = dataGridView1.SelectedRows[0].Index;
                }


                DataTable dtBind = (dataGridView1.DataSource as DataTable);

                if (dtBind.Rows.Count > 0)
                {
                    DataRow[] drs = dtBind.Select("用户ID='" + txtAccountName.Tag.ToString() + "'");

                    foreach (DataRow dr in drs)
                    {
                        dtBind.Rows.Remove(dr);
                    }
                }

                //if (dataGridView1.Rows.Count >= rowIndex )
                //{
                //    dataGridView1.Rows[rowIndex].Selected = true;
                //}
                //else
                //{
                //    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                //}

                ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        public UserInfoData GetSelectUserData()
        {

            if (dataGridView1.SelectedRows.Count <= 0) return null;

            DataGridViewRow dvr = dataGridView1.SelectedRows[0];

            string userID = dvr.Cells["用户ID"].Value.ToString();

            DataRow[] drs = (dataGridView1.DataSource as DataTable).Select("用户ID='" + userID + "'");

            if (drs.Length > 0)
            {
                UserInfoData userData = new UserInfoData();
                userData.BindRowData(drs[0]);

                return userData;
            }

            return null;
        }

        public UserReleationData GetSelectUserReleation()
        {

            if (dataGridView1.SelectedRows.Count <= 0) return null;

            DataGridViewRow dvr = dataGridView1.SelectedRows[0];

            string userID = dvr.Cells["用户ID"].Value.ToString();

            DataRow[] drs = (dataGridView1.DataSource as DataTable).Select("用户ID='" + userID + "'");

            if (drs.Length > 0)
            {
                UserReleationData userReleation = new UserReleationData();
                userReleation.BindRowData(drs[0]);

                return userReleation;
            }

            return null;
        }


        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAccountName.Tag == null)
                {
                    MessageBox.Show("请选择需要修改的用户信息。", "提示");
                    return;
                }


                UserInfoData userData = GetSelectUserData();
                if (userData == null)
                {
                    MessageBox.Show("未获取到有效的用户信息。", "提示");
                    return;
                }

                if (Verify(true) == false) return;
                 

                userData.系统账号 = txtAccountName.Text;
                userData.用户名称 = txtUserName.Text;
                userData.职称级别 = cbxLevel.SelectedIndex;

                userData.签名图片 = picSignImage.Image;
                userData.人员照片 = picUserPhoto.Image;

                userData.账号信息.备注 = rtbAccountDescription.Text;
                userData.账号信息.是否停用 = chkStopUse.Checked;
                userData.账号信息.密码 = UserModel.EncryPwd(txtSurePwd.Text);

                userData.账号信息.CopyBasePro(userData);

                userData.人员信息.人员姓名 = txtName.Text;
                userData.人员信息.人员性别 = cbxSex.Text;
                userData.人员信息.出生日期 = dtpBirth.Value;
                userData.人员信息.办公电话 = txtOfficePhone.Text;
                userData.人员信息.身份证号 = txtCardNo.Text;
                userData.人员信息.电子邮件 = txtEmail.Text;
                userData.人员信息.联系电话 = txtTelePhone.Text;
                userData.人员信息.联系地址 = txtAddress.Text;
                userData.人员信息.备注 = rtbUserDescription.Text;

                userData.人员信息.CopyBasePro(userData);
                //userData.人员信息.个人简介

                UserReleationData userReleation = GetSelectUserReleation();
                if (cbxRoleGroup.SelectedValue != null) userReleation.角色ID = cbxRoleGroup.SelectedValue.ToString();
            
                _um.UpdateUserInfo(userData, userReleation);
               
                DataRow dr = userData.GetBindRow();

                dr["系统账号"] = userData.系统账号;
                dr["用户名称"] = userData.用户名称;
                dr["职称级别"] = userData.职称级别;
                dr["账号信息"] = userData.账号信息.ToString();
                dr["人员信息"] = userData.人员信息.ToString();
                dr["签名图片"] = SqlHelper.ImageToBinary(userData.签名图片);
                dr["人员照片"] = SqlHelper.ImageToBinary(userData.人员照片);
                  
                dr["角色ID"] = userReleation.角色ID;
                dr["角色名称"] = cbxRoleGroup.Text;

                ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex,"保存账户信息失败。", this);
            }
        }

        private void butLoadPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog(this);

                if (File.Exists(openFileDialog1.FileName) == false) return;

                picUserPhoto.Image = ImageEx.LoadFile(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butClearUserPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                picUserPhoto.Image = null;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butClearSignPic_Click(object sender, EventArgs e)
        {
            try
            {
                picSignImage.Image = null;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butImport_Click(object sender, EventArgs e)
        {

        }

        #region 
        /// <summary>
        /// 验证18位身份证
        /// </summary>
        /// <param name="idNumber"></param>
        /// <returns></returns>
        private bool CheckIDCard18(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber.Remove(17), out n) == false
                || n < Math.Pow(10, 16) || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证  
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false;//省份验证  
            }
            string birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证  
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = idNumber.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != idNumber.Substring(17, 1).ToLower())
            {
                return false;//校验码验证  
            }
            return true;//符合GB11643-1999标准  
        }


        /// <summary>  
        /// 16位身份证号码验证  
        /// </summary>  
        private bool CheckIDCard15(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证  
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false;//省份验证  
            }
            string birth = idNumber.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证  
            }
            return true;
        }
        #endregion
    }
}

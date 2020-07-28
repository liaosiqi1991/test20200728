using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;
using zlMedimgSystem.Interface;
using zlMedimgSystem.DataModel;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using zlMedimgSystem.BusinessBase;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmStorageManager : Form, ISetting
    {
        private IDBQuery _dbHelper = null;
        private ILoginUser _loginUser = null;
        private StorageModel _storageModel = null;
        private StorageData storageData = null; //当前选择行的数据
        public frmStorageManager()
        {
            InitializeComponent();
        }
        public frmStorageManager(IDBQuery dbHelper, ILoginUser loginUser)
        {
            InitializeComponent();
            Init(dbHelper, loginUser);
        }

        public void Init(IDBQuery dbHelper, ILoginUser loginUser)
        {
            _dbHelper = dbHelper;
            _loginUser = loginUser;
            _storageModel = new StorageModel(dbHelper);
        }
        public void RefreshSetting()
        {
            LoadStorageData();
        }
        /// <summary>
        /// 加载存储设备信息，将json中的IP地址，端口，分类信息显示在列表中
        /// </summary>
        public void LoadStorageData()
        {
            JStorageInfo jStorageInfo;
            DataRow drNew;
            DataTable dtStorage = _storageModel.GetAllStorage();
            DataTable dtbind = new DataTable("影像存储信息");
            dtbind.Columns.Add("存储ID", Type.GetType("System.String"));
            dtbind.Columns.Add("存储名称", Type.GetType("System.String"));
            dtbind.Columns.Add("IP地址", Type.GetType("System.String"));
            dtbind.Columns.Add("端口", Type.GetType("System.String"));
            dtbind.Columns.Add("分类目录", Type.GetType("System.String"));
            dtbind.Columns.Add("存储信息", Type.GetType("System.String"));

            for (int i = 0; i < dtStorage.Rows.Count; i++)
            {
                drNew = dtbind.NewRow();
                jStorageInfo = JsonHelper.DeserializeObject<JStorageInfo>(dtStorage.Rows[i]["存储信息"].ToString());
                drNew["存储ID"] = dtStorage.Rows[i]["存储ID"].ToString();
                drNew["存储名称"] = dtStorage.Rows[i]["存储名称"].ToString();
                drNew["IP地址"] = jStorageInfo.IP地址;
                drNew["端口"] = jStorageInfo.端口;
                drNew["分类目录"] = jStorageInfo.目录;
                drNew["存储信息"] = dtStorage.Rows[i]["存储信息"].ToString();
                dtbind.Rows.Add(drNew);
            }
            dgvStorage.DataSource = dtbind;
            dgvStorage.Columns["存储ID"].Visible = false;
            dgvStorage.Columns["存储信息"].Visible = false;
            dgvStorage.Columns["分类目录"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        /// <summary>
        /// 加载选择行的信息
        /// </summary>
        public void LoadSelectRowData()
        {
            try
            {
                if (dgvStorage.DataSource == null) { return; }
                if (dgvStorage.Rows.Count < 0) { return; }
                CleanData();
                string strStorageId = dgvStorage.SelectedRows[0].Cells["存储ID"].Value.ToString();
                DataRow[] drStorage = (dgvStorage.DataSource as DataTable).Select("存储ID='" + strStorageId + "'");
                if (drStorage.Length > 0)
                {
                    storageData = new StorageData();
                    storageData.BindRowData(drStorage[0]);

                    txtStorageName.Text = storageData.存储名称;
                    txtStorageName.Tag = storageData.存储ID;
                    if (storageData.存储信息 != null)
                    {
                        cbxType.Text = storageData.存储信息.设备类型.ToString();
                        txtIp.Text = storageData.存储信息.IP地址;
                        txtPort.Text = storageData.存储信息.端口;
                        txtCatalogue.Text = storageData.存储信息.目录;
                        txtUserName.Text = storageData.存储信息.用户名;
                        txtPassword.Text = storageData.存储信息.密码; 
                        chkStopUse.Checked = storageData.存储信息.是否停用;
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
        /// <summary>
        /// 新增存储设备信息
        /// </summary>
        public void InsertStorage()
        {
            StorageData storageDataNew = new StorageData();
            storageDataNew.存储ID = SqlHelper.GetCmpUID();
            storageDataNew.存储名称 = txtStorageName.Text;
            storageDataNew.存储信息.设备类型 = cbxType.Text;
            storageDataNew.存储信息.IP地址 = txtIp.Text;
            storageDataNew.存储信息.端口 = txtPort.Text;
            storageDataNew.存储信息.目录 = txtCatalogue.Text;
            storageDataNew.存储信息.用户名 = txtUserName.Text;
            storageDataNew.存储信息.密码 = txtPassword.Text;
            storageDataNew.存储信息.创建时间 = DateTime.Now;
            storageDataNew.存储信息.是否停用 = chkStopUse.Checked;

            storageDataNew.存储信息.CopyBasePro(storageDataNew);
            //更新数据库
            _storageModel.InsertStorage(storageDataNew);
            //更新表格
            DataTable dtBind = dgvStorage.DataSource as DataTable;
            DataRow drNew = dtBind.NewRow();
            drNew["存储ID"] = storageDataNew.存储ID;
            drNew["存储名称"] = storageDataNew.存储名称;
            //新增显示在列表的列
            drNew["IP地址"] = storageDataNew.存储信息.IP地址;
            drNew["端口"] = storageDataNew.存储信息.端口;
            drNew["分类目录"] = storageDataNew.存储信息.目录;
            drNew["存储信息"] = storageDataNew.存储信息.ToString();
            dtBind.Rows.Add(drNew);
        }
        /// <summary>
        /// 删除选择的存储设备信息
        /// </summary>
        public void DelStorage()
        {
            _storageModel.DelStorage(storageData);
            //更新表格
            CleanData();
            DataTable dtBind = dgvStorage.DataSource as DataTable;
            DataRow drDel = dtBind.Select("存储ID='" + storageData.存储ID + "'")[0];
            dtBind.Rows.Remove(drDel);
        }
        /// <summary>
        /// 更新存储设备信息
        /// </summary>
        public void UpdateStorage()
        {
            storageData.存储名称 = txtStorageName.Text.Trim();
            storageData.存储信息.设备类型 = cbxType.Text;
            storageData.存储信息.IP地址 = txtIp.Text.Trim();
            storageData.存储信息.端口 = txtPort.Text.Trim();
            storageData.存储信息.目录 = txtCatalogue.Text.Trim();
            storageData.存储信息.用户名 = txtUserName.Text.Trim();
            storageData.存储信息.密码 = txtPassword.Text.Trim(); 
            storageData.存储信息.是否停用 = chkStopUse.Checked;

            storageData.存储信息.CopyBasePro(storageData);

            //更新数据库
            _storageModel.UpdateStorage(storageData);
            //更新绑定行
            DataRow dr = storageData.GetBindRow();

            dr["存储名称"] = storageData.存储名称;
            //修改后同步修改列表列的值
            dr["IP地址"] = storageData.存储信息.IP地址;
            dr["端口"] = storageData.存储信息.端口;
            dr["分类目录"] = storageData.存储信息.目录;
            dr["存储信息"] = storageData.存储信息.ToString();
        }
        /// <summary>
        /// 清空编辑器区域的控件的数据
        /// </summary>
        public void CleanData()
        {
            txtStorageName.Text = "";
            txtStorageName.Tag = "";

            cbxType.SelectedText = "FTP";
            txtIp.Text = "";
            txtPort.Text = "";
            txtCatalogue.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = ""; 
            chkStopUse.Checked = false;

        }
        /// <summary>
        /// 验证输入信息是否正确
        /// </summary>
        /// <param name="isUpdate">true：更新操作；false：新增操作</param>
        /// <returns>返回验证信息</returns>
        public string Verify(bool isUpdate)
        {
            if (string.IsNullOrEmpty(txtStorageName.Text.Trim()))
            {
                txtStorageName.Focus();
                return "存储名称不能为空";
            }
            //验证存储名称不能重复
            string strStorageid = _storageModel.GetStorageId(txtStorageName.Text.Trim());
            if (string.IsNullOrEmpty(strStorageid) == false)
            {
                if (isUpdate)
                {
                    if (strStorageid != txtStorageName.Tag.ToString())
                    {
                        txtStorageName.Focus();
                        txtStorageName.SelectAll();
                        return "存储名称不能重复";
                    }

                }
                else
                {
                    txtStorageName.Focus();
                    txtStorageName.SelectAll();
                    return "存储名称不能重复";
                }
            }
            //IP地址不能为空，需要验证IP地址格式
            if (string.IsNullOrEmpty(txtIp.Text) == false)
            {
                string strPattern = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$";
                if (Regex.IsMatch(txtIp.Text.Trim(), strPattern) == false)
                {
                    txtIp.Focus();
                    txtIp.SelectAll();
                    return "IP地址格式不正确";
                }
            }
            else
            {
                return "IP地址不能为空";
            }
            //端口不为空时，只能是数字
            if (string.IsNullOrEmpty(txtPort.Text) == false)
            {
                string strPattern = @"^[0-9]+$";
                Regex reg = new Regex(strPattern);
                if (reg.Match(txtPort.Text.Trim()).Success == false)
                {
                    txtPort.Focus();
                    txtPort.SelectAll();
                    return "端口只能是数字，格式不正确";
                }
            }
            
            //目录格式验证
            string strCatalogue = txtCatalogue.Text.Trim();
            if (string.IsNullOrEmpty(strCatalogue) == false)
            {
                if (strCatalogue.IndexOf("/") > -1 || strCatalogue.IndexOf(@"\\") > -1)
                {
                    txtCatalogue.Focus();
                    txtCatalogue.SelectAll();
                    return @"目录格式不正确，请不要使用/,\\";
                }
            }
            return "";
        }
        /// <summary>
        /// 测试FTP连接
        /// </summary>
        /// <param name="path">路径，实际就是IP地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        private string FtpTest(string path, string username, string password)
        {
            string strMsg = "";
            FTPFileHelp _ftpHelp = new FTPFileHelp();
            //ftp连接测试
            if (_ftpHelp.ConnnectServer(path, username, password) == false)
            {
                return "FTP连接失败,ftp路径：" + path + ",用户：" + username;
            }
            //ftp创建目录测试
            string strDirectory = "\\" + DateTime.Now.ToString("yyyyMMdd") + "test";
            try
            {
                _ftpHelp.MakeDirectory(strDirectory);
            }
            catch
            {
                return "创建目录：" + strDirectory + "  失败";
            }
            //ftp上传文件测试
            string filename = "C:\\ftpTest.txt";
            if (File.Exists(filename) == false)
            {
                FileStream fs = new FileStream(filename, FileMode.CreateNew);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write("FTPTest"); //这里是写入的内容
                sw.Flush();
                fs.Close();
            }
            FileInfo upFile = new FileInfo(filename);
            try
            {
                _ftpHelp.FileUpLoad(strDirectory + "\\ftpTest.txt", upFile);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            upFile.Delete();
            //ftp下载测试
            try
            {
                _ftpHelp.FileDownLoad(strDirectory + "\\ftpTest.txt", filename, true);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            //ftp删除文件测试
            try
            {
                _ftpHelp.DeleteFileName(strDirectory + "\\ftpTest.txt");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            //ftp删除目录测试

            try
            {
                _ftpHelp.DeleteDirectory(strDirectory);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return strMsg;
        }
        private void dgvStorage_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                                                e.RowBounds.Location.Y,
                                                dgv.RowHeadersWidth - 4,
                                                e.RowBounds.Height);


            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                                    dgv.RowHeadersDefaultCellStyle.Font,
                                    rectangle,
                                    dgv.RowHeadersDefaultCellStyle.ForeColor,
                                    TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void frmStorageManager_Load(object sender, EventArgs e)
        {
            try
            {
                LoadStorageData();
                dgvStorage.ClearSelection();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void dgvStorage_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvStorage.SelectedRows.Count > 0)
                {
                    LoadSelectRowData();
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                string strMsg = Verify(false);
                if (string.IsNullOrEmpty(strMsg) == false)
                {
                    MsgBox.ShowInf(strMsg);
                    return;
                }

                InsertStorage();
                //新增行后定位到新增的行，取消掉清空数据操作。
                //CleanData();
                //dgvStorage.ClearSelection();
                ButtonHint.Start(sender as Button, "OK");
                dgvStorage.Rows[dgvStorage.Rows.Count - 1].Selected = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }

        private void butModify_Click(object sender, EventArgs e)
        {
            try
            {
                string strMsg = Verify(true);
                if (string.IsNullOrEmpty(strMsg) == false)
                {
                    MsgBox.ShowInf(strMsg);
                    return;
                }

                UpdateStorage();
                ButtonHint.Start(sender as Button, "OK");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtStorageName.Text.Trim()))
                {
                    return;
                }
                //删除提示设备名称
                if (MessageBox.Show("是否删除存储设备:"+ txtStorageName.Text.Trim() + "？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DelStorage();
                    //dgvStorage.ClearSelection();
                    ButtonHint.Start(sender as Button, "OK");
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string strMsg = FtpTest(txtIp.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if (string.IsNullOrEmpty(strMsg))
            {
                ButtonHint.Start(sender as Button, "OK");
                
            }
            else
            {
                MsgBox.ShowError(strMsg);
            }
        }
    }
}

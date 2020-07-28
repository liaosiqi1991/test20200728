using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing.Imaging;
using zlMedimgSystem.Interface;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.ApplySearch
{
    public partial class frmApplyScan : Form
    {
        #region 私有属性
        private string _str申请ID;
        private string _扫描人;
        private DateTime _申请日期;
        private string _存储ID;
        private IDBQuery _dbQuery;
        private ScanModel _scanModel;
        frmScanImage _scanImageForm = new frmScanImage();
        
        #endregion

        #region 公共属性
        
        public string 存储ID
        {
            get { return _存储ID; }
            set { _存储ID = value; }
        }
        public DateTime 申请日期
        {
            get { return _申请日期; }
            set { _申请日期 = value; }
        }

        public string 扫描人
        {
            get { return  _扫描人; }
            set { _扫描人 = value; }
        }
        public string 申请ID
        {
            get { return _str申请ID; }
            set { _str申请ID = value; }
        }

        #endregion

        #region 构造函数

        public frmApplyScan(IDBQuery dbQuery)
        {
            InitializeComponent();           
            _dbQuery = dbQuery;
            _scanModel = new ScanModel(_dbQuery);            
        }

        #endregion

        #region 公共方法
        public bool Init()
        {            
            
            //查询是否存在申请图像
            if (_scanModel.HasScanImage(_str申请ID)==true)
            {                
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ShowScanImage()
        {
            //从数据库查询扫描申请图像
            DataTable dt = _scanModel.GetScanImages(申请ID);

            if (dt == null || dt.Rows.Count == 0) return false;

            FTPFileHelp ftpHelper = new FTPFileHelp();
            initFTP( _dbQuery, 存储ID,out ftpHelper);

            //构造 scanData类
            ScanData oneScan=new ScanData();
            oneScan.BindRowData(dt.Rows[0]);
            string vPath = ftpHelper.VPath + "//" + oneScan.扫描信息.申请日期.ToString("yyyyMMdd") + "//" + oneScan.申请ID + "//apply//";
            string tmpDir = System.Windows.Forms.Application.StartupPath + @"\Temp" + vPath.Replace("//", "\\").Replace("/","\\");
            System.IO.FileInfo fi;
            if (Directory.Exists(tmpDir) == false) Directory.CreateDirectory(tmpDir);

            flowLayoutPanel.Controls.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                oneScan = new ScanData();
                oneScan.BindRowData(dr);
                //下载图像
                string tmpFile = tmpDir + oneScan.扫描信息.文件名 + ".jpg";
                fi = new System.IO.FileInfo(tmpFile);
                if (fi.Exists ==false )
                {
                    ftpHelper.FileDownLoad(vPath + oneScan.扫描信息.文件名 + ".jpg", tmpFile, false);
                }                    
                PictureBox pb = new PictureBox();
                pb.Height = 200;
                //pb.BackColor = Color.Pink; 
                pb.Width = flowLayoutPanel.Width;
                //pb.Dock = DockStyle.Top;
                pb.Image = Image.FromFile(tmpFile);
                pb.Tag = oneScan;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Click += picMiniImage_Click;
                flowLayoutPanel.Controls.Add(pb);   
                if (flowLayoutPanel.Controls.Count == 1)
                {
                    picImage.Image = pb.Image;
                    picImage.Tag = pb.Tag;
                }
            }

            foreach (Control c in flowLayoutPanel.Controls)
            {
                c.Margin = new Padding(1);                
                if (flowLayoutPanel.VerticalScroll.Visible==true )
                {
                    c.Width = c.Width - 20;
                }
            }
            setBtnDelEnable();
            return true;
        }

        #endregion

        #region 私有方法

        private void btnScan_Click(object sender, EventArgs e)
        {
            _scanImageForm.ShowScan();
            if (_scanImageForm.DialogResult == DialogResult.OK)
            {
                SaveScanImg(_scanImageForm.ScanImage);
            }
            ShowScanImage();
        }

        /// <summary>
        /// 保存扫描的申请单
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        private bool SaveScanImg(Bitmap bmp)
        {            
            //创建一个扫描图像类            
            ScanData oneScan = new ScanData();

            oneScan.申请ID = _str申请ID;
            oneScan.扫描ID = SqlHelper.GetNumGuid().ToString();
            oneScan.扫描信息.存储ID = 存储ID;
            oneScan.扫描信息.扫描人 = 扫描人;
            oneScan.扫描信息.扫描时间 = _scanModel.GetServerDate();
            oneScan.扫描信息.文件名 = Guid.NewGuid().ToString("N");
            oneScan.扫描信息.申请日期 = 申请日期;
            oneScan.扫描信息.CopyBasePro(oneScan);                              

            try
            {
                //保存临时文件
                var eps = new System.Drawing.Imaging.EncoderParameters(1);
                var ep = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 85L);
                eps.Param[0] = ep;
                var jpsEncoder = GetEncoder(ImageFormat.Jpeg);

                FTPFileHelp ftpHelper = new FTPFileHelp();
                initFTP(_dbQuery, 存储ID, out ftpHelper);

                string vPath = ftpHelper.VPath + "//" + oneScan.扫描信息.申请日期.ToString("yyyyMMdd") + "//" + oneScan.申请ID + "//apply//";
                string tmpFile = System.Windows.Forms.Application.StartupPath + @"\Temp" + vPath.Replace("//", "\\");
                if (Directory.Exists(tmpFile) == false) Directory.CreateDirectory(tmpFile);

                tmpFile = tmpFile + oneScan.扫描信息.文件名 + ".jpg";
                bmp.Save(tmpFile, jpsEncoder, eps);
                //释放资源
                ep.Dispose();
                eps.Dispose();

                //上传FTP
                FileInfo fi = new FileInfo(tmpFile);                
                ftpHelper.MakeDirectory(vPath);
                if (ftpHelper.FileUpLoad(vPath + oneScan.扫描信息.文件名 + ".jpg", fi) == true)
                {
                    //存入数据库
                    _scanModel.SaveScanImage(oneScan);
                }
                else
                {
                    return false;
                }
                //ftpHelper.disConnect(); 没有关闭连接的方法吗？
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            return true;
        }

        /// <summary>
        /// 初始化FTP
        /// </summary>
        /// <param name="dbHelper"></param>
        /// <returns></returns>
        private bool initFTP( IDBQuery dbHelper,string StorageID,out FTPFileHelp ftpHelper)
        {
            ftpHelper = new FTPFileHelp();

            StorageModel sModel = new StorageModel(dbHelper);

            StorageData sd = sModel.GetStorageDataByID(StorageID);

            ftpHelper.VPath = (@"/" + sd.存储信息.目录).Replace(@"\\", @"\").Replace(@"\", @"/").Replace("//", "/");
            ftpHelper.ConnnectServer(sd.存储信息.IP地址, sd.存储信息.用户名, sd.存储信息.密码);

            return true;
        }

        /// <summary>
        /// 获取图像编码方式
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                    return codec;
            }
            return null;
        }
 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnScanSetup_Click(object sender, EventArgs e)
        {
            _scanImageForm.ShowScanSetup();
            //scanImageForm.Dispose();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            deleteOneScan();
        }

        #endregion

        private bool deleteOneScan()
        {
            if (picImage.Tag != null && flowLayoutPanel.Controls.Count >0)
            {
                ScanData oneScan = picImage.Tag as ScanData;

                //先删除数据库
                _scanModel.DeleteOneScanImage(oneScan.扫描ID);

                //再删除FTP文件                
                FTPFileHelp ftpHelper = new FTPFileHelp();
                initFTP(_dbQuery, 存储ID, out ftpHelper);

                string vPath = ftpHelper.VPath + "//" + oneScan.扫描信息.申请日期.ToString("yyyyMMdd") + "//" + oneScan.申请ID + "//apply//";
                string tmpDir = System.Windows.Forms.Application.StartupPath + @"\Temp" + vPath.Replace("//", "\\").Replace("/", "\\");

                ftpHelper.DeleteFileName( vPath + oneScan.扫描信息.文件名 + ".jpg");

                //刷新
                ShowScanImage();             
            }
            
            return true;
        }

        private void picMiniImage_Click(object sender, EventArgs e)
        {
            //地方
            PictureBox p = sender as PictureBox;
            if (p.Image != null)
            {
                picImage.Image = p.Image;
                picImage.Tag = p.Tag;
            }           
        }

        private void flowLayoutPanel_Resize(object sender, EventArgs e)
        {
            foreach(Control c in flowLayoutPanel.Controls)
            {
                if (flowLayoutPanel.VerticalScroll.Visible == true)
                {
                    c.Width = flowLayoutPanel.Width  - 20;
                }
                else
                {
                    c.Width = flowLayoutPanel.Width;
                }
            }
        }
        
        /// <summary>
        /// 设置删除按钮的可用性
        /// </summary>
        private void setBtnDelEnable()
        {
            if (flowLayoutPanel.Controls.Count > 0)
                btnDel.Enabled = true;
            else
                btnDel.Enabled = false;
        }
        
    }
}

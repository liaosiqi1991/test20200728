using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using zlMedimgSystem.Services;
using zlMedimgSystem.DataModel;

namespace zlMedimgSystem.CTL.ApplySearch
{
    public partial class frmScanImage : Form
    {
        #region 构造函数

        public frmScanImage()
        {
            InitializeComponent();
            btnOk.Enabled = false;
            btnCancel.Enabled = false;
        }

        #endregion

        #region 公共属性

        public Bitmap ScanImage;

        #endregion

        public void  ShowScan()
        {
            OpenScan();
            this.ShowDialog();
        }

        private void scanner_OnScanComplete(Bitmap bmp)
        {
            //显示图像
            picImage.Image = bmp;
            ScanImage = bmp;
            btnOk.Enabled = true;
            btnCancel.Enabled = true;
        }



        public void OpenScan()
        {
            string scannerName;

            //提取扫描仪
            Configuration ca = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (ca.AppSettings.Settings.AllKeys.Contains("sacndevice"))
            {
                scannerName = ca.AppSettings.Settings["sacndevice"].Value;
            }
            else
            {
                //如果只有一个扫描仪，就直接使用
                List<string> listScan = new List<string>();
                listScan = scanner.GetScanDevs();
                if (listScan.Count() == 1)
                {
                    scannerName = listScan[0];
                    //保存扫描仪                   
                    ca.AppSettings.Settings.Add("sacndevice", scannerName);
                    ca.Save(ConfigurationSaveMode.Modified);
                }
                else
                {
                    //让用户选择一个扫描仪
                    scannerName = ShowScanSetup();
                }
            }
            
            if (scanner.InitDevice(scannerName) == true)
            {
                scanner.Scan();                
            }
        }

        public string ShowScanSetup()
        {
            string scannerName = "";
            List<string> scanList = new List<string>();

            scanList = scanner.GetScanDevs();

            //如果扫描仪数量超过2个，显示窗口给用户选择一个扫描仪
            if (scanList.Count() > 1)
            {
                frmScannerSetup scanSetup = new frmScannerSetup();

                scanSetup.scanList = scanList;
                if (scanSetup.ShowDialog() == DialogResult.OK)
                {
                    scannerName = scanSetup.OutValue;
                }
                scanSetup.Dispose();
            }
            else if (scanList.Count() == 1)
            {
                scannerName = scanList[0];
            }
            else
            {
                MsgBox.ShowInf("未找到扫描仪。");
                return "";
            }
            //显示扫描设置
            scanner.InitDevice(scannerName);
            scanner.ShowSetting();

            //保存扫描仪
            Configuration ca = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ca.AppSettings.Settings.Add("sacndevice", scannerName);
            ca.Save(ConfigurationSaveMode.Modified);
            return scannerName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            scanner.Close();
            DialogResult = DialogResult.Cancel;
            
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            scanner.Close();
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

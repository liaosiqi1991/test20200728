using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.Layout
{
    public partial class frmElementImport : Form
    {
        private Type _eleType = null;
        private string _originalName = "";
        private string _templateFullName = "";

        private string _winKey = "";
        private IDBQuery _dbHelper = null;
        private IBizDataTransferCenter _dataCenter = null;
        private IStationInfo _stationInfo = null;
        private ILoginUser _loginUser = null;
        private IParameters _pars = null;
        private ISysLog _sysLog = null;

        private DesignControl _dcInstance = null;

        private string _templateDir = "";
        public frmElementImport()
        {
            InitializeComponent();
        }

        public void Init(string winKey, IDBQuery dbHelper, IBizDataTransferCenter dataTransCenter, IStationInfo stationInfo, ILoginUser userData, IParameters parameters, ISysLog sysLog)
        {
            _winKey = winKey;
            _dbHelper = dbHelper;
            _dataCenter = dataTransCenter;
            _stationInfo = stationInfo;
            _loginUser = userData;
            _pars = parameters;
            _sysLog = sysLog;
        }

        public string ShowTemplateImport(DesignControl element, IWin32Window owner)
        {
            //dynamic obj = type.Assembly.CreateInstance(type);
            _templateFullName = "";

            _eleType = element.GetType();
            _originalName = element.OriginalModule;

            this.ShowDialog(owner);

            return _templateFullName;
        }

        private void frmElementTemplate_Load(object sender, EventArgs e)
        {
            _dcInstance = _eleType.Assembly.CreateInstance(_eleType.FullName) as DesignControl;

            panel1.Controls.Add(_dcInstance);
                        

            _dcInstance.Dock = DockStyle.Fill;
            _dcInstance.Init(_winKey, _dbHelper, _dataCenter, _stationInfo, _loginUser, _pars, _sysLog);


            listView1.Clear();

            _templateDir = Dir.GetAppTemplateDir() + @"\" + _originalName;

            if (Directory.Exists(_templateDir))
            {
                string[] files =Directory.GetFiles(_templateDir);

                foreach(string file in files)
                {
                    FileInfo fi = new FileInfo(file);

                    listView1.Items.Add(fi.Name);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count <= 0) return;

                string file = _templateDir + @"\" + listView1.SelectedItems[0].Text;

                if (File.Exists(file))
                {
                    using (StreamReader sr = new StreamReader(file))
                    {

                        _dcInstance.CustomDesignFmt = sr.ReadToEnd();
                    }
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            try
            {
                _templateFullName = "";
                this.Close();
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
                if (listView1.SelectedItems.Count > 0)
                {
                    _templateFullName = _templateDir + @"\" + listView1.SelectedItems[0].Text;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

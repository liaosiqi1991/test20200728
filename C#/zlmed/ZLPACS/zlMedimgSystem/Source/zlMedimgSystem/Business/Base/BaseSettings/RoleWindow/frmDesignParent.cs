using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Layout;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BaseSettings
{
    public partial class frmDesignParent : Form
    {

        public event SaveWindowLayout OnSaveWindowLayout;
        public event ReadWindowLayout OnReadWindowLayout;
        public event QueryParentWindowName OnQueryParentWindowName;
        public event MdiWindowChange OnMdiWindowChange;

        private string _serverName = "";
        private BizMainLayout _bml = null;
        public frmDesignParent()
        {
            InitializeComponent();

            _bml = new BizMainLayout(true);

            _bml.OnStateSync += StateSync;
            _bml.OnSaveWindowLayout += SaveLayout;
            _bml.OnReadWindowLayout += ReadLayout;
            _bml.OnQueryParentWindowName += QueryLinkWindow;
            _bml.OnMdiWindowChange += MdiWindowChange;

        }

        private void MdiWindowChange(string designWinKey, bool isToMdiWindow)
        {
            OnMdiWindowChange?.Invoke(designWinKey, isToMdiWindow);
        }


        private void SaveLayout(BizMainLayout bizWindow, string designKey, string layoutFmt)
        {
            OnSaveWindowLayout?.Invoke(bizWindow, designKey, layoutFmt);
        }

        private void ReadLayout(BizMainLayout bizWindow, ref string designKey, out string layoutFmt)
        {
            layoutFmt = "";
            OnReadWindowLayout?.Invoke(bizWindow, ref designKey, out layoutFmt);
        }

        private void QueryLinkWindow(string designKey, out List<string> names)
        {

            names = new List<string>();

            OnQueryParentWindowName?.Invoke(designKey, out names);
        }

        public void SetDesignText(string designWindowKey, string designName)
        {
            _bml.SetDesignText(designWindowKey, designName, panel1, panel2);
        }


        public void Init(IDBQuery dbHelper, ILoginUser userData, IStationInfo stationInfo, IBizDataTransferCenter parentTransferCenter)
        {
            _serverName = stationInfo.DBServerName;
            _bml.Init(dbHelper, userData, stationInfo, parentTransferCenter);
        }
         
        private void StateSync(string stateMsg, bool isFinal = false)
        {
            tsLabState.Text = stateMsg;

            Application.DoEvents();
        }

        private void frmDesignParent_Load(object sender, EventArgs e)
        {
            foreach (Control conMid in this.Controls)
            {
                //得到Mdi
                if (conMid.GetType() == typeof(MdiClient))
                {
                    conMid.BackColor = SystemColors.Control;
                    break;
                }
            }

            tsbServer.Text = "服务器:" + _serverName;

            timerDesign.Enabled = true;
        }

        private void timerDesign_Tick(object sender, EventArgs e)
        {
            timerDesign.Enabled = false;

            _bml.BeforeLoadAssembly();

            StateSync("");

            _bml.MdiParent = this;
            _bml.StartPosition = FormStartPosition.CenterScreen;
            _bml.Show();
        }

    }
}

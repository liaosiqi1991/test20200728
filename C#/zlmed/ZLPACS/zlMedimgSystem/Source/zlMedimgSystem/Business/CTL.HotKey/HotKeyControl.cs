using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.HotKey
{
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(HotKeyControl), "Resources.hotkey.ico")]
    public partial class HotKeyControl : DesignComponent, ISysBizModule, ISysDesign, IBizDataQuery
    {

        private HotKeys _hotKeys = null;
        private SysHotKey _SysHot = null;
        public HotKeyControl()
        {
            InitializeComponent();

            _hotKeys = new HotKeys();
            
            _SysHot = new SysHotKey(this.Handle);
            _SysHot.OnHotkey += OnHotKey;
        }

        protected override void InitBaseInfo()
        {
            _multiInstance = false;
            _moduleName = "系统热键";


            //_provideActionDesc.Add("", ""); 

            //_provideDatas.Add("", "");


            //_designEvents.Add("", new EventActionReleation("", ActionType.atSysFixedEvent)); 
        }

        private void OnHotKey(KeyItemInfo keyInfo)
        {
            try
            {
                DoBindActions(_designEvents[keyInfo.Alias], this);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        protected override void ReloadCustomDesign(string customContext)
        {
            if (string.IsNullOrEmpty(customContext)) return;

            _hotKeys = JsonHelper.DeserializeObject<HotKeys>(customContext);

            InitSysHot(_hotKeys);

            SyncDesignEventsByHotKey();
        }

        private void SyncDesignEventsByHotKey()
        {
            foreach (KeyItemInfo keyInfo in _hotKeys.keys)
            {
                if (_designEvents.ContainsKey(keyInfo.Alias) == false)
                {
                    _designEvents.Add(keyInfo.Alias, new EventActionReleation(keyInfo.Alias, ActionType.atSysFixedEvent));
                }
            }
        }


        private void InitSysHot(HotKeys hotKeys)
        {
            try
            {
                if (DesignMode == false)
                {
                    foreach (KeyItemInfo keyInfo in hotKeys.keys)
                    {
                        _SysHot.RegisterHotkey(keyInfo);
                    }
                }
                else
                {
                    _SysHot.UnregisterHotkeys();
                }

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }


        public override string ShowCustomDesign()
        {
            using (frmHotKeyDesign design = new frmHotKeyDesign())
            {
                design.ShowDesign(_hotKeys, this);
            }

            _customDesignFmt = JsonHelper.SerializeObject(_hotKeys);


            if (_hotKeys.keys != null)
            {
                InitSysHot(_hotKeys);
            }

            SyncDesignEventsByHotKey();

            return _customDesignFmt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.CTL.HotKey
{
    public delegate void HotkeyEventHandler(KeyItemInfo keyItem);

    public enum KeyFlags
    {
        MOD_NONE = 0,
        MOD_ALT = 1,
        MOD_CONTROL = 2,
        MOD_SHIFT = 3,
        //MOD_WIN = 4
    }

    public class SysHotKey : System.Windows.Forms.IMessageFilter
    {
        IntPtr hWnd;

        public event HotkeyEventHandler OnHotkey;


        [DllImport("user32.dll")]
        public static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk);

        [DllImport("user32.dll")]
        public static extern UInt32 UnregisterHotKey(IntPtr hWnd, UInt32 id);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalAddAtom(String lpString);

        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalDeleteAtom(UInt32 nAtom);

        public SysHotKey(IntPtr hWnd)
        {
            this.hWnd = hWnd;
            System.Windows.Forms.Application.AddMessageFilter(this);
        }

        private Dictionary<uint, KeyItemInfo> _regHotkeys = null;
        public int RegisterHotkey(KeyItemInfo keyItem)
        {
            UInt32 hotkeyid = GlobalAddAtom(System.Guid.NewGuid().ToString());

            RegisterHotKey((IntPtr)hWnd, hotkeyid, (UInt32)keyItem.FuncKey, (UInt32)keyItem.CharKey);

            if (_regHotkeys == null) _regHotkeys = new Dictionary<uint, KeyItemInfo>();

            keyItem.RegInstanceID = hotkeyid;
            _regHotkeys.Add(hotkeyid, keyItem);

            return (int)hotkeyid;
        }

        public void UnregisterHotkeys()
        {
            System.Windows.Forms.Application.RemoveMessageFilter(this);

            if (_regHotkeys == null) return;

            for(int i = _regHotkeys.Count -1; i >= 0; i --)
            {
                KeyValuePair<uint, KeyItemInfo> kv= _regHotkeys.ElementAt(i);

                KeyItemInfo delKeyItem = kv.Value; 

                UnregisterHotKey(hWnd, delKeyItem.RegInstanceID);
                GlobalDeleteAtom(delKeyItem.RegInstanceID);

                _regHotkeys.Remove(kv.Key);
            }
        }

        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x312)
            {
                if (OnHotkey != null)
                {
                    uint key = (uint)m.WParam;

                    if (_regHotkeys.ContainsKey(key))
                    {
                        OnHotkey(_regHotkeys[key]);
                    } 
                }
            }
            return false;
        }
    }


    /// <summary>
    /// 键盘项信息
    /// </summary>
    public class KeyItemInfo
    {
        public string ID { get; set; }
        public string Alias { get; set; }
        public KeyFlags FuncKey { get; set; }
        public Keys CharKey { get; set; } 

        public uint RegInstanceID { get; set; }

        public KeyItemInfo()
        {
            ID = Guid.NewGuid().ToString("N");
        }
 
    }

    /// <summary>
    /// 热键信息
    /// </summary>
    public class HotKeys
    {
        public List<KeyItemInfo> keys { get; set; }

        public HotKeys()
        {
            keys = new List<KeyItemInfo>();
        }
    }
}

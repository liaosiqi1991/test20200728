using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace zlMedimgSystem.Services
{
    public class SettingItem
    {
        static private Configuration _root = null;
        private KeyValueConfigurationCollection _setting = null;
        private bool _isBatch = false;
        private Dictionary<string, string> _batch = null;

        public SettingItem()
        {
            if (_root == null) _root = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _setting = _root.AppSettings.Settings;
        }

        public SettingItem(string sectionName)
        {
            if (_root == null) _root = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (_root.Sections.Count <= 0)
            {
                _root.Sections.Add(sectionName, new AppSettingsSection());
            }

            if (_root.GetSection(sectionName) == null)
            {
                _root.Sections.Add(sectionName, new AppSettingsSection());
            }

            AppSettingsSection appSection = _root.GetSection(sectionName) as AppSettingsSection;


            _setting = appSection.Settings;
        }
        public void BatchBegin()
        {
            _isBatch = true;
            if (_batch == null)
            {
                _batch = new Dictionary<string, string>();
            }

            _batch.Clear();
        }

        public void BatchCancel()
        {
            _isBatch = false;
            if (_batch == null) return;

            _batch.Clear();
        }

        public void BatchCommit()
        {
            _isBatch = false;
            if (_batch == null || _batch.Count <= 0) return;
                        
            foreach (KeyValuePair<string, string> kv in _batch)
            {
                bool hasKey = _setting.AllKeys.Contains(kv.Key);

                if (hasKey)
                {
                    _setting[kv.Key].Value = kv.Value;
                }
                else
                {
                    _setting.Add(kv.Key, kv.Value);
                }
            }

            _root.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            _batch.Clear();
        }

        /// <summary>
        /// 写入配置
        /// </summary>
        /// <param name="settingKey"></param>
        /// <param name="value"></param>
        public void WriteSetting(string settingKey, string value)
        {
            if (_isBatch)
            {
                _batch.Add(settingKey, value);
            }
            else
            {                
                bool hasKey = _setting.AllKeys.Contains(settingKey);

                if (hasKey)
                {
                    _setting[settingKey].Value = value;
                }
                else
                {
                    _setting.Add(settingKey, value);
                }

                _root.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
            }

        }


        public void WriteInt(string settingKey, int value)
        {
            WriteSetting(settingKey, value.ToString());
        }

        public void WriteDouble(string settingKey, double value)
        {
            WriteSetting(settingKey, value.ToString());
        }

        public void WriteDateTime(string settingKey, DateTime value)
        {
            WriteSetting(settingKey, value.ToString());
        }

        public void WriteBool(string settingKey, bool value)
        {
            WriteSetting(settingKey, value.ToString());
        }

        /// <summary>
        /// 判断配置键是否存在
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        public bool HasKey(string settingKey)
        {
            return _setting.AllKeys.Contains(settingKey);
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        public string ReadSetting(string settingKey, string defaultValue = "")
        {
            if (_setting.AllKeys.Contains(settingKey) == false) return defaultValue;

            return _setting[settingKey].Value;
        }

        /// <summary>
        /// 读取整数配置
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        public int ReadInt(string settingKey, int defaultValue = 0)
        {
            return Convert.ToInt32(ReadSetting(settingKey, defaultValue.ToString()));
        }

        /// <summary>
        /// 读取浮点数配置
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        public Double ReadDouble(string settingKey, double defaultValue = 0)
        {
            return Convert.ToDouble(ReadSetting(settingKey, defaultValue.ToString()));
        }

        /// <summary>
        /// 读取日期配置
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        public DateTime ReadDatetime(string settingKey, DateTime defaultValue = default(DateTime))
        {
            return Convert.ToDateTime(ReadSetting(settingKey, defaultValue.ToString()));
        }

        /// <summary>
        /// 读取bool类型配置
        /// </summary>
        /// <param name="settingKey"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public bool ReadBool(string settingKey, bool defaultValue = false)
        {
            return Convert.ToBoolean(ReadSetting(settingKey, defaultValue.ToString()));
        }
    }

    static public class AppSettingHelper
    {
        static private SettingItem _sysSetting = null;
        static public SettingItem SysSetting
        {
            get
            {
                if (_sysSetting == null) _sysSetting = new SettingItem();
                return _sysSetting;
            }
        }


        static public SettingItem GetSpecifySection(string sectionName)
        {
            return new SettingItem(sectionName);
        }
    }



    static public class AppSetting
    {         
        static public void BatchBegin()
        {
            AppSettingHelper.SysSetting.BatchBegin();
        }

        static public void BatchCancel()
        {
            AppSettingHelper.SysSetting.BatchCancel();
        }

        static public void BatchCommit()
        {
            AppSettingHelper.SysSetting.BatchCommit();
        }

        /// <summary>
        /// 写入配置
        /// </summary>
        /// <param name="settingKey"></param>
        /// <param name="value"></param>
        static public void WriteSetting(string settingKey, string value)
        {
            AppSettingHelper.SysSetting.WriteSetting(settingKey, value);
        }


        static public void WriteInt(string settingKey, int value)
        {
            WriteSetting(settingKey, value.ToString());
        }

        static public void WriteDouble(string settingKey, double value)
        {
            WriteSetting(settingKey, value.ToString());
        }

        static public void WriteDateTime(string settingKey, DateTime value)
        {
            WriteSetting(settingKey, value.ToString());
        }

        static public void WriteBool(string settingKey, bool value)
        {
            WriteSetting(settingKey, value.ToString());
        }

        /// <summary>
        /// 判断配置键是否存在
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        static public bool HasKey(string settingKey)
        {
            return AppSettingHelper.SysSetting.HasKey(settingKey);
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        static public string ReadSetting(string settingKey, string defaultValue = "")
        {
            return AppSettingHelper.SysSetting.ReadSetting(settingKey, defaultValue);
        }

        /// <summary>
        /// 读取整数配置
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        static public int ReadInt(string settingKey, int defaultValue = 0)
        {
            return Convert.ToInt32(ReadSetting(settingKey, defaultValue.ToString()));
        }

        /// <summary>
        /// 读取浮点数配置
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        static public Double ReadDouble(string settingKey, double defaultValue = 0)
        {
            return Convert.ToDouble(ReadSetting(settingKey, defaultValue.ToString()));
        }

        /// <summary>
        /// 读取日期配置
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        static public DateTime ReadDatetime(string settingKey, DateTime defaultValue = default(DateTime))
        {
            return Convert.ToDateTime(ReadSetting(settingKey, defaultValue.ToString()));
        }

        /// <summary>
        /// 读取bool类型配置
        /// </summary>
        /// <param name="settingKey"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        static public bool ReadBool(string settingKey, bool defaultValue = false)
        {
            return Convert.ToBoolean(ReadSetting(settingKey, defaultValue.ToString()));
        }

    }
}

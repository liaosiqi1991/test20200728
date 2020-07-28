using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.Services
{


    public class ThridDBInstance
    {
        public string 实例名称 { get; set; }
        public string IP地址 { get; set; }

        public string 端口 { get; set; }
        public string 授权用户 { get; set; }
        public string 授权密码 { get; set; }
        public string 驱动文件 { get; set; }

    }


    [Serializable]
    public class ServerInfo: ISerializable
    {
        [DisplayName("服务标识")]
        [Browsable(false)]
        public string Key { get; }

        [DisplayName("服务别名")]
        public string ServerAlias { get; set; }

        [DisplayName("服务器类型")]
        public string ServerType { get; set; }

        [DisplayName("服务驱动文件")]
        public string ServerDriverFile { get; set; }

        [DisplayName("服务器IP")]
        public string ServerIP { get; set; }

        [DisplayName("服务器端口")]
        public int ServerPort { get; set; }

        [DisplayName("服务器实例")]
        public string ServerInstance { get; set; }

        [DisplayName("授权账号")]
        public string GrantAccount { get; set; }

        [DisplayName("授权密码")]
        [Browsable(false)]
        public string GrantPwd { get; set; }

        [DisplayName("认证方式")]
        public string AuthenticationWay { get; set; }

        [DisplayName("认证驱动文件")]
        public string AuthenticationDirverFile { get; set; }

        [DisplayName("三方数据源")] 
        public bool IsThridDBSource { get; set; }

        public ServerInfo()
        {
            Key = Guid.NewGuid().ToString("N");
        }



        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected ServerInfo(SerializationInfo info, StreamingContext context)
        {
            try { Key = info.GetString("Key");} catch { }
            try { ServerAlias = info.GetString("ServerAlias");} catch { }
            try { ServerType = info.GetString("ServerType");} catch { }
            try { ServerDriverFile = info.GetString("ServerDriverFile");} catch { }
            try { ServerIP = info.GetString("ServerIP");} catch { }
            try { ServerPort = info.GetInt32("ServerPort");} catch { }
            try { ServerInstance = info.GetString("ServerInstance");} catch { }
            try { GrantAccount = info.GetString("GrantAccount");} catch { }
            try { GrantPwd = info.GetString("GrantPwd");} catch { }
            try { AuthenticationWay = info.GetString("AuthenticationWay");} catch { }
            try { AuthenticationDirverFile = info.GetString("AuthenticationDirverFile"); } catch { }
            try { IsThridDBSource = info.GetBoolean("IsThridDBSource"); } catch { }
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Key", Key);
            info.AddValue("ServerAlias", ServerAlias);
            info.AddValue("ServerType", ServerType);
            info.AddValue("ServerDriverFile", ServerDriverFile);
            info.AddValue("ServerIP", ServerIP);
            info.AddValue("ServerPort", (int)ServerPort);
            info.AddValue("ServerInstance", ServerInstance);
            info.AddValue("GrantAccount", GrantAccount);
            info.AddValue("GrantPwd", GrantPwd);
            info.AddValue("AuthenticationWay", AuthenticationWay);
            info.AddValue("AuthenticationDirverFile", AuthenticationDirverFile);
            info.AddValue("IsThridDBSource", IsThridDBSource);
        }

    }


    public class ServerManager : List<ServerInfo>
    {
        private const string EncryptKey = "73AA17596B4746AB94DDC626FC666D1D";
        public ServerManager()
        { 
        }

        private string DefaultCfgFile 
        {
            get { return System.Windows.Forms.Application.StartupPath + @"\ServerCfg.dat"; }
        }

         public void SaveToFile()
        {
            SaveToFile(DefaultCfgFile);
        }

        public void LoadFromFile()
        {
            string cfgFile = DefaultCfgFile;
            if (File.Exists(cfgFile)) LoadFromFile(cfgFile);
        }

        /// <summary>
        /// 保存到文件
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveToFile(string fileName)
        {
            Dictionary<string, ServerInfo> serCfg = this.ToDictionary(key => key.ServerAlias, value => value);

            string context = DictionaryJsonHelper.SerializeDictionaryToJsonString<string, ServerInfo>(serCfg);

            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                Encrypt ept = new Encrypt(EncryptKey, false);

                context = ept.EncryptStr(context);

                sw.Write(context);
                sw.Flush();
            } 
            finally
            {
                sw.Close();
                fs.Close();
            }
        }

        /// <summary>
        /// 从文件载入
        /// </summary>
        /// <param name="fileName"></param>
        public void LoadFromFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            try
            {

                string context = sr.ReadToEnd();

                Encrypt ept = new Encrypt(EncryptKey, false);
                context = ept.DecryptStr(context);

                Dictionary<string, ServerInfo> serCfg = DictionaryJsonHelper.DeserializeStringToDictionary<string, ServerInfo>(context);

                foreach (ServerInfo si in serCfg.Values) Add(si);
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
            
            
        }

        public ServerInfo FindAlias(string serverAlias)
        {
            foreach (ServerInfo si in this)
            {
                if (si.ServerAlias.Equals(serverAlias)) return si;
            }

            return null;
        }

        public ServerInfo FindKey(string key)
        {
            foreach (ServerInfo si in this)
            {
                if (si.Key.Equals(key)) return si;
            }

            return null;
        }

        static public ServerEnum EnumDBLibary()
        {
            return new ServerEnum();
        }

        static public VerifyEnum EnumVerifyLibary()
        {
            return new VerifyEnum();
        }
    }



}

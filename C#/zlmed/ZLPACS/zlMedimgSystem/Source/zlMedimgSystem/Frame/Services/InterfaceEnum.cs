using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using zlMedimgSystem.Interface;

namespace zlMedimgSystem.Services
{

    public class InterfaceEnum<T> : Dictionary<string, string>
        where T : IInterfaceName
    {
        protected InterfaceEnum()
        {

        }
        
        /// <summary>
        /// 根据接口名称创建实例
        /// </summary>
        /// <param name="interfaceName"></param>
        /// <param name="objSuffixName"></param>
        /// <returns></returns>
        public object CreateInstance(string interfaceName, string objSuffixName = "")
        {
            string file = System.Windows.Forms.Application.StartupPath + @"\" + this[interfaceName];
            FileInfo fi = new FileInfo(file);

            string assemblyName = fi.Name.Replace(fi.Extension, "");
            string[] tmp = ("..." + assemblyName).Split('.');
            string objName = tmp[tmp.Length - 1];


            return Assembly.LoadFile(file).CreateInstance(assemblyName + "." + objName + objSuffixName);
        }

        public InterfaceEnum(string fileMatchPattern, string objSuffixName = "")
        {
            EnumDBLibary(fileMatchPattern);
        }

        /// <summary>
        /// 载入数据访问模块
        /// </summary>
        /// <returns></returns>
        private void EnumDBLibary(string fileMatchPattern, string objSuffixName = "")
        {
            DirectoryInfo di = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);

            FileInfo[] fis = di.GetFiles(fileMatchPattern, SearchOption.TopDirectoryOnly);

            if (fis.Length <= 0) return;


            foreach (FileInfo fi in fis)
            {
                if (fi.Extension.ToUpper().Equals(".DLL") == false) continue;

                string assemblyName = fi.Name.Replace(fi.Extension, "");
                string[] tmp = ("..." + assemblyName).Split('.');
                string objName = tmp[tmp.Length - 1];

                T objAssembly = default(T);

                try
                {
                    objAssembly = (T)Assembly.LoadFile(fi.FullName).CreateInstance(assemblyName + "." + objName + objSuffixName);
                }
                catch
                {
                    objAssembly = default(T);
                }

                if (objAssembly != null)
                {
                    Add(objAssembly.InterfaceName, fi.Name);
                }

            }
        }
    }


    public class ServerEnum : InterfaceEnum<IDBProvider>
    {
        public ServerEnum() : base("*.DB.*")
        {
        }

        static public IDBProvider GetDBProvider(string driverFileName)
        {
            string modulePath = System.Windows.Forms.Application.StartupPath + @"\" + driverFileName;

            IDBProvider dbProvide = null;
            if (File.Exists(modulePath) == true)
            {
                FileInfo fi = new FileInfo(modulePath);

                string assemblyName = fi.Name.Replace(fi.Extension, "");
                string[] tmp = ("..." + assemblyName).Split('.');
                string objName = tmp[tmp.Length - 1];

                dbProvide = (IDBProvider)Assembly.LoadFile(modulePath).CreateInstance(assemblyName + "." + objName);
            }

            return dbProvide;
        }
    }


    public class VerifyEnum : InterfaceEnum<IVerify>
    {
        public VerifyEnum() : base("*.VERI.*")
        {
        }
    }

}

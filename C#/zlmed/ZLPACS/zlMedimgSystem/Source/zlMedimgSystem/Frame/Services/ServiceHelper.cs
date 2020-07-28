using System;
using System.ServiceProcess;
using Microsoft.Win32;
using System.IO;

namespace zlMedimgSystem.Services
{
    public class ServiceHelper
    {
        public string ServicesName { get; set; }


        public ServiceHelper(string servicesName)
        {
            ServicesName = servicesName;
        }

        /// <summary>
        /// 获取服务程序所在位置
        /// </summary>
        /// <param name="serviceName"></param>
        public string GetServicePath()
        { 

            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services)
            {
                if (s.ServiceName.ToUpper() == ServicesName.ToUpper())
                {
                    RegistryKey _Key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Services\" + ServicesName);

                    if (_Key != null)
                    {
                        object objPath = _Key.GetValue("ImagePath");
                        if (objPath != null)
                        {
                            return Path.GetDirectoryName(objPath.ToString().Substring(1).Replace("\"", "")) + "\\";
                        }
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// 服务是否存在
        /// </summary>
        /// <returns></returns>
        public bool ServiceIsExisted()
        {
            
            ServiceController[] services = ServiceController.GetServices();

            foreach (ServiceController s in services)
            {
                if (s.ServiceName == ServicesName)
                {
                    //如果服务存在，检查是否启动，没有启动则尝试启动
                    try
                    {
                        using (ServiceController imageLoadServ = new ServiceController(ServicesName))
                        {
                            if (imageLoadServ.Status == ServiceControllerStatus.Stopped)
                            {
                                imageLoadServ.Start();
                                imageLoadServ.Refresh();
                                imageLoadServ.WaitForStatus(ServiceControllerStatus.Running, (new TimeSpan(0, 0, 60)));
                            }
                        }
                    }
                    catch { }

                    return true;
                }
            }

            return false;
        }
    }
}

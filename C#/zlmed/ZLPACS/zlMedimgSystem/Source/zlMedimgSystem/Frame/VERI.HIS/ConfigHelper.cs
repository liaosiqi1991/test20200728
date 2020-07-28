using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.VERI.His
{
    public class ConfigHelper
    {

        static public  string CreateConfig(string configFile)
        {
            try
            {
                if (!File.Exists(configFile))
                {
                    string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n<configuration>\r\n</configuration>";
                    using (StreamWriter sw = new StreamWriter(configFile))
                    {
                        sw.Write(xml);
                    }
                }

                return configFile;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }

        }

        static public string GetCfgName()
        {
            return System.Windows.Forms.Application.StartupPath + @"\" + "zlMedimgSystem.VERI.His";
        }
    }
}

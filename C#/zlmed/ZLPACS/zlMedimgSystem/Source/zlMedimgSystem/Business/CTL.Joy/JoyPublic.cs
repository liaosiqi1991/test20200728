using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Joy
{
    public class JoyPar
    {
        public string JoyName { get; set; }

        public JoyPar()
        {

        }

        public void CopyFrom(JoyPar sourcePar)
        {
            this.JoyName = sourcePar.JoyName;
        }


        static public JoyPar GetConfig()
        {
            JoyPar joyPar = new JoyPar();

            joyPar.JoyName = AppSetting.ReadSetting("JoyName");
            
            return joyPar;
        }

        static public void SetConfig(JoyPar joyPar)
        {
            AppSetting.WriteSetting("JoyName", joyPar.JoyName);
        }
    }
}

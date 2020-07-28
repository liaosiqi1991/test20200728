using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.Services
{
    static public class ConsoleEx
    {

        static public void WriteLine(string context)
        {
            Console.Write(AppDomain.CurrentDomain.FriendlyName + ": (" + DateTime.Now.ToString() + ") " + context);
        }
    }
}

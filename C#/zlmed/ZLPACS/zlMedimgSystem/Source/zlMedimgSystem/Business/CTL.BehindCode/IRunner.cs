using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Design;
using zlMedimgSystem.Interface;
using System.Windows.Forms;

namespace zlMedimgSystem.CTL.BehindCode
{
    public interface IRunner
    {
        void Init(CoordinationBizModules winRelateModules, IDBQuery dbHelper, IDBQuery thridDbHelper, ILoginUser userData, IStationInfo stationInfo, 
            IBizDataTransferCenter dataTransCenter, IWin32Window owner);
        bool Run(string callModuleName, ISysDesign callModule, object sender, object eventArgs, string actName, string actTag, 
            IBizDataItems sourceBizDatas, out IBizDataItems processBizDatas);
    }
}

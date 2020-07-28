using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zlMedimgSystem.CTL.BehindCode
{
    public class BehindCodeItem
    {
        /// <summary>
        /// 功能名称
        /// </summary>
        public string FuncName { get; set; }

        /// <summary>
        /// 三方数据源别名
        /// </summary>
        public string ThridDBAlias { get; set; }

        /// <summary>
        /// 功能代码内容
        /// </summary>
        public string FuncContext { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public int VerNo { get; set; }

        /// <summary>
        /// 是否后台编译
        /// </summary>
        public bool IsBGCompile { get; set; }

        public BehindCodeItem Clone()
        {
            BehindCodeItem result = new BehindCodeItem();

            result.FuncName = FuncName;
            result.FuncContext = FuncContext;
            result.ThridDBAlias = ThridDBAlias;
            result.VerNo = VerNo;
            result.IsBGCompile = IsBGCompile;

            return result;
        }
    }
    public class BehindCodeModuleDesign
    {
        public List<BehindCodeItem> BehindCodes { get; set; }

        public BehindCodeModuleDesign()
        {
            BehindCodes = new List<BehindCodeItem>();
        }
    }
}

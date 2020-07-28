
using System.Text;

using System.Xml;

namespace zlMedimgSystem.Services
{
    public class VbPipeData: PipeData 
    {
        public VbPipeData()
        {
        }

        /// <summary>
        /// 删除不可打印字符
        /// </summary>
        /// <param name="tmp"></param>
        /// <returns></returns>
        private string ReplaceLowOrderASCIICharacters(string tmp)
        {
            StringBuilder info = new StringBuilder();
            foreach (char cc in tmp)
            {
                int ss = (int)cc;
                if (((ss >= 0) && (ss <= 8)) || ((ss >= 11) && (ss <= 12)) || ((ss >= 14) && (ss <= 32)))
                    info.AppendFormat(" ", ss);
                else info.Append(cc);
            }
            return info.ToString();
        }  

        public override void LoadXml(string xmlData)
        {
            string curXmlKey = "";
            string curXmlValue = "";

            xmlData = ReplaceLowOrderASCIICharacters(xmlData);
            XmlDocument xmlDoc = new XmlDocument();
 
            xmlDoc.LoadXml(xmlData);

            foreach (XmlNode xNode in xmlDoc.FirstChild.ChildNodes)
            {
                curXmlKey = xNode.Name.Replace("_x003C_", "<").Replace("_x0040_", "@").Replace("_x003E_", ">");
                curXmlValue = xNode.InnerText;

                SetValue(curXmlKey, curXmlValue);
                ParseStructure(curXmlKey, xNode.InnerText);
            }
        }
    }
}

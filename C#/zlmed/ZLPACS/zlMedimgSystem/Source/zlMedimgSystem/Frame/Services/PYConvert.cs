using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace zlMedimgSystem.Services
{
    public class PYConvert
    {
        private static int[] pyValue = new int[]
        {
            -20319,-20317,-20304,-20295,-20292,-20283,-20265,-20257,-20242,-20230,-20051,-20036,
            -20032,-20026,-20002,-19990,-19986,-19982,-19976,-19805,-19784,-19775,-19774,-19763,
            -19756,-19751,-19746,-19741,-19739,-19728,-19725,-19715,-19540,-19531,-19525,-19515,
            -19500,-19484,-19479,-19467,-19289,-19288,-19281,-19275,-19270,-19263,-19261,-19249,
            -19243,-19242,-19238,-19235,-19227,-19224,-19218,-19212,-19038,-19023,-19018,-19006,
            -19003,-18996,-18977,-18961,-18952,-18783,-18774,-18773,-18763,-18756,-18741,-18735,
            -18731,-18722,-18710,-18697,-18696,-18526,-18518,-18501,-18490,-18478,-18463,-18448,
            -18447,-18446,-18239,-18237,-18231,-18220,-18211,-18201,-18184,-18183, -18181,-18012,
            -17997,-17988,-17970,-17964,-17961,-17950,-17947,-17931,-17928,-17922,-17759,-17752,
            -17733,-17730,-17721,-17703,-17701,-17697,-17692,-17683,-17676,-17496,-17487,-17482,
            -17468,-17454,-17433,-17427,-17417,-17202,-17185,-16983,-16970,-16942,-16915,-16733,
            -16708,-16706,-16689,-16664,-16657,-16647,-16474,-16470,-16465,-16459,-16452,-16448,
            -16433,-16429,-16427,-16423,-16419,-16412,-16407,-16403,-16401,-16393,-16220,-16216,
            -16212,-16205,-16202,-16187,-16180,-16171,-16169,-16158,-16155,-15959,-15958,-15944,
            -15933,-15920,-15915,-15903,-15889,-15878,-15707,-15701,-15681,-15667,-15661,-15659,
            -15652,-15640,-15631,-15625,-15454,-15448,-15436,-15435,-15419,-15416,-15408,-15394,
            -15385,-15377,-15375,-15369,-15363,-15362,-15183,-15180,-15165,-15158,-15153,-15150,
            -15149,-15144,-15143,-15141,-15140,-15139,-15128,-15121,-15119,-15117,-15110,-15109,
            -14941,-14937,-14933,-14930,-14929,-14928,-14926,-14922,-14921,-14914,-14908,-14902,
            -14894,-14889,-14882,-14873,-14871,-14857,-14678,-14674,-14670,-14668,-14663,-14654,
            -14645,-14630,-14594,-14429,-14407,-14399,-14384,-14379,-14368,-14355,-14353,-14345,
            -14170,-14159,-14151,-14149,-14145,-14140,-14137,-14135,-14125,-14123,-14122,-14112,
            -14109,-14099,-14097,-14094,-14092,-14090,-14087,-14083,-13917,-13914,-13910,-13907,
            -13906,-13905,-13896,-13894,-13878,-13870,-13859,-13847,-13831,-13658,-13611,-13601,
            -13406,-13404,-13400,-13398,-13395,-13391,-13387,-13383,-13367,-13359,-13356,-13343,
            -13340,-13329,-13326,-13318,-13147,-13138,-13120,-13107,-13096,-13095,-13091,-13076,
            -13068,-13063,-13060,-12888,-12875,-12871,-12860,-12858,-12852,-12849,-12838,-12831,
            -12829,-12812,-12802,-12607,-12597,-12594,-12585,-12556,-12359,-12346,-12320,-12300,
            -12120,-12099,-12089,-12074,-12067,-12058,-12039,-11867,-11861,-11847,-11831,-11798,
            -11781,-11604,-11589,-11536,-11358,-11340,-11339,-11324,-11303,-11097,-11077,-11067,
            -11055,-11052,-11045,-11041,-11038,-11024,-11020,-11019,-11018,-11014,-10838,-10832,
            -10815,-10800,-10790,-10780,-10764,-10587,-10544,-10533,-10519,-10331,-10329,-10328,
            -10322,-10315,-10309,-10307,-10296,-10281,-10274,-10270,-10262,-10260,-10256,-10254
        };

        private static string[] pyName = new string[]
        {
            "A","Ai","An","Ang","Ao","Ba","Bai","Ban","Bang","Bao","Bei","Ben",
            "Beng","Bi","Bian","Biao","Bie","Bin","Bing","Bo","Bu","Ba","Cai","Can",
            "Cang","Cao","Ce","Ceng","Cha","Chai","Chan","Chang","Chao","Che","Chen","Cheng",
            "Chi","Chong","Chou","Chu","Chuai","Chuan","Chuang","Chui","Chun","Chuo","Ci","Cong",
            "Cou","Cu","Cuan","Cui","Cun","Cuo","Da","Dai","Dan","Dang","Dao","De",
            "Deng","Di","Dian","Diao","Die","Ding","Diu","Dong","Dou","Du","Duan","Dui",
            "Dun","Duo","E","En","Er","Fa","Fan","Fang","Fei","Fen","Feng","Fo",
            "Fou","Fu","Ga","Gai","Gan","Gang","Gao","Ge","Gei","Gen","Geng","Gong",
            "Gou","Gu","Gua","Guai","Guan","Guang","Gui","Gun","Guo","Ha","Hai","Han",
            "Hang","Hao","He","Hei","Hen","Heng","Hong","Hou","Hu","Hua","Huai","Huan",
            "Huang","Hui","Hun","Huo","Ji","Jia","Jian","Jiang","Jiao","Jie","Jin","Jing",
            "Jiong","Jiu","Ju","Juan","Jue","Jun","Ka","Kai","Kan","Kang","Kao","Ke",
            "Ken","Keng","Kong","Kou","Ku","Kua","Kuai","Kuan","Kuang","Kui","Kun","Kuo",
            "La","Lai","Lan","Lang","Lao","Le","Lei","Leng","Li","Lia","Lian","Liang",
            "Liao","Lie","Lin","Ling","Liu","Long","Lou","Lu","Lv","Luan","Lue","Lun",
            "Luo","Ma","Mai","Man","Mang","Mao","Me","Mei","Men","Meng","Mi","Mian",
            "Miao","Mie","Min","Ming","Miu","Mo","Mou","Mu","Na","Nai","Nan","Nang",
            "Nao","Ne","Nei","Nen","Neng","Ni","Nian","Niang","Niao","Nie","Nin","Ning",
            "Niu","Nong","Nu","Nv","Nuan","Nue","Nuo","O","Ou","Pa","Pai","Pan",
            "Pang","Pao","Pei","Pen","Peng","Pi","Pian","Piao","Pie","Pin","Ping","Po",
            "Pu","Qi","Qia","Qian","Qiang","Qiao","Qie","Qin","Qing","Qiong","Qiu","Qu",
            "Quan","Que","Qun","Ran","Rang","Rao","Re","Ren","Reng","Ri","Rong","Rou",
            "Ru","Ruan","Rui","Run","Ruo","Sa","Sai","San","Sang","Sao","Se","Sen",
            "Seng","Sha","Shai","Shan","Shang","Shao","She","Shen","Sheng","Shi","Shou","Shu",
            "Shua","Shuai","Shuan","Shuang","Shui","Shun","Shuo","Si","Song","Sou","Su","Suan",
            "Sui","Sun","Suo","Ta","Tai","Tan","Tang","Tao","Te","Teng","Ti","Tian",
            "Tiao","Tie","Ting","Tong","Tou","Tu","Tuan","Tui","Tun","Tuo","Wa","Wai",
            "Wan","Wang","Wei","Wen","Weng","Wo","Wu","Xi","Xia","Xian","Xiang","Xiao",
            "Xie","Xin","Xing","Xiong","Xiu","Xu","Xuan","Xue","Xun","Ya","Yan","Yang",
            "Yao","Ye","Yi","Yin","Ying","Yo","Yong","You","Yu","Yuan","Yue","Yun",
            "Za", "Zai","Zan","Zang","Zao","Ze","Zei","Zen","Zeng","Zha","Zhai","Zhan",
            "Zhang","Zhao","Zhe","Zhen","Zheng","Zhi","Zhong","Zhou","Zhu","Zhua","Zhuai","Zhuan",
            "Zhuang","Zhui","Zhun","Zhuo","Zi","Zong","Zou","Zu","Zuan","Zui","Zun","Zuo"
        };

        static private Hashtable _hashTableSurName = null;

        /// <summary>
        /// 获取姓氏拼音
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static public string GetSurnamePy(string name)
        {
            if (string.IsNullOrEmpty(name)) return "";

            if (_hashTableSurName == null)
            {
                _hashTableSurName = new Hashtable();

                _hashTableSurName.Add("柏", "Bai");
                _hashTableSurName.Add("贲", "Ben");
                _hashTableSurName.Add("薄", "Bo");
                _hashTableSurName.Add("都", "Du");
                _hashTableSurName.Add("颉", "Jie");
                _hashTableSurName.Add("解", "Xie");
                _hashTableSurName.Add("秘", "Bi");
                _hashTableSurName.Add("长", "Chang");
                _hashTableSurName.Add("长孙", "Zhang Sun");
                _hashTableSurName.Add("牟", "Mou");

                _hashTableSurName.Add("莘", "Shen");
                _hashTableSurName.Add("殷", "Yin");
                _hashTableSurName.Add("隽", "Juan");
                _hashTableSurName.Add("尉", "Wei");
                _hashTableSurName.Add("尉迟", "Yu Chi");
                _hashTableSurName.Add("奇", "Ji");
                _hashTableSurName.Add("宓", "Mi");
                _hashTableSurName.Add("盖", "Ge");
                _hashTableSurName.Add("覃", "Qin");
                _hashTableSurName.Add("单", "Shan");

                _hashTableSurName.Add("单于", "Chan Yu");
                _hashTableSurName.Add("谌", "Shen");
                _hashTableSurName.Add("翟", "Zhai");
                _hashTableSurName.Add("乐", "Yue");
                _hashTableSurName.Add("召", "Shao");
                _hashTableSurName.Add("隗", "Kui");
                _hashTableSurName.Add("种", "Chong");
                _hashTableSurName.Add("朴", "Piao");
                _hashTableSurName.Add("仇", "Qiu");
                _hashTableSurName.Add("区", "Ou");

                _hashTableSurName.Add("折", "She");
                _hashTableSurName.Add("黑", "Hei");
                _hashTableSurName.Add("繁", "Po");
                _hashTableSurName.Add("纪", "Ji");
                _hashTableSurName.Add("查", "Cha");
                _hashTableSurName.Add("郇", "Huan");
                _hashTableSurName.Add("弗", "Fu");
                _hashTableSurName.Add("褚", "Chu");
                _hashTableSurName.Add("适", "Shi");
                _hashTableSurName.Add("句", "Ju");

                _hashTableSurName.Add("阚", "Kan");
                _hashTableSurName.Add("乜", "Nie");
                _hashTableSurName.Add("眭", "Sui");
                _hashTableSurName.Add("洗", "Xian");
                _hashTableSurName.Add("员", "Yun");
                _hashTableSurName.Add("祭", "Zhai");
                _hashTableSurName.Add("宿", "Su");
                _hashTableSurName.Add("缪", "Miao");
                _hashTableSurName.Add("乘", "Cheng");
                _hashTableSurName.Add("辟", "Bi");

                _hashTableSurName.Add("车", "Che");
                _hashTableSurName.Add("会", "Kuai");
                _hashTableSurName.Add("铅", "Qian");
                _hashTableSurName.Add("茄", "Qie");
                _hashTableSurName.Add("万", "Wan");
                _hashTableSurName.Add("万俟", "Mo Qi");
                _hashTableSurName.Add("吾", "Wu");
                //ht.Add("", "");
                //ht.Add("", "");
                //ht.Add("", "");
            }


            object value = _hashTableSurName[name.Substring(0, 1)];

            if (value != null)
            {
                return value.ToString() + " " + ConvertPy(name.Substring(1));
            }
            else
            {
                return ConvertPy(name);
            }
        }

        static private Hashtable _hashTableCall = null;

        /// <summary>
        /// 格式化呼叫的姓名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static public string FormatCallSurname(string name)
        {

            if (_hashTableCall == null)
            {
                _hashTableCall = new Hashtable();

                _hashTableCall.Add("柏", "白");
                _hashTableCall.Add("贲", "奔");
                _hashTableCall.Add("薄", "伯");
                _hashTableCall.Add("都", "嘟");
                _hashTableCall.Add("颉", "杰");
                _hashTableCall.Add("解", "谢");
                _hashTableCall.Add("秘", "闭");
                _hashTableCall.Add("长", "常");
                _hashTableCall.Add("长孙", "掌孙");
                _hashTableCall.Add("牟", "谋");

                _hashTableCall.Add("莘", "身");
                _hashTableCall.Add("殷", "阴");
                _hashTableCall.Add("隽", "倦");
                _hashTableCall.Add("尉", "喂");
                _hashTableCall.Add("尉迟", "玉迟");
                _hashTableCall.Add("奇", "叽");
                _hashTableCall.Add("宓", "觅");
                _hashTableCall.Add("盖", "舸");
                _hashTableCall.Add("覃", "芹");
                _hashTableCall.Add("单", "讪");

                _hashTableCall.Add("单于", "婵于");
                _hashTableCall.Add("谌", "肾");
                _hashTableCall.Add("翟", "宅");
                _hashTableCall.Add("乐", "月");
                _hashTableCall.Add("召", "邵");
                _hashTableCall.Add("隗", "奎");
                _hashTableCall.Add("种", "崇");
                _hashTableCall.Add("朴", "瓢");
                _hashTableCall.Add("仇", "囚");
                _hashTableCall.Add("区", "讴");

                _hashTableCall.Add("折", "舌");
                //_hashTableCall.Add("黑", "Hei");
                _hashTableCall.Add("繁", "婆");
                _hashTableCall.Add("纪", "己");
                _hashTableCall.Add("查", "察");
                _hashTableCall.Add("郇", "环");
                //_hashTableCall.Add("弗", "Fu");
                _hashTableCall.Add("褚", "杵");
                _hashTableCall.Add("适", "士");
                _hashTableCall.Add("句", "巨");

                _hashTableCall.Add("阚", "崁");
                _hashTableCall.Add("乜", "圼");
                //_hashTableCall.Add("眭", "Sui");
                _hashTableCall.Add("洗", "崄");
                _hashTableCall.Add("员", "运");
                _hashTableCall.Add("祭", "债");
                _hashTableCall.Add("宿", "素");
                _hashTableCall.Add("缪", "妙");
                _hashTableCall.Add("乘", "程");
                _hashTableCall.Add("辟", "闭");

                //_hashTableCall.Add("车", "Che");
                _hashTableCall.Add("会", "快");
                _hashTableCall.Add("铅", "签");
                //_hashTableCall.Add("茄", "Qie");
                //_hashTableCall.Add("万", "Wan");
                _hashTableCall.Add("万俟", "末骑");
                //_hashTableCall.Add("吾", "Wu");
                //ht.Add("", "");
                //ht.Add("", "");
                //ht.Add("", "");
            }

            object value = _hashTableCall[name.Substring(0, 1)];

            if (value != null)
            {
                return value.ToString() + name.Substring(1);
            }
            else
            {
                return name;
            }
        }

        /// <summary>
        /// 把汉字转换成拼音(全拼)
        /// </summary>
        /// <param name="hzString">汉字字符串</param>
        /// <returns>转换后的拼音(全拼)字符串</returns>
        public static string ConvertPy(string hzString)
        {
            // 匹配中文字符
            Regex regex = new Regex("^[\u4e00-\u9fa5]$");
            byte[] array = new byte[2];
            string pyString = "";
            int chrAsc = 0;
            int i1 = 0;
            int i2 = 0;
            char[] noWChar = hzString.ToCharArray();

            for (int j = 0; j < noWChar.Length; j++)
            {
                // 中文字符
                if (regex.IsMatch(noWChar[j].ToString()))
                {
                    array = System.Text.Encoding.Default.GetBytes(noWChar[j].ToString());
                    i1 = (short)(array[0]);
                    i2 = (short)(array[1]);
                    chrAsc = i1 * 256 + i2 - 65536;


                    if (chrAsc > 0 && chrAsc < 160)
                    {
                        pyString += noWChar[j];
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(pyString) == false) pyString += " ";
                        // 修正部分文字
                        if (chrAsc == -9254)  // 修正“圳”字
                            pyString += "Zhen";
                        else if (chrAsc == -12080)
                        {
                            pyString += "Hang";
                        }
                        else if (chrAsc == -8985)
                        {
                            pyString += "Qian";
                        }
                        else if (chrAsc == -5463)
                        {
                            pyString += "Jia";
                        }
                        else if (chrAsc == -8274)
                        {
                            pyString += "Ge";
                        }
                        else if (chrAsc == -5448)
                        {
                            pyString += "Ga";
                        }
                        else if (chrAsc == -5447)
                        {
                            pyString += "La";
                        }
                        else if (chrAsc == -4649)
                        {
                            pyString += "Chen";
                        }
                        else if (chrAsc == -5436)
                        {
                            pyString += "Mao";
                        }
                        else if (chrAsc == -5213)
                        {
                            pyString += "Mao";
                        }
                        else if (chrAsc == -3597)
                        {
                            pyString += "Die";
                        }
                        else if (chrAsc == -5659)
                        {
                            pyString += "Tian";
                        }
                        else
                        {
                            for (int i = (pyValue.Length - 1); i >= 0; i--)
                            {
                                if (pyValue[i] <= chrAsc)
                                {
                                    pyString += pyName[i];
                                    break;
                                }
                            }
                        }
                    }
                }
                // 非中文字符
                else
                {
                    pyString += noWChar[j].ToString();
                }
            }
            return pyString;
        }
    }
}

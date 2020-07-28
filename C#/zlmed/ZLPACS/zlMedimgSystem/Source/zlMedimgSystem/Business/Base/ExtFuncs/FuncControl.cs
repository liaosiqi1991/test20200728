using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using zlMedimgSystem.Services;
using System.IO;

namespace zlMedimgSystem.ExtFuncs
{
    public partial class FuncControl : UserControl
    {
        private bool _isDesiging = false;

        private InputItems _inputs = null; 

        public FuncControl()
        {
            InitializeComponent();

            lcDemo.RegisterUserCustomizationForm(typeof(DesignMiddleWare));
            lcDemo.AllowCustomization = false;

            _inputs = new InputItems();
        }



        public InputItems Inputs
        {
            get { return _inputs; }
        }

        /// <summary>
        /// 是否进入布局设计状态
        /// </summary>
        public bool DesignState
        {
            get { return _isDesiging; }
            set
            {
                if (_isDesiging == value) return;

                if (value)
                {
                    EnterDesign();
                }
                else
                {
                    CloseDesign();
                }

                _isDesiging = value;
            }
        }


        /// <summary>
        /// 清除布局
        /// </summary>
        public void ClearLayout()
        {
            for (int i = lcDemo.Controls.Count - 1; i >= 0; i--)
            {
                lcDemo.Controls[i].Dispose();
            }

            lcDemo.Controls.Clear();
            lcDemo.Clear(); 
        }


        /// <summary>
        /// 保存为格式串
        /// </summary>
        /// <returns></returns>
        public string SaveSchemeToString()
        { 
            Dictionary<string, string> layoutFmt = new Dictionary<string, string>();
            layoutFmt.Add("录入格式", _inputs.SaveToString());

            using (MemoryStream ms = new MemoryStream())
            {
                lcDemo.SaveLayoutToStream(ms);

                ms.Position = 0;

                StreamReader sr = new StreamReader(ms);

                layoutFmt.Add("布局格式", sr.ReadToEnd());
            }

            return DictionaryJsonHelper.SerializeDictionaryToJsonString<string, string>(layoutFmt);
        }

        /// <summary>
        /// 从格式串载入
        /// </summary>
        /// <param name="queryScheme"></param>
        public void LoadSchemeFromString(string funcScheme)
        {
            if (string.IsNullOrEmpty(funcScheme))
            {
                ClearLayout();
                return;
            }

            string inputItemFmts = "";
            string layoutContext = "";

            ParseFromString(funcScheme, out inputItemFmts, out layoutContext);

            LoadSchemeFromString(inputItemFmts, layoutContext);
        }


        /// <summary>
        /// 载入布局
        /// </summary>
        /// <param name="sqlFormatContext"></param>
        /// <param name="layoutContext"></param>
        private void LoadSchemeFromString(string inputItemFmts, string layoutContext)
        {

            ClearLayout();

            if (string.IsNullOrEmpty(inputItemFmts) || string.IsNullOrEmpty(layoutContext)) return;

            //读取录入项            
            _inputs.LoadFromString(inputItemFmts);

            foreach (InputItem ii in _inputs.Values)
            {
                AddInputControl(ii, ii.Name);
            } 


            //载入布局
            using (MemoryStream ms = new MemoryStream())
            {
                StreamWriter sw = new StreamWriter(ms);

                sw.Write(layoutContext);

                sw.Flush();

                ms.Position = 0;

                lcDemo.RestoreLayoutFromStream(ms);
            }
        }

        /// <summary>
        /// 解析方案格式
        /// </summary>
        /// <param name="queryScheme"></param>
        /// <param name="sqlFormatContext"></param>
        /// <param name="layoutContext"></param>
        private void ParseFromString(string funcScheme, out string inputItemFmts, out string layoutContext)
        {
            Dictionary<string, string> layoutFmt = DictionaryJsonHelper.DeserializeStringToDictionary<string, string>(funcScheme);

            inputItemFmts = layoutFmt["录入格式"];
            layoutContext = layoutFmt["布局格式"];
        }
                 

        public string GetStorageData()
        {
            if (_inputs == null || _inputs.Count <= 0) return "";

            Dictionary<string, object> values = new Dictionary<string, object>();

            foreach(InputItem ii in _inputs.Values)
            {
                if (ii.AllowStorage == false || ii.LinkControl == null) continue;

                object value = null;
                switch(ii.ControlType)
                {
                    case FuncConstDefine.Txt:
                        value = (ii.LinkControl as TextBox).Text;
                        break;
                    case FuncConstDefine.RTxt:
                        value = (ii.LinkControl as RichTextBox).Text;
                        break;
                    case FuncConstDefine.Cbx:
                        value = (ii.LinkControl as ComboBox).Text;
                        break;
                    case FuncConstDefine.Dtp:
                        value = (ii.LinkControl as DateTimePicker).Value;
                        break;
                    default:
                        break;
                }

                values.Add(ii.Name, value);
            }

            return DictionaryJsonHelper.SerializeDictionaryToJsonString<string, object>(values);
        }

        public int GetLayoutHeight()
        {
            return lcDemo.Root.Height;
        }

        public bool AutoHeight
        {
            get{ return lcDemo.OptionsView.FitControlsToDisplayAreaHeight; }
            set { lcDemo.OptionsView.FitControlsToDisplayAreaHeight = value; }
        }


        /// <summary>
        /// 进入设计模式
        /// </summary>
        private void EnterDesign()
        {
            lcDemo.ShowCustomizationForm();
            lcDemo.Root.Selected = true;

            lcDemo.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void CloseDesign()
        {
            lcDemo.HideCustomizationForm();
            lcDemo.BackColor = this.BackColor;
        }


        public void RemoveControl(string controlName)
        {
            Control ctlDel = lcDemo.GetControlByName(controlName);
            if (ctlDel != null)
            {
                LayoutControlItem lciDel = lcDemo.GetItemByControl(ctlDel);

                if (lciDel.Parent != null) lciDel.Parent.Remove(lciDel);

                lcDemo.Controls.Remove(ctlDel);
            }
        }

        public Control AddInputControl(InputItem ii, string controlName)
        {

            LayoutControlItem lci = null;

            string ctlName = controlName;

            switch (ii.ControlType.ToUpper())
            {
                case FuncConstDefine.Cbx:
                    ComboBox cbx = new ComboBox();
                    cbx.Name = ctlName;

                    //从数据源加载数据

                    //设置默认值
                    cbx.Text = ii.DefaultValue;

                    lci = lcDemo.Root.AddItem(ctlName, cbx);
                    lci.Text = ii.Name;

                    ii.LinkControl = cbx;

                    return cbx;
                case FuncConstDefine.Txt:
                    TextBox tb = new TextBox();
                    tb.Name = ctlName;
                    tb.Text = ii.DefaultValue;//设置默认值

                    lci = lcDemo.Root.AddItem(ctlName, tb);
                    lci.Text = ii.Name;

                    ii.LinkControl = tb;

                    return tb;

                case FuncConstDefine.RTxt:
                    RichTextBox rtb = new RichTextBox();
                    rtb.Name = ctlName;
                    rtb.Text = ii.DefaultValue;//设置默认值

                    rtb.Height = 150;

                    lci = lcDemo.Root.AddItem(ctlName, rtb);  
                    lci.Text = ii.Name;

                    lci.Height = rtb.Height;

                    ii.LinkControl = rtb;

                    return rtb;

                case FuncConstDefine.Dtp:
                    DateTimePicker dtp = new DateTimePicker();
                    dtp.Name = ctlName;

                    try
                    {
                        if (string.IsNullOrEmpty(ii.DefaultValue) == false)
                        {
                            //设置默认值
                            dtp.Value = Convert.ToDateTime(ii.DefaultValue);
                        }
                    }
                    catch
                    { }

                    lci = lcDemo.Root.AddItem(ctlName, dtp);
                    lci.Text = ii.Name;

                    ii.LinkControl = dtp;

                    return dtp;

                default:
                    return null;
            }
        }

        /// <summary>
        /// 事件-显示自定义布局设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lcDemo_ShowCustomization(object sender, EventArgs e)
        {
            try
            {
                Control midleWare = ((DevExpress.XtraLayout.LayoutControl)sender).CustomizationForm as DesignMiddleWare;
                
                midleWare.Visible = false;

                _isDesiging = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void lcDemo_HideCustomization(object sender, EventArgs e)
        {
            try
            {
                _isDesiging = false;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void lcDemo_Resize(object sender, EventArgs e)
        {
            try
            {
                this.Height = lcDemo.Height;
            }
            catch
            {

            }
        }
    }
}

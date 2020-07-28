using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using zlMedimgSystem.Services;
using zlMedimgSystem.Interface;
using zlMedimgSystem.DataModel;

namespace zlMedimgSystem.QueryDesign
{
    public partial class QueryFace : UserControl, ILinkLayout
    {
        private DesignMiddleWare _middleWare = null;

        private bool _IsSimpleState = false;
        private int _height = 0;
        private bool _isDesiging = false;

        private QueryCore _queryCore = null;


        public event SelDesignControl OnSelDesign;
        public event RequestSystemPar OnRequestSystemPar;

        private IDBQuery _dbHelper = null;

        private string _queryScheme = "";


        public QueryFace()
        {
            InitializeComponent();

            lcDemo.RegisterUserCustomizationForm(typeof(DesignMiddleWare));

            lcDemo.AllowCustomization = false;

            _queryCore = new QueryCore();
            _queryCore.LinkControl = this;

            _queryCore.OnRequestSystemPar -= RequestSystemPar;
            _queryCore.OnRequestSystemPar += RequestSystemPar;

        }

        public IDBQuery DBHelper
        {
            get { return _dbHelper; }
            set { _dbHelper = value; }
        }

        public object RequestSystemPar(string parName)
        {
            return OnRequestSystemPar?.Invoke(parName);
        }

        public QueryCore Query { get { return _queryCore; } }

        public LayoutControl LayoutCore { get { return lcDemo; } }

        /// <summary>
        /// 是否精简模式
        /// </summary>
        public bool SimpleState
        {
            get { return _IsSimpleState; }
            set
            {
                if (lcDemo.Root.Items.Count <= 0) return;
                if (_IsSimpleState == value) return;

                if (value == true)
                {
                    //进入精简界面
                    if (_height == 0)
                    {
                        _height = this.Height;
                        this.Height = lcDemo.Root.Items[0].Height + lcDemo.Root.Items[0].Padding.Height + 8;
                    }
                }
                else
                {
                    //进入完整界面
                    if (_height != 0)
                    {
                        this.Height = _height;
                        _height = 0;
                    }
                }


                _IsSimpleState = value;
            }
        }
        private void SelDesignControlProcess(object selControl)
        {
            if (_middleWare != null) _middleWare.Visible = false;

 
            OnSelDesign?.Invoke(selControl);
        }

        /// <summary>
        /// 是否进入布局设计状态
        /// </summary>
        public bool IsDesignModel
        {
            get{ return _isDesiging; }
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

        public void PopupFilter(out string sql, out Dictionary<string, object> pars)
        {
            using (frmQueryFilter qf = new frmQueryFilter())
            {
                qf.ShowQueryFilter(this, _dbHelper, _queryScheme, out sql, out pars);
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

            _queryCore.Clear();
        }

        public ControlCollection Items
        {
            get { return lcDemo.Controls; }
        }
        public Control FindControl(string controlName)
        {
            return lcDemo.GetControlByName(controlName);
        }

        public void RemoveControl(string controlName)
        {
            Control ctlDel = lcDemo.GetControlByName(controlName);
            if (ctlDel != null)
            {
                LayoutControlItem lciDel = lcDemo.GetItemByControl(ctlDel);

                lciDel.ShowInCustomizationForm = false;

                lciDel.Parent.Remove(lciDel);

                lcDemo.Controls.Remove(ctlDel);
            }
        }

        private DataTable GetDataForm(InputItem ii)
        {
            if (string.IsNullOrEmpty(ii.DataFrom)) return null;

            string datafrom = ii.DataFrom;

            //判断是否查询语句
            if (datafrom.ToUpper().IndexOf("SELECT ") >= 0)
            {
                //查询语句处理
                QueryCore qc = new QueryCore();

                qc.OnRequestSystemPar += RequestSystemPar;

                qc.LoadFromString(ii.DataFrom);

                string sql = "";
                Dictionary<string, object> dataPars = new Dictionary<string, object>();
                qc.CreateQuerySql(out sql, out dataPars);

                if (string.IsNullOrEmpty(sql))
                {
                    MessageBox.Show("录入项 [" + ii.Name + "] 对应的数据来源无效。", "提示");
                    return null;
                }

                IDBQuery thridDbHelper = _dbHelper;

                if (string.IsNullOrEmpty(ii.DBAlias) == false)
                {
                    string strErr = "";
                    thridDbHelper = SqlHelper.GetThridDBHelper(ii.DBAlias, _dbHelper, ref strErr);
                    if (thridDbHelper == null)
                    {
                        MessageBox.Show("录入项 [" + ii.Name + "] 对应的数据源不能创建。", "提示");
                        return null;
                    }
                }

                if (thridDbHelper != null)
                {
                    DataTable dtResult = thridDbHelper.ExecuteSQL(sql, dataPars);

                    DataRow drNull = dtResult.NewRow();
                    dtResult.Rows.Add(drNull);

                    return dtResult;
                }
                else
                {
                    MessageBox.Show("尚未初始化数据查询对象。", "提示");
                    return null;
                }

            }
            else
            {
                //字符串处理
                string[] aryDatas = (datafrom + ";").Split(';');

                DataTable dtData = new DataTable();

                dtData.Columns.Add("数据值", typeof(string));
                dtData.Columns.Add("数据描述", typeof(string));

                foreach (string dataItem in aryDatas)
                {
                    if (string.IsNullOrEmpty(dataItem)) continue;

                    DataRow dr = dtData.NewRow();

                    string[] parseData = (dataItem + "-" + dataItem).Split('-');
                    dr["数据值"] = parseData[0];
                    dr["数据描述"] = parseData[1];

                    dtData.Rows.Add(dr);
                }

                DataRow drNull = dtData.NewRow();
                dtData.Rows.Add(drNull);

                return dtData;
            }
        }

        private object GetDefaultValue(InputItem ii)
        {
            if (string.IsNullOrEmpty(ii.DefaultValue))
            {
                return null;
            }

            if (ii.DefaultValue.IndexOf("[") < 0 && ii.DefaultValue.IndexOf("]") < 0)
            {
                return ii.DefaultValue;
            }

            if (ii.DefaultValue.IndexOf("[SQL:") >= 0)
            {
                //sql语句处理
                IDBQuery thridDbHelper = _dbHelper;

                if (string.IsNullOrEmpty(ii.DBAlias) == false)
                {
                    string strErr = "";
                    thridDbHelper = SqlHelper.GetThridDBHelper(ii.DBAlias, _dbHelper, ref strErr);
                    if (thridDbHelper == null)
                    {
                        MessageBox.Show("录入项 [" + ii.Name + "] 对应的数据源不能创建。", "提示");
                        return null;
                    }
                }

                if (thridDbHelper != null)
                {
                    string sql = "Select (" + ii.DefaultValue.Replace("[SQL:", "").Replace("]", "") + ") as Result from dual";
                    DataTable dtResult = thridDbHelper.ExecuteSQL(sql);

                    if (dtResult == null || dtResult.Rows.Count <= 0) return null;
                   
                    return dtResult.Rows[0]["Result"];
                }
                else
                {
                    MessageBox.Show("尚未初始化数据查询对象。", "提示");
                    return null;
                }
            }
            else if (ii.DefaultValue.IndexOf("[CS:") >= 0)
            {
                //csharp代码处理
                return null;
            }
            else
            {
                return ii.DefaultValue;
            }
        }

        //private void OnKeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        SendKeys.Send("{tab}");
        //    }
        //}

        public Control AddInputControl(InputItem ii, string controlName)
        {
 
            LayoutControlItem lci = null;

            string ctlName = controlName;
            object defaultValue = GetDefaultValue(ii);

          

            switch (ii.ControlType.ToUpper())
            {
                case QueryConstDefine.Cbx:
                    ComboBox cbx = new ComboBox();
                    cbx.Name = ctlName;

                    //cbx.KeyPress += OnKeyPress;

                    //从数据源加载数据
                    DataTable dtData = GetDataForm(ii);
                    if (dtData != null)
                    {

                        if (dtData.Columns.Count > 1)
                        {
                            if (dtData.Columns.IndexOf("数据值") >= 0)
                            {
                                cbx.ValueMember = "数据值";
                            }
                            else
                            {
                                cbx.ValueMember = dtData.Columns[0].ColumnName;
                            }

                            if (dtData.Columns.IndexOf("数据描述") >= 0)
                            {
                                cbx.DisplayMember = "数据描述";
                            }
                            else
                            {
                                cbx.ValueMember = dtData.Columns[1].ColumnName;
                            }

                        }
                        else
                        {
                            cbx.DisplayMember = dtData.Columns[0].ColumnName;
                            cbx.ValueMember = dtData.Columns[0].ColumnName;
                        }

                        cbx.DataSource = dtData; 
                    }

                    lci = lcDemo.Root.AddItem(ctlName, cbx);
                    lci.ShowInCustomizationForm = false;
                    lci.Text = ii.Name;


                    if (defaultValue != null)
                    {
                        //设置默认值
                        int selIndex = cbx.Items.IndexOf(defaultValue);
                        if (selIndex < 0)
                        {
                            selIndex = cbx.FindString(Convert.ToString(defaultValue));
                        }

                        if (selIndex >= 0)
                        {
                            cbx.SelectedIndex = selIndex;
                        }
                        else
                        {                            
                            cbx.Text = ii.DefaultValue;
                        }
                    }
                    else
                    {
                        cbx.SelectedIndex = cbx.Items.Count - 1;
                    }


                    return cbx;
                case QueryConstDefine.Txt:
                    TextBox tb = new TextBox();
                    tb.Name = ctlName;
                    tb.Text = Convert.ToString(defaultValue);//设置默认值

                    //tb.KeyPress += OnKeyPress;

                    lci = lcDemo.Root.AddItem(ctlName, tb);
                    lci.ShowInCustomizationForm = false;
                    lci.Text = ii.Name;

                    return tb;
                case QueryConstDefine.Dtp:
                    DateTimePicker dtp = new DateTimePicker();
                    dtp.Name = ctlName;

                    //dtp.KeyPress += OnKeyPress;

                    try
                    {
                        if (defaultValue != null)
                        {
                            //设置默认值
                            dtp.Value = Convert.ToDateTime(defaultValue);
                        }
                    }
                    catch
                    { }

                    lci = lcDemo.Root.AddItem(ctlName, dtp);
                    lci.ShowInCustomizationForm = false;
                    lci.Text = ii.Name;

                    return dtp;

                default:
                    return null;
            }
        }


        public void BeginLayout()
        {
            lcDemo.Visible = false;
            lcDemo.BeginUpdate();
        }

        public void EndLayout()
        {
            lcDemo.EndUpdate();
            lcDemo.Visible = true;
        }

        /// <summary>
        /// 刷新设计时布局
        /// </summary>
        /// <param name="sqlFormatContext"></param>
        public void LoadSqlDesign(string sqlFormatContext)
        {
            _queryCore.LoadFromString(sqlFormatContext);
            _queryCore.SyncLinkControl();
        }
        

        /// <summary>
        /// 保存为格式串
        /// </summary>
        /// <returns></returns>
        public string SaveSchemeToString()
        {
            Dictionary<string, string> layoutFmt = new Dictionary<string, string>();
            layoutFmt.Add("查询格式", _queryCore.SourceSqlFmt);

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
        public void LoadSchemeFromString(string queryScheme)
        {
            _queryScheme = queryScheme;

            if (string.IsNullOrEmpty(queryScheme))
            {
                ClearLayout();
                return;
            }

            string sqlFormatContext = "";
            string layoutContext = "";

            ParseFromString(queryScheme, out sqlFormatContext, out layoutContext);
            
            LoadSchemeFromString(sqlFormatContext, layoutContext);
        }

        /// <summary>
        /// 载入布局
        /// </summary>
        /// <param name="sqlFormatContext"></param>
        /// <param name="layoutContext"></param>
        private void LoadSchemeFromString(string sqlFormatContext, string layoutContext)
        {

            ClearLayout();

            if (string.IsNullOrEmpty(sqlFormatContext) || string.IsNullOrEmpty(layoutContext)) return;

            _queryCore.LoadFromString(sqlFormatContext);
            _queryCore.SyncLinkControl();

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
        public void ParseFromString(string queryScheme, out string sqlFormatContext, out string layoutContext)
        {
            Dictionary<string, string> layoutFmt = DictionaryJsonHelper.DeserializeStringToDictionary<string, string>(queryScheme);

            sqlFormatContext = layoutFmt["查询格式"];
            layoutContext = layoutFmt["布局格式"]; 
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
                _middleWare = ((DevExpress.XtraLayout.LayoutControl)sender).CustomizationForm as DesignMiddleWare;

                _middleWare.OnSelDesign -= SelDesignControlProcess;
                _middleWare.OnSelDesign += SelDesignControlProcess;

                _middleWare.Visible = false;

                _isDesiging = true;
            }
            catch(Exception ex)
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
            catch(Exception ex)
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

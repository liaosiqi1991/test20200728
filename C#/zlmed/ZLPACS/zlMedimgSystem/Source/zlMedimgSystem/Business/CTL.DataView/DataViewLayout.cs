using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using System.IO; 

namespace zlMedimgSystem.CTL.DataView
{
    internal partial class DataViewLayout : UserControl
    {
        private DesignMiddleWare _middleWare = null;

        private bool _IsSimpleState = false;
        private int _height = 0;
        private bool _isDesiging = false;
        

        public event SelDesignControl OnSelDesign;
        public event QueryParValueEvent OnRequestPar;

        private IDBQuery _thridDbHelper = null;

        //private string _queryScheme = "";


        public DataViewLayout()
        {
            InitializeComponent();

            lcDemo.RegisterUserCustomizationForm(typeof(DesignMiddleWare));
            lcDemo.AllowCustomization = false;


        }


        public IDBQuery DBHelper
        {
            get;set;
        }


        public IDBQuery ThridDBHelper
        {
            get { return _thridDbHelper; }
            set { _thridDbHelper = value; }
        }

        public object QueryPar(string parName)
        {
            //判断是否系统参数
            object parValue = OnRequestPar?.Invoke(parName);

            if (parValue == null && _layoutControls != null)
            {
                //判断是否本地控件录入参数
                foreach(ViewItem vi in _layoutControls)
                {
                    if (vi.InstanceName != parName) continue;

                    string value = "";

                    switch (vi.ControlType)
                    {
                        case ViewControlType.Lab:
                            value = (vi.ReleationInstance as Label).Text;

                            if (string.IsNullOrEmpty(value))
                            {
                                return "";
                            }
                            else
                            {
                                return (value + "-").Split('-')[0];
                            }

                        case ViewControlType.Txt:
                            value = (vi.ReleationInstance as TextBox).Text;

                            if (string.IsNullOrEmpty(value))
                            {
                                return "";
                            }
                            else
                            {
                                return (value + "-").Split('-')[0];
                            }

                        case ViewControlType.Cbx:
                            value = "";
                             
                            object curValue = (vi.ReleationInstance as ComboBox).SelectedValue;
                            if (curValue != null && curValue is string)
                            {
                                value = curValue.ToString();
                            }

                            if (string.IsNullOrEmpty(value))
                            {
                                value = (vi.ReleationInstance as ComboBox).Text;
                            }
                            

                            if (string.IsNullOrEmpty(value))
                            {
                                return "";
                            }
                            else
                            {
                                return (value + "-").Split('-')[0];
                            }

                        case ViewControlType.Dtp:
                            return (vi.ReleationInstance as DateTimePicker).Value;

                        case ViewControlType.Checkbox:
                            return (vi.ReleationInstance as CheckBox).Checked;

                        default:
                            return null;
                    }
                }

            }

            return parValue;
        }

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

        /// <summary>
        /// 清除布局
        /// </summary>
        public void ClearLayout()
        {
            lcDemo.BeginUpdate();
            try
            {
                for (int i = lcDemo.Controls.Count - 1; i >= 0; i--)
                {
                    lcDemo.Controls[i].Dispose();
                }

                lcDemo.Controls.Clear();
                lcDemo.Clear();

                if (_layoutControls != null)
                {
                    _layoutControls.Clear();
                    _layoutControls = null;
                }
            }
            finally
            {
                lcDemo.EndUpdate();
            }
        }

        public ControlCollection Items
        {
            get { return lcDemo.Controls; }
        }
        public Control FindControl(string controlName)
        {
            return lcDemo.GetControlByName(controlName);
        }

        /// <summary>
        /// 移除项目
        /// </summary>
        /// <param name="controlName"></param>
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

        private List<BaseLayoutItem> GetSelectItems(LayoutControl lc)
        {

            List<BaseLayoutItem> bli = new List<BaseLayoutItem>();

            void InitSubSelectItems(LayoutGroup lcg)
            {
                if (lcg.Selected) bli.Add(lcg);

                foreach (BaseLayoutItem li in lcg.Items)
                {
                    if (li.Selected)
                    {
                        bli.Add(li);
                    }


                    if (li as LayoutControlGroup != null)
                    {
                        InitSubSelectItems(li as LayoutGroup);
                    }

                    if (li as TabbedControlGroup != null)
                    {
                        foreach (LayoutGroup lg in (li as TabbedControlGroup).TabPages)
                        {
                            InitSubSelectItems(lg as LayoutGroup);
                        }
                    }
                }
            }

            InitSubSelectItems(lc.Root);

            return bli;
        }

        public void RemoveSelControl()
        {
            //LayoutGroup lg = null;
            //if (lcDemo.Root.SelectedItems.Count <= 0)
            //{

            //}
            //else
            //{
            //    lg = lcDemo.Root;
            //}

            //if (lg == null) return;

            //for (int i = lcDemo.Root.SelectedItems.Count -1; i >=0; i --)
            //{
            //    LayoutControlItem lci = lcDemo.Root.SelectedItems[i] as LayoutControlItem;
            //    if (lci == null) continue;

            //    Control ctlDel = lci.Control;

            //    lcDemo.Root.Remove(lci);
            //    lcDemo.Controls.Remove(ctlDel);
            //}


            //lcDemo.HideSelectedItems();

            List<BaseLayoutItem> selectItems = GetSelectItems(lcDemo);

            if (selectItems.Count <= 0)
            {
                MessageBox.Show("请选择需要删除的项。", "提示");
                return;
            }

            foreach (BaseLayoutItem selItem in selectItems)
            {

                if (selItem as LayoutGroup != null)
                {
                    LayoutGroup delGroup = selItem as LayoutGroup;

                    if (delGroup.Items.Count > 0)
                    {
                        MessageBox.Show("存在子项，不允许进行删除。", "提示");
                        return;
                    }
                }

                if (selItem as TabbedControlGroup != null)
                {
                    foreach (LayoutGroup lg in (selItem as TabbedControlGroup).TabPages)
                    {
                        if (lg.Items.Count > 0)
                        {
                            MessageBox.Show("存在子项，不允许进行删除。", "提示");
                            return;
                        }
                    }
                }
            }


            if (MessageBox.Show("确认删除当前所选项目吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;

            try
            {
                foreach (BaseLayoutItem selItem in selectItems)
                {
                    selItem.ShowInCustomizationForm = false;

                    LayoutControlItem lci = selItem as LayoutControlItem;
                    if (lci == null) continue;

                    Control ctlDel = lci.Control;
                     
                    lcDemo.Controls.Remove(ctlDel); 

                    selItem.Parent.Remove(selItem);
                }

                lcDemo.HideSelectedItems(); 
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private DataTable GetDataForm(ViewItem vi)
        {
            if (string.IsNullOrEmpty(vi.DataFrom)) return null;

            string datafrom = vi.DataFrom;

            //判断是否查询语句
            if (datafrom.ToUpper().IndexOf("SELECT ") >= 0)
            {
                string[] tmp = vi.DataFrom.Split('|');

                string dbAlias = "";
                string query = "";

                if (tmp.Length > 1)
                {
                    dbAlias = tmp[0];
                    query = tmp[1];
                }
                else
                {
                    query = tmp[0];
                }

                //查询语句处理
                if (DBHelper != null)
                {
                    DataTable dtBind = SqlHelper.GetDataSource(query, dbAlias, DBHelper, QueryPar); 

                    DataRow drNull = dtBind.NewRow();

                    if (dtBind.PrimaryKey.Length > 0)
                    {
                        foreach (DataColumn dc in dtBind.PrimaryKey)
                        {
                            if (dc.DataType == typeof(string))
                            {
                                drNull[dc] = "0";
                            }
                            else 
                            {
                                drNull[dc] = 0;
                            }
                        }
                    }

                    dtBind.Rows.Add(drNull);

                    return dtBind;
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

        public void AddEmptyItemElement()
        {
            lcDemo.Root.AddItem(new EmptySpaceItem());
        }

        public void AddTagGroupElement()
        {
            lcDemo.Root.AddTabbedGroup().AddTabPage("Tab1");
        }


        //private void OnKeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        SendKeys.Send("{tab}");
        //    }
        //}


        private void ElementTextChange(object sender, EventArgs e)
        {
            try
            {
                Control ele = sender as Control;
                if (ele == null) return;

                ViewItem vi = ele.Tag as ViewItem;
                if (vi == null) return;

                string instanceName = vi.InstanceName;

                //判断vi是否已经确认没有关联参数配置


                foreach (ViewItem item in _layoutControls)
                {
                    if (item.Equals(vi)) continue;
                    if (string.IsNullOrEmpty(item.DataFrom)) continue;
                    if (item.DataFrom.IndexOf("[" + instanceName + "]") < 0) continue;
                    if (item.ReleationInstance == null) continue;

                    RebindData(item);

                    return;
                }

                //vi.
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex,this);
            }
        }

        private void RebindData(ViewItem vi)
        {
            if (vi.DataFrom.ToUpper().IndexOf("SELECT ") >= 0)
            {
                DataTable dtData = GetDataForm(vi);
                if (dtData != null)
                {
                    switch (vi.ControlType)
                    {
                        case ViewControlType.Cbx:
                            if (vi.ReleationInstance == null) return;
                            (vi.ReleationInstance as ComboBox).DataSource = dtData;
                            break;

                        default:
                            break;
                    }
                }
            }
        }
        //private void comboBox_Enter(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ComboBox cbx = sender as ComboBox;
        //        if (cbx == null) return;


        //        ViewItem vi = cbx.Tag as ViewItem;
        //        if (vi == null) return;

        //        if (string.IsNullOrEmpty(vi.DataFrom)) return;


        //        if (vi.DataFrom.ToUpper().IndexOf("SELECT ") >= 0)
        //        {
        //            string[] tmp = vi.DataFrom.Split('|');

        //            string dbAlias = "";
        //            string query = "";

        //            if (tmp.Length > 1)
        //            {
        //                dbAlias = tmp[0];
        //                query = tmp[1];
        //            }
        //            else
        //            {
        //                query = tmp[0];
        //            }

        //            string pars = SqlHelper.GetSqlPars(query);

        //            if (string.IsNullOrEmpty(pars)) return;

        //            bool hasPar = false;
        //            foreach (ViewItem item in _layoutControls)
        //            {
        //                if (pars.IndexOf(item.InstanceName) >= 0)
        //                {
        //                    hasPar = true;
        //                    break;
        //                }
        //            }

        //            if (hasPar == false) return;

        //            DataTable dtData = GetDataForm(vi);
        //            if (dtData != null)
        //            {
        //                cbx.DataSource = dtData;
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MsgBox.ShowException(ex, this);
        //    }
        //}

        public Control AddInputControl(ViewItem vi)
        {

            LayoutControlItem lci = null;

            string ctlName = vi.InstanceName; //controlName;

            switch (vi.ControlType.ToUpper())
            {
                case ViewControlType.Lab:
                    Label lab = new Label();
                    lab.Name = ctlName;
                    lab.Text = vi.DefaultValue;
                    lab.Tag = vi;                    

                    lci = lcDemo.Root.AddItem(ctlName, lab);
                    lci.ShowInCustomizationForm = false;
                    lci.Text = (vi.Caption == "") ? "标签" : vi.Caption;

                    return lab;

                case ViewControlType.Cbx:
                    #region combobox处理
                    ComboBox cbx = new ComboBox();
                    cbx.Name = ctlName;
                    cbx.Tag = vi;

                    //从数据源加载数据
                    DataTable dtData = GetDataForm(vi);
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
                                cbx.DisplayMember = dtData.Columns[1].ColumnName;
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
                    lci.Text = (vi.Caption == "") ? "下拉框" : vi.Caption;



                    if (string.IsNullOrEmpty(vi.DefaultValue) == false)
                    {
                        //设置默认值
                        int selIndex = cbx.Items.IndexOf(vi.DefaultValue);
                        if (selIndex < 0)
                        {
                            selIndex = cbx.FindString(vi.DefaultValue);
                        }

                        if (selIndex >= 0)
                        {
                            cbx.SelectedIndex = selIndex;
                        }
                        else
                        {
                            cbx.Text = vi.DefaultValue;
                        }
                    }
                    else
                    {
                        cbx.SelectedIndex = cbx.Items.Count - 1;
                    }

                    if (vi.ReadOnly) cbx.DropDownStyle = ComboBoxStyle.DropDownList;

                    cbx.TextChanged += ElementTextChange;
                    cbx.SelectedIndexChanged += ElementTextChange;
                    //cbx.Enter += comboBox_Enter;
                    //cbx.KeyPress += OnKeyPress;

                    return cbx;
                #endregion

                case ViewControlType.Txt:
                    #region textbox处理
                    TextBox tb = new TextBox();
                    tb.Name = ctlName;
                    tb.Tag = vi;
                    tb.Text = vi.DefaultValue;//设置默认值

                    lci = lcDemo.Root.AddItem(ctlName, tb);
                    lci.ShowInCustomizationForm = false;
                    lci.Text = (vi.Caption == "") ? "文本框" : vi.Caption;

                    tb.Enabled = !vi.ReadOnly;

                    tb.TextChanged += ElementTextChange;
                    //tb.KeyPress += OnKeyPress;

                    return tb;
                #endregion

                case ViewControlType.Dtp:
                    #region datetimepicker处理
                    DateTimePicker dtp = new DateTimePicker();
                    dtp.Name = ctlName;
                    dtp.Tag = vi;

                    try
                    {
                        if (string.IsNullOrEmpty(vi.DefaultValue) == false)
                        {
                            //设置默认值
                            dtp.Value = Convert.ToDateTime(vi.DefaultValue);
                        }
                    }
                    catch
                    { }

                    lci = lcDemo.Root.AddItem(ctlName, dtp);
                    lci.ShowInCustomizationForm = false;
                    lci.Text = (vi.Caption == "") ? "日期框" : vi.Caption;

                    dtp.Enabled = !vi.ReadOnly;

                    dtp.ValueChanged += ElementTextChange;
                    //dtp.KeyPress += OnKeyPress;

                    return dtp;
                #endregion

                case ViewControlType.Checkbox:
                    #region checkbox处理
                    CheckBox cb = new CheckBox();
                    cb.Name = ctlName;
                    cb.Tag = vi;
                    cb.Text = vi.Caption;

                    try
                    {
                        if (string.IsNullOrEmpty(vi.DefaultValue) == false)
                        {
                            //设置默认值
                            cb.Checked = Convert.ToBoolean(vi.DefaultValue);
                        }
                    }
                    catch
                    { }
                   
                    lci = lcDemo.Root.AddItem(ctlName, cb);
                    lci.ShowInCustomizationForm = false;
                    lci.Text = (vi.Caption == "") ? "复选框" : vi.Caption;

                    cb.Enabled = !vi.ReadOnly;

                    cb.CheckedChanged += ElementTextChange;
                    //cb.KeyPress += OnKeyPress;

                    return cb;
                #endregion

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
        /// 保存为格式串
        /// </summary>
        /// <returns></returns>
        public void  GetLayout(out List<ViewItem> viewItems, out string layoutFormat)
        {
            viewItems = new List<ViewItem>();
            foreach (Control ctl in lcDemo.Controls)
            {
                if (ctl.Tag == null) continue;
                ViewItem vi = ctl.Tag as ViewItem;

                if (vi == null) continue;
                viewItems.Add(vi);

            }

            using (MemoryStream ms = new MemoryStream())
            {
                lcDemo.SaveLayoutToStream(ms);

                ms.Position = 0;

                StreamReader sr = new StreamReader(ms);

                layoutFormat = sr.ReadToEnd();
            }
        }

        private List<ViewItem> _layoutControls = null;

        public List<ViewItem> LayoutControls
        {
            get { return _layoutControls; }
        }

        /// <summary>
        /// 载入布局
        /// </summary>
        /// <param name="sqlFormatContext"></param>
        /// <param name="layoutContext"></param>
        public void LoadLayout(List<ViewItem> viewItems, string layoutFormat)
        {

            ClearLayout();
            
            if (string.IsNullOrEmpty(layoutFormat)) return;

            _layoutControls = new List<ViewItem>();

            lcDemo.BeginUpdate();
            try
            {

                foreach (ViewItem vi in viewItems)
                {

                    Control item = AddInputControl(vi);

                    ViewItem viInstance = vi.Clone();
                    viInstance.ReleationInstance = item;

                    _layoutControls.Add(viInstance);
                }

                using (MemoryStream ms = new MemoryStream())
                {

                    StreamWriter sw = new StreamWriter(ms);

                    sw.Write(layoutFormat);

                    sw.Flush();

                    ms.Position = 0;

                    lcDemo.RestoreLayoutFromStream(ms);
                }

                foreach(ViewItem vi in _layoutControls)
                {
                    if (vi.ReleationInstance == null) continue;

                    LayoutControlItem lci = lcDemo.GetItemByControl(vi.ReleationInstance);

                    if (lci == null) continue;

                    vi.ReleationInstance.Font = lci.AppearanceItemCaption.Font;
                    vi.ReleationInstance.ForeColor = lci.AppearanceItemCaption.ForeColor;
                    vi.ReleationInstance.BackColor = lci.AppearanceItemCaption.BackColor;
                }
            }
            finally
            {
                lcDemo.EndUpdate();
            }
        }

        private Dictionary<string, object> _hideDataBind = null;

        public Dictionary<string, object> HideBindDatas
        {
            get { return _hideDataBind; }
        }

        /// <summary>
        /// 绑定数据显示
        /// </summary>
        /// <param name="dtBind"></param>
        public void BindDataView(IDBQuery sysDb, string dataFrom, string dbSourceAlias)
        {
            string sqlParNames = SqlHelper.GetSqlPars(dataFrom);

            List<SqlParamInfo> sqlParValues = new List<SqlParamInfo>();

            foreach (string curPar in sqlParNames.Split(','))
            {
                object parValue = QueryPar(curPar);

                if (parValue != null)
                {
                    if (parValue is DateTime)
                    {
                        sqlParValues.Add(new SqlParamInfo(curPar, DbType.DateTime, parValue));
                    }
                    else if (parValue is int)
                    {
                        sqlParValues.Add(new SqlParamInfo(curPar, DbType.Int64, parValue));
                    }
                    else if (parValue is double)
                    {
                        sqlParValues.Add(new SqlParamInfo(curPar, DbType.Double, parValue));
                    }
                    else if (parValue is string)
                    {
                        sqlParValues.Add(new SqlParamInfo(curPar, DbType.String, parValue));
                    }
                    else
                    {
                        sqlParValues.Add(new SqlParamInfo(curPar, DbType.String, parValue));
                    }
                }
                else
                {
                    sqlParValues.Add(new SqlParamInfo(curPar, DbType.String, null));
                }
            }


            DataTable dtBind = SqlHelper.GetDataSource(dataFrom, dbSourceAlias, sysDb, sqlParValues);
           
            foreach(Control ctl in lcDemo.Controls)
            {
                if (ctl.Tag == null) continue;

                ViewItem vi = ctl.Tag as ViewItem;

                string bindData = "";
                if (dtBind != null && dtBind.Rows.Count > 0 && string.IsNullOrEmpty(vi.BindDataName) == false)
                {
                    if (dtBind.Columns.Contains(vi.BindDataName))
                    {
                        bindData = dtBind.Rows[0][vi.BindDataName].ToString();
                    }
                    else
                    {
                        bindData = Convert.ToString(QueryPar(vi.BindDataName));
                    }
                }

                switch(vi.ControlType)
                {
                    case ViewControlType.Lab:
                        (ctl as Label).Text = bindData;
                        break;

                    case ViewControlType.Txt:
                        (ctl as TextBox).Text = bindData;
                        break;

                    case ViewControlType.Cbx:
                        (ctl as ComboBox).Text = bindData;
                        break;

                    case ViewControlType.Dtp:
                        (ctl as DateTimePicker).Value = (bindData == "")?default(DateTime):Convert.ToDateTime(bindData);
                        break;

                    case ViewControlType.Checkbox:
                        (ctl as CheckBox).Checked = (bindData == "") ? false : Convert.ToBoolean(bindData);
                        break;

                    default:
                        break;
                }
            }

            if (lcDemo.Root != null)
            {
                if (_hideDataBind == null)
                {
                    _hideDataBind = new Dictionary<string, object>();
                }

                _hideDataBind.Clear();

                string[] dbBindInfos = (lcDemo.Root.Text + ",").Split(',');

                foreach(string dbBindInfo in dbBindInfos)
                {
                    if (string.IsNullOrEmpty(dbBindInfo)) continue;

                    object parValue = QueryPar(dbBindInfo);

                    if (parValue == null)
                    {
                        if (dtBind.Rows.Count > 0 && dtBind.Columns.Contains(dbBindInfo))
                        {
                            parValue = dtBind.Rows[0][dbBindInfo].ToString();
                        }
                    }

                    _hideDataBind.Add(dbBindInfo, parValue);

                }
                
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
                _middleWare = ((DevExpress.XtraLayout.LayoutControl)sender).CustomizationForm as DesignMiddleWare;

                _middleWare.OnSelDesign -= SelDesignControlProcess;
                _middleWare.OnSelDesign += SelDesignControlProcess;

                _middleWare.Visible = false;

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
                //this.Height = lcDemo.Height;
            }
            catch
            {

            }
        }


    }
}

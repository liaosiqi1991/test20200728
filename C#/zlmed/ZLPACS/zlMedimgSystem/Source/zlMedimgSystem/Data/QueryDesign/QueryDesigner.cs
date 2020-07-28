using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using DevExpress.XtraLayout;
using zlMedimgSystem.Layout;

namespace zlMedimgSystem.QueryDesign
{
    public partial class QueryDesigner : UserControl
    {
        private IDBQuery _dbHelper = null;
        //系统参数列表
        private List<string> _sysParList = null;
        public QueryDesigner()
        {
            InitializeComponent();

            _sysParList = new List<string>();
        }

        public IDBQuery DBHelper
        {
            get { return _dbHelper; }
            set
            {
                _dbHelper = value;
                qcReview.DBHelper = value;
            }
        }
        public List<string> SysParList
        {
            get { return _sysParList; }
            set { _sysParList = value; }
        }

        /// <summary>
        /// 设计状态
        /// </summary>
        public bool DesignState
        {
            get { return qcReview.IsDesignModel; }
            set
            {
                if (value)
                {
                    timer1.Enabled = true;
                }
                else
                {
                    qcReview.IsDesignModel = value;
                    pgDesign.SelectedObject = null;
                }

            }
        }

        /// <summary>
        /// 插入条件项
        /// </summary>
        public void InsertWhereItem()
        {
            WhereItem wi = null;
            using (frmQueryWhere whereCfg = new frmQueryWhere())
            {
                wi = whereCfg.ShowWhereItem(_dbHelper, _sysParList, "", this);
            }

            if (wi == null) return;
            if (string.IsNullOrEmpty(wi.SourceFmt)) return;

            rtbSql.SelectedText = wi.SourceFmt;

            qcReview.LoadSqlDesign(rtbSql.Text);
            rtbPreview.Text = qcReview.Query.TestSql();
        }

        /// <summary>
        /// 刷新布局
        /// </summary>
        public void RefreshLayout()
        {
            qcReview.LoadSqlDesign(rtbSql.Text);
            rtbPreview.Text = qcReview.Query.TestSql();
        }

        /// <summary>
        /// 保存为格式字符串
        /// </summary>
        /// <returns></returns>
        public string SaveToString()
        {
            RefreshLayout();
                    
            return qcReview.SaveSchemeToString(); 
        }

        /// <summary>
        /// 从格式字符串载入
        /// </summary>
        public void LoadFromString(string queryScheme)
        {
            qcReview.LoadSchemeFromString(queryScheme);

            rtbSql.Text = qcReview.Query.SourceSqlFmt;
            rtbPreview.Text = qcReview.Query.TestSql();
        }

        /// <summary>
        /// 测试查询
        /// </summary>
        /// <param name="dbHelper"></param>
        /// <returns></returns>
        public bool TestQuery(IDBQuery dbHelper)
        {
            string sql = qcReview.Query.TestSql();

            dbHelper.ExecuteSQL(sql);

            return true;
        }

        /// <summary>
        /// 显示查询
        /// </summary>
        /// <param name="dbHelper"></param>
        public void ShowQuery(IDBQuery dbHelper)
        {
            string queryScheme = SaveToString();

            string sql = "";
            Dictionary<string, object> pars = null;

            if (qcReview.Query.GetInputCount() <= 0)
            {
                qcReview.Query.CreateQuerySql(out sql, out pars);
            }
            else
            {
                using (frmQueryFilter qf = new frmQueryFilter())
                {
                    qf.ShowQueryFilter(this, dbHelper,  queryScheme, out sql, out pars);
                }
            }

            //显示数据展现窗口
            if (dbHelper == null)
            {
                MessageBox.Show("数据库未链接，不能执行如下查询:" + System.Environment.NewLine + sql, "提示");
                return;
            }

            if (string.IsNullOrEmpty(sql))
            {
                MessageBox.Show("未获取到有效的查询语句。", "提示");
                return;
            }

            using (DataTable dtResult = dbHelper.ExecuteSQL(sql, pars))
            using (frmQueryResult qr = new frmQueryResult())
            {
                qr.ShowResult(this, dtResult);
            }
        }

        private void rtbSql_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int mouseIndex = rtbSql.SelectionStart;


                string tmp = rtbSql.Text.Substring(0, mouseIndex);
                int indexLeftStart = tmp.LastIndexOf("<wi=");
                int indexLeftEnd = tmp.IndexOf("/wi>", indexLeftStart + 1);

                int leftLength = tmp.Length;


                tmp = rtbSql.Text.Substring(mouseIndex);
                int indexRightStart = tmp.IndexOf("<wi=");
                int indexRightEnd = tmp.IndexOf("/wi>");

                if (indexRightStart <= 0) indexRightStart = 99999999;

                if (indexLeftStart >= 0 && indexLeftStart > indexLeftEnd && indexRightEnd >= 0 && indexRightEnd < indexRightStart)
                {
                    rtbSql.SelectionStart = indexLeftStart;
                    rtbSql.SelectionLength = leftLength + indexRightEnd - indexLeftStart + 4;
                }
                else
                {
                    return;
                }

                string oldFmt = rtbSql.SelectedText;

                if (string.IsNullOrEmpty(oldFmt)) return;

                frmQueryWhere wi = new frmQueryWhere();

                WhereItem result = wi.ShowWhereItem(_dbHelper, _sysParList, oldFmt, this);

                if (result == null) return;

                string whereItemFmt = result.SaveWhereToString();

                if (string.IsNullOrEmpty(whereItemFmt)) return;

                rtbSql.SelectedText = whereItemFmt; // rtbSql.Text.Replace(oldFmt, result);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void qcReview_OnSelDesign(object selControl)
        {
            try
            {
                SelDesignControlProcess(selControl);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void SelDesignControlProcess(object selControl)
        {

            if (selControl is LayoutControlItem)
            {
                pgDesign.SelectedObject = new LayoutControlItemProWrapper(selControl as LayoutControlItem);
            }
            else if (selControl is LayoutControlGroup)
            {
                pgDesign.SelectedObject = new LayoutControlGroupProWrapper(selControl as LayoutControlGroup);
            }
            else if (selControl is TabbedControlGroup)
            {
                pgDesign.SelectedObject = new TabbedControlGroupProWrapper(selControl as TabbedControlGroup);
            }
            else
            {
                pgDesign.SelectedObject = selControl;
            }

            //pgDesign.ExpandAllGridItems();
        }

        private void QueryDesigner_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;

                qcReview.IsDesignModel = true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

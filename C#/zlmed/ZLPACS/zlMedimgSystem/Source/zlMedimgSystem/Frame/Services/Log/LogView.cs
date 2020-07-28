using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace zlMedimgSystem.Services
{
    public partial class LogView : Form
    {
        private const string WEB_ADDRS = "http://www.zlsoft.com";
        private const int PAGE_RECORD_COUNT = 500;    //每页记录数量

        private string logFile;
        DataTable dtLog = null;
        
        int pageCount = 0;              //数据页数
        int curPageIndex = 0;           //当前页索引

        public LogView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示日志窗口
        /// </summary>
        /// <param name="logFile"></param>
        public void ShowLogWindow(string file, IWin32Window owner)
        {
            logFile = file;

            LoadLogData(file);

            this.ShowDialog(owner);
        }

        private void DisposeViewData()
        {
            if (dgvLog.DataSource != null)
            {
                ((DataTable)((BindingSource)dgvLog.DataSource).DataSource).Clear();
                ((DataTable)((BindingSource)dgvLog.DataSource).DataSource).Dispose();

                ((BindingSource)dgvLog.DataSource).Dispose();

                dgvLog.DataSource = null;
            }

            rtbDescription.Text = "";
            rtbSource.Text = "";
        }

        /// <summary>
        /// 载入日志数据
        /// </summary>
        /// <param name="file"></param>
        private void LoadLogData(string file)
        {
            //释放之前的日志对象
            DisposeViewData();

            //判断文件是否存在
            if (System.IO.File.Exists(file) != true)
            {
                dgvLog.Refresh();
                return;
            }

            //清除已经存在的数据
            if (dtLog != null)
            {
                dtLog.Clear();
                dtLog.Dispose();
            }

            try
            {
                dtLog = Logger.ReadLogFileToDataTable(file);
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                dtLog.ReadXml(file);
            }

            InitPageInf(dtLog);
            LoadPageData(1);

            //配置列表样式
            ConfigGridViewStyle(tsmuBigFont.Checked);

            if (dgvLog.RowCount >= 1)
            {
                dgvLog.Rows[0].Selected = true;
                DoSelectionChanged(null, null);
            }

            //GC.Collect();
        }

        /// <summary>
        /// 初始化分页信息
        /// </summary>
        /// <param name="data"></param>
        private void InitPageInf(DataTable data)
        {
            int rowCount = data.Rows.Count ;

            pageCount = ((rowCount % PAGE_RECORD_COUNT) == 0) ? rowCount / PAGE_RECORD_COUNT : rowCount / PAGE_RECORD_COUNT + 1;
            curPageIndex = 1;

            tsTxtCurPage.Text = curPageIndex.ToString();
            tsLabPageInfo.Text = "/" + pageCount.ToString();
        }

        /// <summary>
        /// 载入分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        private void LoadPageData(int pageIndex)
        {
            if (pageIndex <= 0 || pageIndex > pageCount) return;

            DataTable dtPageTemp = dtLog.Clone();

            for (int i = (pageIndex - 1) * PAGE_RECORD_COUNT; i < pageIndex * PAGE_RECORD_COUNT; i++)
            {
                if (i >= dtLog.Rows.Count) break;
                dtPageTemp.ImportRow(dtLog.Rows[i]);
            }

            dtPageTemp.DefaultView.RowFilter = GetFilterStr();

            BindingSource bs = new BindingSource();
            bs.DataSource = dtPageTemp;

            bdnPageInfo.BindingSource = bs;
            dgvLog.DataSource = bs;         

            curPageIndex = pageIndex;

            if (tsTxtCurPage.Text != curPageIndex.ToString())
            {
                //避免触发tsTxtCurPage控件的changed事件，而造成循环调用
                tsTxtCurPage.Text = curPageIndex.ToString();
            }

            tsLabPageInfo.Text ="/" + pageCount.ToString();
        }

        /// <summary>
        /// 配置GridView显示样式
        /// </summary>
        private void ConfigGridViewStyle(bool isBigFont)
        {
            try
            {
                int baseNum = isBigFont ? 2 : 1;

                dgvLog.Columns[0].Width = 55 * baseNum;
                dgvLog.Columns[3].Width = 55;
                dgvLog.Columns[4].Width = 65 * baseNum;
                dgvLog.Columns[5].Width = 90 * baseNum;
                //dgvLog.Columns[6].Width = 150 * baseNum;
                //dgvLog.Columns[7].Width = 200 * baseNum;

                dgvLog.Columns[6].Visible = false;
                dgvLog.Columns[7].Visible = false;

                //dgvLog.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss.fff";
            }
            catch { }
        }

        private void LogView_Load(object sender, EventArgs e)
        {
            InitEvent();

            SetFont();
        }

        /// <summary>
        /// 设置窗体字体
        /// </summary>
        private void SetFont()
        {
            try
            {
                this.Font = new Font("微软雅黑", 9);
            }
            catch { }
        }

        /// <summary>
        /// 初始化相关事件
        /// </summary>
        private void InitEvent()
        {
            this.FormClosed += DoFormClosed;

            dgvLog.SelectionChanged += DoSelectionChanged;
            dgvLog.RowPostPaint += DoRowPostPaint;

            tsmuSmallFont.Click += DoSmallFont;
            tsmuBigFont.Click += DoBigFont;
            tsmuRefresh.Click += DoRefresh;
            tsmuOpen.Click += DoOpenFile;
            tsmuSaveAsFullXml.Click += DoSaveAsFullXml;
            tsmuError.Click += DoFilterType;
            tsmuWaring.Click += DoFilterType;
            tsmuNormal.Click += DoFilterType;
            tsmuDebug.Click += DoFilterType;
            tsmuQuit.Click += DoQuit;
            tsmuOpenWeb.Click += DoOpenWeb;
            tsmuAbout.Click += DoShowAbout;

            bdnPageInfo.ItemClicked += DoItemClicked;
            tsTxtCurPage.TextChanged += DoCurPageChanged;
        }

        #region 执行事件处理

        private void DoSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvLog.RowCount <= 0) return;

                if (dgvLog.SelectedRows.Count <= 0)
                {
                    rtbDescription.Text = "";
                    rtbSource.Text = "";
                    return;
                }

                rtbDescription.Text = dgvLog.SelectedRows[0].Cells["描述"].Value.ToString();
                rtbSource.Text = dgvLog.SelectedRows[0].Cells["来源"].Value.ToString();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void DoRowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                if (e.RowIndex % 2 == 1)
                {
                    dgvLog.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 237, 236, 255);
                }

                if (dgvLog.Rows[e.RowIndex].Cells["类型"].Value.ToString() == "错误")
                {
                    dgvLog.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 小字体
        /// </summary>
        private void DoSmallFont(object sender, EventArgs e)
        {
            try
            {
                this.Font = new Font(this.Font.FontFamily , 9);
                tsmuBigFont.Checked = false;

                ConfigGridViewStyle(false);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 大字体
        /// </summary>
        private void DoBigFont(object sender, EventArgs e)
        {
            try
            {
                this.Font = new Font(this.Font.FontFamily, 11);
                tsmuSmallFont.Checked = false;

                ConfigGridViewStyle(true);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoRefresh(object sender, EventArgs e)
        {
            try
            {
                LoadLogData(logFile);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoOpenFile(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog fileDialog = new OpenFileDialog())
                {
                    fileDialog.Filter = "(*.txt)|*.txt|(*.xml)|*.xml|*.*|*.*";
                    fileDialog.DefaultExt = "*.txt";
                    fileDialog.Title = "打开日志";

                    if (fileDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                    {
                        return;
                    }

                    if (File.Exists(fileDialog.FileName) != true) return;

                    logFile = fileDialog.FileName;                  
                }

                LoadLogData(logFile);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 获取过滤串
        /// </summary>
        /// <returns></returns>
        private string GetFilterStr()
        {
            string filter = "";

            if (tsmuError.Checked == true) filter = "类型='错误'";

            if (tsmuWaring.Checked == true)
            {
                if (string.IsNullOrEmpty(filter) != true) filter = filter + " or ";
                filter = filter + "类型='警告'";
            }

            if (tsmuNormal.Checked == true)
            {
                if (string.IsNullOrEmpty(filter) != true) filter = filter + " or ";
                filter = filter + "类型='常规'";
            }

            if (tsmuDebug.Checked == true)
            {
                if (string.IsNullOrEmpty(filter) != true) filter = filter + " or ";
                filter = filter + "类型='调试'";
            }

            if (tsmuNormal.Checked & tsmuWaring.Checked & tsmuError.Checked & tsmuDebug.Checked) filter = "";

            return filter;
        }

        /// <summary>
        /// 根据日志类型过滤数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoFilterType(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)((BindingSource)dgvLog.DataSource).DataSource;
                dt.DefaultView.RowFilter = GetFilterStr();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 退出窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoQuit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoSaveAsFullXml(object sender, EventArgs e)
        {
            try
            {
                string saveFile = "";

                using (SaveFileDialog fileDialog = new SaveFileDialog())
                {
                    fileDialog.Filter = "(*.xml)|*.xml|(*.*)|*.*";
                    fileDialog.DefaultExt = "*.xml";
                    fileDialog.Title = "另存为";

                    if (fileDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                    {
                        return;
                    }
                    saveFile = fileDialog.FileName;
                }

                dtLog.WriteXml(saveFile, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }            
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoFormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                DisposeViewData();

                //释放加载的日志数据
                if (dtLog != null)
                {
                    dtLog.Clear();
                    dtLog.Dispose();
                }
            }
            catch { }
        }

        /// <summary>
        /// 分页处理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                switch (e.ClickedItem.Name)
                {
                    case "tsbutPerv":   //上一页
                        if (curPageIndex > 1)
                        {
                            curPageIndex = curPageIndex - 1;
                            LoadPageData(curPageIndex);
                        }
                        break;
                    case "tsbutNext":   //下一页
                        if (curPageIndex < pageCount)
                        {
                            curPageIndex = curPageIndex + 1;
                            LoadPageData(curPageIndex);
                        }
                        break;
                    case "tsbutFirstRecord":    //第一条记录
                        curPageIndex = 1;
                        LoadPageData(curPageIndex);
                        break;
                    case "tsbutEndRecord":      //最后一条记录
                        curPageIndex = pageCount;
                        LoadPageData(curPageIndex);

                        dgvLog.ClearSelection();
                        dgvLog.Rows[dgvLog.Rows.Count - 1].Selected = true;
                        dgvLog.CurrentCell = dgvLog.Rows[dgvLog.Rows.Count - 1].Cells[0];

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 打开公司网站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoOpenWeb(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(WEB_ADDRS);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void DoCurPageChanged(object sender, EventArgs e)
        {
            try
            {               
                int pageIndex = Convert.ToInt16(tsTxtCurPage.Text);
                LoadPageData(pageIndex);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 显示About窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoShowAbout(object sender, EventArgs e)
        {
            //try
            //{
            //    using (LogAbout about = new LogAbout())
            //    {
            //        about.ShowDialog(this);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.ShowException(ex, this);
            //}
        }

        #endregion

    }
}

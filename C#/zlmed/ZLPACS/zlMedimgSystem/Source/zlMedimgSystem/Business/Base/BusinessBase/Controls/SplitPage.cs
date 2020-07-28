using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BusinessBase.Controls
{
    public partial class SplitPage : UserControl
    {
        public delegate void EventPageChanged(int curPageIndex, List<object> range);

        //当前页数
        private int _curPageIndex = 0;
        //总页数
        private int _pageCount = 0;

        //每页记录数
        private int _recordCount = 0;
        /// <summary>
        /// 总数
        /// </summary>
        private int _totalCount = 0;

        private List<object> _bindListData = null;


        private bool _isIniting = false;


        public event EventPageChanged OnPageChanged;

        public int PageIndex
        {
            get { return _curPageIndex; }
        }

        public int PageCount
        {
            get { return _pageCount; }
        }

        public int RecordCount
        {
            get { return _recordCount; }
        }

        public int TotalCount
        {
            get { return _totalCount; }
        }

        public SplitPage()
        {
            InitializeComponent();
        }

        public void BindList<T>(List<T> bindData, int recordCount)
        {
            if (bindData == null)
            {
                Init(0, 0);
                return;
            }

            _bindListData = bindData.ConvertAll(S => (object)S);

            Init(bindData.Count, recordCount);
        }

        public void ChangePage(int pageNum)
        {
            if (pageNum <= 0) return;
            if (pageNum > _pageCount) return;

            tsCbxPageNum.SelectedIndex = pageNum - 1;
        }

        public void BindDataTable(DataTable dtBindTable, int recordCount)
        {
            if (dtBindTable == null)
            {
                Init(0, 0);
                return;
            }

            if (_bindListData == null) _bindListData = new List<object>();

            _bindListData.AddRange(dtBindTable.AsEnumerable() as IEnumerable<DataRow>);

            Init(dtBindTable.Rows.Count, recordCount);
        }

        public void BindNull(int totalCount, int recordCount)
        {
            Init(totalCount, recordCount);
        }

        public void UpdatePage(int totalCount)
        {
            _isIniting = true;
            try
            {
                _totalCount = totalCount; 

                _curPageIndex = 0;

                _pageCount = _totalCount / _recordCount;

                //如果不能整除，则需要页数加一
                if (_totalCount % _recordCount != 0) _pageCount = _pageCount + 1;

                tsCbxPageNum.Items.Clear();
                for (int i = 1; i <= _pageCount; i++)
                {
                    tsCbxPageNum.Items.Add(i.ToString() + "/" + _pageCount.ToString());
                }
            }
            finally
            {
                _isIniting = false;
            }
        }

        private void Init(int totalCount, int recordCount)
        {
            _isIniting = true;
            try
            {
                _totalCount = totalCount;
                _recordCount = recordCount;

                _curPageIndex = 0;

                _pageCount = _totalCount / recordCount;

                //如果不能整除，则需要页数加一
                if (_totalCount % recordCount != 0) _pageCount = _pageCount + 1;

                tsCbxPageNum.Items.Clear();
                for (int i = 1; i <= _pageCount; i++)
                {
                    tsCbxPageNum.Items.Add(i.ToString() + "/" + _pageCount.ToString());
                }
            }
            finally
            {
                _isIniting = false;
            }

            tsCbxPageNum.SelectedIndex = 0;
        }

        private void tsCbxPageNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isIniting) return;

                _curPageIndex = tsCbxPageNum.SelectedIndex + 1;

                List<object> rangeList = GetPageData(_curPageIndex);

                OnPageChanged?.Invoke(_curPageIndex, rangeList);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<object> GetPageData(int pageIndex)
        {
            if (_bindListData == null) return null;

            if (pageIndex * _recordCount < _totalCount)
            {
                return _bindListData.GetRange((pageIndex - 1) * _recordCount, _recordCount);
            }
            else
            {
                return _bindListData.GetRange((pageIndex - 1) * _recordCount, _totalCount - (pageIndex - 1) * _recordCount);
            }
        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            try
            {
                if (_curPageIndex <= 1) return;

                tsCbxPageNum.SelectedIndex = tsCbxPageNum.SelectedIndex - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (_curPageIndex >= _pageCount) return;

                tsCbxPageNum.SelectedIndex = tsCbxPageNum.SelectedIndex + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;
using zlMedimgSystem.DataModel;
using System.Windows.Forms;
using System.Data;

namespace zlMedimgSystem.BusinessBase
{
    public class ComboxEx
    {
        private IDBQuery _dbHelper = null;
        public ComboxEx() { }
        public ComboxEx(IDBQuery dbHelper)
        {
            _dbHelper = dbHelper;
        }
        /// <summary>
        /// 设置下拉框项目为字典项目
        /// </summary>
        /// <param name="cbx">下拉框控件</param>
        /// <param name="sDictionary">字典名称</param>
        /// <param name="bNull">是否插入空项目</param>
        public void BindDictionary(ComboBox cbx, string sDictionary, bool bNull)
        {
            DictManageModel _dictManageModel = new DictManageModel(_dbHelper);
            JDictionary dict = _dictManageModel.GetDictionary(sDictionary);
            string sDefault = "";//加载后设置缺省项目
            //绑定前，先清空
            cbx.Items.Clear();

            if (bNull) cbx.Items.Add("");

            //没有字典内容，添加固定项目
            if (dict == null)
            {
                if (sDictionary == "性别")
                {
                    cbx.Items.Add("男");
                    cbx.Items.Add("女");
                    cbx.Items.Add("未知");
                    cbx.Items.Add("未明");
                    cbx.Items.Add("女变男");
                    cbx.Items.Add("男变女");
                }
            }
            else
            {
                //性别下拉框要显示一个空选项，选择循环加入，不使用绑定
                foreach (JDictionaryItem item in dict.项目内容)
                {
                    cbx.Items.Add(item.项目名称);

                    if (item.缺省 == true) sDefault = item.项目名称;
                }
                cbx.Text = sDefault;
            }
        }
        /// <summary>
        /// 绑定影像类别
        /// </summary>
        /// <param name="cbx">控件名称</param>
        public void BindImageKing(ComboBox cbx)
        {
            DeviceKindModel _deviceKindModel = new DeviceKindModel(_dbHelper);
            DataTable dtKind = _deviceKindModel.GetAllDeviceKind();

            cbx.DisplayMember = "影像类别";
            cbx.DataSource = dtKind;

            if (cbx.Items.Count > 0) cbx.SelectedIndex = 0;
           
        }

    }
}

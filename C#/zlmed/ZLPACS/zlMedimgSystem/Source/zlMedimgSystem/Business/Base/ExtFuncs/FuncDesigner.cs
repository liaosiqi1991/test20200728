using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.ExtFuncs
{
    public partial class FuncDesigner : UserControl
    {

        private bool _isLoadingDetail = false;
        public FuncDesigner()
        {
            InitializeComponent();
        }


        public bool DesignState
        {
            get { return funcControl1.DesignState; }
            set
            {
                funcControl1.DesignState = value;
            }
        }


        private void tsbText_Click(object sender, EventArgs e)
        {
            
        }



        private void LocateRow(string name)
        {

            foreach (DataGridViewRow dgr in dataGridView1.Rows)
            {
                if (dgr.Cells["Name"].Value.ToString().Equals(name))
                {
                    dgr.Selected = true;
                    return;
                }
            }
        }

        private bool CheckNameExists(string name)
        {

            foreach(DataGridViewRow dgr in dataGridView1.Rows)
            {
                if (dgr.Cells["Name"].Value.ToString().Equals(name)) return true;
            }

            return false;
        }

        private void BindInputData()
        {
            dataGridView1.DataSource = null;

            if (funcControl1.Inputs.Count <= 0) return;

            List<InputItem> inputData = funcControl1.Inputs.Values.ToList();
            
            dataGridView1.DataSource = inputData;
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("请选择需要删除的项目。");
                    return;
                }

                string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

                funcControl1.RemoveControl(name);

                funcControl1.Inputs.Remove(name);

                BindInputData();
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count <= 0)
                {
                    MessageBox.Show("请选择需要修改的项目。");
                    return;
                }

                string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

                InputItem iiUpdate = funcControl1.Inputs[name];

                if (iiUpdate == null)
                {
                    MessageBox.Show("未找到对应项目配置信息。");
                    return;
                }

                frmFuncInput ffi = new frmFuncInput();

                //ffi.OnCheckNameExists -= CheckNameExists;
                //ffi.OnCheckNameExists += CheckNameExists;

                iiUpdate = ffi.ShowInput(this, iiUpdate);

                if (iiUpdate == null) return;

                //更新明细信息
                LoadInputDetail(iiUpdate.Name);
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void LoadInputDetail(string name)
        {
            try
            {
                _isLoadingDetail = true;

                txtDefaultValue.Text = "";
                rtbDataSource.Text = "";
                chkIsStorage.Checked = true;

                InputItem iiDetail = funcControl1.Inputs[name];

                if (iiDetail == null) return;

                txtDefaultValue.Text = iiDetail.DefaultValue;
                rtbDataSource.Text = iiDetail.DataFrom;
                chkIsStorage.Checked = iiDetail.AllowStorage;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
            finally
            {
                _isLoadingDetail = false;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {                
                if (dataGridView1.SelectedRows.Count <= 0)  return;

                string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

                LoadInputDetail(name);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        /// <summary>
        /// 保存为格式字符串
        /// </summary>
        /// <returns></returns>
        public string SaveToString()
        { 

            return funcControl1.SaveSchemeToString();
        }

        /// <summary>
        /// 从格式字符串载入
        /// </summary>
        public void LoadFromString(string funcScheme)
        {
            funcControl1.LoadSchemeFromString(funcScheme);
        }

        /// <summary>
        /// 显示功能测试窗口
        /// </summary>
        public void ShowTest()
        {
            frmFuncTest ft = new frmFuncTest();
            string data = ft.ShowTest(this, funcControl1.SaveSchemeToString());

            if (string.IsNullOrEmpty(data)) return;

            MessageBox.Show("返回信息：" + System.Environment.NewLine + data, "提示");
        }

        private void tsbNewInput_Click(object sender, EventArgs e)
        {
            try
            {
                string controlType = (sender as ToolStripButton).Text;

                InputItem iiNew = new InputItem();
                iiNew.ControlType = FuncConstDefine.Txt;

                frmFuncInput ffi = new frmFuncInput();

                ffi.OnCheckNameExists -= CheckNameExists;
                ffi.OnCheckNameExists += CheckNameExists;

                iiNew = ffi.ShowInput(this, iiNew);

                if (iiNew == null) return;

                funcControl1.Inputs.Add(iiNew.Name, iiNew);

                BindInputData();


                LocateRow(iiNew.Name);

                funcControl1.AddInputControl(iiNew, iiNew.Name);

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void txtDefaultValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isLoadingDetail) return;
                if (dataGridView1.SelectedRows.Count <= 0) return;

                string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

                InputItem iiDetail = funcControl1.Inputs[name];

                if (iiDetail == null) return;

                iiDetail.DefaultValue = txtDefaultValue.Text;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void rtbDataSource_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isLoadingDetail) return;
                if (dataGridView1.SelectedRows.Count <= 0) return;

                string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

                InputItem iiDetail = funcControl1.Inputs[name];

                if (iiDetail == null) return;

                iiDetail.DataFrom = rtbDataSource.Text;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void chkIsStorage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isLoadingDetail) return;
                if (dataGridView1.SelectedRows.Count <= 0) return;

                string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

                InputItem iiDetail = funcControl1.Inputs[name];

                if (iiDetail == null) return;

                iiDetail.AllowStorage = chkIsStorage.Checked;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

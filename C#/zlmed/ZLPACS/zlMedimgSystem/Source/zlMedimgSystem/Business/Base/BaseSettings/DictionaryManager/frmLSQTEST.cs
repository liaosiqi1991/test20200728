using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.BaseSettings.DictionaryManager
{
    public partial class frmLSQTest : Form
    {

        private IDBQuery _dbHelper = null;
        private DictManageModel _DictManageModel = null;

        public frmLSQTest(IDBQuery dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper;
            _DictManageModel= new DictManageModel(_dbHelper);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            
            try
            {
                DataTable dt = _DictManageModel.GetDictInfo();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //双击获取行内容，并且查找字典信息
            DataGridViewRow dgvr = dataGridView1.CurrentRow;
            string val = dgvr.Cells["字典名称"].Value.ToString();
            string sJoson = _DictManageModel.GetDictContentInfoOneOutput(val);
            //本步骤OK

            dataGridView2.DataSource = null;
            //MessageBox.Show(sJoson);

            List<JDictionaryArr> gridlist = new List<JDictionaryArr>();
            gridlist = JsonHelper.DeserializeObject<List<JDictionaryArr>>(sJoson);
            BindingList<JDictionaryArr> list = new BindingList<JDictionaryArr>(gridlist);
            dataGridView2.DataSource = list;



            //try
            //{
            //    string strJson = _DictManageModel.GetDictContentInfoOneOutput(val);
            //    DataTable DT = JsonHelper.ConvertDataTableFromJson(strJson);
            //    dataGridView2.DataSource = DT;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}





        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                //dataGridView2.it
                //新建空json对象，然后添加到列表中
                string strJson = "";
                JDictionary JD = new JDictionary();
                JDictionaryArr JDA = new JDictionaryArr();
                List<JDictionaryArr> JDAS = new List<JDictionaryArr>();

                JDA.创建日期 = DateTime.Now.ToString();
                JDA.项目编码 = "1";
                JDA.项目名称 = "balabala";
                JDAS.Add(JDA);
                //dataGridView2.DataSource = JDAS;  //添加数据ok

                JDA = new JDictionaryArr();
                JDA.创建日期 = DateTime.Now.ToString();
                JDA.项目编码 = "";
                JDA.项目名称 = "";
                JDAS.Add(JDA);
                dataGridView2.DataSource = JDAS;  //添加数据ok  新增功能OK

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {
                string strJson = "";
                JDictionaryArr JDA = new JDictionaryArr();
                List<JDictionaryArr> JDAS = new List<JDictionaryArr>();

                JDA.创建日期 = DateTime.Now.ToString();
                JDA.项目编码 = "12";
                JDA.项目名称 = "ba2labala";
                JDAS.Add(JDA);
                //dataGridView2.DataSource = JDAS;  //添加数据ok

                JDA = new JDictionaryArr();
                JDA.创建日期 = DateTime.Now.ToString();
                JDA.项目编码 = "12";
                JDA.项目名称 = "12";
                JDAS.Add(JDA);

                JDictionary JD = new JDictionary();
                JD.字典ID = 99;
                JD.字典名称 = "测试项目AK";
                JD.字典信息 = JDAS;

                _DictManageModel.UpdateDictContent(JD);
            }
            catch(Exception  ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}

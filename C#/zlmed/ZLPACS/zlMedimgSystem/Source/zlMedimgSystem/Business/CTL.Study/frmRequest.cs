using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.DB.OraServices;
using zlMedimgSystem.Interface; 
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Study
{
    public partial class frmRequest : Form
    {


        private OraServices _rsHis = null;
        private StudyInfo _studyInfo = new StudyInfo();
        private IDBQuery _dbHelper = null;
        private DataTable _dataTable = new DataTable();
        private ILoginUser _userData = null;
        private long _lngRequest = 0;


        public frmRequest()
        {
            InitializeComponent();

        }

        public frmRequest(OraServices rsHis,IDBQuery dbHelper, ILoginUser userData)
        {
            _rsHis = rsHis;
            _dbHelper = dbHelper;
            _userData = userData;

            InitializeComponent();
            init();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmRequest_Load(object sender, EventArgs e)
        {

            
            
        }

        /// <summary>
        /// 弹出登记窗口，已经根据指定条件获取到病人ID
        /// ParID:用于查找的ID值  ISPatiID：是否病人ID true病人ID false 医嘱ID
        /// </summary>
        /// <param name="adviceID"></param>
        public long ZlShowMe(string strItem,string strValue)
        {
            ClearFace();
            FindReQuest(strItem, strValue);
            this.ShowDialog();
            return _lngRequest;
        }

        /// <summary>
        /// 弹出登记窗口（没有任何条件）
        /// </summary>
        /// <param name="adviceID"></param>
        public long ZlShowMe()
        {
            _lngRequest = 0;
            cboFindItem.SelectedItem = "姓名";
            ClearFace();
            this.ShowDialog();
            return _lngRequest;
        }

        /// <summary>
        /// 控件数值清空
        /// </summary>
        private void ClearFace()
        {
            DataTable rsDT = new DataTable();
            rsDT = (DataTable)gridControl1.DataSource;
            if (rsDT != null)
            {
                rsDT.Rows.Clear();
                gridControl1.DataSource = rsDT;
            }

            txtName.Text = "";
            txtAge.Text = "";
            dtp.Visible = false;
  
            cboSex.SelectedIndex = -1;
            txtPhoneNo.Text = "";
            txtCheckNo.Text = "";
            txtID.Text = "";
            txtRequestTime.Visible = false;
            txtAdvice.Text = "";
            cboRoom.SelectedIndex = -1;
            txtW.Text = "";
            txtH.Text = "";
            txtOther.Text = "";
        }

        /// <summary>
        /// 界面控件初始化
        /// </summary>
        private void init()
        {

            ClearFace();
            //初始化执行间
            if (cboRoom.Items.Count>0)
                return;



            //DataTable rsDT = new DataTable();

            //rsDT = _rsHis.ExecuteSQL("SELECT 执行间,检查设备 FROM 医技执行房间 Where 科室ID=" + _userData.LoginSite);
            //if (rsDT.Rows.Count == 0)
            //{
            //    MessageBox.Show("当前用户科室没有有效的执行间或者检查设备。", "缺少基础数据", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.Hide();
            //}

            //for(int i=0;i< rsDT.Rows.Count;i++)
            //{
                
            //    cboRoom.Items.Insert(i, rsDT.Rows[i]["执行间"]+"[" + rsDT.Rows[i]["检查设备"]+"]");
            //}

            ////初始化时间范围,默认当前时间-3天
            //DateTime dt = DateTime.Now;
            //dt=dt.AddDays(-3d);
            //dtpFind.Text = dt.ToString();


        }


        private void button3_Click(object sender, EventArgs e)
        {
            GetDataFilter();
        }

        /// <summary>
        /// 通过界面条件检索待报到信息
        /// </summary>
        private void GetDataFilter()
        {

            string strItemValue;
            string strSQL;
            string strwhere="";


            strSQL = "Select A.ID, A.姓名, A.病人id as 患者ID,to_char(A.病人来源) as 患者来源, A.主页id,A.性别,A.年龄,A.医嘱内容 as 项目摘要,A.执行科室ID,A.开嘱医生 as 登记人, " +
           " A.诊疗项目ID as 检查项目ID ,B.影像类别,C1.名称 as 执行科室,C2.名称 as 患者科室, " +
           " D.执行过程,D.执行间,F.住院号,G.门诊号,E.身份证号,E.出生日期,E.联系人电话,G.ID as 挂号ID " +
           " From 病人医嘱记录 A, 影像检查项目 B,部门表 C1,部门表 C2,病人医嘱发送 D,病人信息 E,病案主页 F,病人挂号记录 G " +
           " Where A.相关id IS NULL And A.病人科室id=C2.ID And A.执行科室ID=C1.ID " +
           "And A.诊疗项目ID =B.诊疗项目ID And G.no(+)= A.挂号单 and A.病人ID=F.病人ID(+) And A.主页ID=F.主页ID(+) And A.ID = D.医嘱id " +
           "and A.病人ID=E.病人ID And A.病人来源<3 And nvl(D.执行过程,0)<2 And A.执行科室ID=";// + _userData.LoginSite;

            strItemValue = txtFindValue.Text;
            if (strItemValue.Trim()!="")
                {
                    switch (cboFindItem.Text )
                    {
                        case "姓名":
                            strwhere = " and A.姓名 like  '%" + txtFindValue.Text.Trim() + "%'";
                        break;
                        case "就诊卡号":
                            strwhere = " and E.就诊卡号= '" + txtFindValue.Text.Trim() + "'";
                            break;
                        case "门诊号":
                            strwhere = " and G.门诊号= " +  txtFindValue.Text.Trim() ;
                            break;

                        case "住院号":
                            strwhere = " and F.住院号= " + txtFindValue.Text.Trim();
                            break;

                        case "身份证号":

                            strwhere = " and E.身份证号= '" + txtFindValue.Text.Trim() + "'";
                            break;

                        default:
                            strwhere = "";
                            break;
                    }

                    
                }

            strwhere += " and A.开嘱时间 >to_date('" + dtpFind.Text + "', 'yyyy-mm-dd')";


            System.Diagnostics.Debug.WriteLine("test1");

            DataTable rsDT = new DataTable();

            try
            {
                rsDT = _rsHis.ExecuteSQL(strSQL + strwhere);
                gridControl1.DataSource = rsDT;

                gridView1.Columns["ID"].Visible = false;
                gridView1.Columns["患者ID"].Visible = false;
                gridView1.Columns["执行科室ID"].Visible = false;
                gridView1.Columns["检查项目ID"].Visible = false;
                gridView1.Columns["挂号ID"].Visible = false;

            }
            catch
            {
                MessageBox.Show("查找数据错误。", "报到", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
            System.Diagnostics.Debug.WriteLine("test2");

         



        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                LoadOneData();
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MsgBox.ShowException(ex, this);
            }
        }

        private void LoadOneData()
        {
      
                int intSelRow;
                string strTmp;

                if (gridView1.RowCount == 0)
                    return;

                intSelRow = gridView1.GetSelectedRows()[0];
                if (intSelRow < 0)
                    return;
                System.Diagnostics.Debug.WriteLine("LoadOneData step1");
                _studyInfo = new StudyInfo();


                //_studyInfo.ID = Convert.ToInt32("100");
                _studyInfo.ID = Convert.ToInt64(gridView1.GetRowCellValue(intSelRow, "ID").ToString());
                _studyInfo.患者ID = Convert.ToInt64(gridView1.GetRowCellValue(intSelRow, "患者ID").ToString());
                _studyInfo.执行科室ID = Convert.ToInt64(gridView1.GetRowCellValue(intSelRow, "执行科室ID").ToString());
                _studyInfo.检查项目ID = Convert.ToInt64(gridView1.GetRowCellValue(intSelRow, "检查项目ID").ToString());
                _studyInfo.患者来源 = gridView1.GetRowCellValue(intSelRow, "患者来源").ToString();

                strTmp = gridView1.GetRowCellValue(intSelRow, "主页ID").ToString();
                if (strTmp != "")
                    _studyInfo.主页ID = Convert.ToInt16(strTmp);
                else
                    _studyInfo.主页ID = 0;


                string str挂号ID = gridView1.GetRowCellValue(intSelRow, "挂号ID").ToString();
                if (_studyInfo.患者来源 == "1")
                    _studyInfo.就诊ID = str挂号ID;
                else if (_studyInfo.患者来源 == "2")
                    _studyInfo.就诊ID = _studyInfo.主页ID.ToString();
                else
                    _studyInfo.就诊ID = "";


                _studyInfo.姓名 = gridView1.GetRowCellValue(intSelRow, "姓名").ToString();
                _studyInfo.性别 = gridView1.GetRowCellValue(intSelRow, "性别").ToString();
                _studyInfo.年龄 = gridView1.GetRowCellValue(intSelRow, "年龄").ToString();
                _studyInfo.身高 = "";// gridView1.GetRowCellValue(intSelRow, "身高").ToString();
                _studyInfo.体重 = "";// gridView1.GetRowCellValue(intSelRow, "体重").ToString();

                _studyInfo.住院号 = gridView1.GetRowCellValue(intSelRow, "住院号").ToString();
                _studyInfo.门诊号 = gridView1.GetRowCellValue(intSelRow, "门诊号").ToString();
                _studyInfo.检查号 = "";// gridView1.GetRowCellValue(intSelRow, "检查号").ToString();

                _studyInfo.影像类别 = gridView1.GetRowCellValue(intSelRow, "影像类别").ToString();
                _studyInfo.执行科室 = gridView1.GetRowCellValue(intSelRow, "执行科室").ToString();
                _studyInfo.检查设备 = "";// gridView1.GetRowCellValue(intSelRow, "检查设备").ToString();
                _studyInfo.符合情况 = "";//gridView1.GetRowCellValue(intSelRow, "符合情况").ToString();
                //_studyInfo.报到时间 = "";//gridView1.GetRowCellValue(intSelRow, "报到时间").ToString();

                _studyInfo.登记人 = gridView1.GetRowCellValue(intSelRow, "登记人").ToString();
                _studyInfo.报到人 = "";//gridView1.GetRowCellValue(intSelRow, "报到人").ToString();
                _studyInfo.完成人 = "";//gridView1.GetRowCellValue(intSelRow, "完成人").ToString();
                _studyInfo.绿色通道 = "";// gridView1.GetRowCellValue(intSelRow, "绿色通道").ToString();

                _studyInfo.项目摘要 = gridView1.GetRowCellValue(intSelRow, "项目摘要").ToString();
                _studyInfo.患者科室 = gridView1.GetRowCellValue(intSelRow, "患者科室").ToString();
                string strdt = gridView1.GetRowCellValue(intSelRow, "出生日期").ToString();
                _studyInfo.出生日期 = Convert.ToDateTime(strdt);
                _studyInfo.身份证号 = gridView1.GetRowCellValue(intSelRow, "身份证号").ToString();
                _studyInfo.联系人电话 = gridView1.GetRowCellValue(intSelRow, "联系人电话").ToString();


                System.Diagnostics.Debug.WriteLine("LoadOneData step2");
                ///////////////界面控件信息填充


                txtName.Text = _studyInfo.姓名;
                txtAge.Text = _studyInfo.年龄;
                dtp.Text = _studyInfo.出生日期.ToString();
                cboSex.SelectedItem = _studyInfo.性别;

                txtPhoneNo.Text = _studyInfo.联系人电话;

                string strCheckID = _dbHelper.ExecuteSQLOneOutput("select max(检查号) from 影像检查信息").ToString();

                long lngNextID;
                if (strCheckID == "")
                    lngNextID = 1;
                else
                {
                    lngNextID = Convert.ToInt64(strCheckID);
                    lngNextID += 1;
                }
                txtCheckNo.Text = lngNextID.ToString();



            txtID.Text = _studyInfo.身份证号;
                txtAdvice.Text = _studyInfo.项目摘要;
                cboRoom.SelectedIndex = -1;
                DateTime dt = System.DateTime.Now;
                dt.ToString("yyyy-MM-dd HH24:MI:ss");
                txtRequestTime.Text = dt.ToString();

                txtOther.Text = "";
                txtH.Text = "";
                txtW.Text = "";

                dtp.Visible = true;
                txtRequestTime.Visible = true;
                System.Diagnostics.Debug.WriteLine("LoadOneData ok");
          
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (validate()!=true)
                return;

            if (Request() == true)
            {
                int intSelRow = gridView1.GetSelectedRows()[0];
                if (intSelRow < 0)
                    return;
                string strID= gridView1.GetRowCellValue(intSelRow, "ID").ToString();
                _lngRequest = Convert.ToInt64(strID);

                this.Hide();
            }

        }

        /// <summary>
        /// 验证数据有效性，
        /// 要求：有执行间，有检查号
        /// </summary>
        private bool validate()
        {
            try
            {
                string strTmp;

                if (cboRoom.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择一个执行间。", "缺少必要数据", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                strTmp = cboRoom.SelectedItem.ToString();
                strTmp = strTmp.Substring(strTmp.IndexOf("[") + 1, strTmp.Length - strTmp.IndexOf("[") - 2);
                _studyInfo.检查设备 = strTmp;

                if ((txtCheckNo.Text).Trim() == "")
                {

                    MessageBox.Show("检查号不能为空。", "缺少必要数据", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                //传入 执行间 报到人 报到时间 身高 体重 检查号
                _studyInfo.报到人 = _userData.Name;
                _studyInfo.报到时间 = Convert.ToDateTime(txtRequestTime.Text.ToString()); 

                _studyInfo.身高 = txtH.Text;
                _studyInfo.体重 = txtW.Text;
                _studyInfo.检查号 = txtCheckNo.Text;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);

            }

            return  true;
        }

        /// <summary>
        /// 报到操作
        /// 1 json库写入数据
        /// 2 ZLHIS库暂时只更新 检查过程为2  其他暂时不管 
        /// </summary>
        /// <returns></returns>
        private bool Request()
        {

            try
            {
                string strjson;

                strjson = JsonHelper.SerializeObject(_studyInfo);

                System.Diagnostics.Debug.WriteLine("Request JSON库获取MAXID OK");

                if (_dbHelper != null)
                    _dataTable = _dbHelper.ExecuteSQL("INSERT INTO 影像检查信息 " +
                        "(ID,患者ID,姓名,检查号,住院号,门诊号,报到日期,患者信息) " +
                        "VALUES" +
                        " (" + _studyInfo.ID + " , " + _studyInfo.患者ID + "  , '" + _studyInfo.姓名 + "'  , '" + _studyInfo.检查号 + "' ,"
                        + (_studyInfo.住院号 == "" ? "null" : _studyInfo.住院号) + ","
                        + (_studyInfo.门诊号 == "" ? "null" : _studyInfo.门诊号) + "  ,"
                        + "to_date('" + _studyInfo.报到时间.ToString("yyyy-MM-dd HH:mm")  + "', 'yyyy-MM-dd HH24:MI:ss')" + " ," + "'" + strjson + "') ");

                System.Diagnostics.Debug.WriteLine("Request json库插入数据OK");

                _dataTable = _rsHis.ExecuteSQL("update 病人医嘱发送 SET 执行过程=2  WHERE  医嘱ID=" + _studyInfo.ID);
                System.Diagnostics.Debug.WriteLine("Request HIS库插入数据OK");

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

           // _studyInfo.住院号<>""? studyInfo.住院号 : null
            return true;
        }

        /// <summary>
        /// 查找报到
        /// 主界面已经录入工具栏中查找项目，并且项目是姓名、门诊号、住院号，自动填写数据并且进行一次查找
        /// </summary>
        private void FindReQuest(string strItem,string strValue)
        {
            long lngValue;
            string strSQL = "Select A.ID, A.姓名, A.病人id as 患者ID,to_char(A.病人来源) || '' as 患者来源" +
                ", A.主页id,A.性别,A.年龄,A.医嘱内容 as 项目摘要,A.执行科室ID,A.开嘱医生 as 登记人, " +
            " A.诊疗项目ID as 检查项目ID ,B.影像类别,C1.名称 as 执行科室,C2.名称 as 患者科室 " +
            ", D.执行过程,D.执行间,F.住院号,G.门诊号,E.身份证号,To_Char(e.出生日期, 'yyyy-mm-dd hh:mi') as 出生日期,E.联系人电话,G.ID as 挂号ID " +
            " From 病人医嘱记录 A, 影像检查项目 B,部门表 C1,部门表 C2,病人医嘱发送 D,病人信息 E,病案主页 F,病人挂号记录 G " +
            " Where A.相关id IS NULL And A.病人科室id=C2.ID And A.执行科室ID=C1.ID " +
            "And A.诊疗项目ID =B.诊疗项目ID And G.no(+)= A.挂号单 and A.病人ID=F.病人ID(+) And A.主页ID=F.主页ID(+) And A.ID = D.医嘱id " +
            "and A.病人ID=E.病人ID And A.病人来源<3 And nvl(D.执行过程,0)<2 And A.执行科室ID=";// + _userData.LoginSite;

            string strWhere="";

            cboFindItem.SelectedItem = strItem;
            txtFindValue.Text = strValue;
            if (strItem=="姓名")
            {
                strWhere = " and A.姓名 like  '%" + strValue + "%'";
            }

            if (strItem=="门诊号")
            {
                lngValue = Convert.ToInt64(strValue);
                strWhere = " and G.门诊号= " + lngValue;
            }

            if (strItem == "住院号")
            {
                lngValue = Convert.ToInt64(strValue);
                strWhere = " and F.住院号= " + lngValue;
            }

            if (strItem == "身份证号")
            {
                strWhere = " and E.身份证号= '" + strValue + "'"; ;
            }


            DataTable rsDT = null;// new DataTable();
            strSQL = strSQL + strWhere;

            try
            {
                rsDT = _rsHis.ExecuteSQL(strSQL);
                gridControl1.DataSource = rsDT;
                gridView1.PopulateColumns();
                gridView1.Columns["ID"].Visible = false;
                gridView1.Columns["患者ID"].Visible = false;
                gridView1.Columns["执行科室ID"].Visible = false;
                gridView1.Columns["检查项目ID"].Visible = false;
                gridView1.Columns["挂号ID"].Visible = false;
                gridView1.Columns["主页ID"].Visible = false;

                for(int i=0;i< gridView1.RowCount;i++)
                {
                    string strTmp = "";
                    strTmp = gridView1.GetRowCellValue(i, "患者来源").ToString();

                    if (strTmp == "1")
                        strTmp = "门诊病人";

                    if (strTmp == "2")
                        strTmp = "住院病人";


                    gridView1.SetRowCellValue(i, "患者来源", strTmp);

                }

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, "数据查找错误.", this);
                //MessageBox.Show("查找数据错误:" + ex.Message, "查找报到", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    }
}

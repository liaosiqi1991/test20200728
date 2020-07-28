using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.BehindCode
{
    public partial class frmBehindCodeModuleDesign : Form
    {
        private bool _isOk = false;
        private BehindCodeModuleDesign _codeDesign = null;
        private IDBQuery _dbHelper = null;

        public frmBehindCodeModuleDesign()
        {
            InitializeComponent();
        }

        public bool ShowBehindCodeDesign(IDBQuery dbHelper, BehindCodeModuleDesign codeDesign, IWin32Window owner)
        {
            _isOk = false;

            _dbHelper = dbHelper;
            _codeDesign = codeDesign;

            this.ShowDialog(owner);

            return _isOk;
        }

        private void LoadDataSource()
        {
            cbxDBAlias.DisplayMember = "Name";

            ItemBind ib = new ItemBind("", "");
            cbxDBAlias.Items.Add(ib);


            ThridDBSourceModel dbSourceModel = new ThridDBSourceModel(_dbHelper);

            DataTable dtDBSource = dbSourceModel.GetAllThridDBSource();


            foreach (DataRow dr in dtDBSource.Rows)
            {
                ThridDBSourceData dbSource = new ThridDBSourceData();
                dbSource.BindRowData(dr);

                ItemBind ibSource = new ItemBind(dbSource.数据源别名, "");
                ibSource.Tag = dbSource;

                cbxDBAlias.Items.Add(ibSource);
            }
        }


        private void frmBehindCodeModuleDesign_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataSource();

                rtbContext.Text = Properties.Resources.Code;

                int index = rtbContext.Text.IndexOf("public bool Run(");
                rtbContext.SelectionStart = index;

                lbMethodName.Items.Clear();

                if (_codeDesign == null || _codeDesign.BehindCodes.Count <= 0) return;

                lbMethodName.DisplayMember = "Name";
                lbMethodName.ValueMember = "Value";
                
                foreach(BehindCodeItem bci in _codeDesign.BehindCodes)
                {
                    ItemBind ib = new ItemBind();
                    ib.Name = bci.FuncName;
                    ib.Value = bci.FuncContext;

                    ib.Tag = bci; 

                    lbMethodName.Items.Add(ib);
                }

                if (lbMethodName.Items.Count > 0) lbMethodName.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex);
            }
        }

        private void lbMethodName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                rtbContext.Text = "";
                if (lbMethodName.SelectedItem == null) return;

                ItemBind ib = lbMethodName.SelectedItem as ItemBind;

                BehindCodeItem bci = ib.Tag as BehindCodeItem;

                tbName.Text = bci.FuncName;
                rtbContext.Text = bci.FuncContext;
                cbxDBAlias.Text = bci.ThridDBAlias;
                txtVer.Text = Convert.ToString(bci.VerNo);
                chkBGCompile.Checked = bci.IsBGCompile;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex);
            }
        }

        private bool Valide(bool isNew)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("方法名称不允许为空。", "提示");
                tbName.Focus();

                return false;
            }

            int index = lbMethodName.FindString(tbName.Text);

            //判断名称是否重复
            if (isNew)
            {
                if (index >= 0)
                {
                    MessageBox.Show("方法名称不允许重复。", "提示");
                    tbName.Focus();

                    return false;
                }
            }
            else
            {
                if (index >= 0 && index != lbMethodName.SelectedIndex)
                {
                    MessageBox.Show("方法名称不允许重复。", "提示");
                    tbName.Focus();

                    return false;
                }

            }

            return true;

        }
        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (Valide(true) == false) return;

                ItemBind ib = new ItemBind();
                ib.Name = tbName.Text;
                ib.Value = rtbContext.Text;

                BehindCodeItem bci = new BehindCodeItem();

                bci.FuncName = tbName.Text;
                bci.FuncContext = rtbContext.Text;
                bci.ThridDBAlias = cbxDBAlias.Text;
                bci.VerNo = 1;
                bci.IsBGCompile = chkBGCompile.Checked;

                ib.Tag = bci; 
                 
                int newindex = lbMethodName.Items.Add(ib);

                lbMethodName.SelectedIndex = newindex; 

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbMethodName.SelectedItem == null)
                {
                    MessageBox.Show("尚未选择需要更新的方法。", "提示");
                    return;
                }
                if (Valide(false) == false) return;

                ItemBind ib = lbMethodName.SelectedItem as ItemBind;
                ib.Name = tbName.Text;
                ib.Value = rtbContext.Text;


                BehindCodeItem bci = ib.Tag as BehindCodeItem;

                bci.FuncName = tbName.Text;
                bci.FuncContext = rtbContext.Text;
                bci.ThridDBAlias = cbxDBAlias.Text;
                bci.VerNo = bci.VerNo + 1;
                bci.IsBGCompile = chkBGCompile.Checked;

                txtVer.Text = Convert.ToString(bci.VerNo);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbMethodName.SelectedItem == null)
                {
                    MessageBox.Show("尚未选择需要删除的方法。", "提示");
                    return;
                }

                if (MessageBox.Show("确认删除当前所选方法吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;

                ItemBind ib = lbMethodName.SelectedItem as ItemBind;
                lbMethodName.Items.Remove(lbMethodName.SelectedItem);
                 
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }

        }

        private void tsbDebug_Click(object sender, EventArgs e)
        {
            try
            {
                IBizDataItems bizDatas = null;

                Runner run = new Runner(); 

                run.Init("DEBUG", "0",null, null, null, null, null, null);

                BehindCodeItem bci = new BehindCodeItem();
                bci.FuncName = tbName.Text;
                bci.FuncContext = rtbContext.Text;
                bci.ThridDBAlias = cbxDBAlias.Text;
                bci.VerNo = string.IsNullOrEmpty(txtVer.Text) ? 0 : Convert.ToInt32(txtVer.Text);
                bci.IsBGCompile = false;

                run.Run(bci, "", null, sender, e, "验证", null, null, out bizDatas, false);

                MessageBox.Show("验证成功。", "提示");
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void Save()
        {
            if (lbMethodName.SelectedItem != null)
            {
                if (Valide(false) == false) return;

                ItemBind ib = lbMethodName.SelectedItem as ItemBind;
                ib.Name = tbName.Text;
                ib.Value = rtbContext.Text;

                BehindCodeItem bci = ib.Tag as BehindCodeItem;

                bci.FuncName = tbName.Text;
                bci.FuncContext = rtbContext.Text;
                bci.ThridDBAlias = cbxDBAlias.Text;
                bci.VerNo = bci.VerNo + 1;
                bci.IsBGCompile = chkBGCompile.Checked;

                txtVer.Text = Convert.ToString(bci.VerNo);
            }

            _codeDesign.BehindCodes.Clear();

            foreach (ItemBind ib in lbMethodName.Items)
            {
                BehindCodeItem bci = (ib.Tag as BehindCodeItem).Clone();

                _codeDesign.BehindCodes.Add(bci);
            }

            _isOk = true;
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tsTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("载入模板后，将覆盖现有处理代码，是否继续？", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;

                rtbContext.Text = Properties.Resources.Code;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
         
        private void tsbVs_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceCode = rtbContext.Text; 

                string filePath = Dir.GetAppProjectDir() + @"\Template\CodeTemplate.cs";
                if (File.Exists(filePath) == false)
                {
                    MessageBox.Show("模板文件不存在，不能在Visual Studio中编辑。", "提示");
                    return;
                }

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(sourceCode);
                }

                string vsProgram = "devenv.exe";

                //启动测试程序
                try
                {
                    vsProgram = AppSetting.ReadSetting("visual studio file", vsProgram);
                }
                catch { }

                if (string.IsNullOrEmpty(vsProgram))
                {
                    MessageBox.Show("未找到Visual Studio程序。", "提示");
                    return;
                }

                string soluation = Dir.GetAppProjectDir() + @"\Template.sln";
                Process process = new Process();

              
                process.EnableRaisingEvents = true;
                process.Exited += VsExit;

                ProcessStartInfo psi = new ProcessStartInfo(vsProgram, soluation);
                process.StartInfo = psi;

                process.Start();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private  void VsExit(object sender, EventArgs e)
        {
            string filePath = Dir.GetAppProjectDir() + @"\Template\CodeTemplate.cs";

            if (File.Exists(filePath))
            {
                using (StreamReader sw = new StreamReader(filePath))
                {
                    SyncCodeProcess(sw.ReadToEnd());
                }
            }
        }

        public delegate void SyncCode(string code);

        private void SyncCodeProcess(string code)
        {
            if (this.InvokeRequired)//如果是在非创建控件的线程访问，即InvokeRequired=true
            {
                SyncCode syncCode = new SyncCode(SyncCodeProcess);
                this.Invoke(syncCode, new object[] { code });
            }
            else
            {
                rtbContext.Text = code;
                int index = rtbContext.Text.IndexOf("public bool Run(");

                rtbContext.SelectionStart = index;
                rtbContext.SelectionLength = 15;
                
            }
        }
    }
}

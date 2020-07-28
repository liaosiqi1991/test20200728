using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.SqlManager
{
    public partial class frmSqlManager : Form
    {
        private SqlTabs _sqlManager = null;
        public frmSqlManager()
        {
            InitializeComponent();
        }

 
        public void ShowManager(SqlTabs sqlManager, IWin32Window owner)
        {
            _sqlManager = sqlManager;

            this.ShowDialog(owner);
        }

        private void frmSqlManager_Load(object sender, EventArgs e)
        {
            tvSqls.Nodes.Clear();

            if (_sqlManager.SqlBizs.Tables.Count <= 0) return;

            foreach(DataTable dtBiz in _sqlManager.SqlBizs.Tables)
            {
                SqlBiz sb = dtBiz as SqlBiz;

                TreeNode pNode = tvSqls.Nodes.Add(sb.BizName);
                pNode.Name = sb.BizName;

                foreach (DataRow dr in sb.Rows)
                {
                    TreeNode tnSub = pNode.Nodes.Add(dr[sb.KeyName].ToString());
                    tnSub.Name = dr[sb.KeyName].ToString();
                }
            }
        }

        private bool DataValidate()
        {
            if (string.IsNullOrEmpty(cbxBizName.Text) )
            {
                MessageBox.Show("业务标记不能为空。", "提示");
                cbxBizName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtSqlName.Text))
            {
                MessageBox.Show("业务名称不能为空。", "提示");
                txtSqlName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(rtbSqlContext.Text))
            {
                MessageBox.Show("查询内容不能为空。", "提示");
                rtbSqlContext.Focus();
                return false;
            }

            return true;
        }

        private void butNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataValidate() == false) return;

                TreeNode tnParent = null;
                if (_sqlManager.HasBiz(cbxBizName.Text) == false)
                {
                    cbxBizName.Items.Add(cbxBizName.Text);

                    tnParent = tvSqls.Nodes.Add(cbxBizName.Text);
                    tnParent.Name = cbxBizName.Text;
                }


                if (_sqlManager.GetBiz(cbxBizName.Text).HasSql(txtSqlName.Text) == true)
                {
                    MessageBox.Show("查询名称已存在，不能重复添加。", "提示");
                    return;
                }


                _sqlManager.GetBiz(cbxBizName.Text).UpdateSql(txtSqlName.Text, rtbSqlContext.Text);

                if (tnParent == null)
                {
                    TreeNode[] tns = tvSqls.Nodes.Find(cbxBizName.Text, false);
                    if (tns.Length <= 0) return;

                    tnParent = tns[0];
                }

                tnParent.Nodes.Add(txtSqlName.Text);

                if (tnParent.IsExpanded == false) tnParent.Expand();

                _sqlManager.SaveToFile();

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (tvSqls.SelectedNode.Parent == null) return;

                TreeNode tnSel = tvSqls.SelectedNode;
                TreeNode tnParent = tnSel.Parent;
                
                string bizName = tnParent.Text;
                string sqlName = tnSel.Text;

                _sqlManager.GetBiz(bizName).RemoveSql(sqlName);


                tnParent.Nodes.Remove(tnSel);

                if (tnParent.Nodes.Count <= 0) tvSqls.Nodes.Remove(tnParent);

                cbxBizName.Text = "";
                txtSqlName.Text = "";
                rtbSqlContext.Text = "";

                _sqlManager.SaveToFile();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataValidate() == false) return;


                if (tvSqls.SelectedNode.Parent == null) return;

                TreeNode tnSel = tvSqls.SelectedNode;
                TreeNode tnParent = tnSel.Parent;

                string bizName = tnParent.Text;
                string sqlName = tnSel.Text;

                _sqlManager.GetBiz(bizName).UpdateSql(sqlName, rtbSqlContext.Text);


                _sqlManager.SaveToFile();

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void tvSqls_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Parent == null)
            {
                cbxBizName.Text = "";
                txtSqlName.Text = "";
                rtbSqlContext.Text = "";

                return;
            }

            try
            {
                cbxBizName.Text = e.Node.Parent.Text;
                txtSqlName.Text = e.Node.Text;

                rtbSqlContext.Text = _sqlManager.GetBiz(e.Node.Parent.Text).GetSqlContext(e.Node.Text);
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

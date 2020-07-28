﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.BusinessBase;
using zlMedimgSystem.DataModel;
using zlMedimgSystem.Interface;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.CTL.Summary
{
    public partial class frmDBSource : Form
    {

        private BindDataSource _dbSource = null;
        private IDBQuery _dbHelper = null;
        private ThridDBSourceModel _dbSourceModel = null;

        public frmDBSource()
        {
            InitializeComponent();
        }

        public void ShowDesign(BindDataSource dbSource, IDBQuery dbHelper, IWin32Window owner)
        {
            _dbSource = dbSource;
            _dbHelper = dbHelper;

            this.ShowDialog(owner);
        }

        private void frmInfoDesign_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDataSource();

                foreach(string parName in SqlHelper.SysFixPars.Split(','))
                {
                    if (("申请ID,申请识别码,患者ID,患者识别码,患者姓名").IndexOf(parName) >= 0) continue;
                    if (string.IsNullOrEmpty(parName)) continue;

                    listBox1.Items.Add("[系统_" + parName + "]");
                }

                richTextBox1.Text = _dbSource.查询语句;
                tsCbxDataSource.Text = _dbSource.数据源别名;
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void LoadDataSource()
        {
            tsCbxDataSource.ComboBox.DisplayMember = "Name";

            ItemBind ib = new ItemBind("", "");
            tsCbxDataSource.Items.Add(ib);

            if (_dbSourceModel == null)
            {
                _dbSourceModel = new ThridDBSourceModel(_dbHelper);
            }

            DataTable dtDBSource = _dbSourceModel.GetAllThridDBSource();


            foreach (DataRow dr in dtDBSource.Rows)
            {
                ThridDBSourceData dbSource = new ThridDBSourceData();
                dbSource.BindRowData(dr);

                ItemBind ibSource = new ItemBind(dbSource.数据源别名, "");
                ibSource.Tag = dbSource;

                tsCbxDataSource.Items.Add(ibSource);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                _dbSource.查询语句 = richTextBox1.Text;
                _dbSource.数据源别名 = tsCbxDataSource.Text;

                this.Close();

            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex,this);
            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
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

        private void tsbTest_Click(object sender, EventArgs e)
        {
            try
            {
                string pars = SqlHelper.GetSqlPars(richTextBox1.Text);
                DataTable dtTest = SqlHelper.TestSql(_dbHelper, richTextBox1.Text, pars, tsCbxDataSource.Text, this);

                dataGridView1.DataSource = dtTest;

            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.SelectedText = listBox1.Text;
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

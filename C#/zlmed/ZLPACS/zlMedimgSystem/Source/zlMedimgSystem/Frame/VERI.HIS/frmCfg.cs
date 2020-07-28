using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zlMedimgSystem.Services;

namespace zlMedimgSystem.VERI.His
{
    public partial class frmCfg : Form
    {

        private Configuration _ca = null;

        public frmCfg()
        {
            InitializeComponent();
        }


        private string[] GetDatabases()
        {
            string output = "";
            string fileLine;
            string oracle_home;
            Stack parens = new Stack();

            // open tnsnames.ora
            StreamReader sr;
            try
            {
                oracle_home = Environment.GetEnvironmentVariable("oracle_home");
                sr = new StreamReader(oracle_home + @"\network\ADMIN\TNSNAMES.ORA");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw ex;
            }

            // Read the first line of the file
            fileLine = sr.ReadLine();

            // loop through, reading each line of the file
            while (fileLine != null)
            {
                // if the first non whitespace character is a #, ignore the line
                // and go to the next line in the file
                if (fileLine.Length > 0 && fileLine.Trim().Substring(0, 1) != "#")
                {
                    // Read through the input line character by character
                    char lineChar;
                    for (int i = 0; i < fileLine.Length; i++)
                    {
                        lineChar = fileLine[i];

                        if (lineChar == '(')
                        {
                            // if the char is a ( push it onto the stack
                            parens.Push(lineChar);
                        }
                        else if (lineChar == ')')
                        {
                            // if the char is a ), pop the stack
                            parens.Pop();
                        }
                        else
                        {
                            // if there is nothing in the stack, add the character to the

                            if (parens.Count == 0)
                            {
                                output += lineChar;
                            }
                        }
                    }
                }

                // Read the next line of the file
                fileLine = sr.ReadLine();
            }

            // Close the stream reader
            sr.Close();

            // Split the output string into a string[]
            string[] split = output.Split('=');

            // trim each string in the array
            for (int i = 0; i < split.Length; i++)
            {
                split[i] = split[i].Trim();
            }

            Array.Sort(split);

            return split;
        }


        private void frmCfg_Load(object sender, EventArgs e)
        {
            try
            {
                foreach(string snme in GetDatabases())
                {
                    cbxServerName.Items.Add(snme);
                }


                int i;

                string strCfgFile = ConfigHelper.CreateConfig(ConfigHelper.GetCfgName());
                                 

                _ca = ConfigurationManager.OpenExeConfiguration(strCfgFile) ;
                bool hasKey = _ca.AppSettings.Settings.AllKeys.Contains("HIS认证服务名称");

                if (cbxServerName.Items.Count <= 0) return;

                if (hasKey)
                {
                    string loginServer = _ca.AppSettings.Settings["HIS认证服务名称"].Value;
                    i = cbxServerName.Items.IndexOf(loginServer);

                    if (i >= 0) cbxServerName.SelectedIndex = i;
                }
                else
                {
                    cbxServerName.SelectedIndex = 0;
                    _ca.AppSettings.Settings.Add("HIS认证服务名称", cbxServerName.Text);
                }
            }
            catch(Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butSure_Click(object sender, EventArgs e)
        {
            try
            {
                _ca.AppSettings.Settings["HIS认证服务名称"].Value = cbxServerName.Text;
                _ca.Save(ConfigurationSaveMode.Modified);

                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.ShowException(ex, this);
            }
        }
    }
}

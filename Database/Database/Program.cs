using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; 
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            String str;
            SqlConnection myConn = new SqlConnection
                ("Server=BAAL\\SQLEXPRESS2;Integrated security=SSPI ;database=master");
            str = "CREATE DATABASE MyDatabase";
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Database Created Successfully", "MyApp",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyApp", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }

        }
    }
}
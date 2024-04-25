using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace SALES_PROJECT
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        string uname, password;
        //int i = 0;
        public Form1()
        {
            InitializeComponent();
            instance = this;
        }
        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=IDPG3:1521/XE;USER ID=C##SHREYAS;PASSWORD=696996");
             try
             {
               conn.Open();
               MessageBox.Show("Logging in..");
             }
            catch (Exception e1)
            { }
         }


        private void cust_login_Click(object sender, EventArgs e)
        {
            ConnectDB();
            try
            {
                uname = textBox1.Text;
                password = textBox2.Text;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM customers WHERE cust_id = :uname AND cust_passcode = :password";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("uname", OracleDbType.Varchar2).Value = uname;
                cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = password;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "CUSTOMERS");
                DataTable dt = ds.Tables["CUSTOMERS"];
                int rowCount = dt.Rows.Count;

                if (rowCount >= 1)
                {
                    uname = textBox1.Text;
                    customer_login frm = new customer_login();
                    frm.passingvalue = uname;
                    frm.Show();
                    frm.Location = this.Location;
                    frm.Size = this.Size;
                    this.Hide();
                }
                else
                {
                    uname = "";
                    password = "";
                    MessageBox.Show("Invalid Login Details");
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show("Error: " + e2.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void seller_login_Click(object sender, EventArgs e)
        {

            ConnectDB();
            try
            {
                uname = textBox1.Text;
                password = textBox2.Text;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM sellers WHERE SEL_ID = :uname AND sel_passcode = :password";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("uname", OracleDbType.Varchar2).Value = uname;
                cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = password;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "SELLERS");
                DataTable dt = ds.Tables["SELLERS"];
                int rowCount = dt.Rows.Count;

                if (rowCount >= 1)
                {
                    seller_details frm2 = new seller_details();
                    frm2.passingvalue = uname;
                    frm2.Show();
                    frm2.Location = this.Location;
                    frm2.Size = this.Size;
                    this.Hide();
                }
                else
                {
                    uname = "";
                    password = "";
                    MessageBox.Show("Invalid Login Details");
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show("Error: " + e2.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void AdminLogin_Click(object sender, EventArgs e)
        {
            ConnectDB(); // Assuming this function establishes the database connection

            try
            {
                uname = textBox1.Text;
                password = textBox2.Text;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM ADMINS WHERE ad_id = :uname AND ad_passcode = :password";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("uname", OracleDbType.Varchar2).Value = uname;
                cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = password;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "ADMINS");
                DataTable dt = ds.Tables["ADMINS"];
                int rowCount = dt.Rows.Count;

                if (dt.Rows.Count > 0)
                {
                    uname = textBox1.Text;
                    admin_details frm5 = new admin_details();
                    frm5.passingvalue = uname;
                    frm5.Show();
                    frm5.Location = this.Location;
                    frm5.Size = this.Size;
                    this.Hide();
                }
                else
                {
                    uname = "";
                    password = "";
                    MessageBox.Show("Invalid Login Details");
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show("Error: " + e2.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void signup_Click(object sender, EventArgs e)
        {   
            signup_details s = new signup_details();
            s.Show();
            s.Location = this.Location;
            this.Hide();
        }

        private void shipper_login_Click(object sender, EventArgs e)
        {
            ConnectDB(); // Assuming this function establishes the database connection

            try
            {
                uname = textBox1.Text;
                password = textBox2.Text;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM SHIPPERS WHERE ship_id = :uname AND ship_passcode = :password";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("uname", OracleDbType.Varchar2).Value = uname;
                cmd.Parameters.Add("password", OracleDbType.Varchar2).Value = password;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "SHIPPERS");
                DataTable dt = ds.Tables["SHIPPERS"];
                int rowCount = dt.Rows.Count;

                if (rowCount >= 1)
                {
                    uname = textBox1.Text;
                    shipper_details frm3 = new shipper_details();
                    frm3.passingvalue = uname;
                    frm3.Show();
                    frm3.Location = this.Location;
                    frm3.Size = this.Size;
                    this.Hide();
                }
                else
                {
                    uname = "";
                    password = "";
                    MessageBox.Show("Invalid Login Details");
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show("Error: " + e2.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void forgot_pswd_Click(object sender, EventArgs e)
        {
            Forgot_password f = new Forgot_password();
            f.Show();
            this.Hide();
        }
    }
}

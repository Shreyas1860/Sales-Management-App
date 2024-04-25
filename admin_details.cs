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
    public partial class admin_details : Form
    {
        String id;
        OracleConnection conn;
        OracleConnection comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public admin_details()
        {
            InitializeComponent();
        }

        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=IDPG3:1521/XE;USER ID=C##SHREYAS;Password=696996");
            try
            {
                conn.Open();
               // MessageBox.Show("Connected");
            }
            catch (Exception e1)
            {
            }
        }
        public string passingvalue
        {
            get { return id; }
            set { id = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login_history l = new login_history();
            l.Show();
            this.Hide();
        }

        private void admin_details_Load(object sender, EventArgs e)
        {
            //label2.Text = id;
            ConnectDB();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM ADMINS WHERE AD_ID = :id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", OracleDbType.Varchar2).Value = id;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "ADMINS");
                DataTable dt = ds.Tables["ADMINS"];

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    textBox1.Text = dr["ad_name"].ToString();
                    // textBox2.Text = dr["ad_phone"].ToString();
                    textBox3.Text = dr["ad_phone"].ToString();
                    textBox2.Text = dr["ad_email"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            notifications n = new notifications();
            n.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edits saved successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            notifications n = new notifications();
            n.Show();
            this.Hide();
        }
    }
}

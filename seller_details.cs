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
    public partial class seller_details : Form
    {
        string id;
        OracleConnection conn;
        OracleConnection comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public seller_details()
        {
            InitializeComponent();
        }

        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=IDPG3:1521/XE;USER ID=C##SHREYAS;Password=696996");
            try
            {
                conn.Open();
                //MessageBox.Show("Connected");
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


        private void button2_Click(object sender, EventArgs e)
        {
            current_orders c = new current_orders();
            c.Show();

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SALES_PROJECT.Form1 frm1 = new SALES_PROJECT.Form1();
            frm1.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            seller_item_details s = new seller_item_details();
            s.Show();
            this.Hide();
        }

        private void seller_details_Load(object sender, EventArgs e)
        {
            label1.Text = id;
            ConnectDB();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM SELLERS WHERE SEL_ID = :id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", OracleDbType.Varchar2).Value = id;

                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "SELLERS");
                DataTable dt = ds.Tables["SELLERS"];

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    textBox1.Text = dr["sel_name"].ToString();
                    textBox2.Text = dr["sel_phone"].ToString();
                    textBox3.Text = dr["sel_email"].ToString();
                    textBox4.Text = dr["sel_city"].ToString();
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
        }
    }
}

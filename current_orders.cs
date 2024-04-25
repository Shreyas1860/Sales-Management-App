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
    public partial class current_orders : Form
    {
        String id;
        OracleConnection conn;
        OracleConnection comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public current_orders()
        {
            InitializeComponent();
        }
        public string passingvalue
        {
            get { return id; }
            set { id = value; }
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
        private void button4_Click(object sender, EventArgs e)
        {
            seller_details s = new seller_details();
            s.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            seller_item_details s = new seller_item_details();
            s.Show();
            this.Hide();
        }

        private void current_orders_Load(object sender, EventArgs e)
        {
            label1.Text = id;
            ConnectDB();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "current_orders"; // Stored procedure name
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", OracleDbType.Varchar2).Value = id; // Add parameter for id

            dt = new DataTable();
            da = new OracleDataAdapter(cmd);
            try
            {
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception f)
            {
            }



            conn.Close();

        }
    }
}

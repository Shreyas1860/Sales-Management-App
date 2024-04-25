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
    public partial class completed_orders : Form
    {
        String id;
        OracleConnection conn;
        OracleConnection comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public completed_orders()
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

        private void button1_Click(object sender, EventArgs e)
        {
            shipper_details s = new shipper_details();
            s.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            notifications_shipper ns = new notifications_shipper();
            ns.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void completed_orders_Load(object sender, EventArgs e)
        {
            label1.Text = id;
            ConnectDB();
            try
            {
                OracleCommand cmd = new OracleCommand();



                cmd.Connection = conn;
                cmd.CommandText = "showitemsell"; // Stored procedure name
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", OracleDbType.Varchar2).Value = id; // Add parameter for id

                dt = new DataTable();
                da = new OracleDataAdapter(cmd);
                da.Fill(dt);

                dataGridView2.DataSource = dt;
            }
            catch (Exception f)
            {

            }
            conn.Close();
        
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

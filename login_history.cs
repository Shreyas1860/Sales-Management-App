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
    public partial class login_history : Form
    {
        String id;
        OracleConnection conn;
        OracleConnection comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public login_history()
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
            admin_details a = new admin_details();
            a.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            notifications n = new notifications();
            n.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void login_history_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from customers"; // Stored procedure name
            cmd.CommandType = CommandType.Text;
            dt = new DataTable();
            da = new OracleDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            /*textBox1.Text = string.Empty;
            textBox1.Text = "Seller table";
            OracleCommand command = conn.CreateCommand();
            command.CommandText = "Select * from sellers";
            
            OracleDataReader dr = command.ExecuteReader();
            dr.Read();
            richTextBox1.Text = dr.GetString(0);

            command.Dispose();*/
            conn.Close();
        }

        private void sellerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from sellers"; // Stored procedure name
            cmd.CommandType = CommandType.Text;
            dt = new DataTable();
            da = new OracleDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            /*textBox1.Text = string.Empty;
            textBox1.Text = "Seller table";
            OracleCommand command = conn.CreateCommand();
            command.CommandText = "Select * from sellers";
            
            OracleDataReader dr = command.ExecuteReader();
            dr.Read();
            richTextBox1.Text = dr.GetString(0);

            command.Dispose();*/
            conn.Close();
        }

        private void shipperDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from shippers"; // Stored procedure name
            cmd.CommandType = CommandType.Text;
            dt = new DataTable();
            da = new OracleDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            /*textBox1.Text = string.Empty;
            textBox1.Text = "Seller table";
            OracleCommand command = conn.CreateCommand();
            command.CommandText = "Select * from sellers";
            
            OracleDataReader dr = command.ExecuteReader();
            dr.Read();
            richTextBox1.Text = dr.GetString(0);

            command.Dispose();*/
            conn.Close();
        }
    }
}

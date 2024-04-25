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
    public partial class notifications : Form
    {
        String id;
        OracleConnection conn;
        OracleConnection comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public notifications()
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
            login_history l = new login_history();
            l.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin_details a = new admin_details();
            a.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void notifications_Load(object sender, EventArgs e)
        {
            ConnectDB();
            OracleCommand cmd = new OracleCommand();



            cmd.Connection = conn;
            cmd.CommandText = "select * from log"; // Stored procedure name
            cmd.CommandType = CommandType.Text;
            dt = new DataTable();
            da = new OracleDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}

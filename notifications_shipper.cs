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
    public partial class notifications_shipper : Form
    {
        String id;
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public notifications_shipper()
        {
            InitializeComponent();
        }
        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=IDPG3:1521/XE;;USER ID=C##SHREYAS;Password=696996");
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

        private void button2_Click(object sender, EventArgs e)
        {
            completed_orders c = new completed_orders();
            c.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConnectDB();
            comm = new OracleCommand();
            string sel = comboBox1.SelectedValue.ToString();
            comm.CommandText = "insert into delivery(ship_id,order_id) values ('" + id + ",'" + sel + "')";
            comm.CommandType = CommandType.Text;
            int j = comm.ExecuteNonQuery();
            comm.Dispose();
            comm = new OracleCommand();
            comm.CommandText = "removedel";
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("oid", OracleDbType.Varchar2).Value = sel;
            comm.Parameters.Add("sid", OracleDbType.Varchar2).Value = id;
            conn.Close();
        }

        private void notifications_shipper_Load(object sender, EventArgs e)
        {
            label1.Text = id;
            ConnectDB();

            comm = new OracleCommand();
            comm.CommandText = "select order_id from delivery where ship_id='" + id + "' and collected='false'";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "delivery");
            dt = ds.Tables["delivery"];
            int t = dt.Rows.Count; MessageBox.Show(t.ToString());
            comboBox1.DataSource = dt.DefaultView;
            comboBox1.DisplayMember = "order_id";
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class add_items : Form
    {

        String id;
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        int quantity = 0;
        int totprice = 0;
        String itemId;
        String orderId1;
        public add_items()
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

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("item added successfully");
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("items bought successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            item_details i = new item_details();
            i.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void add_items_Load(object sender, EventArgs e)
        {
            label2.Text = id;
            OrderIdGenerator generator = new OrderIdGenerator("O");
            orderId1 = generator.GenerateOrderId();

            comm = new OracleCommand();
            comm.CommandText = "select item_name from items where quantity>0";
            comm.CommandType = CommandType.Text;
            //ds = new DataSet();
            //da = new OracleDataAdapter(comm.CommandText, conn);
            //da.Fill(ds, "items");
            //dt = ds.Tables["items"];
            //int t = dt.Rows.Count;
            //MessageBox.Show(t.ToString());
            //comboBox1.DataSource = dt.DefaultView;
            //comboBox1.DisplayMember = "item_name";
            // Get the selected item_name from the comboBox
            string selectedItemName = comboBox1.Text;

            // Create a new OracleCommand
            comm = new OracleCommand();

            comm.CommandText = "SELECT item_id FROM items WHERE item_name = :selectedItemName";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new OracleParameter(":selectedItemName", selectedItemName));

            // Open the connection and execute the command
            //OracleDataReader reader = comm.ExecuteReader();

            //if (reader.Read())
            //{
                // Retrieve the item_id from the reader
             //   itemId = reader["item_id"].ToString();
            //}

            //reader.Close();

            //comm = new OracleCommand();
            //int maxq = 0;
            //comm.CommandText = "SELECT quantity FROM items WHERE item_id = :itemId";
            //comm.CommandType = CommandType.Text;
            //comm.Parameters.Add(new OracleParameter(":itemId", itemId));
            //reader = comm.ExecuteReader();

            //if (reader.Read())
            //{
            //    maxq = Convert.ToInt32(reader["quantity"]);
            //}

            //reader.Close();

//            numericUpDown1.Maximum = maxq;



            //conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ConnectDB();

            int quantity = (int)numericUpDown1.Value;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO order_items(order_id, item_id, units) VALUES (:orderId, :itemId, :itemQuantity)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new OracleParameter(":orderId", orderId1));
            cmd.Parameters.Add(new OracleParameter(":itemId", itemId));
            cmd.Parameters.Add(new OracleParameter(":itemQuantity", quantity));

            int rowsAffected = cmd.ExecuteNonQuery();
            cmd.Dispose();

            OracleCommand comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "SELECT item_price FROM items WHERE item_id = :itemId";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new OracleParameter(":itemId", itemId));

            OracleDataReader reader = comm.ExecuteReader();
            int price = 0;

            if (reader.Read())
            {
                price = Convert.ToInt32(reader["item_price"]);
            }

            reader.Close();

            totprice += quantity * price;
            label6.Text = totprice.ToString();
            cmd.Dispose();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select item_id, item_name, quantity,item_price from order_items NATURAL JOIN items WHERE cust_id=:custid"; // Stored procedure name
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new OracleParameter(":custid", id));
            dt = new DataTable();
            da = new OracleDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;


            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
    public class OrderIdGenerator
    {
        private int counter;
        private string prefix;
        OracleConnection conn;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public void ConnectDB()
        {
            conn = new OracleConnection("DATA SOURCE=IDPG3:1521/XE;USER ID=C##SHREYAS;Password=696996");
            try
            {
                conn.Open();
                MessageBox.Show("Connected");
            }
            catch (Exception e1)
            {
            }
        }
        public OrderIdGenerator(string prefix)
        {
            this.prefix = prefix;
            ConnectDB();
            //conn.Open();
            
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "SELECT SUBSTR(order_id, 1, 1), MAX(TO_NUMBER(SUBSTR(order_id, 2))) FROM orders";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            int maxOrderId = 0;


            //object result = cmd.ExecuteScalar();
            //cmd.Dispose();
            //if (result != DBNull.Value)
            //{
            //    maxOrderId = Convert.ToInt32(result);
            //}
            this.counter = maxOrderId;
        }
        public string GenerateOrderId()
        {
            counter++;
            return prefix + counter.ToString("D3");
        }
    }
}

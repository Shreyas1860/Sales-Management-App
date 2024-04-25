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
    public partial class seller_item_details : Form
    {
        String id;
        OracleConnection conn;
        OracleConnection comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        public seller_item_details()
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

        private void button3_Click(object sender, EventArgs e)
        {
            current_orders i = new current_orders();
            i.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            seller_details s = new seller_details();
            s.Show();
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
            OracleCommand cmd = new OracleCommand();
            string name = textBox1.Text;
            OrderIdGenerator generator = new OrderIdGenerator("0");
            OracleTransaction trans = conn.BeginTransaction();

            string itemId12 = generator.GenerateOrderId();
            MessageBox.Show(itemId12);
            int itemId1 = int.Parse(itemId12);
            float value = float.Parse(textBox2.Text); // Convert to float
            int qty = (int)numericUpDown1.Value;


            cmd = new OracleCommand();
            cmd.Connection = conn;
            //conn.Open();
            cmd.CommandText = "INSERT INTO items (item_id, item_name, item_price, quantity) VALUES (:itemId1, :name, :value, :qty)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new OracleParameter(":itemId1", itemId1));
            cmd.Parameters.Add(new OracleParameter(":name", name));
            cmd.Parameters.Add(new OracleParameter(":value", OracleDbType.Decimal)).Value = value;
            cmd.Parameters.Add(new OracleParameter(":qty", qty));

            //int j = cmd.ExecuteNonQuery();
            trans.Commit();
            cmd.Dispose();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO sells (sel_id, item_id) VALUES (:selId, :itemId)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new OracleParameter(":selId", id));
            cmd.Parameters.Add(new OracleParameter(":itemId", itemId1));

            //j = cmd.ExecuteNonQuery();

            cmd.Dispose();

            conn.Close();
        }

        private void seller_item_details_Load(object sender, EventArgs e)
        {
            label1.Text = id;
            ConnectDB(); // Assuming this function establishes the database connection

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SHOWITEMSELL"; // Stored procedure name
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
                // Handle the exception appropriately
                MessageBox.Show("Error: " + f.Message);
            }

            conn.Close();

        }

        private void AddItems_Enter(object sender, EventArgs e)
        {

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
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "SELECT SUBSTR(item_id, 1, 1), MAX(TO_NUMBER(SUBSTR(item_id, 2))) FROM items";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                int maxOrderId = 0;
                object result = null;
                try
                {
                    result = cmd.ExecuteScalar();
                }
                catch (Exception e)
                {
                    // Handle the exception, display an error message, or log the error.
                    Console.WriteLine("Error executing query: " + e.Message);
                }

                if (result != null && result != DBNull.Value)
                {
                    if (int.Parse(result.ToString()) != 0)
                    {
                        maxOrderId = int.Parse(result.ToString());
                    }
                    else
                    {
                        // Handle the case where the result cannot be parsed to an integer.
                        Console.WriteLine("Error parsing result to integer.");
                    }
                }

                this.counter = maxOrderId;
            }
            public string GenerateOrderId()
            {
                counter++;
                return prefix + counter.ToString("D3");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

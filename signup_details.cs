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
    public partial class signup_details : Form
    {
        OracleConnection conn;
        public static Form1 instance;
        OracleConnection comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        public signup_details()
        {
            InitializeComponent();
        }
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


        private void button1_Click(object sender, EventArgs e)
        {
              ConnectDB();
            String name = textBox4.Text;
            String phno = textBox3.Text;
            String email = textBox2.Text;
            String city = textBox1.Text;
            String type= comboBox1.SelectedText;
            String date = dateTimePicker1.Value.ToShortDateString();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText="insert into log(name,phno,email,citytype,dob,type,reason) values('"+name+"','"+phno+"','"+email+"','"+city+"', to_date('"+date+"','dd-mm-yyyy'),'"+type+"', 'signup')";
            cmd.CommandType=CommandType.Text;
            int j=cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            MessageBox.Show("Signup Completed");
                Form1 f = new Form1();
                f.Show();
                this.Hide();
           }
    
        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void DETAILS_Enter(object sender, EventArgs e)
        {

        }

        private void signup_details_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Forgot_password : Form
    {
        OracleConnection conn;
        public Forgot_password()
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             ConnectDB();
            String ID = textBox2.Text;
            String name = textBox1.Text;
            String phno = textBox4.Text;
            String email = textBox3.Text;
            String city = textBox6.Text;
            String type= comboBox1.SelectedText;
            String date = dateTimePicker1.Value.ToShortDateString();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText="insert into log(id,name,phno,email,city,type) values('"+ID+"','"+name+"','"+phno+"','"+email+"','"+city+"', to_date('"+date+"','dd-mm-yyyy'),'"+type+"','forgot password')";
            cmd.CommandType=CommandType.Text;
            cmd.ExecuteNonQuery();
                MessageBox.Show("Check inbox in 24-48hrs for login details");
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();
            
        }

        private void Forgot_password_Load(object sender, EventArgs e)
        {

        }
    }
}

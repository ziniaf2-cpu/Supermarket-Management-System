using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;



namespace SuperMarket
{
     class Customer
    {
        public int cId { get; set; }
        public string cName { get; set; }
        public int cPhone { get; set; }
        public string cAddress { get; set; }
    }
    public partial class Form7 : Form
    {

        string connection = @"Data Source=localhost\SQLEXPRESS;Database=smms;Trusted_Connection=True;";

        public Form7()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            Customer customer = new Customer();


            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
           

            customer.cId = Convert.ToInt32(textBox1.Text);
            customer.cName = textBox2.Text;
            customer.cPhone = Convert.ToInt32(textBox3.Text);
            customer.cAddress = textBox4.Text;
            try
            {
                string q = "Insert into customer (cId, cName, cPhone,cAddress) values " +
                    "(@Id, @Name, @Phone, @Address)";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@Id", customer.cId);
                cmd.Parameters.AddWithValue("@Name", customer.cName);
                cmd.Parameters.AddWithValue("@Phone", customer.cPhone);
                cmd.Parameters.AddWithValue("@Address", customer.cAddress);

                cmd.ExecuteNonQuery();
               
            }

            finally
            {
                conn.Close();
            }
        }
    }
}

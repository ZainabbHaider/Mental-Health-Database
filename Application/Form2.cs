using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MentalHealthDtabase
{
    public partial class Form2 : Form
    {
        const string constr = @"Data Source=DESKTOP-HP7DSP0;Initial Catalog=Mental Health System;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql0 = "select ID from Patient";
            con.Open();
            cm = new SqlCommand(sql0, con);
            SqlDataAdapter da0 = new SqlDataAdapter(cm);
            DataTable dt0 = new DataTable();
            da0.Fill(dt0);
            string sql = "insert into Patient values(@ID, @Name, @Age, @Gender, @Username, @Password) ";
            cm = new SqlCommand(sql, con);
            Random r = new Random();
            int num = r.Next(1, 10000);
            foreach (DataRow dr in dt0.Rows)
            {
                if (num.ToString() == dr["ID"].ToString())
                {
                    num = r.Next(1, 10000);
                }
            }
            cm.Parameters.AddWithValue("@ID", num);
            cm.Parameters.AddWithValue("@Name", textBox1.Text);
            cm.Parameters.AddWithValue("@Age", Convert.ToInt32(textBox2.Text));
            cm.Parameters.AddWithValue("@Gender", textBox6.Text);
            cm.Parameters.AddWithValue("@Username", textBox3.Text);
            cm.Parameters.AddWithValue("@Password", textBox4.Text);
            cm.ExecuteNonQuery();
            con.Close();
            this.Hide();
            var form1 = new Login();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

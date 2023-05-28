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
    public partial class Form11 : Form
    {
        const string constr = @"Data Source=DESKTOP-HP7DSP0;Initial Catalog=Mental Health System;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public static string ID = "";
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql0 = "select ID from Medical_Professionals";
            con.Open();
            cm = new SqlCommand(sql0, con);
            SqlDataAdapter da0 = new SqlDataAdapter(cm);
            DataTable dt0 = new DataTable();
            da0.Fill(dt0);
            string sql2 = "select ClinicID from Clinic where ClinicName = @clinicname";
            //con.Open();
            cm = new SqlCommand(sql2, con);
            cm.Parameters.AddWithValue("@clinicname", comboBox1.Text);
            SqlDataAdapter da5 = new SqlDataAdapter(cm);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            string sql = "insert into Medical_Professionals values(@ID, @Name, @Age, @Gender,@Specialisation, @ClinicId , @Fees, @Username, @Password) ";
            cm = new SqlCommand(sql, con);
            Random r = new Random();
            int num = r.Next(1, 100000);
            foreach (DataRow dr in dt0.Rows)
            {
                if (num.ToString() == dr["ID"].ToString())
                {
                    num = r.Next(1, 100000);
                }
            }
            ID = num.ToString();
            cm.Parameters.AddWithValue("@ID", num.ToString());
            cm.Parameters.AddWithValue("@Name", textBox1.Text);
            cm.Parameters.AddWithValue("@Age", Convert.ToInt32(textBox2.Text));
            cm.Parameters.AddWithValue("@Specialisation", comboBox2.Text);
            cm.Parameters.AddWithValue("@ClinicId", dt5.Rows[0].ItemArray[0].ToString());
            cm.Parameters.AddWithValue("@Fees", Convert.ToDecimal(textBox7.Text));
            cm.Parameters.AddWithValue("@Gender", comboBox3.Text);
            cm.Parameters.AddWithValue("@Username", textBox3.Text);
            cm.Parameters.AddWithValue("@Password", textBox4.Text.ToString());
            cm.ExecuteNonQuery();
            con.Close();
            this.Hide();
            var form13 = new Form13();
            form13.Closed += (s, args) => this.Close();
            form13.Show();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            con.Open();
            cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = " select distinct ClinicName from Clinic";
            cm.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cm);
            da1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                comboBox1.Items.Add(dr["ClinicName"].ToString());
            }
            comboBox2.Items.Clear();
            //con.Open();
            cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = " select distinct Specialisation from Medical_Professionals";
            cm.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cm);
            da2.Fill(dt2);

            foreach (DataRow dr in dt2.Rows)
            {
                comboBox2.Items.Add(dr["Specialisation"].ToString());
            }
            comboBox3.Items.Clear();
            comboBox3.Items.Add("Male");
            comboBox3.Items.Add("Female");
            con.Close();
        }
    }
}

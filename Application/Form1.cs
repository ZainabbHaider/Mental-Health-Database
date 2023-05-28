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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace MentalHealthDtabase
{   
    public partial class Login : Form
    {
        const string constr = @"Data Source=DESKTOP-HP7DSP0;Initial Catalog=Mental Health System;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public static string user = "";
        public static string PorD = "";
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (PatientRadioButton.Checked)
            {
                PorD = "P";
                con.Open();
                cm = con.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = " select username from Patient";
                cm.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cm);
                da1.Fill(dt2);
                bool check = false;
                foreach (DataRow dr in dt2.Rows)
                {
                    //Console.WriteLine(dr["username"].ToString());
                    if (textBox1.Text == dr["username"].ToString())
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    user = textBox1.Text;
                    string sql1 = "select password from patient where username = @user";
                    cm = new SqlCommand(sql1, con);
                    cm.Parameters.AddWithValue("@user", user);
                    cm.ExecuteNonQuery();
                    SqlDataAdapter da5 = new SqlDataAdapter(cm);
                    DataTable dt5 = new DataTable();
                    da5.Fill(dt5);
                    if (textBox2.Text == dt5.Rows[0].ItemArray[0].ToString())
                    {
                        this.Hide();
                        var form3 = new Form3();
                        form3.Closed += (s, args) => this.Close();
                        form3.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                    
                    
                }
                else
                {
                    this.Hide();
                    MessageBox.Show("Username not found!");
                    this.Hide();
                    var form1 = new Login();
                    form1.Closed += (s, args) => this.Close();
                    form1.Show();
                }
                con.Close();
            }
            else if (DoctorRdioButton.Checked)
            {
                PorD = "D";
                con.Open();
                cm = con.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = " select username from Medical_Professionals";
                cm.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cm);
                da1.Fill(dt2);
                bool check = false;
                foreach (DataRow dr in dt2.Rows)
                {
                    if (textBox1.Text == dr["username"].ToString())
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    user = textBox1.Text;
                    string sql1 = "select password from Medical_professionals where username = @user";
                    cm = new SqlCommand(sql1, con);
                    cm.Parameters.AddWithValue("@user", user);
                    cm.ExecuteNonQuery();
                    SqlDataAdapter da5 = new SqlDataAdapter(cm);
                    DataTable dt5 = new DataTable();
                    da5.Fill(dt5);
                    /*Console.WriteLine("inside check");
                    Console.WriteLine(textBox2.Text);
                    Console.WriteLine(dt5.Rows[0].ItemArray[0].ToString());*/
                    if (Convert.ToInt32(textBox2.Text) == Convert.ToInt32(dt5.Rows[0].ItemArray[0].ToString()))
                    {
                        //Console.WriteLine("inside password if");
                        this.Hide();
                        var form14 = new Form14();
                        form14.Closed += (s, args) => this.Close();
                        form14.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                }
                else
                {
                    this.Hide();
                    MessageBox.Show("Username not found!");
                    this.Hide();
                    var form1 = new Login();
                    form1.Closed += (s, args) => this.Close();
                    form1.Show();
                }
                con.Close();
            }

            //Form3 form3 = new Form3();
            //form3.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form10 = new Form10();
            form10.Closed += (s, args) => this.Close();
            form10.Show();
            //Form2 form2 = new Form2();  
            //form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*int check = 0;
            if (PatientRadioButton.Checked)
            {
                con.Open();
                cm = con.CreateCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = " select username from Patient";
                cm.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cm);
                da1.Fill(dt1);
                

                foreach (DataRow dr in dt1.Rows)
                {
                    if (textBox1.Text == dr.ToString())
                    {
                        check = 1;

                    }

                }
                con.Close();
            }*/
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

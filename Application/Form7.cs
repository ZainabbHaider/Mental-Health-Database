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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MentalHealthDtabase
{
    public partial class Form7 : Form
    {
        const string constr = @"Data Source=DESKTOP-HP7DSP0;Initial Catalog=Mental Health System;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public string Username { get; set; }
        public Form7()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Login.PorD == "P")
            {
                this.Hide();
                var form3 = new Form3();
                form3.Closed += (s, args) => this.Close();
                form3.Show();
            }
            else if (Login.PorD == "D")
            {
                this.Hide();
                var form14 = new Form14();
                form14.Closed += (s, args) => this.Close();
                form14.Show();
            }
            
            //this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Login();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
            //Form1 form1 = new Form1();
            //form1.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form9 = new Form9();
            form9.Closed += (s, args) => this.Close();
            form9.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form12 = new Form12();
            form12.Closed += (s, args) => this.Close();
            form12.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            //Console.WriteLine(Username);
            con.Open();
            cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            if (Login.PorD == "P") { 
                cm.CommandText = " select Name, Age, Gender from Patient where username = @user"; 
            }
            else if (Login.PorD == "D")
            {
                cm.CommandText = " select Name, Age, Gender from Medical_PRofessionals where username = @user";
            }
            //cm.CommandText = " select Name, Age, Gender from Patient where username = @user";
            cm.Parameters.AddWithValue("@user", Login.user);
            cm.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cm);
            da1.Fill(dt1);
            label4.Text = (dt1.Rows[0].ItemArray[0].ToString());
            label5.Text = (dt1.Rows[0].ItemArray[1].ToString());
            label6.Text = (dt1.Rows[0].ItemArray[2].ToString());
            label9.Text = Login.user;
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
             
            if (Login.PorD == "P")
            {
                string sql1 = "delete Appointments where PatientID = (select ID from Patient where username = @user)";
                con.Open();
                cm = new SqlCommand(sql1, con);
                cm.Parameters.AddWithValue("@user", Login.user);
                cm.ExecuteNonQuery();
                string sql3 = "delete Patient_Diagnosis_to_symptoms where diagnosisID = (select DiagnosisID from Patient_Diagnosis where PatientID = (select ID from Patient where username = @user))";
                cm = new SqlCommand(sql3, con);
                cm.Parameters.AddWithValue("@user", Login.user);
                cm.ExecuteNonQuery();
                string sql2 = "delete Patient_Diagnosis where PatientID = (select ID from Patient where username = @user)";
                cm = new SqlCommand(sql2, con);
                cm.Parameters.AddWithValue("@user", Login.user);
                cm.ExecuteNonQuery();
                string sql = "delete patient where username = @username";
                cm = new SqlCommand(sql, con);
                cm.Parameters.AddWithValue("@username", Login.user);
                cm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete Successful");
                this.Hide();
                var form1 = new Login();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            else if (Login.PorD == "D")
            {
                string sql1 = "delete schedule where MedicalProfessionalID = (select ID from Medical_Professionals where username = @user)";
                con.Open();
                cm = new SqlCommand(sql1, con);
                cm.Parameters.AddWithValue("@user", Login.user);
                cm.ExecuteNonQuery();
                string sql = "delete Medical_Professionals where username = @username";
                cm = new SqlCommand(sql, con);
                cm.Parameters.AddWithValue("@username", Login.user);
                cm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete Successful");
                this.Hide();
                var form1 = new Login();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            //string sql = "delete into schedule values(@ID, @MID, @TS1, @TS2)";
            //con.Open();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form7 = new Form7();
            form7.Closed += (s, args) => this.Close();
            form7.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form15 = new Form15();
            form15.Closed += (s, args) => this.Close();
            form15.Show();
        }
    }
}

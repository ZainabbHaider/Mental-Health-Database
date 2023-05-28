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
    public partial class Form4 : Form
    {
        const string constr = @"Data Source=DESKTOP-HP7DSP0;Initial Catalog=Mental Health System;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public static string Date = "";
        public static string Time = "";
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            con.Open();
            cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = " select Name from Medical_Professionals";
            cm.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cm);
            da1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                comboBox1.Items.Add(dr["Name"].ToString());
            }

            /*comboBox2.Items.Clear();
            cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = " select distinct ClinicName from Clinic";
            cm.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cm);
            da2.Fill(dt2);

            foreach (DataRow dr in dt2.Rows)
            {
                comboBox2.Items.Add(dr["ClinicName"].ToString());
            }
            */
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
            //this.DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form7 = new Form7();
            form7.Closed += (s, args) => this.Close();
            form7.Show();
            //Form7 form7 = new Form7();
            //form7.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql3 = "select Date, TimeSlot, Doctor from Appointments";
            con.Open();
            cm = new SqlCommand(sql3, con);
            //cm.Parameters.AddWithValue("@name", comboBox1.Text);
            cm.ExecuteNonQuery();
            SqlDataAdapter da2 = new SqlDataAdapter(cm);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            bool check3 = true;
            //bool check4 = true;
            foreach (DataRow dr in dt2.Rows)
            {
                //Console.WriteLine(dr["username"].ToString());
                if (radioButton3.Checked)
                {
                    /*var datetime = Convert.ToDateTime(dr["Date"]);
                    var Date = datetime.ToShortDateString();
                    Console.WriteLine(dateTimePicker1.Value);*/
                    //Console.WriteLine(Convert.ToDateTime(dateTimePicker1.Text));
                    //Console.WriteLine(Convert.ToDateTime(dr["Date"]));
                    if (comboBox1.Text == dr["Doctor"].ToString() & Convert.ToDateTime(dateTimePicker1.Text) == Convert.ToDateTime(dr["Date"]) & radioButton3.Text == dr["TimeSlot"].ToString())
                    {
                        check3 = false;
                        break;
                        /*MessageBox.Show("not available!");*/
                    
                    }
                    else
                    {
                        check3 = true;
                    }
                }
                else if (radioButton4.Checked)
                {
                    if (comboBox1.Text == dr["Doctor"].ToString() & Convert.ToDateTime(dateTimePicker1.Text) == Convert.ToDateTime(dr["Date"]) & radioButton4.Text == dr["TimeSlot"].ToString())
                    {
                        check3 = false;
                        break;
                    }
                    else
                    {
                        check3 = true;

                    }
                }
            }
            if (check3)
            {
                string sql1 = "select ID from patient where username = @user";
                cm = new SqlCommand(sql1, con);
                cm.Parameters.AddWithValue("@user", Login.user);
                SqlDataAdapter da5 = new SqlDataAdapter(cm);
                DataTable dt5 = new DataTable();
                da5.Fill(dt5);
                string sql2 = "select s.ID from Schedule s, Medical_Professionals m where s.MedicalProfessionalID = m.ID and m.Name = @name";
                cm = new SqlCommand(sql2, con);
                cm.Parameters.AddWithValue("@name", comboBox1.Text);
                SqlDataAdapter da6 = new SqlDataAdapter(cm);
                DataTable dt6 = new DataTable();
                da6.Fill(dt6);
                string sql0 = "select ID from Appointments";
                cm = new SqlCommand(sql0, con);
                SqlDataAdapter da0 = new SqlDataAdapter(cm);
                DataTable dt0 = new DataTable();
                da0.Fill(dt0);
                string sql = "insert into Appointments values(@ID, @Date, @Location, @PatientID, @MoT, @status, @TimeSlot, @Doctor)";
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
                int mot = -1;
                if (radioButton1.Checked)
                {
                    mot = 1;
                }
                else if (radioButton2.Checked)
                {
                    mot = 0;
                }
                cm.Parameters.AddWithValue("@ID", num);
                cm.Parameters.AddWithValue("@Date", Convert.ToDateTime(dateTimePicker1.Text));
                cm.Parameters.AddWithValue("@Location", comboBox2.Text);
                cm.Parameters.AddWithValue("@PatientID", dt5.Rows[0].ItemArray[0].ToString());
                cm.Parameters.AddWithValue("@MoT", mot);
                //cm.Parameters.AddWithValue("@ScheduleID", dt6.Rows[0].ItemArray[0].ToString());
                cm.Parameters.AddWithValue("@status", "Scheduled");
                if (radioButton3.Checked)
                {
                    Time = radioButton3.Text;
                    cm.Parameters.AddWithValue("@TimeSlot", radioButton3.Text);
                }
                else if (radioButton4.Checked)
                {
                    Time = radioButton4.Text;
                    cm.Parameters.AddWithValue("@TimeSlot", radioButton4.Text);
                }
                
                cm.Parameters.AddWithValue("@Doctor", comboBox1.Text);
                cm.ExecuteNonQuery();

                Date = dateTimePicker1.Text;
                //Time = radioButton3.Text;
                this.Hide();
                Form8 reciept = new Form8();
                reciept.PatientName = textBox1.Text;
                reciept.EmailAddress = textBox2.Text;
                reciept.contactNumber = textBox3.Text;
                reciept.Doctor = comboBox1.Text;
                reciept.ShowDialog();
            }
            else if (!check3)
            {
                MessageBox.Show("Not Available");
            }
            con.Close();
        }

        private void dataGridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select s.TimeSlot1, s.TimeSlot2 from Schedule s, Medical_Professionals m where m.ID = s.MedicalProfessionalID and m.Name = @name";
            con.Open();
            cm = new SqlCommand(sql, con);
            cm.Parameters.AddWithValue("@name", comboBox1.Text);
            cm.ExecuteNonQuery();
            SqlDataAdapter da5 = new SqlDataAdapter(cm);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            radioButton3.Text = dt5.Rows[0].ItemArray[0].ToString();
            radioButton4.Text = dt5.Rows[0].ItemArray[1].ToString();
            comboBox2.Items.Clear();
            string sql1 = "select c.ClinicName from CLinic c, Medical_Professionals m where c.ClinicID = m.ClinicID and m.Name = @name";
            cm = new SqlCommand(sql1, con);
            cm.Parameters.AddWithValue("@name", comboBox1.Text);
            cm.ExecuteNonQuery();
            SqlDataAdapter da1 = new SqlDataAdapter(cm);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();
            foreach (DataRow dr in dt1.Rows)
            {
                comboBox2.Items.Add(dr["ClinicName"].ToString());
            }
    
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

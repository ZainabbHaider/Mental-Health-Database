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
using static MentalHealthDtabase.Form6;

namespace MentalHealthDtabase
{
    public partial class Form6 : Form
    {
        const string constr = @"Data Source=DESKTOP-HP7DSP0;Initial Catalog=Mental Health System;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public class Doctor
        {
            public string Specialisation;
            public string Name;
            public string Location;
            public Doctor(string _Specialisation, string _Name, string _Location)
            {
                Specialisation = _Specialisation;
                Name = _Name;
                Location = _Location;
            }
        }
        List<Doctor> Doctors = new List<Doctor>();
        public Form6()
        {
            InitializeComponent();
            con.Open();
            cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = " select M.Name, M.Specialisation, C.ClinicLocation from Medical_Professionals M, Clinic C where M.ClinicID = C.ClinicID";
            cm.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cm);
            da1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                Doctors.Add(new Doctor(dr["Specialisation"].ToString(), dr["Name"].ToString(), dr["ClinicLocation"].ToString()));
            }
            
            foreach (Doctor b in Doctors)
            {
                Results.Items.Add(b.Name + "/" + b.Specialisation + "/" + b.Location);
            }
            con.Close();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            con.Open();
            cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = " select distinct Specialisation from Medical_Professionals";
            cm.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cm);
            da1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                comboBox1.Items.Add(dr["Specialisation"].ToString());
            }
            comboBox2.Items.Clear();
            /*cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = " select Name from Medical_Professionals";
            cm.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter(cm);
            da3.Fill(dt3);

            foreach (DataRow dr in dt3.Rows)
            {
                comboBox2.Items.Add(dr["Name"].ToString());
            }*/
            comboBox2.Items.Add("2000-4000");
            comboBox2.Items.Add("4000-6000");
            comboBox2.Items.Add("6000-8000");
            //comboBox2.Items.Add("2000-4000");
            /*comboBox4.Items.Clear();
            cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = " select distinct ClinicLocation from Clinic";
            cm.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cm);
            da2.Fill(dt2);

            foreach (DataRow dr in dt2.Rows)
            {
                comboBox4.Items.Add(dr["ClinicLocation"].ToString());
            }*/
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

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
            if (comboBox1.SelectedIndex == 0)
            {
                for (int n = Results.Items.Count - 1; n >= 0; --n)
                {
                    string[] book_info = Results.Items[n].ToString().Split('/');
                    string removelistitem = "Primary Doctor";

                    if (!(book_info[1].Contains(removelistitem)))
                    {
                        Results.Items.RemoveAt(n);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                for (int n = Results.Items.Count - 1; n >= 0; --n)
                {
                    string[] book_info = Results.Items[n].ToString().Split('/');
                    string removelistitem = "Psychiatrist";

                    if (!(book_info[1].Contains(removelistitem)))
                    {
                        Results.Items.RemoveAt(n);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                for (int n = Results.Items.Count - 1; n >= 0; --n)
                {
                    string[] book_info = Results.Items[n].ToString().Split('/');
                    string removelistitem = "Psychoanalyst";

                    if (!(book_info[1].Contains(removelistitem)))
                    {
                        Results.Items.RemoveAt(n);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                for (int n = Results.Items.Count - 1; n >= 0; --n)
                {
                    string[] book_info = Results.Items[n].ToString().Split('/');
                    string removelistitem = "Psychologist";

                    if (!(book_info[1].Contains(removelistitem)))
                    {
                        Results.Items.RemoveAt(n);
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                for (int n = Results.Items.Count - 1; n >= 0; --n)
                {
                    string[] book_info = Results.Items[n].ToString().Split('/');
                    string removelistitem = "Therapist";

                    if (!(book_info[1].Contains(removelistitem)))
                    {
                        Results.Items.RemoveAt(n);
                    }
                }
            }
            if (comboBox2.SelectedIndex == 0)
            {
                for (int n = Results.Items.Count - 1; n >= 0; --n)
                {
                    string[] book_info = Results.Items[n].ToString().Split('/');
                    con.Open();
                    cm = con.CreateCommand();
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select Name from Medical_Professionals where fees >= @Gfees and fees <=@Lfees";
                    cm.Parameters.AddWithValue("@Gfees", 2000);
                    cm.Parameters.AddWithValue("@Lfees", 4000);
                    cm.ExecuteNonQuery();
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(cm);
                    da1.Fill(dt1);
                    con.Close();
                    bool check =  false;
                    foreach (DataRow dr in dt1.Rows)
                    {
                        if (!(book_info[0].Contains(dr["Name"].ToString())))
                        {
                            check = true;
                        }
                        else
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check)
                    {
                        Results.Items.RemoveAt(n);
                    }

                    
                }
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                for (int n = Results.Items.Count - 1; n >= 0; --n)
                {
                    string[] book_info = Results.Items[n].ToString().Split('/');
                    con.Open();
                    cm = con.CreateCommand();
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select Name from Medical_Professionals where fees >= @Gfees and fees <=@Lfees";
                    cm.Parameters.AddWithValue("@Gfees", 4001);
                    cm.Parameters.AddWithValue("@Lfees", 6000);
                    cm.ExecuteNonQuery();
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(cm);
                    da1.Fill(dt1);
                    con.Close();
                    bool check = false;
                    foreach (DataRow dr in dt1.Rows)
                    {
                        if (!(book_info[0].Contains(dr["Name"].ToString())))
                        {
                            check = true;
                        }
                        else
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check)
                    {
                        Results.Items.RemoveAt(n);
                    }
                }
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                for (int n = Results.Items.Count - 1; n >= 0; --n)
                {
                    string[] book_info = Results.Items[n].ToString().Split('/');
                    con.Open();
                    cm = con.CreateCommand();
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select Name from Medical_Professionals where fees >= @Gfees and fees <=@Lfees";
                    cm.Parameters.AddWithValue("@Gfees", 6001);
                    cm.Parameters.AddWithValue("@Lfees", 8000);
                    cm.ExecuteNonQuery();
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(cm);
                    da1.Fill(dt1);
                    con.Close();
                    bool check = false;
                    foreach (DataRow dr in dt1.Rows)
                    {
                        if (!(book_info[0].Contains(dr["Name"].ToString())))
                        {
                            check = true;
                        }
                        else
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check)
                    {
                        Results.Items.RemoveAt(n);
                    }
                }
            }
        }

        private void Results_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Results.Items.Clear();
            foreach (Doctor b in Doctors)
            {
                Results.Items.Add(b.Name + "/" + b.Specialisation + "/" + b.Location);
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

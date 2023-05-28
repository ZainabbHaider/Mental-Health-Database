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
    public partial class Form9 : Form
    {
        const string constr = @"Data Source=DESKTOP-HP7DSP0;Initial Catalog=Mental Health System;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public Form9()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadAppointments()
        {
            // TODO: Complete the function LoadEmployees
            // SQL query to select EmployeeID, FirstName, LastName from Employees
            con.Open();
            string sql = "select a.ID, a.Date, a.Doctor, a.Status from Appointments a, Patient p where p.ID = a.PatientID and p.Username = @username";

            cm = new SqlCommand(sql, con);
            cm.Parameters.AddWithValue("@username", Login.user);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            LoadAppointments();
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

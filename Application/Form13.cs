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

namespace MentalHealthDtabase
{
    public partial class Form13 : Form
    {
        const string constr = @"Data Source=DESKTOP-HP7DSP0;Initial Catalog=Mental Health System;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public Form13()
        {
            InitializeComponent();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql0 = "select ID from Medical_Professionals";
            con.Open();
            cm = new SqlCommand(sql0, con);
            SqlDataAdapter da0 = new SqlDataAdapter(cm);
            DataTable dt0 = new DataTable();
            da0.Fill(dt0);
            string sql = "insert into schedule values(@ID, @MID, @TS1, @TS2)";
            //con.Open();
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
            cm.Parameters.AddWithValue("@ID", num.ToString());
            cm.Parameters.AddWithValue("@MID", Form11.ID);
            if (radioButton1.Checked)
            {
                cm.Parameters.AddWithValue("@TS1", radioButton1.Text);
            }
            else if (radioButton2.Checked)
            {
                cm.Parameters.AddWithValue("@TS1", radioButton2.Text);
            }
            else if (radioButton3.Checked)
            {
                cm.Parameters.AddWithValue("@TS1", radioButton3.Text);
            }
            else if (radioButton4.Checked)
            {
                cm.Parameters.AddWithValue("@TS1", radioButton4.Text);
            }
            if (radioButton5.Checked)
            {
                cm.Parameters.AddWithValue("@TS2", radioButton5.Text);
            }
            else if (radioButton6.Checked)
            {
                cm.Parameters.AddWithValue("@TS2", radioButton6.Text);
            }
            else if (radioButton7.Checked)
            {
                cm.Parameters.AddWithValue("@TS2", radioButton7.Text);
            }
            else if (radioButton8.Checked)
            {
                cm.Parameters.AddWithValue("@TS2", radioButton8.Text);
            }
            cm.ExecuteNonQuery();
            con.Close();
            this.Hide();
            var form1 = new Login();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }
    }
}

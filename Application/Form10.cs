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
    public partial class Form10 : Form
    {
        const string constr = @"Data Source=DESKTOP-HP7DSP0;Initial Catalog=Mental Health System;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.Hide();
                var form11 = new Form11();
                form11.Closed += (s, args) => this.Close();
                form11.Show();
            }
            else if (radioButton2.Checked)
            {
                this.Hide();
                var form2 = new Form2();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MentalHealthDtabase
{
    public partial class Form5 : Form
    {
        const string constr = @"Data Source=DESKTOP-HP7DSP0;Initial Catalog=Mental Health System;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cm = new SqlCommand();
        public class Illness
        {
            public string Name;
            //public string Symptoms;
            public Illness(string _Name)
            {
                Name = _Name;
                //Symptoms = _symptoms;
            }
        }
        List<Illness> Ilnesses = new List<Illness>();
        public Form5()
        {
            InitializeComponent();
            con.Open();
            cm = con.CreateCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = " select Name, Symptoms from Illness";
            cm.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cm);
            da1.Fill(dt1);

            foreach (DataRow dr in dt1.Rows)
            {
                Console.WriteLine(dr["Name"].ToString());
                Ilnesses.Add(new Illness(dr["Name"].ToString()));
            }

            foreach (Illness b in Ilnesses)
            {
                listBox1.Items.Add(b.Name);
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string symptoms = "";
            if (checkBox1.Checked)
            {
                symptoms = symptoms + "," + "Anxiousness";
            }
            if (checkBox2.Checked)
            {
                symptoms = symptoms + "," + "Insomnia";
            }
            if (checkBox3.Checked)
            {
                symptoms = symptoms + "," + "Headache";
            }
            if (checkBox4.Checked)
            {
                symptoms = symptoms + "," + "Irritablity";
            }
            if (checkBox5.Checked)
            {
                symptoms = symptoms + "," + "Hopelessness";
            }
            if (checkBox6.Checked)
            {
                symptoms = symptoms + "," + "Stomach Ache";
            }
            if (checkBox7.Checked)
            {
                symptoms = symptoms + "," + "Restlessness";
            }
            if (checkBox8.Checked)
            {
                symptoms = symptoms + "," + "Hallucination";
            }
            if (checkBox9.Checked)
            {
                symptoms = symptoms + "," + "Emptiness";
            }
            if (checkBox10.Checked)
            {
                symptoms = symptoms + "," + "Trouble Sleeping";
            }
            if (checkBox11.Checked)
            {
                symptoms = symptoms + "," + "Fatigue";
            }
            if (checkBox13.Checked)
            {
                symptoms = symptoms + "," + "Guilt";
            }
            if (checkBox14.Checked)
            {
                symptoms = symptoms + "," + "Lack of Concentration";
            }
            if (checkBox15.Checked)
            {
                symptoms = symptoms + "," + "Following patterns";
            }
            if (checkBox16.Checked)
            {
                symptoms = symptoms + "," + "Extreme weightloss";
            }

                string[] symptomsList = symptoms.Split(',');
                int DepressionCount = 0;
                int AnxietyCount = 0;
                int PTSDCount = 0;
                int ADHDCount = 0;
                int OCDCount = 0;
                int AnorexiaCount = 0;
                int SchizophreniaCount = 0;

                for (int i =0; i<symptomsList.Length; i++)
                {
                    if (symptomsList[i] == "Anxiousness")
                    {
                        DepressionCount++;
                    }
                    else if (symptomsList[i] == "Insomnia")
                    {
                        DepressionCount++;
                        AnorexiaCount++;
                    }
                    else if (symptomsList[i] == "Headache")
                    {
                        DepressionCount++;
                        AnxietyCount++;
                    }
                    else if(symptomsList[i] == "Irritablity")
                    {
                        DepressionCount++;
                        AnxietyCount++;
                    }
                    else if (symptomsList[i] == "Hopelessness")
                    {
                        OCDCount++;
                    }
                    else if (symptomsList[i] == "Stomach Ache")
                    {
                        AnxietyCount++;
                    }
                    else if (symptomsList[i] == "Restlessness")
                    {
                        AnxietyCount++;
                        ADHDCount++;
                    }
                    else if (symptomsList[i] == "Hallucination")
                    {
                        SchizophreniaCount++;
                    }
                    else if (symptomsList[i] == "Emptiness")
                    {
                        DepressionCount++;
                    }
                    else if (symptomsList[i] == "Trouble Sleeping")
                    {
                        PTSDCount++;
                        SchizophreniaCount++;
                    }
                    else if (symptomsList[i] == "Fatigue")
                    {
                        AnorexiaCount++;
                        AnxietyCount++;
                        PTSDCount++;
                    }
                    else if (symptomsList[i] == "Guilt")
                    {
                        DepressionCount++;
                        PTSDCount++;
                    }
                    else if (symptomsList[i] == "Lack of Concentration")
                    {
                        DepressionCount++;
                        PTSDCount++;
                        ADHDCount++;
                    }
                    else if (symptomsList[i] == "Following patterns")
                    {
                        OCDCount++;
                    }
                    else if (symptomsList[i] == "Extreme weightloss")
                    {
                        AnorexiaCount++;
                    }
                }
                
                int[] symptomCount = { DepressionCount, AnxietyCount, PTSDCount, ADHDCount, OCDCount, AnorexiaCount, SchizophreniaCount };
                int max = -9999;
                
                var DiagnosedIllness = new List<string>();
                for (int i = 0; i < symptomCount.Length; i++)
                {
                    if (symptomCount[i] > max)
                    {
                        max = symptomCount[i];       
                    }
                }
                if (DepressionCount == max)
                {
                    DiagnosedIllness.Add("Depression");
                }
                if (AnxietyCount == max)
                {
                    DiagnosedIllness.Add("Anxiety");
                }
                if (PTSDCount == max)
                {
                    DiagnosedIllness.Add("PTSD");
                }
                if (ADHDCount == max)
                {
                    DiagnosedIllness.Add("ADHD");
                }
                if (OCDCount == max)
                {
                    DiagnosedIllness.Add("OCD");
                }
                if (AnorexiaCount == max)
                {
                    DiagnosedIllness.Add("Anorexia");
                }
                if (SchizophreniaCount == max)
                {
                    DiagnosedIllness.Add("Schizophrenia");
                }
                /*for (int i = 0; i < DiagnosedIllness.Count; i++)
                {
                Console.WriteLine(DiagnosedIllness[i]);
                }*/
                 
                for (int n = listBox1.Items.Count - 1; n >= 0; --n)
                {
                    string info = listBox1.Items[n].ToString();                
                    if (!(DiagnosedIllness.Contains(info.Replace(" ", string.Empty))))
                    {
                        listBox1.Items.RemoveAt(n);
                    }
            
                }
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form15 = new Form15();
            form15.Closed += (s, args) => this.Close();
            form15.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Illness b in Ilnesses)
            {
                listBox1.Items.Add(b.Name);
            }
            con.Close();
        }
    }
}

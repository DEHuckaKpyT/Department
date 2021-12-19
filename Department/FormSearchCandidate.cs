using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Department
{
    public partial class FormSearchCandidate : Form
    {
        bool change;
        public FormSearchCandidate(bool change)
        {
            InitializeComponent();
            this.change = change;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //NOTE процедура SearchCandidate
                List<Candidate> candidates = DataBase.Execute<Candidate>("SearchCandidate", "@id", Convert.ToInt16(textBox1.Text), "@FirstName", DBNull.Value, "@Name", DBNull.Value, "@LastName", DBNull.Value);
                if (candidates.Count != 0)
                {
                    new FormCandidate(candidates[0].CandidateID, change).Show();
                    Close();
                    return;
                }
            }
            else if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                //NOTE процедура SearchCandidate
                List<Candidate> candidates = DataBase.Execute<Candidate>("SearchCandidate", "@id", DBNull.Value, "@FirstName", textBox2.Text, "@Name", textBox3.Text, "@LastName", textBox4.Text);
                if (candidates.Count != 0)
                {
                    new FormCandidate(candidates[0].CandidateID, change).Show();
                    Close();
                    return;
                }
            }
        }
    }
}

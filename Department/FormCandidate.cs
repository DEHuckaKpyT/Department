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
    public partial class FormCandidate : Form
    {
        int candidateId;
        public FormCandidate(int candidateId)
        {
            InitializeComponent();
            this.candidateId = candidateId;
        }

        private void FormCandidate_Load(object sender, EventArgs e)
        {
            Candidate candidate = DataBase.SelectQuery<Candidate>($"select * from Candidate where CandidateID = {candidateId}")[0];

            textBoxFirstName.Text = candidate.FirstName;
            textBoxName.Text = candidate.Name;
            textBoxLastName.Text = candidate.LastName;
            textBoxPhone.Text = candidate.Phone;
            textBoxStreet.Text = "1";
            textBoxHouse.Text = candidate.House.ToString();
            textBoxFlat.Text = candidate.Flat.ToString();
            textBoxWork.Text = "2";
            textBoxPost.Text = "3";

        }

        private void button_Click(object sender, EventArgs e)
        {

        }
    }
}

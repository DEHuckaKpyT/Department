﻿using System;
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

            Streets street = DataBase.SelectQuery<Streets>($"select * from Streets where StreetID = {candidate.StreetID}")[0];
            textBoxStreet.Text = (street.First ? $"{street.Sign} {street.Street}" : $"{street.Street} {street.Sign}") + $", д. {candidate.House}, кв. {candidate.Flat}";

            LastWork work = DataBase.SelectQuery<LastWork>($"select * from LastWork where WorkID = {candidate.WorkID}")[0];
            textBoxWork.Text = $"{work.Work}, {work.WorkPlace}";

            Posts post = DataBase.SelectQuery<Posts>($"select * from Post where PostID = {candidate.PostID}")[0];
            textBoxPost.Text = post.Post;
        }

        private void button_Click(object sender, EventArgs e)
        {
            DataBase.InsertUpdateDeleteQuery($"update Candidate set Adopted = 1 where CandidateID = {candidateId}");
            MessageBox.Show("Кандидат успешно принят");
            Close();
            Dispose();
        }
    }
}

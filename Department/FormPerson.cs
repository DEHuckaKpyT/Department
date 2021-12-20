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

namespace Department
{
    public partial class FormPerson : Form
    {
        bool change;
        int PersonId;
        DataSet dataSet1;
        SqlDataAdapter dataAdapter1;
        DataSet dataSet2;
        SqlDataAdapter dataAdapter2;
        public FormPerson(int PersonId, bool change)
        {
            InitializeComponent();
            this.PersonId = PersonId;
            this.change = change;
        }

        private void FormPerson_Load(object sender, EventArgs e)
        {
            Person person = DataBase.SelectQuery<Person>($"select * from Person where PersonID = {PersonId}")[0];

            if (person.DepartmentID != null)
            {
                foreach (var depar in DataBase.SelectQuery<Department>($"select * from Deparment"))
                {
                    comboBoxDepartment.Items.Add(depar);
                    if (depar.DeparmentID == person.DepartmentID) comboBoxDepartment.SelectedItem = depar;
                }
            }
            if (person.InstituteID != null)
            {
                foreach (var inst in DataBase.SelectQuery<Institutes>($"select * from Institute"))
                {
                    comboBoxInstitute.Items.Add(inst);
                    if (person.InstituteID == inst.InstituteID) comboBoxInstitute.SelectedItem = inst;
                }
            }
            if (person.StreetID != null)
            {
                Streets street = DataBase.SelectQuery<Streets>($"select * from Streets where StreetID = {person.StreetID}")[0];

                foreach (Streets st in DataBase.SelectQuery<Streets>("select * from Streets"))
                {
                    comboBoxStreet.Items.Add(st);
                    if (st.StreetID == street.StreetID) comboBoxStreet.SelectedItem = st;
                }
            }
            textBoxHouse.Text = person.House.ToString();
            textBoxFlat.Text = person.Flat.ToString();

            foreach (Posts p in DataBase.SelectQuery<Posts>("select * from Post"))
                comboBoxPost.Items.Add(p);
            if (person.PostID != null)
            {
                comboBoxPost.Items.Clear();
                foreach (Posts p in DataBase.SelectQuery<Posts>("select * from Post"))
                {
                    comboBoxPost.Items.Add(p);
                    if (p.PostID == person.PostID) comboBoxPost.SelectedItem = p;
                }
            }
            foreach (Degrees d in DataBase.SelectQuery<Degrees>("select * from Degree"))
                comboBoxDegree.Items.Add(d);
            if (person.DegreeID != null)
            {
                comboBoxDegree.Items.Clear();
                foreach (Degrees d in DataBase.SelectQuery<Degrees>("select * from Degree"))
                {
                    comboBoxDegree.Items.Add(d);
                    if (d.DegreeID == person.DegreeID) comboBoxDegree.SelectedItem = d;
                }
            }
            LastWork work = DataBase.SelectQuery<LastWork>($"select * from LastWork where WorkID = {person.WorkID}")[0];
            textBoxWork.Text = work.Work + " " + work.WorkPlace;
            textBoxFirstName.Text = person.FirstName;
            textBoxName.Text = person.Name;
            textBoxLastName.Text = person.LastName;
            textBoxPassport.Text = person.Passport;
            if (person.PassportDate.Year > 1800 && person.PassportDate.Year < 2300)
                //NOTE процедура NormalizeDate
                textBoxPassportDate.Text = (string)DataBase.Execute("NormalizeDate", "@date", person.PassportDate);
            if (person.PassportDate.Year > 1800 && person.PassportDate.Year < 2300)
                dateTimePicker1.Value = person.PassportDate;
            textBoxPlace.Text = person.Region;
            if (person.Birth.Year > 1800 && person.Birth.Year < 2300)
                //NOTE процедура NormalizeDate
                textBoxBirth.Text = (string)DataBase.Execute("NormalizeDate", "@date", person.Birth);
            if (person.Birth.Year > 1800 && person.Birth.Year < 2300)
                dateTimePicker2.Value = person.Birth;
            textBoxPhone.Text = person.Phone;
            textBoxSpeciality.Text = person.Speciality;
            textBoxEducation.Text = person.FirstName;
            textBoxYear.Text = person.Year.Year.ToString();
            textBoxRank.Text = person.Rank;
            textBoxComment.Text = person.Comment;

            dataSet1 = new DataSet();
            dataAdapter1 = new SqlDataAdapter($"SELECT [IDNotePenalty], Penalty FROM Penalty where PersonID = {PersonId}", DataBase.connection);
            dataAdapter1.Fill(dataSet1, "Penalty");
            dataGridViewPenalties.DataSource = dataSet1.Tables["Penalty"];
            dataGridViewPenalties.Columns[0].Visible = false;

            dataSet2 = new DataSet();
            dataAdapter2 = new SqlDataAdapter($"SELECT IDNoteReward, Reward FROM Reward where PersonID = {PersonId}", DataBase.connection);
            dataAdapter2.Fill(dataSet2, "Reward");
            dataGridViewRewards.DataSource = dataSet2.Tables["Reward"];
            dataGridViewRewards.Columns[0].Visible = false;
            dataGridViewPenalties.ReadOnly = !change;
            dataGridViewRewards.ReadOnly = !change;
            buttonUpdate.Enabled = change;
            buttonAddReward.Enabled = change;
            buttonAddPenalty.Enabled = change;
            buttonUpdatePenalty.Enabled = change;
            buttonUpdateReward.Enabled = change;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //NOTE процедура NormalizeDate
            textBoxPassportDate.Text = (string)DataBase.Execute("NormalizeDate", "@date", dateTimePicker1.Value);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //NOTE процедура NormalizeDate
            textBoxBirth.Text = (string)DataBase.Execute("NormalizeDate", "@date", dateTimePicker2.Value);
        }

        private void buttonAddPenalty_Click(object sender, EventArgs e)
        {
            new FormAddPenalty(PersonId).ShowDialog();
            dataSet1 = new DataSet();
            dataAdapter1 = new SqlDataAdapter($"SELECT [IDNotePenalty], Penalty FROM Penalty where PersonID = {PersonId}", DataBase.connection);
            dataAdapter1.Fill(dataSet1, "Penalty");
            dataGridViewPenalties.DataSource = dataSet1.Tables["Penalty"];
            dataGridViewPenalties.Columns[0].Visible = false;
        }

        private void buttonUpdateReward_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter2);
            try
            {
                dataAdapter2.Update(dataSet2, "Reward");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddReward_Click(object sender, EventArgs e)
        {
            new FormAddReward(PersonId).ShowDialog();
            dataSet2 = new DataSet();
            dataAdapter2 = new SqlDataAdapter($"SELECT [IDNoteReward], Reward FROM Reward where PersonID = {PersonId}", DataBase.connection);
            dataAdapter2.Fill(dataSet2, "Reward");
            dataGridViewRewards.DataSource = dataSet2.Tables["Reward"];
            dataGridViewRewards.Columns[0].Visible = false;
        }

        private void buttonUpdatePenalty_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter1);
            try
            {
                dataAdapter1.Update(dataSet1, "Penalty");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string query = $"update Person set " +
                $"Name = '{textBoxName.Text}', " +
                $"Phone = '{textBoxPhone.Text}', ";

            if (textBoxLastName.Text != "")
                query += $"LastName = '{textBoxLastName.Text}', ";
            if (textBoxPassport.Text != "")
                query += $"Passport = '{textBoxPassport.Text}', ";
            if (textBoxPassportDate.Text != "")
                query += $"PassportDate = '{dateTimePicker1.Value.ToString("yyyy-MM-dd")}', ";
            if (textBoxBirth.Text != "")
                query += $"Birth = '{dateTimePicker2.Value.ToString("yyyy-MM-dd")}', ";
            if (textBoxPlace.Text != "")
                query += $"Region = '{textBoxPlace.Text}', ";
            if (textBoxSpeciality.Text != "")
                query += $"Speciality = '{textBoxSpeciality.Text}', ";
            if (textBoxEducation.Text != "")
                query += $"Education = '{textBoxEducation.Text}', ";
            if (textBoxYear.Text != "")
                query += $"Year = '{textBoxYear.Text}-01-01', ";
            if (textBoxRank.Text != "")
                query += $"Rank = '{textBoxRank.Text}', ";
            if (textBoxComment.Text != "")
                query += $"Comment = '{textBoxComment.Text}', ";
            if (textBoxFlat.Text != "")
                query += $"Flat = {textBoxFlat.Text}, ";
            if (textBoxHouse.Text != "")
                query += $"House = {textBoxHouse.Text}, ";
            if (comboBoxInstitute.Text != "")
                query += $"InstituteID = {((Institutes)comboBoxInstitute.SelectedItem).InstituteID}, ";
            if (comboBoxDepartment.Text != "")
                query += $"DepartmentID = {((Department)comboBoxDepartment.SelectedItem).DeparmentID}, ";
            if (comboBoxStreet.Text != "")
                query += $"StreetID = {((Streets)comboBoxStreet.SelectedItem).StreetID}, ";
            if (comboBoxPost.Text != "")
                query += $"PostID = {((Posts)comboBoxPost.SelectedItem).PostID}, ";
            if (comboBoxDegree.Text != "")
                query += $"DegreeID = {((Degrees)comboBoxDegree.SelectedItem).DegreeID}, ";

            query += $"FirstName = '{textBoxFirstName.Text}' where PersonID = {PersonId}";

            DataBase.InsertUpdateDeleteQuery(query);
        }
    }
}

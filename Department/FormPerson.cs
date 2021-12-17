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
        int PersonId;
        DataSet dataSet1;
        SqlDataAdapter dataAdapter1;
        DataSet dataSet2;
        SqlDataAdapter dataAdapter2;
        public FormPerson(int PersonId)
        {
            InitializeComponent();
            this.PersonId = PersonId;
        }

        private void FormPerson_Load(object sender, EventArgs e)
        {
            Person person = DataBase.SelectQuery<Person>($"select * from Person where PersonID = {PersonId}")[0];

            if (person.DepartmentID != null)
            {
                Department department = DataBase.SelectQuery<Department>($"select * from Deparment where DeparmentID = {person.DepartmentID}")[0];
                textBoxDepartment.Text = department.Deparment;
            }
            if (person.StreetID != null)
            {
                Streets street = DataBase.SelectQuery<Streets>($"select * from Streets where StreetID = {person.StreetID}")[0];
                textBoxAdress.Text = (street.First ? $"{street.Sign} {street.Street}" : $"{street.Street} {street.Sign}") + $", д {person.House}, кв {person.Flat}";
            }
            if (person.DepartmentID != null)
            {
                Institutes institute = DataBase.SelectQuery<Institutes>($"select * from Institute where InstituteID = {person.InstituteID}")[0];
                textBoxInstitute.Text = institute.Institute;
            }
            if (person.PostID != null)
            {
                Posts post = DataBase.SelectQuery<Posts>($"select * from Post where PostID = {person.PostID}")[0];
                textBoxPost.Text = post.Post;
            }
            if (person.DegreeID != null)
            {
                Degrees degree = DataBase.SelectQuery<Degrees>($"select * from Degree where DegreeID = {person.DegreeID}")[0];
                textBoxDegree.Text = degree.Degree;
            }
            if (person.DegreeID != null)
            {
                LastWork work = DataBase.SelectQuery<LastWork>($"select * from LastWork where WorkID = {person.WorkID}")[0];
                textBoxWork.Text = work.Work + " " + work.WorkPlace;
            }
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
            DataBase.InsertUpdateDeleteQuery($"update Person set " +
                $"FirstName = '{textBoxFirstName.Text}', " +
                $"Name = '{textBoxName.Text}', " +
                $"LastName = '{textBoxLastName.Text}', " +
                //$"DepartmentID = {Text}, " +
                //$"InstituteID = {Text}, " +
                $"Passport = '{textBoxPassport.Text}', " +
                $"PassportDate = '{dateTimePicker1.Value.ToString("yyyy-mm-dd")}', " +
                $"Region = '{textBoxPlace.Text}', " +
                $"Birth = '{dateTimePicker2.Value.ToString("yyyy-mm-dd")}', " +
                $"Phone = '{textBoxPhone.Text}', " +
                //$"StreetID = {Text}, " +
                //$"House = {Text}, " +
                //$"Flat = {Text}, " +
                $"Speciality = '{textBoxSpeciality.Text}', " +
                //$"PostID = {Text}, " +
                $"Education = '{textBoxEducation.Text}', " +
                $"Year = '{textBoxYear.Text}-01-01', " +
                //$"DegreeID = {Text}, " +
                $"Rank = '{textBoxRank.Text}', " +
                $"Comment = '{textBoxComment.Text}' " +
                $"where PersonID = {PersonId}");
        }
    }
}

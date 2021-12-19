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
    public partial class FormMainMenu : Form
    {
        int userId;
        bool change;
        public FormMainMenu(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            User user = DataBase.SelectQuery<User>($"select * from [User] where UserID = {userId}")[0];

            пользователиToolStripMenuItem.Enabled = user.CanSeeUsers;
            аудитToolStripMenuItem.Enabled = user.CanSeeLog;
            change = user.CanChangeInf;
        }

        private void всеКандидатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCandidates form = new FormCandidates(change);
            form.ShowDialog();
        }

        private void FormMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void улицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormStreets(change).ShowDialog();
        }

        private void институтыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormInstitutes(change).ShowDialog();
        }

        private void КафедрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormDepartments(change).ShowDialog();
        }

        private void степениToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormDegrees(change).ShowDialog();
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormPosts(change).ShowDialog();
        }

        private void всеСотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormPersons(change).ShowDialog();
        }

        private void поискКандидатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormSearchCandidate(change).ShowDialog();
        }

        private void поискСотрудникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormSearchPerson(change).ShowDialog();
        }

        private void мойПрофильToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormProfile(userId).ShowDialog();
        }

        private void войтиВДругойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormUsers().ShowDialog();
        }

        private void аудитToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAudit().ShowDialog();
        }
    }
}

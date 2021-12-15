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
        public FormMainMenu(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void всеКандидатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCandidates form = new FormCandidates();
            form.ShowDialog();
        }

        private void FormMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void улицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormStreets().ShowDialog();
        }

        private void институтыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormInstitutes().ShowDialog();
        }

        private void КафедрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormDepartments().ShowDialog();
        }

        private void штрафыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void степениToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void вознагражденияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

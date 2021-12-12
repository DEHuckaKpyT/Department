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
    }
}

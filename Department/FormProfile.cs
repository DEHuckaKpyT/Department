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
    public partial class FormProfile : Form
    {
        int userId;
        public FormProfile(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormPassword(userId).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DataBase.SelectQuery<User>($"select * from [User] where Login = '{textBox1.Text}'").Count == 0)
            {
                DataBase.InsertUpdateDeleteQuery($"update [User] set Login = '{textBox1.Text}' where UserID = {userId}");
                MessageBox.Show("Логин изменён");
            }
            else
                MessageBox.Show("Логин уже существует");
        }

        private void FormProfile_Load(object sender, EventArgs e)
        {
            User user = DataBase.SelectQuery<User>($"select * from [User] where UserID = {userId}")[0];

            textBox1.Text = user.Login;

            if (user.CanSeeUsers) label5.Text = "Могу";
            if (user.CanChangeInf) label6.Text = "Могу";
            if (user.CanSeeLog) label7.Text = "Могу";
        }
    }
}

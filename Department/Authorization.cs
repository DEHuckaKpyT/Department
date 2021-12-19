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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            List<User> users = DataBase.SelectQuery<User>($"select * from [user] where login = '{Login.Text}'");
            if (users.Count == 1)
            {
                User user = users.First();
                if (user.Password == Password.Text)
                {
                    new FormMainMenu(user.UserID).Show();
                    Hide();
                    return;
                }
            }
            MessageBox.Show("Неверный логин или пароль");
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            List<User> users = DataBase.SelectQuery<User>($"select * from [User]");
            foreach (User user in users)
                Login.Items.Add(user.Login);
        }

        private void Login_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<User> users = DataBase.SelectQuery<User>($"select * from [User] where Login = '{Login.Text}'");
            if (users.Count == 1)
                Help.Text = users.First().Password;
        }
    }
}

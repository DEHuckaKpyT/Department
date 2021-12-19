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
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (DataBase.SelectQuery<User>($"select * from [User] where Login = '{textBox1.Text}'").Count == 0)
                {
                    DataBase.InsertUpdateDeleteQuery($"insert into [User] (Login, Password, CanSeeUsers, CanChangeInf, CanSeeLog) values " +
                        $"('{textBox1.Text}', '{textBox2.Text}', " +
                        $"{(checkBox1.Checked ? "1" : "0")}, " +
                        $"{(checkBox2.Checked ? "1" : "0")}, " +
                        $"{(checkBox3.Checked ? "1" : "0")})");
                    MessageBox.Show("Пользователь добавлен");
                    Close();
                }
                else
                    MessageBox.Show("Логин уже существует");
            }
            else
                MessageBox.Show("Данные не введены");
        }
    }
}

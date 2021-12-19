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
    public partial class FormPassword : Form
    {
        int userId;
        public FormPassword(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox2.Text == textBox3.Text)
            {
                User user = DataBase.SelectQuery<User>($"select * from [User] where UserID = {userId}")[0];
                if (user.Password == textBox1.Text)
                {
                    DataBase.InsertUpdateDeleteQuery($"update [User] set Password = '{textBox2.Text}' where UserID = {userId}");
                    MessageBox.Show("Пароль изменён");
                    Close();
                }
                else
                    MessageBox.Show("Пароль не совпадает");
            }
            else
                MessageBox.Show("Пароли не совпадает");
        }
    }
}

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
    public partial class FormAddReward : Form
    {
        int PersonID;
        public FormAddReward(int PersonID)
        {
            InitializeComponent();
            this.PersonID = PersonID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                DataBase.InsertUpdateDeleteQuery($"insert into Reward (Reward, PersonID) values ('{textBox1.Text}', {PersonID})");
            MessageBox.Show("Успешно.");
            Close();
        }
    }
}

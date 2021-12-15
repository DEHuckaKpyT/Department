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
    public partial class FormAddDepartment : Form
    {
        public FormAddDepartment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string department = textBox1.Text;
            string instituten = comboBox1.Text;
            if (department != "" && instituten != "")
            {
                Institutes institute = DataBase.SelectQuery<Institutes>($"select * from Institute where Institute = '{instituten}'")[0];
                DataBase.InsertUpdateDeleteQuery($"insert into Deparment (Deparment, InstituteID) values ('{department}',{institute.InstituteID})");
                Close();
            }
        }

        private void FormAddDepartment_Load(object sender, EventArgs e)
        {
            foreach (var institute in DataBase.SelectQuery<Institutes>($"select * from Institute"))
            {
                comboBox1.Items.Add(institute.Institute);
            }
        }
    }
}

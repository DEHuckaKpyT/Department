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
    public partial class FormDepartment : Form
    {
        bool change;
        int departmentId;
        public FormDepartment(int departmentId, bool change)
        {
            InitializeComponent();
            this.departmentId = departmentId;
            this.change = change;
        }

        private void FormDepartment_Load(object sender, EventArgs e)
        {
            Department department = DataBase.SelectQuery<Department>($"select * from Deparment where DeparmentID = {departmentId}")[0];
            textBox1.Text = department.Deparment;
            foreach (var institute in DataBase.SelectQuery<Institutes>($"select * from Institute"))
            {
                comboBox1.Items.Add(institute.Institute);
            }
            comboBox1.Text = DataBase.SelectQuery<Institutes>($"select * from Institute where InstituteID = {department.InstituteID}")[0].Institute;
            button1.Enabled = change;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string department = textBox1.Text;
            string instituten = comboBox1.Text;
            if (department != "" && instituten != "")
            {
                Institutes institute = DataBase.SelectQuery<Institutes>($"select * from Institute where Institute = '{instituten}'")[0];
                DataBase.InsertUpdateDeleteQuery($"update Deparment set Deparment = '{department}', InstituteID = {institute.InstituteID} where DeparmentID = {departmentId}");
            }
            Close();
        }
    }
}

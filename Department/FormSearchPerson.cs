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
    public partial class FormSearchPerson : Form
    {
        public FormSearchPerson()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //NOTE процедура SearchPerson
                List<Person> persons = DataBase.Execute<Person>("SearchPerson", "@id", Convert.ToInt16(textBox1.Text), "@FirstName", DBNull.Value, "@Name", DBNull.Value, "@LastName", DBNull.Value);
                if (persons.Count != 0)
                {
                    new FormPerson(persons[0].PersonID).Show();
                    Close();
                    return;
                }
            }
            else if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                //NOTE процедура SearchPerson
                List<Person> persons = DataBase.Execute<Person>("SearchPerson", "@id", DBNull.Value, "@FirstName", textBox2.Text, "@Name", textBox3.Text, "@LastName", textBox4.Text);
                if (persons.Count != 0)
                {
                    new FormPerson(persons[0].PersonID).Show();
                    Close();
                    return;
                }
            }
        }
    }
}

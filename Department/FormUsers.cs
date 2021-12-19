using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Department
{
    public partial class FormUsers : Form
    {
        DataSet dataSet;
        SqlDataAdapter dataAdapter;
        public FormUsers()
        {
            InitializeComponent();
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            dataAdapter = new SqlDataAdapter("SELECT UserID, Login, CanSeeUsers, CanChangeInf, CanSeeLog FROM [User]", DataBase.connection);
            dataAdapter.Fill(dataSet, "[User]");
            dataGridView1.DataSource = dataSet.Tables["[User]"];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            try
            {
                dataAdapter.Update(dataSet, "[User]");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormAddUser().ShowDialog();
        }
    }
}

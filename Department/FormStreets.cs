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
    public partial class FormStreets : Form
    {
        DataSet dataSet;
        SqlDataAdapter dataAdapter;
        public FormStreets()
        {
            InitializeComponent();
        }

        private void FormStreets_Load(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            dataAdapter = new SqlDataAdapter("SELECT * FROM Streets", DataBase.connection);
            dataAdapter.Fill(dataSet, "Streets");
            dataGridView1.DataSource = dataSet.Tables["Streets"];
            dataGridView1.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            try
            {
                dataAdapter.Update(dataSet, "Streets");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

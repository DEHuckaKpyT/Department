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
    public partial class FormPersons : Form
    {
        bool change;
        public FormPersons(bool change)
        {
            InitializeComponent();
            this.change = change;
        }

        private void FormPersons_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                new FormPerson(Convert.ToInt32(grid[0, e.RowIndex].Value), change).ShowDialog();
                LoadGrid();
            }
        }

        void LoadGrid()
        {
            dataGridView1.Columns.Clear();
            //NOTE представление View_Persons
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM View_Persons", DataBase.connection);
            dataAdapter.Fill(dataSet, "View_Persons");
            dataGridView1.DataSource = dataSet.Tables["View_Persons"];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Подробнее",
                UseColumnTextForButtonValue = true
            });
        }
    }
}

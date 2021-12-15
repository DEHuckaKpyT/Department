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
    public partial class FormDepartments : Form
    {
        public FormDepartments()
        {
            InitializeComponent();
        }

        private void FormDepartments_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormAddDepartment().ShowDialog();
            LoadGrid();
        }

        void LoadGrid()
        {
            dataGridView1.Columns.Clear();
            //NOTE представление View_DepartmentsInstitutes
            dataGridView1.DataSource = DataBase.SelectQuery<View_DepartmentsInstitutes>($"select * from View_DepartmentsInstitutes");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Подробнее",
                UseColumnTextForButtonValue = true
            });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                new FormDepartment((int)grid[0, e.RowIndex].Value).ShowDialog();
                LoadGrid();
            }
        }
    }
}

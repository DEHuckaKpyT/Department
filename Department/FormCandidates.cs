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
    public partial class FormCandidates : Form
    {
        bool change;
        DataSet dataSet;
        SqlDataAdapter dataAdapter;
        public FormCandidates(bool change)
        {
            InitializeComponent();
            this.change = change;
        }

        private void FormCandidates_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void dataGridViewCandidates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                new FormCandidate((int)grid[0, e.RowIndex].Value, change).ShowDialog();
                LoadGrid();
            }
        }

        void LoadGrid()
        {
            dataGridViewCandidates.Columns.Clear();
            //NOTE представление View_PostCandidateFalse
            dataGridViewCandidates.DataSource = DataBase.SelectQuery<View_PostCandidateFalse>($"select * from View_PostCandidateFalse");
            dataGridViewCandidates.Columns[0].Visible = false;
            dataGridViewCandidates.Columns.Add(new DataGridViewButtonColumn()
            {
                Text = "Подробнее",
                UseColumnTextForButtonValue = true
            });

        }
    }
}

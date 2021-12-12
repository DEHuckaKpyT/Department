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
        DataSet dataSet;
        SqlDataAdapter dataAdapter;
        public FormCandidates()
        {
            InitializeComponent();
        }

        private void FormCandidates_Load(object sender, EventArgs e)
        {
            //dataSet = new DataSet();
            //dataAdapter = new SqlDataAdapter("SELECT * FROM View_PostCandidateFalse", DataBase.connection);
            //dataAdapter.Fill(dataSet, "Candidate");     
            //dataGridViewCandidates.DataSource = dataSet.Tables["Candidate"];
            LoadGrid();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
            //SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            //try
            //{
            //    dataAdapter.Update(dataSet, "Candidate");
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        //}

        private void dataGridViewCandidates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            if (grid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                new FormCandidate((int)grid[0, e.RowIndex].Value).ShowDialog();
                LoadGrid();
            }
        }

        void LoadGrid()
        {
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

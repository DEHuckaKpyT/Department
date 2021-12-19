﻿using System;
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
    public partial class FormInstitutes : Form
    {
        bool change;
        DataSet dataSet;
        SqlDataAdapter dataAdapter;
        public FormInstitutes(bool change)
        {
            InitializeComponent();
            this.change = change;
        }

        private void FormInstitutes_Load(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            dataAdapter = new SqlDataAdapter("SELECT * FROM Institute", DataBase.connection);
            dataAdapter.Fill(dataSet, "Institute");
            dataGridView1.DataSource = dataSet.Tables["Institute"];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.ReadOnly = !change;
            button1.Enabled = change;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            try
            {
                dataAdapter.Update(dataSet, "Institute");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

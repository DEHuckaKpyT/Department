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
    public partial class FormAudit : Form
    {
        public FormAudit()
        {
            InitializeComponent();
        }

        private void FormAudit_Load(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Log.Message, [User].Login, Log.DateTime FROM Log " +
                "inner join [User] on [User].UserID = Log.UserID", DataBase.connection);
            dataAdapter.Fill(dataSet, "Log");
            dataGridView1.DataSource = dataSet.Tables["Log"];
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
    }
}

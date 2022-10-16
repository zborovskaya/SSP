using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSP_1
{
    public partial class Form2 : Form
    {
        DataGridView dataGridView;
        DataSet myDataset;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView = new DataGridView { Parent = this, Dock = DockStyle.Top };
                string connectingString =

                    @"provider=Microsoft.Jet.OLEDB.4.0;data source=m1.mdb";

                OleDbConnection myConn = new OleDbConnection(connectingString);

                //Сформировать строку запросов

                string selectString = "Select * from translator";

                OleDbCommand myCommand = myConn.CreateCommand();

                myCommand.CommandText = selectString;

                OleDbDataAdapter oda = new OleDbDataAdapter();

                oda.SelectCommand = myCommand;

                myDataset = new DataSet();

                myConn.Open();

                string dataTableName = "translator";

                oda.Fill(myDataset, dataTableName);

                DataTable myDataTable = myDataset.Tables[dataTableName];
                dataGridView.DataSource = myDataset.Tables[dataTableName];
                dataGridView.Columns["Id"].ReadOnly = true;
                dataGridView.Columns["english"].ReadOnly = true;
                dataGridView.Columns["russian"].ReadOnly = true;
                myConn.Close();
            }catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dataTableName = "translator";
            DataRow row = myDataset.Tables[dataTableName].NewRow(); // добавляем новую строку в DataTable
            myDataset.Tables[dataTableName].Rows.Add(row);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectingString =

                 @"provider=Microsoft.Jet.OLEDB.4.0;data source=Provider=Microsoft.Jet.OLEDB.4.0;Data Source=m1.mdb";

                OleDbConnection myConn = new OleDbConnection(connectingString);
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from translator WHERE [id]= @id";

                string f;
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    int a = dataGridView.Rows.IndexOf(row);
                    f = dataGridView.Rows[a].Cells[0].Value.ToString();
                    dataGridView.Rows.Remove(row);
                    cmd.Parameters.AddWithValue("@id", f);
                    cmd.Connection = myConn;
                    myConn.Open();
                    cmd.ExecuteNonQuery();
                    myConn.Close();
                }
            }catch { }
           
        }
    }
}

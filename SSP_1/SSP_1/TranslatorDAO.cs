using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSP_1
{
    class TranslatorDAO
    {
        public List<Item> getItemsList()
        {
            string connectingString =

                @"provider=Microsoft.Jet.OLEDB.4.0;data source=C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TRANSLATORDB.mdf";

            OleDbConnection myConn = new OleDbConnection(connectingString);

            //Сформировать строку запросов

            string selectString = "Select * from translator";

            OleDbCommand myCommand = myConn.CreateCommand();

            myCommand.CommandText = selectString;

            OleDbDataAdapter oda = new OleDbDataAdapter();

            oda.SelectCommand = myCommand;

            System.Data.DataSet myDataset = new DataSet();

            myConn.Open();

            string dataTableName = "translator";

            oda.Fill(myDataset, dataTableName);

            DataTable myDataTable = myDataset.Tables[dataTableName];
            List<Item> items = new List<Item>();

            foreach (DataRow dr in myDataTable.Rows)

            {
                items.Add(new Item((String)dr["english_word"],(String) dr["russian_word"]));

            }
            myConn.Close();
            return items;
        }
    }
}

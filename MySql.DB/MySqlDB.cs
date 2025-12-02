using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Dynamic;

namespace MySql.DB
{
    public class MySqlDBConfig
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
    }

    public class MySqlDB
    {
        private readonly string ConnString;
        private readonly MySqlConnection Connection;
        private MySqlCommand Command;
        private MySqlDataAdapter Adapter;

        public MySqlDB(MySqlDBConfig config)
        {
            this.ConnString = $"server={config.Server};username={config.Username};password={config.Password};database={config.Database}";
            this.Connection = new MySqlConnection(this.ConnString);
        }

        public void Execute(string sql)
        {
            Command = new MySqlCommand(sql, this.Connection);
        }

        public List<dynamic> Rows(string sql)
        {
            DataSet set = new DataSet();
            Command = new MySqlCommand(sql, this.Connection);
            Adapter = new MySqlDataAdapter(this.Command);
            Adapter.Fill(set);
            DataTable table = set.Tables[0];

            List<dynamic> dynamicTable = table.AsEnumerable().Select(row =>
            {
                dynamic expando = new ExpandoObject();
                var dict = (IDictionary<string, object>)expando;

                foreach (DataColumn column in table.Columns)
                {
                    dict[column.ColumnName] = row[column] == DBNull.Value ? "" : row[column].ToString();
                }

                return expando;

            }).ToList();

            return dynamicTable;
        }
    }
}

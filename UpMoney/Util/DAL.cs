using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace UpMoney.Util
{
    public class DAL

    {
        private static string server = "bdcadastro.database.windows.net";
        private static string database = "BDCADASTRO";
        private static string user = "leonardo.BDCADASTRO";
        private static string password = "Leo@bmx1150";
        //private static string connectionString = $"server={server};Database={database};Uid={user};Pwd = {password};Trusted_Connection=True;";
        private SqlConnection con;
        //private static string connectionString = $"Server=bdcadastro.database.windows.net;Database=BDCADASTRO;User ID = {user}; Password={password}; Trusted_Connection=True;";


        private static string connectionString = $"Server=tcp:bdcadastro.database.windows.net;Database=BDCADASTRO;Uid=leonardo.BDCADASTRO @bdcadastro; Pwd={password};";
  
        


public DAL()

        {
            //connection = new MySqlConnection(connectionString);
            //connection.Open();

            con = new SqlConnection(connectionString);
            con.Open();

            //SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.CommandType = CommandType.Text;
            //con.Open();

        }

        //Executa selects
        public DataTable RetDataTable(string sql)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(command);
            //con = new SqlConnection(connectionString);                
            da.Fill(dataTable);
            return dataTable;
        }

        //Executa inserts, updates, deletes
        public void ExecutaComandoSQL(string sql)
        {
            SqlCommand command = new SqlCommand(sql, con);
            command.ExecuteNonQuery();
        }


    }
}


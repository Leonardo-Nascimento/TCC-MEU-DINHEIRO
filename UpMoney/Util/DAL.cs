using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace UpMoney.Util
{
    public class DAL

    {
        private static string server = "SQLEXPRESS";
        private static string database = "BDCADASTRO";
        private static string user = "";
        private static string password = "";
        //private static string connectionString = $"server={server};Database={database};Uid={user};Pwd = {password};Trusted_Connection=True;";
        private SqlConnection con;
        private static string connectionString = @"Server=.\sqlexpress;Database=BDCADASTRO;Trusted_Connection=True;";
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


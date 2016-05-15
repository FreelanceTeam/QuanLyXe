using System.Data.SqlClient;

namespace VMS.DAL
{
    public class DataFactory
    {
        private static string _connectionString = "Server=CB;Database=thanhan;Trusted_Connection=True;";
        private static SqlConnection _connection;

        private DataFactory()
        {
            _connectionString = "";
        }

        public static void CreateConnection()
        {
            _connection = new SqlConnection(_connectionString);
        }

        public static SqlCommand CreateCommand(string commandText)
        {
            SqlCommand cmd = new SqlCommand(commandText, _connection);
            return cmd;
        }

        public static SqlDataAdapter CreateAdapter(SqlCommand cmd)
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            return da;
        }

        public static bool ExecuteNonQuery(SqlCommand cmd)
        {
            _connection.Open();
            int rows = cmd.ExecuteNonQuery();
            _connection.Close();
            return rows > 0;
        }
    }
}

using System;
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
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
            }
        }

        public static SqlCommand CreateCommand(string commandText)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand(commandText, _connection);
                return cmd;
            }
            catch (Exception)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!");
            }
            finally
            {
                _connection.Close(); 
            }
        }

        public static SqlDataAdapter CreateAdapter(SqlCommand cmd)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                return da;
            }
            catch (Exception)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!");
            }
        }

        public static bool ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                _connection.Open();
                int rows = cmd.ExecuteNonQuery();
                
                return rows > 0;
            }
            catch (Exception)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu!");
            }
            finally
            {
                _connection.Close(); 
            }
        }
    }
}

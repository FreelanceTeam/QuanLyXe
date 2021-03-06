using System;
using System.Data.SqlClient;
using TVClientManager;

namespace VMS.DAL
{
    public class DataFactory
    {
        private static string _connectionString = "Server=CB;Database=thanhan;Trusted_Connection=True;";
        private static SqlConnection _connection;

        private static string oServer;
        private static string oDatabase;
        private static string oUser;
        private static string oPass;
        private static string sUserLogin;

        public static ClientManager clientManager = new ClientManager();

        private DataFactory()
        {
            _connectionString = "";
        }

        public static void CreateConnection()
        {
            // Use old dll to load Connection Information from Config.xml
            if (clientManager.LoadConfiguration("config.xml", false) == true)
            {
                oServer = clientManager.DecryptString(clientManager.Config.DB_Source);
                oDatabase = clientManager.DecryptString(clientManager.Config.DB_Name);
                oUser = clientManager.DecryptString(clientManager.Config.DB_User);
                oPass = clientManager.DecryptString(clientManager.Config.DB_Password);
                sUserLogin = clientManager.DecryptString(clientManager.Config.User);
            }
            else
            {
                // TODO Should add Message Box to notice about thís
                return;
            }
            // End
            //_connectionString = "server=" + oServer.Trim() + ";database=" + oDatabase.Trim() + ";user=" + oUser.Trim() + ";pwd=" + oPass.Trim();

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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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

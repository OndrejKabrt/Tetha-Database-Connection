using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TethaRawGataway
{
    public class DatabaseSingleton
    {
        private static MySqlConnection conn = null;

        private DatabaseSingleton()
        {
        }

        public static MySqlConnection GetInstance()
        {
            if (conn == null)
            {
                MySqlConnectionStringBuilder consStringBuilder = new MySqlConnectionStringBuilder();
                consStringBuilder.UserID = ReadSetting("Name");
                consStringBuilder.Password = ReadSetting("Password");
                consStringBuilder.Database = ReadSetting("Database");
                consStringBuilder.Server = ReadSetting("DataSource");
                consStringBuilder.ConnectionTimeout  = 30;
                conn = new MySqlConnection(consStringBuilder.ConnectionString);
                conn.Open();
            }
            return conn;
        }

        public static void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private static string ReadSetting(string key)
        {
            //nutno doinstalovat, VS nabídne doinstalaci samo
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Nenalezeno";
            return result;
        }
    }
}

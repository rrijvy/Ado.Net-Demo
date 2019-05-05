using System.Configuration;
using System.Data.SqlClient;

namespace adonet.Data
{
    public class DB
    {
        public static string ConnectionString
        {
            get
            {
                string connString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connString);

                sb.ApplicationName = ApplicationName ?? sb.ApplicationName;
                sb.ConnectTimeout = (ConnectTimeout > 0) ? ConnectTimeout : sb.ConnectTimeout;

                return sb.ToString();
            }
        }

        public static SqlConnection GetSqlConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            connection.Open();

            return connection;
        }

        public static string ApplicationName { get; set; }

        public static int ConnectTimeout { get; set; }        
    }
}
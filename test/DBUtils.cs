using MySqlConnector;

namespace testconnection
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "rtc_oee_management";
            string username = "root";
            string password = "Bongmatntk9";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }

    }
}

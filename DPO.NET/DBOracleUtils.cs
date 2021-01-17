using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPO.NET
{
    class DBOracleUtils
    {
        public static Oracle.DataAccess.Client.OracleConnection
                         GetDBConnection(string host, int port, String sid, String user, String password)
        {

            Console.WriteLine("Getting Connection ...");

            // Connection String để kết nối trực tiếp tới Oracle.
            string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                 + host + ")(PORT = " + port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                 + sid + ")));Password=" + password + ";User ID=" + user;


            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection();

            conn.ConnectionString = connString;

            return conn;
        }
    }
}

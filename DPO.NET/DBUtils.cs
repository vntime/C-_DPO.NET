using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPO.NET
{
    class DBUtils
    {
        public static Oracle.DataAccess.Client.OracleConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 1521;
            string sid = "orcl";
            string user = "test";
            string password = "test";

            return DBOracleUtils.GetDBConnection(host, port, sid, user, password);
        }
    }
}

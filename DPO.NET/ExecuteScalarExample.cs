using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DPO.NET
{
    class ExecuteScalarExample
    {
        static void Main(string[] args)
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                OracleCommand cmd = new OracleCommand("Select count(*) From Employee", conn);

                cmd.CommandType = CommandType.Text;

                // Phương thức ExecuteScalar trả về giá trị của cột đầu tiên trên dòng đầu tiên. 
                object countObj = cmd.ExecuteScalar();

                int count = 0;
                if (countObj != null)
                {
                    count = Convert.ToInt32(countObj);
                }

                Console.WriteLine("Emp Count: " + count);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            Console.Read();
        }
    }
}

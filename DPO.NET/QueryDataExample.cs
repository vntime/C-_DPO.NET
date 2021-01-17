using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPO.NET
{
    class QueryDataExample
    {
        static void Main(string[] args)
        {
            Oracle.DataAccess.Client.OracleConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                QueryEmployee(conn);
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


        private static void QueryEmployee(Oracle.DataAccess.Client.OracleConnection conn)
        {
            string sql = "Select Emp_Id, Emp_No, Emp_Name, Mng_Id from Employee";

            // Tạo một đối tượng Command.
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand();

            // Liên hợp Command với Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;


            using (System.Data.Common.DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        // Chỉ số (index) của cột Emp_ID trong câu lệnh SQL.
                        int empIdIndex = reader.GetOrdinal("Emp_Id"); // 0


                        long empId = Convert.ToInt64(reader.GetValue(0));

                        // Chỉ số của cột Emp_No là 1.
                        string empNo = reader.GetString(1);
                        int empNameIndex = reader.GetOrdinal("Emp_Name");// 2
                        string empName = reader.GetString(empNameIndex);


                        int mngIdIndex = reader.GetOrdinal("Mng_Id");

                        long? mngId = null;

                        if (!reader.IsDBNull(mngIdIndex))
                        {
                            mngId = Convert.ToInt64(reader.GetValue(mngIdIndex));
                        }
                        Console.WriteLine("--------------------");
                        Console.WriteLine("empIdIndex:" + empIdIndex);
                        Console.WriteLine("EmpId:" + empId);
                        Console.WriteLine("EmpNo:" + empNo);
                        Console.WriteLine("EmpName:" + empName);
                        Console.WriteLine("MngId:" + mngId);
                    }
                }
            }
        }
    }
}

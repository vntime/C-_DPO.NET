using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DPO.NET
{
    class DeleteExample
    {
        static void Main(string[] args)
        {
            // Lấy ra kết nối tới cơ sở dữ liệu.
            OracleConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {


                string sql = "Delete from Salary_Grade where Grade = @grade ";

                // Tạo đối tượng Command
                OracleCommand cmd = new OracleCommand();

                // Liên hợp với Connection
                cmd.Connection = conn;

                // Command Text.
                cmd.CommandText = sql;

                cmd.Parameters.Add("@grade", SqlDbType.Int).Value = 3;

                // Thực thi Command (Dùng cho delete,insert, update).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
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
                conn = null;
            }


            Console.Read();

        }
    }
}

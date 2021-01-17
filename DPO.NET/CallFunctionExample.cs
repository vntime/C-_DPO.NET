using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DPO.NET
{
    class CallFunctionExample
    {
        static void Main(string[] args)
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                // Tạo một đối tượng Command để gọi hàm Get_Emp_No.
                OracleCommand cmd = new OracleCommand("Get_Emp_No", conn);

                // Kiểu của Command là StoredProcedure
                cmd.CommandType = CommandType.StoredProcedure;

                // ** Chú ý: Với Oracle, tham số trả về phải được thêm vào đầu tiên.
                // Tạo một đối tượng Parameter, lưu trữ kết quả trả về của hàm  (Varchar2(50)).
                OracleParameter resultParam = new OracleParameter("@Result", OracleDbType.Varchar2, 50);

                // ReturnValue
                resultParam.Direction = ParameterDirection.ReturnValue;

                // Thêm vào danh sách tham số.
                cmd.Parameters.Add(resultParam);

                // Thêm tham số @p_Emp_Id và sét giá trị của nó = 100.
                cmd.Parameters.Add("@p_Emp_Id", OracleDbType.Int32).Value = 100;

                // Gọi hàm.
                cmd.ExecuteNonQuery();

                string empNo = null;
                if (resultParam.Value != DBNull.Value)
                {
                    Console.WriteLine("resultParam.Value: " + resultParam.Value.GetType().ToString());
                    OracleString ret = (OracleString)resultParam.Value;
                    empNo = ret.ToString();
                }
                Console.WriteLine("Emp No: " + empNo);

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

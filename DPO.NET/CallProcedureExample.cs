using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPO.NET
{
    class CallProcedureExample
    {
        static void Main(string[] args)
        {
            Oracle.DataAccess.Client.OracleConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {

                // Tạo một đối tượng Command gọi thủ tục Get_Employee_Info.
                Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand("Get_Employee_Info", conn);

                // Kiểu của Command là StoredProcedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Thêm tham số @p_Emp_Id và sét giá trị của nó = 100.
                cmd.Parameters.Add("@p_Emp_Id", Oracle.DataAccess.Client.OracleDbType.Int32).Value = 100;

                // Thêm tham số @v_Emp_No kiểu Varchar(20).
                cmd.Parameters.Add(new Oracle.DataAccess.Client.OracleParameter("@v_Emp_No", Oracle.DataAccess.Client.OracleDbType.Varchar2, 20));
                cmd.Parameters.Add(new OracleParameter("@v_First_Name", Oracle.DataAccess.Client.OracleDbType.Varchar2, 50));
                cmd.Parameters.Add(new OracleParameter("@v_Last_Name", Oracle.DataAccess.Client.OracleDbType.Varchar2, 50));
                cmd.Parameters.Add(new OracleParameter("@v_Hire_Date", OracleDbType.Date));

                // Đăng ký tham số @v_Emp_No là OUTPUT.
                cmd.Parameters["@v_Emp_No"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters["@v_First_Name"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters["@v_Last_Name"].Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters["@v_Hire_Date"].Direction = System.Data.ParameterDirection.Output;

                // Thực thi thủ tục.
                cmd.ExecuteNonQuery();

                // Lấy các giá trị đầu ra.
                string empNo = cmd.Parameters["@v_Emp_No"].Value.ToString();
                string firstName = cmd.Parameters["@v_First_Name"].Value.ToString();
                string lastName = cmd.Parameters["@v_Last_Name"].Value.ToString();
                object hireDateObj = cmd.Parameters["@v_Hire_Date"].Value;

                Console.WriteLine("hireDateObj type: " + hireDateObj.GetType().ToString());
                Oracle.DataAccess.Types.OracleDate hireDate = (Oracle.DataAccess.Types.OracleDate)hireDateObj;


                Console.WriteLine("Emp No: " + empNo);
                Console.WriteLine("First Name: " + firstName);
                Console.WriteLine("Last Name: " + lastName);
                Console.WriteLine("Hire Date: " + hireDate);

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

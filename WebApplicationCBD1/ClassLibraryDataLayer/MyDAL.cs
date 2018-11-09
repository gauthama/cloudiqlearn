using System;
using System.Collections.Generic;

using System.Data; //CommandType
using System.Data.SqlClient;//SqlDataReader
using ClassLibraryDataModel;


namespace ClassLibraryDataLayer
{
    public class MyDAL
    {
        // const string connectionString = "Data Source =.; Initial Catalog = AdventureWorks; Integrated Security = True";
        

        public static List<Employee> GetAll(string connectionString)
        {
            List<Employee> empList = new List<Employee>();
        
            String commandText = "USE AdventureWorks; SELECT* FROM HumanResources.Employee; ";
            CommandType commandType = CommandType.Text;
            SqlDataReader reader;
            reader = SqlHelper.ExecuteReader(connectionString, commandText, commandType);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetInt32(0),
                    //    reader.GetString(1), reader.GetString(2));
                    int id = reader.GetInt32(0);
                    string nationalId = reader.GetString(1);
                    string loginId = reader.GetString(2);
                    Employee emp = new Employee(id, nationalId, loginId);
                    empList.Add(emp);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            return empList;
        }

        public static Employee GetById(string connectionString, int id)
        {
            Employee emp = null;
            //String connectionString = "Data Source =.; Initial Catalog = AdventureWorks; Integrated Security = True";
            String commandText = String.Format("USE AdventureWorks; SELECT* FROM HumanResources.Employee WHERE BusinessEntityID={0};", id);
            CommandType commandType = CommandType.Text;
            SqlDataReader reader;
            reader = SqlHelper.ExecuteReader(connectionString, commandText, commandType);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetInt32(0),
                    //    reader.GetString(1), reader.GetString(2));
                    int Id = reader.GetInt32(0);
                    string nationalId = reader.GetString(1);
                    string loginId = reader.GetString(2);
                    emp = new Employee(Id, nationalId, loginId);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();

            return emp;
        }

        public static void Update(string connectionString, int id, Employee emp)
        {
            /*
            create procedure mySPupdateEmp(@BID int, @LoginID nvarchar(256))
            as
            begin
            update HumanResources.Employee
            SET LoginID = @LoginID
            where BusinessEntityID = @BID
            end;

            EXEC mySPupdateEmp @BID = 2, @LoginID = "adventure-works\\terri1";
            */
            //String connectionString = "Data Source =.; Initial Catalog = AdventureWorks; Integrated Security = True";
            String commandText = "mySPupdateEmp"; //using stored procedure with param
            CommandType commandType = CommandType.StoredProcedure;
            //SqlParameter[] parameters;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@BID", id));
            parameters.Add(new SqlParameter("@LoginID", emp.loginId));

            SqlHelper.ExecuteNonQuery(connectionString, commandText, commandType, parameters.ToArray());

        }
    }
}

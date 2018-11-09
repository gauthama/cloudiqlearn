using System;
using System.Collections.Generic;
using ClassLibraryDataLayer;
using ClassLibraryDataModel;

namespace ClassLibraryBusinessLayer
{
    public class BusinessClass
    {
        public static List<Employee> GetAll(string connectionString)
        {
            return MyDAL.GetAll(connectionString);
        }

        public static Employee GetById(string connectionString, int id)
        {
            return MyDAL.GetById(connectionString, id);
        }
 
        public static void Post(string connectionString, string value)
        {
        }

        public static void Update(string connectionString, int id, Employee emp)
        {
            MyDAL.Update(connectionString, id, emp);
        }

        public static void Delete(string connectionString, int id)
        {
        }
    }
}

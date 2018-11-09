using System;

namespace ClassLibraryDataModel
{
    public class Employee
    {
        public readonly int id;
        public string nationalId;
        public string loginId;

        public Employee(int id, string nationalId, string loginId)
        {
            this.id = id;
            this.nationalId = nationalId;
            this.loginId = loginId;
        }
    }
}

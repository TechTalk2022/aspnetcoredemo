using System.Collections.Generic;

namespace TechTalkDemo.ASPNETCore2._2.Areas.Student.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class EmployeeModel
    {
        public List<Employee> EmployeeLst { get; set; }
    }
}

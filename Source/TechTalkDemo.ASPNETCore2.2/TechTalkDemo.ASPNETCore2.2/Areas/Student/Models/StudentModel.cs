using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTalkDemo.ASPNETCore2._2.Areas.Student.Models
{
    public class StudentCommanModels
    {

        public StudentModel studentDetails;
        public List<StudentModel> ListStudentModels { get; set; }

        public List<Department> ListDepartment { get; set; }
    }
    public class StudentModel
    {
        public Int32 StudentId { get; set; }
        public string FirstName { get; set; }
        public string MidleName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
    public class Department
    {
        public Int32 DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}

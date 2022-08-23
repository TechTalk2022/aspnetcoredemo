using System;
using System.Collections.Generic;
using System.Text;

namespace TechTalkDemo.Common
{
    public class URLRouting
    {

        public static class StudentInfo
        {
            
            public const string AddStudentDetails = "~/add-student-details";
            public const string EditStudentDetails = "~/edit-student-details";
            public const string DeleteStudentDetails = "~/delete-student-detailst";
            public const string StudentDetails = "~/student-details";
            
        }
        public static class Program
        {

            public const string AddProgramDetails = "~/add-program-details";
            public const string EditProgramDetails = "~/edit-program-details";
            public const string SaveProgramDetails = "~/save-program-details";
            public const string DeleteProgramDetails = "~/delete-program-detailst";
            public const string ProgramDetails = "~/program-details";

        }
        public static class Home
        {

            public const string Index = "~/index"; 
            public const string AdminDashboard = "~/admin-dashboard"; 
            public const string StaffDashboard = "~/staff-dashboard"; 

        }
        public static class Login
        {

            public const string Register = "~/register";
            public const string SignIn = "~/signin";
            public const string Logout = "~/logout";
            

        }

    }
}

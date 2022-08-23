using System;

namespace TechTalkDemo.Common
{
    // List of Controllers 
    public class ControllersList
    { 
        public class HomeController
        {
            // List of action used
            public const string ActionHome = "Home";
            public const string ActionIndex = "Index"; 

            //List of view used
            public const string ViewIndex = "Index"; 


        }
        public class StudentInfoController
        {
            // List of action used
            public const string ActionViewStudentDetails = "ViewStudentDetails";
            public const string ActionSaveDetails = "SaveDetails";
            public const string ActionEditStudentDetails = "EditStudentDetails";
            public const string ActionDeleteStudentDetails = "DeleteStudentDetails";

            //List of view used
            public const string ViewAddStudent = "AddStudent";
            public const string ViewStudentDetails = "ViewStudentDetails";  

        }



        public class ProgramDetailsController
        {
            // List of action used
            public const string ActionViewProgramDetails = "ViewProgramDetails";
            public const string ActionSaveDetails = "SaveDetails";
            public const string ActionEditProgramDetails = "EditProgram";
            public const string ActionDeleteProgramDetails = "DeleteProgram";

            //List of view used
            public const string ViewAddProgramDetails = "AddProgramDetails";
            public const string ViewProgramDetails = "ViewProgramDetails";

        }



    }
}

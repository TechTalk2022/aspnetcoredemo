using System;
using System.Collections.Generic;
using System.Text;

namespace TechTalkDemo.Common
{
    public class DBSqlQuery
    {
            
        
            public const string Student_Select = "SELECT * FROM [dbo].[StudentInfo] WHERE IsDelete=0";
            public const string Student_DELETE = "UPDATE [dbo].[StudentInfo] SET IsDelete=1 WHERE StudentId=";
            public const string Student_GETById = "SELECT * FROM [dbo].[StudentInfo] Where StudentId=";

         
         
    }
}

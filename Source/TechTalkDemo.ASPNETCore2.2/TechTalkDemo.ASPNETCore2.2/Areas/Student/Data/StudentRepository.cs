using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TechtalkDemo.DBEngine;
using TechTalkDemo.ASPNETCore2._2.Areas.Student.Models;

namespace TechTalkDemo.ASPNETCore2._2.Areas.Student.Data
{
    public interface IStudentRepository
    {
        List<Department> CreateCustomersTable();
        StudentCommanModels ViewStudentDetails();
        DataTable GetStudentDetails();
        void SaveStudentInfo(StudentModel objModel);
        DataTable GetStudentInfoById(int sSId);
        void DeleteStudentInfo(int sSId);
    }
    /// <summary>
    /// 
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ISqlDBConnection _sqlDBConnection;

        public StudentRepository(IConfiguration configuration, ISqlDBConnection sqlDBConnection)
        {
            _configuration = configuration;
            _sqlDBConnection = sqlDBConnection;
        }

        public List<Department> CreateCustomersTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DepartmentID", typeof(int));
            dt.Columns.Add("DepartmentName", typeof(string));

            dt.Rows.Add(1, "BCA");
            dt.Rows.Add(2, "BCOM");
            dt.Rows.Add(3, "BBA");
            dt.Rows.Add(4, "EEE");

            List<Department> listdepartment = new List<Department>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Department department = new Department();
                department.DepartmentID = Convert.ToInt32(dt.Rows[i]["DepartmentID"]);
                department.DepartmentName = dt.Rows[i]["DepartmentName"].ToString();
                listdepartment.Add(department);
            }
            return listdepartment;
        }
        public StudentCommanModels ViewStudentDetails()
        {
            StudentCommanModels lststudentCommanModels = new StudentCommanModels();
            List<StudentModel> liststudent = new List<StudentModel>();
            List<Department> listdepartment = new List<Department>();

            DataTable dataTable = _sqlDBConnection.ExecuteTable("SELECT * FROM [dbo].[StudentInfo] WHERE IsDelete=0");

            listdepartment = CreateCustomersTable();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                StudentModel student = new StudentModel
                {
                    StudentId = Convert.ToInt32(dataTable.Rows[i]["StudentId"]),
                    FirstName = dataTable.Rows[i]["FirstName"].ToString(),
                    LastName = dataTable.Rows[i]["LastName"].ToString(),
                    Department = listdepartment.Where(d => d.DepartmentID == Convert.ToInt32(dataTable.Rows[i]["Department"])).Select(x => x.DepartmentName).Single(),
                    MidleName = dataTable.Rows[i]["MidleName"].ToString()
                };
                liststudent.Add(student);
            }
            lststudentCommanModels.ListStudentModels = liststudent;
            return lststudentCommanModels;


        }

        public DataTable GetStudentDetails()
        {
            DataTable dataTable = _sqlDBConnection.ExecuteTable(TechTalkDemo.Common.DBSqlQuery.Student_Select );
            return dataTable;
        }
        public void SaveStudentInfo(StudentModel objModel)
        {
            try
            {
                string query = "";

                if (objModel.StudentId > 0)
                {
                    query = "UPDATE[dbo].[StudentInfo] SET FirstName ='" + objModel.FirstName + "', MidleName ='" + objModel.MidleName + "', LastName ='" + objModel.LastName + "', Department ='" + objModel.Department + "' WHERE StudentId ='" + objModel.StudentId + "' ";
                }
                else
                {
                    query = "INSERT INTO [dbo].[StudentInfo](FirstName,MidleName,LastName,Department) VALUES('" + objModel.FirstName + "','" + objModel.MidleName + "','" + objModel.LastName + "','" + objModel.Department + "')";
                }

                _sqlDBConnection.ExecuteNonQuery(query);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public DataTable GetStudentInfoById(int sSId)
        {
            return _sqlDBConnection.ExecuteTable(TechTalkDemo.Common.DBSqlQuery.Student_GETById+ sSId); ;
        }

        public void DeleteStudentInfo(int sSId)
        {
            _sqlDBConnection.ExecuteNonQuery(TechTalkDemo.Common.DBSqlQuery.Student_DELETE + sSId);
        }

    }
}

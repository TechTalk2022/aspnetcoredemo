using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TechTalkDemo.ASPNETCore2._2.Areas.Student.Data;
using TechTalkDemo.ASPNETCore2._2.Areas.Student.Models;
using TechTalkDemo.Common;

namespace TechTalkDemo.ASPNETCore2._2.Areas.Student.Controllers
{
    [Area(TechTalkDemo.Common.AreaName.Student)]
    public class StudentInfoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IStudentRepository _iStudentRepository;
        StudentCommanModels studentcommanmodels = new StudentCommanModels();

        public StudentInfoController(IConfiguration configuration, IStudentRepository iStudentRepository)
        {
            _configuration = configuration;
            _iStudentRepository = iStudentRepository;
        }

       

        [Route(URLRouting.StudentInfo.AddStudentDetails)]
        public IActionResult AddStudent()
        {
            studentcommanmodels.ListDepartment = _iStudentRepository.CreateCustomersTable();
            return View(studentcommanmodels);
        }

        [Route(URLRouting.StudentInfo.StudentDetails)]
        public ActionResult ViewStudentDetails()
        {
            return View(_iStudentRepository.GetStudentDetails());
        }
        public IActionResult SaveDetails(StudentModel objModel)
        {
            _iStudentRepository.SaveStudentInfo(objModel);
            return RedirectToAction(ControllersList.StudentInfoController.ViewStudentDetails );
        }
        [Route(URLRouting.StudentInfo.EditStudentDetails)]
        public IActionResult EditStudentDetails(int StudentId)
        {

            DataTable dataTable = _iStudentRepository.GetStudentInfoById(StudentId);
            StudentModel student = new StudentModel();
            student.StudentId = Convert.ToInt32(dataTable.Rows[0][DBFields.StudentInfo.StudentId]);
            student.FirstName = dataTable.Rows[0][DBFields.StudentInfo.FirstName].ToString();
            student.LastName = dataTable.Rows[0][DBFields.StudentInfo.LastName].ToString();
            student.Department = dataTable.Rows[0][DBFields.StudentInfo.Department].ToString();
            student.MidleName = dataTable.Rows[0][DBFields.StudentInfo.MidleName].ToString();
            studentcommanmodels.studentDetails = student;
            studentcommanmodels.ListDepartment = _iStudentRepository.CreateCustomersTable(); ;
            return View(ControllersList.StudentInfoController.ViewAddStudent, studentcommanmodels);
        }
        [Route(URLRouting.StudentInfo.DeleteStudentDetails)]
        public IActionResult DeleteStudentDetails(int StudentId)
        {
            _iStudentRepository.DeleteStudentInfo(StudentId);
            return RedirectToAction(ControllersList.StudentInfoController.ViewStudentDetails);
        }
    }
}
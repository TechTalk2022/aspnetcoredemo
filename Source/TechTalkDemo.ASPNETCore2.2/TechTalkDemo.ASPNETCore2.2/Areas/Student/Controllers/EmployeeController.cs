using Microsoft.AspNetCore.Mvc;
using TechTalkDemo.ASPNETCore2._2.Areas.Student.Data;
using TechTalkDemo.ASPNETCore2._2.Areas.Student.Models;

namespace TechTalkDemo.ASPNETCore2._2.Areas.Student.Controllers
{
    [Area(TechTalkDemo.Common.AreaName.Student)]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }

        public IActionResult ViewEmployee()
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.EmployeeLst = _employeeRepository.GetEmployeeData();
            return View(employeeModel);
        }
    }
}

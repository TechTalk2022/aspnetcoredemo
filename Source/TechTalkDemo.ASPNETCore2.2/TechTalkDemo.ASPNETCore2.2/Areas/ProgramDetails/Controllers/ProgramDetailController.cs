using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechTalkDemo.ASPNETCore2._2.Areas.ProgramDetails.Data;
using TechTalkDemo.ASPNETCore2._2.Areas.ProgramDetails.Models;
using TechTalkDemo.Common;

namespace TechTalkDemo.ASPNETCore2._2.Areas.ProgramDetails.Controllers
{
    [Area(TechTalkDemo.Common.AreaName.ProgramDetails)]
    public class ProgramDetailController : Controller
    {


        private readonly IProgramDetailRepository _programDetailRepository;

        public ProgramDetailController(IProgramDetailRepository programDetailRepository)
        {
            _programDetailRepository = programDetailRepository;
        }
         


        [Route(URLRouting.Program.ProgramDetails)]
        public IActionResult ViewProgramDetails()
        {
            return View(_programDetailRepository.GetProgramDetails());
        }
        [Route(URLRouting.Program.AddProgramDetails)]
        public IActionResult AddProgramDetails()
        {
            return View();
        }
        [Route(URLRouting.Program.EditProgramDetails)]
        public IActionResult EditProgramDetails(int Id)
        {
            DataTable dataTable = _programDetailRepository.GetProgramInfoById(Id);

            ProgramDetail student = new ProgramDetail();
            student.ProgramId = Convert.ToInt32(dataTable.Rows[0][DBFields.ProgramDetails.ProgramId]);
            student.StartYear = Convert.ToInt32(dataTable.Rows[0][DBFields.ProgramDetails.StartYear].ToString());
            student.ProgramCode = dataTable.Rows[0][DBFields.ProgramDetails.ProgramCode].ToString();
            student.ProgramName = dataTable.Rows[0][DBFields.ProgramDetails.ProgramName].ToString();
            student.ProgramDesc = dataTable.Rows[0][DBFields.ProgramDetails.ProgramDesc].ToString();
            student.Duration = Convert.ToInt32(dataTable.Rows[0][DBFields.ProgramDetails.Duration].ToString());
            student.ProgramType = dataTable.Rows[0][DBFields.ProgramDetails.ProgramType].ToString();
            
            return View(ControllersList.ProgramDetailsController.ViewAddProgramDetails, student);
             
        }

        [Route(URLRouting.Program.SaveProgramDetails)]
        public IActionResult SaveProgram(ProgramDetail programDetail)
        {
            _programDetailRepository.SaveProgramInfo(programDetail);

            return RedirectToAction(ControllersList.ProgramDetailsController.ActionViewProgramDetails);
        }

        [Route(URLRouting.Program.DeleteProgramDetails)]
        public IActionResult DeleteProgramDetails(int Id)
        {
            _programDetailRepository.DeleteProgramInfo(Id);

            return RedirectToAction(ControllersList.ProgramDetailsController.ActionViewProgramDetails);
        }

    }
}
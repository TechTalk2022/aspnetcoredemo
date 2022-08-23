using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTalkDemo.ASPNETCore2._2.Models;
using TechTalkDemo.Common;

namespace TechTalkDemo.ASPNETCore2._2.Controllers
{
    public class HomeController : Controller
    { 
        public IActionResult Index()
        { 
            return View();
        }
      
        [Route(URLRouting.Home.Index)]
        public IActionResult Home()
        {
            return View(ControllersList.HomeController.ViewIndex);
        }


        [Route(URLRouting.Home.AdminDashboard)]
        public IActionResult AdminDashboard()
        {
            return View(ControllersList.HomeController.ViewIndex);
        }

        [Route(URLRouting.Home.StaffDashboard)]
        public IActionResult StaffDashboard()
        {
            return View(ControllersList.HomeController.ViewIndex);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

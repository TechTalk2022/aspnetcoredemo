using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTalkDemo.ASPNETCore2._2.Models;
using TechTalkDemo.Common;

namespace TechTalkDemo.ASPNETCore2._2.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult login()
        {
            SigninModel signinModel = new SigninModel();


            return View(signinModel);
        }

        [Route(URLRouting.Login.Logout)]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();


            return View("login");
        }
        [Route(URLRouting.Login.SignIn)]
        public IActionResult SignIn(SigninModel signinModel)
        {
            string Area = "";
            string Controller = "";
            string ControllerAction = "";

            if (signinModel.UserName == "admin")
            {
                HttpContext.Session.SetString("CurrentLayout", "_LayoutAdmin");

                Area = "";
                Controller = "Home";
                ControllerAction = "Index";
            }
            else if (signinModel.UserName == "staff")
            {
                HttpContext.Session.SetString("CurrentLayout", "_LayoutStaff");
                Area = "";
                Controller = "Home";
                ControllerAction = "Index";
            }
            else
            {
                HttpContext.Session.SetString("CurrentLayout", "");
                Area = "";
                Controller = "Login";
                ControllerAction = "login"; 
            }
            // string GetValues = HttpContext.Session.GetString("CurrentLayout");
             
            return RedirectToAction(ControllerAction, Controller, new { area = Area });
            //return RedirectToAction(ControllerAction, Controller);


        }
        [Route(URLRouting.Login.Register)]
        public IActionResult register()
        {
            return View();
        }


    }
}
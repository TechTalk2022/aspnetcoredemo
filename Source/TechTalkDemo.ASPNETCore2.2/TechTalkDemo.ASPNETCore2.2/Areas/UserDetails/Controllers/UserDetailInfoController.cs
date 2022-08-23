using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechTalkDemo.ASPNETCore2._2.Areas.UserDetails.Controllers
{
    [Area("UserDetails")]
    public class UserDetailInfoController : Controller
    {
        [Route("~/add-user-details")]
        public IActionResult UserDetails()
        {
            return View();
        }
    }
}
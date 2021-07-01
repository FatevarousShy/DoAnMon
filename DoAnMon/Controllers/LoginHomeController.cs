using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnMon.Controllers
{
    public class LoginHomeController : Controller
    {
        // GET: LoginHome
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TestBank()
        {
            ViewBag.Message = "Your TestBank page.";

            return View();
        }
    }
}
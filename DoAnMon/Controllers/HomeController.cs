using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnMon.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Trang Chủ.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Về Chúng Tôi.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Trang Liên Lạc.";

            return View();
        }
        public ActionResult Signin()
        {
            ViewBag.Message = "Trang Đăng Nhập.";

            return View();
        }
        public ActionResult SignUp()
        {
            ViewBag.Message = "Trang Đăng Ký.";

            return View();
        }
    }
}
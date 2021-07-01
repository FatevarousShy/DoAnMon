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
        public ActionResult LoginIndex()
        {
            ViewBag.Message = "Trang chủ Admin/Người Dùng.";

            return View();
        }
        public ActionResult TestBank()
        {
            ViewBag.Message = "Trang Ngân Hàng Đề.";

            return View();
        }
        public ActionResult YourAccount()
        {
            ViewBag.Message = "Trang Tài Khoản.";

            return View();
        }
        public ActionResult OnlineTest()
        {
            ViewBag.Message = "Trang Kiểm Tra Trực Tuyến.";

            return View();
        }
        public ActionResult TestPost()
        {
            ViewBag.Message = "Trang Nội Dung Đề.";

            return View();
        }
    }
}
using DoAnMon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnMon.Controllers
{
    public class LoginHomeController : Controller

    {
        WebTNDataContext db = new WebTNDataContext();

        // GET: LoginHome
        public ActionResult LoginIndex()
        {
            ViewBag.Message = "Trang chủ Admin/Người Dùng.";

            return View();
        }
        private List<BoDe> DeThiMoi(int count)
        {
            return db.BoDes.Take(count).ToList();
        }
        public ActionResult TestBank()
        {
            ViewBag.Message = "Trang Ngân Hàng Đề.";
            var de = DeThiMoi(6);
            return View(de);
        }
        public ActionResult MucBoDe()
        {
            var bode = from cd in db.DanhMucBoDes select cd;
            return View(bode);
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
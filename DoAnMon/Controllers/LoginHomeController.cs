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
        WEBTNDataContext db = new WEBTNDataContext();

        // GET: LoginHome
        public ActionResult LoginIndex()
        {
            ViewBag.Message = "Trang chủ Admin/Người Dùng.";

            return View();
        }

        private List<DeThi> DeThiMoi(int count)
        {
            return db.DeThis.Take(count).ToList();
        }
        public ActionResult TestBank()
        {
            ViewBag.Message = "Trang Ngân Hàng Đề.";
            var sachmoi = DeThiMoi(6);
            return View(sachmoi);
        }
        public ActionResult YourAccount()
        {
            ViewBag.Message = "Trang Tài Khoản.";

            return View();
        }

        /*
        public ActionResult Details(int id)
        {
            var ThongTin = from s in data.ThongTins
                           where s.MaTK == id
                           select s;
            return View(ThongTin.Single());
        }*/
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
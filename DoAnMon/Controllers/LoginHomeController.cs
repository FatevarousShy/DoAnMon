using DoAnMon.Models;
using PagedList;
using PagedList.Mvc;
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

        private List<De> Demoi(int count)
        {
            return db.Des.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult TestBank(int? page)
        {
            int pagesize = 5;
            int pagenum = (page ?? 1);

            var de = Demoi(15);
            return View(de.ToPagedList(pagenum, pagesize));

        }

        public ActionResult BoDe()
        {
            var bode = from bd in db.BoDes select bd;
            return PartialView(bode);
        }

        public ActionResult DeTheoBoDe(int id)
        {
            var de = from d in db.Des where d.MaBoDe == id select d;
            return View(de);
        }

        public ActionResult ChiTietDe(int id)
        {
            var de = from d in db.Des
                     where d.MaDe == id
                     select d;
            return View(de.Single());
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

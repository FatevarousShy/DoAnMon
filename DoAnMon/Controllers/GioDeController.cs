using DoAnMon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnMon.Controllers
{
    public class GioDeController : Controller
    {
        // GET: GioDe
        public ActionResult Index()
        {
            return View();
        }
        WEBTNDataContext db = new WEBTNDataContext();
        public List<Giode> LayGiode()
        {
            List<Giode> lsGiode = Session["Giode"] as List<Giode>;
            if (lsGiode == null)
            {
                lsGiode = new List<Giode>();
                Session["Giode"] = lsGiode;
            }
            return lsGiode;
        }

        public ActionResult themGiode(int iMaDe, string stURL)
        {
            List<Giode> lsGiode = LayGiode();
            Giode de = lsGiode.Find(n => n.iMaDe == iMaDe);
            if (de == null)
            {
                de = new Giode(iMaDe);
                lsGiode.Add(de);
                return Redirect(stURL);
            }
            else
            {
                de.iSoLuong++;
                return Redirect(stURL);
            }
        }



        private int TongSoLuong()
        {
            int iTongSL = 0;
            List<Giode> lsGiode = Session["GioDe"] as List<Giode>;
            if (lsGiode != null)
            {
                iTongSL = lsGiode.Sum(n => n.iSoLuong);
            }
            return iTongSL;
        }

        private double TongTien()
        {
            double iTongTien = 0;
            List<Giode> lsGiode = Session["GioDe"] as List<Giode>;
            if (lsGiode != null)
            {
                iTongTien = lsGiode.Sum(n => n.dthanhtien);
            }
            return iTongTien;
        }

        public ActionResult GioDePartical()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //XD trng Gio hang
        public ActionResult GioDe()
        {
            List<Giode> lsGiode = LayGiode();
            if (lsGiode.Count == 0)
            {
                return RedirectToAction("TestBank", "LoginHome");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lsGiode);
        }

        public ActionResult XoaGiode(int iMaSP)
        {
            List<Giode> lsGiode = LayGiode();
            Giode sanpham = lsGiode.SingleOrDefault(n => n.iMaDe == iMaSP);
            if (sanpham != null)
            {
                lsGiode.RemoveAll(n => n.iMaDe == iMaSP);
                return RedirectToAction("GioDe");
            }
            if (lsGiode.Count == 0)
            {
                return RedirectToAction("TestBank", "LoginHome");
            }
            return RedirectToAction("GioDe");
        }

        public ActionResult CapNhatGiode(int iMaSP, FormCollection f)
        {
            List<Giode> lsGiode = LayGiode();
            Giode sanpham = lsGiode.SingleOrDefault(n => n.iMaDe == iMaSP);
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("Giode");
        }

        public ActionResult XoaTatCaGiode()
        {
            List<Giode> lsGiode = LayGiode();
            lsGiode.Clear();
            return RedirectToAction("TestBank", "LoginHome");
        }
    }
}
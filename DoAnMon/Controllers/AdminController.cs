using DoAnMon.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;


namespace DoAnMon.Controllers
{
    public class AdminController : Controller
    {
        WEBTNDataContext db = new WEBTNDataContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            // Gán các giá trị người dùng nhập liệu cho các biến 
            var tendn = collection["username"];
            var matkhau = collection["password"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (ad)        

                admin ad = db.admins.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
                if (ad != null)
                {
                    // ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }

        public ActionResult De(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            //return View(db.Des.ToList());
            return View(db.Des.ToList().OrderBy(n => n.MaDe).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult ThemmoiDe()
        {
            //Dua du lieu vao dropdownList
            //Lay ds tu tabke chu de, sắp xep tang dan trheo ten chu de, chon lay gia tri Ma CD, hien thi thi Tenchude
            ViewBag.MaBoDe = new SelectList(db.BoDes.ToList().OrderBy(n => n.TenBoDe), "MaBoDe", "TenBode");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemmoiDe(De de, HttpPostedFileBase fileUpload)
        {
            //Dua du lieu vao dropdownload
            ViewBag.MaDe = new SelectList(db.BoDes.ToList().OrderBy(n => n.TenBoDe), "MaBoDe", "TenBode");
            //Kiem tra duong dan file
            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            //Them vao CSDL
            else
            {
                if (ModelState.IsValid)
                {
                    //Luu ten fie, luu y bo sung thu vien using System.IO;
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //Luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/Anhbia"), fileName);
                    //Kiem tra hình anh ton tai chua?
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        //Luu hinh anh vao duong dan
                        fileUpload.SaveAs(path);
                    }
                    de.Anhbia = fileName;
                    //Luu vao CSDL
                    db.Des.InsertOnSubmit(de);
                    db.SubmitChanges();
                }
                return RedirectToAction("De");
            }
        }
        //Hiển thị sản phẩm
        public ActionResult Chitietde(int id)
        {
            //Lay ra doi tuong detheo ma
            De de = db.Des.SingleOrDefault(n => n.MaDe == id);
            ViewBag.MaDe = de.MaDe;
            if (de== null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(de);
        }
        //Xóa sản phẩm
        [HttpGet]
        public ActionResult Xoade(int id)
        {
            //Lay ra doi tuong decan xoa theo ma
            De de= db.Des.SingleOrDefault(n => n.MaDe == id);
            ViewBag.MaDe = de.MaDe;
            if (de== null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(de);
        }
        [HttpPost, ActionName("Xoade")]
        public ActionResult Xacnhanxoa(int id)
        {
            //Lay ra doi tuong decan xoa theo ma
            De de= db.Des.SingleOrDefault(n => n.MaDe == id);
            ViewBag.MaDe = de.MaDe;
            if (de== null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Des.DeleteOnSubmit(de);
            db.SubmitChanges();
            return RedirectToAction("De");
        }
        //Chinh sửa sản phẩm
        [HttpGet]
        public ActionResult Suade(int id)
        {
            //Lay ra doi tuong detheo ma
            De de= db.Des.SingleOrDefault(n => n.MaDe == id);
            ViewBag.MaDe = de.MaDe;
            if (de== null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Dua du lieu vao dropdownList
            //Lay ds tu tabke chu de, sắp xep tang dan trheo ten chu de, chon lay gia tri Ma CD, hien thi thi Tenchude
            ViewBag.MaBoDe = new SelectList(db.BoDes.ToList().OrderBy(n => n.TenBoDe), "MaBoDe", "TenBode", de.MaBoDe);
            return View(de);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Suade(De de, HttpPostedFileBase fileUpload)
        {
            //Dua du lieu vao dropdownload
            ViewBag.MaBoDe = new SelectList(db.BoDes.ToList().OrderBy(n => n.TenBoDe), "MaBoDe", "TenBode");
            //Kiem tra duong dan file
            if (fileUpload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            //Them vao CSDL
            else
            {
                if (ModelState.IsValid)
                {
                    //Luu ten fie, luu y bo sung thu vien using System.IO;
                    var fileName = Path.GetFileName(fileUpload.FileName);
                    //Luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/Anhbia"), fileName);
                    //Kiem tra hình anh ton tai chua?
                    if (System.IO.File.Exists(path))
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    else
                    {
                        //Luu hinh anh vao duong dan
                        fileUpload.SaveAs(path);
                    }
                    de.Anhbia = fileName;
                    //Luu vao CSDL   
                    UpdateModel(de);
                    db.SubmitChanges();

                }
                return RedirectToAction("De");
            }
        }
        ////////---//////////Bộ Đề

        public ActionResult BoDe(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            //return View(db.Des.ToList());
            return View(db.BoDes.ToList().OrderBy(n => n.MaBoDe).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Thembode()
        {
            return View();
        }

        public ActionResult Chitietbode(int id)
        {
            //Lay ra doi tuong detheo ma
            BoDe bode = db.BoDes.SingleOrDefault(n => n.MaBoDe == id);
            ViewBag.MaDe = bode.MaBoDe;
            if (bode == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(bode);
        }

        [HttpGet]
        public ActionResult Xoabode(int id)
        {
            //Lay ra doi tuong decan xoa theo ma
            BoDe bode = db.BoDes.SingleOrDefault(n => n.MaBoDe == id);
            ViewBag.MaDe = bode.MaBoDe;
            if (bode == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(bode);
        }
        [HttpPost, ActionName("Xoabode")]
        public ActionResult XacnhanxoaBD(int id)
        {
            //Lay ra doi tuong decan xoa theo ma
            BoDe bode = db.BoDes.SingleOrDefault(n => n.MaBoDe == id);
            ViewBag.MaBODe = bode.MaBoDe;
            if (bode == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.BoDes.DeleteOnSubmit(bode);
            db.SubmitChanges();
            return RedirectToAction("BoDe");
        }

        [HttpGet]
        public ActionResult Suabode(int id)
        {
            //Lay ra doi tuong detheo ma
            BoDe bode = db.BoDes.SingleOrDefault(n => n.MaBoDe == id);
            ViewBag.MaBoDe = bode.MaBoDe;
            if (bode == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(bode);
        }
        ////--------
        ///
        public ActionResult Nguoidung(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            //return View(db.Des.ToList());
            return View(db.NguoiDungs.ToList().OrderBy(n => n.MaND).ToPagedList(pageNumber, pageSize));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnMon.Models;

namespace DoAnMon.Controllers
{
    public class HomeController : Controller
    {
        WebTNDataContext db = new WebTNDataContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Trang Chủ.";

            return View();
        }
        [HttpGet]

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
        public ActionResult Faq()
        {
            ViewBag.Message = "Trang Câu Hỏi Thường Gặp.";

            return View();
        }
        public ActionResult Signin()
        {
            ViewBag.Message = "Trang Đăng Nhập.";

            return View();
        }
        [HttpPost]

        public ActionResult SignUp(FormCollection collection, TaiKhoan kh)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            var email = collection["Email"];

            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phai Nhap Ten Dang Nhap";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phai nhap mat khau";
            }
            if (string.IsNullOrEmpty(email))
            {
                ViewData["loi3"] = "Email khong duoc bo trong";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (kh)
                kh.TenDangNhap = tendn;
                kh.MatKhau = matkhau;
                kh.Email = email;

                db.TaiKhoans.InsertOnSubmit(kh);
                db.SubmitChanges();
                return RedirectToAction("SignIn");
            }
            return this.SignUp();
        }
        [HttpGet]

        public ActionResult SignUp()
        {
            ViewBag.Message = "Trang Đăng Ký.";

            return View();
        }
        [HttpPost]

        public ActionResult SignIn(FormCollection collection)
        {
            // Gán các giá trị người dùng nhập liệu cho các biến 
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
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
                //Gán giá trị cho đối tượng được tạo mới (kh)

                TaiKhoan kh = db.TaiKhoans.SingleOrDefault(n => n.TenDangNhap == tendn && n.MatKhau == matkhau);
                if (kh != null)
                {
                    // ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                    return RedirectToAction("LoginIndex","LoginHome");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
    }
}

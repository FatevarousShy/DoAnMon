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
        WEBTNDataContext db = new WEBTNDataContext();

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

        public ActionResult SignUp(FormCollection collection, NguoiDung kh)
        {
            var hoten = collection["HoTen"];
            var tendn = collection["Taikhoan"];
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai = collection["Matkhaunhaplai"];
            var email = collection["Email"];
            var dienthoai = collection["Dienthoai"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["Ngaysinh"]);
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được để trống";
            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu";
            }


            if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Email không được bỏ trống";
            }

            if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi6"] = "Phải nhập điện thoai";
            }
            else
            {
                //Gán giá trị cho đối tượng được tạo mới (kh)

                kh.HoTen = hoten;
                kh.Taikhoan = tendn;
                kh.Matkhau = matkhau;
                kh.Email = email;
                kh.Dienthoai = dienthoai;
                kh.Ngaysinh = DateTime.Parse(ngaysinh);

                db.NguoiDungs.InsertOnSubmit(kh);
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

                NguoiDung kh = db.NguoiDungs.SingleOrDefault(n => n.Taikhoan == tendn && n.Matkhau == matkhau);
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

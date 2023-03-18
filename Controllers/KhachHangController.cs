using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachOnline.Models;

namespace WebBanSachOnline.Controllers
{
    public class KhachHangController : Controller
    {
        MVCBanSachOnlineEntities1 db = new MVCBanSachOnlineEntities1();
        // GET: KhachHang
        public ActionResult Index()
        {
            return View();
        }
        //get trang đăng ký
        public ActionResult DangKy()
        {
            return View();
        }
        //Post Thông tin đăng ký
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHangMVC kh)
        {
            if(ModelState.IsValid)
            {
                db.KhachHangMVCs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        //Get Trang Đăng Nhập   
        public ActionResult DangNhap()
        {
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
           string sTaiKhoan = f["txtTaiKhoan"].ToString();
           string sMatKhau = f["txtMatKhau"].ToString();
           KhachHangMVC kh = db.KhachHangMVCs.SingleOrDefault(n => n.TaiKhoan.Equals( sTaiKhoan) && n.MatKhau.Equals(sMatKhau));
            if(kh != null && kh.HoTen == "admin" && kh.MatKhau == "123") 
            {
                Session["TaiKhoan"] = kh;
                Session["TenKH"] = kh.HoTen;
                return RedirectToAction("Index", "Admin");
            }
            return View();

        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Home");
        }

    }
}
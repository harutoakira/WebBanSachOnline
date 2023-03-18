using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachOnline.Models;

namespace WebBanSachOnline.Controllers
{
    public class GioHangController : Controller
    {
        MVCBanSachOnlineEntities1 db = new MVCBanSachOnlineEntities1();
        // GET: GioHang
        public ActionResult Giohang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> listGioHang = new List<GioHang>();    
            return View(listGioHang);
        }

        public ActionResult ThemGioHang(int iMaSach, string strURL)
        {
          Sach sach  = db.Saches.SingleOrDefault(n => n.MaSach == iMaSach);
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> listGioHang = LayGioHang();
            GioHang sanpham = listGioHang.Find(n => n.iMaSach== iMaSach);
            if(sanpham == null)
            {
                sanpham = new GioHang(iMaSach);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);

            }
        }

        public ActionResult XoaGioHang(int iMaSP)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSP);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> listGioHang = LayGioHang();
            GioHang sanpham = listGioHang.Find(x => x.iMaSach == iMaSP);
            if (sanpham != null)
            {
                listGioHang.RemoveAll(n => n.iMaSach == sanpham.iMaSach);
            }
           if(listGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Gio Hang");
        }

        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSP);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> listGioHang = LayGioHang();
            GioHang sanpham = listGioHang.Find(x => x.iMaSach == iMaSP);
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return View("GioHang");
        }

        public List<GioHang> LayGioHang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang == null)
            {
                listGioHang = new List<GioHang> ();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }
        private int TongSoLuong()
        {
            int iTongSoLuog = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang != null)
            {
                iTongSoLuog = listGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuog;
        }

        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
               dTongTien = listGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }


    }
}
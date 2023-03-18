using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSachOnline.Models;

namespace WebBanSachOnline.Controllers
{
    public class AdminController : Controller
    {
        MVCBanSachOnlineEntities1 db = new MVCBanSachOnlineEntities1();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexDonhang()
        {
            var Order = db.DonHangs.ToList();
            return View(Order);
        }
        public ActionResult IndexNXB()
        {
            var Nxb = db.NhaXuatBans.ToList();
            return View(Nxb);
        }
        public ActionResult IndexSach()
        {
            var Books = db.Saches.ToList();
            return View(Books);
        }
        public ActionResult IndexChUDe()
        {
            var categories = db.ChuDes.ToList();
            return View(categories);
        }
        public ActionResult CreateNXb()
        {
            return View();
        }
        public ActionResult CreateSach()
        {
            ViewBag.MaChuDe = new SelectList(db.ChuDes, "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans, "MaNXB", "TenNXB");
            return View();
        }
        public ActionResult CreateChuDe()
        {
            return View();
        }

    }
}
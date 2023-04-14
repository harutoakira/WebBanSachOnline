using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanSachOnline.Models;

namespace WebBanSachOnline.Controllers
{
    public class SachesController : Controller
    {
        private MVCBanSachOnlineEntities db = new MVCBanSachOnlineEntities();

        // GET: Saches
        public ActionResult Index()
        {
            var saches = db.Sach.Include(s => s.ChuDe).Include(s => s.NhaXuatBan);
            return View(saches.ToList());
        }

        // GET: Saches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Saches/Create
        public ActionResult Create()
        {
            ViewBag.MaChuDe = new SelectList(db.ChuDe, "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB");
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TenSach,GiaBan,MoTa,AnhBia,NgayCapNhat,SoLuongTon,MaNXB,MaChuDe")] Sach sach, HttpPostedFileBase AnhBia)
        {
            if (ModelState.IsValid)
            {
                if(AnhBia !=null)
                {
                    //Lấy tên file của hình được up lên
                    var fileName = Path.GetFileName(AnhBia.FileName);
                   //Tạo đường dẫn tới file
                    var path = Path.Combine(Server.MapPath("~/Content/assets/image/"), fileName);
                    //Lưu tên
                    sach.AnhBia = fileName;
                    //Lưu vào Ảnh bìa
                    AnhBia.SaveAs(path);
                }
                db.Sach.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChuDe = new SelectList(db.ChuDe, "MaChuDe", "TenChuDe", sach.MaChuDe);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }

        // GET: Saches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChuDe = new SelectList(db.ChuDe, "MaChuDe", "TenChuDe", sach.MaChuDe);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,GiaBan,MoTa,AnhBia,NgayCapNhat,SoLuongTon,MaNXB,MaChuDe")] Sach sach, HttpPostedFileBase AnhBia)
        {
            if (ModelState.IsValid)
            {
                var productDB = db.Sach.FirstOrDefault(p => p.MaSach == sach.MaSach);
                if (productDB == null)
                {
                    return HttpNotFound();
                }

                // Assign values to productDB properties
                productDB.TenSach = sach.TenSach;
                productDB.GiaBan = sach.GiaBan;
                productDB.MoTa = sach.MoTa;
                if (AnhBia != null)
                {
                    var fileName = Path.GetFileName(AnhBia.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/assets/HinhAnhSach"), fileName);
                    productDB.AnhBia = fileName;
                    AnhBia.SaveAs(path);
                }
                productDB.NgayCapNhat = sach.NgayCapNhat;
                productDB.SoLuongTon = sach.SoLuongTon;
                productDB.MaNXB = sach.MaNXB;
                productDB.MaChuDe = sach.MaChuDe;

                db.Entry(productDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChuDe = new SelectList(db.ChuDe, "MaChuDe", "TenChuDe", sach.MaChuDe);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBan, "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }

        // GET: Saches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Sach.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sach sach = db.Sach.Find(id);
            db.Sach.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

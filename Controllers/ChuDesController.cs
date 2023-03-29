using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanSachOnline.Models;

namespace WebBanSachOnline.Controllers
{
    public class ChuDesController : Controller
    {
        private MVCBanSachOnlineEntities db = new MVCBanSachOnlineEntities();

        // GET: ChuDes
        public ActionResult Index()
        {
            return View(db.ChuDe.ToList());
        }

        // GET: ChuDes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuDe chuDe = db.ChuDe.Find(id);
            if (chuDe == null)
            {
                return HttpNotFound();
            }
            return View(chuDe);
        }

        // GET: ChuDes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChuDes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChuDe,TenChuDe")] ChuDe chuDe)
        {
            if (ModelState.IsValid)
            {
                db.ChuDe.Add(chuDe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chuDe);
        }

        // GET: ChuDes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuDe chuDe = db.ChuDe.Find(id);
            if (chuDe == null)
            {
                return HttpNotFound();
            }
            return View(chuDe);
        }

        // POST: ChuDes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChuDe,TenChuDe")] ChuDe chuDe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuDe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chuDe);
        }

        // GET: ChuDes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuDe chuDe = db.ChuDe.Find(id);
            if (chuDe == null)
            {
                return HttpNotFound();
            }
            return View(chuDe);
        }

        // POST: ChuDes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChuDe chuDe = db.ChuDe.Find(id);
            db.ChuDe.Remove(chuDe);
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

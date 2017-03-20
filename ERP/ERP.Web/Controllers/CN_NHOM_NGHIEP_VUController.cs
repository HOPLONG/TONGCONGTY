using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP.Web.Models.Database;

namespace ERP.Web.Controllers
{
    public class CN_NHOM_NGHIEP_VUController : Controller
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: CN_NHOM_NGHIEP_VU
        public ActionResult Index()
        {
            var cN_NHOM_NGHIEP_VU = db.CN_NHOM_NGHIEP_VU.Include(c => c.CCTC_CONG_TY);
            return View(cN_NHOM_NGHIEP_VU.ToList());
        }

        // GET: CN_NHOM_NGHIEP_VU/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CN_NHOM_NGHIEP_VU cN_NHOM_NGHIEP_VU = db.CN_NHOM_NGHIEP_VU.Find(id);
            if (cN_NHOM_NGHIEP_VU == null)
            {
                return HttpNotFound();
            }
            return View(cN_NHOM_NGHIEP_VU);
        }

        // GET: CN_NHOM_NGHIEP_VU/Create
        public ActionResult Create()
        {
            ViewBag.TRUC_THUOC = new SelectList(db.CCTC_CONG_TY, "MA_CONG_TY", "TEN_CONG_TY");
            return View();
        }

        // POST: CN_NHOM_NGHIEP_VU/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TEN_NHOM,DIEN_GIAI,TRUC_THUOC")] CN_NHOM_NGHIEP_VU cN_NHOM_NGHIEP_VU)
        {
            if (ModelState.IsValid)
            {
                db.CN_NHOM_NGHIEP_VU.Add(cN_NHOM_NGHIEP_VU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TRUC_THUOC = new SelectList(db.CCTC_CONG_TY, "MA_CONG_TY", "TEN_CONG_TY", cN_NHOM_NGHIEP_VU.TRUC_THUOC);
            return View(cN_NHOM_NGHIEP_VU);
        }

        // GET: CN_NHOM_NGHIEP_VU/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CN_NHOM_NGHIEP_VU cN_NHOM_NGHIEP_VU = db.CN_NHOM_NGHIEP_VU.Find(id);
            if (cN_NHOM_NGHIEP_VU == null)
            {
                return HttpNotFound();
            }
            ViewBag.TRUC_THUOC = new SelectList(db.CCTC_CONG_TY, "MA_CONG_TY", "TEN_CONG_TY", cN_NHOM_NGHIEP_VU.TRUC_THUOC);
            return View(cN_NHOM_NGHIEP_VU);
        }

        // POST: CN_NHOM_NGHIEP_VU/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TEN_NHOM,DIEN_GIAI,TRUC_THUOC")] CN_NHOM_NGHIEP_VU cN_NHOM_NGHIEP_VU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cN_NHOM_NGHIEP_VU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TRUC_THUOC = new SelectList(db.CCTC_CONG_TY, "MA_CONG_TY", "TEN_CONG_TY", cN_NHOM_NGHIEP_VU.TRUC_THUOC);
            return View(cN_NHOM_NGHIEP_VU);
        }

        // GET: CN_NHOM_NGHIEP_VU/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CN_NHOM_NGHIEP_VU cN_NHOM_NGHIEP_VU = db.CN_NHOM_NGHIEP_VU.Find(id);
            if (cN_NHOM_NGHIEP_VU == null)
            {
                return HttpNotFound();
            }
            return View(cN_NHOM_NGHIEP_VU);
        }

        // POST: CN_NHOM_NGHIEP_VU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CN_NHOM_NGHIEP_VU cN_NHOM_NGHIEP_VU = db.CN_NHOM_NGHIEP_VU.Find(id);
            db.CN_NHOM_NGHIEP_VU.Remove(cN_NHOM_NGHIEP_VU);
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

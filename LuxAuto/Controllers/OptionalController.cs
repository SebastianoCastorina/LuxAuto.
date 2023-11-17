using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LuxAuto.Models;

namespace LuxAuto.Controllers
{
    public class OptionalController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Optional
        public ActionResult Index()
        {
            return View(db.Optional.ToList());
        }

        // GET: Optional/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Optional optional = db.Optional.Find(id);
            if (optional == null)
            {
                return HttpNotFound();
            }
            return View(optional);
        }

        // GET: Optional/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Optional/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idOptional,NomeOptional")] Optional optional)
        {
            if (ModelState.IsValid)
            {
                db.Optional.Add(optional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(optional);
        }

        // GET: Optional/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Optional optional = db.Optional.Find(id);
            if (optional == null)
            {
                return HttpNotFound();
            }
            return View(optional);
        }

        // POST: Optional/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idOptional,NomeOptional")] Optional optional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(optional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(optional);
        }

        // GET: Optional/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Optional optional = db.Optional.Find(id);
            if (optional == null)
            {
                return HttpNotFound();
            }
            return View(optional);
        }

        // POST: Optional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Optional optional = db.Optional.Find(id);
            db.Optional.Remove(optional);
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

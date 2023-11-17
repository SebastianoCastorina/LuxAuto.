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
    public class OptionalAutoController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: OptionalAuto
        public ActionResult Index()
        {
            var optionalAuto = db.OptionalAuto.Include(o => o.Autovettura).Include(o => o.Optional);
            return View(optionalAuto.ToList());
        }

        // GET: OptionalAuto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionalAuto optionalAuto = db.OptionalAuto.Find(id);
            if (optionalAuto == null)
            {
                return HttpNotFound();
            }
            return View(optionalAuto);
        }

        // GET: OptionalAuto/Create
        public ActionResult Create()
        {
            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello");
            ViewBag.idOptional = new SelectList(db.Optional, "idOptional", "NomeOptional");
            return View();
        }

        // POST: OptionalAuto/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idOptInAuto,idAuto,idOptional")] OptionalAuto optionalAuto)
        {
            if (ModelState.IsValid)
            {
                db.OptionalAuto.Add(optionalAuto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello", optionalAuto.idAuto);
            ViewBag.idOptional = new SelectList(db.Optional, "idOptional", "NomeOptional", optionalAuto.idOptional);
            return View(optionalAuto);
        }

        // GET: OptionalAuto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionalAuto optionalAuto = db.OptionalAuto.Find(id);
            if (optionalAuto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello", optionalAuto.idAuto);
            ViewBag.idOptional = new SelectList(db.Optional, "idOptional", "NomeOptional", optionalAuto.idOptional);
            return View(optionalAuto);
        }

        // POST: OptionalAuto/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idOptInAuto,idAuto,idOptional")] OptionalAuto optionalAuto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(optionalAuto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello", optionalAuto.idAuto);
            ViewBag.idOptional = new SelectList(db.Optional, "idOptional", "NomeOptional", optionalAuto.idOptional);
            return View(optionalAuto);
        }

        // GET: OptionalAuto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionalAuto optionalAuto = db.OptionalAuto.Find(id);
            if (optionalAuto == null)
            {
                return HttpNotFound();
            }
            return View(optionalAuto);
        }

        // POST: OptionalAuto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OptionalAuto optionalAuto = db.OptionalAuto.Find(id);
            db.OptionalAuto.Remove(optionalAuto);
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

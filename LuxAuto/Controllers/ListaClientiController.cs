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
    public class ListaClientiController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: ListaClienti
        public ActionResult Index()
        {
            return View(db.ListaClienti.ToList());
        }

        // GET: ListaClienti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaClienti listaClienti = db.ListaClienti.Find(id);
            if (listaClienti == null)
            {
                return HttpNotFound();
            }
            return View(listaClienti);
        }

        // GET: ListaClienti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaClienti/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCliente,Nome,Cognome,Email,NumeroTelefono")] ListaClienti listaClienti)
        {
            if (ModelState.IsValid)
            {
                db.ListaClienti.Add(listaClienti);
                db.SaveChanges();
                return RedirectToAction("Index", "Home"); 
            }

            return View(listaClienti);
        }

        // GET: ListaClienti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaClienti listaClienti = db.ListaClienti.Find(id);
            if (listaClienti == null)
            {
                return HttpNotFound();
            }
            return View(listaClienti);
        }

        // POST: ListaClienti/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCliente,Nome,Cognome,Email,NumeroTelefono")] ListaClienti listaClienti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaClienti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listaClienti);
        }

        // GET: ListaClienti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaClienti listaClienti = db.ListaClienti.Find(id);
            if (listaClienti == null)
            {
                return HttpNotFound();
            }
            return View(listaClienti);
        }

        // POST: ListaClienti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListaClienti listaClienti = db.ListaClienti.Find(id);
            db.ListaClienti.Remove(listaClienti);
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

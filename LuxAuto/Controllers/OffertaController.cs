using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using LuxAuto.Models;
using Microsoft.Ajax.Utilities;

namespace LuxAuto.Controllers
{
    public class OffertaController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Offerta
        public ActionResult Index()
        {
            var offerta = db.Offerta.Include(o => o.Asta).Include(o => o.Autovettura).Include(o => o.User);
            return View(offerta.ToList());
        }

        // GET: Offerta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offerta offerta = db.Offerta.Find(id);
            if (offerta == null)
            {
                return HttpNotFound();
            }
            return View(offerta);
        }

        // GET: Offerta/Create
        public ActionResult Create()
        {
            var autovettureConAsta = db.Autovettura
                    .Where(a => a.HasAsta == true)
                    .ToList();

                ViewBag.idAuto = new SelectList(autovettureConAsta, "idAuto", "NomeModello");
         
            
            ViewBag.idAsta = new SelectList(db.Asta, "idAsta", "idAsta");
          
            ViewBag.idUser = new SelectList(db.User, "idUser", "Nome");
            return View();
        }

        // POST: Offerta/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idOfferta,OffertaFatta,idUser,idAuto,idAsta")] Offerta offerta)
        {

            //GET USER ID
            
            
            User user = db.User.Where(u=>u.Username == User.Identity.Name).FirstOrDefault();
            if (ModelState.IsValid)
            {
                offerta.idUser = user.idUser;   
                offerta.DataOfferta=DateTime.Now;
                db.Offerta.Add(offerta);
                db.SaveChanges();

                // Aggiorna il prezzo attuale nell'asta
                var asta = db.Asta.Find(offerta.idAsta);
                if (asta != null)
                {
                    asta.UltimaOfferta = offerta.OffertaFatta.ToString(); // Aggiorna il prezzo attuale con l'offerta fatta
                    db.Entry(asta).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Asta");
            }
            return View("Index","Asta");
            }
         
            // ... (gestione degli errori)
       

      






        // GET: Offerta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offerta offerta = db.Offerta.Find(id);
            if (offerta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAsta = new SelectList(db.Asta, "idAsta", "idAsta", offerta.idAsta);
            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello", offerta.idAuto);
            ViewBag.idUser = new SelectList(db.User, "idUser", "Nome", offerta.idUser);
            return View(offerta);
        }

        // POST: Offerta/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idOfferta,OffertaFatta,DataOfferta,idUser,idAuto,idAsta")] Offerta offerta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offerta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAsta = new SelectList(db.Asta, "idAsta", "idAsta", offerta.idAsta);
            ViewBag.idAuto = new SelectList(db.Autovettura, "idAuto", "NomeModello", offerta.idAuto);
            ViewBag.idUser = new SelectList(db.User, "idUser", "Nome", offerta.idUser);
            return View(offerta);
        }

        // GET: Offerta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offerta offerta = db.Offerta.Find(id);
            if (offerta == null)
            {
                return HttpNotFound();
            }
            return View(offerta);
        }

        // POST: Offerta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offerta offerta = db.Offerta.Find(id);
            db.Offerta.Remove(offerta);
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

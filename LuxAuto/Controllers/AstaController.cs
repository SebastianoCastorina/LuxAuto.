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
    public class AstaController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Asta
        public ActionResult Index()
        {
            var astaList = db.Asta.Where(a => DateTime.Now < a.DataChiusuraAsta).ToList(); 
               

            foreach (var asta in astaList)
            {
                var ultimaOfferta = db.Offerta
                    .Where(o => o.idAsta == asta.idAsta)
                    .OrderByDescending(o => o.DataOfferta)
                    .FirstOrDefault();

                if (ultimaOfferta != null)
                {
                    asta.UltimaOfferta = ultimaOfferta.OffertaFatta.ToString();
                }
            }

            return View(astaList);
        }

        // GET: Asta/Create
        public ActionResult Create()
        {
            // Filtra solo le auto che hanno HasAsta impostato su true
            var autovettureConAsta = db.Autovettura
                .Where(a => a.HasAsta == true)
                .ToList();

            ViewBag.idAuto = new SelectList(autovettureConAsta, "idAuto", "NomeModello", "PrezzoBase");

            return View();
        }

        // POST: Asta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UltimaOfferta, idAsta,idAuto,PrezzoBase,DataChiusuraAsta")] Asta asta)
        {
            if (ModelState.IsValid)
            {
             
             db.Asta.Add(asta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Filtra solo le auto che hanno HasAsta impostato su true in caso di errore di validazione
            var autovettureConAsta = db.Autovettura
                .Where(a => a.HasAsta == true)
                .ToList();

            ViewBag.idAuto = new SelectList(autovettureConAsta, "idAuto", "NomeModello", asta.idAuto);
            return View(asta);
        }



        // GET: Asta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Asta asta = db.Asta.Find(id);

            if (asta == null)
            {
                return HttpNotFound();
            }

            // Recupera le immagini dell'auto associata dal modello Autovettura
            var autovettura = db.Autovettura
                .Where(av => av.idAuto == asta.idAuto)
                .FirstOrDefault();

            if (autovettura != null)
            {
                asta.CaroselloImages = new List<string>
        {
            autovettura.Foto,
            autovettura.Foto1,
            autovettura.Foto2,
            autovettura.Foto3,
            autovettura.Foto4,
            autovettura.Foto5,
            autovettura.Foto6
        };
            }

            return View(asta);
        }


        // GET: Asta/Create




        // GET: Asta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asta asta = db.Asta.Find(id);
            if (asta == null)
            {
                return HttpNotFound();
            }
            return View(asta);
        }

        // POST: Asta/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAsta,idAuto,PrezzoBase")] Asta asta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asta);
        }

        // GET: Asta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asta asta = db.Asta.Find(id);
            if (asta == null)
            {
                return HttpNotFound();
            }
            return View(asta);
        }

        // POST: Asta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asta asta = db.Asta.Find(id);

            if (asta == null)
            {
                return HttpNotFound();
            }

            db.Asta.Remove(asta);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using LuxAuto.Models;

namespace LuxAuto.Controllers
{
    public class MarchioController : Controller
    {
        private ModelDBContext db = new ModelDBContext();


        public ActionResult Index()
        {
            var marchi = db.Marchio.ToList();
            return View(marchi);

        }


        public JsonResult GetMarchiDistincti()
        {
            var marchiDistinti = db.Marchio.Select(m => m.NomeMarchio).Distinct().ToList();
            return Json(marchiDistinti, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FilterByMarchio(string selectedMarchio)
        {
            // Esegui la logica per filtrare e ottenere i marchi distinti
            var marchiDistinti = db.Marchio.Select(m => m.NomeMarchio).Distinct().ToList();

            // Crea oggetti SelectListItem dal tuo elenco di stringhe
            var selectListItems = marchiDistinti.Select(marchio => new SelectListItem
            {
                Text = marchio,
                Value = marchio
            });

            // Imposta i dati nella ViewData con la chiave corretta "selectedMarchio"
            ViewData["selectedMarchio"] = new SelectList(selectListItems, "Value", "Text", selectedMarchio);

            // Non è necessario fare nulla qui, l'azione Index gestirà il filtro
            return RedirectToAction("Index", new { marchio = selectedMarchio });
        }
        // GET: Marchio


        // GET: Marchio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marchio marchio = db.Marchio.Find(id);
            if (marchio == null)
            {
                return HttpNotFound();
            }
            return View(marchio);
        }
      

        // GET: Marchio/Create
        public ActionResult Create()
        {
            return View();
        }





        // POST: Marchio/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Marchio marchio, HttpPostedFileBase Logo)
        {
            if (ModelState.IsValid)
            {
                if (Logo != null && Logo.ContentLength > 0)
                {
                    // Genera un nome univoco per il file
                    string nomeLogo = Guid.NewGuid().ToString() + Path.GetExtension(Logo.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img/LoghiMarchi"), nomeLogo);

                    // Salva il file sul server
                    Logo.SaveAs(path);

                    // Assegna il nome del file alla proprietà Logo
                    marchio.Logo = nomeLogo;
                }
                else
                {
                    marchio.Logo = ""; // o qualsiasi valore predefinito desiderato
                }

                db.Marchio.Add(marchio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marchio);
        }

        // GET: Marchio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marchio marchio = db.Marchio.Find(id);
            if (marchio == null)
            {
                return HttpNotFound();
            }
            return View(marchio);
        }

        // POST: Marchio/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMarchio,NomeMarchio,BreveStoria")] Marchio marchio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marchio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marchio);
        }

        // GET: Marchio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marchio marchio = db.Marchio.Find(id);
            if (marchio == null)
            {
                return HttpNotFound();
            }
            return View(marchio);
        }

        // POST: Marchio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marchio marchio = db.Marchio.Find(id);
            db.Marchio.Remove(marchio);
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

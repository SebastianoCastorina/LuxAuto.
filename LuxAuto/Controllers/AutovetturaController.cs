using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using LuxAuto.Models;

namespace LuxAuto.Controllers
{
    public class AutovetturaController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: Autovettura
        public ActionResult ListaCarFiltrate()
        {
            ViewData["selectedMarchio"] = new SelectList(db.Marchio, "NomeMarchio", "NomeMarchio");
            return View();

        }

        public ActionResult Index(string marchio)
        {
            var autovettura = db.Autovettura.Include(a => a.Marchio).Include(a => a.OptionalAuto);

            if (!string.IsNullOrEmpty(marchio))
            {
                autovettura = autovettura.Where(a => a.Marchio.NomeMarchio == marchio);
            }
            ViewData["selectedMarchio"] = new SelectList(db.Marchio, "NomeMarchio", "NomeMarchio");
            return View(autovettura.ToList());
        }


        [HttpPost]
        public ActionResult FilterByMarchio(string selectedMarchio)
        {
            var autovettura = db.Autovettura.Include(a => a.Marchio).Include(a => a.OptionalAuto);

            if (!string.IsNullOrEmpty(selectedMarchio))
            {
                autovettura = autovettura.Where(a => a.Marchio.NomeMarchio == selectedMarchio);
            }

            
            ViewData["selectedMarchio"] = new SelectList(db.Marchio, "NomeMarchio", "NomeMarchio");

            return View("Index", autovettura.ToList());
        }

        // GET: Autovettura/Details/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Autovettura carDetails = db.Autovettura.Find(id);

            if (carDetails == null)
            {
                return HttpNotFound();
            }

            // Popola la lista di immagini del carosello
            carDetails.CaroselloImages = new List<string>
    {
        carDetails.Foto,
        carDetails.Foto1,
        carDetails.Foto2,
        carDetails.Foto3,
        carDetails.Foto4,
        carDetails.Foto5,
        carDetails.Foto6
    };

            return View(carDetails);






        }

    


        // GET: Autovettura/Create
        public ActionResult Create()
        {
            ViewBag.idMarchio = new SelectList(db.Marchio, "idMarchio", "NomeMarchio");
            ViewBag.idOptInAuto = new SelectList(db.OptionalAuto, "idOptInAuto", "idOptInAuto");
            return View();
        }

        // POST: Autovettura/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Autovettura a, HttpPostedFileBase Foto, HttpPostedFileBase Foto1, HttpPostedFileBase Foto2, HttpPostedFileBase Foto3, HttpPostedFileBase Foto4, HttpPostedFileBase Foto5, HttpPostedFileBase Foto6)
        {
            if (ModelState.IsValid)
            {
              
                    

                    if (Foto != null && Foto.ContentLength > 0)
                    {
                        string nomeFile = Foto.FileName;
                        string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile);
                        Foto.SaveAs(path);
                        a.Foto = nomeFile;

                        
                    }
                    else 
                    {
                        a.Foto = "";
                    
                        // Imposta un valore predefinito o vuoto per la foto
                    }
                    if( Foto1 != null && Foto1.ContentLength > 0 )
                        
                    {
                 

                    string nomeFile1 = Foto1.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile1);
                    Foto1.SaveAs(path);
                    a.Foto1 = nomeFile1;

                   
                }
                    else
                {
                    a.Foto1 = "";

                    // Imposta un valore predefinito o vuoto per la foto
                }
                if (Foto2 != null && Foto2.ContentLength > 0)

                {


                    string nomeFile2 = Foto2.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile2);
                    Foto2.SaveAs(path);
                    a.Foto2 = nomeFile2;


                }
                else
                {
                    a.Foto2 = "";

                    // Imposta un valore predefinito o vuoto per la foto
                }
                if (Foto3 != null && Foto3.ContentLength > 0)

                {


                    string nomeFile3 = Foto3.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile3);
                    Foto3.SaveAs(path);
                    a.Foto3 = nomeFile3;


                }
                else
                {
                    a.Foto3 = "";

                    // Imposta un valore predefinito o vuoto per la foto
                }
                if (Foto4 != null && Foto4.ContentLength > 0)

                {


                    string nomeFile4 = Foto4.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile4);
                    Foto4.SaveAs(path);
                    a.Foto4 = nomeFile4;


                }
                else
                {
                    a.Foto4 = "";

                    // Imposta un valore predefinito o vuoto per la foto
                }
                if (Foto5 != null && Foto5.ContentLength > 0)

                {


                    string nomeFile5 = Foto5.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile5);
                    Foto5.SaveAs(path);
                    a.Foto5 = nomeFile5;


                }
                else
                {
                    a.Foto5 = "";

                    // Imposta un valore predefinito o vuoto per la foto
                }
                if (Foto6 != null && Foto6.ContentLength > 0)

                {


                    string nomeFile6 = Foto6.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile6);
                    Foto6.SaveAs(path);
                    a.Foto6 = nomeFile6;


                }
                else
                {
                    a.Foto6 = "";

                    // Imposta un valore predefinito o vuoto per la foto
                }
                


                db.Autovettura.Add(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Per favore fai le cose per bene";
                return View();
            }
        }
            //ViewBag.idMarchio = new SelectList(db.Marchio, "idMarchio", "NomeMarchio", a.idMarchio);
            //ViewBag.idOptInAuto = new SelectList(db.OptionalAuto, "idOptInAuto", "idOptInAuto", a.idOptInAuto);
            //return View(a);


            // GET: Autovettura/Edit/5
            public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autovettura autovettura = db.Autovettura.Find(id);
            if (autovettura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMarchio = new SelectList(db.Marchio, "idMarchio", "NomeMarchio", autovettura.idMarchio);
           
            return View(autovettura);
        }

        // POST: Autovettura/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Autovettura a, HttpPostedFileBase Foto, HttpPostedFileBase Foto1, HttpPostedFileBase Foto2, HttpPostedFileBase Foto3, HttpPostedFileBase Foto4, HttpPostedFileBase Foto5, HttpPostedFileBase Foto6)
        {
            if (ModelState.IsValid)
            {



                if (Foto != null && Foto.ContentLength > 0)
                {
                    string nomeFile = Foto.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile);
                    Foto.SaveAs(path);
                    a.Foto = nomeFile;


                }
                else
                {
                    a.Foto = "";

                    // Imposta un valore predefinito o vuoto per la foto
                }
                if (Foto1 != null && Foto1.ContentLength > 0)

                {


                    string nomeFile1 = Foto1.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile1);
                    Foto1.SaveAs(path);
                    a.Foto1 = nomeFile1;


                }
                else
                {
                    a.Foto1 = "";

                    // Imposta un valore predefinito o vuoto per la foto
                }
                if (Foto2 != null && Foto2.ContentLength > 0)

                {


                    string nomeFile2 = Foto2.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile2);
                    Foto2.SaveAs(path);
                    a.Foto2 = nomeFile2;


                }
                else
                {
                    a.Foto2 = "";

                    // Imposta un valore predefinito o vuoto per la foto
                }
                if (Foto3 != null && Foto3.ContentLength > 0)

                {


                    string nomeFile3 = Foto3.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile3);
                    Foto3.SaveAs(path);
                    a.Foto3 = nomeFile3;


                }
                else
                {
                    a.Foto3 = "";

                    // Imposta un valore predefinito o vuoto per la foto
                }
                if (Foto4 != null && Foto4.ContentLength > 0)

                {


                    string nomeFile4 = Foto4.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile4);
                    Foto4.SaveAs(path);
                    a.Foto4 = nomeFile4;


                }
                else
                {
                    a.Foto4 = "";

                    // Imposta un valore predefinito o vuoto per la foto
                }
                if (Foto5 != null && Foto5.ContentLength > 0)

                {


                    string nomeFile5 = Foto5.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile5);
                    Foto5.SaveAs(path);
                    a.Foto5 = nomeFile5;


                }
                else
                {
                    a.Foto5 = "";

                    // Imposta un valore predefinito o vuoto per la foto
                }
                if (Foto6 != null && Foto6.ContentLength > 0)

                {


                    string nomeFile6 = Foto6.FileName;
                    string path = Path.Combine(Server.MapPath("~/Content/assets/img"), nomeFile6);
                    Foto6.SaveAs(path);
                    a.Foto6 = nomeFile6;


                }
                else
                {
                    a.Foto6 = "";

                    // Imposta un valore predefinito o vuoto per la foto
                }



                db.Autovettura.Add(a);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Per favore fai le cose per bene";
                return View();
            }
        }
            // GET: Autovettura/Delete/5
            public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autovettura autovettura = db.Autovettura.Find(id);
            if (autovettura == null)
            {
                return HttpNotFound();
            }
            return View(autovettura);
        }

        // POST: Autovettura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autovettura autovettura = db.Autovettura.Find(id);
            db.Autovettura.Remove(autovettura);
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

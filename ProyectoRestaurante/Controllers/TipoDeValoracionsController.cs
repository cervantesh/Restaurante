using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoRestaurante.Models;

namespace ProyectoRestaurante.Controllers
{
    public class TipoDeValoracionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoDeValoracions
        public ActionResult Index()
        {
            return View(db.TipoDeValoracions.ToList());
        }

        // GET: TipoDeValoracions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeValoracion tipoDeValoracion = db.TipoDeValoracions.Find(id);
            if (tipoDeValoracion == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeValoracion);
        }

        // GET: TipoDeValoracions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeValoracions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoDeValoracionID,Descripcion")] TipoDeValoracion tipoDeValoracion)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeValoracions.Add(tipoDeValoracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDeValoracion);
        }

        // GET: TipoDeValoracions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeValoracion tipoDeValoracion = db.TipoDeValoracions.Find(id);
            if (tipoDeValoracion == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeValoracion);
        }

        // POST: TipoDeValoracions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoDeValoracionID,Descripcion")] TipoDeValoracion tipoDeValoracion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeValoracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDeValoracion);
        }

        // GET: TipoDeValoracions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeValoracion tipoDeValoracion = db.TipoDeValoracions.Find(id);
            if (tipoDeValoracion == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeValoracion);
        }

        // POST: TipoDeValoracions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeValoracion tipoDeValoracion = db.TipoDeValoracions.Find(id);
            db.TipoDeValoracions.Remove(tipoDeValoracion);
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

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
    public class TipoRestaurantesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoRestaurantes
        public ActionResult Index()
        {
            return View(db.TipoRestaurantes.ToList());
        }

        // GET: TipoRestaurantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRestaurante tipoRestaurante = db.TipoRestaurantes.Find(id);
            if (tipoRestaurante == null)
            {
                return HttpNotFound();
            }
            return View(tipoRestaurante);
        }

        // GET: TipoRestaurantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoRestaurantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoRestauranteID,Descripcion")] TipoRestaurante tipoRestaurante)
        {
            if (ModelState.IsValid)
            {
                db.TipoRestaurantes.Add(tipoRestaurante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoRestaurante);
        }

        // GET: TipoRestaurantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRestaurante tipoRestaurante = db.TipoRestaurantes.Find(id);
            if (tipoRestaurante == null)
            {
                return HttpNotFound();
            }
            return View(tipoRestaurante);
        }

        // POST: TipoRestaurantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoRestauranteID,Descripcion")] TipoRestaurante tipoRestaurante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoRestaurante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoRestaurante);
        }

        // GET: TipoRestaurantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoRestaurante tipoRestaurante = db.TipoRestaurantes.Find(id);
            if (tipoRestaurante == null)
            {
                return HttpNotFound();
            }
            return View(tipoRestaurante);
        }

        // POST: TipoRestaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoRestaurante tipoRestaurante = db.TipoRestaurantes.Find(id);
            db.TipoRestaurantes.Remove(tipoRestaurante);
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

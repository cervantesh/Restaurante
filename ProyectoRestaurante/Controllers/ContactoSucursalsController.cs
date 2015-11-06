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
    public class ContactoSucursalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactoSucursals
        public ActionResult Index()
        {
            return View(db.ContactoSucursals.ToList());
        }

        // GET: ContactoSucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactoSucursal contactoSucursal = db.ContactoSucursals.Find(id);
            if (contactoSucursal == null)
            {
                return HttpNotFound();
            }
            return View(contactoSucursal);
        }

        // GET: ContactoSucursals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactoSucursals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactoSucursalID,E_mail,Contacto,Telefono,FKSucursalID")] ContactoSucursal contactoSucursal)
        {
            if (ModelState.IsValid)
            {
                db.ContactoSucursals.Add(contactoSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactoSucursal);
        }

        // GET: ContactoSucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactoSucursal contactoSucursal = db.ContactoSucursals.Find(id);
            if (contactoSucursal == null)
            {
                return HttpNotFound();
            }
            return View(contactoSucursal);
        }

        // POST: ContactoSucursals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactoSucursalID,E_mail,Contacto,Telefono,FKSucursalID")] ContactoSucursal contactoSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactoSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactoSucursal);
        }

        // GET: ContactoSucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactoSucursal contactoSucursal = db.ContactoSucursals.Find(id);
            if (contactoSucursal == null)
            {
                return HttpNotFound();
            }
            return View(contactoSucursal);
        }

        // POST: ContactoSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactoSucursal contactoSucursal = db.ContactoSucursals.Find(id);
            db.ContactoSucursals.Remove(contactoSucursal);
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

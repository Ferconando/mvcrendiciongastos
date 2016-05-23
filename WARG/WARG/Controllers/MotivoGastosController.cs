using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entidades;

namespace WARG.Models
{
    [Authorize]
    public class MotivoGastosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MotivoGastos
        public ActionResult Index()
        {
            return View(db.MotivoGastoes.ToList());
        }
                
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotivoGasto motivoGasto = db.MotivoGastoes.Find(id);
            if (motivoGasto == null)
            {
                return HttpNotFound();
            }
            return View(motivoGasto);
        }

        // GET: MotivoGastos/Create
        public ActionResult Create()
        {
            return View();
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MotivoID,Motivo")] MotivoGasto motivoGasto)
        {
            if (ModelState.IsValid)
            {
                db.MotivoGastoes.Add(motivoGasto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(motivoGasto);
        }
                
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotivoGasto motivoGasto = db.MotivoGastoes.Find(id);
            if (motivoGasto == null)
            {
                return HttpNotFound();
            }
            return View(motivoGasto);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MotivoID,Motivo")] MotivoGasto motivoGasto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(motivoGasto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(motivoGasto);
        }
                
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MotivoGasto motivoGasto = db.MotivoGastoes.Find(id);
            if (motivoGasto == null)
            {
                return HttpNotFound();
            }
            return View(motivoGasto);
        }
                
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MotivoGasto motivoGasto = db.MotivoGastoes.Find(id);
            db.MotivoGastoes.Remove(motivoGasto);
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

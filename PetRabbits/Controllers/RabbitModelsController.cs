using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetRabbits.Models;

namespace PetRabbits.Controllers
{
    public class RabbitModelsController : Controller
    {
        private PetRabbitsContext db = new PetRabbitsContext();

        // GET: RabbitModels
        public ActionResult Index()
        {
            return View(db.RabbitModels.ToList());
        }

        // GET: RabbitModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RabbitModel rabbitModel = db.RabbitModels.Find(id);
            if (rabbitModel == null)
            {
                return HttpNotFound();
            }
            return View(rabbitModel);
        }

        // GET: RabbitModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RabbitModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RabbitID,RabbitName,RabbitAge,RabbitBreed,IsNeutered")] RabbitModel rabbitModel)
        {
            if (ModelState.IsValid)
            {
                db.RabbitModels.Add(rabbitModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rabbitModel);
        }

        // GET: RabbitModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RabbitModel rabbitModel = db.RabbitModels.Find(id);
            if (rabbitModel == null)
            {
                return HttpNotFound();
            }
            return View(rabbitModel);
        }

        // POST: RabbitModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RabbitID,RabbitName,RabbitAge,RabbitBreed,IsNeutered")] RabbitModel rabbitModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rabbitModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rabbitModel);
        }

        // GET: RabbitModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RabbitModel rabbitModel = db.RabbitModels.Find(id);
            if (rabbitModel == null)
            {
                return HttpNotFound();
            }
            return View(rabbitModel);
        }

        // POST: RabbitModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RabbitModel rabbitModel = db.RabbitModels.Find(id);
            db.RabbitModels.Remove(rabbitModel);
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

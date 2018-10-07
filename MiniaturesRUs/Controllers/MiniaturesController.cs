using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniaturesRUs.Models;

namespace MiniaturesRUs.Controllers
{
    public class MiniaturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Miniatures
        public ActionResult Index()
        {
            return View(db.Minitures.ToList());
        }

        // GET: Miniatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miniature miniature = MiniatureDB.GetMiniatureById(id);
            if (miniature == null)
            {
                return HttpNotFound();
            }
            return View(miniature);
        }

        // GET: Miniatures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Miniatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Miniid,Name,Price,Description,Year,GameName,Faction,Speed,Attack,Strength,HitPoints,Defense")] Miniature miniature)
        {
            if (ModelState.IsValid)
            {
                MiniatureDB.AddMiniatureToDB(miniature);
                return RedirectToAction("Index");
            }

            return View(miniature);
        }

        // GET: Miniatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miniature miniature = MiniatureDB.GetMiniatureById(id);
            if (miniature == null)
            {
                return HttpNotFound();
            }
            return View(miniature);
        }

        // POST: Miniatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Miniid,Name,Price,Description,Year,GameName,Faction,Speed,Attack,Strength,HitPoints,Defense")] Miniature miniature)
        {
            if (ModelState.IsValid)
            {
                MiniatureDB.UpdateMiniature(miniature);
                return RedirectToAction("Index");
            }
            return View(miniature);
        }

        // GET: Miniatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miniature miniature = MiniatureDB.GetMiniatureById(id);
            if (miniature == null)
            {
                return HttpNotFound();
            }
            return View(miniature);
        }

        // POST: Miniatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miniature miniature = db.Minitures.Find(id);
            db.Minitures.Remove(miniature);
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

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

        [HttpGet]
        public ActionResult Search(MiniatureSearchViewModel search)
        {

            if (UserHasNotSearched(search))
            {
                return View(search);
            }

            //IQueryable results DO NOT query database
            IQueryable<Miniature> query =
                from p in db.Miniatures
                select p;

            if (search.Name != null)
            {
                query = from p in query
                        where p.Name == search.Name
                        select p;
            }
            if (search.Price.HasValue)
            {
                query = from p in query
                        where p.Price >= search.Price
                        select p;
            }
            if (search.Description != null)
            {
                query = from p in query
                        where p.Description == search.Description
                        select p;
            }
            if (search.Year.HasValue)
            {
                query = from p in query
                        where p.Year == search.Year
                        select p;
            }
            if (search.GameName != null)
            {
                query = from p in query
                        where p.GameName == search.GameName
                        select p;
            }
            if (search.Faction != null)
            {
                query = from p in query
                        where p.Faction == search.Faction
                        select p;
            }
            if (search.Size != null)
            {
                query = from p in query
                        where p.Size == search.Size
                        select p;
            }
            if (search.Speed.HasValue)
            {
                query = from p in query
                        where p.Speed >= search.Speed
                        select p;
            }
            if (search.Attack.HasValue)
            {
                query = from p in query
                        where p.Attack >= search.Attack
                        select p;
            }
            if (search.Strength.HasValue)
            {
                query = from p in query
                        where p.Strength >= search.Strength
                        select p;
            }
            if (search.HitPoints.HasValue)
            {
                query = from p in query
                        where p.HitPoints >= search.HitPoints
                        select p;
            }
            if (search.Defense.HasValue)
            {
                query = from p in query
                        where p.Defense >= search.Defense
                        select p;
            }

            //SEND completed query to database and get products
            search.SearchResults = query.ToList();

            return View(search);
        }

        private bool UserHasNotSearched(MiniatureSearchViewModel search)
        {
            if (search.Name == null &&
                search.Price == null &&
                search.Description == null &&
                search.Year == null &&
                search.GameName == null &&
                search.Faction == null &&
                search.Size == null &&
                search.Speed == null &&
                search.Attack == null &&
                search.Strength == null &&
                search.HitPoints == null &&
                search.Defense == null
                )
            {
                return true;
            }

            return false;
        }

        // GET: Miniatures
        public ActionResult Index(int? id)
        {
            int page = id ?? 1;

            const byte PageSize = 15;

            ViewBag.CurrentPage = page;

            List<Miniature> prods = MiniatureDB.GetProductsByPage(page, PageSize);

            int numProducts = MiniatureDB.GetTotalProducts();

            int maxPage = (int)Math.Ceiling(numProducts / (double)PageSize);

            ViewBag.MaxPage = maxPage;

            return View(prods);
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
            Miniature miniature = MiniatureDB.GetMiniatureById(id);
            MiniatureDB.DeleteMiniature(miniature);
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

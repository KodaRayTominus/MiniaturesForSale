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
        //private ApplicationDbContext db = new ApplicationDbContext();

        //[HttpGet]
        //public ActionResult Search(MiniatureSearchViewModel search)
        //{

        //    if (UserHasNotSearched(search))
        //    {
        //        return View(search);
        //    }

        //    //string maxPrice = Request.Form["MaxPrice"];
        //    //if (maxPrice == null) { }

        //    //SELECT * FROM Products
        //    //IQueryable results DO NOT query database
        //    IQueryable<Miniature> query =
        //        from p in db.Minitures
        //        select p;

        //    if (search.MaxPrice.HasValue)
        //    {
        //        //Adds WHERE price < search.MaxPrice
        //        query = from p in query
        //                where p.Price <= search.MaxPrice.Value
        //                select p;
        //    }
        //    if (search.MinPrice.HasValue)
        //    {
        //        //Add minPrice to WHERE clause
        //        query = from p in query
        //                where p.Price >= search.MinPrice.Value
        //                select p;
        //    }
        //    if (search.ProductName != null)
        //    {
        //        query = from p in query
        //                where p.Title.Contains(search.ProductName)
        //                select p;
        //    }
        //    if (search.Category != null)
        //    {
        //        query = from p in query
        //                where p.Category == search.Category
        //                select p;
        //    }

        //    //SEND completed query to database and get products
        //    search.SearchResults = query.ToList();

        //    return View(search);
        //}

        //private bool UserHasNotSearched(MiniatureSearchViewModel search)
        //{
        //    if ()
        //    {
        //        return true;
        //    }

        //    return false;
        //}

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

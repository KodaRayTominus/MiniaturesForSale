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
    public class ProductOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductOrders
        public ActionResult Index()
        {
            var productOrders = db.ProductOrders.Include(p => p.Miniature).Include(p => p.Order);
            return View(productOrders.ToList());
        }

        // GET: ProductOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrder productOrder = ProductOrderDB.GetProductOrderById(id);
            if (productOrder == null)
            {
                return HttpNotFound();
            }
            return View(productOrder);
        }

        // GET: ProductOrders/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Miniatures, "MiniId", "Name");
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId");
            return View();
        }

        // POST: ProductOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,ProductId")] ProductOrder productOrder)
        {
            if (ModelState.IsValid)
            {
                ProductOrderDB.AddProductOrderToDB(productOrder);
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Miniatures, "MiniId", "Name", productOrder.ProductId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", productOrder.OrderId);
            return View(productOrder);
        }

        // GET: ProductOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrder productOrder = ProductOrderDB.GetProductOrderById(id);
            if (productOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Miniatures, "MiniId", "Name", productOrder.ProductId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", productOrder.OrderId);
            return View(productOrder);
        }

        // POST: ProductOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,ProductId")] ProductOrder productOrder)
        {
            if (ModelState.IsValid)
            {
                ProductOrderDB.UpdateProductOrder(productOrder);
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Miniatures, "MiniId", "Name", productOrder.ProductId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "OrderId", productOrder.OrderId);
            return View(productOrder);
        }

        // GET: ProductOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductOrder productOrder = ProductOrderDB.GetProductOrderById(id);
            if (productOrder == null)
            {
                return HttpNotFound();
            }
            return View(productOrder);
        }

        // POST: ProductOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductOrder productOrder = ProductOrderDB.GetProductOrderById(id);
            ProductOrderDB.DeleteProductOrder(productOrder);
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

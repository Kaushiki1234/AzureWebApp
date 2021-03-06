using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AzureWebApp.Models;

namespace AzureWebApp.Controllers
{
    public class RetailStoresController : Controller
    {
        private RetailStoreContext db = new RetailStoreContext();

        // GET: RetailStores
        public ActionResult Index()
        {
            return View(db.RetailStores.ToList());
        }

        // GET: RetailStores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RetailStore retailStore = db.RetailStores.Find(id);
            if (retailStore == null)
            {
                return HttpNotFound();
            }
            return View(retailStore);
        }

        // GET: RetailStores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RetailStores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Quantity,Price")] RetailStore retailStore)
        {
            if (ModelState.IsValid)
            {
                db.RetailStores.Add(retailStore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(retailStore);
        }

        // GET: RetailStores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RetailStore retailStore = db.RetailStores.Find(id);
            if (retailStore == null)
            {
                return HttpNotFound();
            }
            return View(retailStore);
        }

        // POST: RetailStores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Quantity,Price")] RetailStore retailStore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(retailStore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(retailStore);
        }

        // GET: RetailStores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RetailStore retailStore = db.RetailStores.Find(id);
            if (retailStore == null)
            {
                return HttpNotFound();
            }
            return View(retailStore);
        }

        // POST: RetailStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RetailStore retailStore = db.RetailStores.Find(id);
            db.RetailStores.Remove(retailStore);
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

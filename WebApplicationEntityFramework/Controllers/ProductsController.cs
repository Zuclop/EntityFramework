﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationEntityFramework.Models;

namespace WebApplicationEntityFramework.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Products
        public ActionResult Index()
        {
            var listProd = db.Products.Include(p => p.ProductType);
            return View(listProd);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Include(p => p.ProductType).Where(t=>t.ProductID==id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            SelectList types = new SelectList(db.ProductTypes, "ProductTypeId", "Name");
            ViewBag.Types = types;
            return View();
        }

        // POST: Products/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductType productType = db.ProductTypes.Find(product.ProductTypeId);
                product.ProductType = productType;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            SelectList types = new SelectList(db.ProductTypes, "ProductTypeId", "Name");
            ViewBag.Types = types;
            return View(product);
        }

        // POST: Products/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                //Product oldProduct = db.Products.Include(p => p.ProductType).Where(t => t.ProductID == product.ProductID).FirstOrDefault();
                ProductType productType = db.ProductTypes.Find(product.ProductTypeId);
                product.ProductType = productType;
                db.Entry(product).State = EntityState.Modified;
                db.Entry(product.ProductType).State = EntityState.Modified;
                //db.Entry(oldProduct).CurrentValues.SetValues(product);
                //db.Entry(oldProduct.ProductType).CurrentValues.SetValues(product.ProductType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
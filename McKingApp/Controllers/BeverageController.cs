using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McKingApp.Controllers
{
    public class BeverageController : Controller
    {
        private McKingBurgerContext db;
        public BeverageController(McKingBurgerContext db)
        {
            this.db = db;
        }
        // GET: BeverageController
        public ActionResult Index()
        {
            return View(this.db.Beverages is null ? new List<Beverage>() : this.db.Beverages.ToList());
        }

        // GET: BeverageController/Details/5
        public ActionResult Details(int? id)
        {
            return View(this.db.Beverages.Find(id));
        }

        // GET: BeverageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BeverageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Beverage beverage)
        {
            if (ModelState.IsValid)
            {
                db.Beverages.Add(beverage);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(beverage);
        }

        // GET: BeverageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.Beverages.Find(id));
        }

        // POST: BeverageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Beverage beverage)
        {
            if (ModelState.IsValid)
            {
                db.Beverages.Update(beverage);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }

        // GET: BeverageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(this.db.Beverages.Find(id));
        }

        // POST: BeverageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Beverage beverage)
        {
            Beverage toFind = this.db.Beverages.Find(id);
            db.Beverages.Remove(toFind);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

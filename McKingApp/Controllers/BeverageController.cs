using DomainModel;
using McKingApp.Repository;
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
        private ICrud<Beverage> repository;
        public BeverageController(ICrud<Beverage> repository)
        {
            this.repository = repository;
        }
        // GET: BeverageController
        public ActionResult Index()
        {
            return View(this.repository.ReadAll() is null ? new List<Beverage>() : this.repository.ReadAll().ToList());
        }

        // GET: BeverageController/Details/5
        public ActionResult Details(int id)
        {
            return View(this.repository.Read(id));
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
                repository.Create(beverage);
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }

        // GET: BeverageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Read(id));
        }

        // POST: BeverageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Beverage beverage)
        {
            if (ModelState.IsValid)
            {
                repository.Update(beverage);
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }

        // GET: BeverageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.Read(id));
        }

        // POST: BeverageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Beverage beverage)
        {
            repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

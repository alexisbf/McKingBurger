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
    public class BurgerController : Controller
    {
        private ICrudAsync<Burger> repository;
        public BurgerController(ICrudAsync<Burger> repository)
        {
            this.repository = repository;
        }
        
        // GET: BurgerController
        public ActionResult Index()
        {
            return View(this.repository.ReadAll() is null ? new List<Burger>() : this.repository.ReadAll().ToList());
        }

        // GET: BurgerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var read = await repository.ReadAsync(id);
            return View(read);
        }

        // GET: BurgerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BurgerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BurgerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BurgerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BurgerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BurgerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

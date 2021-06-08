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
        public async Task<ActionResult> Create(Burger burger)
        {
            if (ModelState.IsValid)
            {
                await repository.CreateAsync(burger);
                return RedirectToAction(nameof(Index));
            }
            return View(burger);                      
        }

        // GET: BurgerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var edit = await repository.ReadAsync(id);
            return View(edit);
        }

        // POST: BurgerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Burger burger)
        {
            if (ModelState.IsValid)
            {
                await repository.UpdateAsync(burger);
                return RedirectToAction(nameof(Index));
            }
            return View(burger);
        }

        // GET: BurgerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var delete = await repository.ReadAsync(id);
            return View(delete);
        }

        // POST: BurgerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            await repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

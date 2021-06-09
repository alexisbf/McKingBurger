using Dal;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McKingApp.Repository.ViewComponents
{
    public class BurgerDetailsViewComponent : ViewComponent
    {
        private readonly McKingBurgerContext context;

        public BurgerDetailsViewComponent(McKingBurgerContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int menuId)
        {
            var burger = await GetBurgerByMenuId(menuId);
            return View(burger);
        }

        private Task<List<Burger>> GetBurgerByMenuId(int menuId)
        {
            return this.context.Menus.Where(m => m.Id == menuId).Select(m => m.Burger).ToListAsync();
        }
    }
}

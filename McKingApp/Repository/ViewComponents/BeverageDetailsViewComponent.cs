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
    public class BeverageDetailsViewComponent : ViewComponent
    {
        private readonly McKingBurgerContext context;

        public BeverageDetailsViewComponent(McKingBurgerContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int menuId)
        {
            var burger = await GetBeverageByMenuId(menuId);
            return View(burger);
        }

        private Task<List<Beverage>> GetBeverageByMenuId(int menuId)
        {
            return this.context.Menus.Where(m => m.Id == menuId).Select(m => m.Beverage).ToListAsync();
        }
    }
}

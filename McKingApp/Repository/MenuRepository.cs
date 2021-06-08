using Dal;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McKingApp.Repository
{
    public class MenuRepository : ICrud<Menu>
    {
        private McKingBurgerContext context;
        public MenuRepository(McKingBurgerContext context)
        {
            this.context = context;
        }

        public void Create(Menu menu)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Menu Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Menu> ReadAll()
        {
            return this.context.Menus
                .Include(m => m.Burger)
                .Include(m => m.Beverage)
                .Include(m => m.Description)
                .Include(m => m.Dessert);
        }

        public void Update(Menu menu)
        {
            throw new NotImplementedException();
        }
    }
}

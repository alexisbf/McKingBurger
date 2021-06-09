using Dal;
using DomainModel;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using McKingApp.Repository.Interfaces;

namespace McKingApp.Repository
{
    public class BeverageRepository : ICrud<Beverage>
    {
        private McKingBurgerContext context;
        public BeverageRepository(McKingBurgerContext context)
        {
            this.context = context;
        }
        public void Create(Beverage beverage)
        {
            this.context.Beverages.Add(beverage);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            Beverage beverage = this.context.Beverages.Find(id);
            var tempMenus = this.context.Menus.Where(m => m.Id == id).ToList();
            tempMenus.ForEach(value => context.Menus.Remove(value));
            this.context.Beverages.Remove(beverage);
            this.context.SaveChanges();
        }

        public Beverage Read(int id)
        {
            return this.context.Beverages.Find(id);
        }

        public IQueryable<Beverage> ReadAll() => this.context.Beverages;

        public void Update(Beverage beverage)
        {
            var entry = this.context.Entry(beverage);
            entry.State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}

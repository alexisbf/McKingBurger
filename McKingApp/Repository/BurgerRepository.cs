using Dal;
using DomainModel;
using McKingApp.Repository.Interfaces;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace McKingApp.Repository
{
    public class BurgerRepository : ICrudAsync<Burger>
    {
        private McKingBurgerContext context;

        public BurgerRepository(McKingBurgerContext context)
        {
            this.context = context;
        }

        public async Task<Burger> ReadAsync(int id)
        {
            var read = await context.Burgers.FindAsync(id);
            return read;
        }

        public IQueryable<Burger> ReadAll() => this.context.Burgers;

        public async Task CreateAsync(Burger burger)
        {
            this.context.Burgers.Add(burger);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var burger = this.context.Burgers.Find(id);
            var tempMenus = this.context.Menus.Where(m => m.Id == id).ToList();
            tempMenus.ForEach(value => context.Menus.Remove(value));
            this.context.Burgers.Remove(burger);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Burger burger)
        {
            this.context.Burgers.Update(burger);
            await this.context.SaveChangesAsync();
        }
    }
}

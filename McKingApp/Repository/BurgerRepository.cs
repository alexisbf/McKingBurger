﻿using Dal;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McKingApp.Repository
{
    public class BurgerRepository : ICrud<Burger>
    {
        private McKingBurgerContext context;
        public BurgerRepository(McKingBurgerContext context)
        {
            this.context = context;
        }

        public void Create(Burger burger)
        {
            this.context.Burgers.Add(burger);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            Burger burger = this.context.Burgers.Find(id);
            this.context.Burgers.Remove(burger);
            this.context.SaveChanges();
        }

        public Burger Read(int id)
        {
            return this.context.Burgers.Find(id);
        }

        public IQueryable<Burger> ReadAll() => this.context.Burgers;

        public void Update(Burger burger)
        {
            this.context.Burgers.Update(burger);
            this.context.SaveChanges();
        }
    }
}

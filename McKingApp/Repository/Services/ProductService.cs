using Dal;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McKingApp.Repository.Services
{
    public class ProductService
    {
        private readonly McKingBurgerContext context;
        public ProductService(McKingBurgerContext context)
        {
            this.context = context;
        }

        public List<Burger> GetBurgers()
        {
            return this.context.Burgers.ToList();
        }

        public List<Beverage> GetBeverages()
        {
            return this.context.Beverages.ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using DomainModel;
using System;

namespace Dal
{
    public class McKingBurgerContext : DbContext
    {
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Product> Products { get; set; }

        public McKingBurgerContext()
            : base()
        {
        }

        public McKingBurgerContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("SchoolDatabaseMemory");
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=McKingBurgerDatabase;Integrated Security=true");

            base.OnConfiguring(optionsBuilder);
        }

    }

}

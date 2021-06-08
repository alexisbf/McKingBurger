using System;
using DomainModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class McKingBurgerContextExtension
    {
        public static void Initialize(this McKingBurgerContext context, bool dropAlways = false)
        {
            if(dropAlways) 
                context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Menus.Any())
                return;

            var beverages = new List<Beverage>()
            {
                new Beverage
                {
                    Name = "Coca",
                    Price = 1.7M,
                    Description = "Meilleure boisson du monde",
                    Stockpiled = 0,
                    Millimeter = 330,
                    IsCarbonated = true
                },
                new Beverage
                {
                    Name = "Orangina",
                    Price = 2M,
                    Description = "Boisson à l'orange",
                    Stockpiled = 0,
                    Millimeter = 350,
                    IsCarbonated = true
                },
                new Beverage
                {
                    Name = "Evian",
                    Price = 1.5M,
                    Description = "L'eau, c'est la vie",
                    Stockpiled = 0,
                    Millimeter = 500,
                    IsCarbonated = false
                }
            };

            context.Beverages.AddRange(beverages);

            var burgers = new List<Burger>()
            {
                new Burger
                {
                    Name = "Le Burgé",
                    Price = 11.2M,
                    Description = "Pour les amateurs de viande",
                    Stockpiled = 0,
                    BeefWeight = 200,
                    Weight = 350
                },
                new Burger
                {
                    Name = "Cheese Burgé",
                    Price = 12M,
                    Description = "Le même, mais au fromage",
                    Stockpiled = 0,
                    BeefWeight = 200,
                    Weight = 400
                },
                new Burger
                {
                    Name = "Le Fô Burgé",
                    Price = 1.5M,
                    Description = "celui qui n'a pas de viande",
                    Stockpiled = 0,
                    BeefWeight = 0,
                    Weight = 375
                }
            };

            context.Burgers.AddRange(burgers);
            var sides = new List<Side>()
            {
                new Side
                {
                    Name = "P'tite salade",
                    Price = 6.5M,
                    Description = "Ça va bien avec le fô",
                    Stockpiled = 0,
                    Weight = 50,
                    SaltWeight = 5
                },
                new Side
                {
                    Name = "P'tiote frite",
                    Price = 3.5M,
                    Description = "C'est bon avec un burgé",
                    Stockpiled = 0,
                    Weight = 150,
                    SaltWeight = 2
                },
                new Side
                {
                    Name = "Frites Fantasy",
                    Price = 1.5M,
                    Description = "Mais pas la fantasy de Tolkien, hein",
                    Stockpiled = 0,
                    Weight = 200,
                    SaltWeight = 3
                }
            };

            context.Sides.AddRange(sides);

            var Desserts = new List<Dessert>()
            {
                new Dessert
                {
                    Name = "Glace Fleurie",
                    Price = 4.5M,
                    Description = "Elle sent pas la rose",
                    Stockpiled = 0,
                    Millimeter = 200,
                    IsFrozen = true
                },
                new Dessert
                {
                    Name = "P'tiote Pomme",
                    Price = 4M,
                    Description = "C'pour lô vegan, hein",
                    Stockpiled = 0,
                    Millimeter = 100,
                    IsFrozen = false
                },
                new Dessert
                {
                    Name = "Cookie",
                    Price = 1.5M,
                    Description = "Bah c'est bon",
                    Stockpiled = 0,
                    Millimeter = 80,
                    IsFrozen = false
                }
            };

            context.Sides.AddRange(sides);

            var menus = new List<Menu>()
            {
                new Menu
                {
                    Name = "Le gros Menu",
                    Price = 15M,
                    Description = "Un menu pour les gros",
                    Stockpiled = 0,
                    Beverage =  beverages[1],
                    Burger = burgers[0],
                    Dessert = Desserts[2],
                    Side = sides[0]
                    
                },
                new Menu
                {
                    Name = "Le fô Menu",
                    Price = 15M,
                    Description = "Un menu pour les fô",
                    Stockpiled = 0,
                    Beverage = beverages[0],
                    Burger = burgers[2],
                    Dessert = Desserts[0],
                    Side = sides[0]
                },
                new Menu
                {
                    Name = "Le p'tiot Menu",
                    Price = 15M,
                    Description = "Un menu pour les pitchounes",
                    Stockpiled = 0,
                    Beverage = beverages[2],
                    Burger = burgers[1],
                    Side = sides[2]
                }
            };

            context.Menus.AddRange(menus);

            context.SaveChanges();
        }
    }
}

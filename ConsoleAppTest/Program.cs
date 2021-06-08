using System;
using Dal;
using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new McKingBurgerContext())
            {
                context.Initialize();
                foreach(var item in context.Menus
                    .Include(m => m.Burger)
                    .Include(m => m.Beverage)
                    .Include(m => m.Dessert)
                    .Include(m => m.Description)
                    )
                {
                    Console.WriteLine($"{item.Name}, {item.Burger.Name}, {item.Beverage.Name}");
                }
            } 
        }
    }
}

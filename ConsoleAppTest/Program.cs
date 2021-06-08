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
                context.Initialize(true);
                foreach(var item in context.Burgers)
                {
                    Console.WriteLine($"{item.Name}");
                }
            } 
        }
    }
}

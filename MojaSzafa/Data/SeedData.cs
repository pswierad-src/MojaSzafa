using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MojaSzafa.Models;
using System;
using System.Linq;

namespace MojaSzafa.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new MojaSzafaContext(serviceProvider.GetRequiredService<DbContextOptions<MojaSzafaContext>>()))
            {
                if (!_context.Clothes.Any())
                {
                    _context.Clothes.Add(new Clothing { Name = "koszula", Material = "len", Color = "biały", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "spodnie", Material = "jeans", Color = "indygo", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "marynarka", Material = "bawełna", Color = "szary", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "buty", Material = "skóra", Color = "brązowy", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "t-shirt", Material = "bawełna", Color = "biały", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "koszula", Material = "len", Color = "biały", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "spodnie", Material = "jeans", Color = "indygo", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "marynarka", Material = "bawełna", Color = "szary", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "buty", Material = "skóra", Color = "brązowy", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "t-shirt", Material = "bawełna", Color = "biały", DateAdded = DateTime.Now });

                    _context.SaveChanges();
                }               
            }
        }
    }
}

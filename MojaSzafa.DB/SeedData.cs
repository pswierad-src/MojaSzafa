using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MojaSzafa.DB.Entities;
using System;
using System.Linq;

namespace MojaSzafa.DB
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
                    _context.Clothes.Add(new Clothing { Name = "oksfordy", Material = "skóra", Color = "brązowy", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "buty sportowe", Material = "skóra", Color = "biały", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "buty sportowe", Material = "siatka", Color = "szary", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "t-shirt", Material = "bawełna", Color = "czerwony", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "t-shirt", Material = "bawełna", Color = "biały", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "kurtka", Material = "skóra", Color = "czarny", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "płaszcz", Material = "bawełna", Color = "beżowy", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "koszula", Material = "len", Color = "czarny", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "koszula", Material = "len", Color = "niebieski", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "spodnie", Material = "len", Color = "beżowy", DateAdded = DateTime.Now });
                    _context.Clothes.Add(new Clothing { Name = "spodnie", Material = "denim", Color = "niebieski", DateAdded = DateTime.Now });


                    _context.SaveChanges();
                }
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MojaSzafa.DB.Entities;

namespace MojaSzafa.DB
{
    public class MojaSzafaContext : DbContext
    {
        public MojaSzafaContext(DbContextOptions<MojaSzafaContext> options)
            : base(options)
        {
        }

        public static MojaSzafaContext Create(DbContextOptions<MojaSzafaContext> options)
        {
            return new MojaSzafaContext(options);
        }

        public DbSet<Clothing> Clothes { get; set; }
    }
}

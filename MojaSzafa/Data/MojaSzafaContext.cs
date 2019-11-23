using Microsoft.EntityFrameworkCore;
using MojaSzafa.Models;

namespace MojaSzafa
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

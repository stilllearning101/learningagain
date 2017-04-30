using SportsStore.Domain.Entities;
using System.Data.Entity;

namespace SportsStore.Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
    }
}
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PortalContext: DbContext
    {
        public PortalContext(DbContextOptions<PortalContext> options): base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
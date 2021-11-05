
using Core.Interfaces;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PortalContext: DbContext, IPortalContext
    {
        public PortalContext(DbContextOptions<PortalContext> options): base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}
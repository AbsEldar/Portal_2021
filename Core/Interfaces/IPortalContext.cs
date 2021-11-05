using System.Threading;
using System.Threading.Tasks;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces
{
    public interface IPortalContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductBrand> ProductBrands { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }

        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
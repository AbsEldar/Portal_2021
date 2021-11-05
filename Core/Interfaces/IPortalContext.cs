using System.Threading;
using System.Threading.Tasks;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces
{
    public interface IPortalContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
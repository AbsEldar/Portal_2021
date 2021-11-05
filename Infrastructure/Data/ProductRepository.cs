using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Domains;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly IPortalContext _context;
        public ProductRepository(IPortalContext context)
        {
            _context = context;

        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
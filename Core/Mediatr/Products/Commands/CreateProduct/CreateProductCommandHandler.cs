using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Interfaces;
using Domains;
using MediatR;

namespace Core.Mediatr.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IPortalContext _context;
        public CreateProductCommandHandler(IPortalContext context)
        {
            _context = context;

        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                Name = request.Name,
                PictureUrl = request.PictureUrl,
                Price = request.Price,
                ProductBrandId = request.ProductBrandId,
                ProductTypeId = request.ProductTypeId
            };

            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
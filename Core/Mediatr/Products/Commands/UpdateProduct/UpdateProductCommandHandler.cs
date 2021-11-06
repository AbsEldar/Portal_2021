using System.Threading;
using System.Threading.Tasks;
using Core.Common.Exceptions;
using Core.Interfaces;
using Domains;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Mediatr.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IPortalContext _dbContext;
        public UpdateProductCommandHandler(IPortalContext context)
        {
            _dbContext = context;

        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Products.FirstOrDefaultAsync(prod => prod.Id == request.Id, cancellationToken);
 
            if(entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }
 
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.PictureUrl = request.PictureUrl;
            entity.Price = request.Price;
            entity.ProductBrandId = request.ProductBrandId;
            entity.ProductTypeId = request.ProductTypeId;
 
            await _dbContext.SaveChangesAsync(cancellationToken);
 
            return Unit.Value;
        }
    }
}
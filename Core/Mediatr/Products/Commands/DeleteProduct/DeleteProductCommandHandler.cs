using System.Threading;
using System.Threading.Tasks;
using Core.Common.Exceptions;
using Core.Interfaces;
using Domains;
using MediatR;

namespace Core.Mediatr.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IPortalContext _dbContext;
        public DeleteProductCommandHandler(IPortalContext context)
        {
            _dbContext = context;

        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
              var entity = await _dbContext.Products.FindAsync(new object[] {request.Id}, cancellationToken);
 
             if(entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }
 
            _dbContext.Products.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
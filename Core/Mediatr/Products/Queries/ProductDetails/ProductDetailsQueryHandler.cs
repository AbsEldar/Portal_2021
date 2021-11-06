using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Common.Exceptions;
using Core.Interfaces;
using Core.Specifications.SpecModels;
using Domains;
using MediatR;

namespace Core.Mediatr.Products.Queries.ProductDetails
{
    public class ProductDetailsQueryHandler : IRequestHandler<ProductDetailsQuery, ProductDetailsVm>
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IMapper _mapper;
        public ProductDetailsQueryHandler(IGenericRepository<Product> productsRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productsRepo = productsRepo;

        }

        public async Task<ProductDetailsVm> Handle(ProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(request.Id);
            var entity = await _productsRepo.GetEntityWithSpec(spec);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return _mapper.Map<ProductDetailsVm>(entity);
        }
    }
}
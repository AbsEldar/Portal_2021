using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications.SpecModels;
using Domains;
using MediatR;

namespace Core.Mediatr.Products.Queries.ProductList
{
    public class ProductListQueryHandler : IRequestHandler<ProductListQuery, ProductListVm>
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        public ProductListQueryHandler(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productRepo = productRepo;

        }
        public async Task<ProductListVm> Handle(ProductListQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(request.ProductSpecParams);
            var countSpec = new ProductWithFiltersForCountSpecification(request.ProductSpecParams);
            var totalItems = await _productRepo.CountAsync(countSpec);
            var products = await _productRepo.ListAsync(spec);

            
           

            var plv = new ProductListVm();
            plv.Data = _mapper.Map<IList<ProductLookupDto>>(products);
            plv.TotalItems = totalItems;
            plv.PageIndex = request.ProductSpecParams.PageIndex;
            plv.PageSize = request.ProductSpecParams.PageSize;

            
            return plv;
        }
    }
}
using System;
using Core.Specifications;
using MediatR;

namespace Core.Mediatr.Products.Queries.ProductList
{
    public class ProductListQuery: IRequest<ProductListVm>
    {
        // public string Sort { get; set; }
        // public Guid? BrandId { get; set; }
        // public Guid? TypeId { get; set; }
        public ProductSpecParams ProductSpecParams {get; set;}
    }
}
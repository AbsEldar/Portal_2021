using System;
using MediatR;

namespace Core.Mediatr.Products.Queries.ProductDetails
{
    public class ProductDetailsQuery: IRequest<ProductDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
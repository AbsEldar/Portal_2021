using System;
using MediatR;

namespace Core.Mediatr.Products.Commands.CreateProduct
{
    public class CreateProductCommand: IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid ProductBrandId { get; set; }
    }
}
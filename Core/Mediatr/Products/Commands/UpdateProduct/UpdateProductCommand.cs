using System;
using MediatR;

namespace Core.Mediatr.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand: IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid ProductBrandId { get; set; }
        
    }
}
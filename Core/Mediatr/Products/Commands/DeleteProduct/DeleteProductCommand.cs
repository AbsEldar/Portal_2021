using System;
using MediatR;

namespace Core.Mediatr.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand: IRequest
    {
        public Guid Id { get; set; }
    }
}
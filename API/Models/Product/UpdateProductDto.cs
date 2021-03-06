using System;
using AutoMapper;
using Core.Common.Mappings;
using Core.Mediatr.Products.Commands.UpdateProduct;

namespace API.Models.Product
{
    public class UpdateProductDto: IMapWith<UpdateProductCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid ProductBrandId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductDto, UpdateProductCommand>()
            .ForMember(prCommand => prCommand.Id, opt => opt.MapFrom(product => product.Id))
            .ForMember(prCommand => prCommand.Name, opt => opt.MapFrom(product => product.Name))
            .ForMember(prCommand => prCommand.Description, opt => opt.MapFrom(product => product.Description))
            .ForMember(prCommand => prCommand.Price, opt => opt.MapFrom(product => product.Price))
            .ForMember(prCommand => prCommand.PictureUrl, opt => opt.MapFrom(product => product.PictureUrl))
            .ForMember(prCommand => prCommand.ProductTypeId, opt => opt.MapFrom(product => product.ProductTypeId))
            .ForMember(prCommand => prCommand.ProductBrandId, opt => opt.MapFrom(product => product.ProductBrandId));
        }
    }
}
using System;
using AutoMapper;
using Core.Common.Mappings;
using Domains;

namespace Core.Mediatr.Products.Queries.ProductList
{
    public class ProductLookupDto: IMapWith<Product>
    {
         public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookupDto>()
            .ForMember(productVm => productVm.Id, opt => opt.MapFrom(product => product.Id))
            .ForMember(productVm => productVm.Name, opt => opt.MapFrom(product => product.Name))
            .ForMember(productVm => productVm.Description, opt => opt.MapFrom(product => product.Description))
            .ForMember(productVm => productVm.Price, opt => opt.MapFrom(product => product.Price))
            .ForMember(productVm => productVm.PictureUrl, opt => opt.MapFrom(product => product.PictureUrl))
            .ForMember(productVm => productVm.ProductType, opt => opt.MapFrom(product => product.ProductType.Name))
            .ForMember(productVm => productVm.ProductBrand, opt => opt.MapFrom(product => product.ProductBrand.Name));
        }
    }
}
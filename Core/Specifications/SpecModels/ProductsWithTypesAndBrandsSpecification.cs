using System;
using Domains;

namespace Core.Specifications.SpecModels
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {

         public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy( x => x.Name);
           
        }
        // public ProductsWithTypesAndBrandsSpecification(string sort, Guid? brandId, Guid? typeId)
        //       : base(x =>
        //         (!brandId.HasValue || x.ProductBrandId == brandId) &&
        //         (!typeId.HasValue || x.ProductTypeId == typeId)
        //     )
        // {
        //     AddInclude(x => x.ProductType);
        //     AddInclude(x => x.ProductBrand);
        //     AddOrderBy( x => x.Name);
 
        //     if(!string.IsNullOrEmpty(sort))
        //     {
        //         switch (sort)
        //         {
        //             case "priceAsc": 
        //                 AddOrderBy(p => p.Price);
        //                 break;
        //             case "priceDesc": 
        //                 AddOrderByDescending(p => p.Price);
        //                 break;
        //             default:
        //                 AddOrderBy(n => n.Name);
        //                 break;
        //         }
        //     }
        // }

        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
            : base(x =>
                 (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
                (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy( x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex -1), productParams.PageSize);
 
            if(!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc": 
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc": 
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }
        public ProductsWithTypesAndBrandsSpecification(Guid id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

    }
}
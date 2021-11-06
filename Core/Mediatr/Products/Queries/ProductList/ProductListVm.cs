using System.Collections.Generic;

namespace Core.Mediatr.Products.Queries.ProductList
{
    public class ProductListVm
    {
        public IList<ProductLookupDto> Products { get; set; }
    }
}
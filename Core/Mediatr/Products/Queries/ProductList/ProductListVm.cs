using System.Collections.Generic;

namespace Core.Mediatr.Products.Queries.ProductList
{
    public class ProductListVm
    {
        public IList<ProductLookupDto> Data { get; set; }
        public int TotalItems { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
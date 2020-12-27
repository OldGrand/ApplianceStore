using ApplianceStore.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ApplianceStore.Tests.Comparers
{
    class ProductDTOComparer : IEqualityComparer<ProductDTO>
    {
        public bool Equals(ProductDTO x, ProductDTO y)
        {
            return x.Id == y.Id &&
               x.Title == y.Title &&
               x.Manufacturer == y.Manufacturer &&
               x.Description == y.Description &&
               x.Price == y.Price &&
               x.CountInStock == y.CountInStock &&
               x.IsAvailable == y.IsAvailable &&
               x.Photo == y.Photo;
        }

        public int GetHashCode([DisallowNull] ProductDTO obj)
        {
            return HashCode.Combine(obj.Id, obj.Title, obj.Manufacturer, obj.Description,
                obj.Price, obj.CountInStock, obj.IsAvailable, obj.Photo);
        }
    }
}

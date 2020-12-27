using ApplianceStore.PL.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ApplianceStore.Tests.Comparers
{
    class ProductBindingModelComparer : IEqualityComparer<ProductBindingModel>
    {
        public bool Equals([AllowNull] ProductBindingModel x, [AllowNull] ProductBindingModel y)
        {
            return x.Title == y.Title &&
                   x.Manufacturer == y.Manufacturer &&
                   x.Description == y.Description &&
                   x.Price == y.Price &&
                   x.CountInStock == y.CountInStock &&
                   x.IsAvailable == y.IsAvailable &&
                   x.Photo == y.Photo;
        }

        public int GetHashCode([DisallowNull] ProductBindingModel obj)
        {
            return HashCode.Combine(obj.Title, obj.Manufacturer, obj.Description, 
                obj.Price, obj.CountInStock, obj.IsAvailable, obj.Photo);
        }
    }
}

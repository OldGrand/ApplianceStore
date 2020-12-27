using ApplianceStore.PL.Models.BindingModels;
using System.Collections.Generic;

namespace ApplianceStore.PL.Models.ViewModels
{
    public class ProductRangeViewModel
    {
        public RangeBindingModel Range { get; set; }
        public IEnumerable<ProductViewModel> ProductVMs { get; set; }
    }
}

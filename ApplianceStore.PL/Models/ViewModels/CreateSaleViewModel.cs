using ApplianceStore.PL.Models.BindingModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplianceStore.PL.Models
{
    public class CreateSaleViewModel
    {
        public SaleBindingModel Sale { get; set; }
        public SelectList ProductTitles { get; set; }
    }
}

using ApplianceStore.PL.Models.BindingModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplianceStore.PL.Models
{
    public class CreateSupplyViewModel
    { 
        public SupplyBindingModel Supply { get; set; }
        public SelectList ProductTitles { get; set; } 
    }
}

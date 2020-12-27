using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Mvc;

namespace ApplianceStore.PL.Models.BindingModels
{
    public class SupplyBindingModel
    {
        [Display(Name = "Количество")]
        public int Count { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Display(Name = "Поставщик")]
        [Required]
        [Remote(action: "IsSupplierUniq", controller: "Supply", ErrorMessage = "Название уже используется")]
        public string Supplier { get; set; }

        [Display(Name = "Продукт")]
        public int ProductId { get; set; }
    }
}

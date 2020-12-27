using System.ComponentModel.DataAnnotations;
using System;

namespace ApplianceStore.PL.Models.BindingModels
{
    public class SaleBindingModel
    {
        [Range(1, int.MaxValue)]
        [Display(Name = "Количество")]
        public int Count { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Скидка")]
        public int Discount { get; set; }

        [Display(Name = "Продукт")]
        public int ProductId { get; set; }
    }
}

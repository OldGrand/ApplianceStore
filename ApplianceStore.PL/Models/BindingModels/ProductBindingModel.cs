using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApplianceStore.PL.Models.BindingModels
{
    public class ProductBindingModel
    {
        [Display(Name = "Название")]
        [Required]
        [Remote(action: "IsTitleUniq", controller: "Product", ErrorMessage = "Название уже используется")]
        public string Title { get; set; }

        [Display(Name = "Производитель")]
        [Required]
        public string Manufacturer { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Количество на складе")]
        public int CountInStock { get; set; }

        [Display(Name = "Доступность")]
        [Required]
        public bool IsAvailable { get; set; }

        [Display(Name = "Фото")]
        [Required]
        public string Photo { get; set; }
    }
}

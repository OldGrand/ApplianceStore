using ApplianceStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplianceStore.PL.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CountInStock { get; set; }
        public bool IsAvailable { get; set; }
        public string Photo { get; set; }
    }
}


using System;

namespace ApplianceStore.BLL.DTO
{
    public class ProductDTO
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


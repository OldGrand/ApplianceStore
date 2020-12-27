using System;

namespace ApplianceStore.BLL.DTO
{
    public class SupplyDTO
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public string Supplier { get; set; }

        public int ProductId { get; set; } 
        public ProductDTO Product { get; set; }
    }
}


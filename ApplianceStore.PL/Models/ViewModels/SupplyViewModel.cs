using System;

namespace ApplianceStore.PL.Models
{
    public class SupplyViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public string Supplier { get; set; }

        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
    }
}


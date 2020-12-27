using ApplianceStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplianceStore.BLL.DTO
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public int Discount { get; set; }

        public int ProductId { get; set; } 
        public ProductDTO Product { get; set; }
    }
}


namespace ApplianceStore.DAL.Entities
{
    public class Sale : BaseProductInfo
    {
        public int Discount { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}


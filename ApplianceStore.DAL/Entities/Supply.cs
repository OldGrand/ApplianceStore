
namespace ApplianceStore.DAL.Entities
{
    public class Supply : BaseProductInfo
    {
        public string Supplier { get; set; }

        public int ProductId { get; set; } 
        public virtual Product Product { get; set; }
    }
}



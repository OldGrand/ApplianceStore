using ApplianceStore.BLL.DTO;
using System.Collections.Generic;

namespace ApplianceStore.BLL.Interfaces
{
    public interface IProductService
    {
        void Add(ProductDTO supplyDTO);
        IEnumerable<ProductTitleDTO> GetTitles();
        ProductDTO Get(int id);
        void Delete(int id);
        IEnumerable<ProductDTO> GetAll();
        void Dispose();
    }
}

using ApplianceStore.BLL.DTO;
using System.Collections.Generic;

namespace ApplianceStore.BLL.Interfaces
{
    public interface ISaleService
    {
        void Add(SaleDTO supplyDTO);
        SaleDTO Get(int id);
        void Delete(int id);
        IEnumerable<SaleDTO> GetAll();
        void Dispose();
    }
}

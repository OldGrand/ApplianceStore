using ApplianceStore.BLL.DTO;
using System.Collections.Generic;

namespace ApplianceStore.BLL.Interfaces
{
    public interface ISupplyService
    {
        void Add(SupplyDTO supplyDTO);
        SupplyDTO Get(int id); 
        void Delete(int id);
        IEnumerable<SupplyDTO> GetAll(); 
        void Dispose();
    }
}

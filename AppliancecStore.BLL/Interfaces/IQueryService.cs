using ApplianceStore.BLL.DTO;
using ApplianceStore.BLL.DTO.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplianceStore.BLL.Interfaces
{
    public interface IQueryService
    {
        Task<IEnumerable<TitleValueDTO>> GetSalePriceWithDiscount();
        Task<IEnumerable<ProductDTO>> GetProductTitleWithPriceInRange(int start, int end);
        Task<IEnumerable<ProductDTO>> GetProductTitleAndDescrThatWasSuppliedLast();
        Task<IEnumerable<ProductDTO>> GetProductTitleAndPriceThatWasSaledToday(int value);
        Task<IEnumerable<SupplyAvgCountDTO>> GetSupplierWhereAvgCountMoreThanUserVal(int value);
        Task<IEnumerable<TitleValueDTO>> GetTotalSalesSum();
        Task<IEnumerable<TitleValueDTO>> GetAvgProductPriceForSuppliers();
        Task<IEnumerable<DateSumDTO>> GetTotalSupplyCountGroupedByDate(int val);
        Task<IEnumerable<ProductDTO>> GetProductsThoseNeverBeenSupplied();
        Task<IEnumerable<ProductTitleCountInStockDTO>> GetProductsListAndCountInStockForManufacturer(string val);
        void Dispose();
    }
}

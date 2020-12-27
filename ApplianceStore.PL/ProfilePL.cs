using ApplianceStore.BLL.DTO;
using ApplianceStore.BLL.DTO.Queries;
using ApplianceStore.PL.Models;
using ApplianceStore.PL.Models.BindingModels;
using ApplianceStore.PL.Models.ViewModels;
using AutoMapper;

namespace ApplianceStore.PL
{
    public class ProfilePL : Profile
    {
        public ProfilePL()
        {
            CreateMap<SaleDTO, SaleViewModel>().ReverseMap();
            CreateMap<ProductDTO, ProductViewModel>().ReverseMap();
            CreateMap<SupplyDTO, SupplyViewModel>().ReverseMap();

            CreateMap<ProductTitleDTO, ProductTitleViewModel>();
            CreateMap<SaleBindingModel, SaleDTO>();
            CreateMap<ProductBindingModel, ProductDTO>();
            CreateMap<SupplyBindingModel, SupplyDTO>();
            CreateMap<TitleValueDTO, TitleValueViewModel>();
            CreateMap<SupplyAvgCountDTO, SupplyAvgCountViewModel>();
            CreateMap<DateSumDTO, DateSumViewModel>();
            CreateMap<ProductTitleCountInStockDTO, ProductTitleCountInStockViewModel>();
        }
    }
}

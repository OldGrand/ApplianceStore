using ApplianceStore.BLL.DTO;
using ApplianceStore.DAL.Entities;
using AutoMapper;

namespace ApplianceStore.BLL
{
    public class ProfileBLL : Profile
    {
        public ProfileBLL()
        {
            CreateMap<Sale, SaleDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Supply, SupplyDTO>().ReverseMap();
            CreateMap<Product, ProductTitleDTO>();
        }
    }
}
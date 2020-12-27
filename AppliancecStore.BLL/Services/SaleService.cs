    using ApplianceStore.BLL.DTO;
using ApplianceStore.BLL.Interfaces;                                                                                                       
using ApplianceStore.DAL.Entities;
using ApplianceStore.DAL.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApplianceStore.BLL.Services
{
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SaleService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public void Add(SaleDTO saleDto)
        {
            var createdSale = _mapper.Map<SaleDTO, Sale>(saleDto);
            _unitOfWork.SaleRepository.Create(createdSale);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var removedSale = _unitOfWork.SaleRepository.Read(_ => _.Id == id);
            _unitOfWork.SaleRepository.Delete(removedSale);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public SaleDTO Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SaleDTO> GetAll()
        {
            var sales = _unitOfWork.SaleRepository.ReadAll();
            return _mapper.Map<IEnumerable<Sale>, IEnumerable<SaleDTO>>(sales);
        }
    }
}

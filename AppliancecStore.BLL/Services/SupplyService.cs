using ApplianceStore.BLL.Interfaces;
using ApplianceStore.DAL.Interfaces;
using ApplianceStore.DAL.Entities;
using System.Collections.Generic;
using AutoMapper;
using System;
using Microsoft.EntityFrameworkCore;
using ApplianceStore.BLL.DTO;

namespace ApplianceStore.BLL.Services
{
    public class SupplyService : ISupplyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SupplyService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public void Add(SupplyDTO supplyDto)
        {
            var createdSupply = _mapper.Map<SupplyDTO, Supply>(supplyDto);
            _unitOfWork.SupplyRepository.Create(createdSupply);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public IEnumerable<SupplyDTO> GetAll()
        {
            var supplies = _unitOfWork.SupplyRepository.ReadAll();
            return _mapper.Map<IEnumerable<Supply>, IEnumerable<SupplyDTO>>(supplies);
        }

        public SupplyDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var removedSupply = _unitOfWork.SupplyRepository.Read(_ => _.Id == id);
            _unitOfWork.SupplyRepository.Delete(removedSupply);
            _unitOfWork.Save();
        }
    }
}

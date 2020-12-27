using ApplianceStore.BLL.DTO;
using ApplianceStore.BLL.Interfaces;
using ApplianceStore.DAL.Entities;
using ApplianceStore.DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace ApplianceStore.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public void Add(ProductDTO supplyDto)
        {
            var createdProduct = _mapper.Map<ProductDTO, Product>(supplyDto);
            _unitOfWork.ProductRepository.Create(createdProduct);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var removedProduct = _unitOfWork.ProductRepository.Read(_ => _.Id == id);
            _unitOfWork.ProductRepository.Delete(removedProduct);
            _unitOfWork.Save();
        }

        public IEnumerable<ProductTitleDTO> GetTitles()
        {
            var products = _unitOfWork.ProductRepository.ReadAll();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductTitleDTO>>(products);
        }

        public ProductDTO Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var products = _unitOfWork.ProductRepository.ReadAll();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}

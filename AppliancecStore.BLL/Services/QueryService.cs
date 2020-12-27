using ApplianceStore.BLL.DTO;
using ApplianceStore.BLL.DTO.Queries;
using ApplianceStore.BLL.Interfaces;
using ApplianceStore.DAL.Entities;
using ApplianceStore.DAL.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplianceStore.BLL.Services
{
    public class QueryService : IQueryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QueryService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }
        //1
        public async Task<IEnumerable<TitleValueDTO>> GetSalePriceWithDiscount()
        {
            return await (from s in _unitOfWork.SaleRepository.ReadAll()
                          select new TitleValueDTO
                          {
                              Title = s.Product.Title,
                              Value = s.Count * s.Product.Price - (s.Count * s.Product.Price * (s.Discount / 100))
                          }).ToListAsync();
        }
        //2
        public async Task<IEnumerable<ProductDTO>> GetProductTitleWithPriceInRange(int start, int end)
        {
            return await (from p in _unitOfWork.ProductRepository.ReadAll()
                          where p.Price > start && p.Price < end
                          select _mapper.Map<Product, ProductDTO>(p)).ToListAsync();
        }
        //3
        public async Task<IEnumerable<ProductDTO>> GetProductTitleAndDescrThatWasSuppliedLast()
        {
            var lastSupplyDate = await (from s in _unitOfWork.SupplyRepository.ReadAll()
                                        select s.Date).MaxAsync();

            return await (from s in _unitOfWork.SupplyRepository.ReadAll()
                          where s.Date == lastSupplyDate
                          select new ProductDTO
                          {
                              Title = s.Product.Title,
                              Description = s.Product.Description
                          }).ToListAsync();
        }
        //4
        public async Task<IEnumerable<ProductDTO>> GetProductTitleAndPriceThatWasSaledToday(int value)
        {
            return await (from s in _unitOfWork.SaleRepository.ReadAll()
                          where s.Date.Date == DateTime.Now.Date && s.Count > value
                          select new ProductDTO
                          {
                              Title = s.Product.Title,
                              Price = s.Product.Price
                          }).ToListAsync();
        }
        //5
        public async Task<IEnumerable<SupplyAvgCountDTO>> GetSupplierWhereAvgCountMoreThanUserVal(int value)
        {
            return await (from s in _unitOfWork.SupplyRepository.ReadAll()
                          group s by s.Supplier into g
                          where g.Average(_ => _.Count) > value
                          select new SupplyAvgCountDTO
                          {
                              Supplier = g.Key,
                              AvgProductCount = g.Average(_ => _.Count)
                          }).ToListAsync();
        }
        //6
        public async Task<IEnumerable<TitleValueDTO>> GetTotalSalesSum()
        {
            return from s in await _unitOfWork.SaleRepository.ReadAll().ToListAsync()
                   group s by s.Date.Month into g
                   select new TitleValueDTO
                   {
                       Title = g.Key.ToString(),
                       Value = g.Sum(_ => _.Count * _.Product.Price - (_.Count * _.Product.Price * (_.Discount / 100)))
                   };
        }
        //7
        public async Task<IEnumerable<TitleValueDTO>> GetAvgProductPriceForSuppliers()
        {
            return from s in await _unitOfWork.SupplyRepository.ReadAll().ToListAsync()
                   group s by s.Supplier into g
                   select new TitleValueDTO
                   {
                       Title = g.Key,
                       Value = g.Average(_ => _.Product.Price)
                   };
        }
        //8
        public async Task<IEnumerable<DateSumDTO>> GetTotalSupplyCountGroupedByDate(int val)
        {
            return await (from s in _unitOfWork.SupplyRepository.ReadAll()
                          group s by s.Date into g
                          where g.Sum(_ => _.Count) > val
                          select new DateSumDTO
                          {
                              Date = g.Key,
                              Sum = g.Sum(_ => _.Count)
                          }).ToListAsync();
        }
        //9
        public async Task<IEnumerable<ProductDTO>> GetProductsThoseNeverBeenSupplied()
        {
            var productsIds = _unitOfWork.SupplyRepository.ReadAll().Select(_ => _.ProductId);
            return await (from p in _unitOfWork.ProductRepository.ReadAll()
                          where !productsIds.Contains(p.Id)
                          select new ProductDTO
                          {
                              Title = p.Title,
                              Description = p.Description
                          }).ToListAsync();
        }
        //10
        public async Task<IEnumerable<ProductTitleCountInStockDTO>> GetProductsListAndCountInStockForManufacturer(string val)
        {
            return await (from p in _unitOfWork.ProductRepository.ReadAll()
                          where p.Manufacturer == val
                          group p by p.Title into g
                          select new ProductTitleCountInStockDTO
                          {
                              Title = g.Key,
                              CountInStock = g.Sum(_ => _.CountInStock)
                          }).ToListAsync();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}

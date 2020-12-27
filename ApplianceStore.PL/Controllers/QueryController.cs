using ApplianceStore.BLL.DTO;
using ApplianceStore.BLL.DTO.Queries;
using ApplianceStore.BLL.Interfaces;
using ApplianceStore.PL.Models;
using ApplianceStore.PL.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplianceStore.PL.Controllers
{
    public class QueryController : Controller
    {
        private readonly IQueryService _queryService;
        private readonly IMapper _mapper;

        public QueryController(IQueryService queryService, IMapper mapper)
        {
            _queryService = queryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> FirstQuery()
        {
            var titleValueDTOs = await _queryService.GetSalePriceWithDiscount();
            var titleValuesVMs = _mapper.Map<IEnumerable<TitleValueDTO>, IEnumerable<TitleValueViewModel>>(titleValueDTOs);
            return View(titleValuesVMs);
        }

        public IActionResult SecondQuery()
        {
            var productRangeVM = new ProductRangeViewModel();
            return View(productRangeVM);
        }

        [HttpPost]
        public async Task<IActionResult> SecondQuery(ProductRangeViewModel productRangeVM)
        {
            if (ModelState.IsValid)
            {
                var productDTOs = await _queryService.GetProductTitleWithPriceInRange(productRangeVM.Range.Start, 
                                                                                      productRangeVM.Range.End);
                var productVMs = _mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(productDTOs);
                productRangeVM.ProductVMs = productVMs;
            }
            return View(productRangeVM);
        }

        public async Task<IActionResult> ThirdQuery()
        {
            var titleDescrDTOs = await _queryService.GetProductTitleAndDescrThatWasSuppliedLast();
            var titleDescrVMs = _mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(titleDescrDTOs);
            return View(titleDescrVMs);
        }

        public IActionResult FourthQuery()
        {
            var g = new GenericIntViewModel<ProductViewModel>();
            return View(g);
        }

        [HttpPost]
        public async Task<IActionResult> FourthQuery(GenericIntViewModel<ProductViewModel> intTitleValueVM)
        {
            if (ModelState.IsValid)
            {
                var productDTOs = await _queryService.GetProductTitleAndPriceThatWasSaledToday(intTitleValueVM.Integer);
                var productVMs = _mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(productDTOs);
                intTitleValueVM.Source = productVMs;
            }
            return View(intTitleValueVM);
        }

        public IActionResult FifthQuery()
        {
            var g = new GenericIntViewModel<SupplyAvgCountViewModel>();
            return View(g);
        }

        [HttpPost]
        public async Task<IActionResult> FifthQuery(GenericIntViewModel<SupplyAvgCountViewModel> aupplyAvgCountIntVM)
        {
            if (ModelState.IsValid)
            {
                var supplyAvgCountDTOs = await _queryService.GetSupplierWhereAvgCountMoreThanUserVal(aupplyAvgCountIntVM.Integer);
                var supplyAvgCountVMs = _mapper.Map<IEnumerable<SupplyAvgCountDTO>,IEnumerable<SupplyAvgCountViewModel>>(supplyAvgCountDTOs);
                aupplyAvgCountIntVM.Source = supplyAvgCountVMs;
            }
            return View(aupplyAvgCountIntVM);
        }

        public async Task<IActionResult> SixthQuery()
        {
            var titleValueDTOs = await _queryService.GetTotalSalesSum();
            var titleValuesVMs = _mapper.Map<IEnumerable<TitleValueDTO>, IEnumerable<TitleValueViewModel>>(titleValueDTOs);
            return View(titleValuesVMs);
        }

        public async Task<IActionResult> SeventhQuery()
        {
            var titleValueDTOs = await _queryService.GetAvgProductPriceForSuppliers();
            var titleValuesVMs = _mapper.Map<IEnumerable<TitleValueDTO>, IEnumerable<TitleValueViewModel>>(titleValueDTOs);
            return View(titleValuesVMs);
        }

        public IActionResult EighthQuery()
        {
            var g = new GenericIntViewModel<DateSumViewModel>();
            return View(g);
        }

        [HttpPost]
        public async Task<IActionResult> EighthQuery(GenericIntViewModel<DateSumViewModel> supplyDateSumVM)
        {
            if (ModelState.IsValid)
            {
                var supplyAvgCountDTOs = await _queryService.GetTotalSupplyCountGroupedByDate(supplyDateSumVM.Integer);
                var supplyAvgCountVMs = _mapper.Map<IEnumerable<DateSumDTO>, IEnumerable<DateSumViewModel>>(supplyAvgCountDTOs);
                supplyDateSumVM.Source = supplyAvgCountVMs;
            }
            return View(supplyDateSumVM);
        }

        public async Task<IActionResult> NinthQuery()
        {
            var productDTOs = await _queryService.GetProductsThoseNeverBeenSupplied();
            var productVMs = _mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(productDTOs);
            return View(productVMs);
        }

        public IActionResult TenthQuery()
        {
            var g = new GenericStringViewModel<ProductTitleCountInStockViewModel>();
            return View(g);
        }

        [HttpPost]
        public async Task<IActionResult> TenthQuery(GenericStringViewModel<ProductTitleCountInStockViewModel> g)
        {
            if (ModelState.IsValid)
            {
                var supplyAvgCountDTOs = await _queryService.GetProductsListAndCountInStockForManufacturer(g.String);
                var supplyAvgCountVMs = _mapper.Map<IEnumerable<ProductTitleCountInStockDTO>, IEnumerable<ProductTitleCountInStockViewModel>>(supplyAvgCountDTOs);
                g.Source = supplyAvgCountVMs;
            }
            return View(g);
        }
    }
}

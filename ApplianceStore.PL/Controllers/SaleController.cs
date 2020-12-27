using System.Collections.Generic;
using ApplianceStore.BLL.DTO;
using ApplianceStore.BLL.Interfaces;
using ApplianceStore.PL.Models;
using ApplianceStore.PL.Models.BindingModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace ApplianceStore.PL.Controllers
{
    public class SaleController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;

        public SaleController(IProductService productService, ISaleService saleService, IMapper mapper)
        {
            _productService = productService;
            _saleService = saleService;
            _mapper = mapper;
        }

        public IActionResult Items()
        {
            var sales = _mapper.Map<IEnumerable<SaleDTO>, IEnumerable<SaleViewModel>>(_saleService.GetAll());
            return View(sales);
        }

        public IActionResult Delete(int id)
        {
            _saleService.Delete(id);
            return RedirectToAction(nameof(Items));
        }

        public IActionResult Create()
        {
            var createModel = new CreateSaleViewModel
            {
                ProductTitles = new SelectList(_productService.GetTitles(), "Id", "Title")
            };

            return View(createModel);
        }

        [HttpPost]
        public IActionResult Create(CreateSaleViewModel createVM)
        {
            if(ModelState.IsValid)
            {
                var saleDTO = _mapper.Map<SaleBindingModel, SaleDTO>(createVM.Sale);
                _saleService.Add(saleDTO);

                return RedirectToAction(nameof(Items));
            }
            createVM.ProductTitles = new SelectList(_productService.GetTitles(), "Id", "Title");
            return View(createVM);
        }
    }
}

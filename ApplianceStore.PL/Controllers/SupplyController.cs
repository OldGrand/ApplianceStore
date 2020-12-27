using Microsoft.AspNetCore.Mvc;
using ApplianceStore.PL.Models;
using ApplianceStore.BLL.Interfaces;
using ApplianceStore.BLL.DTO;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplianceStore.PL.Models.BindingModels;
using System.Linq;

namespace ApplianceStore.PL.Controllers
{
    public class SupplyController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISupplyService _supplyService;
        private readonly IMapper _mapper;

        public SupplyController(ISupplyService supplyService, IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _supplyService = supplyService;
            _mapper = mapper;
        }

        public IActionResult Items()
        {
            var supplies = _mapper.Map<IEnumerable<SupplyDTO>, IEnumerable<SupplyViewModel>>(_supplyService.GetAll());
            return View(supplies); 
        }

        public IActionResult Delete(int id)
        {
            _supplyService.Delete(id);
            return RedirectToAction(nameof(Items));
        }

        public IActionResult Create()
        {
            var createModel = new CreateSupplyViewModel
            {
                ProductTitles = new SelectList(_productService.GetTitles(), "Id", "Title")
            };

            return View(createModel);
        }

        [HttpPost]
        public IActionResult Create(CreateSupplyViewModel createVM)
        {
            if(ModelState.IsValid)
            {
                var supplyDTO = _mapper.Map<SupplyBindingModel, SupplyDTO>(createVM.Supply);
                _supplyService.Add(supplyDTO);

                return RedirectToAction(nameof(Items));
            }
            createVM.ProductTitles = new SelectList(_productService.GetTitles(), "Id", "Title");
            return View(createVM);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsSupplierUniq(string supplier)
        {
            if (_supplyService.GetAll().Count(_ => _.Supplier == supplier) == 0)
                return Json(true);
            return Json(false);
        }
    }
}

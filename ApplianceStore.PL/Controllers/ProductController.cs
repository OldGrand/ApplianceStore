using ApplianceStore.BLL.DTO;
using ApplianceStore.BLL.Interfaces;
using ApplianceStore.PL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using ApplianceStore.PL.Models.BindingModels;
using System.Linq;

namespace ApplianceStore.PL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public IActionResult Items()
        {
            var products = _mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(_productService.GetAll());
            return View(products);
        }

        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction(nameof(Items));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductBindingModel productVM)
        {
            if(ModelState.IsValid)
            {
                var productDTO = _mapper.Map<ProductBindingModel, ProductDTO>(productVM);
                _productService.Add(productDTO);

                return RedirectToAction(nameof(Items));
            }

            return View(productVM);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsTitleUniq(string title)
        {
            if (_productService.GetAll().Count(_ => _.Title == title) == 0)
                return Json(true);
            return Json(false);
        }
    }
}

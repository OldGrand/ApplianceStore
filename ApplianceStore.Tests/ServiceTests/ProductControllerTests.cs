using System;
using System.Collections.Generic;
using System.Linq;
using ApplianceStore.BLL.DTO;
using ApplianceStore.BLL.Interfaces;
using ApplianceStore.PL;
using ApplianceStore.PL.Controllers;
using ApplianceStore.PL.Models;
using ApplianceStore.PL.Models.BindingModels;
using ApplianceStore.Tests.Comparers;
using AutoFixture.Xunit2;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ApplianceStore.Tests
{
    public class ProductControllerTests
    {
        private readonly IMapper _mapper;

        public ProductControllerTests()
        {
            var profile = new ProfilePL();
            _mapper = new MapperConfiguration(_ => _.AddProfile(profile)).CreateMapper();
        }

        [Theory]
        [AutoData]
        public void ProductItemsTest(List<ProductDTO> productDTOs, [Frozen] Mock<IProductService> productService) 
        {
            //Arrange
            productService.Setup(_ => _.GetAll()).Returns(productDTOs);
            var controller = new ProductController(productService.Object, _mapper);

            //Act
            var result = controller.Items();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var modelResult = Assert.IsAssignableFrom<IEnumerable<ProductViewModel>>(viewResult.Model);

            var productDTOsFromView = _mapper.Map<IEnumerable<ProductViewModel>, IEnumerable<ProductDTO>>(modelResult);
            Assert.True(productDTOs.SequenceEqual(productDTOsFromView, new ProductDTOComparer()));
        }

        [Theory]
        [AutoData]
        public void ProductAddValidItemTest(ProductBindingModel productBM, [Frozen] Mock<IProductService> productService)
        {
            //Arrange
            var controller = new ProductController(productService.Object, _mapper);

            //Act
            var result = controller.Create(productBM);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Items", redirectToActionResult.ActionName);

            productService.Verify(_ => _.Add(It.IsAny<ProductDTO>()));
        }

        [Theory]
        [AutoData]
        public void ProductAddInvalidItemTest(ProductBindingModel productBM, [Frozen] Mock<IProductService> productService)
        {
            //Arrange
            var controller = new ProductController(productService.Object, _mapper);
            controller.ModelState.AddModelError("Title", "Required");

            //Act
            var result = controller.Create(productBM);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var modelResult = Assert.IsAssignableFrom<ProductBindingModel>(viewResult.Model);
            Assert.Equal(productBM, modelResult, new ProductBindingModelComparer());
        }

        [Theory]
        [AutoData]
        public void DeleteProductTest(ProductBindingModel productBM, [Frozen] Mock<IProductService> productService)
        {
            ////Arrange
            //var controller = new ProductController(productService.Object, _mapper);
            

            ////Act
            //var result = controller.Delete();

            ////Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var modelResult = Assert.IsAssignableFrom<ProductBindingModel>(viewResult.Model);
            //Assert.Equal(productBM, modelResult, new ProductBindingModelComparer());
        }
    }
}


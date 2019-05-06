using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TestApi.Controllers;
using TestApi.Dto;
using TestApi.Helper;

namespace TestApi.Tests
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void ShouldReturnProducts()
        {
            //Arrange

            //Act
            var productController = new ProductController();
            var actionResult = productController.GetProducts();
            var actualProducts = actionResult.Value.ToList();

            //Assert
            var expectedProducts = DataStore.GetProducts();
            AssertProducts(expectedProducts, actualProducts);           
        }

        private void AssertProducts(List<Product> expectedProducts, List<Product> actualProducts)
        {
            Assert.AreEqual(expectedProducts.Count, actualProducts.Count);
            foreach (var expectedProduct in expectedProducts)
            {
                var index = expectedProducts.IndexOf(expectedProduct);
                Assert.AreEqual(expectedProduct.Id, actualProducts[index].Id);
                Assert.AreEqual(expectedProduct.ModelCode, actualProducts[index].ModelCode);
                Assert.AreEqual(expectedProduct.ProductName, actualProducts[index].ProductName);
                Assert.AreEqual(expectedProduct.SerialNumber, actualProducts[index].SerialNumber);
            }
        }
    }
}

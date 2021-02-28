using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Business.Concrete.Managers;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using Moq;

namespace Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);
            productManager.Add(new Product());
        }
    }
}

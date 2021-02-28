using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Abstract;
using Entities.Concrete;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetList().Data
            };
            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "Gsm",
                QuantityPerUnit = "1",
                UnitPrice = 3000
            });
            return "Added";
        }
        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {
                CategoryId = 1,
                ProductName = "Gsm",
                QuantityPerUnit = "1",
                UnitPrice = 3000
            }, new Product
            {
                CategoryId = 1,
                ProductName = "Gsm",
                QuantityPerUnit = "1",
                UnitPrice = -5
            });
            return "Done";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Concrete;

namespace MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
    }
}
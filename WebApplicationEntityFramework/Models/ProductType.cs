using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationEntityFramework.Models
{
    public class ProductType
    {
        public ProductType()
        {
        }
        public int ProductTypeID { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
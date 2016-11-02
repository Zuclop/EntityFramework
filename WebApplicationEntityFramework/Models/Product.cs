using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationEntityFramework.Models
{
    public class Product
    {
        public Product()
        {
        }
        public int ProductID { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }
    }
}
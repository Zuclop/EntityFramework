using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplicationEntityFramework.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        : base()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

    }
}
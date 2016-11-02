﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationEntityFramework.Models;

namespace WebApplicationEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*using(var ctx = new ApplicationContext())
            {
                ProductType s = new ProductType() { Name = "Arahis" };
                Product stud = new Product() { Name = "Kozacka slava", ProductType = s };
                ctx.ProductTypes.Add(s);
                ctx.Products.Add(stud);
                ctx.SaveChanges();
            }*/
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
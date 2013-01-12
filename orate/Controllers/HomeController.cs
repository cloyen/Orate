using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using orate.Dao;
using orate.Models;

namespace orate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = " Começando o programa!";

            return View();
        }

        public ActionResult About()
        {
            Category category = new Category { Id = 23, Name = "TabletPc" };            
            Product product = new Product { Name = "Apple", Discontinued = "true", Category = category};
            ProductDao productDao = ProductDao.GetInstance();
            productDao.Add(product);
            
            
        
            return View();
        }
    }
}

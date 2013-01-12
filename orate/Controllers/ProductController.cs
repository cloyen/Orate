using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using orate.Models;
using orate.Dao;
using orate.Filters;
namespace orate.Controllers
{
    /*[author] mnascimento
     * [date] january 23th of 2013
     * Control of products list
     */
    public class ProductController : Controller
    {       
        /* Method Index (Managers -> Products)
         * This method show be as list of all products view, but may be delete or edit 
         * options for this 
         * but must be the privileges of admin for execute this action
         */        
        [AuthenticationFilter]
        public ActionResult Index()
        {
            ProductDao dao = ProductDao.GetInstance();
            IList<Product> products = dao.ListAll();
            return View(products);
        }

        /* Method Controlar (Control Menu)
        * This method show be as list of all products view, but doesn't have to permitions to
        * delete or edit options for this 
        * but must be the privileges of operator for execute this action
        */
        public ActionResult Controlar()
        {
            ProductDao dao = ProductDao.GetInstance();
            IList<Product> products = dao.ListAll();
            return View(products);
        }


        /*
         * This method make a form for 
         *  input new dates of product in  Salvar method
         */
        public ActionResult Cadastrar()
        {
            CategoryDao dao = CategoryDao.GetInstance();
            IList<Category> categories = dao.ListAll();

            return View(categories);
        }

        /*
         * This method receives dates of method index 
         * and input Update product on database
         * */
        [HttpGet]
        public ActionResult Editar(Double Id)
        {
            ProductDao dao = ProductDao.GetInstance();
            Product product = dao.GetById(Id);
            return View(product);

        }

        /*
         * This method receives dates of method index 
         * and input new product on database
         * */
        [HttpPost]
        public ActionResult Salvar(Product product)
        {
            ProductDao productDao = ProductDao.GetInstance();
            product.Category = CategoryDao.GetInstance().GetById(product.Category.Id);
            /* cadastrar */
            if (product.Id == 0)
            {
                productDao.Add(product);
               return RedirectToAction("Index", "Product");
            }
            /* Editar */
            else
            {
                productDao.Update(product);
              return  RedirectToAction("Index", "Product");

            }
            
        }

        /*
         * This method receives Id of product  
         * and make a delete of this from database
         */
        [HttpGet]
        public ActionResult Delete(Double Id)
        {
            Product product = ProductDao.GetInstance().GetById(Id);
            ProductDao dao = ProductDao.GetInstance();
            dao.Remove(product);

           return RedirectToAction("Index", "Product");
            
        }

        


    }
}

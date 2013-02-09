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
                return RedirectToAction("Index", "Product");

            }

        }

        /*
         * This method receives id of product  
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

        /*This method would have to make ajax on this view, but still doesn't arrived 
      * in the end.
      */
        public ActionResult IniciarSaida()
        {
            CompanyDao dao = CompanyDao.getInstance();
            List<Company> companies = dao.getAll();
            return View(companies);
        }


        /* This method will do a Give out of products
         * this method contain the client business and 
         */

        public ActionResult ProcessAddOutPut(int companyId, DateTime date)
        {
            OutPutDao dao = OutPutDao.getInstance();
            Company company = CompanyDao.getInstance().getById(companyId);
            OutPut outPut = new OutPut();

            outPut.Company = company;
            outPut.Date = date;

            //  if ((outPut != null) && (dao.getOutPutByDate(date) == null))
            if ((Session["outPut"] == null) && (outPut != null))
            {
                dao.add(outPut);
                Session["outPut"] = dao.getOutPutByDate(date);

            }
            outPut = (OutPut)Session["outPut"];
            List<Product> products = ProductDao.GetInstance().ListAll();
            Object[] obj = new Object[2] { outPut, products };

            return View(obj);
        }


        /* This method will do a Give out of products
        * this method contain the client business and 
        */

        public ActionResult DarSaida(OutPut outPut)
        {
            OutPutDao dao = OutPutDao.getInstance();
            bool able = false;
            if (outPut != null)
            {
                dao.add(outPut);
                able = true;
            }
            return Json(able);
        }


        
        public JsonResult ProcessItensOut(double productId, double quantity)
        {
            // treatment about update quantity of stock products
            ProductDao dao = ProductDao.GetInstance();
            Product product = dao.GetById(productId);
            //treatment about of save outPut 
            double qnt = product.Quantity;
                    product.Quantity = qnt - quantity;
                  

            var p = (new { id = product.Id, name = product.Name, quantity = product.Quantity });

            return Json(p,JsonRequestBehavior.AllowGet);

        }
    }
}

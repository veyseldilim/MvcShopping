using MvcShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShopping.Controllers
{
    public class ProductController : BaseController
    {

        public Context db = new Context();


        // GET: Product
        public ActionResult Index()
        {
            var products = from e in db.products
                           orderby e.CategoryName.CategoryId
                           select e;
            return View(products);


        }

        public ActionResult Details(int id)
        {
           
            return View(db.products.Where(p => p.CategoryName.CategoryId == id).ToList());
   
        }

        public ActionResult Search(string searchString)
        {
            var products = from m in db.products
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.Contains(searchString));
            }

            return View(products);
        }

       public ActionResult ListbyCategory(String categoryName)
       {


            return View(db.products.Where(p => p.CategoryName.CategoryName.ToUpper() .Equals(categoryName.ToUpper()) ).ToList());
       }


    }
}
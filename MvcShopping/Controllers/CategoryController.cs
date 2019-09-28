using MvcShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcShopping.Controllers
{

    public class CategoryController : BaseController
    {

        public Context db = new Context();

        
        public ActionResult Index()
        {
            var products = from e in db.products
                           orderby e.CategoryName.CategoryId
                           select e;
            return View(products);

        }

        public ActionResult ListbyCategory(String categoryName)
        {
            ViewBag.vari = categoryName;

            return View(db.products.Where(p => p.CategoryName.CategoryName.ToUpper().Equals(categoryName.ToUpper())).ToList());
        }

        public ActionResult ListbyPrice(string min , string max)
        {
            int minn = Convert.ToInt32(min.Substring(1));
            int maxx = Convert.ToInt32(max.Substring(1));


            return View(db.products.Where(p => p.ProductPrice > minn &&  p.ProductPrice < maxx).ToList());

        }


        /*
        public ActionResult ListbyPriceC(string categoryName, string min, string max)
        {
            int minn = Convert.ToInt32(min.Substring(1));
            int maxx = Convert.ToInt32(max.Substring(1));
            return View(db.products.Where(p => p.CategoryName.CategoryName.Equals(categoryName) && p.ProductPrice > minn && p.ProductPrice < maxx).ToList());

        }

        */

    }

}
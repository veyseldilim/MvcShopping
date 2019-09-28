using MvcShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShopping.Controllers
{
    public class HomeController : BaseController
    {

        public Context db = new Context();

        public ActionResult Index()
        {
            var categories = from e in db.categories
                             orderby e.CategoryId
                             select e;
            return View(categories);

        }
            

        [ChildActionOnly]
        public PartialViewResult NavBar()
        {
            var currentBasket = db.basket.Where(xXx => xXx.CustomerId == 1).Count();

            return PartialView("Views/Shared/_Layout.cshtml", currentBasket);
        }




    }
}


using MvcShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShopping.Controllers
{
    public class SharedController : BaseController
    {
        // GET: Shared

        public Context db = new Context();

        public IEnumerable<Cart> MainLayoutViewModel { get; set; }
        // [ChildActionOnly]

        /*
    public SharedController()
    {

       // this.MainLayoutViewModel= db.basket.Where(xXx => xXx.CustomerId == 1).ToList();

       // this.ViewData["MainLayoutViewModel"] = this.MainLayoutViewModel;

        // ViewBag["baskets"] = MainLayoutViewModel;
        //  return PartialView("~/Views/Shared/_Layout.cshtml", baskets);
    }

    */

        public ActionResult Index()
        {
            ViewBag.basketss = db.basket.Where(xXx => xXx.CustomerId == 1).ToList();
            // var currentBasket = db.basket.Where(xXx => xXx.CustomerId == 1).ToList();
            //  return View("~/Views/Shared/_maPartialView.cshtml", currentBasket);
            return View("~/Views/Shared/_Layout.cshtml");
        }
    }
}
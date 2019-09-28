using MvcShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShopping.Controllers
{
    public abstract class BaseController : Controller
    {
        // GET: Base
        public Context db = new Context();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            ViewBag.basketsize = db.basket.Count(); //Add whatever


            base.OnActionExecuting(filterContext);
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
                base.Initialize(requestContext);
              

        }

       

       

    }
}
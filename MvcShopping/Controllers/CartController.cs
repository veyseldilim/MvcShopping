using MvcShopping.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcShopping.Controllers
{
    public class CartController : BaseController
    {
        // GET: Cart

        public  Context db = new Context();

        public ActionResult Index()
        {
            var baskets = from e in db.basket.Include("Product")
                          orderby e.BasketID
                          select e;

            ViewBag.products = db.products.ToList();

            var bb = from e in db.basket
                     select e.Product;
            ViewBag.s = bb.ToList();


            return View(baskets);

        }
        public ActionResult AddCart(int ID)
        {
            var product = db.products.Where(p => p.ProductId == ID).FirstOrDefault();
           
            if (product.ProductStock > 0)
            {
                if (!db.Reserves.Any(k => k.ProductId == ID))
                {
                    Reserve reserve = new Reserve
                    {
                        Product = db.products.Where(p => p.ProductId == ID).FirstOrDefault(),
                        Reserved_Number = 1,
                        CustomerId = 1
                    };

                    db.Reserves.Add(reserve);

                    Cart cd = new Cart
                    {
                        Product = db.products.Where(p => p.ProductId == ID).FirstOrDefault(),
                        Quantity = 1,
                        CustomerId = 1


                    };
                    db.basket.Add(cd);

                }
                else if (product.ProductStock - db.Reserves.Where(k => k.ProductId == ID).FirstOrDefault().Reserved_Number > 0)
                {
                    var currentBasket = db.basket.Where(xXx => xXx.ProductId == ID).FirstOrDefault();
                    currentBasket.Quantity += 1;

                    var currentReserve = db.Reserves.Where(xXx => xXx.ProductId == ID).FirstOrDefault();

                    currentReserve.Reserved_Number += 1;


                }
                else
                {
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }  
            else
            {
                // return View("~/Views/Home/Index.cshtml");
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            db.SaveChanges();

            return RedirectToAction(nameof(Index));
          
        }

        public ActionResult ChangeCard(int id , int quanti)
        {
            var currentquanti = db.basket.Where(xXx => xXx.ProductId == id).FirstOrDefault();
            var currentreservequanti = db.Reserves.Where(xXx => xXx.ProductId == id).FirstOrDefault();
            var currentProductStock = db.products.Where(xXx => xXx.ProductId == id).FirstOrDefault();
            if (quanti == 0)
            {
                db.basket.Remove(currentquanti);
                db.Reserves.Remove(currentreservequanti);
            }
            else if (quanti > 0 && quanti <= currentProductStock.ProductStock && currentProductStock.ProductStock > 0)
            {
                currentquanti.Quantity = quanti;
                currentreservequanti.Reserved_Number = quanti;
            }
            else
            {
                // return View("~/Views/Home/Index.cshtml");
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
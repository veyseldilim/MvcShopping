using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcShopping.Models;


namespace MvcShopping.Models
{
    public class Order
    {
        [Key]

        public int OrderID { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public IEnumerable<Cart> Carts { get; set; }
        
        
        public DateTime OrderDate { get; set; }


    }
}
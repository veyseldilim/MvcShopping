
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcShopping.Models;


namespace MvcShopping.Models
{
    public class Product
    {

        [Key]

        public int ProductId { get; set; }
        public virtual Category CategoryName { get; set; }

        public String ProductName { get; set; }

        public String ImagePath { get; set; }

        public double ProductPrice { get; set; }

        public int ProductStock { get; set; }

        public Product()
        {

        }
    }
}
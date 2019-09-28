using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcShopping.Models;


namespace MvcShopping.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }
        public String CategoryName { get; set; }

    }
}
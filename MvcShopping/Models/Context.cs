using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcShopping.Models;

namespace MvcShopping.Models
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {

        }

        public  DbSet<Product> products { get; set; }
        public  DbSet<Category> categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }


        public DbSet<Cart> basket { get; set; }

        public DbSet<Reserve> Reserves { get; set; }
    }
}
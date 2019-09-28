﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcShopping.Models;


namespace MvcShopping.Models
{
    public class Customer
    {

        [Key]
        public int CustomerId { get; set; }
       
        public String Email { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Password { get; set; }


        public Customer()
        {

        }

    }
}
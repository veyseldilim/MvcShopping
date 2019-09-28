using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MvcShopping.Models;

namespace MvcShopping.Models
{
    public class Reserve
    {
        [Key]
        public int ReserveId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Reserved_Number { get; set; }

    }
}
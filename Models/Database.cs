using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product.Models
{
    public class Database
    {
        public product Products { get; set; }
        public Order Orders { get; set; }
        public Database()
        {
            ProductEntities dbObj = new ProductEntities();
             Products = new product();

        }
       

       
    }
}
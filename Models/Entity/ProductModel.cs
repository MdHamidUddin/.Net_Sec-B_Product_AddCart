using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product.Models.Entity
{
    public class ProductModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<double> Price { get; set; }
        public string Description { get; set; }
        public Nullable<int> Quantity { get; set; }



    }
}
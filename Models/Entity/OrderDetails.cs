using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product.Models.Entity
{
    public class OrderDetails
    {
        public string Name { get; set; }
        public Nullable<double> Price { get; set; }
        public string Description { get; set; }
        public Nullable<int> Quantity { get; set; }

        public Nullable<System.DateTime> Date { get; set; }
    }
}
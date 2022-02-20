using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product.Models.Entity
{
    public class OrderModel
    {
        public int O_ID { get; set; }
        public Nullable<int> P_ID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }

        
    }
}
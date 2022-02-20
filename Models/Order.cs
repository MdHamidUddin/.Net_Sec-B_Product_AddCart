
namespace Product.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int O_ID { get; set; }
        public Nullable<int> P_ID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual product product { get; set; }
    }
}

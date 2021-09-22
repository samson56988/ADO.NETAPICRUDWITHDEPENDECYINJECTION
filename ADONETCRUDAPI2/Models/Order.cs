using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADONETCRUDAPI2.Models
{
    public class Order
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public string Description { get; set; }

        public decimal Ordercost { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADONETCRUDAPI2.Models
{
    public class Customer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }
    }
}
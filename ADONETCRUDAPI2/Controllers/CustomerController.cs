using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ADONETCRUDAPI2.BuisnessLogic;
using ADONETCRUDAPI2.Models;

namespace ADONETCRUDAPI2.Controllers
{
    
    public class CustomerController : ApiController
    {
        private readonly CustomerRepository customer = new CustomerRepository();

        [HttpGet]
        public IEnumerable<Customer> GetCustomer()
        {
            return customer.GetAllCustomer().ToList();
        }  

        [HttpGet]     
        public Customer GetCustomerByID(int id)
        {
            return customer.GetCustomerByID(id);
        }

        [HttpPost]
        public Customer Create([FromBody] Customer customers)
        {
            return customer.AddCustomer(customers);
        }

        [HttpPut]
       public Customer Update([FromBody] Customer customers)
        {
            return customer.UpdateCustomer(customers);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            customer.DeleteCustomer(id);
        } 

        
    }
}

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
    public class OrderController : ApiController
    {
        private readonly OrderRepository order = new OrderRepository();

        [HttpGet]
        public IEnumerable<Order> GetOrder()
        {
            return order.GetAllOrder().ToList();
        }
        [HttpGet]
        public Order GetCustomerByID(int id)
        {
            return order.GetOrderByID(id);
        }
        [HttpPost]
        public Order Create([FromBody] Order orders)
        {
            return order.AddOrder(orders);
        }
        [HttpPut]
        public Order Update([FromBody] Order orders)
        {
            return order.UodateOrder(orders);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            order.DeleteOrder(id);
        }
    }
}

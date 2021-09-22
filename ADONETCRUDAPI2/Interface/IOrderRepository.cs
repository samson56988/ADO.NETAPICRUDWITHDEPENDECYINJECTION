using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADONETCRUDAPI2.Models;

namespace ADONETCRUDAPI2.Interface
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrder();

        Order GetOrderByID(int ID);

        Order AddOrder(Order order);

        Order UodateOrder(Order order);

        void DeleteOrder(int id);
    }
}

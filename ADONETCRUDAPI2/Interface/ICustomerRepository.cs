using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADONETCRUDAPI2.Models;

namespace ADONETCRUDAPI2.Interface
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomer();
        Customer GetCustomerByID(int ID);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}

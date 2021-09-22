using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADONETCRUDAPI2.Interface;
using ADONETCRUDAPI2.Models;
using ADONETCRUDAPI2.ConnectionString;
using System.Data.SqlClient;

namespace ADONETCRUDAPI2.BuisnessLogic
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer AddCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("InsertCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@Telephone", customer.Telephone);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return customer;
        }

        public void DeleteCustomer(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("DeleteCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            List<Customer> customers = new List<Customer>();
            using (SqlConnection con = new SqlConnection(ConnectionString.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    Customer customer = new Customer();
                    customer.ID = Convert.ToInt32(rdr["ID"].ToString());
                    customer.Name = rdr["Name"].ToString();
                    customer.Address = rdr["Address"].ToString();
                    customer.Email = rdr["Email"].ToString();
                    customer.Telephone = rdr["Telephone"].ToString();
                    customers.Add(customer);
                }
                rdr.Close();
            }

            return customers;
        }

        public Customer GetCustomerByID(int ID)
        {
            Customer customer = new Customer();
            using (SqlConnection con = new SqlConnection(ConnectionString.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetCustomerID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    customer.ID = ID;
                    customer.Name = rdr["Name"].ToString();
                    customer.Address = rdr["Address"].ToString();
                    customer.Email = rdr["Email"].ToString();
                    customer.Telephone = rdr["Telephone"].ToString();
                    
                }
                rdr.Close();
            }

            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("UpdateCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", customer.ID);
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@Telephone", customer.Telephone);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return customer;
        }
    }
}
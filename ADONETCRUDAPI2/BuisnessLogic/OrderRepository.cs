using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADONETCRUDAPI2.Interface;
using ADONETCRUDAPI2.Models;
using System.Data.SqlClient;
using ADONETCRUDAPI2.ConnectionString;

namespace ADONETCRUDAPI2.BuisnessLogic
{
    public class OrderRepository : IOrderRepository
    {
        public Order AddOrder(Order order)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("InsertOrders", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                cmd.Parameters.AddWithValue("@Description", order.CustomerID);
                cmd.Parameters.AddWithValue("@OrderCost", order.Ordercost);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return order;
        }

        public void DeleteOrder(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("DeleteOrder", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public IEnumerable<Order> GetAllOrder()
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection con = new SqlConnection(ConnectionString.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Order order = new Order();
                    order.ID = Convert.ToInt32(rdr["ID"].ToString());
                    order.CustomerID = Convert.ToInt32(rdr["CustomerID"].ToString());
                    order.Description = rdr["Description"].ToString();
                    order.Ordercost = Convert.ToDecimal(rdr[""].ToString());
                    orders.Add(order);
                }
                rdr.Close();
            }

            return orders;
        }

        public Order GetOrderByID(int ID)
        {
            Order order = new Order();
            using (SqlConnection con = new SqlConnection(ConnectionString.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetOrderID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    order.ID = ID;
                    order.CustomerID = Convert.ToInt32(rdr["Name"].ToString());
                    order.Description = rdr["Description"].ToString();
                    order.Ordercost = Convert.ToDecimal(rdr["OrderCost"].ToString());


                }
                rdr.Close();
            }

            return order;
        }

        public Order UodateOrder(Order order)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.ConnectionString.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("UpdateOrder", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", order.ID);
                cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                cmd.Parameters.AddWithValue("@Description", order.CustomerID);
                cmd.Parameters.AddWithValue("@OrderCost", order.Ordercost);
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return order;
        }
    
    }
}
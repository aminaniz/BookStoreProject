using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class OrderSQLImp : IOrderRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public OrderSQLImp()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["sudDB"].ConnectionString;
            conn = new SqlConnection(connectionstring);
            comm = new SqlCommand();
        }
        public int AddOrder(int userId)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "INSERT INTO Orders (UserId, BookId, Price, Quantity, TotalPrice) SELECT UserId, BookId, Price, Quantity, TotalAmount FROM CartItem where UserId = " + userId + "";
                conn.Open();
                rows = comm.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                comm.CommandText = "delete from CartItem where UserId = " + userId + "";
                rows = comm.ExecuteNonQuery();
                conn.Close();
            }
            return rows;
        }

        public int DeleteOrder(int OrderId)
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetOrders(int UserId)
        {

            using (conn)
            {
                List<Orders> orders = new List<Orders>();
                comm.CommandText = "select * from Orders inner join Book on Orders.BookId = Book.BookId where UserId = "+UserId+"";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    int user_Id = Convert.ToInt32(dr["UserId"]);
                    int bookId = Convert.ToInt32(dr["BookId"]);
                    int status = Convert.ToInt32(dr["Status"]);
                    decimal price = Convert.ToDecimal(dr["Price"]);
                    int quantity = Convert.ToInt32(dr["Quantity"]);
                    decimal totalPrice = Convert.ToDecimal(dr["TotalPrice"]);
                    decimal discount = Convert.ToDecimal(dr["Discount"]);
                    //decimal grandTotal = Convert.ToDecimal(dr["GrandTotal"]);
                    string couponCode = dr["CouponCode"].ToString();
                    string title = dr["Title"].ToString();
                    string author = dr["AuthorName"].ToString();
                    string image = dr["Image"].ToString();
                    orders.Add(new Orders(user_Id, bookId, status, price, quantity, totalPrice, discount,  couponCode, title, author, image));
                }

                conn.Close();
                return orders;
            }
        }

        public int UpdateOrder(int OrderId, Orders orders)
        {
            throw new NotImplementedException();
        }
    }
}
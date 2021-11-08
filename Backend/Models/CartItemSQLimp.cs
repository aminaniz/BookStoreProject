using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class CartItemSQLimp : CartItemInterface
    {
        SqlConnection conn;
        SqlCommand comm;

        public CartItemSQLimp()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["sudDB"].ConnectionString;
            conn = new SqlConnection(connectionstring);
            comm = new SqlCommand();
        }

        public int AddCartItem(CartItem cartItem)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "select * from CartItem where UserId="+ cartItem.UserId + " and BookId="+cartItem.BookId+"";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cartItem.Quantity = (Convert.ToInt32(dr["Quantity"])) + 1;
                        cartItem.Total = (Convert.ToInt32(dr["Quantity"]) + 1) * cartItem.Price;
                        comm.CommandText = "update CartItem set Quantity=" + cartItem.Quantity + ",TotalAmount="+cartItem.Total+" where  UserId=" + cartItem.UserId + " and BookId=" + cartItem.BookId + "";
                    }
                        
                }
                else
                {
                    comm.CommandText = "insert into CartItem (BookId, UserId, Active, Price, Quantity, TotalAmount) values(" + cartItem.BookId + "," + cartItem.UserId + "," + cartItem.Active + "," + cartItem.Price + "," + cartItem.Quantity + ", " + cartItem.Total + ")";
                }
                conn.Close();
                comm.Connection = conn;
                //comm.CommandText = "insert into CartItem (BookId, UserId, Active, Price, Quantity, TotalAmount) values(" + cartItem.BookId + "," + cartItem.UserId + "," + cartItem.Active + "," + cartItem.Price + "," + cartItem.Quantity + ", "+cartItem.Total+")";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }

        public int DeleteCart(int userId)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "delete from CartItem where UserId=" + userId + " ";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }

        public int DeleteCartItem(int cartItemId)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "delete from CartItem where CartItem_ID="+cartItemId+" ";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }

        public List<CartItem> GetCartItems(int UserId)
        {
            List<CartItem> cartItems = new List<CartItem>();
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "select * from CartItem join Book on CartItem.BookId = Book.BookId where UserId = "+UserId+"";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        
                        int CartItem_Id = Convert.ToInt32(dr["CartItem_Id"]);
                        int BookId = Convert.ToInt32(dr["BookId"]);
                        int User_Id = Convert.ToInt32(dr["UserId"]);
                        int Active = Convert.ToInt32(dr["Active"]);
                        Decimal Price = Convert.ToDecimal(dr["Price"]);
                        int Quantity = Convert.ToInt32(dr["Quantity"]);
                        string image = dr["Image"].ToString();
                        string Title = dr["Title"].ToString();
                        string Author = dr["AuthorName"].ToString();
                        Decimal Total = Convert.ToDecimal(dr["TotalAmount"]);


                        CartItem cartItem = new CartItem(CartItem_Id, BookId, User_Id, Active, Price, Quantity, image, Title, Author, Total);
                        Console.WriteLine(cartItem);
                        cartItems.Add(cartItem);
                    }
                }
            }
            return cartItems;
        }

        public int UpdateCartItem(int cartItemId, CartItem cartItem)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "update CartItem set  Price = " + cartItem.Price + ", Quantity = " + cartItem.Quantity + ", TotalAmount = "+cartItem.Total+" where cartItem_ID = "+ cartItemId + "; ";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }
    }
}
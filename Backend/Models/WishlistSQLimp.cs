using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class WishlistSQLimp : IWishRepositry
    {
        SqlConnection conn;
        SqlCommand comm;

        public WishlistSQLimp()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["sudDB"].ConnectionString;
            conn = new SqlConnection(connectionstring);
            comm = new SqlCommand();
        }
        public int AddWishlist(Wishlist wishlist)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "select * from Wishlist where BookID=" + wishlist.BookId + " and UserId=" + wishlist.UserId + "";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        return 0;
                    }
                }
                else
                {
                    conn.Close();
                    comm.CommandText = "insert into Wishlist (BookId, UserId) values(" + wishlist.BookId + "," + wishlist.UserId + ")";
                    conn.Open();
                    
                }
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }

        public int DeleteWishlist(int WishId)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "delete from Wishlist where WishId=" + WishId + " ";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }

        public List<Wishlist> GetWishlist(int UserId)
        {
            List<Wishlist> wishlistItems = new List<Wishlist>();
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "select * from Wishlist join Book on Wishlist.BookId = Book.BookId where UserId = " + UserId + "";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        int WishId = Convert.ToInt32(dr["WishId"]);
                        int BookId = Convert.ToInt32(dr["BookId"]);
                        int User_Id = Convert.ToInt32(dr["UserId"]);
                        Decimal Price = Convert.ToDecimal(dr["Price"]);
                        string image = dr["Image"].ToString();
                        string Title = dr["Title"].ToString();
                        string Author = dr["AuthorName"].ToString();

                        Wishlist wishlist = new Wishlist(WishId, BookId, User_Id,Price,image, Title, Author);
                        Console.WriteLine(wishlist);
                        wishlistItems.Add(wishlist);
                    }
                }
            }
            return wishlistItems;
        }
    }
}
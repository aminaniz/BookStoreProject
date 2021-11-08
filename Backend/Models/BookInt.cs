using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace BookStore.Models
{
    public class BookInt : InterfaceBook
    {
        SqlConnection conn;
        SqlCommand comm;
        public BookInt()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["sudDB"].ConnectionString;
            conn = new SqlConnection(connectionstring);
            comm = new SqlCommand();
        }
        public int AddBook(Book book)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "insert into Book (CatId,Title, AuthorName, ISBN,Year,Price,Description,Position,Status,Image,Format,Rating) values(" + book.CatId + ",'" + book.Title + "','" + book.AuthorName + "'," + book.ISBN + ",'" + book.Year + "'," + book.Price + ",'" + book.Description + "'," + book.Position + ",'" + book.Status + "','" + book.Image + "','" + book.Format + "'," + book.Rating + ")";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }

        public int DeleteBook(int id)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "delete from Book where BookId=" + id + " ";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }

        public Book GetBookId(int id)
        {
            throw new NotImplementedException();
        }
        public List<Book> Search(string searchword ,string search)
        {
            List<Book> books = new List<Book>();
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "select * from Book where "+ search +" like '%" + searchword + "%'";
                Console.WriteLine(comm.CommandText);
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int BookId = Convert.ToInt32(dr["BookId"]);
                        int CategoryId = Convert.ToInt32(dr["CatId"]);
                        string Title = dr["Title"].ToString();
                        string AuthorName = dr["AuthorName"].ToString();
                        int ISBN = (int)Convert.ToInt64(dr["ISBN"]);
                        DateTime Year = Convert.ToDateTime(dr["Year"]);
                        float Price = (float)Convert.ToDecimal(dr["Price"]);
                        string Image = dr["Image"].ToString();
                        string Description = dr["Description"].ToString();
                        int Position = Convert.ToInt32(dr["Position"]);
                        string Status = dr["Status"].ToString();
                        string Format = dr["Format"].ToString();
                        float Rating = (float)Convert.ToDecimal(dr["Rating"]);
                        Book book = new Book(BookId, CategoryId, Title, AuthorName, ISBN,Price, Year, Image, Description, Position, Status,Rating,Format);

                        Console.WriteLine(book);
                        books.Add(book);
                    }
                }
            }
            return books;
        }
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "SELECT  Top(50)* FROM Book INNER JOIN Author ON Author.Name = Book.AuthorName";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        int BookId = Convert.ToInt32(dr["BookId"]);
                        int CategoryId = Convert.ToInt32(dr["CatId"]);
                        string Title = dr["Title"].ToString();
                        string AuthorName = dr["AuthorName"].ToString();
                        int ISBN = (int)Convert.ToInt64(dr["ISBN"]);
                        DateTime Year = Convert.ToDateTime(dr["Year"]);
                        float Price = (float)Convert.ToDecimal(dr["Price"]);
                        
                        string Image = dr["Image"].ToString();
                        string Description = dr["Description"].ToString();
                        int Position = Convert.ToInt32(dr["Position"]);
                        string Status = dr["Status"].ToString();
                        string Format = dr["Format"].ToString();
                        float Rating = (float)Convert.ToDecimal(dr["Rating"]);

                        Book book = new Book(BookId, CategoryId, Title, AuthorName, ISBN,Price, Year, Image, Description, Position, Status,Rating,Format);
                        Console.WriteLine(book);
                        books.Add(book);
                    }
                }
            }
            return books;
        }

        public int UpdateBook(Book book)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "update Book set Title='" + book.Title + "', Description='" + book.Description + "', AuthorName='" + book.AuthorName + "', Position=" + book.Position + ", Status='" + book.Status + "' where BookId=" + book.BookId + " ";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }

        public List<Book> GetBooksbyId(int id)
        {
            List<Book> books = new List<Book>();
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "select Top 30 * from Book where CatId=" + id + "";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int BookId = Convert.ToInt32(dr["BookId"]);
                        int CategoryId = Convert.ToInt32(dr["CatId"]);
                        string Title = dr["Title"].ToString();
                        string AuthorName = dr["AuthorName"].ToString();
                        int ISBN = (int)Convert.ToInt64(dr["ISBN"]);
                        DateTime Year = Convert.ToDateTime(dr["Year"]);
                        float Price = (float)Convert.ToDecimal(dr["Price"]);
                        string Image = dr["Image"].ToString();
                        string Description = dr["Description"].ToString();
                        int Position = Convert.ToInt32(dr["Position"]);
                        string Status = dr["Status"].ToString();
                        string Format = dr["Format"].ToString();
                        float Rating = (float)Convert.ToDecimal(dr["Rating"]);

                        Book book = new Book(BookId, CategoryId, Title, AuthorName, ISBN, Price,Year, Image, Description, Position, Status,Rating,Format);
                        Console.WriteLine(book);
                        books.Add(book);
                    }
                }
            }
            return books;
        }

        Book InterfaceBook.GetBooksbyName(string name)
        {
            Book book = new Book();
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "select * from Book where Title='" + name + "'";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int BookId = Convert.ToInt32(dr["BookId"]);
                        int CategoryId = Convert.ToInt32(dr["CatId"]);
                        string Title = dr["Title"].ToString();
                        string AuthorName = dr["AuthorName"].ToString();
                        int ISBN = (int)Convert.ToInt64(dr["ISBN"]);
                        DateTime Year = Convert.ToDateTime(dr["Year"]);
                        float Price = (float)Convert.ToDecimal(dr["Price"]);
                        string Image = dr["Image"].ToString();
                        string Description = dr["Description"].ToString();
                        int Position = Convert.ToInt32(dr["Position"]);
                        string Status = dr["Status"].ToString();
                        string Format = dr["Format"].ToString();
                        float Rating = (float)Convert.ToDecimal(dr["Rating"]);

                        book = new Book(BookId, CategoryId, Title, AuthorName, ISBN,Price, Year, Image, Description, Position, Status,Rating,Format);

                    }
                }
            }
            return book;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace BookStore.Models
{
    public class AuthorSQLimp : IAuthorRepository
    {

        SqlConnection conn;
        SqlCommand comm;

        public AuthorSQLimp()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sudDB"].ConnectionString);
            comm = new SqlCommand();
        }
        public Author AddAuthor(Author author)
        {
            comm.CommandText = "insert into Author(AuthorId, Name, About, Image) values(" + author.Id + ", '" + author.Name + "', '" + author.About + "', '" + author.Image + "') ";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            conn.Close();
            return author;
        }

        public void DeleteAuthor(int id)
        {
            comm.CommandText = "delete from Author where AuthorId = " + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public Author GetAuthorById(int id)
        {
            comm.CommandText = "select * from Author where AuthorId = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int AuthorId = Convert.ToInt32(dr["AuthorId"]);
                string name = dr["Name"].ToString();
                string about = dr["About"].ToString();
                string image = dr["Image"].ToString();
                Author author = new Author(AuthorId, name, about, image);
                return author;
            }
            conn.Close();
            return null;
        }

        public Author GetAuthorByName(string name)
        {
            comm.CommandText = "select * from Author where Name = " + name;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int Id = Convert.ToInt32(dr["AuthorId"]);
                string AuthorName = dr["Name"].ToString();
                string about = dr["About"].ToString();
                string image = dr["Image"].ToString();
                Author author = new Author(Id, AuthorName, about, image);
                return author;
            }
            conn.Close();
            return null;
        }

        public List<Author> GetAuthors()
        {
            List<Author> authors = new List<Author>();
            comm.CommandText = "Select * from Author";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["AuthorId"]);
                string name = dr["Name"].ToString();
                string about = dr["About"].ToString();
                string image = dr["Image"].ToString();

                authors.Add(new Author(id, name, about, image));
            }

            conn.Close();
            return authors;
        }

        public void UpdateAuthor(int id, Author author)
        {
            comm.CommandText = "Update Author set Name='" + author.Name + "', About='" + author.About + "', Image='" + author.Image + "' where Id = " + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}


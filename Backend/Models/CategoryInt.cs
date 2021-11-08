using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using BookStore.Models;

namespace BookStore.Models

{
    public class CategoryInt : InterfaceCategory
    {
        SqlConnection conn;
        SqlCommand comm;
        public CategoryInt()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["sudDB"].ConnectionString;
            conn = new SqlConnection(connectionstring);
            comm = new SqlCommand();
        }
        public int AddCategory(Category category)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "insert into Category (Name, Description,Image, status,position) values('" + category.Name + "','" + category.Description+ "','" + category.Image + "'," + category.Status + "," + category.Position + ")";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }

        public int DeleteCategory(int id)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "select * from Book where CatId=" + id + "";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        return 0;
                    }
                    conn.Close();
                    comm.CommandText = "delete from Category where CategoryId=" + id + " ";
                    conn.Open();
                    return comm.ExecuteNonQuery();
                }
                else
                {
                    conn.Close();
                    comm.CommandText = "delete from Category where CategoryId=" + id + " ";
                    conn.Open();
                    return comm.ExecuteNonQuery();
                }
                
            }
            
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "select * from Category order by Position";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Category category= new Category();
                        category.CategoryId = dr.GetInt32(0);
                        category.Name = dr.GetString(1);
                        category.Description = dr.GetString(2);
                        category.Image = dr.GetString(3);
                        category.Position = dr.GetByte(5);
                        category.Status = dr.GetByte(4);
                        


                        Console.WriteLine(category);
                        categories.Add(category);
                    }
                }
            }
            return categories;
        }

        public List<Category> Search(string searchword)
        {
            throw new NotImplementedException();
        }

        public int UpdateCategory(Category category)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "update category set Name='" + category.Name + "', Description='"+category.Description+"', Position="+category.Position+", Status="+category.Status+" where CategoryId="+category.CategoryId+" ";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }
    }
}
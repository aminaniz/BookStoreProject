using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;

namespace BookStore.Models
{
    public class UserSQLimp : IUserRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public UserSQLimp()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sudDB"].ConnectionString);
            comm = new SqlCommand();
        }
        public string AddUser(User user)
        {
            comm.CommandText = "exec register @Name = '" + user.Name + "', @Email ='" + user.Email + "', @ContactNo='" + user.ContactNo + "', @Password ='" + user.Password + "'";
            comm.Connection = conn;
            conn.Open();
            int rows = comm.ExecuteNonQuery();
            if (rows > 0)
            {
                conn.Close();
                return "Registered Successfully";
            }
            conn.Close();
            return "Registration Failed";
        }
        
        public User Login(User user)
        {
            comm.CommandText = "exec login @Email = '" + user.Email + "', @Password='" + user.Password + "'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int UserId = Convert.ToInt32(dr["UserId"]);
                string name = dr["Name"].ToString();
                string email = dr["Email"].ToString();
                string mobile = dr["ContactNo"].ToString();
                string password = dr["Password"].ToString();
                int status = Convert.ToInt32(dr["Status"]);
                int admin = Convert.ToInt32(dr["Admin"]);
                string image = dr["Image"].ToString();
                User newUser = new User(UserId, name, email, mobile, password, status, admin, image);
                return newUser;
            }
            conn.Close();
            return null;
        }

        public void DeleteUser(int id)
        {
            comm.CommandText = "delete from Users where UserId = " + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public User GetUserById(int id)
        {
            comm.CommandText = "select * from Users where UserId = " + id;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int UserId = Convert.ToInt32(dr["UserId"]);
                string name = dr["Name"].ToString();
                string email = dr["Email"].ToString();
                string mobile = dr["MObile"].ToString();
                string password = dr["Password"].ToString();
                int status = Convert.ToInt32(dr["Status"]);
                int admin = Convert.ToInt32(dr["Admin"]);
                string image = dr["Image"].ToString();
                User user = new User(UserId, name, email, mobile, password, status, admin, image);
                return user;
            }
            conn.Close();
            return null;
        }

        public User GetUserByMobile(string mobile)
        {
            comm.CommandText = "select * from Users where Mobile = " + mobile;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int UserId = Convert.ToInt32(dr["UserId"]);
                string name = dr["Name"].ToString();
                string email = dr["Email"].ToString();
                string UserMobile = dr["Mobile"].ToString();
                string password = dr["Password"].ToString();
                int status = Convert.ToInt32(dr["Status"]);
                int admin = Convert.ToInt32(dr["Admin"]);
                string image = dr["Image"].ToString();
                User user = new User(UserId, name, email, UserMobile, password, status, admin, image);
                return user;
            }
            conn.Close();
            return null;
        }

        public List<User> GetUserByName(string name)
        {
            List<User> users = new List<User>();
            comm.CommandText = "Select * from Users where Name = '"+name+"'";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int UserId = Convert.ToInt32(dr["UserId"]);
                string UserName = dr["Name"].ToString();
                string email = dr["Email"].ToString();
                string mobile = dr["MObile"].ToString();
                string password = dr["Password"].ToString();
                int status = Convert.ToInt32(dr["Status"]);
                int admin = Convert.ToInt32(dr["Admin"]);
                string image = dr["Image"].ToString();

                users.Add(new User(UserId, UserName, email, mobile, password, status, admin, image));
            }

            conn.Close();
            return users;
        }
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            comm.CommandText = "exec view_customers";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int UserId = Convert.ToInt32(dr["UserId"]);
                string name = dr["Name"].ToString();
                string email = dr["Email"].ToString();
                string mobile = dr["ContactNo"].ToString();
                string password = dr["Password"].ToString();
                int status = Convert.ToInt32(dr["Status"]);
                int admin = Convert.ToInt32(dr["Admin"]);
                string image = dr["Image"].ToString();

                users.Add(new User(UserId, name, email, mobile, password, status, admin, image));
            }

            conn.Close();
            return users;
        }

        public void UpdateUser(int id, User user)
        {
            //this will cause some ambiguity like at each time we don't have to change all the things in the table.
            // we can do that one by one. so i think we need to create separate update request.
        }

        public void ChangeStatus(int id, int status)
        {
            comm.CommandText = "update Users set Status="+status +"where UserId = " + id;
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using BookStore.Models;

namespace BookStore.Models
{
    public class ShippingAddressInt : InterfaceShippingAddress
    {
        SqlConnection conn;
        SqlCommand comm;

        public ShippingAddressInt()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["sudDB"].ConnectionString;
            conn = new SqlConnection(connectionstring);
            comm = new SqlCommand();
        }

        public int AddAddress(ShippingAddress shippingAddress)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "insert into Shipping_Address (UserId, Line1,Line2, City,State, Pincode) values(" + shippingAddress.UserId + ",'" + shippingAddress.Line1 + "','" + shippingAddress.Line2 + "','" + shippingAddress.City + "','" + shippingAddress.State + "', '"+ shippingAddress.Pincode+ "')";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }

        public int DeleteAddress(int id)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "delete from Shipping_Address where AdressId = " + id + "";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }

        public List<ShippingAddress> GetAddress(int userId)
        {
            List<ShippingAddress> listofAddress = new List<ShippingAddress>();
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "select * from Shipping_Address where UserId = "+userId+"";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        
                        int addressId = Convert.ToInt32(dr["AddressId"]);
                        int user_Id = Convert.ToInt32(dr["UserId"]);
                        string line1 = dr["Line1"].ToString();
                        string line2 = dr["Line2"].ToString();
                        string city = dr["City"].ToString();
                        string state = dr["State"].ToString();
                        string pincode = dr["Pincode"].ToString();
                        ShippingAddress shippingAddress = new ShippingAddress(addressId, user_Id, line1, line2, city, state, pincode);

                        listofAddress.Add(shippingAddress);
                    }
                }
            }
            return listofAddress;
        }

        public ShippingAddress GetAddressById(int userId)
        {
            throw new NotImplementedException();
        }

        public int UpdateAddress(ShippingAddress shippingAddress)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "update Shipping_Address set  Line1 = '" + shippingAddress.Line1 + "', Line2 = '" + shippingAddress.Line2 + "', City = '" + shippingAddress.City + "', State = '" + shippingAddress.State + "',Pincode = '" + shippingAddress.Pincode + "' where UserId = " + shippingAddress.UserId + " and AddressId ="+shippingAddress.AddressId+"";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class CouponInt : InterfaceCoupon
    {
        SqlConnection conn;
        SqlCommand comm;
        public CouponInt()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["sudDB"].ConnectionString;
            conn = new SqlConnection(connectionstring);
            comm = new SqlCommand();
        }
        public int AddCoupon(Coupon coupon)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "insert into Coupon (Tag,Discount,ExpiryDate,MinAmount,Activated) values('" + coupon.Tag + "',"+coupon.Discount+",'" + coupon.ExpiryDate + "'," + coupon.MinAmount + "," + coupon.Activated + "  )";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }

        public int DeleteCoupon(int id)
        {
            throw new NotImplementedException();
        }

        public List<Coupon> GetCoupons()
        {
            List<Coupon> coupons = new List<Coupon>();
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "SELECT  Top(50)* FROM Coupon ";
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        int CouponId = Convert.ToInt32(dr["CouponId"]);
                        string Tag = dr["Tag"].ToString();
                        DateTime ExpiryDate = Convert.ToDateTime(dr["ExpiryDate"]);
                        float Discount = (float)Convert.ToDecimal(dr["Discount"]);
                        int MinAmount = Convert.ToInt32(dr["MinAmount"]);
                        int Activated = Convert.ToInt32(dr["Activated"]);

                        Coupon coupon = new Coupon(CouponId,Tag,ExpiryDate,Discount,MinAmount,Activated);
                        Console.WriteLine(coupon);
                        coupons.Add(coupon);
                    }
                }
            }
            return coupons;
        }

        public int UpdateCoupon(Coupon coupon)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "update Coupon set Tag='" + coupon.Tag + "', Discount=" + coupon.Discount + "where CouponId=" + coupon.CouponId + " ";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }

        public int StatusChange(int id,int status)
        {
            int rows;
            using (conn)
            {
                comm.Connection = conn;
                comm.CommandText = "update Coupon set Activated="+status+" where CouponId="+id+" ";
                conn.Open();
                rows = comm.ExecuteNonQuery();
            }
            return rows;
        }
    }
}
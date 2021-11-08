using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Models
{
    interface InterfaceCoupon
    {
        List<Coupon> GetCoupons();
        int UpdateCoupon(Coupon Coupon);
        int StatusChange(int id, int status);
        int DeleteCoupon(int id);
        int AddCoupon(Coupon coupon);
    }
}

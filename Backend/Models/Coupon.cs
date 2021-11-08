using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Coupon
    {

        public int CouponId;
        public string Tag;
        public float Discount;
        public DateTime ExpiryDate;
        public int MinAmount;
        public int Activated;


        public Coupon( int couponId,string tag,DateTime expiryDate, float discount, int minAmount,int activated)
        {
            CouponId=couponId;
        Tag=tag;
       Discount=discount;
        ExpiryDate=expiryDate;
       MinAmount=minAmount;
        Activated=activated;
    }
    }
}
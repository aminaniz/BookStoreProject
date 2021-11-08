using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ShippingAddress
    {
        public ShippingAddress(int addressId, int userId, string line1, string line2, string city, string state, string pincode)
        {
            AddressId = addressId;
            UserId = userId;
            Line1 = line1;
            Line2 = line2;
            City = city;
            State = state;
            Pincode = pincode;
        }

        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
    }
}
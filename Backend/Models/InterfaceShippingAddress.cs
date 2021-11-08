using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    interface InterfaceShippingAddress
    {
        List<ShippingAddress> GetAddress(int userId);
        ShippingAddress GetAddressById(int userId);
        int UpdateAddress(ShippingAddress shippingAddress);
        int DeleteAddress(int id);
        int AddAddress(ShippingAddress shippingAddress);
    }
}

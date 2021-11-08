using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    interface IOrderRepository
    {
        List<Orders> GetOrders(int UserId);
        int AddOrder(int userId);
        int UpdateOrder(int OrderId, Orders orders);
        int DeleteOrder(int OrderId);
    }
}

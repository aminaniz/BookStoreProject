using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    interface CartItemInterface
    {
        List<CartItem> GetCartItems(int UserId);
        int AddCartItem(CartItem cartItem);
        int UpdateCartItem(int cartItemId, CartItem cartItem);
        int DeleteCartItem(int cartItemId);

        int DeleteCart(int userId);
    }
}

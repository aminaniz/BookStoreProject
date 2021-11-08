using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    interface IWishRepositry
    {
        List<Wishlist> GetWishlist(int UserId);
        int AddWishlist(Wishlist wishlist);
        int DeleteWishlist(int WishId);
    }
}

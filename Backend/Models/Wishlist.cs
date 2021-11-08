using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Wishlist
    {
        public Wishlist(int wishId, int bookId, int userId,decimal price, string image, string title, string author)
        {
            WishId = wishId;
            BookId = bookId;
            UserId = userId;
            Price = price;
            Image = image;
            Title = title;
            Author = author;
        }

        public int WishId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public decimal Price { get; }
        public string Image { get; }
        public string Title { get; }
        public string Author { get; }
    }
}
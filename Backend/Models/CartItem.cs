using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int BookId { get; set; }
        public int UserId{ get; set; }
        public int Active { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Total { get; set; }

        public CartItem(int carItemId, int bookId, int userId, int active, decimal price, int quantity, string image, string title, string author, decimal total)
        {
            this.CartItemId = carItemId;
            this.BookId = bookId;
            this.UserId = userId;
            this.Active = active;
            this.Price = price;
            this.Quantity = quantity;
            this.Image = image;
            this.Title = title;
            this.Author = author;
            this.Total = total;
        }

        public CartItem()
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal GrandTotal { get; set; }
        public string CouponCode { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public string Title { get; }
        public string Author { get; }
        public string Title1 { get; }
        public string Author1 { get; }
        public string Image { get; }

        public Orders()
        {
            
        }

        public Orders(int user_Id, int bookId, int status, decimal price, int quantity, decimal totalPrice, decimal discount, string couponCode)
        {
            BookId = bookId;
            Status = status;
            Price = price;
            Quantity = quantity;
            TotalPrice = totalPrice;
            Discount = discount;
            //GrandTotal = grandTotal;
            CouponCode = couponCode;
        }


        public Orders(int user_Id, int bookId, int status, decimal price, int quantity, decimal totalPrice, decimal discount,  string couponCode, string title, string author, string image) 
        {
            BookId = bookId;
            Status = status;
            Price = price;
            Quantity = quantity;
            TotalPrice = totalPrice;
            Discount = discount;
            //GrandTotal = grandTotal;
            CouponCode = couponCode;
            Title1 = title;
            Author1 = author;
            Image = image;
        }
    }
}
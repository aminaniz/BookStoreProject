using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {
        private int categoryId;
        private string authorName;
        private int position;
        private int status;

        public int BookId { get; set; }
        public int CatId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int ISBN { get; set; }
        public DateTime Year { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }
        public byte Position { get; set; }
        public string Status { get; set; }
        public string Image { get; set; }

        public Book() { }

        public Book(int bookId, int categoryId, string title, string authorName, int iSBN, float price,
            DateTime year, string image, string description, int position, string status,float rating,string format)
        {
            BookId = bookId;
            this.categoryId = categoryId;
            Title = title;
            this.AuthorName = authorName;
            ISBN = iSBN;
            Price = price;
            Year = year;
            Image = image;
            Description = description;
            this.position = position;
            this.Status = status;
            Rating = rating;
            Format = format;
        }
    }

    
}
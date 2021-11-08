using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public int Admin { get; set; }
        public string Image { get; set; }

        public User() { }

        public User(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public User(int userId, string name, string email, string ContactNo, string password, int status, int admin, string image)
        {
            this.UserId = userId;
            this.Name = name;
            this.ContactNo = ContactNo;
            this.Email = email;
            this.Password = password;
            this.Status = status;
            this.Admin = admin;
            this.Image = image;

        }
    }
}
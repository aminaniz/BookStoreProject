using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Image { get; set; }

        public Author() { }

        public Author(int id, string name, string about, string image)
        {
            this.Id = id;
            this.Name = name;
            this.About = about;
            this.Image = image;
        }
    }
}
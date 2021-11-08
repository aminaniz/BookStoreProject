using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models;
using System.Web.Http.Cors;


namespace BookStore.Controllers
{
    
    public class AuthorController : ApiController
    {
        private IAuthorRepository repository;

        public AuthorController()
        {
            this.repository = new AuthorSQLimp();
        }

        [HttpGet]
        public List<Author> Get() { return repository.GetAuthors(); }

        [HttpGet]
        public Author Get(int id) { return repository.GetAuthorById(id); }

        [HttpGet]
        public Author Get(string name) { return repository.GetAuthorByName(name); }

        [HttpPost]
        public Author Post(Author author) { return repository.AddAuthor(author); }

        [HttpPut]
        public void Put(int id, Author author) { repository.UpdateAuthor(id, author); }

        [HttpDelete]
        public void Delete(int id) { repository.DeleteAuthor(id); }

    }
}

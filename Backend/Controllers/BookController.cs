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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BookController : ApiController
    {
        private InterfaceBook repository;

        public BookController()
        {
            this.repository = new BookInt();
        }
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var data = repository.DeleteBook(id);
            if (data <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something went wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }
        }
        [HttpPut]
        [Route("updatebook")]
        public HttpResponseMessage Put(Book book)
        {
            var data = repository.UpdateBook(book);
            if (data <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something went wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Updated");
            }
        }
        [HttpGet]
        [Route("books")]
        public IHttpActionResult Get()
        {
            Console.WriteLine("qqq");
            return Ok(repository.GetBooks());
        }

        [HttpGet]
        [Route("booksid/{id}")]
        public IHttpActionResult Get(int id)
        {
            Console.WriteLine("gfhg");
            return Ok(repository.GetBooksbyId(id));
        }

        [HttpGet]
        [Route("details/{name}")]
        public IHttpActionResult Get(string name)
        {
            Console.WriteLine("gfhg");
            return Ok(repository.GetBooksbyName(name));
        }

        [HttpGet]
        [Route("search/{name}/{search}")]
        public IHttpActionResult Get(string name,string search)
        {
            Console.WriteLine("gfhg");
            return Ok(repository.Search(name,search));
        }



        [HttpPost]
        [Route("addbook")]
        public HttpResponseMessage Post(Book book)
        {
            var data = repository.AddBook(book);
            if (data <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something is wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Book Added");
            }
        }
    }
}

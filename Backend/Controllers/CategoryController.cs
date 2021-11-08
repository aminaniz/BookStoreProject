using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BookStore.Models;


namespace BookStore.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        private InterfaceCategory repository;

        public CategoryController()
        {
            this.repository = new CategoryInt();
        }

        [HttpDelete]
        [Route("deletecat/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = repository.DeleteCategory(id);
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
        [Route("updatecat")]
        public HttpResponseMessage Put(Category category)
        {
            var data = repository.UpdateCategory(category);
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
        [Route("categories")]
        public IHttpActionResult Get()
        {
            return Ok(repository.GetCategories());
        }

        [HttpGet]
        [Route("searchcat")]
        public HttpResponseMessage Get(string searchword)
        {
            var data = repository.Search(searchword);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Category Doesnt exist");
            }
        }

        [HttpPost]
        [Route("addcat")]
        public HttpResponseMessage Post(Category category)
        {
            var data = repository.AddCategory(category);
            if (data <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something is wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Category Added");
            }
        }
    }
}

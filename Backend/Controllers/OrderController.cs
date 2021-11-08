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
    public class OrderController : ApiController
    {
        private IOrderRepository repository;

        public OrderController()
        {
            this.repository = new OrderSQLImp();
        }

        [HttpDelete]
        [Route("myOrder/{id}")]
        public HttpResponseMessage DeleteOrder(int id)
        {
            var data = repository.DeleteOrder(id);
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
        [Route("myOrder/{id}")]
        public HttpResponseMessage Put(int id, Orders orders)
        {
            var data = repository.UpdateOrder(id, orders);
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
        [Route("myOrder/{UserId}")]
        public HttpResponseMessage Get(int UserId)
        {
            var data = repository.GetOrders(UserId);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Cart is Empty");
            }
        }




        [HttpGet]
        [Route("place_order/{userId}")]
        public HttpResponseMessage AddOrder(int userId)
        {
            var data = repository.AddOrder(userId);
            if (data <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something is wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Item ordered");
            }
        }

    }
}

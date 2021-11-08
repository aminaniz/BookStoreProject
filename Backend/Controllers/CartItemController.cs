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
    public class CartItemController : ApiController
    {
        private CartItemInterface repository;

        public CartItemController()
        {
            this.repository = new CartItemSQLimp();
        }

        [HttpDelete]
        [Route("cart/{id}")]
        public HttpResponseMessage DeleteCartItem(int id)
        {
            var data = repository.DeleteCartItem(id);
            if (data <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something went wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }
        }

        [HttpDelete]
        [Route("empty_cart/{UserId}")]
        public HttpResponseMessage DeleteCart(int userId)
        {
            var data = repository.DeleteCart(userId);
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
        [Route("cart/{id}")]
        public HttpResponseMessage Put(int id, CartItem cartItem)
        {
            var data = repository.UpdateCartItem(id, cartItem);
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
        [Route("cart/{UserId}")]
        public HttpResponseMessage Get(int UserId)
        {
            var data = repository.GetCartItems(UserId);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Cart is Empty");
            }
        }




        [HttpPost]
        [Route("add-to-cart")]
        public HttpResponseMessage Post(CartItem cartItem)
        {
            var data = repository.AddCartItem(cartItem);
            if (data <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something is wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Item Added into cart");
            }
        }
    }
}

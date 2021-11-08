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
    public class WishlistController : ApiController
    {
        private IWishRepositry repository;

        public WishlistController()
        {
            this.repository = new WishlistSQLimp();
        }

        [HttpDelete]
        [Route("delete-wishlist/{id}")]
        public HttpResponseMessage DeleteWishlistItem(int id)
        {
            var data = repository.DeleteWishlist(id);
            if (data <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something went wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }
        }

        [HttpGet]
        [Route("wishlist/{UserId}")]
        public HttpResponseMessage Get(int UserId)
        {
            var data = repository.GetWishlist(UserId);
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
        [Route("add-wishlist/{userId}")]
        public HttpResponseMessage Post(Wishlist wishlist)
        {
            var data = repository.AddWishlist(wishlist);
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

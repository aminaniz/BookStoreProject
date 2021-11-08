using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CouponStore.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CouponController : ApiController
    {
        private InterfaceCoupon repository;
        public CouponController()
        {
            this.repository = new CouponInt();

        }
        [HttpPost]
        [Route("addcoupon")]
        public HttpResponseMessage Post(Coupon coupon)
        {
            var data = repository.AddCoupon(coupon);
            if (data <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something is wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Coupon Added");
            }
        }

        [HttpGet]
        [Route("coupons")]
        public IHttpActionResult Get()
        {
            Console.WriteLine("qqq");
            return Ok(repository.GetCoupons());
        }

        [HttpDelete]
        [Route("deletecoupon")]
        public HttpResponseMessage Delete(int id)
        {
            var data = repository.DeleteCoupon(id);
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
        [Route("updatecoupon")]
        public HttpResponseMessage Put(Coupon coupon)
        {
            var data = repository.UpdateCoupon(coupon);
            if (data <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something went wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Coupon Updated");
            }
        }

        [HttpPut]
        [Route("coupon/statuschange/{id}/{status}")]
        public HttpResponseMessage Put(int id, int status)
        {
            var data = repository.StatusChange(id,status);
            if (data <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Something went wrong");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Coupon Updated");
            }
        }
    }
}

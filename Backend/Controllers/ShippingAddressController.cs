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
    public class ShippingAddressController : ApiController
    {
        private InterfaceShippingAddress repository;

        public ShippingAddressController()
        {
            this.repository = new ShippingAddressInt();
        }

        [HttpGet]
        [Route("ShippingAddress/{UserId}")]
        public List<ShippingAddress> Get(int userId) { return repository.GetAddress(userId); }

        [HttpGet]
        public ShippingAddress GetById(int userId) { return repository.GetAddressById(userId); }

        [HttpPost]
        [Route("addAddress")]
        public int Post(ShippingAddress shippingAddress) { return repository.AddAddress(shippingAddress); }

        [HttpPut]
        [Route("updateAddress")]
        public int Put(ShippingAddress shippingAddress) 
        { return repository.UpdateAddress(shippingAddress); }

        [HttpDelete]
        public void Delete(int id) { repository.DeleteAddress(id); }
    }
}

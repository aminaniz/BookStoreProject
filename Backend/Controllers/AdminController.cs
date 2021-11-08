using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookStore.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdminController : ApiController
    {
        private InterfaceAdmin repository;
        public AdminController()
        {
            this.repository = new AdminInt();
            
        }

        [HttpPost]
        [Route("admin/login")]
        public Admin Login(Admin admin) { return repository.Login(admin); }
    }
}

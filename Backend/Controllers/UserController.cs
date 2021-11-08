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
    [EnableCors (origins:"*", headers:"*", methods:"*")]
    public class UserController : ApiController
    {
        private IUserRepository repository;
        public UserController()
        {
            this.repository = new UserSQLimp();
        }

        [HttpGet]
        [Route("api/customers")]
        public List<User> Get() { return repository.GetUsers(); }

        [HttpGet]
        public User Get(int id) { return repository.GetUserById(id); }

        [HttpGet]
        public List<User> Get(string name) { return repository.GetUserByName(name); }

        [HttpPost]
        [Route("api/register")]
        public string Post(User user) { return repository.AddUser(user); }

        [HttpPost]
        [Route("api/user/login")]
        public User Login(User user) { return repository.Login(user); }

        [HttpPut]
        [Route("api/user/statuschange/{id}/{status}")]
        public void Put(int id, int status) { repository.ChangeStatus(id, status); }

        [HttpDelete]
        public void Delete(int id) { repository.DeleteUser(id); }

    }
}

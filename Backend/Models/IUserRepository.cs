using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserById(int id);
        List<User> GetUserByName(string name);
        User GetUserByMobile(string ContactNo);
        void UpdateUser(int id, User user);
        string AddUser(User user);
        void DeleteUser(int id);
        User Login(User user);

        void ChangeStatus(int id, int status);
    }
}

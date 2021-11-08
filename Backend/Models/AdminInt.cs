using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class AdminInt : InterfaceAdmin
    {
        Admin InterfaceAdmin.Login(Admin admin)
        {
            if (admin.Username=="admin123" && admin.Password == "admin")
            {
                return admin;
            }
            else if(admin.Username=="admin456" && admin.Password == "admin")
            {
                return admin;
            }
            else
            {
                return null;
            }
        }
    }
}
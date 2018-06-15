using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.DataIO;

namespace WebAPI.Controllers
{
    public class ProfController : ApiController
    {
        public static XMLDataIO xml = new XMLDataIO();

        [HttpGet]
        [ActionName("GetUserByUsername")]
        public User GetUserByUsername(string username)
        {
            string ss = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Users.xml");
            List<User> users = xml.ReadUsers(ss);

            foreach(User us in users) { 
                if (us.UserName == username)
                {
                    User kor = new Customer();
                    kor.UserName = us.UserName;
                    kor.Name = us.Name;
                    kor.Surname = us.Surname;
                    kor.Role = us.Role;
                    kor.Email = us.Email;
                    kor.ContactPhoneNumber = us.ContactPhoneNumber;
                    kor.Gender =us.Gender;
                    kor.Password = null;
                    kor.JMBG = us.JMBG;
                    kor.Drives = us.Drives;
                    
                    return kor;
                }
            }
           
            return null;
        }

    }
}

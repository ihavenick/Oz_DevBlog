using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Oz_DevBlog.DAL.Context;
using Oz_DevBlog.Data.Identity_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace Oz_DevBlog.UI.Controllers
{
    public class AApiController : ApiController
    {

        private readonly Oz_DevDBContext DB;
        private readonly UserStore<ApplicationUser> uStore;
        private readonly UserManager<ApplicationUser> AppUserManager;


        public AApiController()
        {
            DB = new Oz_DevDBContext();
            uStore = new UserStore<ApplicationUser>(DB);
            AppUserManager = new UserManager<ApplicationUser>(uStore);
        }

  
        public UnrealUser GetUserByName(string username,string password)
        {
            //Only SuperAdmin or Admin can delete users (Later when implement roles)
            ApplicationUser user = AppUserManager.Find(username, password);

            if (user != null)
            {

                UnrealUser a = new UnrealUser()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                };
                a.ImageLink = "http://atacetin.net" + user.ImageofUser.ImagePath;

                return a;
            }

            return null;

        }

    }
    public class UnrealUser
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageLink { get; set; }

    }
}

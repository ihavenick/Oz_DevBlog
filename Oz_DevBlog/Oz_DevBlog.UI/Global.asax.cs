using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Oz_DevBlog.DAL.Context;
using Oz_DevBlog.Data.Identity_Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Oz_DevBlog.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Oz_DevDBContext db = new Oz_DevDBContext();
            RoleStore<ApplicationRole> rstore = new RoleStore<ApplicationRole>(db);
            RoleManager<ApplicationRole> rManager = new RoleManager<ApplicationRole>(rstore);
            UserStore<ApplicationUser> uStore = new UserStore<ApplicationUser>(db);
            UserManager<ApplicationUser> uManager = new UserManager<ApplicationUser>(uStore);
            
            if (!rManager.RoleExists("Admin"))
            {
                ApplicationRole adminRole = new ApplicationRole("Admin", "Sistem Yöneticisi");
                rManager.Create(adminRole);
            }
            if (!rManager.RoleExists("User"))
            {
                ApplicationRole userRole = new ApplicationRole("User", "Sistem kullanicisi");
                rManager.Create(userRole);
            }

            

            if (uManager.FindByEmail("admin@atacetin.net") == null)
            {
                ApplicationUser u = new ApplicationUser()
                {
                    Email = "admin@atacetin.net",
                    UserName = "adminadmin",
                     FirstName= "Ata",
                     LastName = "Çetin",
                      Address="Ankara",
                       ImageID=1,
                        PhoneNumber="+905320557453",
                         
                     

                };

                uManager.Create(u, "1234567?");
                uManager.AddToRole(u.Id, "Admin");

            }
        }
    }
}

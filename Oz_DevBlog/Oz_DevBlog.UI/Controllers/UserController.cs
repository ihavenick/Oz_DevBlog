using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Oz_DevBlog.DAL.Context;
using Oz_DevBlog.Data.Identity_Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oz_DevBlog.UI.Controllers
{
    public class UserController : Controller
    {

        private readonly Oz_DevDBContext db;
            private readonly UserStore<ApplicationUser> uStore;
        private readonly UserManager<ApplicationUser> uManager;
        public UserController()
        {
            db = new Oz_DevDBContext();
            uStore = new UserStore<ApplicationUser>(db);
            uManager = new UserManager<ApplicationUser>(uStore);
        }
        // GET: User
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            ViewBag.ImageID = new SelectList(db.Image, "ImageID", "ImagePath");

            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser currentuser = await uManager.FindByIdAsync(User.Identity.GetUserId());
                return View(currentuser);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Index([Bind(Include = "Id,ImageID,FirstName,LastName,PhoneNumber,Address,Email,PasswordHash,SecurityStamp,UserName")] ApplicationUser user)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return View(user);
            }
            return View(user);
        }
    }
}
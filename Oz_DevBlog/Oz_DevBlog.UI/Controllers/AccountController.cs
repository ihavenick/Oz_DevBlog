using hbehr.recaptcha;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Oz_DevBlog.DAL.Context;
using Oz_DevBlog.Data.Identity_Entity;
using Oz_DevBlog.UI.Models.AccountVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Oz_DevBlog.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly Oz_DevDBContext DB;
        private readonly UserStore<ApplicationUser> uStore;
        private readonly UserManager<ApplicationUser> uManager;


        public AccountController()
        {
            DB = new Oz_DevDBContext();
            uStore = new UserStore<ApplicationUser>(DB);
            uManager = new UserManager<ApplicationUser>(uStore);
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser uselected = uManager.Find(model.UserName, model.Password);
                if (uselected==null)
                {
                    return View(model);
                }
                else
                {
                    IAuthenticationManager auth = HttpContext.GetOwinContext().Authentication;
                    AuthenticationProperties rememberProp=new AuthenticationProperties();
                    rememberProp.IsPersistent=model.RememberMe;
                    ClaimsIdentity identity= uManager.CreateIdentity(uselected,"ApplicationCookie");
                    auth.SignIn(rememberProp, identity);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(model);
            }
  
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterVM model)
        {
            string userResponse = HttpContext.Request.Params["g-recaptcha-response"];
            bool validCaptcha = ReCaptcha.ValidateCaptcha(userResponse);
            if (validCaptcha)
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser uinserted = new ApplicationUser()
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserName = model.UserName,
                        Address = model.Address,

                    };
                    IdentityResult result = uManager.Create(uinserted, model.Password);
                    if (result.Succeeded)
                    {
                        uManager.AddToRole(uinserted.Id, "User");
                        return RedirectToAction("Login", "Account");
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            IAuthenticationManager auth = HttpContext.GetOwinContext().Authentication;
            auth.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}
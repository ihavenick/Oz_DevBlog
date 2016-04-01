using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oz_DevBlog.UI.Areas.Admin.Controllers
{
    public class PanelController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if(User.IsInRole("Admin"))
            {
                return View();
            }
            else
            {
               return RedirectToAction("Index", "Home");
            }
        }
    }
}
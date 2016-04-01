using System.Web.Mvc;

namespace Oz_DevBlog.UI.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
               defaults: new { controller = "Panel", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
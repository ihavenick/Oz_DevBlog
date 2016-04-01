using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oz_DevBlog.DAL.Repository;
using Oz_DevBlog.Data.Model_Entity;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Oz_DevBlog.DAL.Context;
using Oz_DevBlog.Data.Identity_Entity;
using hbehr.recaptcha;

namespace Oz_DevBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository<AdminDesc> RepAd;
        private readonly Repository<Skill> RepSkill;
        private readonly Repository<Education> RepEdu;
        private readonly Repository<SkillType> RepSkilltype;
        private readonly Repository<Employment> RepEmp;
        private readonly Repository<Project> RepPro;
        private readonly Repository<Blog> RepBlo;
        private readonly Repository<BlogType> RepBtype;
        private readonly Repository<Tag> RepTag;
        private readonly Repository<SocialMedia> RepS;
        private readonly Oz_DevDBContext db;
        private readonly UserStore<ApplicationUser> uStore;
        private readonly UserManager<ApplicationUser> uManager;
        private readonly Repository<Comment> RepC;
        public HomeController()
        {
            db = new Oz_DevDBContext();
            uStore = new UserStore<ApplicationUser>(db);
            uManager = new UserManager<ApplicationUser>(uStore);
            RepTag = new Repository<Tag>();
            RepBlo = new Repository<Blog>();
            RepPro = new Repository<Project>();
            RepEmp = new Repository<Employment>();
            RepEdu = new Repository<Education>();
            RepSkill = new Repository<Skill>();
            RepSkilltype = new Repository<SkillType>();
            RepAd = new Repository<AdminDesc>();
            RepBtype = new Repository<BlogType>();
            RepS = new Repository<SocialMedia>();
            RepC = new Repository<Comment>();
        }
        // GET: Home
        public ActionResult Index(int? sayfaNo)
        {
            ViewBag.S = RepS.GetAllEntity();
            ViewBag.Pro = RepPro.GetAllEntity().Include("Image");
            ViewBag.Admindesc = RepAd.GetEntityByID(1);
            ViewBag.Skills = RepSkill.GetAllEntity();
            ViewBag.Skilltype = RepSkilltype.GetAllEntity().Include("Skill");
            ViewBag.Edu = RepEdu.GetAllEntity();
            ViewBag.Emp = RepEmp.GetAllEntity();
            ViewBag.Bty = RepBtype.GetAllEntity();
            ViewBag.Tag = RepTag.GetAllEntity();

            ViewBag.Admin = uManager.FindByEmail("admin@atacetin.net");

            return View(RepBlo.GetAllEntity().OrderBy(x => x.BlogID).ToPagedList(sayfaNo ?? 1, 3));

        }

        public ActionResult Detail(int? blogid)
        {
            ViewBag.Admin = uManager.FindByEmail("admin@atacetin.net");
            ViewBag.Bty = RepBtype.GetAllEntity();
            ViewBag.Tag = RepTag.GetAllEntity();
            Blog blog = RepBlo.GetEntityByID(Convert.ToInt32(blogid));
            return View(blog);
        }
        [HttpPost]
        public ActionResult Detail(int? blogid, string CommentContent)
        {
            ApplicationUser admin = uManager.FindByEmail("admin@atacetin.net");
            string userResponse = HttpContext.Request.Params["g-recaptcha-response"];
            bool validCaptcha = ReCaptcha.ValidateCaptcha(userResponse);
            if (validCaptcha)
            {
                Comment c = new Comment()
                {
                    CommentContent = CommentContent,
                    ApplicationUserId = User.Identity.GetUserId(),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsActive = true,
                    BlogID = blogid,

                };
                RepC.InsertEntity(c);
                ViewBag.Admin = uManager.FindByEmail("admin@atacetin.net");
                ViewBag.Bty = RepBtype.GetAllEntity();
                ViewBag.Tag = RepTag.GetAllEntity();
                Blog blog = RepBlo.GetEntityByID(Convert.ToInt32(blogid));
                return View(blog);
            }
            else {
                // Bot Attack, non validated !
                return RedirectToAction("Home", "Index");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oz_DevBlog.DAL.Context;
using Oz_DevBlog.Data.Model_Entity;

namespace Oz_DevBlog.UI.Areas.Admin.Controllers
{
    public class SocialMediasController : Controller
    {
        private Oz_DevDBContext db = new Oz_DevDBContext();

        // GET: Admin/SocialMedias
        public ActionResult Index()
        {
            return View(db.SocialMedia.ToList());
        }

        // GET: Admin/SocialMedias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialMedia = db.SocialMedia.Find(id);
            if (socialMedia == null)
            {
                return HttpNotFound();
            }
            return View(socialMedia);
        }

        // GET: Admin/SocialMedias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SocialMedias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SocialMediaID,SocialMediaName,SocialMediaLink,SocialMediaIcon,DateCreated,DateModified,IsActive")] SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                db.SocialMedia.Add(socialMedia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socialMedia);
        }

        // GET: Admin/SocialMedias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialMedia = db.SocialMedia.Find(id);
            if (socialMedia == null)
            {
                return HttpNotFound();
            }
            return View(socialMedia);
        }

        // POST: Admin/SocialMedias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SocialMediaID,SocialMediaName,SocialMediaLink,SocialMediaIcon,DateCreated,DateModified,IsActive")] SocialMedia socialMedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialMedia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialMedia);
        }

        // GET: Admin/SocialMedias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedia socialMedia = db.SocialMedia.Find(id);
            if (socialMedia == null)
            {
                return HttpNotFound();
            }
            return View(socialMedia);
        }

        // POST: Admin/SocialMedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialMedia socialMedia = db.SocialMedia.Find(id);
            db.SocialMedia.Remove(socialMedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

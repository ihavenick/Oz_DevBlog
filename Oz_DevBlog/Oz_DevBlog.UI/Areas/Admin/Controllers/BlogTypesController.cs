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
    public class BlogTypesController : Controller
    {
        private Oz_DevDBContext db = new Oz_DevDBContext();

        // GET: Admin/BlogTypes
        public ActionResult Index()
        {
            return View(db.BlogType.ToList());
        }

        // GET: Admin/BlogTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogType blogType = db.BlogType.Find(id);
            if (blogType == null)
            {
                return HttpNotFound();
            }
            return View(blogType);
        }

        // GET: Admin/BlogTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BlogTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogTypeID,BlogTypeName,IsActive,DateCreated,DateModified")] BlogType blogType)
        {
            if (ModelState.IsValid)
            {
                db.BlogType.Add(blogType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogType);
        }

        // GET: Admin/BlogTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogType blogType = db.BlogType.Find(id);
            if (blogType == null)
            {
                return HttpNotFound();
            }
            return View(blogType);
        }

        // POST: Admin/BlogTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogTypeID,BlogTypeName,IsActive,DateCreated,DateModified")] BlogType blogType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogType);
        }

        // GET: Admin/BlogTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogType blogType = db.BlogType.Find(id);
            if (blogType == null)
            {
                return HttpNotFound();
            }
            return View(blogType);
        }

        // POST: Admin/BlogTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogType blogType = db.BlogType.Find(id);
            db.BlogType.Remove(blogType);
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

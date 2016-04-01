using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oz_DevBlog.DAL.Context;
using Oz_DevBlog.Data.Model_Entity;

namespace Oz_DevBlog.UI.Areas.Admin.Controllers
{
    public class CommentsController : Controller
    {
        private Oz_DevDBContext db = new Oz_DevDBContext();

        // GET: Admin/Comments
        public async Task<ActionResult> Index()
        {
            var comment = db.Comment.Include(c => c.Blog).Include(c => c.UserOfComment);
            return View(await comment.ToListAsync());
        }

        // GET: Admin/Comments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = await db.Comment.FindAsync(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Admin/Comments/Create
        public ActionResult Create()
        {
            ViewBag.BlogID = new SelectList(db.Blog, "BlogID", "BlogTitle");
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Admin/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CommentID,CommentContent,BlogID,IsAccepted,IsActive,DateCreated,DateModified,ApplicationUserId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comment.Add(comment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BlogID = new SelectList(db.Blog, "BlogID", "BlogTitle", comment.BlogID);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", comment.ApplicationUserId);
            return View(comment);
        }

        // GET: Admin/Comments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = await db.Comment.FindAsync(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogID = new SelectList(db.Blog, "BlogID", "BlogTitle", comment.BlogID);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", comment.ApplicationUserId);
            return View(comment);
        }

        // POST: Admin/Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CommentID,CommentContent,BlogID,IsAccepted,IsActive,DateCreated,DateModified,ApplicationUserId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BlogID = new SelectList(db.Blog, "BlogID", "BlogTitle", comment.BlogID);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", comment.ApplicationUserId);
            return View(comment);
        }

        // GET: Admin/Comments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = await db.Comment.FindAsync(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Admin/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Comment comment = await db.Comment.FindAsync(id);
            db.Comment.Remove(comment);
            await db.SaveChangesAsync();
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

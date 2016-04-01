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
    public class AdminDescsController : Controller
    {
        private Oz_DevDBContext db = new Oz_DevDBContext();

        // GET: Admin/AdminDescs
        public ActionResult Index()
        {
            return View(db.AdminDesc.ToList());
        }

        // GET: Admin/AdminDescs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminDesc adminDesc = db.AdminDesc.Find(id);
            if (adminDesc == null)
            {
                return HttpNotFound();
            }
            return View(adminDesc);
        }

        // GET: Admin/AdminDescs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminDescs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminDescID,AdminsTitle,AdminsDesc,AdminsQuote")] AdminDesc adminDesc)
        {
            if (ModelState.IsValid)
            {
                db.AdminDesc.Add(adminDesc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminDesc);
        }

        // GET: Admin/AdminDescs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminDesc adminDesc = db.AdminDesc.Find(id);
            if (adminDesc == null)
            {
                return HttpNotFound();
            }
            return View(adminDesc);
        }

        // POST: Admin/AdminDescs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminDescID,AdminsTitle,AdminsDesc,AdminsQuote")] AdminDesc adminDesc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminDesc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminDesc);
        }

        // GET: Admin/AdminDescs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminDesc adminDesc = db.AdminDesc.Find(id);
            if (adminDesc == null)
            {
                return HttpNotFound();
            }
            return View(adminDesc);
        }

        // POST: Admin/AdminDescs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminDesc adminDesc = db.AdminDesc.Find(id);
            db.AdminDesc.Remove(adminDesc);
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

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
    public class SkillTypesController : Controller
    {
        private Oz_DevDBContext db = new Oz_DevDBContext();

        // GET: Admin/SkillTypes
        public ActionResult Index()
        {
            return View(db.SkillType.ToList());
        }

        // GET: Admin/SkillTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillType skillType = db.SkillType.Find(id);
            if (skillType == null)
            {
                return HttpNotFound();
            }
            return View(skillType);
        }

        // GET: Admin/SkillTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SkillTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SkillTypeID,SkillTypeName,IsActive,DateCreated,DateModified")] SkillType skillType)
        {
            if (ModelState.IsValid)
            {
                db.SkillType.Add(skillType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skillType);
        }

        // GET: Admin/SkillTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillType skillType = db.SkillType.Find(id);
            if (skillType == null)
            {
                return HttpNotFound();
            }
            return View(skillType);
        }

        // POST: Admin/SkillTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SkillTypeID,SkillTypeName,IsActive,DateCreated,DateModified")] SkillType skillType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skillType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skillType);
        }

        // GET: Admin/SkillTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillType skillType = db.SkillType.Find(id);
            if (skillType == null)
            {
                return HttpNotFound();
            }
            return View(skillType);
        }

        // POST: Admin/SkillTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SkillType skillType = db.SkillType.Find(id);
            db.SkillType.Remove(skillType);
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

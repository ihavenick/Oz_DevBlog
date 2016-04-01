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
    public class SkillsController : Controller
    {
        private Oz_DevDBContext db = new Oz_DevDBContext();

        // GET: Admin/Skills
        public ActionResult Index()
        {
            var skill = db.Skill.Include(s => s.SkillType);
            return View(skill.ToList());
        }

        // GET: Admin/Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skill.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // GET: Admin/Skills/Create
        public ActionResult Create()
        {
            ViewBag.SkillTypeID = new SelectList(db.SkillType, "SkillTypeID", "SkillTypeName");
            return View();
        }

        // POST: Admin/Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SkillID,SkillName,SkillRate,SkillTypeID,IsActive,DateCreated,DateModified")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Skill.Add(skill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SkillTypeID = new SelectList(db.SkillType, "SkillTypeID", "SkillTypeName", skill.SkillTypeID);
            return View(skill);
        }

        // GET: Admin/Skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skill.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkillTypeID = new SelectList(db.SkillType, "SkillTypeID", "SkillTypeName", skill.SkillTypeID);
            return View(skill);
        }

        // POST: Admin/Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SkillID,SkillName,SkillRate,SkillTypeID,IsActive,DateCreated,DateModified")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SkillTypeID = new SelectList(db.SkillType, "SkillTypeID", "SkillTypeName", skill.SkillTypeID);
            return View(skill);
        }

        // GET: Admin/Skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = db.Skill.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: Admin/Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skill skill = db.Skill.Find(id);
            db.Skill.Remove(skill);
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

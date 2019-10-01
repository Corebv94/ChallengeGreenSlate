using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UserProjectsController : Controller
    {
        private ChallengeEntities db = new ChallengeEntities();

        // GET: UserProjects
        public ActionResult Index()
        {
            var userProjects = db.UserProjects.Include(u => u.Project).Include(u => u.User);
            return View(userProjects.ToList());
        }

        // GET: UserProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProjects userProjects = db.UserProjects.Find(id);
            if (userProjects == null)
            {
                return HttpNotFound();
            }
            return View(userProjects);
        }

        // GET: UserProjects/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Project, "Id", "Id");
            ViewBag.UserId = new SelectList(db.User, "Id", "FirstName");
            return View();
        }

        // POST: UserProjects/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,ProjectId,IsActive")] UserProjects userProjects)
        {
            if (ModelState.IsValid)
            {
                db.UserProjects.Add(userProjects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Project, "Id", "Id", userProjects.ProjectId);
            ViewBag.UserId = new SelectList(db.User, "Id", "FirstName", userProjects.UserId);
            return View(userProjects);
        }

        // GET: UserProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProjects userProjects = db.UserProjects.Find(id);
            if (userProjects == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Project, "Id", "Id", userProjects.ProjectId);
            ViewBag.UserId = new SelectList(db.User, "Id", "FirstName", userProjects.UserId);
            return View(userProjects);
        }

        // POST: UserProjects/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,ProjectId,IsActive")] UserProjects userProjects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProjects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Project, "Id", "Id", userProjects.ProjectId);
            ViewBag.UserId = new SelectList(db.User, "Id", "FirstName", userProjects.UserId);
            return View(userProjects);
        }

        // GET: UserProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProjects userProjects = db.UserProjects.Find(id);
            if (userProjects == null)
            {
                return HttpNotFound();
            }
            return View(userProjects);
        }

        // POST: UserProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProjects userProjects = db.UserProjects.Find(id);
            db.UserProjects.Remove(userProjects);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegandLogin.Models;

namespace RegandLogin.Controllers
{
    public class new_UserController : Controller
    {
        private practice_purposeEntities db = new practice_purposeEntities();

        // GET: new_User
        public ActionResult Index()
        {
            return View(db.new_User.ToList());
        }

        // GET: new_User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            new_User new_User = db.new_User.Find(id);
            if (new_User == null)
            {
                return HttpNotFound();
            }
            return View(new_User);
        }

        // GET: new_User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: new_User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_name,Password,address,mail,mobile")] new_User new_User)
        {
            if (ModelState.IsValid)
            {
                db.new_User.Add(new_User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(new_User);
        }

        // GET: new_User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            new_User new_User = db.new_User.Find(id);
            if (new_User == null)
            {
                return HttpNotFound();
            }
            return View(new_User);
        }

        // POST: new_User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_name,Password,address,mail,mobile")] new_User new_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(new_User).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(new_User);
        }

        // GET: new_User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            new_User new_User = db.new_User.Find(id);
            if (new_User == null)
            {
                return HttpNotFound();
            }
            return View(new_User);
        }

        // POST: new_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new_User new_User = db.new_User.Find(id);
            db.new_User.Remove(new_User);
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

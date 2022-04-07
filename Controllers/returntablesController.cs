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
    public class returntablesController : Controller
    {
        private practice_purposeEntities db = new practice_purposeEntities();

        // GET: returntables
        public ActionResult Index()
        {
            return View(db.returntables.ToList());
        }

        // GET: returntables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            returntable returntable = db.returntables.Find(id);
            if (returntable == null)
            {
                return HttpNotFound();
            }
            return View(returntable);
        }

        // GET: returntables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: returntables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "return_id,return_date,today_date,elapse,fine")] returntable returntable)
        {
            if (ModelState.IsValid)
            {
                db.returntables.Add(returntable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(returntable);
        }

        // GET: returntables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            returntable returntable = db.returntables.Find(id);
            if (returntable == null)
            {
                return HttpNotFound();
            }
            return View(returntable);
        }

        // POST: returntables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "return_id,return_date,today_date,elapse,fine")] returntable returntable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(returntable).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(returntable);
        }

        // GET: returntables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            returntable returntable = db.returntables.Find(id);
            if (returntable == null)
            {
                return HttpNotFound();
            }
            return View(returntable);
        }

        // POST: returntables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            returntable returntable = db.returntables.Find(id);
            db.returntables.Remove(returntable);
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

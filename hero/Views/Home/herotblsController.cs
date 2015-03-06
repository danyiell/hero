using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hero;

namespace hero.Views.Home
{
    public class herotblsController : Controller
    {
        private HeroesContext db = new HeroesContext();

        // GET: herotbls
        public ActionResult Index()
        {
            return View(db.herotbls.ToList());
        }

        // GET: herotbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            herotbl herotbl = db.herotbls.Find(id);
            if (herotbl == null)
            {
                return HttpNotFound();
            }
            return View(herotbl);
        }

        // GET: herotbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: herotbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,From,Powers,Weapons,Enemy,KnownFriends,Groups,Image,Description")] herotbl herotbl)
        {
            if (ModelState.IsValid)
            {
                db.herotbls.Add(herotbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(herotbl);
        }

        // GET: herotbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            herotbl herotbl = db.herotbls.Find(id);
            if (herotbl == null)
            {
                return HttpNotFound();
            }
            return View(herotbl);
        }

        // POST: herotbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,From,Powers,Weapons,Enemy,KnownFriends,Groups,Image,Description")] herotbl herotbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(herotbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(herotbl);
        }

        // GET: herotbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            herotbl herotbl = db.herotbls.Find(id);
            if (herotbl == null)
            {
                return HttpNotFound();
            }
            return View(herotbl);
        }

        // POST: herotbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            herotbl herotbl = db.herotbls.Find(id);
            db.herotbls.Remove(herotbl);
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

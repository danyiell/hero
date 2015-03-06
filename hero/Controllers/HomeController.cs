using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hero.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
        HeroesContext db = new HeroesContext();
        [HttpGet]
        public ActionResult Search() {
            return View(db.herotbls.ToList());
        }
        [HttpPost]
        public ActionResult Search(string searchHeroes)
        {
            if (searchHeroes != "") { 
                var heroText = from h in db.herotbls select h;
                {
                    heroText = heroText.Where(h => h.Name.ToUpper().Contains(searchHeroes.ToUpper()));
                }
                return View(heroText.ToList());
            }
            else{
                 return View(db.herotbls.ToList());
            } 
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Edit(int? id) {
          herotbl hero = db.herotbls.Find(id);
            if (hero == null)
                return HttpNotFound();
            return View(hero);           
        }
        [HttpPost]
        public ActionResult Edit(herotbl edHero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edHero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Home/Search");
            }
            return View(edHero);
        }
            public ActionResult Details(int? id) {
            if (id==null)
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            herotbl hero = db.herotbls.Find(id);
            if (hero==null)
                return HttpNotFound();
            return View(hero);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(herotbl hero)
        {
            if (ModelState.IsValid)
            {
                db.herotbls.Add(hero);
                db.SaveChanges();
                return RedirectToAction("Search");
            }
            return View(hero);
        }
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            herotbl hero = db.herotbls.Find(id);
            if (hero == null) {
                return HttpNotFound();
            }
            return View(hero);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            herotbl hero = db.herotbls.Find(id);
            db.herotbls.Remove(hero);
            db.SaveChanges();
            return RedirectToAction("Search");
        }
     }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hero.Controllers
{
    public class HeroController : Controller
    {
      HeroesContext db = new HeroesContext();
        public ActionResult showHero() {
         return View(db.herotbls.ToList());
        }

        public ActionResult Index(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            herotbl hero = db.herotbls.Find(id);
            if (hero == null)
                return HttpNotFound();
            return View(hero);
        }
        public ActionResult back() { //wasn't sure if I should use a RedirectResult or ActionResult or whatever?
            return Redirect("/Home/");
        }

    }
}
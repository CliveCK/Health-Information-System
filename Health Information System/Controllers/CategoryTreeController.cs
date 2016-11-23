using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Health_Information_System.Models;
using Health_Information_System.HIS.DAL;

namespace Health_Information_System.Controllers
{
    public class CategoryTreeController : Controller
    {
        private HISDBContext db = new HISDBContext();
        // GET: CategoryTree
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CategoryHeaderID = new SelectList(db.CategoryHeader, "CategoryHeaderID", "Description");
            return View("CategoryTree");
        }

        public ActionResult Edit(int id)
        {
            var Categories = db.CategoryHeader.Find(id);
            ViewBag.CategoryHeaderID = new SelectList(db.CategoryHeader, "CategoryHeaderID", "Description");
            return View("CategoryTree", Categories);
        }

        public ActionResult LoadCategory(int id)
        {
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "CategoryTree");
            return Json(new { Url = redirectUrl });
        }

        [HttpPost]
        public ActionResult SaveCategory([Bind( Include = "CategoryHeaderID,Description,Description2")] CategoryHeader Category)
        {
            if (ModelState.IsValid)
            {
                Category.CreatedDate = DateTime.Now;
                Category.CreatedBy = 1;
                db.CategoryHeader.Add(Category);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}
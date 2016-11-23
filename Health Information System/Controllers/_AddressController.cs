using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Health_Information_System.HIS.DAL;
using Health_Information_System.Models;

namespace Health_Information_System.Controllers
{
    public class _AddressController : Controller
    {
        private HISDBContext db = new HISDBContext();

        // GET: _Address
        public ActionResult Index()
        {
            var addresses = db.Addresses.Include(a => a.Cities);
            return View(addresses.ToList());
        }

        [ChildActionOnly]
        public ViewResult _Address(Models.Members model)
        {
            Addresses addresses = db.Addresses.Include(a => a.Cities).FirstOrDefault(a => a.OwnerTypeID == OwnerType.Member & a.OwnerID == model.ID);
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name");
            ViewBag.MemberID = model.ID;
            return View(addresses);
        }

        [ChildActionOnly]
        public ViewResult _CompanyAddress(Models.Companies model)
        {
            Addresses addresses = db.Addresses.Include(a => a.Cities).FirstOrDefault(a => a.OwnerTypeID == OwnerType.Company & a.OwnerID == model.CompanyID);
            return View(addresses);
        }

        // GET: _Address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            return View(addresses);
        }

        // GET: _Address/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name");
            return View("Members");
        }

        // POST: _Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressID,OwnerTypeID,OwnerID,Email1,Email2,ContactPerson,AddressLine1,AddressLine2,CityID,WorkTelephone,ContactPersonTelephone,IsPrimary,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(addresses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", addresses.CityID);
            return View(addresses);
        }

        public ActionResult Create([Bind(Include = "AddressID,OwnerTypeID,OwnerID,Email1,Email2,ContactPerson,AddressLine1,AddressLine2,CityID,WorkTelephone,ContactPersonTelephone,IsPrimary,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Addresses addresses, Models.Members Members)
        {
            if (ModelState.IsValid)
            {
                addresses.OwnerID = ViewBag.MemberID;
                addresses.OwnerTypeID = OwnerType.Member;
                db.Addresses.Add(addresses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", addresses.CityID);
            return View(addresses);
        }

        // GET: _Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", addresses.CityID);
            return View(addresses);
        }

        // POST: _Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressID,OwnerTypeID,OwnerID,Email1,Email2,ContactPerson,AddressLine1,AddressLine2,CityID,WorkTelephone,ContactPersonTelephone,IsPrimary,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addresses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", addresses.CityID);
            return View(addresses);
        }

        // GET: _Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            return View(addresses);
        }

        // POST: _Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Addresses addresses = db.Addresses.Find(id);
            db.Addresses.Remove(addresses);
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

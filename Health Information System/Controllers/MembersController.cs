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
    public class MembersController : Controller
    {
        private HISDBContext db = new HISDBContext();

        // GET: Members
        public ActionResult Index()
        {
            var members = db.Members.Include(m => m.BillingGroups).Include(m => m.Nationality).Include(m => m.segregatedFunds).Include(m => m.CategoryDetails).Include(m => m.Companies);
            return View(members.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.BillingGroupID = new SelectList(db.BillingGroups, "ID", "Name");
            ViewBag.NationalityID = new SelectList(db.Nationalities, "ID", "Name");
            ViewBag.SegregatedFundID = new SelectList(db.SegregatedFunds, "SegregatedFundID", "Code");
            ViewBag.CategoryID = new SelectList(db.CategoryDetails, "CategoryID", "Description");
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Name");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SegregatedFundID,MemberStatusID,MemberNo,Suffix,Title,FirstName,Initials,Surname,DateOfBirth,Sex,MaritalStatus,Race,DateOfJoining,ExpiryDate,EmailAddress,Occupation,BillingGroupID,IsDependant,HomeNo,WorkNo,Occupation,NationalIDNo,Photo,NationalityID,CompanyID,ParentID,CategoryID,IsDependant,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Members members)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(members);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BillingGroupID = new SelectList(db.BillingGroups, "ID", "Name", members.BillingGroupID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "ID", "Name", members.NationalityID);
            ViewBag.SegregatedFundID = new SelectList(db.SegregatedFunds, "SegregatedFundID", "Code", members.SegregatedFundID);
            ViewBag.CategoryID = new SelectList(db.CategoryDetails, "CategoryID", "Description", members.CategoryID);
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Name", members.CompanyID);
            return View(members);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            ViewBag.BillingGroupID = new SelectList(db.BillingGroups, "ID", "Name", members.BillingGroupID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "ID", "Name", members.NationalityID);
            ViewBag.SegregatedFundID = new SelectList(db.SegregatedFunds, "SegregatedFundID", "Code", members.SegregatedFundID);
            ViewBag.CategoryID = new SelectList(db.CategoryDetails, "CategoryID", "Description", members.CategoryID);
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Name", members.CompanyID);
            return View(members);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SegregatedFundID,MemberStatusID,MemberNo,Suffix,Title,FirstName,Initials,Surname,DateOfBirth,Sex,MaritalStatus,Race,DateOfJoining,ExpiryDate,EmailAddress,Occupation,BillingGroupID,IsDependant,HomeNo,WorkNo,Occupation,NationalIDNo,Photo,NationalityID,CompanyID,ParentID,CategoryID,IsDependant,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Members members)
        {
            if (ModelState.IsValid)
            {
                db.Entry(members).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BillingGroupID = new SelectList(db.BillingGroups, "ID", "Name", members.BillingGroupID);
            ViewBag.NationalityID = new SelectList(db.Nationalities, "ID", "Name", members.NationalityID);
            ViewBag.SegregatedFundID = new SelectList(db.SegregatedFunds, "SegregatedFundID", "Name", members.SegregatedFundID);
            ViewBag.CategoryID = new SelectList(db.CategoryDetails, "CategoryID", "Description", members.CategoryID);
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "Name", members.CompanyID);
            return View(members);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Members members = db.Members.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Members members = db.Members.Find(id);
            db.Members.Remove(members);
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

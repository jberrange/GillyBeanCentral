using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GillyBeanCentral.Entities;
using GillyBeanCentral.Models;

namespace GillyBeanCentral.Areas.Admin.Controllers
{
    public class ActivityOptionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ActivityOption
        public async Task<ActionResult> Index()
        {
            return View(await db.ActivityOptions.ToListAsync());
        }

        // GET: Admin/ActivityOption/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityOption activityOption = await db.ActivityOptions.FindAsync(id);
            if (activityOption == null)
            {
                return HttpNotFound();
            }
            return View(activityOption);
        }

        // GET: Admin/ActivityOption/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ActivityOption/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ActivityName,Byline,Description")] ActivityOption activityOption)
        {
            if (ModelState.IsValid)
            {
                db.ActivityOptions.Add(activityOption);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(activityOption);
        }

        // GET: Admin/ActivityOption/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityOption activityOption = await db.ActivityOptions.FindAsync(id);
            if (activityOption == null)
            {
                return HttpNotFound();
            }
            return View(activityOption);
        }

        // POST: Admin/ActivityOption/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ActivityName,Byline,Description")] ActivityOption activityOption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityOption).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(activityOption);
        }

        // GET: Admin/ActivityOption/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityOption activityOption = await db.ActivityOptions.FindAsync(id);
            if (activityOption == null)
            {
                return HttpNotFound();
            }
            return View(activityOption);
        }

        // POST: Admin/ActivityOption/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ActivityOption activityOption = await db.ActivityOptions.FindAsync(id);
            db.ActivityOptions.Remove(activityOption);
            await db.SaveChangesAsync();
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

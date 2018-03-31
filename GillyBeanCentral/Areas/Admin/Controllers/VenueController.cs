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
    public class VenueController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Venue
        public async Task<ActionResult> Index()
        {
            return View(await db.Venues.ToListAsync());
        }

        // GET: Admin/Venue/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = await db.Venues.FindAsync(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // GET: Admin/Venue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Venue/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,VenueName,Byline,HasAccommodation, HasEventFacilities, ThumbnailUrl, Url,VenueTypeID")] Venue venue)
        {
            if (ModelState.IsValid)
            {
                db.Venues.Add(venue);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(venue);
        }

        // GET: Admin/Venue/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = await db.Venues.FindAsync(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // POST: Admin/Venue/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,VenueName,Byline,HasAccommodation, HasEventFacilities, ThumbnailUrl, Url,VenueTypeID")] Venue venue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venue).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(venue);
        }

        // GET: Admin/Venue/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = await db.Venues.FindAsync(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // POST: Admin/Venue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Venue venue = await db.Venues.FindAsync(id);
            db.Venues.Remove(venue);
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

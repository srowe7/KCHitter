﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KCHitterDAD.Models;

namespace KCHitterDAD.Controllers
{
    public class SessionsController : Controller
    {
        private KCHitterDADContext db = new KCHitterDADContext();

        // GET: Sessions
        public ActionResult Index()
        {
            var sessions = db.Sessions.Include(s => s.Player);
            return View(sessions.ToList());
        }

        // GET: Sessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // GET: Sessions/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName");
            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SessionID,Date,PlayerID,Pitches,TotalHits,GoodContact,BadContact,ExitVelocity")] Session session)
        {
            if (ModelState.IsValid)
            {
                db.Sessions.Add(session);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", session.PlayerID);
            return View(session);
        }

        // GET: Sessions/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", session.PlayerID);
            return View(session);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SessionID,Date,PlayerID,Pitches,TotalHits,GoodContact,BadContact,ExitVelocity")] Session session)
        {
            if (ModelState.IsValid)
            {
                db.Entry(session).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", session.PlayerID);
            return View(session);
        }

        // GET: Sessions/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // POST: Sessions/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Session session = db.Sessions.Find(id);
            db.Sessions.Remove(session);
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

        public ActionResult PlayerSession([Bind(Include = "SessionID,Date,PlayerID,Pitches,TotalHits,GoodContact,BadContact,ExitVelocity")] Session session)
        {
            if (ModelState.IsValid)
            {
                db.Sessions.Add(session);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", session.PlayerID);
            return View(session);
        }
    }
}

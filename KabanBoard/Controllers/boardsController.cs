using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KabanBoard.Enitity;
using KabanBoard.Models.POCOs;

namespace KabanBoard.Controllers
{
    public class boardsController : Controller
    {
        private KanbanDB db = new KanbanDB();

        // GET: boards
        public ActionResult Index()
        {
            return View(db.board.ToList());
        }

        // GET: boards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boards boards = db.board.Find(id);
            if (boards == null)
            {
                return HttpNotFound();
            }
            return View(boards);
        }

        // GET: boards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: boards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "boardID,Title")] boards boards)
        {
            if (ModelState.IsValid)
            {
                db.board.Add(boards);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boards);
        }

        // GET: boards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boards boards = db.board.Find(id);
            if (boards == null)
            {
                return HttpNotFound();
            }
            return View(boards);
        }

        // POST: boards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "boardID,Title")] boards boards)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boards).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boards);
        }

        // GET: boards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boards boards = db.board.Find(id);
            if (boards == null)
            {
                return HttpNotFound();
            }
            return View(boards);
        }

        // POST: boards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            boards boards = db.board.Find(id);
            db.board.Remove(boards);
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

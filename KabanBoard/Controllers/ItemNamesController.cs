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
    public class ItemNamesController : Controller
    {
        private KanbanDB db = new KanbanDB();

        // GET: ItemNames
        public ActionResult Index()
        {
            return View(db.itemnames.ToList());
        }

        // GET: ItemNames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemNames itemNames = db.itemnames.Find(id);
            if (itemNames == null)
            {
                return HttpNotFound();
            }
            return View(itemNames);
        }

        // GET: ItemNames/Create
        public ActionResult Create(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: ItemNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemNamesID,ItemNameTitle")] ItemNames itemNames, int? id)
        {
            if (ModelState.IsValid)
            {
                db.board.Find(id).Items.Add(itemNames);
                db.itemnames.Add(itemNames);
                db.SaveChanges();
                return RedirectToAction("Details","boards",new {id=id});
            }

            return View(itemNames);
        }

        // GET: ItemNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemNames itemNames = db.itemnames.Find(id);
            if (itemNames == null)
            {
                return HttpNotFound();
            }
            return View(itemNames);
        }

        // POST: ItemNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemNamesID,ItemNameTitle")] ItemNames itemNames)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemNames).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemNames);
        }

        // GET: ItemNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemNames itemNames = db.itemnames.Find(id);
            if (itemNames == null)
            {
                return HttpNotFound();
            }
            return View(itemNames);
        }

        // POST: ItemNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemNames itemNames = db.itemnames.Find(id);
            db.itemnames.Remove(itemNames);
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

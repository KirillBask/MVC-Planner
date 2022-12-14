using Microsoft.AspNetCore.Mvc;
using MvcPlanner.Data;
using MvcPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcPlanner.Controllers
{
    public class PlannerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PlannerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Planner> workList = _db.PlannedWork;
            return View(workList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Planner obj)
        {
            if (ModelState.IsValid)
            {
                obj.DateCreated = DateTime.Now;
                _db.PlannedWork.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.PlannedWork.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.PlannedWork.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.PlannedWork.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.PlannedWork.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(Planner obj)
        {
            if (ModelState.IsValid)
            {
                obj.DateUpdated = DateTime.Now;
                _db.PlannedWork.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Done(int? id)
        {
            var obj = _db.PlannedWork.Find(id);
            obj.IsDone = true;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Actual()
        {
            var workList = new List<Planner>();
            workList.AddRange(_db.PlannedWork);
            var specifyList = workList.Where(x => !x.IsDone);
            _db.SaveChanges();
            return View(specifyList);
        }

        [HttpGet]
        public IActionResult All()
        {
            var workList = new List<Planner>();
            workList.AddRange(_db.PlannedWork);
            _db.SaveChanges();
            return View("Index", workList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudOperation.Models;

namespace CrudOperation.Controllers
{
    public class StudentController : Controller
    {
        public ApplicationDbContext Context = new ApplicationDbContext();
        // GET: Student
        public ActionResult Index()
        {
            var studentList = Context.Students.ToList();
            return View(studentList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student aStudent)
        {
            if (ModelState.IsValid)
            {
                Context.Students.Add(aStudent);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aStudent);
        }

        public ActionResult Edit(int? Id)
        {
            var aStudent = Context.Students.SingleOrDefault(s => s.Id == Id);

            return View(aStudent);
        }

        [HttpPost]
        public ActionResult Edit(Student aStudent)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(aStudent).State = EntityState.Modified;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aStudent);
        }

        public ActionResult Delete(int? Id)
        {
            var aStudent = Context.Students.SingleOrDefault(s => s.Id == Id);
            return View(aStudent);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var aStudent = Context.Students.SingleOrDefault(s => s.Id == id);
            Context.Students.Remove((aStudent ?? throw new InvalidOperationException()));
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
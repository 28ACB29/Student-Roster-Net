using StudentRoster.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Web.Mvc;

namespace StudentRoster.Controllers
{
	public class StudentController : Controller
	{
		private StudentRosterDB DB = new StudentRosterDB();

		// GET: Student
		public ActionResult Index()
		{
			IEnumerable<Student> students = this.DB.Students;
			return this.View(students);
		}

		// GET: Student/Details/5
		public ActionResult Details(int id)
		{
			Student student = this.DB.Students.Find(id);
			return this.View(student);
		}

		// GET: Student/Create
		public ActionResult Create()
		{
			return this.View();
		}

		// POST: Student/Create
		[HttpPost]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				this.DB.SaveChanges();
				return this.RedirectToAction("Index");
			}
			catch
			{
				return this.View();
			}
		}

		// GET: Student/Edit/5
		public ActionResult Edit(int id)
		{
			Student student = this.DB.Students.Find(id);
			return this.View(student);
		}

		// POST: Student/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here
				Student student = this.DB.Students.Find(id);
				student.SchoolYear = int.Parse(collection["SchoolYear"]);
				student.Campus = int.Parse(collection["Campus"]);
				student.EntryDate = DateTime.Parse(collection["SchoolYear"]);
				student.GradeLevel = int.Parse(collection["SchoolYear"]);
				student.SchoolYear = int.Parse(collection["SchoolYear"]);
				this.DB.Students.AddOrUpdate(student);
				this.DB.SaveChanges();
				return this.RedirectToAction("Index");
			}
			catch
			{
				return this.View();
			}
		}

		// GET: Student/Delete/5
		public ActionResult Delete(int id)
		{
			Student student = this.DB.Students.Find(id);
			return this.View(student);
		}

		// POST: Student/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here
				Student student = this.DB.Students.Find(id);
				this.DB.Students.Remove(student);
				this.DB.SaveChanges();
				return this.RedirectToAction("Index");
			}
			catch
			{
				return this.View();
			}
		}
	}
}

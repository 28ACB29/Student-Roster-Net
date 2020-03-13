using StudentRoster.Models;
using StudentRoster.Utility;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace StudentRoster.Controllers
{
	public class HomeController : Controller
	{
		private StudentRosterDB DB = new StudentRosterDB();

		public ActionResult Index()
		{
			return this.View();
		}

		public ActionResult About()
		{
			this.ViewBag.Message = "Your application description page.";

			return this.View();
		}

		public ActionResult Contact()
		{
			this.ViewBag.Message = "Your contact page.";

			return this.View();
		}

		public ActionResult Download()
		{
			IEnumerable<Student> students = this.DB.Students;
			byte[] fileData = CSVUtility.WriteCSV(students);
			return base.File(fileData, "text/csv", "Students.csv");
		}

		[HttpPost]
		public ActionResult Index(HttpPostedFileBase file)
		{
			if(file != null)
			{
				if(Path.GetExtension(file.FileName) == ".csv")
				{
					using(Stream stream = file.InputStream)
					{
						IEnumerable<Student> students = CSVUtility.ReadCSV(stream);
						foreach(Student student in students)
						{
							this.DB.Students.AddOrUpdate(student); 
						}
						this.DB.SaveChanges();
					}
				}
			}
			return this.Index();
		}
	}
}
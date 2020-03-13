using System;

namespace StudentRoster.Models
{
	public class Student
	{
		public int StudentID
		{
			get;
			set;
		}

		public int SchoolYear
		{
			get;
			set;
		}

		public int Campus
		{
			get;
			set;
		}

		public DateTime EntryDate
		{
			get;
			set;
		}

		public int GradeLevel
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public override string ToString()
		{
			return this.SchoolYear.ToString() + "," +
				this.Campus.ToString() + "," +
				this.StudentID.ToString() + "," +
				this.EntryDate.ToString("M/d/yyyy") + "," +
				this.GradeLevel.ToString() + "," +
				this.Name;
		}
	}
}
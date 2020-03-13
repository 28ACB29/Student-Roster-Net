using System.Data.Entity;

namespace StudentRoster.Models
{
	public class StudentRosterDB : DbContext
	{
		public DbSet<Student> Students
		{
			get;
			set;
		}
	}
}
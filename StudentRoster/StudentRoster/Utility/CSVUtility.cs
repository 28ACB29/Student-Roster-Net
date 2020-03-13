using Microsoft.VisualBasic.FileIO;
using StudentRoster.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StudentRoster.Utility
{
	public static class CSVUtility
	{
		private static string[] Delimiter = new string[] { "," };

		private static string[] Headers = new string[] { "SchoolYr", "Campus", "StudentID", "EntryDate", "GradeLevel", "Name" };

		private static Student ToStudent(string[] fields)
		{
			Student student;

			int SchoolYear;
			int Campus;
			int StudentID;
			DateTime EntryDate;
			int GradeLevel;

			//validate fields
			if(fields.Length == 6 &&
				int.TryParse(fields[0], out SchoolYear) &&
				int.TryParse(fields[1], out Campus) &&
				int.TryParse(fields[2], out StudentID) &&
				DateTime.TryParse(fields[3], out EntryDate) &&
				int.TryParse(fields[4], out GradeLevel))
			{

				//create new student and fill in values from fields
				student = new Student()
				{
					SchoolYear = SchoolYear,
					Campus = Campus,
					StudentID = StudentID,
					EntryDate = EntryDate,
					GradeLevel = GradeLevel,
					Name = fields[5]
				};
			}
			else
			{
				student = null;
			}
			return student;
		}

		public static IEnumerable<Student> ReadCSV(Stream stream)
		{
			using(TextFieldParser parser = new TextFieldParser(stream))
			{

				//make it a CSV parser
				parser.Delimiters = CSVUtility.Delimiter;

				//trim whitespace automatically
				parser.TrimWhiteSpace = true;
				string[] fields;
				Student student;

				//keep reading while there's data
				while(!parser.EndOfData)
				{

					//read a line's worth of fields
					fields = parser.ReadFields();

					//ignore headers
					if(!fields.SequenceEqual(CSVUtility.Headers))
					{

						//try to convert fields into a Student object
						student = CSVUtility.ToStudent(fields);

						//only yield a Student if it's valid
						if(student != null)
						{
							yield return student;
						}
					}
				}
			}
		}

		public static byte[] WriteCSV(IEnumerable<Student> Students)
		{
			byte[] bytes;
			StringBuilder builder = new StringBuilder();

			//write column headers
			builder.AppendLine(string.Join(",", CSVUtility.Headers));

			//write all students
			foreach(Student student in Students)
			{
				builder.AppendLine(student.ToString());
			}
			bytes = Encoding.UTF8.GetBytes(builder.ToString());
			return bytes;
		}
	}
}
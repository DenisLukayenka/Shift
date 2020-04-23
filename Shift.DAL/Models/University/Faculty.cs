using System.Collections.Generic;

namespace Shift.DAL.Models.University
{
	public class Faculty
	{
		public int Id { get; set; }
		public string FacultyName { get; set; }
		public string Abbreviation { get; set; }
		public string Dean { get; set; }

		public ICollection<Department> Departments { get; set; } = new List<Department>();
	}
}

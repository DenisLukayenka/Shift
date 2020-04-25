using System.Collections.Generic;

namespace Shift.DAL.Models.University
{
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.DAL.Models.UserModels.GraduateData;
	using Shift.DAL.Models.UserModels.UndergraduateData;

	public class Department
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public string Head { get; set; }

		public int? FacultyId { get; set; }
		public Faculty Faculty { get; set; }

		public ICollection<Employee> Employees { get; set; } = new List<Employee>();
		public ICollection<Undergraduate> Undergraduates { get; set; } = new List<Undergraduate>();
		public ICollection<Graduate> Graduates { get; set; } = new List<Graduate>();
	}
}

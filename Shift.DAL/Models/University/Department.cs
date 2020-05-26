using System.Collections.Generic;

namespace Shift.DAL.Models.University
{
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.DAL.Models.UserModels.GraduateData;
	using Shift.DAL.Models.UserModels.UndergraduateData;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Department
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public string Head { get; set; }

		public int? FacultyId { get; set; }
		public Faculty Faculty { get; set; }

		public ICollection<Employee> Employees { get; set; } = new List<Employee>();
	}
}

using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.EmployeeData
{
	public class AcademicDegree
	{
		public int AcademicDegreeId { get; set; }

		public string DegreeName { get; set; }

		public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
	}
}

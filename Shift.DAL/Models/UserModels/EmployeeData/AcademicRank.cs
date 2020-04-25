using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.EmployeeData
{
	public class AcademicRank
	{
		public int Id { get; set; }

		public string RankName { get; set; }

		public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
	}
}

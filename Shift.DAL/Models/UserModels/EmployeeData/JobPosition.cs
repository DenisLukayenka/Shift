using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.EmployeeData
{
	public class JobPosition
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public string ShortName { get; set; }

		public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
	}
}

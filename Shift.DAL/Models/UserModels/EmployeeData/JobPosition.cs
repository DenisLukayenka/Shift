using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.EmployeeData
{
	public class JobPosition
	{
		public int JobPositionId { get; set; }

		public string JobPositionName { get; set; }

		public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
	}
}

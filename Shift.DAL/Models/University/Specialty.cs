using System.Collections.Generic;

namespace Shift.DAL.Models.University
{
	using Shift.DAL.Models.UserModels.UserData;

	public class Specialty
	{
		public int Id { get; set; }

		public string Code { get; set; }
		public string Title { get; set; }

		public int? DepartmentId { get; set; }
		public virtual Department Department { get; set; }

		public virtual ICollection<User> Students { get; set; } = new List<User>();
	}
}

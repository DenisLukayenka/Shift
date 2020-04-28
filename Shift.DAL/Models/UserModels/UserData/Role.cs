using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.UserData
{
	public class Role
	{
		public int Id { get; set; }
		public string Caption { get; set; }

		public virtual ICollection<User> Users { get; set; } = new List<User>();
	}
}

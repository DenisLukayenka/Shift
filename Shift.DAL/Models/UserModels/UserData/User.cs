using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.UserData
{
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.DAL.Models.UserModels.GraduateData;
	using Shift.DAL.Models.UserModels.UndergraduateData;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PatronymicName { get; set; }

		public string Email { get; set; }

		public virtual ICollection<LoginInfo> LoginData { get; set; } = new List<LoginInfo>();

		public virtual Employee Employee { get; set; }
		public virtual Graduate Graduate { get; set; }
		public virtual Undergraduate Undergraduate { get; set; }

		public int RoleId { get; set; }
		public virtual Role Role { get; set; }
	}
}

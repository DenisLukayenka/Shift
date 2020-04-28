namespace Shift.Infrastructure.Models.ViewModels.Auth
{
	public class EmployeeViewModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PatronymicName { get; set; }

		public string Email { get; set; }

		public string Login { get; set; }
		public string Password { get; set; }

		public int? JobPositionId { get; set; }
		public int? DegreeId { get; set; }
		public int? RankId { get; set; }
		public int? DepartmentId { get; set; }
	}
}

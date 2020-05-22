namespace Shift.Infrastructure.Models.ViewModels.Auth
{
	public class UserRegisterVM
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PatronymicName { get; set; }
		public string Email { get; set; }

		public LoginVM Login { get; set; }
	}
}

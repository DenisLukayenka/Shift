using Shift.Infrastructure.Models.ViewModels.Users;

namespace Shift.Infrastructure.Models.ViewModels.Auth
{
	public class AuthResponse
	{
		public string Alert { get; set; }

		public UserContext User { get; set; }

		public string Token { get; set; }
	}
}

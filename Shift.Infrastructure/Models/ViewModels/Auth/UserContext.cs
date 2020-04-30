using System.Text.Json.Serialization;

namespace Shift.Infrastructure.Models.ViewModels.Auth
{
	public class UserContext
	{
		public int UserId { get; set; }
		public string Login { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		[JsonIgnore]
		public string Role { get; set; }
	}
}

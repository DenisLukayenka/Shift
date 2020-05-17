using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Shift.Infrastructure.Models.ViewModels.Users
{
	[KnownType(typeof(GraduateContext))]
	[KnownType(typeof(UndergraduateContext))]
	public class UserContext
	{
		public int UserId { get; set; }
		public int SpecifiesUserId { get; set; }
		public string Login { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		[JsonIgnore]
		public string Role { get; set; }
	}
}

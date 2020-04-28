using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.DAL.Models.UserModels.UserData
{
	public class LoginInfo
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Login { get; set; }
		public string HashPassword { get; set; }
		public string Salt { get; set; }

		public int? UserId { get; set; }
		public virtual User User { get; set; }
	}
}

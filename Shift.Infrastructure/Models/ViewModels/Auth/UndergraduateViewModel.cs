using System;
using Shift.DAL.Models.University;

namespace Shift.Infrastructure.Models.ViewModels.Auth
{
	public class UndergraduateViewModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PatronymicName { get; set; }

		public string Email { get; set; }

		public string Login { get; set; }
		public string Password { get; set; }

		public EducationForm EducationForm { get; set; }

		public int SpecialtyId { get; set; }

		public int AdviserId { get; set; }

		public DateTime StartEducationDate { get; set; }
		public DateTime FinishEducationDate { get; set; }
	}
}

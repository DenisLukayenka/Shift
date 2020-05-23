using System;

namespace Shift.Infrastructure.Models.ViewModels.Auth
{
	using Shift.DAL.Models.University;

	public class GraduateRegisterVM
	{
		public UserRegisterVM User { get; set; }

		public EducationForm EducationForm { get; set; }

		public int? SpecialtyId { get; set; }

		public int AdviserId { get; set; }

		public DateTime? StartEducationDate { get; set; }
		public DateTime? FinishEducationDate { get; set; }
	}
}

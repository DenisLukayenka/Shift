using System;
using Shift.DAL.Models.University;

namespace Shift.Infrastructure.Models.ViewModels.Auth
{
	public class UndergraduateRegisterVM
	{
		public UserRegisterVM User { get; set; }

		public EducationForm EducationForm { get; set; }

		public int? SpecialtyId { get; set; }

		public int AdviserId { get; set; }

		public DateTime? StartEducationDate { get; set; }
		public DateTime? FinishEducationDate { get; set; }
	}
}

using System;
using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.UndergraduateData
{
	using Shift.DAL.Models.University;
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.DAL.Models.UserModels.UserData;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Undergraduate
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UndergraduateId { get; set; }

		public int UserId { get; set; }
		public virtual User User { get; set; }

		public EducationForm EducationForm { get; set; } = EducationForm.DAILY;

		public DateTime? StartEducationDate { get; set; }
		public DateTime? FinishEducationDate { get; set; }

		public int? ScienceAdviserId { get; set; }
		public virtual Employee ScienceAdviser { get; set; }

		public int? SpecialtyId { get; set; }
		public virtual Specialty Specialty { get; set; }

		public virtual ICollection<UndergraduateJournal> Journals { get; set; } = new List<UndergraduateJournal>()
		{
			new UndergraduateJournal()
		};
	}
}

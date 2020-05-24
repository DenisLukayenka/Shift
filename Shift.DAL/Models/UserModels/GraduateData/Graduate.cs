using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shift.DAL.Models.UserModels.GraduateData
{
	using Shift.DAL.Models.University;
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.DAL.Models.UserModels.UserData;

	public class Graduate
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int GraduateId { get; set; }

		public int UserId { get; set; }
		public virtual User User { get; set; }

		public EducationForm EducationForm { get; set; } = EducationForm.DAILY;

		public DateTime? StartEducationDate { get; set; }
		public DateTime? FinishEducationDate { get; set; }

		public int? ScienceAdviserId { get; set; }
		public virtual Employee ScienceAdviser { get; set; }

		public int? SpecialtyId { get; set; }
		public virtual Specialty Specialty { get; set; }

		public virtual ICollection<GraduateJournal> GraduateJournals { get; set; } = new List<GraduateJournal>()
		{
			new GraduateJournal()
		};
	}
}

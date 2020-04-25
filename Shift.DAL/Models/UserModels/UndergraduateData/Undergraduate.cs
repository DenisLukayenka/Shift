using System;
using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.UndergraduateData
{
	using Shift.DAL.Models.University;
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.DAL.Models.UserModels.UserData;

	public class Undergraduate
	{
		public int Id { get; set; }
		public User User { get; set; }

		public EducationForm EducationForm { get; set; } = EducationForm.DAILY;

		public int StudyTerm { get; set; } = 2;
		public DateTime StartEducationDate { get; set; } = DateTime.Now;
		public DateTime FinishEducationDate { get; set; } =  DateTime.Now;

		public int? ScienceAdviserId { get; set; }
		public virtual Employee ScienceAdviser { get; set; }

		public int? SpecialtyId { get; set; }
		public virtual Specialty Specialty { get; set; }

		public virtual ICollection<UndergraduateJournal> Journals { get; set; } = new List<UndergraduateJournal>();
	}
}

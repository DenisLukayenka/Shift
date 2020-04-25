using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.GraduateData
{
	using Shift.DAL.Models.University;
	using Shift.DAL.Models.UserModels.GraduateData.JournalData;

	public class GraduateJournal
	{
		public int Id { get; set; }

		public int? GraduateId { get; set; }
		public virtual Graduate Graduate { get; set; }

		public int? UniversitySettingsId { get; set; }
		public virtual UniversitySettings UniversitySettings { get; set; }

		public virtual RationalInfo RationalInfo { get; set; }
		public virtual ThesisPlan ThesisPlan { get; set; }

		public virtual ICollection<WorkPlan> WorkPlans { get; set; } = new List<WorkPlan>();
		public virtual ICollection<EducationPhase> EducationYears { get; set; } = new List<EducationPhase>();
	}
}

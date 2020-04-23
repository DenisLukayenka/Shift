using System;

namespace Shift.DAL.Models.UserModels.GraduateData.JournalData
{
	public class ScienceActivity
	{
		public int Id { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }

		public string Title { get; set; }
		public string Address { get; set; }
		public string PlanResult { get; set; }

		public int? EducationPhaseId { get; set; }
		public virtual EducationPhase EducationPhase { get; set; }
	}
}

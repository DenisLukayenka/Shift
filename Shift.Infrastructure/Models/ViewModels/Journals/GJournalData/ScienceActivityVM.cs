using System;

namespace Shift.Infrastructure.Models.ViewModels.Journals.GJournalData
{
	public class ScienceActivityVM
	{
		public int? Id { get; set; }

		public DateTime? StartDate { get; set; }
		public DateTime? FinishDate { get; set; }

		public string Title { get; set; }
		public string Address { get; set; }
		public string PlanResult { get; set; }

		public int? EducationPhaseId { get; set; }
	}
}

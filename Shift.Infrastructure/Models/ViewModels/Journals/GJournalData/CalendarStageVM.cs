using System;

namespace Shift.Infrastructure.Models.ViewModels.Journals.GJournalData
{
	public class CalendarStageVM
	{
		public int Id { get; set; }

		public string StageName { get; set; }

		public DateTime StartDate { get; set; } = DateTime.Now;
		public DateTime FinishDate { get; set; } = DateTime.Now;

		public string WaitResult { get; set; }

		public string OutcomeResult { get; set; }

		public int? EducationPhaseId { get; set; }
	}
}

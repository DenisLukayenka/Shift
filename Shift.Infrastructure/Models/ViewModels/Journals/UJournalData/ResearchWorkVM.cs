using System;

namespace Shift.Infrastructure.Models.ViewModels.Journals.UJournalData
{
	public class ResearchWorkVM
	{
		public int Id { get; set; }

		public string JobType { get; set; }

		public string PresentationType { get; set; }

		public DateTime? StartDate { get; set; }
		public DateTime? FinishDate { get; set; }
	}
}

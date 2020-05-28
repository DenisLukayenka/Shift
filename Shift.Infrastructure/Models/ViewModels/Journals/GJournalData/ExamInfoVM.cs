using System;

namespace Shift.Infrastructure.Models.ViewModels.Journals.GJournalData
{
	public class ExamInfoVM
	{
		public int? Id { get; set; }
		public int? Mark { get; set; }
		public DateTime? Date { get; set; }
		public int? DisciplineId { get; set; }
		public int? GraduateJournalId { get; set; }
	}
}
